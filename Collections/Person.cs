namespace Collections
{
    class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Person(string name, string lastName, DateTime dateOfBirth) {
            Name = name;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }
    }
}
