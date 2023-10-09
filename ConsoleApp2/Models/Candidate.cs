namespace ConsoleApp2.Models
{
    public class Candidate : Person
    {
        public Candidate(string name) : base(name)
        {
        }
        public Candidate(string name, string email) : base(name, email)
        {
        }

        public string Location { get; set; }
        public int Experience { get; set; }

        public override void NonStaticMethod()
        {
            Console.WriteLine("NonStaticMethod called from Candidate");
        }
        public bool IsCandidate { get; } = true;

        public override int AbstractMethod()
        {
            Console.WriteLine("Abstract method called from Candidate");
            return 99;
        }
    }

    // Encapsulation, hide internal state

    // static
    // Access Modifier: private (accesible with the class), internal (accessible within the same assembly), public, protected (accessible to inheriting type)



}