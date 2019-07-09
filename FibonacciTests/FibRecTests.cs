using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fibonacci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci.Tests
{
    [TestClass()]
    public class FibRecTests
    {
        [TestMethod()]
        public void ComputeFibonacciTest()
        {
            FibIt it = new FibIt();
            Assert.AreEqual(it.ComputeFibonacci(6), 8);
            FibRec rec = new FibRec();
            Assert.AreEqual(rec.ComputeFibonacci(6), 8);
        }
    }
}