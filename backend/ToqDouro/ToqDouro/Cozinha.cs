using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToqDouro
{
    public class Cozinha
    {
        public List<Pedido> Pedidos { get; set; }

        public Cozinha()
        {
            Pedidos = new List<Pedido>();
        }

        public void ReceberPedido(Pedido pedido)
        {
            Pedidos.Add(pedido);
        }

        public void ReceberPedidos(List<Pedido> pedidos)
        {
            if (pedidos == null) return;
            foreach (var pedido in pedidos)
            {
                ReceberPedido(pedido);
            }
        }

        public void PrepararPedidos()
        {
            foreach (Pedido pedido in Pedidos)
            {
                pedido.Status = "Prato pronto";
            }
        }

        public void EntregarPedidos()
        {
            foreach (Pedido pedido in Pedidos)
            {
                pedido.Status = "Entregue";
            }
        }
    }
}