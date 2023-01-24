using DalpiazDDD.Domain.Entitys.ComporEntrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application.Dtos
{
    public class ConjuntoEntradaCadastroDto
    {
        public string Descricao { get; set; }
        public string Path { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
