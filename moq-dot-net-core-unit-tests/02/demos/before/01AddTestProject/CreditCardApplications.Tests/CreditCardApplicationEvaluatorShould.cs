using System;
using Xunit;
using Moq;

namespace CreditCardApplications.Tests
{
    public class CreditCardApplicationEvaluatorShould
    {
        [Fact]
        public void AcceptHighIncomeApplications()
        {
            Mock<IFrequentFlyerNumberValidator> mockValidator = 
                new Mock<IFrequentFlyerNumberValidator>();

            // acronym for system under test
            //-- Arrange
            var sut = new CreditCardApplicationEvaluator(mockValidator.Object);
            var application = new CreditCardApplication() {GrossAnnualIncome = 100_000};
            
            //-- Act
            CreditCardApplicationDecision decision = sut.Evaluate(application);

            //-- Assert
            Assert.Equal(CreditCardApplicationDecision.AutoAccepted, decision);
        }

        [Fact]
        public void ReferYoungApplications()
        {
            Mock<IFrequentFlyerNumberValidator> mockValidator =
                new Mock<IFrequentFlyerNumberValidator>();

            mockValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);
            // acronym for system under test
            //-- Arrange
            var sut = new CreditCardApplicationEvaluator(mockValidator.Object);
            var application = new CreditCardApplication() {Age = 19};

            //-- Act
            CreditCardApplicationDecision decision = sut.Evaluate(application);

            //-- Assert
            Assert.Equal(CreditCardApplicationDecision.ReferredToHuman, decision);
        }

        [Fact]
        public void DeclineLowIncomeApplications()
        {
            //-- Arrange
            Mock<IFrequentFlyerNumberValidator> mockValidator =
                new Mock<IFrequentFlyerNumberValidator>();

            //mockValidator.Setup(x => x.IsValid("x")).Returns(true);
            // Equivalent as above
            //mockValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);

            //Equivalent as above
            //mockValidator.Setup(x => x.IsValid(It.Is<string>(number => number.StartsWith('x'))))
            //.Returns(true);

            // (It.IsIn example)
            //mockValidator.Setup(x => x.IsValid(It.IsIn("x","y","z"))).Returns(true);

            // (It.IsInRange example)
            //mockValidator.Setup(x => x.IsValid(It.IsInRange("b","z", Range.Inclusive)))
                //.Returns(true);

            // (It.IsRegex example)
            mockValidator.Setup(x => x.IsValid(It.IsRegex("[a-z]",
                                System.Text.RegularExpressions.RegexOptions.None)))
                         .Returns(true);

            var sut = new CreditCardApplicationEvaluator(mockValidator.Object);
            var application = new CreditCardApplication
            {
                GrossAnnualIncome = 19_999,
                FrequentFlyerNumber = "a",
                Age = 42
            };

            //-- Act
            CreditCardApplicationDecision decision = sut.Evaluate(application);

            //-- Assert
            Assert.Equal(CreditCardApplicationDecision.AutoDeclined, decision);
        }

        [Fact]
        public void ReferInvalidFrequentFlyerApplications()
        {
            //-- Arrange (Mock Strict example)
            Mock<IFrequentFlyerNumberValidator> mockValidator =
                new Mock<IFrequentFlyerNumberValidator>(MockBehavior.Strict);

            mockValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);
            
            var sut = new CreditCardApplicationEvaluator(mockValidator.Object);
            var application = new CreditCardApplication();

            //-- Act
            CreditCardApplicationDecision decision = sut.Evaluate(application);

            //-- Assert
            Assert.Equal(CreditCardApplicationDecision.ReferredToHuman, decision);

        }

        [Fact]
        public void DeclineLowIncomeApplicationsOutDemo()
        {
            //-- Arrange
            Mock<IFrequentFlyerNumberValidator> mockValidator =
                new Mock<IFrequentFlyerNumberValidator>();

            bool isValid = true;
            mockValidator.Setup(x => x.IsValid(It.IsAny<string>(), out isValid));

            var sut = new CreditCardApplicationEvaluator(mockValidator.Object);
            var application = new CreditCardApplication
            {
                GrossAnnualIncome = 19_999,
                Age = 42,
                FrequentFlyerNumber = "a"
            };

            //-- Act
            CreditCardApplicationDecision decision = sut.EvaluateUsingOut(application);

            //-- Assert
            Assert.Equal(CreditCardApplicationDecision.AutoDeclined, decision);
        }
        // other evaluator test conditions

    }
}
