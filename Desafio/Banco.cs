using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    class Banco
    {
        public List<Cliente> listaClientes= new List<Cliente>();
        public string Nome { get; set; }

        public Banco(string nome)
        {
            Nome = nome;
        }

        public Cliente procuraCliente(string entradaUsuario)
        {
            foreach (Cliente c in listaClientes)
            {
                if (c.confereCPF(entradaUsuario))
                    return c;
            }

            return null;
        }

        public Conta procuraConta(int nroConta)
        {
            foreach(Cliente cli in listaClientes)
            {
                if (cli.procuraContaCliente(nroConta, out var conta))
                    return conta;
            }
            return null;
        }

        public Cliente criaCliente(string nome, string cpf)
        {
            bool clienteExiste = existeCliente(cpf);
            if (clienteExiste)
            {
                throw new Exception("Cliente já existente.");
            }
            Cliente novoCliente = new Cliente(nome, cpf);
            listaClientes.Add(novoCliente);
            return novoCliente;
        }

        public bool existeCliente(string cpf)
        {
            Cliente cliente = listaClientes.Find(c => !c.confereCPF(cpf));
            return cliente != null;
        }
    }
}
