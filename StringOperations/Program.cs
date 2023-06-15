// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

namespace StringOperations { 

    class Program
    {
        static void Main(string[] args)
        {
           // Console.WriteLine("Insert input: ");
           // string userInput = Console.ReadLine();
            
            //TESTING//
            /*SubString(userInput);
            Replace(userInput);
            Modify(userInput);
            AlterTextCase(userInput);
            Split(userInput);
            CheckExtension(userInput);*/

            //PRACTICE//
            //ToCamelCase(userInput);
           // ToKebabCase(userInput);

            //DATE TIME//
            DateTime now = DateTime.Now;
            DateTime openDate = new DateTime(2021, 1, 1);

            //result is TimeSpan
            var result = now - openDate;
            Console.WriteLine(result.Days + " days");

            //var result2 = now + openDate; incorrect

            Console.WriteLine(now.Date);
            var result2 = now.Add(result);
            Console.WriteLine(result2.Date);

            Console.WriteLine(result2.ToString("F"));

            //TIME MEASUREMENT//

            DateTime start = DateTime.Now;

            for (int i = 0; i < 100000; i++)
            {
                //
            }

            DateTime end = DateTime.Now;

            Console.WriteLine(end - start);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 100000; i++)
            {
                //
            }
            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed);

            //CLASS FOR DATE CHECKING//
            

            DateTime current = DateTime.Now;
            DateTime before = now.Subtract(new TimeSpan(7,0,0,0));
            DateTime after = now.Add(new TimeSpan(7,0,0,0));

            Console.WriteLine(Utils.IsDateBetween(current, before, after));

            //creating an extension method
            Console.WriteLine(now.IsBetween(before, after));

            int number = 5;
            Console.WriteLine(number.Squared());
        }

        static void ToKebabCase(string input)
        {
            //some-variable-name
            string kebabCaseTrim = input.Trim();
            kebabCaseTrim = kebabCaseTrim.Replace(" ", "-");           
            string kebabCaseLower = kebabCaseTrim.ToLower();
            Console.WriteLine(kebabCaseLower);
        }

        static void ToCamelCase(string input)
        {
            //someVariableName
            string camelCaseTrim = input.Trim();
            string[] words = camelCaseTrim.Split(' ');
            string result = "";

            //first word
            string firstLetter = words[0].Substring(0, 1);
            string restOfWord = words[0].Substring(1);
            string camelCase = firstLetter.ToLower() + restOfWord.ToLower();
            result += camelCase;

            //rest of the words
            foreach (string word in words.Skip(1)) //skip the first word
            {
                 firstLetter = word.Substring(0, 1);
                 restOfWord = word.Substring(1);
                 camelCase = firstLetter.ToUpper() + restOfWord.ToLower();
                 result += camelCase;
            }
            Console.WriteLine(result);
        }

        static void SubString(string input)
        {
            if (input.Length > 5)
            {
                string start = input.Substring(0, 5);
                string end = input.Substring(input.Length - 5);
                Console.WriteLine(start +"..."+ end);
            }
        }

        static void Replace(string input)
        {
            string replace = input.Replace(" ", "_");
            Console.WriteLine(replace);
        }

        static void Modify(string input)
        {
            if (input.Length > 5)
            {
                string modify = input.Remove(0, 5);
                Console.WriteLine(modify);
            }
            //trim can be used to remove whitespaces
            //modify.Trim();
        }

        static void AlterTextCase(string input)
        {
            string alteredText = input.ToUpper();
            Console.WriteLine(alteredText);
        }

        static void Split(string input)
        {
            foreach(string word in input.Split(' '))
            Console.WriteLine(word);
        }
        
        static void CheckExtension(string input)
        {
            if(input.EndsWith(".txt"))
            {
                Console.WriteLine("Text file!");
            }
            else
            {
                Console.WriteLine("Not a text file!");
            }

            if(input.Contains("text"))
            {
                Console.WriteLine("Contains word text!");
            }
            else
            { 
                Console.WriteLine("Doesn't contain word text!");      
            }
        }
    }
}

