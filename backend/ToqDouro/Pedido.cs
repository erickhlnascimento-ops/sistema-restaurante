using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToqDouro
{
    public class Pedido
    {
        public Cliente Cliente { get; set; }
        public Prato Prato { get; set; }
        public string Status { get; set; }
        public int NumeroMesa { get; set; }

        // Construtor que aceita cliente e prato (corrige chamada new Pedido(this, prato))
        public Pedido(Cliente cliente, Prato prato)
        {
            Cliente = cliente;
            Prato = prato;
            Status = "Pendente";
        }
    }
}