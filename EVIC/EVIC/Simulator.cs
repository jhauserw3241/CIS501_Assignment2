using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVIC
{
    public class Simulator
    {
        private int menuMem = 0; // 0 = Main Menu, 1 = System Status, 2 = Warning Messages, 3 = Temperature
        private Controller controllerInfo;
        
        public int MenuMem { get { return menuMem; } }

        // Constructor
        // 
        // Pass in an instance of a shared controller.
        public Simulator(Controller cont)
        {
            controllerInfo = cont;
        }

        // Display Main Menu
        // 
        // Displays the choices for the main menu of the simulator.
        private void DisplayMainMenu()
        {
            Console.WriteLine("╔═══╤══════════════════╗");
            Console.WriteLine("║ 1 │ System Status    ║");
            Console.WriteLine("╟───┼──────────────────╢");
            Console.WriteLine("║ 2 │ Warning Messages ║");
            Console.WriteLine("╟───┼──────────────────╢");
            Console.WriteLine("║ 3 │ Temperature      ║");
            Console.WriteLine("╟───┼──────────────────╢");
            Console.WriteLine("║Esc│ Leave Simulator  ║");
            Console.WriteLine("╚═══╧══════════════════╝");
        }

        // Display System Modifier
        // 
        // Display the message indicating how the user can modify the System Status from the simulator.
        private void DisplaySystemMod()
        {
            Console.WriteLine("Press [Enter] to increment the distance one unit in the displayed format (Esc to leave).");
        }

        // Display Warning Menu
        // 
        // Displays the choices for the warning toggle menu of the simulator.
        private void DisplayWarningMenu()
        {
            Console.WriteLine("╔═══╤══════════════════╗");
            Console.WriteLine("║ A │ Door ajar        ║");
            Console.WriteLine("╟───┼──────────────────╢");
            Console.WriteLine("║ B │ Check Engine     ║");
            Console.WriteLine("╟───┼──────────────────╢");
            Console.WriteLine("║ C │ Change Oil       ║");
            Console.WriteLine("╟───┼──────────────────╢");
            Console.WriteLine("║Esc│ Return to Menu   ║");
            Console.WriteLine("╚═══╧══════════════════╝");
        }

        // Display Temperature Menu
        // 
        // Displays the choices for altering the temperature display fromt eh simulator.
        private void DisplayTempMenu()
        {
            Console.WriteLine("╔═══╤═════════════════════╗");
            Console.WriteLine("║ A │ Outside Temperature ║");
            Console.WriteLine("╟───┼─────────────────────╢");
            Console.WriteLine("║ B │ Inside Temperature  ║");
            Console.WriteLine("╟───┼─────────────────────╢");
            Console.WriteLine("║Esc│ Return to Menu      ║");
            Console.WriteLine("╚═══╧═════════════════════╝");
        }

        // Get Action
        // 
        // Translates keyboard input into a standard numerical value recognized throughout this class.
        private int GetAction()
        {
            ConsoleKeyInfo input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    return 0;
                case ConsoleKey.D2:
                    return 1;
                case ConsoleKey.D3:
                    return 2;
                case ConsoleKey.A:
                    return 3;
                case ConsoleKey.B:
                    return 4;
                case ConsoleKey.C:
                    return 5;
                case ConsoleKey.Spacebar:
                    return 6;
                case ConsoleKey.Enter:
                    return 7;
                case ConsoleKey.Escape:
                    return 8;
                default:
                    return -1;
            }
        }

        // Get Temperature
        // 
        // Prompts the user for a new temperature value, returns the original value if an incorrect value is entered.
        private double GetTemp(string location)
        {
            double rtrn;
            Console.Write("Please enter a Fahrenheit value for the {0} temperature: ", location);
            if (Double.TryParse(Console.ReadLine(), out rtrn))
            {
                return rtrn;
            }
            else return 0.00;
        }

        // Main
        //
        // Interact with the user to modify the information for the program
        public void ModifyInfo()
        {
            bool cont;
            int action;

            do
            {
                cont = true;
                Console.Clear();
                Console.WriteLine(controllerInfo.GetCategoryValueString("System Status"));
                switch (menuMem)
                {
                    case 0:
                        DisplayMainMenu();
                        action = GetAction();
                        switch (action)
                        {
                            case 0:
                            case 1:
                            case 2:
                                menuMem = action + 1;
                                break;
                            case 8:
                                cont = false;
                                return;
                        }
                        break;
                    case 1:
                        DisplaySystemMod();
                        action = GetAction();
                        switch (action)
                        {
                            case 7:
                                controllerInfo.IncrementOdometerValue();
                                break;
                            case 8:
                                menuMem = 0;
                                break;
                        }
                        break;
                    case 2:
                        DisplayWarningMenu();
                        action = GetAction();
                        switch (action)
                        {
                            case 3:
                                controllerInfo.ToggleDoorAjar();
                                break;
                            case 4:
                                controllerInfo.ToggleCheckEngine();
                                break;
                            case 5:
                                controllerInfo.ToggleChangeOil();
                                break;
                            case 8:
                                menuMem = 0;
                                break;
                        }
                        break;
                    case 3:
                        DisplayTempMenu();
                        action = GetAction();
                        switch (action)
                        {
                            case 3:
                                controllerInfo.SetOutsideTemperature(GetTemp("outside"));
                                break;
                            case 4:
                                controllerInfo.SetInsideTemperature(GetTemp("inside"));
                                break;
                            case 8:
                                menuMem = 0;
                                break;
                        }
                        break;
                }
            } while (cont);
        } // end ModifyInfo
    }
}
