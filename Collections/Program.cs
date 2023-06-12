using System.Collections.Generic;
using System.Linq;
namespace Collections
{ 
    class Program
    {
        static void DisplayElements(List<int> argList)
        {
            for (int i = 0; i < argList.Count; i++)
            {
                Console.WriteLine(argList[i]); 
            }
        }

        static List<Person> GetEmployees()
        {           
            List<Person> employees = new List<Person>()
            {
                new Person("Bill","Wick",new DateTime(1998,1,12)),
                new Person("John","Wick",new DateTime(1997,2,21)),
                new Person("Andrew","Jones",new DateTime(1992,2,22)),
                new Person("John","Smith",new DateTime(1991,6,24)),
                new Person("Bob","Smith",new DateTime(2000,7,2)),
                new Person("Andy","Smith",new DateTime(1994,8,23)),
                new Person("Ed","Smith",new DateTime(1995,2,21))
            }; 
            return employees;
        }

        static Dictionary<string,Currency> GetCurrencies()
        {
            return new Dictionary<string, Currency> 
            {
                {"usd", new Currency("usd", "United States, Dollar", 1)},
                {"eur", new Currency("eur", "Euro", 0.83975) },
                {"gbp", new Currency("gbp", "British Pound", 0.74771) },
                {"cad", new Currency("cad", "Canadian Dollar", 1.38724) }
            };
          
        }

        static IEnumerable<int> GetYieldedData()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return i;
            }
        }

        static IEnumerable<int> GetData()
        {
            var result = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                result.Add(i);
            }

            return result;
        }

        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 6, 1, 20};
            list.ForEach(x => { Console.WriteLine(x); });


            Console.WriteLine("************************* \n");

            DisplayElements(list);

            list.Remove(1);

            Console.WriteLine("************************* \n");

            DisplayElements(list);

            list.RemoveRange(0,1);

            Console.WriteLine("************************* \n");

            DisplayElements(list);

            Console.WriteLine("************************* \n");

           
            
            List<Person> employees = GetEmployees();

            bool EmployeeIsYoung(Person employee)
            {
                return employee.DateOfBirth.Year > 1995;
            }
            bool EmployeeIsBob(Person employee)
            {
                return employee.Name == "Bob";
            }

            List<Person> youngEmployees = new List<Person>();

            foreach (Person person in employees)
            {
                if (person.DateOfBirth.Year > 1995)
                youngEmployees.Add(person);
            }

            youngEmployees.ForEach(x => Console.WriteLine("Employee: " + x.Name));
            Console.WriteLine("Young employees count: " +  youngEmployees.Count);

            // LINQ //////////////////////////////////////////

            List<Person> youngEmployeesLinq = employees.Where(EmployeeIsYoung).ToList();
            Person? bob = employees.FirstOrDefault(EmployeeIsBob);

            if(bob is not null)
            {
                Console.WriteLine("Hi! " + bob.Name);
            }

            //LAMBDAS////////////////////////////////////////////

            youngEmployeesLinq = employees.Where(e=>e.DateOfBirth.Year > 1995).ToList();
            youngEmployees.ForEach(x => Console.WriteLine("Employee: " + x.Name));
            Console.WriteLine("Young employees count: " + youngEmployees.Count);


            bob = employees.FirstOrDefault(e=>e.Name.Equals("Bob"));

            if (bob is not null)
            {
                Console.WriteLine("Hi! " + bob.Name);
            }

            //DICTIONARY////////////////////////////////////////////
            // Dictionary<TKey,TValue>

            var dictionary = GetCurrencies();
            var someText = "String";
            var integer = 1;

            Currency? selectedCurrency = null;
            dictionary.TryGetValue("cd", out selectedCurrency);

            if(selectedCurrency is not null)
            Console.WriteLine("The rate for this currency is : " + selectedCurrency.Rate);

            //YIELD//////////////////////////////////////////////////
            //returning the iterator that enables us to get the items one by one
            //instead of the whole collection
            //there is also yield break

            var yieldedData = GetYieldedData();

            foreach( var data in yieldedData)
            {
                Console.WriteLine(data);
            }

            Console.WriteLine("************************* \n");

            var listData = GetData();

            foreach (var data in listData)
            {
                Console.WriteLine(data);
            }
        }
    }
}

