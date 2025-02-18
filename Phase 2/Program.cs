using System;
using System.Collections.Generic;
using System.Threading;

class Program {
    static void Main() {
        BankAccount account = new BankAccount(100.00m);
        List<Thread> threads = new List<Thread>();
        Console.WriteLine($"Initial balance is {account.Balance}");

        for(int i = 0; i < 10; i++){
            threads.Add(new Thread(() => account.Deposit(100.50m)));
            threads.Add(new Thread(() => account.withdraw(50.25m)));
        }

        foreach(Thread thread in threads){
            thread.Start();
        }
        
        foreach(Thread thread in threads){
            thread.Join();
        }

        Console.WriteLine($"Final balance is {account.Balance}");
    }
}
