using System;
using System.Linq;

namespace Bank.Program;

public class Program
{
    public class ContaBancaria
    {
        public static int proximoId = 1;

        public int ID { get; private set; }
        public string User { get; }
        private double saldo;

        public ContaBancaria(string user, double saldoI)
        {
            ID = proximoId++;
            User = user;
            saldo = saldoI;
        }

        //Criação de conta personalizada
        public static ContaBancaria CriarUsuario()
        {
            Console.Write("Digite seu nome : ");
            string nome = Console.ReadLine();

            Console.Write("Digite seu saldo : ");
            double saldo = Convert.ToDouble(Console.ReadLine());

            return new ContaBancaria(nome, saldo);

        }


        // Metodo para executar saque
        public bool Sacar(double value)
        {
            if (value > saldo)
            {
                Console.WriteLine("Saldo insuficiente !!!\n");
                return false;
            }
            saldo -= value;
            Console.WriteLine("Saque efetuado com sucesso !!!\n");
            return true;
        }
        //Metodo para depositar o dinheiro
        public void Depositar(double value)
        {
            saldo += value;
            Console.WriteLine("Deposito feito com sucesso !!!\n");
        }
        //Metodo para transfefencia
        public bool Transferir(ContaBancaria destino, double value)
        {
            if (Sacar(value))
            {
                destino.Depositar(value);
                Console.WriteLine($"Transferencia de R$ {value:F2} para {destino.User} feita com secesso!!!\n");
                return true;
            }
            return false;
        }

        public void Info()
        {
            Console.WriteLine($"Informações da conta...\nConta : {ID}\nNome  : {User}\nSaldo : R${saldo:F2}\n");
        }
    }
    public static void Interface(ContaBancaria conta, ContaBancaria conta2)
    {
        Console.WriteLine("\nSistema Bancario\nSeja bem vindo ao meu sistema bancario :)\n");

        bool continuar = true;
        while (continuar)
        {
            Console.Write("1-Consultar conta\n2-Sacar\n3-Depositar\n4-Traferencia\n5-Sair\n");
            int escolha = Convert.ToInt32(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    conta.Info();
                    break;

                case 2:
                    Console.Write("Escolha o valor que deseja sacar\n");
                    double valor = Convert.ToDouble(Console.ReadLine());
                    conta.Sacar(valor);
                    break;

                case 3:
                    Console.WriteLine("Digite o valor que deseja depositar");
                    double val = Convert.ToDouble(Console.ReadLine());
                    conta.Depositar(val);
                    break;

                case 4:
                    Console.WriteLine("Digite o valor da transferencia: ");
                    double transferir = Convert.ToDouble(Console.ReadLine());

                    bool transferenciabool = conta.Transferir(conta2, transferir);
                    if (transferenciabool)
                    {
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("Transferencia nao realizada. Ocorreu eu erro:(");
                    }
                    break;

                case 5:
                    continuar = false;
                    break;
            }
            if (!continuar)
            {
                Console.Clear();
                Console.WriteLine("Obrigado por usar meu banco ! Volte sempre :)");
                Console.WriteLine("Digite enter para fechar o programa");
                while (true)
                {
                    var tecla = Console.ReadKey().Key;
                    if (tecla == ConsoleKey.Enter)
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }
    }

    public static void Main()
    {
        Console.WriteLine("Criar Primeira conta :\n");
        ContaBancaria conta = ContaBancaria.CriarUsuario();

        Console.WriteLine("\nCriar segunda conta :\n");
        ContaBancaria conta2 = ContaBancaria.CriarUsuario();

        Interface(conta, conta2);
    }
}