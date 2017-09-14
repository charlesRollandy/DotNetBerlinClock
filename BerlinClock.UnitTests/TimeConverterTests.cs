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
    }
}
