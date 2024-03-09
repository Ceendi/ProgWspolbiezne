using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using ProgWspolbiezne.ViewModel;

namespace ProgWspolbiezneTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(Testowy.Dodawanie(5, 6), 11);
        }
    }
}