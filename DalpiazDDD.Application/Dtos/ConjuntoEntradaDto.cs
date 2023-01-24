using DalpiazDDD.Domain.Entitys.ComporEntrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application.Dtos
{
    public class ConjuntoEntradaDto
    {
        public int Id { get; set; }
        public Entrada Entrada { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
