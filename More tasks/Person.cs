using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_tasks
{
    class Person
    {

        private string name = "def";
        private string lastName = "def";

        public static int count = 0;
        DateTime dateOfBirth;

        private string? ContactNumber { get;set;}

        public Person() { count++; }
        public Person(string name, string lastName) {

            this.name = name;
            this.lastName = lastName;
            count++;
        }
        public DateTime DateOfBirth {

            get{return this.dateOfBirth;}
            set{dateOfBirth = value; }

            }


       public string Name { get { return name; } set { name = value; } }
       public string GetLastName() => lastName;

    }
}
