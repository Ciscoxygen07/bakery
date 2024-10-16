using System.Collections.Generic;
using System;
using System.Data;
using MySql.Data.MySqlClient;


public class Product
{
    public int Product_Id { get; set;}
    public decimal Price { get; set;}
    public string ProductType { get; set;}
    public decimal Amount { get; set;}

 public Product ()
 {}
    public Product(decimal amount)
{
    Amount = amount;
}

public Product(int code , decimal price , string type)
{    

    Product_Id = code;
    Price = price;
    ProductType = type;
    
}

// public override string ToString ()
// {
//     return $"{Code}\t{Price}\t{Menu}";  
// }
}