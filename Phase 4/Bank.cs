class Bank{
    
    /// <summary>
    /// Transfer money from one account to another
    /// Uses timeout to avoid deadlocks
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="amount"></param>
    public static void transfer(BankAccount from, BankAccount to, decimal amount){
        //added lock ordering to avoid deadlock
        object firstLock = from.Id < to.Id ? from.GetLock() : to.GetLock();
        object secondLock = from.Id < to.Id ? to.GetLock() : from.GetLock();

        bool acquiredFirstLock = false, acquiredSecondLock = false;
        try{
            //added timeout to avoid deadlock
            acquiredFirstLock = Monitor.TryEnter(firstLock, TimeSpan.FromSeconds(3));
            if(!acquiredFirstLock){
                Console.WriteLine("Failed to acquire first lock");
                return;
            }
            

            Thread.Sleep(2000);
            //added timeout to avoid deadlock
            acquiredSecondLock = Monitor.TryEnter(secondLock, TimeSpan.FromSeconds(3));
            if(!acquiredSecondLock){
                Console.WriteLine("Failed to acquire second lock");
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