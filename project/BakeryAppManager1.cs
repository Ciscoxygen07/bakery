using System.Collections.Generic;
using System;
using System.Data;
using MySql.Data.MySqlClient;

public class BakeryAppManager1
{
    private static string ConnectionStringWithoutDB = "Server = localhost; User=root; password=Oxygen07;";
    private static string ConnectionString = "Server = localhost; User = root; database=BakeryAppBase1; password=Oxygen07;";

     public static void CreateDataBase()
   {
    using(MySqlConnection connection = new MySqlConnection(ConnectionStringWithoutDB))
    {
      connection.Open();
      string query = "Create Database if not exists BakeryAppBase1";
      MySqlCommand command = new MySqlCommand(query , connection);
      command.ExecuteNonQuery();
      Console.WriteLine("database created successfully");
      
    }
   }


   

}