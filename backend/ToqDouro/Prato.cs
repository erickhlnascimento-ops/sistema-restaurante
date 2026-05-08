using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToqDouro
{
    // Classe responsável por representar um prato do restaurante
    public class Prato
    {
        // Nome do prato
        public string Nome { get; set; }

        // Preço do prato
        public double Preco { get; set; }

        // Construtor da classe Prato
        // Recebe o nome e o preço do prato
        public Prato(string nome, double preco)
        {
            // Define o nome do prato
            Nome = nome;

            // Define o preço do prato
            Preco = preco;
        }
    }
}