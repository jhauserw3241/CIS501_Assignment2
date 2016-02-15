using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVIC
{
    public class Controller
    {
        private Model data = new Model();

        // Display Option
        //
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
                // Check if there is some sort of number to be outputted
                string categoryValue;
                if (categoryName[i] == "System Status")
                {
                    categoryValue = "[" + data.odometerValue.ToString() + " mi]";
                }
                else if (categoryName[i] == "Door Ajar")
                {
                    categoryValue = "[" + data.doorAjar.ToString() + "]";
                }
                else if (categoryName[i] == "Check Engine")
                {
                    categoryValue = "[" + data.checkEngine.ToString() + "]";
                }
                else if (categoryName[i] == "Oil Change")
                {
                    categoryValue = "[Oil change in" + data.milesTillNextChange.ToString() + " mi]";
                }
                else if (categoryName[i] == "Units")
                {
                    if (!data.isMetricUnits)
                    {
                        categoryValue = "[US Units]";
                    }
                    else
                    {
                        categoryValue = "[Metric Units]";
                    }
                }
                else if (categoryName[i] == "Temp Info")
                {
                    if (data.isOutTemp)
                    {
                        categoryValue = "[" + data.outTemp.ToString() + " F Outside]";
                    }
                    else
                    {
                        categoryValue = "[" + data.inTemp.ToString() + " F Inside]";
                    }
                }
                else if (categoryName[i] == "Trip Info")
                {
                    if (data.isTripA)
                    {
                        categoryValue = "[Trip-A: " + data.tripADist + " mi]";
                    }
                    else
                    {
                        categoryValue = "[Trip-B: " + data.tripBDist + " mi]";
                    }
                }
                else
                {
                    categoryValue = new String(' ', categoryName[i].Length);
                }

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
                string topBottomBoundary = new String('-', displayLength);
                string intermediateLine = new String(' ', displayLength);
                string sidewaysArrowIntermediate = new String(' ', (displayLength - 2));
                string uprightArrowIntermediate = new String(' ', (displayLength - 1));
                string upDownArrowIntermediate = new String(' ', (displayLength - 2));
                string errorIntermediate = new String(' ', (displayLength - 5));

                // Add the lines to the display array
                output.Add(topBottomBoundary);
                output.Add("|" + categoryName + "|");
                output.Add("|" + categoryValue + "|");
                if (arrowDir[i] == "left")
                {
                    output.Add("|" + intermediateLine + "|");
                    output.Add("|" + sidewaysArrowIntermediate + "<-|");
                }
                else if (arrowDir[i] == "up")
                {
                    output.Add("|" + sidewaysArrowIntermediate + "^|");
                    output.Add("|" + sidewaysArrowIntermediate + "||");
                }
                else if (arrowDir[i] == "right")
                {
                    output.Add("|" + intermediateLine + "|");
                    output.Add("|" + sidewaysArrowIntermediate + "->|");
                }
                else if (arrowDir[i] == "down")
                {
                    output.Add("|" + sidewaysArrowIntermediate + "||");
                    output.Add("|" + sidewaysArrowIntermediate + "v|");
                }
                else if (arrowDir[i] == "up&down")
                {
                    output.Add("|" + upDownArrowIntermediate + "^||");
                    output.Add("|" + upDownArrowIntermediate + "|v|");
                }
                else
                {
                    output.Add("|" + intermediateLine + "|");
                    output.Add("|" + errorIntermediate + "error|");
                }
                output.Add(topBottomBoundary);
                output.Add(" " + intermediateLine + " ");
                totalOutput.Add(output);

                // Reset variables
                output.Clear();
                displayLength = 0;
            }

            return totalOutput;
        }

    }
}
