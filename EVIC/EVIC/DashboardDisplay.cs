using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVIC
{
    public class DashboardDisplay
    {
        public Controller Controller
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        // Main
        //
        // Interact with the user to display the information for the program
        public static void ReadInfo()
        {
            Console.WriteLine("Started dashboard display successfully!");
            Console.ReadLine();
        }
    }
}
