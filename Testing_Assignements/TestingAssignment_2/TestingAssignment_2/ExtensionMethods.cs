using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace TestingAssignment_2
{
    public static class ExtensionMethods
    {
        static int ascii = 0;
        static string output = "";

        /// <summary>
        /// Convert Uppercase to Lower
        /// </summary>
        /// <param name="inputString">extension method</param>
        /// <returns>converted string</returns>
        public static string UppertoLower(this string inputString)
        {
            string output = "";
            int ascii = 0;
            foreach (var ch in inputString)
            {
                ascii = (int)ch;
                if (ascii >= 65 && ascii <= 90)
                    ascii += 32;
                else if (ascii >= 97 && ascii <= 122)
                    ascii -= 32;
                output += (char)ascii;
            }

            return output;
        }

        /// <summary>
        /// Convert to Titecase
        /// </summary>
        /// <param name="inputString">extension method</param>
        /// <returns>converted string</returns>
        public static string TitleCase(this string inputString)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(inputString);
        }

        public static string Capitalize(this string inputString)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(inputString);
        }

        /// <summary>
        /// Check string for lower
        /// </summary>
        /// <param name="inputString">extension method</param>
        /// <returns>converted string</returns>
        public static string CheckLower(this string inputString)
        {
            foreach (var item in inputString)
            {
                ascii = (int)item;
                bool status = false;
                if (ascii >= 97 && ascii <= 122)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                if (status)
                {
                    return "Success";
                }
            }
            return "null";
        }

        /// <summary>
        /// Check for upper case
        /// </summary>
        /// <param name="inputString">extension method</param>
        /// <returns>converted string</returns>
        public static string CheckUpper(this string inputString)
        {
            foreach (var item in inputString)
            {
                ascii = (int)item;
                bool status = false;
                if (ascii >= 65 && ascii <= 90)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                if (status)
                {
                    return "Success";
                }
            }
            return "null";
        }

        /// <summary>
        /// Check for integer
        /// </summary>
        /// <param name="inputString">extension method</param>
        /// <returns>converted string</returns>
        public static string CheckforInt(this string inputString)
        {
            try
            {
                return "" + int.Parse(inputString);
            }
            catch (Exception)
            {
                return "null";
            }
        }

        /// <summary>
        /// Remove Last Charecter
        /// </summary>
        /// <param name="inputString">extension method</param>
        /// <returns>converted string</returns>
        public static string RemoveLastChar(this string inputString)
        {
            return inputString.Substring(0, inputString.Length - 1);
        }

        /// <summary>
        /// Count the word
        /// </summary>
        /// <param name="inputString">extension method</param>
        /// <returns>converted string</returns>
        public static string WordCount(this string inputString)
        {
            return "" + inputString.Count();
        }

        /// <summary>
        /// String to integer
        /// </summary>
        /// <param name="inputString">extension method</param>
        /// <returns>converted string</returns>
        public static string StringToInt(this string inputString)
        {
            try
            {
                return "" + int.Parse(inputString);
            }
            catch (Exception)
            {
                return "null";
            }
        }

    }
}
