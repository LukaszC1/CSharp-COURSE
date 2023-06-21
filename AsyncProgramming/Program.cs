
namespace asynchronous_programming
{

    class Program
    {
        private static List<Task> tasks = new List<Task>();
        private static int count = 0;
        static async Task Main(string[] args)
        {
            Console.WriteLine("Main started");

            try //this wont work for async void methods
            {
                await DelayAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //AsyncMethod();

            Console.ReadKey(); //so the program doesnt finish too quickly
        }

        

        private static async void AsyncMethod()
        {
            Console.WriteLine("Async method");
            // Async method

            for (int a = 0; a < 50; a++)
            {
                var task = Task.Run(() => {Method();}
                );

                tasks.Add(task);
            }        

            for (int b = 0; b < 3; b++)
            {
                Console.WriteLine(b);
            }

            Console.WriteLine("Task.WhenAny");
            await Task.WhenAny(tasks);
            Console.WriteLine("Async method end");

        }

        private static async Task DelayAsync()
        {
            Console.WriteLine("Start delay");
            await Task.Delay(1000);

            throw new Exception("Exception in DelayAsync");
            Console.WriteLine("End delay");

        }

        private static int Method()
        {
           Console.WriteLine("Task running! " + count);
           count++;
           return 0;
        }

    }


}