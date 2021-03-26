using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAssignment_2;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        
        string inputString = "";
        string Expected = "";
        [TestMethod]
        public void UpperToLower()
        {
            // Arrange 
            inputString = "UniT TesT";
            Expected = "uNIt tESt";
        
            // Act
            string output = inputString.UppertoLower();

            // Assert
            Assert.AreEqual(Expected, output);

        }

        [TestMethod]
        public void TitleCase()
        {
            // Arrange 
            inputString = "UniT TesT";
            Expected = "Unit Test";

            // Act
            string output = inputString.TitleCase();

            // Assert
            Assert.AreEqual(Expected, output);

        }

        [TestMethod]
        public void CheckLower()
        {
            // Arrange 
            inputString = "UniT TesT";
            Expected = "Success";

            // Act
            string output = inputString.CheckLower();

            // Assert
            Assert.AreEqual(Expected, output);

        }

        [TestMethod]
        public void Capitalize()
        {
            // Arrange 
            inputString = "UniT TesT";
            Expected = "Unit Test";

            // Act
            string output = inputString.Capitalize();

            // Assert
            Assert.AreEqual(Expected, output);

        }

        [TestMethod]
        public void CheckUpper()
        {
            // Arrange 
            inputString = "UniT TesT";
            Expected = "Success";

            // Act
            string output = inputString.CheckUpper();

            // Assert
            Assert.AreEqual(Expected, output);

        }

        [TestMethod]
        public void CheckforInt()
        {
            // Arrange 
            inputString = "12313";
            Expected = "12313";

            // Act
            string output = inputString.CheckforInt();

            // Assert
            Assert.AreEqual(Expected, output);

        }

        [TestMethod]
        public void RemoveLastChar()
        {
            // Arrange 
            inputString = "UniT TesT";
            Expected = "UniT Tes";

            // Act
            string output = inputString.RemoveLastChar();

            // Assert
            Assert.AreEqual(Expected, output);

        }

        [TestMethod]
        public void WordCount()
        {
            // Arrange 
            inputString = "UniT TesT";
            Expected = "9";

            // Act
            string output = inputString.WordCount();

            // Assert
            Assert.AreEqual(Expected, output);

        }

        [TestMethod]
        public void StringToInt()
        {
            // Arrange 
            inputString = "12345";
            Expected = "12345";

            // Act
            string output = inputString.StringToInt();

            // Assert
            Assert.AreEqual(Expected, output);

        }
    }
}
