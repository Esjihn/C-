using System;
using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BLTests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void CalculatePercentOfGoalStepsTestValid()
        {
            //-- Arrange (Setup Data and instances needed to perform the test)
            var customer = new Customer();
            string goalSteps = "5000";
            string actualSteps = "2000";
            decimal expected = 40M;

            //-- Act (Method under test)
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //-- Assert (Assertion of test)
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePercentOfGoalStepsTestValidAndSame()
        {
            //-- Arrange (Setup Data and instances needed to perform the test)
            var customer = new Customer();
            string goalSteps = "5000";
            string actualSteps = "5000";
            decimal expected = 100M;

            //-- Act (Method under test)
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //-- Assert (Assertion of test)
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePercentOfGoalStepsTestValidActualIsZero()
        {
            //-- Arrange (Setup Data and instances needed to perform the test)
            var customer = new Customer();
            string goalSteps = "5000";
            string actualSteps = "0";
            decimal expected = 0M;

            //-- Act (Method under test)
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //-- Assert (Assertion of test)
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculatePercentOfStepsTestGoalIsNull()
        {
            //-- Arrange (Setup Data and instances needed to perform the test)
            var customer = new Customer();
            string goalSteps = "null";
            string actualSteps = "2000";

            //-- Act (Method under test)
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //-- Assert (Assertion of test)
            // expected exception automatically asserts
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculatePercentOfStepsTestGoalMustBeNumeric()
        {
            //-- Arrange (Setup Data and instances needed to perform the test)
            var customer = new Customer();
            string goalSteps = "null";
            string actualSteps = "2000";

            //-- Act (Method under test)
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //-- Assert (Assertion of test)
            // expected exception automatically asserts
        }
    }
}

       
