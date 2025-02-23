class BankAccount{
    private readonly object balancelock = new object();
    public decimal Balance {get;  set;}

    public int Id {get; private set;}



    public BankAccount(int id, decimal initialBalance){
        Id = id;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount){
        lock(balancelock){
            Balance += amount;
            Console.WriteLine($"Deposited {amount}, balance is now {Balance}");
        }
    }

    public bool Withdraw(decimal amount){
        lock(balancelock){
            if(Balance >= amount){
                Balance -= amount;
                Console.WriteLine($"Withdrawn {amount}, balance is now {Balance}");
                return true;
            }
            Console.WriteLine($"Account {Id}: Withdrawal of {amount} failed due to insufficient funds");
            return false;
            
        }
    }

    public object GetLock(){
        return balancelock;
    }

}