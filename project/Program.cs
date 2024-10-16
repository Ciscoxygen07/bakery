using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Transactions;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
        
                                   
                                  
        // BakeryAppManager1.CreateDataBase();
            // UserTable.CreateUserTable1();
            // AdminWalletTable.CreateAdminWalletTable();
            // ProductTable.CreateProductTable1();
            //  WalletTable.CreateUserWalletTable();
            //   OrderTable.CreateOrderTable1();
            // AdminTable.CreateAdminTable1();
            User userManager = new User();
            Admin amnManager = new Admin();
            Payment transactionManager = new Payment();
            Product product= new Product();
             AdminWallet adminWallet= new  AdminWallet();
            Wallet wallet= new Wallet();
                                      

                    //  UserTable.CreateUser(userManager);
                    // CartTable.CreateCartTable1();
                    // CartItemTable.CreateCartItemTable();

            bool running = true;

            while (running)
            {
               
                // Console.Clear();
                Console.WriteLine("Welcome to MY BAKING APP");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                ProductTable.GetAllProducts(product , wallet);
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                Console.WriteLine("1. REGISTER");
                Console.WriteLine("2. LOGIN");
                Console.WriteLine("3. LOGIN AS ADMIN");
                Console.WriteLine("4. EXIT");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");

                Console.Write("Choose an option  ==> ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                     UserTable.CreateUser(userManager);
                       break;
                        case "3":
                        var man = AdminTable.AdminLog(amnManager) ;
                        if (true)
                        {
                            bool ami = true;
                            while (ami)
                            {
                            Console.WriteLine("--------------------------------------------------------------------------------------------------");
                            Console.WriteLine("1. ADD ITEMS");
                            Console.WriteLine("2. GET ALL ITEMS");
                            Console.WriteLine("3. UPDATE ITEMS");
                            Console.WriteLine("4. REMOVE ITEMS");
                            System.Console.WriteLine(" 5.Wallet");
                            Console.WriteLine("6. EXIT");
                            Console.WriteLine("--------------------------------------------------------------------------------------------------");

                            Console.Write("Choose an option  ==> ");

                            Console.WriteLine("--------------------------------------------------------------------------------------------------");

                            string AdminChoice = Console.ReadLine();
                            switch (AdminChoice)
                            {
                                case "1":
                                ProductTable.CreateProduct(product);
                                break;
                                case "2":
                                ProductTable.GetAllProducts(product , wallet);
                                break;
                                case "3":
                                Console.WriteLine("Enter the item to be updated");
                                int product_Id = int.Parse(Console.ReadLine());
                                ProductTable.UpdateProduct(product, product_Id);
                                break;
                                case "4":
                                ProductTable.DeleteProduct(product);
                                break;

                                case "5":
                                System.Console.WriteLine("1. Create wallet");
                                System.Console.WriteLine("2.Check Balance");
                                System.Console.WriteLine("3.Transfer");

                                System.Console.WriteLine("Choose any number from the  option above");
                                string opti = Console.ReadLine();

                                switch (opti)
                                {
                                    case "1":
                                    AdminWalletTable.CreateAdminWallet(adminWallet);
                                    break;

                                    case "2":
                                    AdminWalletTable.CheckAdminbalance(adminWallet , wallet);
                                    break;

                                    case "3":
                                    AdminWalletTable.Transfer(wallet , userManager , adminWallet);
                                    break;

                                    default:
                                    System.Console.WriteLine("Invalid number");
                                    break;
                                }
                                break;
                                case "6":
                                running = false;
                                break;
                                default:
                                Console.WriteLine("Invalid option.");
                                break;
                            } 
                        }
                    }
                       break;
                       
                    case "2":
                          Console.WriteLine("Enter Your Id number");
                         int id = int.Parse(Console.ReadLine());
                        var loggedInUser = UserTable.LoginUser(id);
                        if (loggedInUser != null )
                        {
                            bool loggedIn = true;
                            while (loggedIn)
                            {
                                Console.WriteLine("Welcome to MY BAKING APP");
                                Console.WriteLine("1. Wallet");
                                Console.WriteLine("2.Place an order");
                                Console.WriteLine("3. Exit");
                                Console.Write("Choose an option  ==>");
                                string loginChoice = Console.ReadLine();
                                switch (loginChoice)
                                {
                                    case "1":
                                    Console.WriteLine("1.Create Wallet");
                                    Console.WriteLine("2.Deposit");
                                    System.Console.WriteLine("3.View Balance");

                                    Console.WriteLine("Choose any option from above");
                                    string opt = Console.ReadLine();

                                    switch (opt)
                                    {
                                        case "1":
                                        WalletTable.CreateWallet(wallet);
                                        break;

                                        case "2":
                                        WalletTable.AddMoney(wallet, userManager);
                                        break;

                                        case "3":
                                        WalletTable.ViewWalletBalance(wallet);
                                        break;

                                        default:
                                        Console.WriteLine("Invalid number");
                                        break;
                                    }
                                    break;

                                    case "2":
                                    ProductTable.GetAllProducts(product , wallet);
                                     Console.WriteLine("Enter Your Id number");
                                     int productId = int.Parse(Console.ReadLine());
                                     ProductTable.Order(productId , wallet);
                                  
                                    break;

                                    case "3":
                                    loggedIn = false;
                                    break;

                                   default:
                                   Console.WriteLine("Invalid number");
                                   break;
                                 }
                            }
                        }
                        break;
                    case "4":
                        running = false;
                        break;
                      default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }



        }
    }
}




