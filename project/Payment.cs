using System.Collections.Generic;
using System;
using System.Data;
using MySql.Data.MySqlClient;

public class Payment
{
    public string AccountNumber { get; private set; }
    public decimal Balance { get; private set; }
    
    public Payment()
    {}

    public Payment(string accountNumber, decimal intialBalance)
    {
        AccountNumber = accountNumber;
        Balance = intialBalance;
        var act = new Payment(accountNumber , intialBalance);
        
    }

    public bool Credit()
    {
        Console.WriteLine("Enter amount");
        decimal amount = decimal.Parse(Console.ReadLine());
        if (amount <= 0) 
        {
            return false;
        }
        Balance += amount;
        return true;
    }

    public bool Debit()
    {
         Console.WriteLine("Enter amount");
        decimal amount = decimal.Parse(Console.ReadLine());
        if (amount <= 0 || amount > Balance)
        {
            return false;
        } 
        Balance -= amount;
        return true;
    }
}

// public class Bank
// {
//     public static bool Transfer(Account sender, Account receiver, decimal amount)
//     {
//         if (sender.amount)
//         {
//             receiver.Credit(amount);
//             return true;
//         }
//         return false;
//     }
// }


