using System;
using System.Collections.Generic;

namespace EVIC
{
    public class Model
    {
        // Define fields
        #region Fields
        
        private int units = 0, // 0 = US, 1 = Metric
            odometerValue = 0,
            distTillNextChange = 3000,
            tripADist = 0,
            tripBDist = 0,
            outTemp = 75,
            inTemp = 70;
        private bool door = false,
            engine = false,
            oil = false;

        #endregion

        // Define properties
        #region Properties
        
        public int Units { get { return units; } }
        public int OdometerValue { get { return odometerValue; } }
        public int DistTillNextChange { get { return distTillNextChange; } }
        public int TripADist { get { return tripADist; } }
        public int TripBDist { get { return tripBDist; } }
        public int OutTemp { get { return outTemp; } }
        public int InTemp { get { return inTemp; } }
        public bool Door { get { return door; } }
        public bool Engine { get { return engine; } }
        public bool Oil { get { return oil; } }

        #endregion
        
        private bool ResetGauge(string gauge)
        {
            switch (gauge)
            {
                case "total":
                    odometerValue = 0;
                    break;
                case "tripA":
                    tripADist = 0;
                    break;
                case "tripB":
                    tripBDist = 0;
                    break;
                default:
                    return false;
            }
            return true;
        }

        #region Personal Settings

        public void SwitchUnits()
        {
            units = (units + 1) % 2;
            switch (units)
            {
                case 0:
                    odometerValue = CnvtUnits(odometerValue, "mi");
                    distTillNextChange = CnvtUnits(distTillNextChange, "mi");
                    tripADist = CnvtUnits(tripADist, "mi");
                    tripBDist = CnvtUnits(tripBDist, "mi");
                    outTemp = CnvtUnits(outTemp, "f");
                    inTemp = CnvtUnits(inTemp, "f");
                    break;
                case 1:
                    odometerValue = CnvtUnits(odometerValue, "km");
                    distTillNextChange = CnvtUnits(distTillNextChange, "km");
                    tripADist = CnvtUnits(tripADist, "km");
                    tripBDist = CnvtUnits(tripBDist, "km");
                    outTemp = CnvtUnits(outTemp, "c");
                    inTemp = CnvtUnits(inTemp, "c");
                    break;
            }
        }

        private int CnvtUnits(int value, string into)
        {
            switch (into)
            {
                case "c":
                    return (int)Math.Round(((double)value - 32.0) / (9.0 / 5.0));
                case "f":
                    return (int)Math.Round((double)value * (9.0/5.0) + 32.0);
                case "km":
                    return (int)Math.Round((double)value / 0.62137);
                case "mi":
                    return (int)Math.Round((double)value * 0.62137);
                default:
                    return -1;
            }
        }

        #endregion
    }
}
