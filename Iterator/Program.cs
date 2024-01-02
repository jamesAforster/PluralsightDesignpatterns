// See https://aka.ms/new-console-template for more information

using Iterator;

Console.WriteLine("Hello, World!");

// create the collection
PeopleCollection people = new PeopleCollection();

people.Add(new Person("Kevin Dockx", "Belgium"));
people.Add(new Person("Gill Cleeren", "Belgium"));
people.Add(new Person("Roland Guijt", "The Netherlands"));
people.Add(new Person("Thomas Claudius Huber", "Germany"));

var peopleIterator = people.CreateIterator();

// use the iterator to run through the people in the collection; they should come out in alphabetical order
for (Person person = peopleIterator.First(); !peopleIterator.IsDone; person = peopleIterator.Next())
{
    Console.WriteLine(person?.Name);
}
