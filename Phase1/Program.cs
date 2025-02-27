using System;
using System.Collections.Generic;
using System.Threading;


class Program {
    static void Main() {
        BankAccount account = new BankAccount(100.00m);
        List<Thread> threads = new List<Thread>();
        /*bool trueFalse = false;//used to keep the while loop running
        decimal amount = 0;//used to take in the amount to deposit or withdraw
        */
        Console.WriteLine($"Initial balance is {account.Balance}");

        /*while(!trueFalse){
            Console.WriteLine("Enter 1 to deposit, 2 to withdraw, 0 to exit");
            int input = int.Parse(Console.ReadLine());
            if(input == 0){
                trueFalse = true;
                break;
            }
            Console.WriteLine("Enter an amount");
            try{
                amount = int.Parse(Console.ReadLine());
            }
            catch(FormatException){
                Console.WriteLine("Invalid input, try again");
                continue;
            }
            if(input == 1){
                threads.Add(new Thread(() => account.Deposit(amount)));
            }
            else if(input == 2){
                threads.Add(new Thread(() => account.withdraw(amount)));
            }
            else{
                Console.WriteLine("Invalid input, try again");
                continue;
            }
        }*/
        //used for testing

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