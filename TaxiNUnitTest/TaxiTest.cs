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
        public void Fail_If_No_Persons()
        {
            Assert.Catch<Exception>(() => service.CalculateTotalPrice(100, 0));
        }
    }
}
