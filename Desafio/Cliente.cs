using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    class Cliente
    {
        public List<Conta> listaContas = new List<Conta>();
        public string Nome { get; set; }
        public string Cpf;

        public Cliente(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }

        public bool confereCPF(string c)
        {
            if (c.Equals(Cpf))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Conta criaConta(int id, decimal saldoInicial)
        {
            foreach(var conta in listaContas)
            {
                if (conta.NumeroDaConta == id)
                {
                    return null;
                }
            }
            Conta novaConta = new Conta(id, saldoInicial);
            listaContas.Add(novaConta);

            return novaConta;
        }
        
        public bool procuraContaCliente(int nroConta, out Conta c)
        {
            c = null;
            foreach(Conta conta in listaContas)
            {
                if(conta.NumeroDaConta == nroConta)
                {
                    c = conta;
                    return true;
                }
            }
            return false;
        }
    }
}
