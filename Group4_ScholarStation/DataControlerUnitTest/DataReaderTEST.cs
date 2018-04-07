using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessControler;
using System.Data.SqlClient;

namespace DataControlerUnitTest
{
    [TestClass]
    public class DataReaderTEST
    {
        [TestMethod]
        public void ReaderTestMethodToSeeDatabaseTableIsEmpty()
        {
            //Arange
            IRead readFromFalseDB = new ConnectionControler();
            bool readFalse = true;
            String myCommand = "null";

            //Act
            SqlDataReader currentSessionList = readFromFalseDB.DataReader(myCommand);
            if(currentSessionList == null)
            {
                readFalse = false;
            }

            //Assert
            Assert.IsFalse(readFalse);

            //Arange
            IRead readFromTrueDB = new ConnectionControler();
            bool readTrue = false;
            String myCommandTrue = "Select * from tutors";

            //Act
            SqlDataReader currentSessionListTrue = readFromTrueDB.DataReader(myCommandTrue);
            if (currentSessionListTrue.Read())
            {
                readTrue = true;
            }

            //Assert
            Assert.IsTrue(readTrue);
        }
    }
}
