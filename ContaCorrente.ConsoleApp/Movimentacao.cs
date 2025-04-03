using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.ConsoleApp
{
    public class Movimentacao
    {
        private string tipo;
        private decimal valor;

        public Movimentacao(string tipo, decimal valor)
        {
            this.tipo = tipo;
            this.valor = valor;
        }
        public string GetTipo()
        {
            return tipo; 
        }
        public decimal GetValor()
        {
            return valor; 
        }
    }
}
