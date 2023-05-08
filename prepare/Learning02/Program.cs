using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Person p1 = new Person();
        p1._firstName = "Mary";
        p1._lastName = "Smith";
        p1._age = 25;

        var p2 = new Person();
        p2._firstName = "John";
        p2._lastName = "Watkins";
        p2._age = 30;

        List<Person> people = new List<Person>();
        people.Add(p1);
        people.Add(p2);

        foreach (person p in people)
        {
            Console.WriteLine(p._firstname);
        }
}