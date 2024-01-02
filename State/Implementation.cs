namespace State;

/// <summary>
/// State
/// </summary>
public abstract class BankAccountState
{
    public BankAccount BankAccount { get; protected set; } = null!;
    public decimal Balance { get; protected set;  }
    public abstract void Deposit(decimal amount);
    public abstract void Withdraw(decimal amount);
}

/// <summary>
/// ConcreteState
/// </summary>
public class RegularState : BankAccountState
{
    public RegularState(decimal balance, BankAccount bankAccount)
    {
        Balance = balance;
        BankAccount = bankAccount;
    }

    public override void Deposit(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, depositing {amount}");
        Balance += amount;

        if (Balance > 1000)
        {
            BankAccount.BankAccountState = new GoldState(Balance, BankAccount);
        }
    }

    public override void Withdraw(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, withdrawing {amount} from {Balance}");
        
        Balance -= amount;
        
        if (Balance < 0)
        {
            BankAccount.BankAccountState = new OverdrawnState(Balance, BankAccount);
        }
    }
}

/// <summary>
/// ConcreteState
/// </summary>
public class OverdrawnState : BankAccountState
{
    public OverdrawnState(decimal balance, BankAccount bankAccount)
    {
        Balance = balance;
        BankAccount = bankAccount;
    }

    public override void Deposit(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, depositing {amount}");
        Balance += amount;
        if (Balance > 0)
        {
            BankAccount.BankAccountState = new RegularState(Balance, BankAccount);
        }
    }

    public override void Withdraw(decimal amount)
    { 
        Console.WriteLine($"In {GetType()}, cannot withdraw, balance is {Balance}");
    }
}

/// <summary>
/// ConcreteState
/// </summary>
public class GoldState : BankAccountState
{
    public GoldState(decimal balance, BankAccount bankAccount)
    {
        Balance = balance;
        BankAccount = bankAccount;
    }

    public override void Deposit(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, depositing {amount} " +
                          $"{amount} + 10% bonus: {amount / 10}");
        
        Balance += amount + (amount / 10);
    }

    public override void Withdraw(decimal amount)
    { 
        Console.WriteLine($"In {GetType()}, withdrawing {amount}, balance is {Balance}");
        Balance -= amount;
        
        if (Balance < 1000 && Balance >= 0)
        {
            Console.WriteLine($"In {GetType()}, balance is {Balance} so setting state to {typeof(RegularState)}");
            BankAccount.BankAccountState = new RegularState(Balance, BankAccount);
        }
        else if (Balance < 0)
        {
            Console.WriteLine($"In {GetType()}, balance is {Balance} so setting state to {typeof(OverdrawnState)}");
            BankAccount.BankAccountState = new OverdrawnState(Balance, BankAccount);
        }
    }
}

/// <summary>
/// Context
/// </summary>
public class BankAccount
{
    public BankAccountState BankAccountState { get; set; }
    
    public decimal Balance { get { return BankAccountState.Balance; } }
    
    public BankAccount()
    {
        // Here, we set the initial state.
        // By passing in an instance of itself into the state, we allow the state to change the state of the context in which it sits.
        BankAccountState = new RegularState(200, this);
    }
    
    /// <summary>
    /// Request a deposit.
    /// </summary>
    /// <param name="amount"></param>
    public void Deposit(decimal amount)
    {
        // Let the current state handle the deposit.
        BankAccountState.Deposit(amount);
    }
    
    /// <summary>
    /// Request a withdrawal.
    /// </summary>
    /// <param name="amount"></param>
    public void Withdrawal(decimal amount)
    {
        // Let the current state handle the withdrawal.
        BankAccountState.Withdraw(amount);
    }
}
