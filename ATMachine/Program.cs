using System;
using System.Security.Principal;

namespace ATMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(1000);
            PinValidator pinValidator = new PinValidator();

            Bank bank = new Bank(account, pinValidator);

            Console.WriteLine("Welcome to ATMachine!");

            while (true)
            {
                Console.Write("Enter your PIN: ");
                string enteredPin = Console.ReadLine();

                if (pinValidator.ValidatePin(enteredPin))
                {
                    Console.Write("Enter the amount you want to withdraw: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                    {
                        bool withdrawalResult = bank.WithdrawMoney(enteredPin, amount);

                        if (withdrawalResult)
                        {
                            Console.WriteLine($"You withdrew {amount} USD. Your new balance is {account.Balance} USD.");
                        }
                        else
                        {
                            Console.WriteLine("Withdrawal failed. Check the amount or try again later.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount. Enter a numeric amount.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid PIN. Please try again.");
                }

                Console.WriteLine("Do you want to make another transaction? (yes/no)");
                string response = Console.ReadLine();
                if (response.ToLower() != "yes")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }
        }
    }
}
