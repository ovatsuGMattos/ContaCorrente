using static System.Net.Mime.MediaTypeNames;

namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ContaCorrente conta1 = new ContaCorrente();
            conta1.Saldo = 1000;
            conta1.Numero = 12;
            conta1.Limite = 0;
            conta1.Movimentacoes = new Movimentacao[10];

            conta1.Sacar(200);
            conta1.Depositar(300);
            conta1.Depositar(500);
            conta1.Sacar(200); 

            ContaCorrente conta2 = new ContaCorrente();
            conta2.Saldo = 300;
            conta2.Numero = 13;
            conta2.Limite = 0;
            conta2.Movimentacoes = new Movimentacao[10];

            conta1.Transferir(conta2, 400);

            Console.Clear();

            conta1.ExibirExtrato();
            Console.WriteLine();
            conta2.ExibirExtrato();

            Console.ReadLine();
        }
        
    }
}
