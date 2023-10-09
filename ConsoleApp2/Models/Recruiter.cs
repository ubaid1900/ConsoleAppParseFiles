namespace ConsoleApp2.Models
{

    public class Recruiter : Person
    {
        public Recruiter(string name) : base(name)
        {
        }
        public Recruiter(string name, string email) : base(name, email)
        {
        }

        public override int AbstractMethod()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Abstract method called from Recruiter");
            return 100;
        }

        public override void NonStaticMethod()
        {
            Console.WriteLine("NonStaticMethod called from Recruiter");
        }
    }

    // Encapsulation, hide internal state

    // static
    // Access Modifier: private (accesible with the class), internal (accessible within the same assembly), public, protected (accessible to inheriting type)



}