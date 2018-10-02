using System;
using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTests
{
    // TestClass attribute is required in the Microsoft unit testing 
    // framework for managed code for any class that contains unit test
    // methods that you want to run in Test Explorer
    [TestClass]
    public class UnitTest1
    {
        // and each test method that you want Test Explorer to run must have the 
        [TestMethod]
        public void TestMethod1()
        {
            
        }

        // Must meet the following requirements
        // It's decorated with the [TestMethod] attribute.
        // It returns void.
        // It cannot have parameters.
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        
    }
}
