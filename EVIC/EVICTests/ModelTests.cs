using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EVIC;

namespace EVICTests
{
    [TestClass]
    class ModelTests
    {
        private Model data = new Model();

        // Valid Check Engine Test
        //
        // Verify that the check engine value getter returns
        // what the value is set to
        [TestMethod]
        public void ValidCheckEngineTest()
        {
            data.SetCheckEngine(false);
            Assert.IsFalse(data.IsCheckEngine());
        }

        // Valid Check Oil Test
        //
        // Verify that the check oil value getter returns what
        // the value is set to
        [TestMethod]
        public void ValidCheckOilTest()
        {
            data.SetChangeOil(true);
            Assert.IsTrue(data.IsChangeOil());
        }

        // Valid Door Ajar Test
        //
        // Verify that the door ajar value getter returns what
        // the value is set to
        [TestMethod]
        public void ValidDoorAjarTest()
        {
            data.SetDoorAjar(true);
            Assert.IsTrue(data.IsDoorAjar());
        }
    }
}
