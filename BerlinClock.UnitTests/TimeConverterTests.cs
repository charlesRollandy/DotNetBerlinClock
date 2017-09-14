﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BerlinClock.Core;

namespace BerlinClock.UnitTests
{
    [TestClass]
    public class TimeConverterTests
    {
        private TimeConverter timeConverter;

        [TestInitialize]
        public void Init()
        {
            timeConverter = new TimeConverter();
        }

        [TestMethod]
        public void Should_Yellow_Lamp_On_Top_Be_Illuminated_When_Seconds_Are_Even()
        {
            Assert.AreEqual("Y", timeConverter.ConvertSecondsToSecondsLampRow(0));
            Assert.AreEqual("Y", timeConverter.ConvertSecondsToSecondsLampRow(2));
            Assert.AreEqual("Y", timeConverter.ConvertSecondsToSecondsLampRow(30));
            Assert.AreEqual("Y", timeConverter.ConvertSecondsToSecondsLampRow(58));
        }

        [TestMethod]
        public void Should_Yellow_Lamp_On_Top_Not_Be_Illuminated_When_Seconds_Are_Odd()
        {
            Assert.AreEqual("O", timeConverter.ConvertSecondsToSecondsLampRow(1));
            Assert.AreEqual("O", timeConverter.ConvertSecondsToSecondsLampRow(3));
            Assert.AreEqual("O", timeConverter.ConvertSecondsToSecondsLampRow(31));
            Assert.AreEqual("O", timeConverter.ConvertSecondsToSecondsLampRow(59));
        }

        [TestMethod]
        public void Should_Top_Hours_Row_Have_Four_Lamps()
        {
            for (int i = 0; i < 60; i++)
            {
                Assert.AreEqual(4, timeConverter.ConvertHoursToTopHoursLampRow(i).Length);
            }
        }

        [TestMethod]
        public void Should_Top_Hours_Row_Have_No_Red_Lamp_Illuminated_When_Hour_Is_Zero()
        {
            Assert.AreEqual("OOOO", timeConverter.ConvertHoursToTopHoursLampRow(0));
        }

        [TestMethod]
        public void Should_Every_Top_Hours_Row_Lamp_Be_Illuminated_When_Another_5_Hours_Have_Passed()
        {
            Assert.AreEqual("OOOO", timeConverter.ConvertHoursToTopHoursLampRow(2));
            Assert.AreEqual("OOOO", timeConverter.ConvertHoursToTopHoursLampRow(4));
            Assert.AreEqual("ROOO", timeConverter.ConvertHoursToTopHoursLampRow(5));
            Assert.AreEqual("ROOO", timeConverter.ConvertHoursToTopHoursLampRow(6));
            Assert.AreEqual("ROOO", timeConverter.ConvertHoursToTopHoursLampRow(9));
            Assert.AreEqual("RROO", timeConverter.ConvertHoursToTopHoursLampRow(10));
            Assert.AreEqual("RROO", timeConverter.ConvertHoursToTopHoursLampRow(11));
            Assert.AreEqual("RROO", timeConverter.ConvertHoursToTopHoursLampRow(14));
            Assert.AreEqual("RRRO", timeConverter.ConvertHoursToTopHoursLampRow(15));
            Assert.AreEqual("RRRO", timeConverter.ConvertHoursToTopHoursLampRow(16));
            Assert.AreEqual("RRRO", timeConverter.ConvertHoursToTopHoursLampRow(19));
            Assert.AreEqual("RRRR", timeConverter.ConvertHoursToTopHoursLampRow(20));
            Assert.AreEqual("RRRR", timeConverter.ConvertHoursToTopHoursLampRow(21));
            Assert.AreEqual("RRRR", timeConverter.ConvertHoursToTopHoursLampRow(23));
        }

        [TestMethod]
        public void Should_Bottom_Hours_Row_Have_Four_Lamps()
        {
            for (int i = 0; i < 60; i++)
            {
                Assert.AreEqual(4, timeConverter.ConvertHoursToBottomHoursLampRow(i).Length);
            }
        }

        [TestMethod]
        public void Should_Bottom_Hours_Row_Have_No_Red_Lamp_Illuminated_When_Hour_Is_Zero()
        {
            Assert.AreEqual("OOOO", timeConverter.ConvertHoursToBottomHoursLampRow(0));
        }

