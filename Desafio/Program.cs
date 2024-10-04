using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Desafio
{
    public class Program
    {
        static Banco banco = new Banco("bdas");
        //static Banco banco = new Banco("Banrisul");
        public static void Main(string[] args)
        {
            MenuPrincipal();
            Console.ReadKey();
        }

        static void Testes()

        {

            //Menu();

            //Banco banco = new Banco("bdas");
            Cliente arthur = banco.criaCliente("Arthur M", "1234");
            Console.WriteLine($"{arthur.Nome}");
            //Console.WriteLine($"{arthur.criaConta(1)}");
            Conta conta1 = arthur.criaConta(GeraNumeroConta(), 1000);

            Cliente matheus = banco.criaCliente("Matheus M", "4321");
            Console.WriteLine($"{matheus.Nome}");
            //Console.WriteLine($"{matheus.criaConta(1)}");
            Conta conta2 = matheus.criaConta(GeraNumeroConta(), 500);

            Console.WriteLine("Saldo Conta Arthur: R$ " + conta1.Saldo);
            Console.WriteLine("Saldo Conta Matheus: R$ " + conta2.Saldo);
            Console.WriteLine("Numero da Conta Matheus: " + conta2.NumeroDaConta);
            Console.WriteLine("Numero da Conta Arthur: " + conta1.NumeroDaConta);


            conta1.Transferir(conta2, 250);
            //Transferencia
            Console.WriteLine("-----------------");
            Console.WriteLine("Saldo Conta Arthur: R$ " + conta1.Saldo);
            Console.WriteLine("Saldo Conta Matheus: R$ " + conta2.Saldo);
            conta2.Sacar(100);
            Console.WriteLine($"Saldo Conta Matheus: R$ {conta2.Saldo:0.00}");
            Console.WriteLine(conta2.VisulizarSaldo());

            Conta contaProcurada = banco.procuraConta(conta2.NumeroDaConta);
            Console.WriteLine("\n\n" + contaProcurada.Saldo);

        }
        static int GeraNumeroConta()
        {
            int numeroGerado = new Random().Next(1, int.MaxValue);

            if (banco.procuraConta(numeroGerado) == null)
            {
                return numeroGerado;
            }
            return GeraNumeroConta();
            
        }

        static void MenuPrincipal()
        {

            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Entrar");
            Console.Write("OPÇÃO:");
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    Console.Write("Digite seu nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Digite seu CPF: ");
                    string cpf = Console.ReadLine();
                    banco.criaCliente(nome, cpf);
                    break;
                case 2:

                    break;
            }
            
        }

        static void MenuCliente(string cpf)
        {
            if (cpf != null)
            {
                Console.Write("Digite seu CPF: ");
                cpf = Console.ReadLine();
            }
            Cliente clienteLogado = banco.procuraCliente(cpf);

            Console.Write("1- Criar conta" +
                "2- Acessar conta" +
                "OPÇÃO: ");
            int opcao = int.Parse(Console.ReadLine());

            switch(opcao)
            {
                case 1:
                    Console.Write("Indorme seu saldo incial: ");

                    Conta conta1 = clienteLogado.criaConta(GeraNumeroConta(), );
                    break;
                case 2:
                    break;

            }
        }
    }
}
