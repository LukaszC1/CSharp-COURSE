using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

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
            DataVerification(googleApps);
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


