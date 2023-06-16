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
            ProjectData(googleApps);
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


