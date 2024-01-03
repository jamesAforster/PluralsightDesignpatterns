namespace Visitor;

/// <summary>
/// ConcreteElement
/// </summary>
public class Customer : IElement
{
    public string Name { get; set; }
    public decimal AmountOrdered { get; private set; }
    public decimal Discount { get; set; }

    public Customer(string name, decimal amountOrdered)
    {
        Name = name;
        AmountOrdered = amountOrdered;
    }

    public void Accept(IVisitor visitor)
    {
        // visitor.VisitCustomer(this);
        visitor.Visit(this);
        Console.WriteLine($"Visited {nameof(Customer)} {Name}, discount given: {Discount}");
    }
}

/// <summary>
/// ConcreteElement
/// </summary>
public class Employee : IElement
{
    public string Name { get; set; }
    public int YearsEmployed { get; private set; }
    public decimal Discount { get; set; }

    public Employee(string name, int yearsEmployed)
    {
        Name = name;
        YearsEmployed = yearsEmployed;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this); // here, the concrete element calls the visitor, the concrete element is the client of the visitor
        Console.WriteLine($"Visited {nameof(Employee)} {Name}, discount given: {Discount}");
    }
}

// /// <summary>
// /// Visitor
// /// </summary>
// public interface IVisitor
// {
//     void VisitCustomer(Customer customer);
//     void VisitEmployee(Employee employee);
// }

/// <summary>
/// Visitor (alternative)
/// </summary>
public interface IVisitor
{
    void Visit(IElement element);
}

/// <summary>
/// ConcreteVisitor
/// </summary>
public class DiscountVisitor : IVisitor
{
    public decimal TotalDiscountGiven { get; set; }
    
    private void VisitCustomer(Customer customer)
    {
        var discount = customer.AmountOrdered / 10;
        customer.Discount = discount;
        TotalDiscountGiven += discount;
    }

    private void VisitEmployee(Employee employee)
    {
        var discount = employee.YearsEmployed < 10 ? 100 : 200;
        employee.Discount = discount;
        TotalDiscountGiven += discount;
    }

    public void Visit(IElement element)
    {
        if (element is Customer)
        {
            VisitCustomer((Customer)element);
        }
        else if (element is Employee)
        {
            VisitEmployee((Employee)element);
        }
    }
}

public class Container // All this class does is wrap the elements so we can iterate over them using the visitor
{
    public List<Employee> Employees { get; set; } = new();
    public List<Customer> Customers { get; set; } = new();

    public void Accept(IVisitor visitor)
    {
        foreach (var employee in Employees)
        {
            employee.Accept(visitor);
        }

        foreach (var customer in Customers)
        {
            customer.Accept(visitor);
        }
    }
}

/// <summary>
/// Element
/// </summary>
public interface IElement
{
    void Accept(IVisitor visitor);
}
