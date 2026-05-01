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

        public Pedido(Cliente cliente, Prato prato)
        {
            Cliente = cliente;
            Prato = prato;
            Status = "Enviado para cozinha";
        }
    }
}