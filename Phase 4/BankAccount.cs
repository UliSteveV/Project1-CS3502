//phase 4
class BankAccount{
    private readonly object balancelock = new object();
    public decimal Balance {get;  set;}

    public int Id {get; private set;}


    /// <summary>
    /// Constructor for BankAccount
    /// </summary>
    /// <param name="id"></param>
    /// <param name="initialBalance"></param>
    public BankAccount(int id, decimal initialBalance){
        Id = id;
        Balance = initialBalance;
    }

    /// <summary>
    /// Deposit money into the account
    /// </summary>
    /// <param name="amount"></param>
    public void Deposit(decimal amount){
        lock(balancelock){
            Balance += amount;
            Console.WriteLine($"Deposited {amount}, balance is now {Balance}");
        }
    }


    /// <summary>
    /// Withdraw money from the account
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Get the lock object for the account
    /// </summary>
    /// <returns></returns>
    public object GetLock(){
        return balancelock;
    }

}