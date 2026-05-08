using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToqDouro
{
    // Classe responsável por representar a cozinha do restaurante
    public class Cozinha
    {
        // Lista de pedidos recebidos pela cozinha
        public List<Pedido> Pedidos { get; set; }

        // Construtor da classe Cozinha
        // Inicia a lista de pedidos vazia
        public Cozinha()
        {
            Pedidos = new List<Pedido>();
        }

        // Método responsável por receber um único pedido
        public void ReceberPedido(Pedido pedido)
        {
            // Adiciona o pedido na lista da cozinha
            Pedidos.Add(pedido);
        }

        // Método responsável por receber vários pedidos de uma vez
        public void ReceberPedidos(List<Pedido> pedidos)
        {
            // Verifica se a lista está vazia ou nula
            if (pedidos == null) return;

            // Percorre todos os pedidos recebidos
            foreach (var pedido in pedidos)
            {
                // Envia cada pedido para o método de adicionar pedido
                ReceberPedido(pedido);
            }
        }

        // Método responsável por preparar todos os pedidos
        public void PrepararPedidos()
        {
            // Percorre todos os pedidos da cozinha
            foreach (Pedido pedido in Pedidos)
            {
                // Atualiza o status do pedido para pronto
                pedido.Status = "Prato pronto";
            }
        }

        // Método responsável por entregar todos os pedidos
        public void EntregarPedidos()
        {
            // Percorre todos os pedidos
            foreach (Pedido pedido in Pedidos)
            {
                // Atualiza o status do pedido para entregue
                pedido.Status = "Entregue";
            }
        }
    }
}