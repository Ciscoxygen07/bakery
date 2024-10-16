using System.Collections.Generic;
using System;
using System.Data;
using MySql.Data.MySqlClient;

public class UserTable
{
    private static List <User> users = new List <User> ();
    private static string ConnectionStringWithoutDB = "Server = localhost; User=root; password=Oxygen07;";
    private static string ConnectionString = "Server = localhost; User = root; database=BakeryAppBase1; password=Oxygen07;";


//    public static void CreateUserDataBase()
//    {
//     using(MySqlConnection connection = new MySqlConnection(ConnectionStringWithoutDB))
//     {
//       connection.Open();
//       string query = "Create Database if not exists UserBakeryAppBase";
//       MySqlCommand command = new MySqlCommand(query , connection);
//       command.ExecuteNonQuery();
//       Console.WriteLine("database created successfully");
//     }
//    }


 public static void CreateUserTable1()
   {
     using(MySqlConnection connection=new MySqlConnection(ConnectionString))
     {
      connection.Open();
      string query = "create table if not exists BakeryAppBase1.User(UserId int primary Key not null auto_increment , FirstName varchar(255) not null, LastName varchar (255) not null, PhoneNumber varchar(255) not null unique, Email varchar(255)not null unique , Address varchar (255) not null, State varchar (255) not null , Country varchar (255) not null , Gender char (1) not null , Password varchar (255) not null unique);";
      MySqlCommand command = new MySqlCommand(query, connection);
      var execute = command.ExecuteNonQuery();

      if (execute == 0)
      {
        Console.WriteLine("Table Created Successfully");
      }
      else
      {
        Console.WriteLine("Unble to create Table.");
      }
     }
   }


    public static void CreateUser(User user)
   {

        Console.Write("First Name : ");
        string firstName = Console.ReadLine();
        Console.Write("Last Name : ");
        string lastName = Console.ReadLine();
        Console.Write("Email : ");
        string email = Console.ReadLine();
        Console.Write("Phone Number : ");
        string phoneNumber = Console.ReadLine();
        Console.Write("Address : ");
        string address = Console.ReadLine();
        Console.Write("State : ");
        string state = Console.ReadLine();
        Console.Write("Country : ");
        string country = Console.ReadLine();
        Console.Write("Gender : ");
        char gender = char.Parse(Console.ReadLine());
        Console.Write("Password : ");
        string password = Console.ReadLine();
        Console.WriteLine("User registered successfully.");
        var users1 = new User(firstName, lastName, email, phoneNumber, address, state, country, gender, password);
        users.Add(users1);
    using(MySqlConnection connection = new MySqlConnection(ConnectionString))
    {
      connection.Open();
      MySqlCommand insert =  new MySqlCommand($"insert into User(FirstName,LastName,email,PhoneNumber,Address,State,Country,Gender,Password) values ('{user.FirstName = firstName}',  '{user.LastName =lastName}' , '{user.Email = email}' ,'{user.PhoneNumber = phoneNumber}' , '{user.Address = address}' , '{user.State = state}' , '{user.Country = country}' ,'{user.Gender = gender}' , '{user.Password = password}');" , connection);
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


    public static User  LoginUser(int Id)
    {
         using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();

            string selectQuery = $"SELECT UserId, FirstName, email From BakeryAppBase1.User where UserId ={Id} ";
            using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("User in the database: ");
                    if (reader.Read())
                    {
                      User use = new User();
                      use.Id = reader.GetInt32(0);
                       use.FirstName = reader.GetString(1);
                      use.Email = reader.GetString(2);
                      Console.WriteLine($"welcome : {use.FirstName} ");
                      return use;
                    }
                }
            }
        } 
         return null;
    }
   

}
