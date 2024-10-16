using System.Collections.Generic;
using System;
using System.Data;
using MySql.Data.MySqlClient;

    public class ProductTable
{
    private static List<Product> product1 = new List<Product>();
    private static string ConnectionStringWithoutDB = "Server = localhost; User=root; password=Oxygen07;";
    private static string ConnectionString = "Server = localhost; User = root; database=BakeryAppBase1; password=Oxygen07;";


 public static void CreateProductTable1()
   {
      string query = "create table if not exists BakeryAppBase1.Product(Product_Id int primary Key not null auto_increment , ProductType varchar(255) not null, Price decimal (25 , 2) not null);";
      // string Query = "create table if not exists ProductBakeryAppBase.Product";
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

     public static void CreateProduct(Product product)
   {
       int Count = 0;
        Console.WriteLine ("Enter the amount of product you want to input");
        int input = int.Parse (Console.ReadLine());

        for (int i = 0; i < input; i++)
        {
        Console.WriteLine("Enter the code of bread");
        int code = int.Parse (Console.ReadLine());

        Console.WriteLine ("Enter the price of product");
        decimal price = decimal.Parse (Console.ReadLine()); 

        Console.WriteLine("Enter the size of item");
        string type = Console.ReadLine ().ToUpper();
        
       
        var pro = new Product(code, price, type);
        product1.Add(pro);
        Count++ ;

          Console.WriteLine($"You have successfully added {Count} a products");
          Console.WriteLine();
        using(MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
      connection.Open();
      MySqlCommand insert =  new MySqlCommand($"insert into Product(Price , ProductType) values ( '{product.Price = price }' , '{product.ProductType = type }');" , connection);
       var execute = insert.ExecuteNonQuery();
       if(execute == 0)
       {
        Console.WriteLine("Product added Succesfully");
       }
       else
       {
        Console.WriteLine("Product not created");
       }
    }
        }  
   }

  public  static void UpdateProduct(Product product , int product_id)
   {
    foreach (var item in product1)
                        {
                    if (product_id == product.Product_Id)  
                       {
                        Console.WriteLine("Enter the product Id ");
                       int newcode = int.Parse(Console.ReadLine());
                        
                        
                        Console.WriteLine("Enetr product pice");
                        decimal price = decimal.Parse(Console.ReadLine());

                        Console.WriteLine("Enter product brandname");
                        string newmenu = Console.ReadLine().ToUpper();

                        item.Product_Id = newcode;
                        item.Price = price ;
                        item.ProductType = newmenu ;
                        Console.WriteLine($"Product Name : {item.Product_Id.ToString()}\t  Product Price : {item.Price.ToString()}\t  Product category : {item.ProductType.ToUpper()}\t");

                            break;
 
    }
    using(MySqlConnection connection=new MySqlConnection(ConnectionString))
    {
      connection.Open();
      string query = $"UPDATE BakeryAppBase1.Product SET productType = '{product.ProductType}' , Price = '{product.Price}' where Product_Id = {product.Product_Id}";
      MySqlCommand command = new MySqlCommand(query, connection);
      var execute = command.ExecuteNonQuery(); 
      if (execute > 0)
      {
        Console.WriteLine("product table updated successfully");
      }
      else
      {
        Console.WriteLine("unable to update product ");
      }
    }
   }
   }

   public static Product  GetAllProducts(Product product , Wallet wallet)
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();

            string selectQuery = "SELECT * From BakeryAppBase1.Product ";
            
            using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Products in the database: ");
                    while (reader.Read())
                    {
                    
                    Console.WriteLine($"Product_Id: {reader["Product_Id"]}, ProductType: {reader["ProductType"]}, Price: {reader["Price"]}");
                    }
                    if (reader.Read())
                    {
                      Product use = new Product();
                      use.Product_Id = reader.GetInt32(0);
                       use.ProductType = reader.GetString(1);
                      use.Price = reader.GetDecimal(2);

                      if (reader.Read())
                      {
                        Console.WriteLine("Would you like to order more? yes or no");
                string opt = Console.ReadLine().ToLower();
                if (opt == "yes")
                {
                Console.WriteLine("Enter the code");
                int code = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the quantity");
                int quantity = int.Parse(Console.ReadLine());
                // var products = Convert(items.ToString());
                 if (product.Product_Id == code)
                {
                    
                    decimal subtotal1 = product.Price * quantity;
                    wallet.Amount = wallet.Balance - subtotal1;
                    
                    // Console.WriteLine(items.ToString());
                    Console.WriteLine($"code\t Menu\t Price\t Quantity\t Sub Total\t");
                    Console.WriteLine($"{product.Product_Id} {code}");
                    Console.WriteLine($"Total Amount : {subtotal1}");
                    Console.WriteLine($"{subtotal1} has been deducted from your wallet");
                }  
                      }
                    //   Console.WriteLine($"welcome : {use.FirstName} ");

                    
                      return use;
                }

            }
            }

        }
        return null;
    }
    }

       public static void DeleteProduct(Product product)
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            string query = $"delete from BakeryAppBase1.Product where Product_Id = {product.Product_Id} ;";

            MySqlCommand command = new MySqlCommand(query, connection);
            var execute = command.ExecuteNonQuery();

            if (execute > 0)
            {
                Console.WriteLine("Deleted Successfully.");
            }
            else
            {
                Console.WriteLine("Unable To Delete.");
            }
        }
    }

     public static Product  Order(int product_Id , Wallet wallet)
    {
         using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();

            string selectQuery = $"SELECT Product_Id, ProductType, Price From BakeryAppBase1.Product where Product_Id ={product_Id} ";
            using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Enter the quantity");
                    int quantity = int.Parse(Console.ReadLine());
                   int total =  product_Id * quantity;
                    if (reader.Read())
                    {
                      Product use = new Product();
                      use.Product_Id = reader.GetInt32(0);
                      use.ProductType = reader.GetString(1);
                      use.Price = reader.GetDecimal(2);

                      decimal dds = use.Price * quantity;
                      Console.WriteLine($"The total is : {dds} ");
                      if (dds <= wallet.Balance)
                      {
                        decimal subtotalamt = dds - wallet.Balance;
                        Console.WriteLine($"purchase sucesssfull and {subtotalamt}N has been deducted from your account");
                      }
                      else
                    {
                        Console.WriteLine("insufficient balance Fund your Wallet before  you can make a purchase");
                    }
                      return use;
                    }
                }
            }
        } 
         return null;
    }

}
