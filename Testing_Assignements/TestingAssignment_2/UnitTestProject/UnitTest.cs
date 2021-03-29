using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAssignment_2;
using Xunit;

namespace UnitTestProject
{
    public class UnitTest
    {
        
        string inputString = "";
        string Expected = "";

        [Fact]
        public void InverseCase()
        {
            // Arrange 
            inputString = "UniT TesT";
            Expected = "uNIt tESt";
        
            // Act
            string output = inputString.InverseCase();

            // Assert
            Xunit.Assert.Equal(Expected, output);

        }

        [Fact]
        public void TitleCase()
        {
            // Arrange 
            inputString = "UniT TesT";
            Expected = "Unit Test";

            // Act
            string output = inputString.TitleCase();

            // Assert
            Xunit.Assert.Equal(Expected, output);

        }

        [Fact]
        public void CheckLower()
        {
            // Arrange 
            inputString = "UniT TesT";
            Expected = "Success";

            // Act
            string output = inputString.CheckLower();

            // Assert
            Xunit.Assert.Equal(Expected, output);

        }

        [Fact]
        public void Capitalize()
        {
            // Arrange 
            inputString = "UniT TesT";
            Expected = "Unit Test";

            // Act
            string output = inputString.Capitalize();

            // Assert
            Xunit.Assert.Equal(Expected, output);

        }

        [Fact]
        public void CheckUpper()
        {
            // Arrange 
            inputString = "UniT TesT";
            Expected = "Success";

            // Act
            string output = inputString.CheckUpper();

            // Assert
            Xunit.Assert.Equal(Expected, output);

        }

        [Fact]
        public void CheckforInt()
        {
            // Arrange 
            inputString = "12313";
            Expected = "12313";

            // Act
            string output = inputString.CheckforInt();

            // Assert
            Xunit.Assert.Equal(Expected, output);

        }

        [Fact]
        public void RemoveLastChar()
        {
            // Arrange 
            inputString = "UniT TesT";
            Expected = "UniT Tes";

            // Act
            string output = inputString.RemoveLastChar();

            // Assert
            Xunit.Assert.Equal(Expected, output);

        }

        [Fact]
        public void WordCount()
        {
            // Arrange 
            inputString = "UniT TesT";
            Expected = "9";

            // Act
            string output = inputString.WordCount();

            // Assert
            Xunit.Assert.Equal(Expected, output);

        }

        [Fact]
        public void StringToInt()
        {
            // Arrange 
            inputString = "12345";
            Expected = "12345";

            // Act
            string output = inputString.StringToInt();

            // Assert
            Xunit.Assert.Equal(Expected, output);

        }
    }
}
