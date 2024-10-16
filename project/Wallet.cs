using System.Collections.Generic;
using System;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;

public class Wallet
{
     
//  public static List<Wallet> account = new List<Wallet>(); 
    public  decimal Amount { get; set; }
    public string AccountNumber { get; set; }
    public string ReceiverAccountNumber { get; set; }
    public string BVN { get; set; }
    public string NIN { get; set; }
    public DateAndTime dateAndTime{ get; set; }
    // public string AccountName { get; set; }
    public decimal Balance { get;  set; }
   
    public string AccountStatus { get; set; }
    public string AccountHolder { get; set; }
    public string Pin {get; set;}
    // public string TransactionNarration { get; set;}
    
    public Wallet()
    {
        
    }

    public Wallet(string accountNumber,string receiverAccountNumber,decimal balance,string bvn,string nin,string pin)
    {
        AccountNumber = accountNumber;
        ReceiverAccountNumber = receiverAccountNumber;
        Amount = 0.00m;
        BVN = bvn;
        NIN = nin;
        Balance = balance;
        dateAndTime = dateAndTime;
        AccountStatus = "Active";
        Pin = pin;
        // TransactionNarration = transactionNarration;
    }

    public override string ToString ()
{
    return $"{AccountNumber}\t{ReceiverAccountNumber}\t{Balance}\t{BVN}\t{NIN}\t{Pin}";
}
}
