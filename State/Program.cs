using State;

Console.Title = "State";

BankAccount bankAccount = new BankAccount();
bankAccount.Deposit(100);
bankAccount.Withdrawal(500);
bankAccount.Withdrawal(100);

// go gold
bankAccount.Deposit(2000);
// still in gold state
bankAccount.Deposit(100);
// back to overdrawn
bankAccount.Withdrawal(3000);
// should transition to regular
bankAccount.Deposit(3000);
// should still be in regular
bankAccount.Deposit(100);


Console.ReadKey();
