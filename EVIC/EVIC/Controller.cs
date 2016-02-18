﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVIC
{
    public class Controller
    {
        private Model data = new Model();

        // Convert Units
        //
        // Convert the specified value to the specified unit type
        // @param value the specified value
        // @param into the unit type to convert the specified value to
        // @return the converted value
        private int CnvtUnits(int value, string into)
        {
            switch (into)
            {
                case "c":
                    return (int)Math.Round(((double)value - 32.0) / (9.0 / 5.0));
                case "f":
                    return (int)Math.Round((double)value * (9.0 / 5.0) + 32.0);
                case "km":
                    return (int)Math.Round((double)value / 0.62137);
                case "mi":
                    return (int)Math.Round((double)value * 0.62137);
                default:
                    return -1;
            }
        }

        // Display Option
        //
        // @param categoryName A list of names of the category options presented
        //      to the user
        // @param arrowDir A list of arrow directions for the various category options
        // @return the string array for the option information
        public List<List<string>> DisplayOption(List<string> categoryName, List<string> arrowDir)
        {
            List<List<string>> totalOutput = new List<List<string>>();
            List<string> output = new List<string>();
            int displayLength = 0;

            // Verify that the number of category names and arrow directions are the same
            if (categoryName.Count != arrowDir.Count)
            {
                return null;
            }

            // Add the information for all of the options
            for (int i = 0; i < categoryName.Count; i++)
            {
                output = new List<string>();
                // Get the value to be outputted
                string categoryValue = GetCategoryValueString(categoryName[i]);

                // Determine the length of the option display
                if (displayLength < categoryName[i].Length)
                {
                    displayLength = categoryName[i].Length;
                }
                if (displayLength < categoryValue.Length)
                {
                    displayLength = categoryValue.Length;
                }

                // Create boundary
                string topBottomBoundary = new String('-', (displayLength + 2));
                string intermediateLine = new String(' ', displayLength);
                string categoryNameBuffer = new String(' ', (displayLength - categoryName[i].Length));
                string categoryValueBuffer = new String(' ', (displayLength - categoryValue.Length));

                // Get the arrow lines
                List<string> arrowOutput = GetArrowDirectionStrings(arrowDir[i], displayLength);

                // Add the lines to the display array
                output.Add(topBottomBoundary);
                output.Add("|" + categoryNameBuffer + categoryName[i] + "|");
                output.Add("|" + categoryValueBuffer + categoryValue + "|");
                for (int j = 0; j < arrowOutput.Count; j++)
                {
                    output.Add(arrowOutput[j]);
                }
                output.Add(topBottomBoundary);
                output.Add(" " + intermediateLine + " ");
                totalOutput.Add(output);

                // Reset variables
                displayLength = 0;
            }

            return totalOutput;
        } // End DisplayOption()

        // Get Arrow Direction Strings
        //
        // Get the strings that will tell the user which key they need to press to
        // achieve the desired operation
        public List<string> GetArrowDirectionStrings(string arrowDir, int length)
        {
            // Define variables
            List<string> output = new List<string>();
            string intermediateLine = new String(' ', length);
            string sidewaysArrowIntermediate = new String(' ', (length - 2));
            string uprightArrowIntermediate = new String(' ', (length - 1));
            string upDownArrowIntermediate = new String(' ', (length - 2));
            string errorIntermediate = new String(' ', (length - 5));
            string escapeIntermediate = new String(' ', (length - 3));
            string spaceIntermediate = new String(' ', (length - 5));

            if (arrowDir == "left")
            {
                output.Add("|" + intermediateLine + "|");
                output.Add("|" + sidewaysArrowIntermediate + "<-|");
            }
            else if (arrowDir == "up")
            {
                output.Add("|" + uprightArrowIntermediate + "^|");
                output.Add("|" + uprightArrowIntermediate + "||");
            }
            else if (arrowDir == "right")
            {
                output.Add("|" + intermediateLine + "|");
                output.Add("|" + sidewaysArrowIntermediate + "->|");
            }
            else if (arrowDir == "down")
            {
                output.Add("|" + uprightArrowIntermediate + "||");
                output.Add("|" + uprightArrowIntermediate + "v|");
            }
            else if (arrowDir == "up&down")
            {
                output.Add("|" + upDownArrowIntermediate + "^||");
                output.Add("|" + upDownArrowIntermediate + "|v|");
            }
            else if (arrowDir == "escape")
            {
                output.Add("|" + intermediateLine + "|");
                output.Add("|" + escapeIntermediate + "Esc|");
            }
            else if (arrowDir == "space")
            {
                output.Add("|" + intermediateLine + "|");
                output.Add("|" + spaceIntermediate + "space|");
            }
            else
            {
                output.Add("|" + intermediateLine + "|");
                output.Add("|" + errorIntermediate + "error|");
            }

            return output;
        } // End GetArrowDirectionStrings()

        // Get Category Value String
        //
        // Get the category value string that correlates with the
        // category name
        public string GetCategoryValueString(string categoryName)
        {
            string categoryValue;

            if (categoryName == "System Status")
            {
                categoryValue = "[" + data.GetOdometerValue().ToString() + " mi]";
            }
            else if (categoryName == "Door Ajar")
            {
                categoryValue = "[" + data.IsDoorAjar().ToString() + "]";
            }
            else if (categoryName == "Check Engine")
            {
                categoryValue = "[" + data.IsCheckEngine().ToString() + "]";
            }
            else if (categoryName == "System Info")
            {
                // Determine whether or not to show the odometer value
                if (data.GetOdometerSys())
                {
                    categoryValue = "[" + data.GetOdometerValue().ToString() + " mi]";
                }
                else
                {
                    categoryValue = "[Oil change in " + data.GetMilesTillNextChange().ToString() + " mi]";
                }

                data.SetOdometerSys(!data.GetOdometerSys());
            }
            else if (categoryName == "Units")
            {
                // Determine whether the current units are US or metric
                if (!data.IsMetricUnits())
                {
                    categoryValue = "[US Units]";
                }
                else
                {
                    categoryValue = "[Metric Units]";
                }
            }
            else if ((categoryName == "Temp Info") || (categoryName == "Toggle Temp Info"))
            {
                // Determine whether the current temperature is the outside or inside temperature
                if (data.IsOutTemp())
                {
                    categoryValue = "[" + data.GetOutTemp().ToString() + " F Outside]";
                }
                else
                {
                    categoryValue = "[" + data.GetInTemp().ToString() + " F Inside]";
                }
            }
            else if ((categoryName == "Trip Info") || (categoryName == "Toggle Trip Info"))
            {
                // Determine whether the current trip is trip A or B
                if (data.IsTripA())
                {
                    categoryValue = "[Trip-A: " + data.GetTripADist().ToString() + " mi]";
                }
                else
                {
                    categoryValue = "[Trip-B: " + data.GetTripBDist().ToString() + " mi]";
                }
            }
            else if (categoryName == "Warning Messages")
            {
                // Determine which state the user is on currently
                if (data.GetWarningMessageState() == 0)
                {
                    categoryValue = "[Door Ajar:" + data.IsDoorAjar().ToString() + "]";
                }
                else if (data.GetWarningMessageState() == 1)
                {
                    categoryValue = "[Check Engine: " + data.IsCheckEngine().ToString() + "]";
                }
                else if (data.GetWarningMessageState() == 2)
                {
                    categoryValue = "[Oil change: " + data.IsChangeOil().ToString() + "]";
                }
                else
                {
                    categoryValue = "Error";
                }

                // Update the warning message state
                UpdateWarningMessageState();
            }
            else
            {
                // Create a string full of spaces as a place holder
                categoryValue = new String(' ', categoryName.Length);
            }

            return categoryValue;
        } // End GetCategoryValueString()

        // Increment Odometer Value
        //
        // Increment the odometer value, decrement the miles till the next oil change, and
        // decrement Trip-A or Trip-B (depending on if the value of Trip-A is zero)
        public void IncrementOdometerValue()
        {
            // Increment the odometer value
            data.SetOdometerValue(data.GetOdometerValue() + 1);

            // Decrement the miles till the next oil change
            data.SetOilChangeDist(data.GetMilesTillNextChange() - 1);

            // Check if the oil needs to be changed
            if (data.GetMilesTillNextChange() == 0)
            {
                data.SetChangeOil(true);
            }
            else
            {
                data.SetChangeOil(false);
            }

            // Determine if there is any more distance in the first trip
            if (data.GetTripADist() > 0)
            {
                // Decrement the distance for Trip A
                data.SetTripADist(data.GetTripADist() - 1);
            }
            else if(data.GetTripBDist() > 0)
            {
                // Decrement the distance for Trip B
                data.SetTripBDist(data.GetTripBDist() - 1);
            }
        }

        // Reset Current Trip Distance
        //
        // Reset the current trip distance value
        public void ResetCurrentTripDist()
        {
            if (data.IsTripA())
            {
                ResetTripADist();
            }
            else
            {
                ResetTripBDist();
            }
        }

        // Reset Oil Change
        //
        // Reset the oil change distance to the default value(3000 mi)
        public void ResetOilChange()
        {
            data.SetOilChangeDist(0);
        }

        // Reset Trip A Distance
        //
        // Reset the Trip A distance value
        public void ResetTripADist()
        {
            data.SetTripADist(0);
        }

        // Reset Trip B Distance
        //
        // Reset the Trip B distance value
        public void ResetTripBDist()
        {
            data.SetTripBDist(0);
        }

        // Switch Units
        //
        // Switcdh units from metric to US or vice versa for all important values
        public void SwitchUnits()
        {
            // Determine if the data is currently in metric units
            if (data.IsMetricUnits())
            {
                data.SetOdometerValue(CnvtUnits(data.GetOdometerValue(), "mi"));
                data.SetOilChangeDist(CnvtUnits(data.GetMilesTillNextChange(), "mi"));
                data.SetTripADist(CnvtUnits(data.GetTripADist(), "mi"));
                data.SetTripBDist(CnvtUnits(data.GetTripBDist(), "mi"));
                data.SetOutTemp(CnvtUnits(data.GetOutTemp(), "f"));
                data.SetInTemp(CnvtUnits(data.GetInTemp(), "f"));
            }
            else
            {
                data.SetOdometerValue(CnvtUnits(data.GetOdometerValue(), "km"));
                data.SetOilChangeDist(CnvtUnits(data.GetMilesTillNextChange(), "km"));
                data.SetTripADist(CnvtUnits(data.GetTripADist(), "km"));
                data.SetTripBDist(CnvtUnits(data.GetTripBDist(), "km"));
                data.SetOutTemp(CnvtUnits(data.GetOutTemp(), "c"));
                data.SetInTemp(CnvtUnits(data.GetInTemp(), "c"));
            }
        }

        // Toggle Change Oil
        //
        // Toggle whether or not the user needs to change the oil
        public void ToggleChangeOil()
        {
            data.SetChangeOil(!data.IsChangeOil());
        }

        // Toggle Check Engine
        //
        // Toggle whether or not the user should check the engine
        public void ToggleCheckEngine()
        {
            data.SetCheckEngine(!data.IsCheckEngine());
        }

        // Toggle Door Ajar
        //
        // Toggle whether or not the door is ajar
        public void ToggleDoorAjar()
        {
            data.SetDoorAjar(!data.IsDoorAjar());
        }

        // Toggle Display Temp
        //
        // Toggle whether or not the display temperature is the outside temperature
        public void ToggleDisplayTemp()
        {
            data.SetDisplayTemp(!data.IsOutTemp());
        }

        // Toggle Metric Units
        //
        // Toggle whether or not the values are outputted in metric
        public void ToggleMetricUnits()
        {
            data.SetMetricUnits(!data.IsMetricUnits());
        }

        // Update Warning Message Type
        //
        // Move the warning message state to the next state
        public void UpdateWarningMessageState()
        {
            data.SetWarningMessageState(data.GetWarningMessageState() + 1);
        }
    }
}
