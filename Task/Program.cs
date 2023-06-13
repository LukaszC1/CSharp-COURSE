

namespace Task
{
    class Program
    {
        

        static void Main(string[] args)
        {
          
            PhoneBook phoneBook = new PhoneBook();


            //Test data
            phoneBook.AddContact("John Smith", 799999991);
            phoneBook.AddContact("John Smith", 799999991);
            phoneBook.AddContact("John Smith", 799999991);
            phoneBook.AddContact("John Smith", 799999991);
            phoneBook.AddContact("John Smith", 799999991);
            phoneBook.AddContact("John Wick", 799999991);

            phoneBook.DisplayAllContacts();

            Console.WriteLine("Search result: ");
            List<Contact> searchList = phoneBook.SearchByName("John Smith");

            if (searchList is not null) 
            searchList.ForEach(x=>Console.WriteLine(x.Name + " " + x.PhoneNumber));
            ///////

            bool working = true;       

            while (working)
            {
                Console.WriteLine("1 Add contact");
                Console.WriteLine("2 Display contacts by number");
                Console.WriteLine("3 Display all contacts");
                Console.WriteLine("4 Search contact by name");
                Console.WriteLine("5 Stop");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Enter name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter number: ");
                        int number = int.Parse(Console.ReadLine());
                        phoneBook.AddContact(name, number);
                        break;
                    case "2":
                        Console.WriteLine("Enter number: ");
                        List<Contact>? search = phoneBook.SearchByNumber(int.Parse(Console.ReadLine()));
                        if (search is not null)
                            search.ForEach(x => Console.WriteLine(x.Name + " " + x.PhoneNumber));
                        break;
                    case "3":
                        phoneBook.DisplayAllContacts();
                        break;
                    case "4":
                        Console.WriteLine("Enter name: ");
                        List<Contact>? searchName = phoneBook.SearchByName(Console.ReadLine());
                        if (searchName is not null)
                            searchName.ForEach(x => Console.WriteLine(x.Name + " " + x.PhoneNumber));
                        break;
                    case "5":
                        working = false;
                        break;
                    default:
                        Console.WriteLine("Select correct option!");
                        break;
                }
            }
        }
    
    
    }       
    
    
}


