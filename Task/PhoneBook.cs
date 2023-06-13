using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class PhoneBook
    {
        private List<Contact> phoneBook;
    
    public PhoneBook() { 
        phoneBook = new List<Contact>();
        }

    public void DisplayAllContacts()
        {
            Console.WriteLine("The phone book contains: "+ phoneBook.Count + " elements.");
            phoneBook.ForEach(contact => { Console.WriteLine(contact.Name + " " + contact.PhoneNumber);});
        }
    public void AddContact(string name, int phoneNumber)
        {
            Contact contact = new Contact(name, phoneNumber);
            phoneBook.Add(contact);           
        }
        public List<Contact>? SearchByNumber(int phoneNumber)
        {
            List<Contact>? contacts = phoneBook.Where(c => c.PhoneNumber.Equals(phoneNumber)).ToList();

            if (contacts is not null)
            {
                return contacts;
            }
            else
            {
                Console.WriteLine("The contact is not present in the phone book!");
                return null;
            }
        }

        public List<Contact>? SearchByName(string name)
        {
            List<Contact>? contacts = phoneBook.Where(c => c.Name.Equals(name)).ToList();

            if (contacts is not null)
            {
                return contacts;
            }
            else
            {
                Console.WriteLine("The contact is not present in the phone book!");
                return null;
            }
        }
    }
}
