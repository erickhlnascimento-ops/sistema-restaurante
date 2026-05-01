using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToqDouro
{
    class Exibicao
    {
        static void Main(string[] args)
        {
            // CLIENTES
            Cliente cliente1 = new Cliente("Lucas");
            Cliente cliente2 = new Cliente("Amanda");
            Cliente cliente3 = new Cliente("Carlos");

            // PRATOS
            Prato hamburguer = new Prato("Hambúrguer", 35);
            Prato pizza = new Prato("Pizza", 50);
            Prato refri = new Prato("Refrigerante", 8);
            Prato batata = new Prato("Batata Frita", 20);

            // PEDIDOS PELO CELULAR
            cliente1.FazerPedido(hamburguer);
            cliente1.FazerPedido(refri);

            cliente2.FazerPedido(pizza);

            cliente3.FazerPedido(batata);
            cliente3.FazerPedido(refri);

            // COZINHA
            Cozinha cozinha = new Cozinha();

            cozinha.ReceberPedidos(cliente1.Pedidos);
            cozinha.ReceberPedidos(cliente2.Pedidos);
            cozinha.ReceberPedidos(cliente3.Pedidos);

            // INTERFACE
            Console.WriteLine("========================================");
            Console.WriteLine("         RESTAURANTE TOQ D'OURO         ");
            Console.WriteLine("========================================");

            Console.WriteLine("\nPEDIDOS RECEBIDOS:\n");

            foreach (Pedido pedido in cozinha.Pedidos)
            {
                Console.WriteLine(
                    pedido.Cliente.Nome +
                    " pediu " +
                    pedido.Prato.Nome +
                    " - " +
                    pedido.Status
                );
            }

            // COZINHA PREPARA
            cozinha.PrepararPedidos();

            Console.WriteLine("\n========================================");
            Console.WriteLine("         COZINHA PREPARANDO             ");
            Console.WriteLine("========================================\n");

            foreach (Pedido pedido in cozinha.Pedidos)
            {
                Console.WriteLine(
                    pedido.Cliente.Nome +
                    " - " +
                    pedido.Prato.Nome +
                    " - " +
                    pedido.Status
                );
            }

            // ENTREGA
            cozinha.EntregarPedidos();

            Console.WriteLine("\n========================================");
            Console.WriteLine("          PEDIDOS ENTREGUES             ");
            Console.WriteLine("========================================\n");

            foreach (Pedido pedido in cozinha.Pedidos)
            {
                Console.WriteLine(
                    pedido.Cliente.Nome +
                    " recebeu " +
                    pedido.Prato.Nome +
                    " - " +
                    pedido.Status
                );
            }

            // CONTA FINAL
            Console.WriteLine("\n========================================");
            Console.WriteLine("             CONTA FINAL                ");
            Console.WriteLine("========================================\n");

            Console.WriteLine(cliente1.Nome + " deve R$ " + cliente1.TotalGasto());
            Console.WriteLine(cliente2.Nome + " deve R$ " + cliente2.TotalGasto());
            Console.WriteLine(cliente3.Nome + " deve R$ " + cliente3.TotalGasto());

            Console.ReadLine();
        }
    }
}