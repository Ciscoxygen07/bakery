using System.Collections.Generic;
using System;
using System.Data;
using MySql.Data.MySqlClient;

public class  User
{
  public int Id { get; set;}
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string PhoneNumber { get; set; }
  public string Email { get; set; }
  public string Address { get; set; }
  public string State { get; set; }
  public string Country { get; set; }
  public char Gender { get; set; }
  public string Password { get; set; }


  
public User()
    { }
    public User(string firstName, string lastName, string email, string phoneNumber, string address, string state, string country, char gender, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
        State = state;
        Country = country;
        Gender = gender;
        Password = password;
    }

//      public override string ToString ()
// {
//     return $"{FirstName}\t{LastName}\t{Email}\t{PhoneNumber}\t{Address}\t{State}\t{Country}\t{Gender}\t{Password}";
// }
  
}



