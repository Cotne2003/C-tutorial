using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.src.OopPrinciples.Encapsulation
{
	internal class BankAccount
	{
		private decimal balance;

        public decimal GetBalance()
        {
            return balance;
        }

        public BankAccount(decimal balance)
        {
            Deposit(balance);
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0 )
            {
                throw new ArgumentException("Deposit amount must be positive");
            }

            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive");
            }

            if (amount > balance)
            {
                throw new InvalidOperationException("Insufficient funds");
            }

            balance -= amount;
        }
    }
}
