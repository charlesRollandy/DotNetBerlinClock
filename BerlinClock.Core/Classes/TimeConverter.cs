
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

            return ConvertIlluminatedLampsInARowToString(4, numberOfLightsIlluminated, LampsAreAlwaysRed);
        }

        public string ConvertHoursToBottomHoursLampRow(int hours)
        {
            int numberOfLightsIlluminated = hours % 5;

            return ConvertIlluminatedLampsInARowToString(4, numberOfLightsIlluminated, LampsAreAlwaysRed);
        }

        public string ConvertMinutesToTopMinutesLampRow(int minutes)
        {
            int numberOfLightsIlluminated = (minutes - (minutes % 5)) / 5;
            return ConvertIlluminatedLampsInARowToString(11, numberOfLightsIlluminated, LampAreRedWhenNumberIsDisisibleBy3AndYellowOtherwise);
        }

        public string LampsAreAlwaysRed(int lampNumber)
        {
            return "R";
        }

        public string LampAreRedWhenNumberIsDisisibleBy3AndYellowOtherwise(int lampNumber)
        {
            return lampNumber % 3 == 0 ? "R" : "Y";
        }

        private string ConvertIlluminatedLampsInARowToString(int numberOfLampsInTheRow, int numberOfLightsIlluminated, Func<int, string> provideIlluminatedColor)
        {
            string lampsRowResult = string.Empty;
            for (int i = 1; i <= numberOfLampsInTheRow; i++)
            {
                lampsRowResult += (i <= numberOfLightsIlluminated) ? provideIlluminatedColor(i) : "O";
            }
            return lampsRowResult;
        }
    }
}