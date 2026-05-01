using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToqDouro
{
    public class Mesa
    {
        public int Numero { get; set; }

        public List<Cliente> Clientes { get; set; }

        public Mesa(int numero)
        {
            Numero = numero;
            Clientes = new List<Cliente>();
        }

        public void AdicionarCliente(Cliente cliente)
        {
            Clientes.Add(cliente);
        }
    }
}