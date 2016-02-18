using System;
using System.Collections.Generic;

namespace EVIC
{
    public class Model
    {
        // Define variables
        private bool checkEngine = false;
        private bool changeOil = false;
        private bool doorAjar = false;
        private double inTemp = 0.00;
        private bool isFarenheitUnits = true;
        private bool isMetricUnits = false;
        private bool isOdometerSys = true;
        private bool isOutTemp = false;
        private bool isTripA = true;
        private int milesTillNextChange = 3000;
        private int odometerValue = 0;
        private double outTemp = 0.00;
        private int tripADist = 0;
        private int tripBDist = 0;
        private int warningMessageState = 0;

        // Allow other classes to access variables

        // Is Check Engine
        //
        // @return whether or not the user should check the engine soon
        public bool IsCheckEngine()
        {
            return checkEngine;
        }

        // Is Change Oil
        //
        // @return whether or not the oil needs to be checked
        public bool IsChangeOil()
        {
            return changeOil;
        }

        // Is Door Ajar
        //
        // @return whether or not door is ajar
        public bool IsDoorAjar()
        {
            return doorAjar;
        }

        // Is Farenheit Units
        //
        // @whether or not the degrees are in farenheit
        public bool IsFarenheitUnits()
        {
            return isFarenheitUnits;
        }

        // Is Metric Units
        //
        // @return whether or not the output should be display in metric units
        public bool IsMetricUnits()
        {
            return isMetricUnits;
        }

        // Is Out Temperature
        //
        // @return whether or not the output temperature should be the internal temperature
        //      of the car or the temperature of the outside
        public bool IsOutTemp()
        {
            return isOutTemp;
        }

        // Is Trip A
        //
        // @return whether or not the trip information to output is the Trip A information
        public bool IsTripA()
        {
            return isTripA;
        }

        // Get In Temp
        //
        // @return the internal temp of the car
        public double GetInTemp()
        {
            return inTemp;
        }

        // Get Miles Till Next Change
        //
        // @return the number of miles till the next oil change
        public int GetMilesTillNextChange()
        {
            return milesTillNextChange;
        }

        // Set Odometer System
        //
        // @return whether or not the odometer should be outputted for the System Status
        public bool GetOdometerSys()
        {
            return isOdometerSys;
        }

        // Get Odometer Value
        //
        // @return the odometer value
        public int GetOdometerValue()
        {
            return odometerValue;
        }

        // Get Out Temperature
        //
        // @return the out temperature
        public double GetOutTemp()
        {
            return outTemp;
        }

        // Get Trip A Dist
        //
        // @return the Trip A distance
        public int GetTripADist()
        {
            return tripADist;
        }

        // Get Trip B Dist
        //
        // @return the Trip B distance
        public int GetTripBDist()
        {
            return tripBDist;
        }

        // Get Warning Message State
        //
        // @return the warning message state
        public int GetWarningMessageState()
        {
            return warningMessageState;
        }

        // Set Check Engine
        //
        // Set if the engine needs to be checked soon
        // @param whether or not the engine needs to be checked soon
        public void SetCheckEngine(bool val)
        {
            checkEngine = val;
        }

        // Set Change Oil
        //
        // Set whether or not the user needs to change the oil
        // @param val whether or not the oil needs to be changed
        public void SetChangeOil(bool val)
        {
            changeOil = val;
        }

        // Set Display Temperature
        //
        // Set whether or not the out temperature is being shown
        public void SetDisplayTemp(bool val)
        {
            isOutTemp = val;
        }

        // Set Door Ajar
        //
        // Set whether the door is ajar
        // @param whether or not the door is open
        public void SetDoorAjar(bool val)
        {
            doorAjar = val;
        }

        // Set Farenheit Units
        //
        // @param whether or not the units are in farenheit
        public void SetFarenheitUnits(bool val)
        {
            isFarenheitUnits = val;
        }

        // Set Inside Temperature
        //
        // Set the temperature inside of the vehicle.
        public void SetInTemp(double temp)
        {
            inTemp = temp;
        }

        // Set Metric Units
        //
        // Set whether or not the units are metric
        public void SetMetricUnits(bool val)
        {
            isMetricUnits = val;
        }

        // Set Odometer System
        //
        // Update the System Status to either show the odometer value or the
        // distance to the next oil change
        // @param whether or not the odometer value should be shown
        public void SetOdometerSys(bool val)
        {
            isOdometerSys = val;
        }

        // Set Odometer Value
        //
        // Update the odometer value by the supplied value
        // @param the odometer value to add to the odometer value
        public void SetOdometerValue(int val)
        {
            odometerValue = val;
        }

        // Set Oil Change
        //
        // Update the miles till the next oil change value
        // @param the new number of miles to the next oil change
        public void SetOilChangeDist(int val)
        {
            milesTillNextChange = val;
        }

        // Set Outside Temperature
        // 
        // Set the temperature inside the vehicle.
        public void SetOutTemp(double temp)
        {
            outTemp = temp;
        }

        // Set Trip A Distance
        //
        // Set the Trip A distance
        public void SetTripADist(int val)
        {
            tripADist = val;
        }

        // Set Trip B Distance
        //
        // Set the Trip B distance
        public void SetTripBDist(int val)
        {
            tripBDist = val;
        }

        // Set Trip Display
        //
        // Set which trip is diplayed.
        public void SetTripDisp(bool val)
        {
            isTripA = val;
        }

        // Set Warning Message State
        //
        // Set the warning message state to the supplied value
        // @param val to set the warning state
        public void SetWarningMessageState(int val)
        {
            //warningMessageState = (val % 2);
            warningMessageState = (val % 3);
        }
    }
}
