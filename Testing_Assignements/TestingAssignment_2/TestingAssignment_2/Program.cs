using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAssignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            string output;

            // Case 1
            output = ExtensionMethods.StringConvert(inputString, "UpperToLower");

            // Case 2
            output = ExtensionMethods.StringConvert(inputString, "TitleCase");

            // Case 3
            output = ExtensionMethods.StringConvert(inputString, "CheckLower");

            // Case 4
            output = ExtensionMethods.StringConvert(inputString, "Capitalize");

            // Case 5
            output = ExtensionMethods.StringConvert(inputString, "CheckUpper");

            // Case 6
            output = ExtensionMethods.StringConvert(inputString, "CheckforInt");

            // Case 7
            output = ExtensionMethods.StringConvert(inputString, "RemoveLastChar");

            // Case 8
            output = ExtensionMethods.StringConvert(inputString, "WordCount");

            // Case 9
            output = ExtensionMethods.StringConvert(inputString, "StringToInt");

            // Console Write
            Console.WriteLine(output);
        }
    }
}
