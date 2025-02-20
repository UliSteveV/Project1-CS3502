class BankAccount{
    private object balancelock = new object();
    public decimal Balance {get;  set;}

    public BankAccount(decimal initialBalance){
        Balance = initialBalance;
    }

    public void Deposit(decimal amount){
        //lock to protect the balance variable
        //don't know if this was required for phase
        //however it did say to practice good thread safety so I
        //included simple locks
        lock(balancelock){
            Balance += amount;
            Console.WriteLine($"Deposited {amount}, balance is now {Balance}");
        }
    }

    public void withdraw(decimal amount){
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