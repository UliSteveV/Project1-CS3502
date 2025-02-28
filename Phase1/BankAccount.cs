//phase 1
class BankAccount{
    public decimal Balance {get;  set;}

    /// <summary>
    /// Constructor for BankAccount
    /// </summary>
    /// <param name="initialBalance"></param>
    public BankAccount(decimal initialBalance){
        Balance = initialBalance;
    }

    /// <summary>
    /// Deposit method for BankAccount
    /// </summary>
    /// <param name="amount"></param>
    public void Deposit(decimal amount){
        Balance += amount;
        Console.WriteLine($"Deposited {amount}, balance is now {Balance}");
    }

    /// <summary>
    /// Withdraw method for BankAccount
    /// </summary>
    /// <param name="amount"></param>
    public void withdraw(decimal amount){
        if(Balance >= amount){
            Balance -= amount;
            Console.WriteLine($"Withdrawn {amount}, balance is now {Balance}");
        }
        else{
            Console.WriteLine($"Sorry, not enough funds to withdraw {amount}");
        }
    }

}