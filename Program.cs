using System;
using System.Linq;


namespace Bank;

public static class Program
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

    public static void Main()
    {
        ContaBancaria conta = new ContaBancaria(1, "Matheus", 0);
        ContaBancaria conta2 = new ContaBancaria(2, "Jose", 0);
        conta.Info();
        conta.Depositar(500);
        conta.Info();
        conta.Sacar(600);
        conta.Info();

        conta2.Info();
        conta.Transferir(conta2, 300);

        conta.Info();
        conta2.Info();


    }
}
