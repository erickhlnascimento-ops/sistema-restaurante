using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToqDouro
{
    public class Prato
    {
        public string Nome { get; set; }
        public double Preco { get; set; }

        public Prato(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
        }
    }
}