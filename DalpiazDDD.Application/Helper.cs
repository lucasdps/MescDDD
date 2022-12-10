using DalpiazDDD.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application
{
    public class Helper
    {
        public static decimal StringToDecimal(string valor)
        {
           valor = string.IsNullOrEmpty(valor) ? "0" : valor;

            var c = System.Threading.Thread.CurrentThread.CurrentCulture;
            var s = c.NumberFormat.CurrencyDecimalSeparator;

            valor = valor.Replace(",", s);
            valor = valor.Replace(".", s);

            return Convert.ToDecimal(valor);

        }
    }
}
