using Xunit;
using ATMachine;

namespace ATMachine.Tests
{
    public class BankTests
    {
        [Fact]
        public void TestWithdrawMoney_SuccessfulWithdraw()
        {
            Account account = new Account(1000);
            PinValidator pinValidator = new PinValidator();

            Bank bank = new Bank(account, pinValidator);

            bool result = bank.WithdrawMoney("1234", 500);

            Assert.True(result);
            Assert.Equal(500, account.Balance);
        }

        [Fact]
        public void TestWithdrawMoney_InvalidPin()
        {
            Account konto = new Account(1000);
            PinValidator pinValidator = new PinValidator();

            Bank bank = new Bank(konto, pinValidator);

            bool result = bank.WithdrawMoney("5678", 500);

            Assert.False(result);
            Assert.Equal(1000, konto.Balance);
        }

        [Fact]
        public void TestWithdrawMoney_InsufficientFunds()
        {
            Account konto = new Account(1000);
            PinValidator pinValidator = new PinValidator();

            Bank bank = new Bank(konto, pinValidator);

            bool result = bank.WithdrawMoney("1234", 1500);

            Assert.False(result);
            Assert.Equal(1000, konto.Balance);
        }
    }
}
