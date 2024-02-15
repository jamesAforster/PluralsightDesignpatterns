using Prototype;

// Shallow Copy
// This will copy strings, ints, characaters - primitive values
// It will not copy COMPLEX values, like Name

Name name = new Name("Dan", "Smith");

Person person = new Person(name);
Person personClone = person.Clone(true);

name.FirstName = "Laura";

Console.WriteLine($"Original person: {person.Name.FirstName}"); // Original person: Laura
Console.WriteLine($"Person was cloned: {personClone.Name.FirstName}"); // Manager was cloned: Laura


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

