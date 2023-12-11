// using Prototype;
//
// var manager = new Manager("Cindy");
// Manager managerClone = (Manager)manager.Clone(); // We need to cast this to a Manager because the CLone method is defined on the abstract base class Person, so returns a Person
//
// Console.WriteLine($"Manager was cloned: {managerClone.Name}");
//
// var employee = new Employee("Kevin", manager);
// var employeeClone = (Employee)employee.Clone(true);
//
// Console.WriteLine($"Employee was cloned: {employeeClone.Name}," +
//                   $" with manager {employeeClone.Manager.Name}");
//                   
// managerClone.Name = "Karen";
// Console.WriteLine($"Employee was cloned: {employeeClone.Name}," +
//                   $" with manager {employeeClone.Manager.Name}");

using Prototype;

// var initialDog = new Terrier(1, "hello");
// var shallowDog = initialDog;
//
// initialDog.ReferenceType = "Goodbye";
//
// Console.WriteLine("First Dog reference type: " + initialDog.ReferenceType);
// Console.WriteLine("Shallow Dog reference type: " + shallowDog.ReferenceType);

var initialDog = new Terrier(1, "hello");
var shallowDog = initialDog;

initialDog.ReferenceType = "Goodbye";

Console.WriteLine("First Dog reference type: " + initialDog.ReferenceType);
Console.WriteLine("Shallow Dog reference type: " + shallowDog.ReferenceType);

// var deepDog = (Terrier)initialDog.Clone(true);
// var shallowDog = (Terrier)initialDog.Clone(false);
//
// Console.WriteLine("First Dog value type: " + initialDog.ValueType);
// Console.WriteLine("Deep Dog value type: " + deepDog.ValueType);
// Console.WriteLine("Shallow Dog value type: " + shallowDog.ValueType);
//
// initialDog.ValueType = 2;
//
// Console.WriteLine("First Dog value type: " + initialDog.ValueType);
// Console.WriteLine("Deep Dog value type: " + deepDog.ValueType);
// Console.WriteLine("Shallow Dog value type: " + shallowDog.ValueType);
//
//
// Console.WriteLine("First Dog reference type: " + initialDog.ReferenceType);
// Console.WriteLine("Deep Dog reference type: " + deepDog.ReferenceType);
// Console.WriteLine("Shallow Dog reference type: " + shallowDog.ReferenceType);
//
// initialDog.ReferenceType = "goodbye";
//
// Console.WriteLine("First Dog reference type: " + initialDog.ReferenceType);
// Console.WriteLine("Deep Dog reference type: " + deepDog.ReferenceType);
// Console.WriteLine("Shallow Dog reference type: " + shallowDog.ReferenceType);