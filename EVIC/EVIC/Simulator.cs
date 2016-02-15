using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVIC
{
    public class Simulator
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
        // Interact with the user to modify the information for the program
        public void ModifyInfo()
        {
            Console.WriteLine("Started simulator successfully!");
            Console.ReadLine();
        }
    }
}
