using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVIC
{
    public class DashboardDisplay
    {
        private Controller controllerInfo = new Controller();

        // Read Info
        //
        // Interact with the user to display the information for the program
        public void ReadInfo()
        {
            Console.WriteLine("Started dashboard display successfully!");
            SystemStatusMap();
            return;
        }

        // System Status Map
        //
        // Display and handle the system status options
        public void SystemStatusMap()
        {
            // Display the data for the options to output to the user
            List<string> categoryNames = new List<string>()
            {
                "Trip Info",
                "System Info",
                "Warning Messages",
                "Quit Display"
            };
            List<string> arrowDirs = new List<string>()
            {
                "left",
                "up&down",
                "right",
                "escape"
            };
            SetDisplayOptions(categoryNames, arrowDirs);

            // Interpret the user's choice
            ConsoleKey input = Console.ReadKey().Key;
            if (ConsoleKey.LeftArrow == input)
            {
                Console.WriteLine("Left");
                TripInfoMap();
            }
            else if ((ConsoleKey.UpArrow == input) || ((ConsoleKey.DownArrow == input)))
            {
                //Console.WriteLine("Up or Down");
                //NextOilChangeMap();
            }
            else if (ConsoleKey.RightArrow == input)
            {
                //Console.WriteLine("Right");
                WarningMessagesMap();
            } 
            else
            {
                Console.WriteLine("Error: Invalid option");
            }
            Console.ReadKey();
        }

        // Set and Display Options
        //
        // Set and display the user's options for how to proceed
        public void SetDisplayOptions(List<string> categories, List<string> dirs)
        {
            // Get the data for the options to output to the user
            List<List<string>> optionArgs = controllerInfo.DisplayOption(categories, dirs);
            int numOptions = optionArgs.Count;
            int numLines = optionArgs[0].Count;

            // Output the options to the user
            for (int i = 0; i < numLines; i++)
            {
                for (int j = 0; j < numOptions; j++)
                {
                    Console.Write(optionArgs[j][i]);
                }
                Console.WriteLine("");
            }
        }

        // Warning Messages Map
        //
        // Display and handle the warning messages options
        public void WarningMessagesMap()
        {
            // Display the data for the options to output to the user
            List<string> categoryNames = new List<string>()
            {
                "System Status",
                "Warning Messages",
                "Personal Settings"
            };
            List<string> arrowDirs = new List<string>()
            {
                "left",
                "up&down",
                "right"
            };
            SetDisplayOptions(categoryNames, arrowDirs);

            // Interpret the user's choice
            ConsoleKey input = Console.ReadKey().Key;
            if (ConsoleKey.LeftArrow == input)
            {
                SystemStatusMap();
            }
            else if (ConsoleKey.UpArrow == input)
            {
                WarningMessagesMap();
            }
            else if (ConsoleKey.RightArrow == input)
            {
                PersonalSettingsMap();
            }
            else
            {
                Console.WriteLine("Error: Invalid option");
            }
        }

        // Personal Settings Map
        //
        // Display and handle the personal settings options
        public void PersonalSettingsMap()
        {
            // Display the data for the options to output to the user
            List<string> categoryNames = new List<string>()
            {
                "Units",
                "Temp Info",
                "Toggle Units",
                "System Status"
            };
            List<string> arrowDirs = new List<string>()
            {
                "up",
                "right",
                "space",
                "escape"
            };
            SetDisplayOptions(categoryNames, arrowDirs);

            // Interpret the user's choice
            ConsoleKey input = Console.ReadKey().Key;
            if (ConsoleKey.UpArrow == input)
            {
                PersonalSettingsMap();
            }
            else if (ConsoleKey.RightArrow == input)
            {
                TemperatureDisplayMap();
            }
            else if (ConsoleKey.Spacebar == input)
            {
                controllerInfo.ToggleMetricUnits();
            }
            else
            {
                Console.WriteLine("Error: Invalid option");
            }
        }

        // Temperature Display Map
        //
        // Display and handle the temperature display options
        public void TemperatureDisplayMap()
        {
            // Display the data for the options to output to the user
            List<string> categoryNames = new List<string>()
            {
                "Personal Settings",
                "Toggle Temp Info",
                "Trip Info",
                "System Status"
            };
            List<string> arrowDirs = new List<string>()
            {
                "left",
                "up&down",
                "right",
                "escape"
            };
            SetDisplayOptions(categoryNames, arrowDirs);

            // Interpret the user's choice
            ConsoleKey input = Console.ReadKey().Key;
            if (ConsoleKey.LeftArrow == input)
            {
                PersonalSettingsMap();
            }
            else if ((ConsoleKey.UpArrow == input) || ((ConsoleKey.DownArrow == input)))
            {
                controllerInfo.ToggleMetricUnits();
                TemperatureDisplayMap();
            }
            else if (ConsoleKey.RightArrow == input)
            {
                TripInfoMap();
            }
            else if (ConsoleKey.Escape == input)
            {
                SystemStatusMap();
            }
            else
            {
                Console.WriteLine("Error: Invalid option");
            }
        }

        // Trip Info Map
        //
        // Display and handle the trip information options
        public void TripInfoMap()
        {
            // Display the data for the options to output to the user
            List<string> categoryNames = new List<string>()
            {
                "Temp Info",
                "Toggle Trip Info",
                "System Status",
                "Reset Trip Info"
            };
            List<string> arrowDirs = new List<string>()
            {
                "left",
                "up&down",
                "right",
                "space"
            };
            SetDisplayOptions(categoryNames, arrowDirs);

            // Interpret the user's choice
            ConsoleKey input = Console.ReadKey().Key;
            if (ConsoleKey.LeftArrow == input)
            {
                TemperatureDisplayMap();
            }
            else if ((ConsoleKey.UpArrow == input) || ((ConsoleKey.DownArrow == input)))
            {
                TripInfoMap();
            }
            else if (ConsoleKey.RightArrow == input)
            {
                SystemStatusMap();
            }
            else if (ConsoleKey.Spacebar == input)
            {
                controllerInfo.ResetCurrentTripDist();
                TripInfoMap();
            }
            else
            {
                Console.WriteLine("Error: Invalid option");
            }
        }

        //// Next Oil Change Map
        ////
        //// Display and handle the mills till the next oil change options
        //public void NextOilChangeMap()
        //{
        //    throw new System.NotImplementedException();
        //}

        //// Unit Toggle
        ////
        //// Toggle the units from US to metric or vice versa
        //public bool UnitToggle()
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
        //public bool TemperatureSourceToggle()
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
