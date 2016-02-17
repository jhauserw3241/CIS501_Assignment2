﻿using System;
using System.Collections.Generic;

namespace EVIC
{
    public class Model
    {
        // Define variables
        private bool checkEngine = false;
        private bool doorAjar = false;
        private int inTemp = 0;
        private bool isMetricUnits = false;
        private bool isOdometerSys = true;
        private bool isOutTemp = false;
        private bool isTripA = true;
        private int milesTillNextChange = 3000;
        private int odometerValue = 0;
        private int outTemp = 0;
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

        // Is Door Ajar
        //
        // @return whether or not door is ajar
        public bool IsDoorAjar()
        {
            return doorAjar;
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
        public int GetInTemp()
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
        public int GetOutTemp()
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

        // Set Display Temperature
        //
        // Set whether or not the out temperature is being shown
        public void SetDisplayTemp(bool val)
        {
            isOutTemp = val;
        }

        // Set Inside Temperature
        //
        // Set the temperature inside of the vehicle.
        public void SetInTemp(int temp)
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
            odometerValue += val;
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
        public void SetOutTemp(int temp)
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
