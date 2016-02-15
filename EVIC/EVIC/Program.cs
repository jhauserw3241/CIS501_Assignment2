using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVIC
{
    class Program
    {
        private DashboardDisplay display = new DashboardDisplay();
        private Simulator sim = new Simulator();

        // Main
        //
        // Run this code when the program starts
        static void Main()
        {
            Program currentProgram = new Program();
            currentProgram.ProvideUserOptions();
        }

        // Provide User Options
        //
        // Provider the user the option of using the Dashboard
        // Display or the Simulator
        public void ProvideUserOptions()
        {
            // Offer the user option
            Console.WriteLine("Which program would you like to use?(1 or 2)");
            Console.WriteLine("1.) Dashboard Display");
            Console.WriteLine("2.) Simulator");

            // Interpret the user's choice
            string input = Console.ReadLine();
            if (input.Equals("1"))
            {
                display.ReadInfo();
            }
            else if (input.Equals("2"))
            {
                sim.ModifyInfo();
            }
            else
            {
                Console.Write("Invalid option");
                Console.ReadKey();
            }
        }
    }
}
