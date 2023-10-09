// define class/ define type

namespace ConsoleApp2.Models
{
    /// <summary>
    /// shape representing a person
    /// <usage>
    /// Person p = new Person();
    /// </usage>
    /// </summary>
    public abstract class Person
    {
        public abstract int AbstractMethod();

        // cannot be used on an instance
        public static void StaticMethod()
        { }
        // can only be used on a type
        public virtual void NonStaticMethod()
        {
            Console.WriteLine("NonStaticMethod called from Person");
        }

        // constructor overloading
        public Person(string name) // constructor with one argument
        {
            Name = name;
        }

        // Cannot overload with the same parameter types
        //public Person(string phone)
        //{
        //    this.phone = phone;
        //}
        public Person(string name, string email) // constructor with two arguments
        {
            Name = name;
            Email = email;
        }

        ~Person()
        {
            Console.WriteLine("This object is being destroyed");
        }

        private string phone; // Field

        public string Phone { get => phone; set => phone = value; } // Property

        public int Id { get; private set; }

        public string Name { get; set; }
        public string Email { get; set; }
    }
}

// Encapsulation, hide internal state

// static
// Access Modifier: private (accesible with the class), internal (accessible within the same assembly), public, protected (accessible to inheriting type)



