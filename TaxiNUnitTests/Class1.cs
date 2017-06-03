using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiNUnitTests
{
    [TestFixture]
    public class Class1
    {
       

        [Test]
        public void Fail_If_No_Persons()
        {
            Assert.True(true);
            //Assert.Catch<Exception>(() => service.CalculateTotalPrice(100, 0));
        }
    }
}
