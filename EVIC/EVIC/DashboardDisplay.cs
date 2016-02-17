using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVIC
{
    public class DashboardDisplay
    {
        private Dictionary<int, int> subMenuMem = new Dictionary<int, int>() { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 } };
        private int menuMem = 0; // 0 = System Status, 1 = Warning Messages, 2 = Personal Settings, 3 = Temperature Info, 4 = Trip Info

        public Controller Controller { get; set; }
        public int MenuMem { get { return menuMem; } }
        public Dictionary<int, int> SubMenuMem { get { return subMenuMem; } }

        // Format and display output for the console.
        public void DisplayUnits(int value, string unit)
        {
            Console.WriteLine("[{0} {1}]", value.ToString(), unit);
        }

        // Interpret input from keyboard into format that is no hardware dependant.
        private int GetAction()
        {
            ConsoleKeyInfo input = Console.ReadKey();
            switch(input.Key)
            {
                case ConsoleKey.UpArrow:
                    return 0;
                case ConsoleKey.RightArrow:
                    return 1;
                case ConsoleKey.DownArrow:
                    return 2;
                case ConsoleKey.LeftArrow:
                    return 3;
                case ConsoleKey.Spacebar:
                    return 4;
                case ConsoleKey.Enter:
                    return 5;
                case ConsoleKey.Escape:
                    return 6;
                default:
                    return -1;
            }
        }

        // Navigate the dashboard menu
        private bool NavMenu(int direction)
        {
            switch (direction)
            {
                case 0: // Sub-menu scroll up
                    switch (menuMem)
                    {
                        case 0:
                        case 3:
                        case 4:
                            subMenuMem[menuMem] = (subMenuMem[menuMem] - 1) % 2;
                            break;
                        case 1:
                            subMenuMem[1] = (subMenuMem[1] - 1) % 3;
                            break;
                        default:
                            return false;
                    }
                    break;
                case 1: // Main menu scroll right
                    menuMem = (menuMem + 1) % 5;
                    break;
                case 2: // Sub-menu scroll down
                    switch (menuMem)
                    {
                        case 0:
                        case 3:
                        case 4:
                            subMenuMem[menuMem] = (subMenuMem[menuMem] + 1) % 2;
                            break;
                        case 1:
                            subMenuMem[1] = (subMenuMem[1] + 1) % 3;
                            break;
                        default:
                            return false;
                    }
                    break;
                case 3: // Main Menu scroll left
                    menuMem = (menuMem - 1) % 5;
                    break;
                default:
                    return false;
            }
            return true;
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
