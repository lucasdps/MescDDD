using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Application.Interfaces.Mappers;
using DalpiazDDD.Domain.Entitys.ConjuntoResultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application.Mappers
{
    public class MapperConjuntoResultado : IMapperConjuntoResultado
    {
        public ConjuntoResultadoDto EntityToMapperDto(ConjuntoResultado conjuntoResultado)
        {
            var r = new ConjuntoResultadoDto
            {
                Id = conjuntoResultado.Id,
                Descricao = conjuntoResultado.Descricao,
                IdConjuntoEntrada = conjuntoResultado.IdConjuntoEntrada,
                Iteracoes = conjuntoResultado.Iteracoes,
                Nodes = conjuntoResultado.Nodes,
                QtdRestricoes = conjuntoResultado.QtdRestricoes,
                QtdVariaveis = conjuntoResultado.QtdVariaveis,
                Status = conjuntoResultado.Status,
                TempoMilisegundos = conjuntoResultado.TempoMilisegundos,
                ValorFuncaoObjetivo = conjuntoResultado.ValorFuncaoObjetivo
            };

            r.u_o = new List<AnaliseOperacaoDto>();
            if (conjuntoResultado.u_o != null)
                    conjuntoResultado.u_o.ToList().ForEach(item => {
                    r.u_o.Add(
                        new AnaliseOperacaoDto 
                        { 
                            ConjuntoResultadoId = item.ConjuntoResultadoId,
                            Id = item.Id,
                            OperacaoId = item.OperacaoId,
                            Realizada = item.Realizada 
                        }
                    );
                });

            r.x = new List<AnaliseOperacaoEquipamentoDto>();
            if(conjuntoResultado.x!=null)
                conjuntoResultado.x.ToList().ForEach(item => {
                    r.x.Add(
                        new AnaliseOperacaoEquipamentoDto
                        {
                            ConjuntoResultadoId = item.ConjuntoResultadoId,
                            Id = item.Id,
                            OperacaoId = item.OperacaoId,
                            Realizada = item.Realizada,
                            EquipamentoId = item.EquipamentoId
                        }
                    );
                });


            r.u_fp_o = new List<AnaliseOperacaoFPDto>();
            if (conjuntoResultado.u_fp_o != null)
                conjuntoResultado.u_fp_o.ToList().ForEach(item => {
                    r.u_fp_o.Add(
                        new AnaliseOperacaoFPDto
                        {
                            ConjuntoResultadoId = item.ConjuntoResultadoId,
                            Id = item.Id,
                            OperacaoId = item.OperacaoId,
                            Realizada = item.Realizada,
                            FpId   = item.FpId
                        }
                    );
                });

            r.u_fs_o = new List<AnaliseOperacaoFSDto>();
            if (conjuntoResultado.u_fs_o != null)
                conjuntoResultado.u_fs_o.ToList().ForEach(item => {
                    r.u_fs_o.Add(
                        new AnaliseOperacaoFSDto
                        {
                            ConjuntoResultadoId = item.ConjuntoResultadoId,
                            Id = item.Id,
                            OperacaoId = item.OperacaoId,
                            Realizada = item.Realizada,
                            FsId = item.FsId
                        }
                    );
                });

            return r;
        }

        public ConjuntoResultado MapperDtoToEntity(ConjuntoResultadoDto conjuntoResultadoDto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ConjuntoResultadoDto> MapperListResultadosDto(IEnumerable<ConjuntoResultado> conjuntoResultado)
        {
            throw new NotImplementedException();
        }

        public ConjuntoResultadoDto EntityToMapperDtoSemInclude(ConjuntoResultado conjuntoResultado)
        {
            var r = new ConjuntoResultadoDto
            {
                Id = conjuntoResultado.Id,
                Descricao = conjuntoResultado.Descricao,
                IdConjuntoEntrada = conjuntoResultado.IdConjuntoEntrada,
                Iteracoes = conjuntoResultado.Iteracoes,
                Nodes = conjuntoResultado.Nodes,
                QtdRestricoes = conjuntoResultado.QtdRestricoes,
                QtdVariaveis = conjuntoResultado.QtdVariaveis,
                Status = conjuntoResultado.Status,
                TempoMilisegundos = conjuntoResultado.TempoMilisegundos,
                ValorFuncaoObjetivo = conjuntoResultado.ValorFuncaoObjetivo
            };

           

            return r;
        }

    }
}
