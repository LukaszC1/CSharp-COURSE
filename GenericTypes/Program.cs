
using GenericTypes;

internal class Program
{
    private static void Main(string[] args)
    {
        var restaurants = new List<Restaurant>();

        var paginatedResult = new PaginatedResult<Restaurant>
        {
            Results = restaurants,
            ResultsFrom = 1,
            ResultsTo = 10,
            TotalPages = 1,
            TotalResults = 10
        };

        var users = new List<User>();

        /*
            var stringRepository = new Repository<string>();

            stringRepository.Add("Hello");
            stringRepository.Add("World");

            Console.WriteLine(stringRepository.GetEelement(0));*/

        var userRepo = new Repository<int, User>();

        userRepo.Add(1, new User { Name = "John" });
        User? user = userRepo.GetEelement(1);
        Console.WriteLine(user?.Name);


        int[] intArray = { 1, 2, 3, 4, 5 };

        Utils.Swap(ref intArray[0], ref intArray[1]);

      /*  foreach (var item in intArray)
        {
            Console.WriteLine(item);
        }
      */
        void WriteWithComma(string value)
        {
            Console.Write(value + ", ");
        }

        Display display = (string value) => Console.Write(value + ", ");
        display("Hello World");

        display(Count(intArray,x=>x > 2).ToString());
    }

    static void DisplayNumbers(IEnumerable<int> numbers, Display display)
    {
        foreach (var number in numbers)
        {
            display(number.ToString());
        }
    }

    public delegate void Display(string message);

    public delegate bool Predicate<T>(T element);
    static int Count<T>(IEnumerable<T> elements, Predicate<T> predicate)
    {
        int count = 0;

        foreach (var element in elements)
        {
           if(predicate(element))
            count++;
        }
        return count;
    }
}


