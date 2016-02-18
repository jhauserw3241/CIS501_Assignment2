using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EVIC;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;

namespace EVICTests
{
    [TestClass]
    public class UnitTests
    {
        #region ControllerTests

        // Create an instance of the controller class to test
        private Controller cont = new Controller();

        // Different Size Lists Display Option
        //
        // Test DisplayOption() with the two list arguments being different sizes
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "The number of items in the two parameter lists don't match")]
        public void DifferentSizeListsDisplayOptionTest()
        {
            // Arguments
            List<string> catNames = new List<string>()
            {
                "cat1"
            };
            List<string> arrowDirs = new List<string>()
            {
                "a1",
                "a2"
            };

            cont.DisplayOption(catNames, arrowDirs);
        }

        // Valid Display Option
        //
        // Test DisplayOption() with valid arguments
        [TestMethod]
        public void ValidDisplayOptionTest()
        {
            // Arguments
            List<string> catNames = new List<string>()
            {
                "cat1",
                "cat 2"
            };
            List<string> arrowDirs = new List<string>()
            {
                "a1",
                "a2"
            };

            cont.DisplayOption(catNames, arrowDirs);
        }
        #endregion

        #region ModelTests

        //Create an instance of the model classto test
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

        #endregion
    }
}
