using System.Collections.Generic;
using System;
using System.Data;
using MySql.Data.MySqlClient;

public class  Admin
{
  public string Email { get; set; }
  public string Password { get; set; }


  
public Admin()
    { }
    public Admin( string email, string password)
    {
       
        Email = email;
        
        Password = password;
    }

//      public override string ToString ()
// {
//     return $"{Email}\t{Password}";
// }
  
}



