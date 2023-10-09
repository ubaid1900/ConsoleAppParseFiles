using ConsoleApp2.Models;
using System.Collections;
using System.Diagnostics;
using System.Linq; // Language integrated query

internal class Program
{
    private static void Main(string[] args)
    {
        Person pTom = new Recruiter("Tom");
        //p.Id = 1;
        pTom.Name = "John";
        Console.WriteLine(pTom.Id);
        Console.WriteLine(string.IsNullOrWhiteSpace(pTom.Name) ? "name is null or whitespace" : "name is " + pTom.Name);
        Console.WriteLine(pTom.Phone);
        Console.WriteLine(pTom.Email);
        Console.WriteLine("Done");

        Person pJane = new Candidate("Jane", "Jane@g.com");
        Console.WriteLine(pJane.Id);
        Console.WriteLine(string.IsNullOrWhiteSpace(pJane.Name) ? "name is null or whitespace" : "name is " + pJane.Name);
        Console.WriteLine(pJane.Phone);
        Console.WriteLine(pJane.Email);
        Console.WriteLine("Done");

        Recruiter r1 = new Recruiter("r1");
        Candidate c1 = new Candidate("c1");

        // Recruiter is derived type. Person is base type. A base type can be morphed to a derived type, but not vice versa - POLYMORPHISM
        Person p1 = new Recruiter("r1");
        Person p2 = new Candidate("c1");

        r1.NonStaticMethod();
        c1.NonStaticMethod();
        p1.NonStaticMethod();
        p2.NonStaticMethod();

        r1.AbstractMethod();
        c1.AbstractMethod();
        p1.AbstractMethod();
        p2.AbstractMethod();


        object o1 = p1;
        object o2 = new Stopwatch();

        ArrayList arrayList = new ArrayList();
        arrayList.Add(1);
        object? i = arrayList[0];
        int ii = Convert.ToInt32(i);



        object q1 = Convert.ChangeType(p2, typeof(Candidate)); // boxing: some type to object, unboxing: object to some type
        Candidate? q2 = p2 as Candidate;
        Candidate q3 = (Candidate)p2;


        if (p2 is Candidate cc)
        {
            //Candidate cc = p2 as Candidate;
            Console.WriteLine("Is cc candidate? {0}", cc.IsCandidate);
        }
        else
        {
            Console.WriteLine("p2 is not a candidate.");
        }
        Candidate v = p2 as Candidate;
        if (v == null)
        {
            Console.WriteLine("v is null");
        }
        else
        {
            Console.WriteLine("Is v candidate? {0}", v.IsCandidate);
        }

    }
}

// Encapsulation, hide internal state

// static
// Access Modifier: private (accesible with the class), internal (accessible within the same assembly), public, protected (accessible to inheriting type)



