using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock.Core
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            throw new NotImplementedException();
        }

        public string ConvertSecondsToSecondsLampRow(int seconds)
        {
            return (seconds % 2 == 0) ? "Y" : "O";
        }

        public string ConvertHoursToTopHoursLampRow(int hours)
        {
            int numberOfLightsIlluminated = (hours - (hours % 5)) / 5;

            return ConvertIlluminatedLampsInARowToString(4, numberOfLightsIlluminated);
        }

        public string ConvertHoursToBottomHoursLampRow(int hours)
        {
            int numberOfLightsIlluminated = hours % 5;

            return ConvertIlluminatedLampsInARowToString(4, numberOfLightsIlluminated);
        }

        public string ConvertMinutesToTopMinutesLampRow(int minutes)
        {
            int numberOfLightsIlluminated = (minutes - (minutes % 5)) / 5;
            string bottomHoursRowResult = string.Empty;
            for (int i = 1; i <= 11; i++)
            {
                bottomHoursRowResult += (i <= numberOfLightsIlluminated) ? (i % 3 == 0 ? "R" : "Y") : "O";
            }
            return bottomHoursRowResult;
        }

        private string ConvertIlluminatedLampsInARowToString(int numberOfLampsInTheRow, int numberOfLightsIlluminated)
        {
            string bottomHoursRowResult = string.Empty;
            for (int i = 1; i <= numberOfLampsInTheRow; i++)
            {
                bottomHoursRowResult += (i <= numberOfLightsIlluminated) ? "R" : "O";
            }
            return bottomHoursRowResult;
        }
    }
}
