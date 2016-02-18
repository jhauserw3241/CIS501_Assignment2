using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVIC
{
    public class DashboardDisplay
    {
        private Controller controllerInfo;

        // Constructor
        //
        // Pass an instance of a shared controller.
        public DashboardDisplay(Controller cont)
        {
            controllerInfo = cont;
        }

        // Personal Settings Map
        //
        // Display and handle the personal settings options
        public void PersonalSettingsMap()
        {
            Console.Clear();
            // Display the data for the options to output to the user
            List<string> categoryNames = new List<string>()
            {
                "Warning Messages",
                "Units",
                "Temp Info",
                "Toggle Units",
                "System Status"
            };
            List<string> arrowDirs = new List<string>()
            {
                "left",
                "up",
                "right",
                "space",
                "escape"
            };
            SetDisplayOptions(categoryNames, arrowDirs);

            // Interpret the user's choice
            ConsoleKey input = Console.ReadKey().Key;
            if (ConsoleKey.LeftArrow == input)
            {
                WarningMessagesMap();
            }
            else if (ConsoleKey.UpArrow == input)
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
                PersonalSettingsMap();
            }
            else
            {
                Console.WriteLine("Error: Invalid option");
            }
        }

        // Read Info
        //
        // Interact with the user to display the information for the program
        public void ReadInfo()
        {
            Console.WriteLine("Started dashboard display successfully!");
            SystemStatusMap();
            return;
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
 
        // System Status Map
        //
        // Display and handle the system status options
        public void SystemStatusMap()
        {
            Console.Clear();
            // Display the data for the options to output to the user
            List<string> categoryNames = new List<string>()
            {
                "Trip Info",
                "System Info",
                "Warning Messages",
                "Reset Oil",
                "Quit Display"
            };
            List<string> arrowDirs = new List<string>()
            {
                "left",
                "up&down",
                "right",
                "space",
                "escape"
            };
            SetDisplayOptions(categoryNames, arrowDirs);

            // Interpret the user's choice
            ConsoleKey input = Console.ReadKey(true).Key;
            if (ConsoleKey.LeftArrow == input)
            {
                //Console.WriteLine("Left");
                TripInfoMap();
            }
            else if ((ConsoleKey.UpArrow == input) || ((ConsoleKey.DownArrow == input)))
            {
                controllerInfo.ToggleOdometerSys();
                SystemStatusMap();
            }
            else if (ConsoleKey.RightArrow == input)
            {
                //Console.WriteLine("Right");
                WarningMessagesMap();
            }
            else if (ConsoleKey.Spacebar == input)
            {
                controllerInfo.ResetOilChange();
                SystemStatusMap();
            }
            else if (ConsoleKey.Escape == input)
            {
                return;
            }
            else
            {
                Console.WriteLine("Error: Invalid option");
            }
            Console.ReadKey();
        }

        // Temperature Display Map
        //
        // Display and handle the temperature display options
        public void TemperatureDisplayMap()
        {
            Console.Clear();
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
                controllerInfo.ToggleDisplayTemp();
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
            Console.Clear();
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
                controllerInfo.ToggleTripDisp();
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

        // Warning Messages Map
        //
        // Display and handle the warning messages options
        public void WarningMessagesMap()
        {
            Console.Clear();
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
                "up",
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
                // Update the warning message state
                controllerInfo.UpdateWarningMessageState();
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
    }
}
