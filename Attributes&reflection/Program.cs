
using System.Reflection;

namespace reflection
{
    class Program
    {
        static void Display(object obj)
        {
            Type objType = obj.GetType();

            var properties = objType.GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(obj);

                var propertyType = value.GetType();

                if (propertyType.IsPrimitive || propertyType == typeof(string))
                {

                    var displayProp = property.GetCustomAttribute<DisplayPropertyAttribute>();

                    if (displayProp != null)
                    {
                        Console.WriteLine($"{displayProp.DisplayName}: {value}");
                    }
                    else
                    {
                        Console.WriteLine($"{property.Name}: {value}");
                    }
                
                }
            
            }
        }

       
        static void Main(string[] args)
        {
            Address address = new Address()
            {
                City = "New York",
                PostalCode = "10001",
                Street = "123 Main Street"  
            };
            
            Person person = new Person()
            {
                FirstName = "John",
                LastName = "Doe",
                Address = address
            };

            Display(person);
            Console.WriteLine("-------------------------");
            Display(address);


            Console.WriteLine("Insert person property to update: ");
            var propertyToUpdate = Console.ReadLine();
            Console.WriteLine("Insert value: ");
            var valueToUpdate = Console.ReadLine();

            SetValue(person, propertyToUpdate, valueToUpdate);
            Display(person);

        }

        static void SetValue<T>(T obj, string propName, string value)
        {
            Type objType = typeof(T);

            var propertyToUpdate = objType.GetProperty(propName);

            if(propertyToUpdate is not null)
            {
                propertyToUpdate.SetValue(obj, value);
            }
        }
    }



}