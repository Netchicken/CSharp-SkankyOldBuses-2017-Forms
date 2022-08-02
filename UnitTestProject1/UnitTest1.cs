using System;
using System.ComponentModel;
using CSharp_SkankyOldBusses2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Form1 myForm1 = new Form1();


        [TestMethod]
        public void DiscountFormulaAt20Test()
        {
            Single Expected =  14.39f;
            var Actual = myForm1.DiscountFormula((Single)17.99, (Single).2);

            Assert.AreEqual(Expected, Actual);
        }
        [TestMethod]
        public void DiscountFormulaAt25Test()
        {
            Single Expected = 13.49f;
            var Actual = myForm1.DiscountFormula((Single)17.99, (Single).25);

            Assert.AreEqual(Expected, Actual);
        }

    }
}
