﻿using System;
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

            // Case 1
            Console.WriteLine(inputString.InverseCase());

            // Case 2
            Console.WriteLine(inputString.TitleCase());

            // Case 3
            Console.WriteLine(inputString.CheckLower());

            // Case 4
            Console.WriteLine(inputString.Capitalize());

            // Case 5
            Console.WriteLine(inputString.CheckUpper());

            // Case 6
            Console.WriteLine(inputString.CheckforInt());

            // Case 7
            Console.WriteLine(inputString.RemoveLastChar());

            // Case 8
            Console.WriteLine(inputString.WordCount());

            // Case 9
            Console.WriteLine(inputString.StringToInt());

            Console.ReadLine();
        }
    }
}
