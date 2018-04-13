using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearn
{
    class BankAccount {
        private double balance=0;
        public void Deposit(double n) {
            balance += n;
        }
        public void Withdraw(double n) {
            balance -= n;
        }
        public double GetBalance() {
            return balance;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount b = new BankAccount();
            Console.WriteLine("Qual a operação que deseja realizar?);
            Console.WriteLine("1- Depósito");
            Console.WriteLine("2- Saque");
            Console.WriteLine("3- Saldo");
            Console.WriteLine("4- Sair");
            opt = Console.ReadLine();
            switch ({opt})
            {
                case 1:
                Console.WriteLine("Qual a quantia?");
                String Dep = Console.ReadLine ();
                n = Convert.ToDouble(Dep);
                b.Deposit(n);
                Console.WriteLine(b.GetBalance());
                break;
                case 2:
                Console.WriteLine("Qual a quantia?");
                String Wit = Console.ReadLine ();
                n = Convert.ToDouble(Wit);
                b.Withdraw(n);
                Console.WriteLine(b.GetBalance());
                break;
                case 3:
                Console.WriteLine(b.GetBalance());
                Console.ReadLine();
                break;
                case 4:
                Console.WriteLine("Ok. Até mais!");
                Console.ReadLine();
                break;
                default:
                Console.WriteLine("Opção invalida.");
                Console.ReadLine();
                break;
            }                                   
        }
    }
}