        [TestMethod]
        public void Should_Every_Bottom_Hours_Row_Lamp_Be_Illuminated_When_Another_Hour_Has_Passed_And_Hours_Number_Is_Not_Divisible_By_Five()
        {
            Assert.AreEqual("RROO", timeConverter.ConvertHoursToBottomHoursLampRow(2));
            Assert.AreEqual("RRRR", timeConverter.ConvertHoursToBottomHoursLampRow(4));
            Assert.AreEqual("OOOO", timeConverter.ConvertHoursToBottomHoursLampRow(5));
            Assert.AreEqual("ROOO", timeConverter.ConvertHoursToBottomHoursLampRow(6));
            Assert.AreEqual("RRRR", timeConverter.ConvertHoursToBottomHoursLampRow(9));
            Assert.AreEqual("OOOO", timeConverter.ConvertHoursToBottomHoursLampRow(10));
            Assert.AreEqual("ROOO", timeConverter.ConvertHoursToBottomHoursLampRow(11));
            Assert.AreEqual("RROO", timeConverter.ConvertHoursToBottomHoursLampRow(12));
            Assert.AreEqual("RRRO", timeConverter.ConvertHoursToBottomHoursLampRow(13));
            Assert.AreEqual("RRRR", timeConverter.ConvertHoursToBottomHoursLampRow(14));
            Assert.AreEqual("OOOO", timeConverter.ConvertHoursToBottomHoursLampRow(15));
            Assert.AreEqual("ROOO", timeConverter.ConvertHoursToBottomHoursLampRow(16));
            Assert.AreEqual("RRRR", timeConverter.ConvertHoursToBottomHoursLampRow(19));
            Assert.AreEqual("OOOO", timeConverter.ConvertHoursToBottomHoursLampRow(20));
            Assert.AreEqual("ROOO", timeConverter.ConvertHoursToBottomHoursLampRow(21));
            Assert.AreEqual("RRRO", timeConverter.ConvertHoursToBottomHoursLampRow(23));
        }

        [TestMethod]
        public void Should_Top_Minutes_Row_Have_Eleven_Lamps()
        {
            for (int i = 0; i < 60; i++)
            {
                Assert.AreEqual(11, timeConverter.ConvertMinutesToTopMinutesLampRow(i).Length);
            }
        }

        [TestMethod]
        public void Should_Top_Minutes_Row_Have_No_Lamp_Illuminated_When_Minute_Is_Zero()
        {
            Assert.AreEqual("OOOOOOOOOOO", timeConverter.ConvertMinutesToTopMinutesLampRow(0));
        }

        [TestMethod]
        public void Should_Every_Third_Top_Minutes_Row_Lamp_Be_Illuminated_In_Red_When_Fifteen_Minutes_Have_Passed()
        {
            string converResultForFourteenMinutes = timeConverter.ConvertMinutesToTopMinutesLampRow(14);
            string converResultForFifteenMinutes = timeConverter.ConvertMinutesToTopMinutesLampRow(15);
            string converResultForSixteenMinutes = timeConverter.ConvertMinutesToTopMinutesLampRow(16);

            string converResultForTwentyNineMinutes = timeConverter.ConvertMinutesToTopMinutesLampRow(29);
            string converResultForThirtyMinutes = timeConverter.ConvertMinutesToTopMinutesLampRow(30);
            string converResultForThirtyOneMinutes = timeConverter.ConvertMinutesToTopMinutesLampRow(31);

            string converResultForFortyFourMinutes = timeConverter.ConvertMinutesToTopMinutesLampRow(44);
            string converResultForFortyFiveMinutes = timeConverter.ConvertMinutesToTopMinutesLampRow(45);
            string converResultForFortySixMinutes = timeConverter.ConvertMinutesToTopMinutesLampRow(46);

            Assert.AreEqual("O", converResultForFourteenMinutes.Substring(2, 1));
            Assert.AreEqual("O", converResultForFourteenMinutes.Substring(5, 1));
            Assert.AreEqual("O", converResultForFourteenMinutes.Substring(8, 1));

            Assert.AreEqual("R", converResultForFifteenMinutes.Substring(2, 1));
            Assert.AreEqual("O", converResultForFifteenMinutes.Substring(5, 1));
            Assert.AreEqual("O", converResultForFifteenMinutes.Substring(8, 1));

            Assert.AreEqual("R", converResultForSixteenMinutes.Substring(2, 1));
            Assert.AreEqual("O", converResultForSixteenMinutes.Substring(5, 1));
            Assert.AreEqual("O", converResultForSixteenMinutes.Substring(8, 1));

            Assert.AreEqual("R", converResultForTwentyNineMinutes.Substring(2, 1));
            Assert.AreEqual("O", converResultForTwentyNineMinutes.Substring(5, 1));
            Assert.AreEqual("O", converResultForTwentyNineMinutes.Substring(8, 1));

            Assert.AreEqual("R", converResultForThirtyMinutes.Substring(2, 1));
            Assert.AreEqual("R", converResultForThirtyMinutes.Substring(5, 1));
            Assert.AreEqual("O", converResultForThirtyMinutes.Substring(8, 1));

            Assert.AreEqual("R", converResultForThirtyOneMinutes.Substring(2, 1));
            Assert.AreEqual("R", converResultForThirtyOneMinutes.Substring(5, 1));
            Assert.AreEqual("O", converResultForThirtyOneMinutes.Substring(8, 1));

            Assert.AreEqual("R", converResultForFortyFourMinutes.Substring(2, 1));
            Assert.AreEqual("R", converResultForFortyFourMinutes.Substring(5, 1));
            Assert.AreEqual("O", converResultForFortyFourMinutes.Substring(8, 1));

            Assert.AreEqual("R", converResultForFortyFiveMinutes.Substring(2, 1));
            Assert.AreEqual("R", converResultForFortyFiveMinutes.Substring(5, 1));
            Assert.AreEqual("R", converResultForFortyFiveMinutes.Substring(8, 1));

            Assert.AreEqual("R", converResultForFortySixMinutes.Substring(2, 1));
            Assert.AreEqual("R", converResultForFortySixMinutes.Substring(5, 1));
            Assert.AreEqual("R", converResultForFortySixMinutes.Substring(8, 1));
        }
    }
}
