﻿using System;
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
            if (seconds % 2 == 0)
                return "Y";
            return "O";
        }
    }
}