class BankAccount{
    private object balancelock = new object();
    public double Balance {get;  set;}

    public BankAccount(int initialBalance){
        Balance = initialBalance;
    }

    public void Deposit(int amount){
        
        lock(balancelock){
            Balance += amount;
            Console.WriteLine($"Deposited {amount}, balance is now {Balance}");
        }
        
        Balance += amount;
        Console.WriteLine($"Deposited {amount}, balance is now {Balance}");
    }

    public void withdraw(int amount){
        lock(balancelock){
            if(Balance >= amount){
                Balance -= amount;
                Console.WriteLine($"Withdrawn {amount}, balance is now {Balance}");
            }
            else{
                Console.WriteLine($"Sorry, not enough funds to withdraw {amount}");
            }
            
        }
    }

}