﻿using BinaryConverterDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverterConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryConverterLib lib = new BinaryConverterLib();

            string res = lib.RequestToBinaryConverter(42);
            Console.WriteLine("Binary of 42 is: {0}", res);
            Console.ReadKey();
        }
    }
}
