using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BankAccountNS;
namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }



        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }


        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRangeDebit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 99999999.00;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }




        [TestMethod]
        public void Credit_WhenAmountIsNegative_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            double beginningBalance = 100.00;
            double creditAmount = -50.00;
            BankAccount account = new BankAccount("Mr. John Doe", beginningBalance);

            // Act and assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Credit(creditAmount));
        }
        [TestMethod]
        public void Credit_WhenAmountIsPositive_ShouldDeductFromBalance()
        {
            // Arrange
            double beginningBalance = 100.00;
            double creditAmount = 50.00;
            BankAccount account = new BankAccount("Mr. John Doe", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            // Поскольку метод Credit уменьшает баланс, новый баланс должен быть равен 100 - 50 = 50
            Assert.AreEqual(50.00, account.Balance, "Balance should be deducted by the credit amount.");
        }


        [TestMethod]
        public void Credit_WhenAmountIsZero_ShouldNotChangeBalance()
        {
            // Arrange
            double beginningBalance = 100.00;
            double creditAmount = 0.00;
            BankAccount account = new BankAccount("Mr. John Doe", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            Assert.AreEqual(beginningBalance, account.Balance, "Balance should remain the same when credit amount is zero.");
        }
    }
}