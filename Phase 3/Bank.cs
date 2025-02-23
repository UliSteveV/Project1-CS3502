class Bank{
    public static void Transfer(BankAccount from, BankAccount to, decimal amount){
        lock(from.GetLock())
        {
            Thread.Sleep(100);
            lock(to.GetLock())
            {
                if(from.Withdraw(amount)){
                    to.Deposit(amount);
                    Console.WriteLine();
                }
            }
        }
    }
}