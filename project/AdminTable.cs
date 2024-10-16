 using System.Collections.Generic;
using System;
using System.Data;
using MySql.Data.MySqlClient;

public class AdminTable
{
    private static List<Admin> adm = new List<Admin>();
    private static string ConnectionStringWithoutDB = "Server = localhost; User=root; password=Oxygen07;";
    private static string ConnectionString = "Server = localhost; User = root; database=BakeryAppBase1; password=Oxygen07;";


 public static void CreateAdminTable1()
   {
      string query = "create table if not exists BakeryAppBase1.Admin( Admin_Id  INT not null AUTO_INCREMENT PRIMARY KEY, EMAIL VARCHAR(255) NOT NULL , PASSWORD VARCHAR (255) NOT NULL);";
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


 
 public static bool AdminLog(Admin admin)
   {
        Console.Write("Email : ");
        string email = Console.ReadLine();
        Console.Write("Password : ");
        string password = Console.ReadLine();
       foreach (var use in adm)
      {
         if (use.Email == "admin123@gmail.com" && use.Password == "12345")
         {
          //  Console.WriteLine("You have successfully logged in as an admin");
          return true;
            
         }
      }
     
     using(MySqlConnection connection = new MySqlConnection(ConnectionString))
    {
      connection.Open();
      MySqlCommand insert =  new MySqlCommand($"insert into Admin(EMAIL,PASSWORD) values ( '{admin.Email = email}' , '{admin.Password = password}');" , connection);
       var execute = insert.ExecuteNonQuery();
       if(execute == 0)
       {
        Console.WriteLine("Admin Created Succesfully");
       }
      //  else
      //  {
      //   Console.WriteLine("Unable To Create User");
      //  }
    }
       Console.WriteLine("You have successfully logged in as an admin");
      return false;
   }
}