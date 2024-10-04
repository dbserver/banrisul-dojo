using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    class Conta
    {

        public decimal Saldo { get; private set; }
        public int NumeroDaConta { get; private set; }


        public Conta(int nroConta, decimal saldoInicial)
        {
            if (saldoInicial < 0)
            {
                throw new Exception("O valor inicial deve ser maior que zero");

            }
            Saldo = saldoInicial;
            NumeroDaConta = nroConta;
        }

        public void Depositar(decimal valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
            }
        }

        public void Sacar(decimal valor)
        {
            if (Saldo - valor >= 0)
            {
                Saldo -= valor;
            }
        }

        public void Transferir(Conta destino, decimal valor)
        {
            if (Saldo - valor >= 0)
            {
                Saldo -= valor;
                destino.Saldo += valor;
            }
        }

        public string VisulizarSaldo()
        {
            return $"Conta {NumeroDaConta}: {Saldo:0.00}";
        }



    }
}
