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

            string topHoursRowResult = string.Empty;
            for (int i = 1; i <= 4; i++)
            {
                topHoursRowResult += (i <= numberOfLightsIlluminated) ? "R" : "O";
            }

            return topHoursRowResult;
        }

        public string ConvertHoursToBottomHoursLampRow(int p)
        {
            return string.Empty;
        }
    }
}
