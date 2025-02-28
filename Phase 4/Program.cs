//phase 4
class Program
{
    static void Main()
    {
        BankAccount account1 = new BankAccount(0001, 10000m);
        BankAccount account2 = new BankAccount(0002, 10000m);
        
        List<Thread> threads = new List<Thread>();

        Console.WriteLine($"Initial balance of account 1 is {account1.Balance}");
        Console.WriteLine($"Initial balance of account 2 is {account2.Balance}");
        

        threads.Add(new Thread(() => Bank.transfer(account1, account2, 1000m)));
        threads.Add(new Thread(() => Bank.transfer(account2, account1, 2000m)));
        

        Console.WriteLine("Starting threads");
        foreach (Thread t in threads)
        {
            t.Start();
        }
        foreach (Thread t in threads)
        {
            t.Join();
        }

        Console.WriteLine($"account 1 balance after transfer attempt: {account1.Balance}");
        Console.WriteLine($"account 2 balance after transfer attempt: {account2.Balance}");
        
    }
}