using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class Customers : ICustomerType
{
    public Customers(){} 
    public Customers(string firstName, string lastName, CustomerType customerType, string email)
    {
       
        FirstName = firstName;
        LastName = lastName;
        CustomerType = customerType;
        Email = email;
    }
    public Customers(int id, string firstName, string lastName, CustomerType customerType, string email)
    {
        ID=id;
        FirstName = firstName;
        LastName = lastName;
        CustomerType = customerType;
        Email = email;
    }
    public int ID{get;set;}
    public string FirstName{get;set;}
    public string LastName{get;set;}
    public CustomerType CustomerType{get;set;}
    public string Email{get;set;}


}

  