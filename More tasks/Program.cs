using More_tasks;
using System.Text.RegularExpressions;

namespace More_tasks
{
    public class Program
    {
        private static void Main()
        {
            Regex regex = new Regex(@"^([a-z0-9])+\.?([a-z0-9]+)@([a-z]+)[.](\w{2,3})$");
            string email = ".test.test@gmail.com";

            bool isMatch = regex.IsMatch(email);
            Console.WriteLine(isMatch);
            Console.WriteLine("\n\n\n"); //////////////////////////////////////////


            Person person = new Person();
            Person person2 = new Person();
            Person person3 = new Person();

            person.Name = email;
            Console.WriteLine(person.Name);
            Console.WriteLine(person.GetLastName());      
            
            Console.WriteLine(Person.count); //number of Person class instances

            Console.WriteLine("\n\n\n"); //////////////////////////////////////////



            ExcelFile excelFile = new ExcelFile();
            
            excelFile.fileName = "new file";
            excelFile.Compress();   


            PowerPointFile powerPointFile = new PowerPointFile();   
            powerPointFile.size = 1024;
            powerPointFile.Compress();

            Console.WriteLine("\n\n\n"); //////////////////////////////////////////


            Shape shape = new Shape();
            Circle circle = new Circle();
            Triangle triangle = new Triangle();

            List<Shape> shapes = new List<Shape>();
            
            shapes.Add(shape);
            shapes.Add(circle);
            shapes.Add(triangle);

            foreach(Shape shapeObj in shapes)
                {
                    shapeObj.Draw();
                }
        }
    }
}