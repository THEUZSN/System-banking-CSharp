using System;
using System.Linq;


namespace Bank;

public class Program
{
    public class ContaBancaria
    {
        public int ID { get; }
        public string User { get; }
        private double saldo;

        public ContaBancaria(int id, string user, double saldoI)
        {
            ID = id;
            User = user;
            saldo = saldoI;
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
        Console.WriteLine("Sistema Bancario\nSeja bem vindo ao meu sistema bancario :)\n");

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
                Console.WriteLine("Aperte qualquer tecla");
                Console.ReadKey();
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
        ContaBancaria conta = new ContaBancaria(1, "Matheus", 1000);
        ContaBancaria conta2 = new ContaBancaria(2, "Jose", 1000);

        Interface(conta, conta2);
    }
}