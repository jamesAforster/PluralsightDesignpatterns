namespace Command;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

public class Manager : Employee
{
    public List<Employee> Employees { get; set; } = new();
    
    public Manager(int id, string name) : base(id, name)
    {
    }
}

/// <summary>
/// Receiver (interface)
/// </summary>
public interface IEmployeeManagerRepository
{
    void AddEmployee(int managerId, Employee employee);
    void RemoveEmployee(int managerId, Employee employee);
    bool HasEmployee(int managerId, int employeeId);
    void WriteDataStore();
}

/// <summary>
/// In memory database
/// </summary>
public class EmployeeManagerRepository : IEmployeeManagerRepository
{
    private readonly List<Employee> _employees = new();
    private readonly List<Manager> _managers = new List<Manager>()
    {
        new Manager(1, "Katie"), 
        new Manager(2, "Geoff")
    };
    
    public void AddEmployee(int managerId, Employee employee)
    {
        _managers.First(m => m.Id == managerId).Employees.Add(employee);
    }

    public void RemoveEmployee(int managerId, Employee employee)
    {
        _managers.First(m => m.Id == managerId).Employees.Remove(employee);
    }

    public bool HasEmployee(int managerId, int employeeId)
    {
        return _managers
            .First(m => m.Id == managerId).Employees
            .Any(e => e.Id == employeeId);
    }

    public void WriteDataStore()
    {
        foreach (var manager in _managers)
        {
            Console.WriteLine($"Manager:  {manager.Id}, {manager.Name}");
            if (manager.Employees.Any())
            {
                foreach (var employee in manager.Employees)
                {
                    Console.WriteLine($"\tEmployee: {employee.Id}, {employee.Name}");
                }
            }
            else
            {
                Console.WriteLine("\tNo employees");
            }
        }
    }
}

/// <summary>
/// Command (interface)
/// </summary>
public interface ICommand
{
    void Execute();
    bool CanExecute();

    void Undo();
}


/// <summary>
/// Command (concrete)
/// </summary>
public class AddEmployeeToManagerList : ICommand
{ 
    private readonly IEmployeeManagerRepository _employeeManagerRepository;
    private readonly int _managerId;
    private readonly Employee? _employee;
    
    public AddEmployeeToManagerList(
        IEmployeeManagerRepository employeeManagerRepository, 
        int managerId, 
        Employee employee)
    {
        _employeeManagerRepository = employeeManagerRepository;
        _managerId = managerId;
        _employee = employee;
    }
    
    public bool CanExecute()
    {
        if (_employee == null)
        {
            return false;
        }
        
        // employee shouldn't be on the manager's list already
        if (_employeeManagerRepository.HasEmployee(_managerId, _employee.Id))
        {
            return false;
        }

        return true;
    }
    
    public void Execute()
    {
        if (_employee == null)
        {
            return;
        }
        
        _employeeManagerRepository.AddEmployee(_managerId, _employee);
    }
    
    public void Undo()
    {
        if (_employee == null)
        {
            return;
        }
        
        _employeeManagerRepository.RemoveEmployee(_managerId, _employee);
    }
}

/// <summary>
/// Invoker
/// </summary>
public class CommandManager
{
    private readonly Stack<ICommand> _commands = new Stack<ICommand>();
    
    public void Invoke(ICommand command)
    {
        if (command.CanExecute())
        {
            command.Execute();
            _commands.Push(command);
        }
    }

    public void Undo()
    {
        if (_commands.Any())
        {
            _commands.Pop()?.Undo();
        }
    }
    
    public void UndoAll()
    {
        while (_commands.Any())
        {
            _commands.Pop()?.Undo();
        }
    }
}

