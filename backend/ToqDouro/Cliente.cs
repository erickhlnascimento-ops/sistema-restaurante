using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToqDouro
{
    // Classe responsável por representar um cliente do restaurante
    public class Cliente
    {
        // Nome do cliente
        public string Nome { get; set; }

        // Lista de pedidos feitos pelo cliente
        public List<Pedido> Pedidos { get; set; }

        // Construtor da classe Cliente
        // Recebe o nome do cliente e inicia a lista de pedidos vazia
        public Cliente(string nome)
        {
            Nome = nome;
            Pedidos = new List<Pedido>();
        }

        // Método responsável por criar um novo pedido
        // Recebe um prato como parâmetro
        public void FazerPedido(Prato prato)
        {
            // Cria um novo pedido associando o cliente ao prato escolhido
            Pedido pedido = new Pedido(this, prato);

            // Adiciona o pedido na lista de pedidos do cliente
            Pedidos.Add(pedido);
        }

        // Método que calcula o total gasto pelo cliente
        public double TotalGasto()
        {
            // Soma o preço de todos os pratos pedidos
            return Pedidos.Sum(p => p.Prato.Preco);
        }
    }
}