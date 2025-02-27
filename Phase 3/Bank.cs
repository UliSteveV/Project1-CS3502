class Bank{

    /// <summary>
    /// Transfer money from one account to another
    /// This method is not thread safe
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="amount"></param>
    public static void Transfer(BankAccount from, BankAccount to, decimal amount){
        lock(from.GetLock())
        {
            Thread.Sleep(100);
            lock(to.GetLock())
            {
                if(from.Withdraw(amount)){
                    to.Deposit(amount);
                    Console.WriteLine($"Transfer of {amount} from Account {from.Id} to Account {to.Id} complete");
                }
            }
        }
    }

    /// <summary>
    /// This method detects deadlocks and aborts the transfer if a deadlock is detected
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="amount"></param>

    public static void transferWithDetection(BankAccount from, BankAccount to, decimal amount){
        object firstLock = from.GetLock();
        object secondLock = to.GetLock();

        bool acquiredFirstLock = false, acquiredSecondLock = false;
        try{
            acquiredFirstLock = Monitor.TryEnter(firstLock);
            if(!acquiredFirstLock){
                Console.WriteLine("Failed to acquire first lock, aborting transfer");
                return;
            }
            

            Thread.Sleep(100);

            acquiredSecondLock = Monitor.TryEnter(secondLock);
            if(!acquiredSecondLock){
                Console.WriteLine("Failed to acquire second lock, aborting transfer");
                return;
            }

            if(from.Withdraw(amount)){
                to.Deposit(amount);
                Console.WriteLine($"Transfer of {amount} from Account {from.Id} to Account {to.Id} complete");
            }
        }
        finally{
            if(acquiredFirstLock) Monitor.Exit(firstLock);
            if(acquiredSecondLock) Monitor.Exit(secondLock);
        }
    }
}