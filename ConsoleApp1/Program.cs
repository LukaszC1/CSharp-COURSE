using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.CodeDom;

namespace ConsoleApp1
{
    internal class Program
    {
        enum animals : byte { 
            cat = 1,
            dog = 2,
        }

        static void Main()
        {
            /*
                        string fontsFolder = @"C:\Windows\fonts";

                        string concatenated = string.Concat("to", "me");

                        string interpolated = $"{fontsFolder} + \\folder";
                        Console.WriteLine(interpolated);


                        StringBuilder sb = new StringBuilder("This");
                        sb.Append(" is");
                        sb.Append(" a text.");

                        string result = sb.ToString();
                        Console.WriteLine(result);

                        bool compareResult = sb.ToString().Equals(result);
                        Console.WriteLine(compareResult);*/

            String year = "1981";

            // parsing to different data types
            int yearInteger = int.Parse(year);
            Console.WriteLine(yearInteger);

            string[] cars = { "volvo", "audi", "mazda"};

            foreach (var car in cars) {
                Console.WriteLine(car + "\n");
            }

            List<int> listOfInputs = new List<int>();           //TASK1

            string temp;
            int maxVal = 0;

            while(true)
            {
                temp = Console.ReadLine();
                if (temp.Equals("0"))
                    break;

                int lastInt = int.Parse(temp);

                if(lastInt > maxVal)
                    maxVal = lastInt;

                listOfInputs.Add(lastInt);   
            }


            int result = 0;

            foreach (var element in listOfInputs)
            {
                result += element;
            }

            Console.WriteLine("Result: " + result);
            Console.WriteLine("Max value: " + maxVal);

            Console.WriteLine("Select 1 for cat or 2 for dog:");
            var input = Console.ReadLine();

            animals userChoice = (animals)Enum.Parse(typeof(animals), input);

            if(userChoice == animals.cat)
            {
                Console.WriteLine("CAT!");
            }
            else
                Console.WriteLine("DOG!");


            //nullable

            int? number = null;

            Console.WriteLine(number);


            //try-catch
            try 
            { var element = cars[5]; }
            catch (IndexOutOfRangeException e) 
            { Console.WriteLine("Exception!"); };


            //TASK 2 PARSING DATA

            Console.WriteLine("Enter your date of birth: (dd.mm.yyyy)");
            string userInput = Console.ReadLine();

            var dateNow = DateTime.Now;
            DateTime dateOfBirth = DateTime.Parse(userInput);
            TimeSpan timeSpan = dateNow - dateOfBirth;

            Console.WriteLine(timeSpan.TotalDays);

            Console.ReadLine(); 
        }
    }
}
