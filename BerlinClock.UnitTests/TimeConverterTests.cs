using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BerlinClock.Core;

namespace BerlinClock.UnitTests
{
    [TestClass]
    public class TimeConverterTests
    {
        [TestMethod]
        public void Should_Yellow_Lamp_On_Top_Be_Illuminated_When_Seconds_Are_Even()
        {
            TimeConverter timeConverter = new TimeConverter();
            Assert.AreEqual("Y", timeConverter.ConvertSecondsToSecondsLampRow(0));
            Assert.AreEqual("Y", timeConverter.ConvertSecondsToSecondsLampRow(2));
            Assert.AreEqual("Y", timeConverter.ConvertSecondsToSecondsLampRow(30));
            Assert.AreEqual("Y", timeConverter.ConvertSecondsToSecondsLampRow(58));
        }

        [TestMethod]
        public void Should_Yellow_Lamp_On_Top_Not_Be_Illuminated_When_Seconds_Are_Odd()
        {
            TimeConverter timeConverter = new TimeConverter();
            Assert.AreEqual("O", timeConverter.ConvertSecondsToSecondsLampRow(1));
            Assert.AreEqual("O", timeConverter.ConvertSecondsToSecondsLampRow(3));
            Assert.AreEqual("O", timeConverter.ConvertSecondsToSecondsLampRow(31));
            Assert.AreEqual("O", timeConverter.ConvertSecondsToSecondsLampRow(59));
        }
    }
}
