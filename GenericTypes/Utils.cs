using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
    public class Utils
    {
        public static void Swap<T>(ref T a, ref T b) 
        {
            Console.WriteLine($"Before swap: a = {a}, b = {b}");
            T temp = a;
            a = b;
            b = temp;
            Console.WriteLine($"After swap: a = {a}, b = {b}");
        }
    }
}
