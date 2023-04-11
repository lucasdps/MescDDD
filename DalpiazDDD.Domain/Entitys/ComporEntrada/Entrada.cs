using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Entitys.ComporEntrada
{
    public class Entrada
    {
        public int QtdOperacoes { get; set; }
        public int QtdEquipamentos { get; set; }
        public int QtdFP { get; set; }
        public int QtdFS { get; set; }
        public int TotalTipoModeloEquipamento { get; set; }
        public int TotalTipoModeloFP { get; set; }
        public int TotalTipoModeloFS { get; set; }
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }
        public IEnumerable<AssociarOperacaoEquipamento> AssociarOperacaoEquipamentos { get; set; }
        public IEnumerable<FormulaAssociarOperacaoEquipamento> ASS_OEs { get; set; }
        public IEnumerable<FormulaCompativelEquipamentoFpExtendido> ASS_EFPs { get; set; }
        public IEnumerable<FormulaCompativelFpFsExtendido> ASS_FPFSs { get; set; }
        public IEnumerable<CompativelEquipamentoFp> CompativelEquipamentosFps { get; set; }
        public IEnumerable<CompativelEquipamentoFpReduzido> CompativelEquipamentosFpReduzidos { get; set; }

        public IEnumerable<CompativelFpFs> CompativelFPsFSs { get; set; }
        public IEnumerable<CompativelFpFsReduzida> CompativelFPsFSReduzidas { get; set; }
        public IEnumerable<Equipamento> Equipamentos { get; set; }
        public IEnumerable<FP> FPs { get; set; }
        public IEnumerable<FS> FSs { get; set; }
        public IEnumerable<ManutencaoFP> ManutencaoFPs { get; set; }
        public IEnumerable<ManutencaoFS> ManutencaoFSs { get; set; }
        public IEnumerable<ModeloEquipamento> ModeloEquipamentos { get; set; }
        public IEnumerable<ModeloFP> ModeloFPs { get; set; }
        public IEnumerable<ModeloFS> ModeloFSs { get; set; }
        public IEnumerable<Operacao> Operacoes { get; set; }
        public IEnumerable<TipoEquipamento> TipoEquipamentos { get; set; }
        public IEnumerable<TipoModeloEquipamento> TipoModeloEquipamentos { get; set; }
        public IEnumerable<int> TM_EQ { get; set; }
        public IEnumerable<TipoFP> TipoFPs { get; set; }
        public IEnumerable<TipoModeloFP> TipoModeloFPs { get; set; }
        public IEnumerable<int> TM_FP { get; set; }
        public IEnumerable<TipoFS> TipoFSs { get; set; }
        public IEnumerable<TipoModeloFS> TipoModeloFSs { get; set; }
        public IEnumerable<int> TM_FS { get; set; }
        public IEnumerable<FormulaColisaoOperacao> COL_OPER { get; set; }
        public IEnumerable<FormulaColisaoOperacaoFP> COL_OPER_FP { get; set; }
        public IEnumerable<FormulaColisaoOperacaoFS> COL_OPER_FS { get; set; }
        public IEnumerable<FormulaCicloFP> CICLO_FP { get; set; }
        public IEnumerable<FormulaCicloFS> CICLO_FS { get; set; }


        public void MontarEntrada(string? file)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            if (string.IsNullOrEmpty(file))
            {
                file = @"C:\Users\siste\source\repos\LPProblemGoogle\Entrada.xlsm";
            }
            else
            {
                file = @"C:\Users\siste\source\repos\LPProblemGoogle\" + file;
            }
            
            using (ExcelPackage package = new ExcelPackage(new FileInfo(file)))
            {
                //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                AssociarOperacaoEquipamentos = GetList<AssociarOperacaoEquipamento>(package.Workbook.Worksheets["AssociarOperacaoEquipamento"]);
                CompativelEquipamentosFps = GetList<CompativelEquipamentoFp>(package.Workbook.Worksheets["CompativelEquipamentoFp"]);
                CompativelFPsFSs = GetList<CompativelFpFs>(package.Workbook.Worksheets["CompativelFpFs"]);
                FPs = GetList<FP>(package.Workbook.Worksheets["FP"]);
                FSs = GetList<FS>(package.Workbook.Worksheets["FS"]);
                Equipamentos = GetList<Equipamento>(package.Workbook.Worksheets["Equipamento"]);
                ManutencaoFPs = GetList<ManutencaoFP>(package.Workbook.Worksheets["ManutencaoFP"]);
                ManutencaoFSs = GetList<ManutencaoFS>(package.Workbook.Worksheets["ManutencaoFS"]);
                ModeloEquipamentos = GetList<ModeloEquipamento>(package.Workbook.Worksheets["ModeloEquipamento"]);
                ModeloFPs = GetList<ModeloFP>(package.Workbook.Worksheets["ModeloFP"]);
                ModeloFSs = GetList<ModeloFS>(package.Workbook.Worksheets["ModeloFS"]);
                Operacoes = GetList<Operacao>(package.Workbook.Worksheets["Operacao"]);
                TipoEquipamentos = GetList<TipoEquipamento>(package.Workbook.Worksheets["TipoEquipamento"]);
                TipoFSs = GetList<TipoFS>(package.Workbook.Worksheets["TipoFS"]);
                TipoFPs = GetList<TipoFP>(package.Workbook.Worksheets["TipoFP"]);

                //gerar Id TipoModelo para FS
                var cont = 1;
                var listaTipoModeloFSs = new List<TipoModeloFS>();
                TipoFSs.ToList().ForEach(tfs => {
                    ModeloFSs.ToList().ForEach(mfs => {
                        listaTipoModeloFSs.Add(new TipoModeloFS { Id = cont, IdModeloFs = mfs.Id, IdTipoFs = tfs.Id });
                        cont++;
                    });
                });
                TipoModeloFSs = listaTipoModeloFSs;
                FSs.ToList().ForEach(fsitem => {
                    fsitem.IdTipoModeloFs = TipoModeloFSs.Single(a => a.IdModeloFs == fsitem.IdModeloFs
                    && a.IdTipoFs == fsitem.IdTipoFs).Id;
                });


                //gerar Id TipoModelo para FP
                cont = 1;
                var listaTipoModeloFPs = new List<TipoModeloFP>();
                TipoFPs.ToList().ForEach( tfp=> {
                    ModeloFPs.ToList().ForEach(mfp=> {
                        listaTipoModeloFPs.Add(new TipoModeloFP { Id = cont, IdModeloFp = mfp.Id, IdTipoFp = tfp.Id });
                        cont++;
                    });
                });
                TipoModeloFPs = listaTipoModeloFPs;
                FPs.ToList().ForEach( fpitem=> {
                    fpitem.IdTipoModeloFp = TipoModeloFPs.Single(a => a.IdModeloFp == fpitem.IdModeloFp
                    && a.IdTipoFp == fpitem.IdTipoFp).Id;
                });
               
                

                //Gerando CompativelFpFsReduzida
                CompativelFPsFSReduzidas = CompativelFPsFSs.Select(x=> new CompativelFpFsReduzida { 
                    IdTipoModeloFp = TipoModeloFPs.SingleOrDefault( t=>t.IdTipoFp == x.IdTipoFp && t.IdModeloFp == x.IdModeloFp).Id,
                    IdTipoModeloFs = TipoModeloFSs.SingleOrDefault(t => t.IdTipoFs == x.IdTipoFs && t.IdModeloFs == x.IdModeloFs).Id,
                    QtdFs =x.QtdFs
                });




                //gerar Id TipoModelo para Equipamento
                cont = 1;
                var listaTipoModeloEquipamentos = new List<TipoModeloEquipamento>();
                TipoFPs.ToList().ForEach(te => {
                    ModeloFPs.ToList().ForEach(me => {
                        listaTipoModeloEquipamentos.Add(new TipoModeloEquipamento { Id = cont, IdModeloEquipamento = me.Id, IdTipoEquipamento = te.Id });
                        cont++;
                    });
                });
                TipoModeloEquipamentos = listaTipoModeloEquipamentos;
                Equipamentos.ToList().ForEach(eitem => {
                    eitem.IdTipoModeloEquipamento = TipoModeloEquipamentos.Single(a => a.IdModeloEquipamento == eitem.IdModeloEquipamento
                    && a.IdTipoEquipamento == eitem.IdTipoEquipamento).Id;
                });

                //Gerando CompativelFpFsReduzida
                var listaCompativelEquipamentosFpReduzidos = new List<CompativelEquipamentoFpReduzido>();
                 CompativelEquipamentosFps.ToList().ForEach(x => {
                     listaCompativelEquipamentosFpReduzidos.Add(new CompativelEquipamentoFpReduzido { 
                        IdTipoModeloFp = TipoModeloFPs.FirstOrDefault(t => t.IdTipoFp == x.IdTipoFp && t.IdModeloFp == x.IdModeloFp).Id,
                        IdTipoModeloEquipamento = TipoModeloEquipamentos.FirstOrDefault(t => t.IdTipoEquipamento == x.IdTipoEquipamento && t.IdModeloEquipamento == x.IdModeloEquipamento).Id,
                        QtdFp = x.QtdFp
                     });
                 });
                CompativelEquipamentosFpReduzidos = listaCompativelEquipamentosFpReduzidos;




            }

            this.P1 = 100000;
            this.P2 = 1;
            this.P3 =1;
            this.QtdEquipamentos = Equipamentos.Count();
            this.QtdFP = FPs.Count();
            this.QtdFS = FSs.Count();
            this.QtdOperacoes = Operacoes.Count();
            this.TotalTipoModeloEquipamento = TipoModeloEquipamentos.Count();
            this.TotalTipoModeloFP = TipoModeloFPs.Count();
            this.TotalTipoModeloFS = TipoModeloFPs.Count();

            IList<FormulaAssociarOperacaoEquipamento> listASS_OEs = new List<FormulaAssociarOperacaoEquipamento>();
            //var contador_teste = 1;
            //Operacoes.ToList().ForEach( oitem => {
            //    Equipamentos.ToList().ForEach( eitem=> {
            //        try
            //        {
            //            var obj = AssociarOperacaoEquipamentos.FirstOrDefault(x => x. && x.IdOperacao == oitem.Id && x.IdEquipamento == eitem.Id);
            //            if (obj!=null)
            //            {
            //                listASS_OEs.Add(new FormulaAssociarOperacaoEquipamento
            //                {
            //                    IdEquipamento = eitem.Id,
            //                    IdOperacao = oitem.Id,
            //                    Situacao = obj == null ? 0 : 1

            //                });
            //            }
            //            contador_teste++;
            //        }
            //        catch (Exception ex)
            //        {


            //        }
            //    });
            //});

            AssociarOperacaoEquipamentos.ToList().ForEach(aoe=> {
                listASS_OEs.Add(new FormulaAssociarOperacaoEquipamento
                {
                    IdEquipamento = aoe.IdEquipamento,
                    IdOperacao = aoe.IdOperacao,
                    Situacao = 1

                });
            });
            ASS_OEs = listASS_OEs.ToArray();


            IList<FormulaCompativelEquipamentoFpExtendido> listASS_EFPs = new List<FormulaCompativelEquipamentoFpExtendido>();
            var qtdFp = CompativelEquipamentosFpReduzidos.Select(x=>x.IdTipoModeloFp).Distinct().Count();
            CompativelEquipamentosFpReduzidos.ToList().ForEach( eitem=> {
                for (int i = 1; i <= qtdFp; i++)
                {
                    var obj = CompativelEquipamentosFpReduzidos.FirstOrDefault(x => x.IdTipoModeloFp == i && x.IdTipoModeloEquipamento == eitem.IdTipoModeloEquipamento);
                    listASS_EFPs.Add(new FormulaCompativelEquipamentoFpExtendido { 
                        IdTipoModeloEquipamento = eitem.IdTipoModeloEquipamento,
                        IdTipoModeloFp = i,
                        Situacao = obj == null? 0 : obj.QtdFp
                    });
                }
            });
            ASS_EFPs = listASS_EFPs.ToArray();


            IList<FormulaCompativelFpFsExtendido> listASS_FPFSs = new List<FormulaCompativelFpFsExtendido>();
            var qtdFs = CompativelFPsFSReduzidas.Select(x => x.IdTipoModeloFp).Distinct().Count();
            CompativelFPsFSReduzidas.ToList().ForEach(fpitem => {
                
                for (int i = 1; i <= qtdFs; i++)
                {
                    var obj = CompativelFPsFSReduzidas.FirstOrDefault(x => x.IdTipoModeloFp == i && x.IdTipoModeloFs == fpitem.IdTipoModeloFs);
                    listASS_FPFSs.Add(new FormulaCompativelFpFsExtendido
                    {
                        IdTipoModeloFs = i,
                        IdTipoModeloFp = fpitem.IdTipoModeloFp,
                        Situacao = obj == null ? 0 : obj.QtdFs
                    });
                }
            });
            ASS_FPFSs = listASS_FPFSs.ToArray();


            var auxTM_EQ = new List<int>();
            Equipamentos.ToList().ForEach(eitem =>
            {
                auxTM_EQ.Add(eitem.IdTipoModeloEquipamento);
            });
            TM_EQ = auxTM_EQ.ToArray();

            var auxTM_FP = new List<int>();
            FPs.ToList().ForEach(fpitem =>
            {
                auxTM_FP.Add(fpitem.IdTipoModeloFp);
            });
            TM_FP = auxTM_FP.ToArray();

            var auxTM_FS = new List<int>();
            FSs.ToList().ForEach(fsitem =>
            {
                auxTM_FS.Add(fsitem.IdTipoModeloFs);
            });
            TM_FS = auxTM_FS.ToArray();


            //Calculando as colisões
            int VerificaColisaoOperacao(Operacao c1, Operacao c2)
            {
                if ( c2.DataInicio > c1.DataFim)
                {
                    return 0;
                }

                if (c1.DataInicio > c2.DataFim)
                {
                    return 0;
                }

                return 1;
                
            }
            var listaCOL_OPER = new List<FormulaColisaoOperacao>();
            for (int o1 = 0; o1 < QtdOperacoes; o1++)
            {
                var coli_1 = Operacoes.Single(a => a.Id == o1 + 1);
                for (int o2 = 0; o2 < QtdOperacoes; o2++)
                {
                    var coli_2 = Operacoes.Single(a => a.Id == o2 + 1);

                    var verificaCol = VerificaColisaoOperacao(coli_1, coli_2);

                    if (verificaCol==1)
                    {
                        listaCOL_OPER.Add(new FormulaColisaoOperacao
                        {
                            IdOperacao1 = o1 + 1,
                            IdOperacao2 = o2 + 1,
                            Colisao = verificaCol
                        });
                    }

                    
                }
            }
            COL_OPER = listaCOL_OPER;



            int VerificaColisaoOperacaoFP(Operacao c, ManutencaoFP fp)
            {
                if (c.DataInicio > fp.DataFim || fp.DataIni > c.DataFim)
                {
                    return 0;
                }

                return 1;
            }
            var listaCOL_OPER_FP = new List<FormulaColisaoOperacaoFP>();
            for (int o = 0; o < QtdOperacoes; o++)
            {
                var coli = Operacoes.Single(a => a.Id == o + 1);
                for (int fp = 0; fp < QtdFP; fp++)
                {
                    var _fp = ManutencaoFPs.Single(a => a.Id == fp + 1);

                    var verificaCol = VerificaColisaoOperacaoFP(coli, _fp);
                    if (verificaCol==1)
                    {
                        listaCOL_OPER_FP.Add(new FormulaColisaoOperacaoFP
                        {
                            IdOperacao = o + 1,
                            IdFP = fp + 1,
                            Colisao = verificaCol
                        });
                    }
                    
                }
            }
            COL_OPER_FP = listaCOL_OPER_FP;

            int VerificaColisaoOperacaoFS(Operacao c, ManutencaoFS fs)
            {
                if (c.DataInicio > fs.DataFim || fs.DataInicio > c.DataFim)
                {
                    return 0;
                }

                return 1;
            }
            var listaCOL_OPER_FS = new List<FormulaColisaoOperacaoFS>();
            for (int o = 0; o < QtdOperacoes; o++)
            {
                var coli = Operacoes.Single(a => a.Id == o + 1);
                for (int fs = 0; fs < QtdFS; fs++)
                {
                    var _fs = ManutencaoFSs.Single(a => a.Id == fs + 1);

                    var verificaCol = VerificaColisaoOperacaoFS(coli, _fs);
                    if (verificaCol == 1)
                    {
                        listaCOL_OPER_FS.Add(new FormulaColisaoOperacaoFS
                        {
                            IdOperacao = o + 1,
                            IdFS = fs + 1,
                            Colisao = verificaCol
                        });
                    }
                    
                }
            }
            COL_OPER_FS = listaCOL_OPER_FS;


            //criando ciclos para FP e FS que serão usados na função objetivo
            var listaCICLO_FP = new List<FormulaCicloFP>();
            FPs.ToList().ForEach( fpitem => {
                listaCICLO_FP.Add(new FormulaCicloFP { IdFP = fpitem.Id, QtdCiclos = fpitem.QtdCiclos });
            });
            CICLO_FP = listaCICLO_FP;

            var listaCICLO_FS = new List<FormulaCicloFS>();
            FSs.ToList().ForEach(fsitem => {
                listaCICLO_FS.Add(new FormulaCicloFS { IdFS = fsitem.Id, QtdCiclos = fsitem.QtdCiclos });
            });
            CICLO_FS = listaCICLO_FS;

        }

        private static List<T> GetList<T>(ExcelWorksheet sheet)
        {
            List<T> list = new List<T>();
            //first row is for knowing the properties of object
            var columnInfo = Enumerable.Range(1, sheet.Dimension.Columns).ToList().Select(n =>

                new { Index = n, ColumnName = sheet.Cells[1, n].Value.ToString() }
            );

            for (int row = 2; row <= sheet.Dimension.Rows; row++)
            {
                T obj = (T)Activator.CreateInstance(typeof(T));//generic object
                foreach (var prop in typeof(T).GetProperties())
                {
                    if(!columnInfo.Any(c => c.ColumnName == prop.Name))
                    {
                        continue;
                    }


                    int col = columnInfo.SingleOrDefault(c => c.ColumnName == prop.Name).Index;
                    var val = sheet.Cells[row, col].Value;
                    var propType = prop.PropertyType;
                    prop.SetValue(obj, Convert.ChangeType(val, propType));
                  
                }
                list.Add(obj);
            }

            return list;
        }


    }
}
