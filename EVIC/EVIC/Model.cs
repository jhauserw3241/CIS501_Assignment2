namespace EVIC
{
    public class Model
    {
        // Define variables
        public int odometerValue = 0;
        public int milesTillNextChange = 3000;
        public int tripADist = 0;
        public int tripBDist = 0;
        public bool isMetricUnits = false;
        public bool isOutTemp = false;
        public bool isTripA = true;
        public int outTemp = 0;
        public int inTemp = 0;
        public bool checkEngine = false;
        public bool doorAjar = false;
    }
}
