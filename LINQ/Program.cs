using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using LINQ.Person;
using Newtonsoft.Json;

// ReSharper disable UseFormatSpecifierInInterpolation

namespace FirstProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvPath = @"C:\Users\meduz\Documents\CSharp-COURSE\LINQ\googleplaystore1.csv";
            var googleApps = LoadGoogleAps(csvPath);

            //Display(googleApps);
            //GetData(googleApps);
            //ProjectData(googleApps);
            //DivideData(googleApps);
            //OrderData(googleApps);
            //DataSetOperation(googleApps);
            //DataVerification(googleApps);
            //GroupData(googleApps);
            //GroupDataOperations(googleApps);

            var people = LoadPeople();
            var addresses = LoadAddresses();

            //TASK WITH DOING THE LEFT JOIN

            Console.WriteLine("--------------------------------------------------");

            var leftJoin = people.GroupJoin(addresses, p => p.Id, a => a.PersonId, (person, addresses) => new
            {
                Person = person,
                Addresses = addresses
            }).SelectMany(x => x.Addresses.DefaultIfEmpty(), (person, address) => new
            {
                Person = person.Person,
                Address = address,
                City = address?.City
            });

            foreach (var person in leftJoin)
            {
                Console.WriteLine(person.Person.Name + " " + person.Address?.Street + " " + person.City);
            }

            Console.WriteLine("--------------------------------------------------");







            //LEARNING LINQ

            var peopleWithAddresses = people.Join(addresses, p => p.Id, a => a.PersonId, (p, a) => new
            {
                Person = p,
                Address = a
            });

            foreach (var personWithAddress in peopleWithAddresses)
            {
                Console.WriteLine(personWithAddress.Person.Name + " " + personWithAddress.Address.Street);
            }
            Console.WriteLine("--------------------------------------------------");

            var groupJoin = people.GroupJoin(addresses, p => p.Id, a => a.PersonId,

                (person, addresses) => new { person.Name, Addreses = addresses
            });

            foreach (var person in groupJoin)
            {
                Console.WriteLine(person.Name);
                foreach (var address in person.Addreses)
                {
                    Console.WriteLine(person.Name + " " + address.Street);
                }
            }
        }
    

        private static List<Person> LoadPeople()
        {
            var jsonFullPath = Directory.GetCurrentDirectory();
            jsonFullPath = Directory.GetParent(jsonFullPath).Parent.FullName;
            jsonFullPath = Directory.GetParent(jsonFullPath).Parent.FullName;
            jsonFullPath += @"\LINQ\Person\People.json";
            var json = File.ReadAllText(jsonFullPath);
      
            return JsonConvert.DeserializeObject<List<Person>>(json);
        }

        private static List<Address> LoadAddresses()
        {
            var jsonFullPath = Directory.GetCurrentDirectory();
            jsonFullPath = Directory.GetParent(jsonFullPath).Parent.FullName;
            jsonFullPath = Directory.GetParent(jsonFullPath).Parent.FullName;
            jsonFullPath += @"\LINQ\Person\Addresses.json";
            var json = File.ReadAllText(jsonFullPath);

            return JsonConvert.DeserializeObject<List<Address>>(json);
        }

        static void GroupDataOperations(IEnumerable<GoogleApp> googleApps)
        {
            var cathegoryGroups = googleApps.GroupBy(x => x.Category);


            foreach (var group in cathegoryGroups)
            {
                Console.WriteLine("Group " + group.Key);
                Console.WriteLine(group.Average(g => g.Reviews));
                Console.WriteLine(group.Min(g => g.Reviews));
                Console.WriteLine(group.Max(g => g.Reviews));
                Console.WriteLine("------------------------");
            }

            Console.WriteLine("--------------------------------------------------");

            var filteredGroups = googleApps.GroupBy(x => x.Category)
                .Where(g=> g.Min(g=>g.Reviews >= 10));

            foreach (var group in filteredGroups)
            {
                Console.WriteLine("Group " + group.Key);
                Console.WriteLine(group.Average(g => g.Reviews));
                Console.WriteLine(group.Min(g => g.Reviews));
                Console.WriteLine(group.Max(g => g.Reviews));
                Console.WriteLine("------------------------");
            }

        }

        static void GroupData (IEnumerable<GoogleApp> googleApps)
        {
            var cathegoryGroups = googleApps.GroupBy(x => x.Category);

            Console.WriteLine("Number of cathegories: " + cathegoryGroups.Count());

            var video_players = cathegoryGroups.First(g => g.Key == Category.VIDEO_PLAYERS);
            var apps = video_players.ToList();
            Display(apps);

            foreach (var group in cathegoryGroups)
            {
                Console.WriteLine("Group--------------------");
                Display(group);
            }
        }
        static void DataVerification (IEnumerable<GoogleApp> googleApps)
        {
            var weatherApps = googleApps.Where(x =>x.Category == Category.WEATHER);
            Console.WriteLine("Does every weather app have at least 20 reviews?: " + weatherApps.All(x=>x.Reviews > 20));
            Console.WriteLine("Any weather apps with 2 million reviews?: " + weatherApps.Any(x => x.Reviews > 2000000));

        }
        static void DataSetOperation (IEnumerable<GoogleApp> googleApps)
        {
            /*var highRatedApps = googleApps.Where(x => (x.Rating > 4.6))
                .Select(a => a.Category);

            Console.WriteLine("High rated apps cathegories.");
            Console.WriteLine(string.Join("\n",highRatedApps.Distinct()));*/


            var setA = googleApps.Where(x => x.Rating > 4.6 && x.Type == Type.Paid
            && x.Reviews > 1200);

            var setB = googleApps.Where(x=>x.Name.Contains("Pro") && x.Reviews > 1200
            && x.Rating > 4.6);

           /* Display(setA);
            Console.WriteLine("--------------------------------------------------");
            Display(setB);*/

            var appsUnion = setA.Union(setB);
            Console.WriteLine("Apps union");
            Display(appsUnion);

            Console.WriteLine("--------------------------------------------------");
            var appsIntersect = setA.Intersect(setB);
            Console.WriteLine("Apps intersect");
            Display(appsIntersect);

            Console.WriteLine("--------------------------------------------------");
            var appsExcept = setA.Except(setB);
            Console.WriteLine("Apps except");
            Display(appsExcept);
        }

        static void OrderData(IEnumerable<GoogleApp> googleApps)
        {
            var orderedApps = googleApps.OrderByDescending(x => x.Rating) //method chaining
                .ThenBy(x => x.Name)
                .Take(5);
            Display(orderedApps);
        }
        static void ProjectData(IEnumerable<GoogleApp> googleApps)
        {
            var highRatedApps = googleApps.Where(x => (x.Rating > 4.6) && (x.Category == Category.BEAUTY));
            var highRatedAppsNames = highRatedApps.Select(x => x.Name);

           // highRatedAppsNames.ToList().ForEach(x => Console.WriteLine(x));

            var dtos = highRatedApps.Select(x => new GoogleAppDto
            {
                Name = x.Name,
                Reviews = x.Reviews
            });

            var anonymousDtos = highRatedApps.Select(x => new 
            {
                Name = x.Name,
                Reviews = x.Reviews
            });

            dtos.ToList().ForEach(x => Console.WriteLine(x.Name + " "+ x.Reviews));
                        dtos.ToList().ForEach(x => Console.WriteLine(x.Name + " "+ x.Reviews));

            var genres = googleApps.SelectMany(x => x.Genres);
            genres.ToList().ForEach(x => Console.WriteLine(x));



          /*  List<string> highRatedAppsNames = new List<string>();

            foreach (var googleApp in highRatedApps)
            {
                highRatedAppsNames.Add(googleApp.Name);
            }*/

        }

        static void DivideData(IEnumerable<GoogleApp> googleApps)
        {
            var highRatedApps = googleApps.Where(x => (x.Rating > 4.6) && (x.Category == Category.BEAUTY));
            //Display(highRatedApps);

            var firstHighRatedApp = highRatedApps.Take(5);  
            Display(firstHighRatedApp);

            Console.WriteLine("--------------------------------------------------");

            firstHighRatedApp = highRatedApps.TakeWhile(x=> x.Reviews > 1500);
            Display(firstHighRatedApp);

            Console.WriteLine("--------------------------------------------------");

            firstHighRatedApp = firstHighRatedApp.Skip(1);
            Display(firstHighRatedApp);

            //SkipWhile -> version with a predicate

            /*foreach (var googleApp in highRatedApps)
            {
                firstHighRatedApp.Add(googleApp);
                if (firstHighRatedApp.Count == 5)
                    break;
            }

            Display(firstHighRatedApp);*/
        }
        static void GetData(IEnumerable<GoogleApp> googleApps)
        {
            var highRatedApps = googleApps.Where(x => (x.Rating > 4.6) && (x.Category == Category.BEAUTY))
                 .ToList();
            highRatedApps.ForEach(x => Console.WriteLine(x.ToString()));

            Console.WriteLine("--------------------------------------------------");
            var first = googleApps.FirstOrDefault(x => x.Category == Category.BEAUTY);
            Display(first);
        }

        static void Display(IEnumerable<GoogleApp> googleApps)
        {
            foreach (var googleApp in googleApps)
            {
                Console.WriteLine(googleApp);
            }

        }
        static void Display(GoogleApp googleApp)
        {
            Console.WriteLine(googleApp);
        }

        static List<GoogleApp> LoadGoogleAps(string csvPath)
        {
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<GoogleAppMap>();
                var records = csv.GetRecords<GoogleApp>().ToList();
                return records;
            }

        }

    }    
}


