using Newtonsoft.Json;

namespace Prototype
{
    public class Person
    {
        public Name Name { get; set; }

        public Person(Name name)
        {
            Name = name;
        }
    
        public Person Clone(bool deepClone = false)
        { 
            if (deepClone)
            {
                var objectAsJson = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Person>(objectAsJson);
            }
        
            return (Person)MemberwiseClone();
        }
    }

    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Name(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }
    }
    
    // /// <summary>
    // /// Prototype 
    // /// </summary>
    // public abstract class Person
    // // declares an interface for cloning itself
    // {
    //     public abstract string Name { get; set; }
    //     public abstract Person Clone(bool deepClone);
    // }
    //
    // public class Manager : Person
    // {
    //     public override string Name { get; set; }
    //
    //     public Manager(string name)
    //     {
    //         Name = name;
    //     }
    //     
    //     public override Person Clone(bool deepClone = false)
    //     {
    //         if (deepClone)
    //         {
    //             var objectAsJson = JsonConvert.SerializeObject(this);
    //             return JsonConvert.DeserializeObject<Employee>(objectAsJson); // Deep Copy
    //         }
    //         
    //         return (Person)MemberwiseClone(); // Shallow Copy
    //     }
    // }
    //
    // public class Employee : Person
    // {
    //     public Manager Manager { get; set; }
    //     public override string Name { get; set; }
    //
    //     public Employee(string name, Manager manager)
    //     {
    //         Name = name;
    //         Manager = manager;
    //     }
    //     
    //     public override Person Clone(bool deepClone = false)
    //     {
    //         if (deepClone)
    //         {
    //             var objectAsJson = JsonConvert.SerializeObject(this);
    //             return JsonConvert.DeserializeObject<Employee>(objectAsJson);
    //         }
    //         return (Person)MemberwiseClone();
    //     }
    // }
}