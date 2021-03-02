using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace TestingAssignment_2
{
    public class ExtensionMethods
    {
        public static string StringConvert(string inputString, string opertaion)
        {
            int ascii = 0;
            string output = "";
            if (opertaion.Equals("UpperToLower"))
            {
                foreach (var chr in inputString)
                {
                    ascii = (int)chr;
                    if (ascii >= 65 || ascii <= 90)
                    {
                        ascii += 32;
                    }
                    else
                    {
                        ascii -= 32;
                    }
                    output += (char)ascii;
                }
                return output;
            }

            else if (opertaion.Equals("TitleCase") || opertaion.Equals("Capitalize"))
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                return textInfo.ToTitleCase(inputString);
            }

            else if (opertaion.Equals("CheckLower"))
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
            }

            else if (opertaion.Equals("CheckUpper"))
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
            }

            else if (opertaion.Equals("CheckforInt"))
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

            else if (opertaion.Equals("RemoveLastChar"))
            {
                return inputString.Substring(inputString.Length - 1);
            }

            else if (opertaion.Equals("WordCount"))
            {
                return ""+inputString.Count();
            }

            else if (opertaion.Equals("StringToInt"))
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
            return "null";
        }
    }
}
