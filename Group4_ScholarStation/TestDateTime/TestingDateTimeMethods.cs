using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Scholar_Station;

namespace TestDateTime
{
    [TestClass]
    public class TestingDateTimeMethods
    {
        [TestMethod]
        public void TestingTimeMethod()
        {
            //Arange
            Time testTimeResults = new Time();

            //Act
            IList<string> timeList = testTimeResults.getTime();

            //Assert
            Assert.AreEqual("8:00 AM", timeList[0].ToString());
        }
    
        [TestMethod]
        public void TestingDate()
        {
            //Arange
            Date testTimeResults = new Date();

            //Act
            IList<string> timeList = testTimeResults.FillDate();

            //Must be set to the next day. For example it today was 4/25/2018 then the date needs to be set to 4/26/2018.
            //Assert
            Assert.AreEqual("4/26/2018", timeList[0].ToString());
        }
    }
}
