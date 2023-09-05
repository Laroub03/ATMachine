using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMachine
{
    // Bank.cs
    public class Bank
    {
        private Account Konto { get; }
        private PinValidator PinValidator { get; }

        public Bank(Account account, PinValidator pinValidator)
        {
            Konto = account;
            PinValidator = pinValidator;
        }

        public bool WithdrawMoney(string enteredPin, decimal amount)
        {
            if (!PinValidator.ValidatePin(enteredPin))
                return false;

            return Konto.Withdraw(amount);
        }
    }
}
