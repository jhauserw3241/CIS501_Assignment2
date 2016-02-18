using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EVIC;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;

namespace EVICTests
{
    [TestClass]
    public class ControllerTests
    {
        // Create an instance of the controller class to test
        public Controller cont = new Controller();

        // Different Size Lists Display Option
        //
        // Test DisplayOption() with the two list arguments being different sizes
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Parameter lists not same size")]
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
    }
}
