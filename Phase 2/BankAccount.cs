
class BankAccount{
    private readonly Mutex balancelock = new Mutex();
    public decimal Balance {get;  set;}

    public BankAccount(decimal initialBalance){
        Balance = initialBalance;
    }

    public void Deposit(decimal amount){
        balancelock.WaitOne();
        Console.WriteLine("Acquired Mutex");
        try{
            Balance += amount;
            Console.WriteLine($"Deposited {amount}, balance is now {Balance}");
        }
        finally{
            balancelock.ReleaseMutex();
            Console.WriteLine("Released Mutex");
        }
    }

    public void withdraw(decimal amount){
        balancelock.WaitOne();
        Console.WriteLine("Acquired Mutex");
        try{
            if(Balance >= amount){
                Balance -= amount;
                Console.WriteLine($"Withdrawn {amount}, balance is now {Balance}");
            }
            else{
                Console.WriteLine($"Sorry, not enough funds to withdraw {amount}");
            }
        }
        finally{
            balancelock.ReleaseMutex();
            Console.WriteLine("Released Mutex");
        }
    }

}