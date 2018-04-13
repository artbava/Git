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
            Console.WriteLine("Qual a operação que deseja realizar? - digite o número correspondente e pressione enter:");
            Console.WriteLine("1- Deposit");
            Console.WriteLine("2- Withdraw");
            Console.WriteLine("3- Show Balance");
            Console.WriteLine("4- Exit");
            opt = Console.ReadLine();
            switch ({opt})
            {
                case 1:
                Console.WriteLine("Qual a quantia que será depositada?");
                String Dep = Console.ReadLine ();
                n = Convert.ToDouble(Dep);
                b.Deposit(n);
                break;
                case 2:
                Console.WriteLine("Qual a quantia que será sacada?");
                String Withdraw = Console.ReadLine ();
                n = Convert.ToDouble(Wit);
                b.Withdraw(n);
                break;
                case 3:
                Console.WriteLine(b.GetBalance());
                break;
                case 4:
                Console.WriteLine("Ok. Até mais!");
                break;
                default:
                Console.WriteLine("Opção invalida.");
                break;
            }                                   
        }
    }
}