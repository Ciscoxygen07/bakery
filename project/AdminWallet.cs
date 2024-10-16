using System.Collections.Generic;
using System;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;

public class AdminWallet
{
     
//    public static List<AdminWallet> account = new List<AdminWallet>(); 
    // public  decimal Amount { get; set; }
    public string AccountNumber { get; set; }
    public decimal Amount { get; set; } 
    public DateAndTime dateAndTime{ get; set; }
    // public string AccountName { get; set; }
    public decimal Balance { get;  set; }
   
    public string AccountStatus { get; set; }
    public string AccountHolder { get; set; }
    public string Pin {get; set;}
    // public string TransactionNarration { get; set;}
    
    public AdminWallet()
    {
        
    }

    public AdminWallet(string accountNumber,decimal balance  ,string pin)
    {
        AccountNumber = accountNumber;
        // Amount = amount;
        Balance = 0.00m;
        dateAndTime = dateAndTime;
        AccountStatus = "Active";
        Pin = pin;
        // TransactionNarration = transactionNarration;
    }

    public override string ToString ()
{
    return $"{AccountNumber}\t\t{Balance}\t{Amount}\t{Pin}";
}
}
