using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Application.Interfaces.Mappers;
using DalpiazDDD.Domain.Entitys.ComporEntrada;
using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application.Mappers
{
    public class MapperConjuntoEntrada : IMapperConjuntoEntrada
    {
        public ConjuntoEntrada MapperDtoToEntityAdd(ConjuntoEntradaCadastroDto conjuntoEntradaDto)
        {


            var entrada = new Entrada();
            entrada.MontarEntrada(conjuntoEntradaDto.Path);
            return new ConjuntoEntrada
            {
                DataCadastro = conjuntoEntradaDto.DataCadastro,
                Descricao = conjuntoEntradaDto.Descricao,
                //Entrada = entrada,
                AssociarOperacaoEquipamentos = entrada.AssociarOperacaoEquipamentos,
                ASS_EFPs = entrada.ASS_EFPs,
                CICLO_FS = entrada.CICLO_FS,
                CICLO_FP = entrada.CICLO_FP,
                COL_OPER_FS = entrada.COL_OPER_FS,
                COL_OPER_FP = entrada.COL_OPER_FP,
                ASS_FPFSs = entrada.ASS_FPFSs,
                ASS_OEs = entrada.ASS_OEs,
                COL_OPER = entrada.COL_OPER,
                CompativelEquipamentosFpReduzidos = entrada.CompativelEquipamentosFpReduzidos,
                CompativelEquipamentosFps = entrada.CompativelEquipamentosFps,
                CompativelFPsFSReduzidas = entrada.CompativelFPsFSReduzidas,
                CompativelFPsFSs = entrada.CompativelFPsFSs,
                Equipamentos = entrada.Equipamentos,
                FPs = entrada.FPs,
                FSs = entrada.FSs,
                ManutencaoFPs = entrada.ManutencaoFPs,
                ManutencaoFSs = entrada.ManutencaoFSs,
                ModeloEquipamentos = entrada.ModeloEquipamentos,
                ModeloFPs = entrada.ModeloFPs,
                ModeloFSs = entrada.ModeloFSs,
                Operacoes = entrada.Operacoes,
                TipoModeloEquipamentos = entrada.TipoModeloEquipamentos,
                P1 = entrada.P1,
                P2 = entrada.P2,
                P3 = entrada.P3,
                QtdEquipamentos = entrada.QtdEquipamentos,
                QtdFP = entrada.QtdFP,
                QtdFS = entrada.QtdFS,
                QtdOperacoes = entrada.QtdOperacoes,
                TipoEquipamentos = entrada.TipoEquipamentos,
                TipoFPs = entrada.TipoFPs,
                TipoFSs = entrada.TipoFSs,
                TipoModeloFPs = entrada.TipoModeloFPs,
                TipoModeloFSs = entrada.TipoModeloFSs,
                TM_EQ = entrada.TM_EQ,
                TM_FP = entrada.TM_FP,
                TM_FS = entrada.TM_FS,
                TotalTipoModeloEquipamento = entrada.TotalTipoModeloEquipamento,
                TotalTipoModeloFP = entrada.TotalTipoModeloFP,
                TotalTipoModeloFS = entrada.TotalTipoModeloFS

            };
           
        }

        public ConjuntoEntrada MapperDtoToEntity(ConjuntoEntradaDto conjuntoEntradaDto)
        {


            return new ConjuntoEntrada
            {
                DataCadastro = conjuntoEntradaDto.DataCadastro,
                Descricao = conjuntoEntradaDto.Descricao,
                //Entrada = conjuntoEntradaDto.Entrada,
                Id = conjuntoEntradaDto.Id
            };

        }

        public ConjuntoEntradaDto MapperEntityToDto(ConjuntoEntrada conjuntoEntrada)
        {
            return new ConjuntoEntradaDto 
            {
                Id = conjuntoEntrada.Id,
                //Entrada = conjuntoEntrada.Entrada,
                Descricao = conjuntoEntrada.Descricao,
                DataCadastro = conjuntoEntrada.DataCadastro
            };
        }

        public IEnumerable<ConjuntoEntradaDto> MapperListFuncionariosDto(IEnumerable<ConjuntoEntrada> conjuntoEntradas)
        {
            List<ConjuntoEntradaDto> retorno = new List<ConjuntoEntradaDto>();
            conjuntoEntradas.ToList().ForEach( item => {
                retorno.Add(new ConjuntoEntradaDto 
                { 
                    Id = item.Id,
                    DataCadastro = item.DataCadastro,
                    Descricao = item.Descricao,
                    //Entrada = item.Entrada
                });
            });
            return retorno;


        }

        public ConjuntoEntradaPrevisualizacaoDto MapperEntityToDtoPrevisualizacao(ConjuntoEntrada conjuntoEntrada)
        {
            return new ConjuntoEntradaPrevisualizacaoDto 
            {
                Descricao = conjuntoEntrada.Descricao,
                Id = conjuntoEntrada.Id,
                P1 = conjuntoEntrada.P1,
                P2 = conjuntoEntrada.P2,
                P3 = conjuntoEntrada.P3 ,
                QtdEquipamentos = conjuntoEntrada.QtdEquipamentos,
                QtdFP = conjuntoEntrada.QtdFP,
                QtdFS = conjuntoEntrada.QtdFS,
                QtdOperacoes = conjuntoEntrada.QtdOperacoes
            };
        }

        public IEnumerable<ConjuntoEntradaPrevisualizacaoDto> MapperListConjuntoEntradaPrevisualizacaoDto(IEnumerable<ConjuntoEntrada> conjuntoEntradas)
        {
            List<ConjuntoEntradaPrevisualizacaoDto> retorno = new List<ConjuntoEntradaPrevisualizacaoDto>();
            conjuntoEntradas.ToList().ForEach(item => {
                retorno.Add(new ConjuntoEntradaPrevisualizacaoDto
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    QtdOperacoes = item.QtdOperacoes,
                    QtdFS = item.QtdFS,
                    QtdFP = item.QtdFP,
                    QtdEquipamentos = item.QtdEquipamentos,
                    P3 = item.P3,
                    P1 = item.P1,
                    P2 = item.P2
                });
            });
            return retorno;
        }
    }
}
