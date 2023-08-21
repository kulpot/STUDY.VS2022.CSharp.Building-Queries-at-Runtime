using System;
using System.Linq;
using System.Data.Entity;

//ref link:https://www.youtube.com/watch?v=v0pjG7vXbAQ&list=PLRwVmtr-pp06SlwcsqhreZ2byuozdnPlg&index=10
// ..

class MeContext : DbContext
{
    public MeContext() : base("meConnectionInfo") { }
    public DbSet<Person> People { get; set; }
}

class Person
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}

class MainClass
{
    static void Main()
    {
        var plumber = new MeContext();
        IQueryable<Person> people = plumber.People;

        //var randy = new Random();
        //Func<bool> randomBool = () => randy.Next() % 2 == 0;    // random true or false

        //Console.WriteLine(people);
        //if (randomBool())
        //    people = people.Where(p => p.Age > 30);
        //Console.WriteLine(people);
        //if (randomBool())
        //    people = people.OrderBy(p => p.FirstName);
        //Console.WriteLine(people);

        people = people.Where(p => p.Age > 30);
        people = people.OrderBy(p => p.FirstName);

        var endResult = people.Select(p => p.FirstName);
        var endResultAT = people.Select(p => new { p.FirstName, p.LastName });  // Anonymous type
        Console.WriteLine(endResult);
        Console.WriteLine(endResultAT);


        //var plumber = new MeContext();
        //foreach (Person person in plumber.People.AsEnumerable().Where(p => p.Age > 30))  // deferred execution knowledge
        //    Console.WriteLine(person.FirstName + " " + person.LastName);
    }
}