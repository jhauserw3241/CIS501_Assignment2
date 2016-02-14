using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using EVIC.DashboardDisplay;

namespace EVIC
{
    class Program
    {
        public DashboardDisplay DashboardDisplay
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }


        public Simulator Simulator
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        static void Main()
        {
            // Offer the user option
            Console.WriteLine("Which program would you like to use?(1 or 2)");
            Console.WriteLine("1.) Dashboard Display");
            Console.WriteLine("2.) Simulator");

            // Interpret the user's choice
            if (Console.Read() == 1)
            {
                DashboardDisplay.ReadInfo();
            }
            else if (Console.Read() == 2)
            {
                Simulator.ModifyInfo();
            }
            else
            {
                Console.Write("Invalid option");
                Console.ReadKey();
            }
        }
    }
}
