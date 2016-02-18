using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EVIC;

namespace EVICTests
{
    [TestClass]
    class ProgramTests
    {
        // Left Arrow Test
        //
        // Verify that the left arrow works
        [TestMethod]
        public void LeftArrowTest()
        {
            Console.WriteLine("Push the left arrow key");
            Assert.AreEqual(Console.ReadKey(), ConsoleKey.LeftArrow);
        }
    }
}
