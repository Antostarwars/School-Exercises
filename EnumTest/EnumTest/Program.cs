using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        // New Data Type, it works like an int. 0,1,2 etc
        enum Test
        {
            RED = 0,
            GREEN
        }
    }
}
