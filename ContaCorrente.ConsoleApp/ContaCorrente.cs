using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.ConsoleApp
{
    public class ContaCorrente
    {
        public int Numero;
        public decimal Saldo;
        public decimal Limite;
        public Movimentacao[] Movimentacoes;
        private int movimentacaoIndex;
        
        public ContaCorrente(int numero, decimal SaldoInicial, decimal limite)
        {
            Numero = numero;
            Saldo = SaldoInicial;
            Limite = limite;
            Movimentacoes = new Movimentacao[10];
        }

        public ContaCorrente()
        {
            
        }

        private void RegistrarMovimentacao(string tipo, decimal valor)
        {
            if (movimentacaoIndex < 10) 
            {
                Movimentacoes[movimentacaoIndex++] = new Movimentacao(tipo, valor);
            }
            else
            {
                Console.WriteLine("Limite de movimentações atingido.");
            }
        }
        //Saque: Permite a retirada de valores, respeitando o limite máximo permitido.
        public void Sacar(decimal valor)
        {
            if (valor > 0 && Saldo + Limite >= valor)
            {
                Saldo -= valor;
                RegistrarMovimentacao("Saque", valor);
                Console.WriteLine("Saque realizado com sucesso.");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente, verifique valor solicitado.");
            }
        }
        //Depósito: Possibilita a adição de fundos à conta.
        public void Depositar(decimal valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
                RegistrarMovimentacao("Deposito", valor); 
                Console.WriteLine("Valor adicionado a conta com sucesso.");
            }
            else
            {
                Console.WriteLine("Valor invalido para depósito");
            }
        }
        //Transferência entre contas: Permite a movimentação de valores entre contas correntes distintas.
        public void Transferir(ContaCorrente destino, decimal valor)
        {
            if (Saldo + Limite >= valor && Saldo >= valor)
            {
                Saldo -= valor;
                destino.Saldo += valor;
                RegistrarMovimentacao("Transferencia enviada", valor);
                destino.RegistrarMovimentacao("Transferencia recebida", valor);
                Console.WriteLine($"Transferencia de R$ {valor} para conta {destino.Numero} realizada.");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente");
            }
        }
        //Emissão de extrato: Lista todas as movimentações realizadas em um período específico.
        public void ExibirExtrato()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Extrato da conta {Numero}");
            Console.WriteLine("--------------------------");
            for (int i = 0; i < movimentacaoIndex; i++)
                Console.WriteLine($"{Movimentacoes[i].GetTipo()}: R$ {Movimentacoes[i].GetValor()}");

            //Consulta de saldo: Fornece informações atualizadas sobre o montante disponível.
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Saldo atual: R$ {Saldo}");
            Console.WriteLine("--------------------------");
        }

    }
}
