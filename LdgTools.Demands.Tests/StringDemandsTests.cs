using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LdgTools.Demands.Tests
{
    [TestClass]
    public class StringDemandsTests
    {
        //With ExceptionDemander
        [DataTestMethod]
        [DataRow("", true)]
        [DataRow(" ", true)]
        [DataRow("test", false)]
        public void Test_IsNotNullOrWhitespace(string tVal, bool throws)
        {
            Type dType = typeof(ExceptionDemander<>);
            Demand.InitializeDemand(dType.FullName);

            if (throws)
            {
                Assert.ThrowsException<ValidationException>(()=>Demand.That(tVal).IsNotNullOrWhitespace());
            }
            else
            {
                Assert.AreEqual(0, Demand.That(tVal).IsNotNullOrWhitespace().GetErrors().Count);
            }
        }

    }
}
