using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace Prototype
{
    /// <summary>
    /// Prototype 
    /// </summary>
    public abstract class Person
    // declares an interface for cloning itself
    {
        public abstract string Name { get; set; }
        public abstract Person Clone(bool deepClone);
    }

    public class Manager : Person
    {
        public override string Name { get; set; }

        public Manager(string name)
        {
            Name = name;
        }
        
        public override Person Clone(bool deepClone = false)
        {
            if (deepClone)
            {
                var objectAsJson = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Employee>(objectAsJson); // Deep Copy
            }
            
            return (Person)MemberwiseClone(); // Shallow Copy
        }
    }
    
    public class Employee : Person
    {
        public Manager Manager { get; set; }
        public override string Name { get; set; }

        public Employee(string name, Manager manager)
        {
            Name = name;
            Manager = manager;
        }
        
        public override Person Clone(bool deepClone = false)
        {
            if (deepClone)
            {
                var objectAsJson = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Employee>(objectAsJson);
            }
            return (Person)MemberwiseClone();
        }
    }


    public abstract class Dog
    {
        public int ValueType { get; set; }
        
        public string ReferenceType { get; set; }

        public abstract Dog Clone(bool deepClone);
    }

    public class Terrier : Dog
    {
        public Terrier(int i, string s)
        {
            ValueType = i;
            ReferenceType = s;
        }

        public override Dog Clone(bool deepClone)
        {
            if (deepClone)
            {
                var objectAsJson = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Terrier>(objectAsJson); // Deep Copy
            }
            
            return (Terrier)MemberwiseClone(); // Shallow Copy
        }
    }
}