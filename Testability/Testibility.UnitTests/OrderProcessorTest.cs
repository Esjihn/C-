using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testibility.UnitTests
{
    [TestClass]
    public class OrderProcessorTest
    {
        // METHODNAME_CONDITION_EXPECTATION
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Process_OrderIsAlreadyShipped_ThrowsAnException()
        {
            var orderProcessor = new OrderProcessorTest();
            var order = new OrderProcessorTest
            {
                Shipment = new Shipment()
            };

            orderProcessor.Process(order)
        }
    }

    public class FakeShippingCalculator : IShippingCalculator
    {
        public float CalculateShipping(OrderProcessorTest order)
        {
            return 1;
        }
    }
}
