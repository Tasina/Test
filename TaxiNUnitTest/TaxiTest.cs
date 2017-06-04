using Ninject;
using NUnit.Framework;
using System;

namespace TaxiNUnitTest
{
    [TestFixture]
    public class TaxiTest
    {
        TaxiService service;

        [SetUp]
        public void SetUp()
        {
            IKernel kernel = new StandardKernel(new NinjectTaxiModule());
            ITaxi cab = kernel.Get<TaxiCab>();
            ITaxi bus = kernel.Get<TaxiBus>();
            service = new TaxiService(cab, bus);
        }

        [Test]
        public void Fail_If_No_Persons() // Edge
        {
            Assert.Catch<Exception>(() => service.CalculateTotalPrice(100, 0));
        }

        // One cab
        [TestCase(10, 1, Result = 200)] // Edge
        [TestCase(10, 4, Result = 200)] // Edge
        // One bus
        [TestCase(10, 5, Result = 300)] // Edge
        [TestCase(10, 8, Result = 300)] // Edge
        // One cab and one bus
        [TestCase(10, 9, Result = 500)] // Loop
        // Two busses
        [TestCase(10, 15, Result = 600)] // Loop
        public float Loop_Can_Allocate_Persons(float km, int persons)
        {
            return service.CalculateTotalPrice(km, persons);
        }

        // Results in discount
        [TestCase(50, 9, Result = 1170)] // true true
        // Does not result in discount
        [TestCase(10, 1, Result = 200)] // false false - Short circuit
        [TestCase(50, 1, Result = 600)] // true false
        [TestCase(10, 9, Result = 500)] // false true - Short circuit
        public float Multiple_Condition_Discount(float km, int persons)
        {
            return service.CalculateTotalPrice(km, persons);
        }
    }
}
