using System;
using System.Collections.Generic;
using System.Threading;


class Program{
    static void Main(){
        BankAccount account1 = new BankAccount(0001, 1000m);
        BankAccount account2 = new BankAccount(0002, 500m);
        List<Thread> threads = new List<Thread>();
        List<Thread> threads2 = new List<Thread>();

        Console.WriteLine($"Initial balance of account 1 is {account1.Balance}");
        Console.WriteLine($"Initial balance of account 2 is {account2.Balance}");

        threads.Add(new Thread(() => Bank.Transfer(account1, account2, 100m)));
        threads.Add(new Thread(() => Bank.Transfer(account2, account1, 200m)));

        foreach(Thread t in threads){
            t.Start();
        }

        foreach(Thread t in threads){
            t.Join();
        }

        Console.WriteLine($"Account 2 balance after transfer attempt: {account2.Balance}");
        Console.WriteLine($"Account 1 balance after transfer attempt: {account1.Balance}");
        

        Console.WriteLine($"Initial balance of account 1 is {account1.Balance}");
        Console.WriteLine($"Initial balance of account 2 is {account2.Balance}");

        threads2.Add(new Thread(() => Bank.transferWithDetection(account1, account2, 100m)));
        threads2.Add(new Thread(() => Bank.transferWithDetection(account1, account2, 200m)));

        foreach(Thread t in threads2){
            t.Start();
        }

        foreach(Thread t in threads2){
            t.Join();
        }

        Console.WriteLine($"Account 1 balance after transfer attempt: {account1.Balance}");
        Console.WriteLine($"Account 2 balance after transfer attempt: {account2.Balance}");
        
    }
}
