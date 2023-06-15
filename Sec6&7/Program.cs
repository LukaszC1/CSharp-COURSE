using program;
using Newtonsoft.Json;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        int result;
        string s = "-1";

        if (int.TryParse(s, out result))
        {
            if(result < 0)
            Console.WriteLine(s);
            else
                Console.WriteLine("Number is not negative!");
        }
        else
            Console.WriteLine("Couldnt parse!");


        //Reverse a string///////////////////////////////////

        string str = "this is a test";

        string[] words = str.Split(' ');
        string[] reverseWords = new string[words.Length];
        int i = 0;

        foreach (string word in words.Reverse()) 
        {
        //    Console.WriteLine(word);
            reverseWords[i] = word;
            i++;
        }
        
       string finalResult = string.Join(' ', reverseWords);
        // Console.WriteLine(finalResult);


        //FILE HANDLING//////////////////////////////////////
        // ReadFiles();
        // GenerateDocuments();
        // ScanAndAppend();

        //(DE)SERIALIZATION TO JSON
        //Json();

        //USING//////////////////////////////////////////////
        using (var readFileStream = new FileStream(@"..\FILE-TEST\doc1.txt", FileMode.Open))
        { 
            //do smth with the file
        
        } //block using will close the file in a safe way (no memory leaks)

        using (Player player = new Player())
        {
            //do whatever
            //the class can be used only in this block
        }

        //var writeFileStream = new FileStream(@"..\FILE-TEST\doc1.txt", FileMode.Append);
        //writeFileStream.Close(); this method is not safe because if an exception is thrown, the file will not be closed
    }

    static void ReadFiles()
    {
        var document1 = File.ReadAllText(@"..\FILE-TEST\doc1.txt");
        var document2 = File.ReadAllLines(@"..\FILE-TEST\doc2.txt");

        var document2String = string.Join(Environment.NewLine, document2);

        Console.WriteLine(document1 + "\n");
        Console.WriteLine(document2 + "\n");

        Console.WriteLine(document2String);


    }

    static void GenerateDocuments()
    {
        string name = "John";
        var orderNumber = "225";

        var template = File.ReadAllText(@"..\FILE-TEST\template.txt");
        var document = template.Replace("{name}", name)
            .Replace("{orderNumber}", orderNumber)
            .Replace("{dateTime}", DateTime.Now.ToString());

        File.WriteAllText(@"..\FILE-TEST\report.txt", document);
    }

    static void ScanAndAppend()
    {
        var files = Directory.GetFiles(@"..\FILE-TEST\","*.txt", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            File.AppendAllText(file, "\n All rights reserved");
        }
    }

    static void Json()
    {
        var player = new Player()
        {
            Name = "John",
            Level = 1,
            HealthPoints = 100,
            Statistics = new List<Statistic>()
            {
                new Statistic() { Name = "Strength", Points = 10 },
                new Statistic() { Name = "Agility", Points = 5 },
                new Statistic() { Name = "Intelligence", Points = 15 }
            }
        };

        player.Level++;

        var jsonPlayer = JsonConvert .SerializeObject(player);
        Console.WriteLine(jsonPlayer);

        File.WriteAllText(@"..\FILE-TEST\player.json", jsonPlayer);

        string readFile = File.ReadAllText(@"..\FILE-TEST\player.json");

        Player readPlayer = JsonConvert.DeserializeObject<Player>(readFile);
        Console.WriteLine(readPlayer.Name);
    }
}

