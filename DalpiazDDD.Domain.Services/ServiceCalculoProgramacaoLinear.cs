using DalpiazDDD.Domain.Core.Interfaces.Repositorys;
using DalpiazDDD.Domain.Core.Interfaces.Services;
using DalpiazDDD.Domain.Entitys.ComporEntrada;
using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;
using DalpiazDDD.Domain.Entitys.ConjuntoResultado;
using Google.OrTools.LinearSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Services
{
    public class ServiceCalculoProgramacaoLinear : IServiceCalculoProgramacaoLinear
    {
        private readonly IRepositoryConjuntoResultado repositoryConjuntoResultado;
        public ServiceCalculoProgramacaoLinear(IRepositoryConjuntoResultado repositoryConjuntoResultado) 
        {
            this.repositoryConjuntoResultado = repositoryConjuntoResultado;
        }
        public bool ExecutarOrTools(ConjuntoEntrada entrada)
        {
            
            //entrada.MontarEntrada(null);

            ConjuntoResultado analiseResultado = new ConjuntoResultado();

            // Create the linear solver with the SCIP backend.
            Solver solver = Solver.CreateSolver("SCIP");
            solver.EnableOutput();
            //solver.SetSolverSpecificParametersAsString("limits/memory=8000");

            #region variaveis_decisao

            //Variável de decisão binária que informa se a operação foi realizada
            Variable[] u_o = new Variable[entrada.QtdOperacoes];
            for (int i = 0; i < entrada.QtdOperacoes; i++)
            {
                u_o[i] = solver.MakeBoolVar($"u_o_{i}");
            }

            //variável de decisão binária que informa se o equipamento foi usado na operação
            Variable[,] x = new Variable[entrada.QtdOperacoes, entrada.QtdEquipamentos];
            for (int i = 0; i < entrada.QtdOperacoes; i++)
            {
                for (int j = 0; j < entrada.QtdEquipamentos; j++)
                {
                    x[i, j] = solver.MakeBoolVar($"x_{i}_{j}");
                }
            }

            //variável de decisão linear que informa se a fp foi usada na operação
            Variable[,] u_fp_o = new Variable[entrada.QtdOperacoes, entrada.QtdFP];
            for (int i = 0; i < entrada.QtdOperacoes; i++)
            {
                for (int j = 0; j < entrada.QtdFP; j++)
                {
                    u_fp_o[i, j] = solver.MakeNumVar(0.0, double.PositiveInfinity, $"u_fp_o_{i}_{j}");
                }
            }

            //variável de decisão linear que informa se a fs foi usada na operação
            Variable[,] u_fs_o = new Variable[entrada.QtdOperacoes, entrada.QtdFS];
            for (int i = 0; i < entrada.QtdOperacoes; i++)
            {
                for (int j = 0; j < entrada.QtdFS; j++)
                {
                    u_fs_o[i, j] = solver.MakeNumVar(0.0, double.PositiveInfinity, $"u_fs_o_{i}_{j}");
                }
            }

            //variável de decisão binária que indica se a ferramenta primária está associada ao equipamento na operação
            Variable[,,] y = new Variable[entrada.QtdOperacoes, entrada.QtdEquipamentos, entrada.QtdFP];
            for (int i = 0; i < entrada.QtdOperacoes; i++)
            {
                for (int e = 0; e < entrada.QtdEquipamentos; e++)
                {
                    for (int j = 0; j < entrada.QtdFP; j++)
                    {
                        y[i, e, j] = solver.MakeNumVar(0.0, double.PositiveInfinity, $"y_{i}_{e}_{j}");
                    }
                }
            }

            //variável de decisão binária que indica se a ferramenta secundária está associada à ferramenta primária
            Variable[,,] z = new Variable[entrada.QtdOperacoes, entrada.QtdFP, entrada.QtdFS];
            for (int i = 0; i < entrada.QtdOperacoes; i++)
            {
                for (int e = 0; e < entrada.QtdFP; e++)
                {
                    for (int j = 0; j < entrada.QtdFS; j++)
                    {
                        z[i, e, j] = solver.MakeNumVar(0.0, double.PositiveInfinity, $"z_{i}_{e}_{j}");
                    }
                }
            }

            Console.WriteLine("Number of variables = " + solver.NumVariables());
            analiseResultado.QtdVariaveis = solver.NumVariables();
            #endregion variaveis_decisao

            #region Restrições
            //# constraint 1: Se a operação for atendida, os equipamentos devem estar associados a operação, ou seja, sndo atendidos na operação
            for (int e = 0; e < entrada.QtdEquipamentos; e++)
            {
                for (int o = 0; o < entrada.QtdOperacoes; o++)
                {
                    var item = entrada.ASS_OEs.FirstOrDefault(a => a.IdEquipamento == (e + 1) && a.IdOperacao == (o + 1));
                    if (item != null)
                    {
                        solver.Add(x[o, e] == (u_o[o] * item.Situacao));
                    }
                    else
                    {
                        solver.Add(x[o, e] == 0);
                    }
                    
                }
            }

            //# constraint 2: Se o equipamento "e" passar por uma operação, todas as ferramentas primarias necessarias devem ser consideradas
            //retirando itens zerados de ASS_EFP
            var ASS_EFP = entrada.ASS_EFPs.ToList();
            ASS_EFP.RemoveAll(x => x.Situacao == 0);
            for (int o = 0; o < entrada.QtdOperacoes; o++)
            {
                for (int e = 0; e < entrada.QtdEquipamentos; e++)
                {
                    for (int t = 0; t < entrada.TipoModeloFPs.Count(); t++)
                    {
                        if (ASS_EFP
                            .Any(a => a.IdTipoModeloEquipamento == entrada.TM_EQ.ElementAt(e) && a.IdTipoModeloFp == t + 1)
                            ) //diferente de zero
                        {
                            LinearExpr primeiraParcela = new LinearExpr();
                            for (int i = 0; i < entrada.QtdFP; i++)
                            {
                                if (entrada.TM_FP.ElementAt(i) == t + 1)
                                {
                                    primeiraParcela += y[o, e, i];
                                }
                            }
                            solver.Add(primeiraParcela >= ASS_EFP
                                   .Single(a => a.IdTipoModeloEquipamento == entrada.TM_EQ.ElementAt(e) && a.IdTipoModeloFp == t + 1)
                                   .Situacao *
                                   x[o, e]);



                        }
                    }
                }
            }

            // # constraint 3: Uma ferramenta primária só pode ser usada para um equipamento que tenha compatibilidade
            //retirando itens não zerados de ASS_EFP
            var ASS_EFP_ZERO = entrada.ASS_EFPs.ToList();
            ASS_EFP_ZERO.RemoveAll(x => x.Situacao != 0);
            for (int o = 0; o < entrada.QtdOperacoes; o++)
            {
                for (int e = 0; e < entrada.QtdEquipamentos; e++)
                {
                    for (int i = 0; i < entrada.QtdFP; i++)
                    {
                        if (ASS_EFP_ZERO.Any(a => a.IdTipoModeloEquipamento == entrada.TM_EQ.ElementAt(e) &&
                            a.IdTipoModeloFp == entrada.TM_FP.ElementAt(i))) // igual a zero
                        {
                            solver.Add(y[o, e, i] == 0);
                        }
                    }
                }
            }

            // # constraint 4: Se a FP estiver em uso por alguma operação, as FS necessárias também devem estár alocadas
            var ASS_FPFS = entrada.ASS_FPFSs.ToList();
            ASS_FPFS.RemoveAll(x => x.Situacao == 0);
            for (int o = 0; o < entrada.QtdOperacoes; o++)
            {
                for (int e = 0; e < entrada.QtdEquipamentos; e++)
                {
                    for (int i = 0; i < entrada.QtdFP; i++)
                    {
                        for (int t = 0; t < entrada.TotalTipoModeloFS; t++)
                        {
                            if (ASS_FPFS
                                .Any(a => a.IdTipoModeloFp == entrada.TM_FP.ElementAt(i) && a.IdTipoModeloFs == t + 1)
                                )// diferente de zero
                            {
                                LinearExpr primeiraParcela = new LinearExpr();
                                for (int j = 0; j < entrada.QtdFS; j++)
                                {
                                    if (entrada.TM_FS.ElementAt(j) == t + 1)
                                    {
                                        primeiraParcela += z[o, i, j];
                                    }
                                }
                                solver.Add(primeiraParcela >= ASS_FPFS.Single(a => a.IdTipoModeloFp == entrada.TM_FP.ElementAt(i) && a.IdTipoModeloFs == t + 1).Situacao
                                           * y[o, e, i]);
                            }
                        }
                    }
                }
            }

            // # constraint 5: uma FS só pode ser usada para uma fp tenha compatibilidade
            var ASS_FPFS_ZERO = entrada.ASS_FPFSs.ToList();
            ASS_FPFS_ZERO.RemoveAll(x => x.Situacao != 0);
            for (int o = 0; o < entrada.QtdOperacoes; o++)
            {
                for (int i = 0; i < entrada.QtdFP; i++)
                {
                    for (int j = 0; j < entrada.QtdFS; j++)
                    {
                        if (ASS_FPFS_ZERO.Any(a => a.IdTipoModeloFp == entrada.TM_FP.ElementAt(i) && a.IdTipoModeloFs == entrada.TM_FS.ElementAt(j)))
                        {
                            solver.Add(z[o, i, j] == 0);
                        }
                    }
                }
            }

            // # constraint 6: verificando se a FP é utilizada na operação
            for (int o = 0; o < entrada.QtdOperacoes; o++)
            {
                for (int i = 0; i < entrada.QtdFP; i++)
                {
                    LinearExpr ultimaParcela = new LinearExpr();
                    for (int e = 0; e < entrada.QtdEquipamentos; e++)
                    {
                        ultimaParcela += y[o, e, i];
                    }
                    solver.Add(u_fp_o[o, i] == ultimaParcela);
                }
            }

            // # constraint 7: verificando se a FS é utilizada na operação
            for (int o = 0; o < entrada.QtdOperacoes; o++)
            {
                for (int j = 0; j < entrada.QtdFS; j++)
                {
                    LinearExpr ultimaParcela = new LinearExpr();
                    for (int i = 0; i < entrada.QtdFP; i++)
                    {
                        ultimaParcela += z[o, i, j];
                    }
                    solver.Add(u_fs_o[o, j] == ultimaParcela);
                }
            }

            //// # constraint 8: se há colisão entre operações "o1" e "o2", então "o1" e "o2" não podem compartilhar fps;
            //// Dizemos que existe uma colisão entre duas operações se existe interseção entre os períodos destinados destinados a cada operação
            //// retirando zeros de entrada.COL_OPER
            var COL_OPER = entrada.COL_OPER.ToList();
            COL_OPER.RemoveAll(co => co.Colisao == 0);
            for (int o1 = 0; o1 < entrada.QtdOperacoes; o1++)
            {
                for (int o2 = 0; o2 < entrada.QtdOperacoes; o2++)
                {
                    if (o1 != o2 && COL_OPER.Any(a => a.IdOperacao1 == (o1 + 1) && a.IdOperacao2 == (o2 + 1)))
                    {
                        for (int i = 0; i < entrada.QtdFP; i++)
                        {
                            solver.Add(u_fp_o[o1, i] + u_fp_o[o2, i] <= 1);
                        }
                    }
                }
            }

            //// # constraint 9: se há colisão entre operações "o1" e "o2", então "o1" e "o2" não podem compartilhar fss;
            //// Dizemos que existe uma colisão entre duas operações se existe interseção entre os períodos destinados destinados a cada operação
            for (int o1 = 0; o1 < entrada.QtdOperacoes; o1++)
            {
                for (int o2 = 0; o2 < entrada.QtdOperacoes; o2++)
                {
                    if (o1 != o2 && COL_OPER.Any(a => a.IdOperacao1 == o1 + 1 && a.IdOperacao2 == o2 + 1))
                    {
                        for (int i = 0; i < entrada.QtdFS; i++)
                        {
                            solver.Add(u_fs_o[o1, i] + u_fs_o[o2, i] <= 1);
                        }
                    }
                }
            }

            // # constraint 10: Não se pode usar uma fp em manutenção
            //// retirando zeros de entrada.COL_OPER_FP
            var COL_OPER_FP = entrada.COL_OPER_FP.ToList();
            COL_OPER_FP.RemoveAll(co => co.Colisao == 0);
            for (int o = 0; o < entrada.QtdOperacoes; o++)
            {
                for (int i = 0; i < entrada.QtdFP; i++)
                {
                    if (COL_OPER_FP.Any(a => a.IdOperacao == (o + 1) && a.IdFP == (i + 1)))
                    {
                        solver.Add(u_fp_o[o, i] == 0);
                    }
                }
            }

            // # constraint 11: Não se pode usar uma fs em manutenção
            //// retirando zeros de entrada.COL_OPER_FP
            var COL_OPER_FS = entrada.COL_OPER_FS.ToList();
            COL_OPER_FS.RemoveAll(co => co.Colisao == 0);
            for (int o = 0; o < entrada.QtdOperacoes; o++)
            {
                for (int j = 0; j < entrada.QtdFS; j++)
                {
                    if (COL_OPER_FS.Any(a => a.IdOperacao == o + 1 && a.IdFS == j + 1))
                    {
                        solver.Add(u_fs_o[o, j] == 0);
                    }
                }
            }


            Console.WriteLine("Number of constraints = " + solver.NumConstraints());
            analiseResultado.QtdRestricoes = solver.NumConstraints();
            #endregion
            //
            //      FUNÇÃO OBJETIVO / minimizar
            //
            //
            Objective objective = solver.Objective();
            LinearExpr parcela1 = new LinearExpr();
            for (int o = 0; o < entrada.QtdOperacoes; o++)
            {
                if (o == 0)
                {
                    parcela1 = 1 - u_o[o];
                }
                else
                {
                    parcela1 += 1 - u_o[o];
                }
            }

            LinearExpr parcela2 = new LinearExpr();
            for (int o = 0; o < entrada.QtdOperacoes; o++)
            {
                for (int i = 0; i < entrada.QtdFP; i++)
                {
                    if (o == 0)
                    {
                        parcela2 = entrada.CICLO_FP.Single(a => a.IdFP == i + 1).QtdCiclos * u_fp_o[o, i];
                    }
                    else
                    {
                        parcela2 += entrada.CICLO_FP.Single(a => a.IdFP == i + 1).QtdCiclos * u_fp_o[o, i];
                    }
                }
            }

            LinearExpr parcela3 = new LinearExpr();
            for (int o = 0; o < entrada.QtdOperacoes; o++)
            {
                for (int j = 0; j < entrada.QtdFS; j++)
                {
                    if (o == 0)
                    {
                        parcela3 = entrada.CICLO_FS.Single(a => a.IdFS == j + 1).QtdCiclos * u_fs_o[o, j];
                    }
                    else
                    {
                        parcela3 += entrada.CICLO_FS.Single(a => a.IdFS == j + 1).QtdCiclos * u_fs_o[o, j];
                    }
                }
            }
            solver.Minimize((entrada.P1 * (parcela1)) + (entrada.P2 * parcela2) + (entrada.P3 * parcela3));

            Solver.ResultStatus resultStatus = solver.Solve();

            // Check that the problem has an optimal solution.
            if (resultStatus != Solver.ResultStatus.OPTIMAL)
            {
                Console.WriteLine("The problem does not have an optimal solution!");
                return false;
            }
            analiseResultado.Status = (int)resultStatus;
            Console.WriteLine("Solution:");
            Console.WriteLine("Optimal objective value = " + solver.Objective().Value());

            analiseResultado.ValorFuncaoObjetivo = (int) solver.Objective().Value();

            analiseResultado.TempoMilisegundos = (int)solver.WallTime();
            analiseResultado.Iteracoes = (int)solver.Iterations();
            analiseResultado.Nodes = (int)solver.Nodes();
            Console.WriteLine("\nAdvanced usage:");
            Console.WriteLine("Problem solved in " + solver.WallTime() + " milliseconds");
            Console.WriteLine("Problem solved in " + solver.Iterations() + " iterations");
            Console.WriteLine("Problem solved in " + solver.Nodes() + " branch-and-bound nodes");

            analiseResultado.IdConjuntoEntrada = entrada.Id;
            analiseResultado.Descricao = $"[{analiseResultado.TempoMilisegundos}-{analiseResultado.Iteracoes}-{analiseResultado.Nodes}-{analiseResultado.ValorFuncaoObjetivo}]";


            this.repositoryConjuntoResultado.Add(analiseResultado);

            //Variável de decisão binária que informa se a operação foi realizada
            analiseResultado.u_o = new List<AnaliseOperacao>();
            for (int i = 0; i < entrada.QtdOperacoes; i++)
            {
                if ((int)u_o[i].SolutionValue()==1)
                {
                    var a = new AnaliseOperacao();
                    a.OperacaoId = i;
                    a.Realizada = (int)u_o[i].SolutionValue();
                    analiseResultado.u_o.Add(a);
                }
                
            }

            this.repositoryConjuntoResultado.Update(analiseResultado);

            //recuperando variável de decisão binária que informa se o equipamento foi usado na operação
            analiseResultado.x = new List<AnaliseOperacaoEquipamento>();
            for (int i = 0; i < entrada.QtdOperacoes; i++)
            {
                for (int j = 0; j < entrada.QtdEquipamentos; j++)
                {
                    if ((int)x[i, j].SolutionValue()==1)
                    {
                        var a = new AnaliseOperacaoEquipamento();
                        a.Realizada = (int)x[i, j].SolutionValue();
                        a.OperacaoId = i;
                        a.EquipamentoId = j;
                        analiseResultado.x.Add(a);
                    }
                }
                this.repositoryConjuntoResultado.Update(analiseResultado);
            }

            //variável de decisão linear que informa se a fp foi usada na operação
            analiseResultado.u_fp_o = new List<AnaliseOperacaoFP>();
            for (int i = 0; i < entrada.QtdOperacoes; i++)
            {
                for (int j = 0; j < entrada.QtdFP; j++)
                {
                    if ((int)u_fp_o[i, j].SolutionValue()==1)
                    {
                        var a = new AnaliseOperacaoFP();
                        a.Realizada = (int)u_fp_o[i, j].SolutionValue();
                        a.OperacaoId = i;
                        a.FpId = j;
                        analiseResultado.u_fp_o.Add(a);
                    }
                }
                this.repositoryConjuntoResultado.Update(analiseResultado);
            }

            //variável de decisão linear que informa se a fs foi usada na operação
            analiseResultado.u_fs_o = new List<AnaliseOperacaoFS>();
            for (int i = 0; i < entrada.QtdOperacoes; i++)
            {
                for (int j = 0; j < entrada.QtdFS; j++)
                {
                    if ((int)u_fs_o[i, j].SolutionValue()==1)
                    {
                        var a = new AnaliseOperacaoFS();
                        a.Realizada = (int)u_fs_o[i, j].SolutionValue();
                        a.OperacaoId = i;
                        a.FsId = j;
                        analiseResultado.u_fs_o.Add(a);
                    }
                    
                }
                this.repositoryConjuntoResultado.Update(analiseResultado);
            }

            //variável de decisão binária que indica se a ferramenta primária está associada ao equipamento na operação
            //analiseResultado.y = new List<AnaliseOperacaoEquipamentoFP>();
            //for (int i = 0; i < entrada.QtdOperacoes; i++)
            //{
            //    for (int e = 0; e < entrada.QtdEquipamentos; e++)
            //    {
            //        for (int j = 0; j < entrada.QtdFP; j++)
            //        {
            //            var a = new AnaliseOperacaoEquipamentoFP();
            //            a.Realizada =(int) y[i, e, j].SolutionValue();
            //            a.OperacaoId = i;
            //            a.EquipamentoId = e;
            //            a.FpId = j;
            //            analiseResultado.y.Add(a);

            //        }
            //        this.repositoryConjuntoResultado.Update(analiseResultado);
            //    }
                
            //}

            //variável de decisão binária que indica se a ferramenta secundária está associada à ferramenta primária
            //analiseResultado.z = new List<AnaliseOperacaoEquipamentoFS>();
            //for (int i = 0; i < entrada.QtdOperacoes; i++)
            //{
            //    for (int e = 0; e < entrada.QtdFP; e++)
            //    {
            //        for (int j = 0; j < entrada.QtdFS; j++)
            //        {
            //            var a = new AnaliseOperacaoEquipamentoFS();
            //            a.Realizada = (int)z[i, e, j].SolutionValue();
            //            a.OperacaoId = i;
            //            a.EquipamentoId = e;
            //            a.FsId = j;
            //            analiseResultado.z.Add(a);
            //        }
            //        this.repositoryConjuntoResultado.Update(analiseResultado);
            //    }
                
            //}

            
            try
            {
                
            }
            catch (Exception ex)
            {

            }

            return true;
        }
    }
}
