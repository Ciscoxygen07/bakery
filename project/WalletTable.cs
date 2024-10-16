using System.Collections.Generic;
using System;
using System.Data;
using MySql.Data.MySqlClient;

    public class WalletTable
{
    private static List<Wallet> userwall = new List<Wallet>();
    private static string ConnectionStringWithoutDB = "Server = localhost; User=root; password=Oxygen07;";
    private static string ConnectionString = "Server = localhost; User = root; database=BakeryAppBase1; password=Oxygen07;";


 public static void CreateUserWalletTable()
   {
      string query = "create table if not exists BakeryAppBase1.Wallet(Wallet_Id int primary Key not null auto_increment , AccountNumber varchar(255) not null, Balance decimal (25 , 2) not null);";
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



    public static void CreateWallet(Wallet wallet)
   {
        string accountNumber = new Random().Next(100000, 999999).ToString();
        Console.WriteLine("Enter BVN: ");
        string bvn = Console.ReadLine();
        string nin = Console.ReadLine();
        Console.WriteLine("Enter PIN: ");
        string pin = Console.ReadLine();
        string receiverAccountNumber = "00112233";
        decimal balance = 0.00m;
        var accounts = new Wallet(accountNumber, receiverAccountNumber , balance, bvn, nin, pin);
        userwall.Add(accounts);
        Console.WriteLine($"Account created successfully. Account Number: {accountNumber} ");
        using(MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
      connection.Open();
      MySqlCommand insert =  new MySqlCommand($"insert into Wallet(AccountNumber,Balance) values ('{wallet.AccountNumber = accountNumber}',  '{wallet.Balance = balance}');" , connection);
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


public static void AddMoney(Wallet wallet , User user)
   {
       Console.Write("Enter account number: ");
        string accountNumber = Console.ReadLine();
         Console.Write("Enter deposit amount: ");
                    decimal amount = decimal.Parse(Console.ReadLine());
                       decimal amt =  wallet.Balance + amount;

        //check the account
        foreach(var account in userwall)
        {
            if(account.AccountNumber == accountNumber && account.AccountHolder == user.Email)
            { 
                if(account.AccountStatus == "Active")
                {
                    Console.Write("Enter pin : ");
                    string pin = Console.ReadLine();
                    if(account.Pin == pin)
                    {
                        amt =  wallet.Balance + amount;
                        Console.WriteLine("Deposit successful.");
                        using(MySqlConnection connection = new MySqlConnection(ConnectionString))
                        {
                            connection.Open();
                            MySqlCommand insert =  new MySqlCommand($"insert into Wallet(AccountNumber, Balance) values ('{wallet.AccountNumber = accountNumber}',  '{wallet.Balance = amt}');" , connection);
                            var execute = insert.ExecuteNonQuery();
                            if(execute == 0)
                            {
                                Console.WriteLine("User Created Succesfully");
                            }
                        }
                        return;

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
        // using(MySqlConnection connection = new MySqlConnection(ConnectionString))
        // {
        //     connection.Open();
        //     MySqlCommand insert =  new MySqlCommand($"insert into Wallet(AccountNumber, Balance) values ('{wallet.AccountNumber = accountNumber}',  '{wallet.Balance = amt}');" , connection);
        //     var execute = insert.ExecuteNonQuery();
        //     if(execute == 0)
        //     {
        //         Console.WriteLine("User Created Succesfully");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Unable To Create User");
        //     }
        // }

    //    using (MySqlConnection connection = new MySqlConnection(ConnectionString))
    //     {
    //         connection.Open();

    //         string selectQuery = $"SELECT AccountNumber, Balance From BakeryAppBase1.Wallet where AccountNumber ={wallet.AccountNumber = accountNumber} ";
    //         using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
    //         {
    //             using (MySqlDataReader reader = command.ExecuteReader())
    //             {
    //                 Console.WriteLine("User in the database: ");
    //                 if (reader.Read())
    //                 {
    //                   Wallet use = new Wallet();
    //                   use.AccountNumber = reader.GetString(0);
    //                    use.Balance = reader.GetDecimal(1);
    //                 //   Console.WriteLine($"welcome : {use} ");
    //                 }
    //             }
    //         }
    //     } 
      
   }

  public static void ViewWalletBalance(Wallet wallet)
        {
            Console.WriteLine($"Current Wallet Balance: ${wallet.Balance}");
        }

        
      public static Wallet  GetUserWallet(int Id)
    {
        
         using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            string selectQuery = $"SELECT Balance FROM Wallet WHERE Wallet_Id = {Id} ";
            using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("User in the database: ");
                    if (reader.Read())
                    {
                      Wallet use = new Wallet();
                      use.Balance = reader.GetDecimal(1);
                      return use;
                    }
                }
            }
        } 
         return null;
    }


    
        public decimal GetBalance(Wallet wallet)
        {
            return wallet.Balance;
        }

}