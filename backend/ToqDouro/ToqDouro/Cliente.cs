using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToqDouro
{
    public class Cliente
    {
        public string Nome { get; set; }

        public List<Pedido> Pedidos { get; set; }

        public Cliente(string nome)
        {
            Nome = nome;
            Pedidos = new List<Pedido>();
        }

        public void FazerPedido(Prato prato)
        {
            Pedido pedido = new Pedido(this, prato);
            Pedidos.Add(pedido);
        }

        public double TotalGasto()
        {
            return Pedidos.Sum(p => p.Prato.Preco);
        }
    }
}