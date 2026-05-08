using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToqDouro
{
    class Exibicao
    {
        // =====================================
        // LISTA GERAL DE PEDIDOS
        // =====================================

        static List<Pedido> pedidosGerais =
            new List<Pedido>();

        // =====================================
        // CARDÁPIO
        // =====================================

        static List<Prato> cardapio =
            new List<Prato>()
        {
            new Prato("Hambúrguer", 35),
            new Prato("Pizza", 50),
            new Prato("Refrigerante", 8),
            new Prato("Batata Frita", 20),
            new Prato("Hot Dog", 18),
            new Prato("Milk Shake", 22),
            new Prato("Suco Natural", 12),
            new Prato("Lasanha", 45),
            new Prato("Strogonoff", 40),
            new Prato("Sorvete", 15),
            new Prato("Coxinha", 10),
            new Prato("Pastel", 14),
            new Prato("Açaí", 25),
            new Prato("Pudim", 13)
        };

        static void Main(string[] args)
        {
            Cozinha cozinha =
                new Cozinha();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("====================================");
                Console.WriteLine("       RESTAURANTE TOQ D'OURO      ");
                Console.WriteLine("====================================");

                Console.WriteLine("1 - Área do Cliente");
                Console.WriteLine("2 - Área ADM");
                Console.WriteLine("0 - Sair");

                Console.Write(
                    "\nEscolha uma opção: "
                );

                string opcao =
                    Console.ReadLine();

                switch (opcao)
                {
                    case "1":

                        TelaCliente(
                            cozinha
                        );

                        break;

                    case "2":

                        TelaADM(
                            cozinha
                        );

                        break;

                    case "0":

                        return;

                    default:

                        Console.WriteLine(
                            "\nOpção inválida."
                        );

                        Console.ReadLine();

                        break;
                }
            }
        }

        // =====================================
        // ÁREA CLIENTE
        // =====================================

        static void TelaCliente(
            Cozinha cozinha
        )
        {
            Console.Clear();

            Console.WriteLine(
                "======= ÁREA DO CLIENTE ======="
            );

            Console.Write(
                "Digite o número da mesa: "
            );

            int numeroMesa =
                LerInt("", 1);

            // Lista de clientes da mesa
            List<Cliente> clientesMesa =
                new List<Cliente>();

            // ==============================
            // ADICIONAR CLIENTES
            // ==============================

            while (true)
            {
                Console.Clear();

                Console.WriteLine(
                    "======= ADICIONAR CLIENTES ======="
                );

                Console.Write(
                    "Nome do cliente: "
                );

                string nome =
                    Console.ReadLine();

                Cliente cliente =
                    new Cliente(nome);

                clientesMesa.Add(
                    cliente
                );

                Console.Write(
                    "\nAdicionar outra pessoa? (s/n): "
                );

                string resposta =
                    Console.ReadLine()
                    .ToLower();

                if (resposta != "s")
                    break;
            }

            // ==============================
            // PEDIDOS
            // ==============================

            foreach (
                Cliente cliente
                in clientesMesa
            )
            {
                while (true)
                {
                    Console.Clear();

                    Console.WriteLine(
                        "======= PEDIDO DE " +
                        cliente.Nome.ToUpper() +
                        " ======="
                    );

                    // Mostrar cardápio
                    for (
                        int i = 0;
                        i < cardapio.Count;
                        i++
                    )
                    {
                        Console.WriteLine(
                            (i + 1) +
                            " - " +
                            cardapio[i].Nome +
                            " | R$ " +
                            cardapio[i].Preco
                        );
                    }

                    Console.WriteLine(
                        "0 - Finalizar Pedido"
                    );

                    Console.Write(
                        "\nEscolha um prato: "
                    );

                    int escolha =
                        LerInt(
                            "",
                            0,
                            cardapio.Count
                        );

                    // Finalizar pedido
                    if (escolha == 0)
                        break;

                    Prato pratoEscolhido =
                        cardapio[
                            escolha - 1
                        ];

                    cliente.FazerPedido(
                        pratoEscolhido
                    );

                    Pedido pedido =
                        cliente.Pedidos.Last();

                    pedido.NumeroMesa =
                        numeroMesa;

                    // STATUS INICIAL
                    pedido.Status =
                        "Preparando";

                    cozinha.ReceberPedido(
                        pedido
                    );

                    pedidosGerais.Add(
                        pedido
                    );

                    Console.WriteLine(
                        "\nPedido enviado!"
                    );

                    Console.WriteLine(
                        "\nStatus atual: " +
                        pedido.Status
                    );

                    Console.WriteLine(
                        "\nPressione ENTER..."
                    );

                    Console.ReadLine();
                }
            }

            // ==============================
            // CONTA FINAL
            // ==============================

            Console.Clear();

            Console.WriteLine(
                "======= CONTA DA MESA " +
                numeroMesa +
                " =======\n"
            );

            double totalMesa = 0;

            foreach (
                Cliente cliente
                in clientesMesa
            )
            {
                double totalCliente =
                    cliente.TotalGasto();

                totalMesa +=
                    totalCliente;

                Console.WriteLine(
                    cliente.Nome +
                    " gastou R$ " +
                    totalCliente
                );
            }

            Console.WriteLine(
                "\nTOTAL DA MESA: R$ " +
                totalMesa
            );

            Console.ReadLine();
        }

        // =====================================
        // ÁREA ADM
        // =====================================

        static void TelaADM(
            Cozinha cozinha
        )
        {
            Console.Clear();

            Console.WriteLine(
                "======= LOGIN ADM ======="
            );

            Console.Write(
                "Digite a senha: "
            );

            string senha =
                LerSenha();

            if (senha != "admin123")
            {
                Console.WriteLine(
                    "\nSenha incorreta."
                );

                Console.ReadLine();

                return;
            }

            while (true)
            {
                Console.Clear();

                Console.WriteLine(
                    "======= PAINEL ADM ======="
                );

                Console.WriteLine(
                    "1 - Ver pedidos"
                );

                Console.WriteLine(
                    "2 - Alterar status da mesa"
                );

                Console.WriteLine(
                    "3 - Cancelar pedido"
                );

                Console.WriteLine(
                    "4 - Ver cardápio"
                );

                Console.WriteLine(
                    "5 - Adicionar item"
                );

                Console.WriteLine(
                    "6 - Editar item"
                );

                Console.WriteLine(
                    "7 - Remover item"
                );

                Console.WriteLine(
                    "0 - Voltar"
                );

                Console.Write(
                    "\nEscolha uma opção: "
                );

                string opcao =
                    Console.ReadLine();

                switch (opcao)
                {
                    // =========================
                    // VER PEDIDOS
                    // =========================

                    case "1":

                        Console.Clear();

                        Console.WriteLine(
                            "======= PEDIDOS =======\n"
                        );

                        var mesas =
                            pedidosGerais
                            .GroupBy(
                                p => p.NumeroMesa
                            );

                        foreach (
                            var mesa in mesas
                        )
                        {
                            Console.WriteLine(
                                "Mesa " +
                                mesa.Key
                            );

                            foreach (
                                Pedido pedido
                                in mesa
                            )
                            {
                                Console.WriteLine(
                                    pedido.Cliente.Nome +
                                    " pediu " +
                                    pedido.Prato.Nome +
                                    " - " +
                                    pedido.Status
                                );
                            }

                            Console.WriteLine(
                                "----------------------"
                            );
                        }

                        Console.ReadLine();

                        break;

                    // =========================
                    // ALTERAR STATUS
                    // =========================

                    case "2":

                        Console.Clear();

                        Console.WriteLine(
                            "======= ALTERAR STATUS =======\n"
                        );

                        var mesasExistentes =
                            pedidosGerais
                            .Select(
                                p => p.NumeroMesa
                            )
                            .Distinct();

                        foreach (
                            int mesa
                            in mesasExistentes
                        )
                        {
                            Console.WriteLine(
                                "Mesa " +
                                mesa
                            );
                        }

                        Console.Write(
                            "\nDigite a mesa: "
                        );

                        int mesaSelecionada =
                            LerInt("", 1);

                        var pedidosMesa =
                            pedidosGerais
                            .Where(
                                p =>
                                    p.NumeroMesa ==
                                    mesaSelecionada
                            );

                        if (
                            !pedidosMesa.Any()
                        )
                        {
                            Console.WriteLine(
                                "\nMesa não encontrada."
                            );

                            Console.ReadLine();

                            break;
                        }

                        Console.WriteLine(
                            "\n1 - Preparando"
                        );

                        Console.WriteLine(
                            "2 - Entregue"
                        );

                        Console.WriteLine(
                            "3 - Finalizado"
                        );

                        Console.Write(
                            "\nNovo status: "
                        );

                        string statusOpcao =
                            Console.ReadLine();

                        string novoStatus =
                            "";

                        switch (
                            statusOpcao
                        )
                        {
                            case "1":

                                novoStatus =
                                    "Preparando";

                                break;

                            case "2":

                                novoStatus =
                                    "Entregue";

                                break;

                            case "3":

                                novoStatus =
                                    "Finalizado";

                                break;

                            default:

                                Console.WriteLine(
                                    "\nStatus inválido."
                                );

                                Console.ReadLine();

                                continue;
                        }

                        foreach (
                            Pedido pedido
                            in pedidosMesa
                        )
                        {
                            pedido.Status =
                                novoStatus;
                        }

                        Console.WriteLine(
                            "\nStatus atualizado!"
                        );

                        Console.ReadLine();

                        break;

                    // =========================
                    // CANCELAR PEDIDO
                    // =========================

                    case "3":

                        Console.Clear();

                        Console.WriteLine(
                            "======= CANCELAR PEDIDO =======\n"
                        );

                        for (
                            int i = 0;
                            i < pedidosGerais.Count;
                            i++
                        )
                        {
                            Console.WriteLine(
                                i +
                                " - " +
                                pedidosGerais[i]
                                    .Cliente.Nome +
                                " | Mesa " +
                                pedidosGerais[i]
                                    .NumeroMesa +
                                " | " +
                                pedidosGerais[i]
                                    .Prato.Nome
                            );
                        }

                        Console.Write(
                            "\nDigite o pedido: "
                        );

                        int cancelar =
                            LerInt(
                                "",
                                0,
                                pedidosGerais.Count - 1
                            );

                        pedidosGerais
                            .RemoveAt(
                                cancelar
                            );

                        Console.WriteLine(
                            "\nPedido cancelado!"
                        );

                        Console.ReadLine();

                        break;

                    // =========================
                    // VER CARDÁPIO
                    // =========================

                    case "4":

                        Console.Clear();

                        Console.WriteLine(
                            "======= CARDÁPIO =======\n"
                        );

                        for (
                            int i = 0;
                            i < cardapio.Count;
                            i++
                        )
                        {
                            Console.WriteLine(
                                i +
                                " - " +
                                cardapio[i].Nome +
                                " | R$ " +
                                cardapio[i].Preco
                            );
                        }

                        Console.ReadLine();

                        break;

                    // =========================
                    // ADICIONAR ITEM
                    // =========================

                    case "5":

                        Console.Clear();

                        Console.WriteLine(
                            "======= ADICIONAR ITEM =======\n"
                        );

                        Console.Write(
                            "Nome: "
                        );

                        string novoNome =
                            Console.ReadLine();

                        Console.Write(
                            "Preço: "
                        );

                        double novoPreco =
                            double.Parse(
                                Console.ReadLine()
                            );

                        cardapio.Add(
                            new Prato(
                                novoNome,
                                novoPreco
                            )
                        );

                        Console.WriteLine(
                            "\nItem adicionado!"
                        );

                        Console.ReadLine();

                        break;

                    // =========================
                    // EDITAR ITEM
                    // =========================

                    case "6":

                        Console.Clear();

                        Console.WriteLine(
                            "======= EDITAR ITEM =======\n"
                        );

                        for (
                            int i = 0;
                            i < cardapio.Count;
                            i++
                        )
                        {
                            Console.WriteLine(
                                i +
                                " - " +
                                cardapio[i].Nome +
                                " | R$ " +
                                cardapio[i].Preco
                            );
                        }

                        Console.Write(
                            "\nDigite o item: "
                        );

                        int editar =
                            LerInt(
                                "",
                                0,
                                cardapio.Count - 1
                            );

                        Console.Write(
                            "Novo nome: "
                        );

                        cardapio[editar].Nome =
                            Console.ReadLine();

                        Console.Write(
                            "Novo preço: "
                        );

                        cardapio[editar].Preco =
                            double.Parse(
                                Console.ReadLine()
                            );

                        Console.WriteLine(
                            "\nItem atualizado!"
                        );

                        Console.ReadLine();

                        break;

                    // =========================
                    // REMOVER ITEM
                    // =========================

                    case "7":

                        Console.Clear();

                        Console.WriteLine(
                            "======= REMOVER ITEM =======\n"
                        );

                        for (
                            int i = 0;
                            i < cardapio.Count;
                            i++
                        )
                        {
                            Console.WriteLine(
                                i +
                                " - " +
                                cardapio[i].Nome +
                                " | R$ " +
                                cardapio[i].Preco
                            );
                        }

                        Console.Write(
                            "\nDigite o item: "
                        );

                        int remover =
                            LerInt(
                                "",
                                0,
                                cardapio.Count - 1
                            );

                        cardapio.RemoveAt(
                            remover
                        );

                        Console.WriteLine(
                            "\nItem removido!"
                        );

                        Console.ReadLine();

                        break;

                    case "0":

                        return;

                    default:

                        Console.WriteLine(
                            "\nOpção inválida."
                        );

                        Console.ReadLine();

                        break;
                }
            }
        }

        // =====================================
        // ESCONDER SENHA
        // =====================================

        static string LerSenha()
        {
            StringBuilder senha =
                new StringBuilder();

            ConsoleKeyInfo tecla;

            while (true)
            {
                tecla =
                    Console.ReadKey(true);

                if (
                    tecla.Key ==
                    ConsoleKey.Enter
                )
                {
                    Console.WriteLine();

                    break;
                }

                if (
                    tecla.Key ==
                    ConsoleKey.Backspace &&
                    senha.Length > 0
                )
                {
                    senha.Remove(
                        senha.Length - 1,
                        1
                    );

                    Console.Write(
                        "\b \b"
                    );
                }
                else if (
                    !char.IsControl(
                        tecla.KeyChar
                    )
                )
                {
                    senha.Append(
                        tecla.KeyChar
                    );

                    Console.Write("*");
                }
            }

            return senha.ToString();
        }

        // =====================================
        // VALIDAR NÚMEROS
        // =====================================

        static int LerInt(
            string prompt,
            int minimo =
                int.MinValue,
            int maximo =
                int.MaxValue
        )
        {
            while (true)
            {
                Console.Write(
                    prompt
                );

                string entrada =
                    Console.ReadLine()
                    ?.Trim();

                if (
                    int.TryParse(
                        entrada,
                        out int valor
                    )
                )
                {
                    if (
                        valor >= minimo &&
                        valor <= maximo
                    )
                    {
                        return valor;
                    }

                    Console.WriteLine(
                        $"Valor deve estar entre {minimo} e {maximo}."
                    );
                }
                else
                {
                    Console.WriteLine(
                        "Digite um número válido."
                    );
                }
            }
        }
    }
}