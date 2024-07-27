using System;
using System.Diagnostics;


// Antonio De Rosa 3H 2023-11-10
/*
 * Write in output crescent order of the value in input.
 */
namespace ConsoleAppCrescentValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert 3 Integer Numbers:");
            int a = int.Parse(Console.ReadLine());         
            int b = int.Parse(Console.ReadLine());         
            int c = int.Parse(Console.ReadLine());         
            int temp;                                      
                                                           
            while (!checkCrescent(a,b,c))                  
            {                                              
                if (c > b)                                 
                {                                          
                    temp = b;                              
                    b = c;                                 
                    c = temp;                              
                }                                          
                if (b > a)                                 
                {                                          
                    temp = a;                              
                    a = b;                                 
                    b = temp;                              
                }                                          
            } // it's possible to not use the while loop using 3 if
                                                           
            Console.WriteLine("Numbers in crescent value order are: {0}, {1}, {2}", c, b, a);
            Console.ReadKey();                             
        }                                                  
                                                           
        static bool checkCrescent(int a, int b, int c)     
        {                                                  
            if (a < b || b < c) return false;              
            if (b < c) return false;
            return true;                                   
        }                                                  
    }                                                      
}                                                          
