using System.Collections.Generic;
using System;
using System.Data;
using MySql.Data.MySqlClient;

    public class AdminWalletTable
{
    private static List<AdminWallet> userwall = new List<AdminWallet>();
    private static string ConnectionStringWithoutDB = "Server = localhost; User=root; password=Oxygen07;";
    private static string ConnectionString = "Server = localhost; User = root; database=BakeryAppBase1; password=Oxygen07;";


 public static void CreateAdminWalletTable()
   {
      string query = "create table if not exists BakeryAppBase1.AdminWallet(Product_Id int primary Key not null auto_increment , AccountNumber varchar(255) not null, Balance decimal (25 , 2) not null);";
        try
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                Console.WriteLine("Product table created successfully.");
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("An error occurred while creating the table: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
    }



    public static void CreateAdminWallet(AdminWallet wallet)
   {
        string accountNumber = "00112233";
        string pin = "12345";
        decimal balance = 0.00m;
        var accounts = new AdminWallet(accountNumber, balance, pin);
        userwall.Add(accounts);
        using(MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
      connection.Open();
      MySqlCommand insert =  new MySqlCommand($"insert into Wallet(AccountNumber,Balance) values ('{wallet.AccountNumber = "00112233"}',  '{wallet.Balance = balance}');" , connection);
       var execute = insert.ExecuteNonQuery();
       if(execute == 0)
       {
        Console.WriteLine("User Created Succesfully");
       }
       else
       {
        Console.WriteLine("Unable To Create User");
       }
    }
   }


public static void CheckAdminbalance(AdminWallet adminWallet , Wallet wallet)
   {
            if(adminWallet.AccountNumber == "00112233" && adminWallet.AccountHolder == "admin123@gmail.com")
            { 
                        wallet.Balance += wallet.Amount;
                        Console.WriteLine($"Your current balance is {adminWallet.Balance}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Pin");
                        return;
                        
                    }
           
            }


       
      

        public static void Transfer(Wallet wallet , User user, AdminWallet adminWallet)
   {
        Console.Write("Enter account number: ");
        string accountNumber = Console.ReadLine();
        //check the account
        foreach(var account in userwall)
        {
            //  var account = Convert(accounts.ToString());
            //check if the account exist and the user is the owner of the account
            if(account.AccountNumber == accountNumber && account.AccountHolder == user.Email)
            { 
                if(account.AccountStatus == "Active")
                {
                    Console.Write("Enter amount to be transferred : ");
                    decimal amount = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter pin : ");
                    string pin = Console.ReadLine();
                    if(amount <= adminWallet.Balance && account.Pin == pin)
                    {
                        adminWallet.Balance -= amount;
                        Console.WriteLine("Transfer successful.");
                        return;
                    }
                     else if (amount > adminWallet.Balance && account.Pin == pin)
                    {
                        Console.WriteLine("Please fund your wallet before making a traansfer");
                        return ;
                    }
                    else 
                    {
                        Console.WriteLine("Invalid Pin");
                        return;
                    }
                   
                }
                else
                {
                    Console.WriteLine("Account is InActive. Transaction can not be completed");
                    return;
                }
            }
        }
        Console.WriteLine("Account is invalid!");
        using(MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
      connection.Open();
      MySqlCommand insert =  new MySqlCommand($"insert into AdminWallet(AccountNumber) values ('{wallet.AccountNumber = accountNumber}',  '{adminWallet.Balance}');" , connection);
       var execute = insert.ExecuteNonQuery();
       if(execute == 0)
       {
        Console.WriteLine("User Created Succesfully");
       }
       else
       {
        Console.WriteLine("Unable To Create User");
       }
    }
     
   }  



}
               
    
