namespace GenericTypes { 

    class Program
    {
        static void Main(string[] args)
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
        }
    }
}

