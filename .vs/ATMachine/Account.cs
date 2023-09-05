using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMachine
{
    // Konto.cs
    public class Account
    {
        public decimal Balance { get; private set; }

        public Account(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > Balance)
                return false;

            Balance -= amount;
            return true;
        }
    }

}
