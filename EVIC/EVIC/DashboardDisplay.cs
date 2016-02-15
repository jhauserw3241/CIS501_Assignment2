using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVIC
{
    public class DashboardDisplay
    {
        private Controller controllerInfo = new Controller();

        // Main
        //
        // Interact with the user to display the information for the program
        public void ReadInfo()
        {
            Console.WriteLine("Started dashboard display successfully!");
            SystemStatusMap();
        }

        // System Status Map
        //
        // Display and handle the system status options
        public void SystemStatusMap()
        {
            Console.WriteLine("started system status map");
            // Output options
            List<string> categoryNames = new List<string>()
            {
                "Trip Info",
                "Oil Change",
                "Warning Messages"
            };
            List<string> arrowDirs = new List<string>()
            {
                "left",
                "up&down",
                "right"
            };
            List<List<string>> optionArgs = controllerInfo.DisplayOption(categoryNames, arrowDirs);
            Console.WriteLine("Number of options: " + optionArgs.Count);
            for (int i = 0; i < optionArgs.Count; i++)
            {
                Console.WriteLine("Option: " + i.ToString());
                int numArgs = optionArgs[i].Count;
                Console.WriteLine("number of lines in current option: " + optionArgs[i]);
                for (int j = 0; j < optionArgs[i].Count; j++)
                {
                    Console.Write("Option: " + i.ToString() + " Row: " + j.ToString());
                    Console.Write(optionArgs[i][j].ToString());
                }
                Console.WriteLine();
            }

            // Interpret the user's choice
            ConsoleKey input = Console.ReadKey().Key;
            if (ConsoleKey.LeftArrow == input)
            {
                Console.WriteLine("Left");
                //WarningMessagesMap();
            }
            else if ((ConsoleKey.UpArrow == input) || ((ConsoleKey.DownArrow == input)))
            {
                Console.WriteLine("Up or Down");
                //NextOilChangeMap();
            }
            else if (ConsoleKey.RightArrow == input)
            {
                Console.WriteLine("Right");
                //TripInfoMap();
            }
            else
            {
                Console.WriteLine("Invalid option");
            }
        }

        //// Warning Messages Map
        ////
        //// Display and handle the warning messages options
        //public static void WarningMessagesMap()
        //{
        //    // Output options
        //    Console.WriteLine("      Warning Messages");
        //    Console.WriteLine("Hardware Warning Messages");
        //    Console.WriteLine("           ^");
        //    Console.WriteLine("           |  -> Personal Settings");

        //    // Interpret the user's choice
        //    ConsoleKey input = Console.ReadKey().Key;
        //    if (ConsoleKey.UpArrow == input)
        //    {
        //        // Display whether or not the door is ajar

        //        // Display whether or not the engine should be checked

        //        // Display the number of miles till the next oil change needs to be made
        //        NextOilChangeMap();
        //    }
        //    else if (ConsoleKey.RightArrow == input)
        //    {
        //        TripInfoMap();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid option");
        //    }
        //}

        //// Personal Settings Map
        ////
        //// Display and handle the personal settings options
        //public static void PersonalSettingsMap()
        //{
        //    // Output options
        //    Console.WriteLine("    Personal Settings");
        //    Console.WriteLine("Change Units");
        //    Console.WriteLine("     ^");
        //    Console.WriteLine("     |  -> Temperature Display");

        //    // Interpret the user's choice
        //    ConsoleKey input = Console.ReadKey().Key;
        //    if (ConsoleKey.UpArrow == input)
        //    {
        //        // Toggle the units
        //        while (true == UnitToggle())
        //        {
        //            Console.Write("The units have successfully been toggled to ");
        //            if (!Model.isMetricUnits)
        //            {
        //                Console.WriteLine("US units.");
        //            }
        //            else
        //            {
        //                Console.WriteLine("metric units.");
        //            }
        //        }

        //        // Go back to the system status map
        //        SystemStatusMap();
        //    }
        //    else if (ConsoleKey.RightArrow == input)
        //    {
        //        TemperatureDisplayMap();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid option");
        //    }
        //}

        //// Temperature Display Map
        ////
        //// Display and handle the temperature display options
        //public static void TemperatureDisplayMap()
        //{
        //    // Output options
        //    Console.WriteLine("            Temperature Information");
        //    Console.WriteLine("           Toggle Temperature Source");
        //    Console.WriteLine("                      ^ |");
        //    Console.WriteLine("Personal Settings <-  | v  -> Trip Info");

        //    // Interpret the user's choice
        //    ConsoleKey input = Console.ReadKey().Key;
        //    if (ConsoleKey.LeftArrow == input)
        //    {
        //        PersonalSettingsMap();
        //    }
        //    else if ((ConsoleKey.UpArrow == input) || ((ConsoleKey.DownArrow == input)))
        //    {
        //        // Toggle the temperature source
        //        while (TemperatureSourceToggle())
        //        {
        //            Console.Write("The units have successfully been toggled to ");
        //            if (!Model.isMetricUnits)
        //            {
        //                Console.WriteLine("US units.");
        //            }
        //            else
        //            {
        //                Console.WriteLine("metric units.");
        //            }
        //        }
        //    }
        //    else if (ConsoleKey.RightArrow == input)
        //    {
        //        TripInfoMap();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid option");
        //    }
        //}

        //// Trip Info Map
        ////
        //// Display and handle the trip information options
        //public static void TripInfoMap()
        //{
        //    // Output options
        //    Console.WriteLine("                  Trip Info");
        //    Console.WriteLine("           Toggle Trip Information");
        //    Console.WriteLine("                     ^ |");
        //    Console.WriteLine("Temperature Info <-  | v  -> System Status");
        //    Console.WriteLine("       <space-bar> Reset Trip Distance");

        //    // Interpret the user's choice
        //    ConsoleKey input = Console.ReadKey().Key;
        //    if (ConsoleKey.LeftArrow == input)
        //    {
        //        TemperatureDisplayMap();
        //    }
        //    else if ((ConsoleKey.UpArrow == input) || ((ConsoleKey.DownArrow == input)))
        //    {
        //        // Print out the results for the current trip
        //        if (Model.isTripA)
        //        {
        //            Console.WriteLine("[Trip-A: " + Model.tripADist.ToString() + " mi]");
        //        }
        //        else
        //        {
        //            Console.WriteLine("[Trip-B: " + Model.tripBDist.ToString() + " mi]");
        //        }
        //        Model.isTripA = !Model.isTripA;
        //    }
        //    else if (ConsoleKey.RightArrow == input)
        //    {
        //        SystemStatusMap();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid option");
        //    }
        //}

        //// Next Oil Change Map
        ////
        //// Display and handle the mills till the next oil change options
        //public static void NextOilChangeMap()
        //{
        //    throw new System.NotImplementedException();
        //}

        //// Unit Toggle
        ////
        //// Toggle the units from US to metric or vice versa
        //public static bool UnitToggle()
        //{
        //    // Toggle the units from US to metric units
        //    Console.WriteLine("Toggle units: (US/Metric)");

        //    if (" " == Console.ReadLine())
        //    {
        //        Model.isMetricUnits = !Model.isMetricUnits;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //// Temperature Source Toggle
        ////
        //// Toggle between outside and inside temperature information
        //public static bool TemperatureSourceToggle()
        //{
        //    // Output options
        //    Console.WriteLine(" Temperature Information");
        //    Console.WriteLine("Toggle Temperature Source");
        //    Console.WriteLine("          ^ |");
        //    Console.WriteLine("          | v");

        //    // Interpret user input
        //    ConsoleKey input = Console.ReadKey().Key;
        //    if ((ConsoleKey.UpArrow == input) || ((ConsoleKey.DownArrow == input)))
        //    {
        //        // Output the output source
        //        if (Model.isOutTemp)
        //        {
        //            Console.WriteLine(Model.outTemp.ToString() + " F Outside");
        //        }
        //        else
        //        {
        //            Console.WriteLine(Model.inTemp.ToString() + " F Inside");
        //        }

        //        // Convert to the opposite of the current temperature source
        //        Model.isOutTemp = !Model.isOutTemp;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
