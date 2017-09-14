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

            return ConvertIlluminatedLampsInARowToString(numberOfLightsIlluminated);
        }

        public string ConvertHoursToBottomHoursLampRow(int hours)
        {
            int numberOfLightsIlluminated = hours % 5;

            return ConvertIlluminatedLampsInARowToString(numberOfLightsIlluminated);
        }

        public string ConvertMinutesToTopMinutesLampRow(int minutes)
        {
            int numberOfLightsIlluminated = (minutes - (minutes % 5)) / 5;
            string topMinutesRowResult = string.Empty;
            for (int i = 1; i <= 11; i++)
            {
                topMinutesRowResult += (i <= numberOfLightsIlluminated) ? "R" : "O";
            }
            return topMinutesRowResult;
        }

        private string ConvertIlluminatedLampsInARowToString(int numberOfLightsIlliminated)
        {
            string bottomHoursRowResult = string.Empty;
            for (int i = 1; i <= 4; i++)
            {
                bottomHoursRowResult += (i <= numberOfLightsIlliminated) ? "R" : "O";
            }
            return bottomHoursRowResult;
        }
    }
}
