using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Challenge
{
    public enum CustomerType { Current, Past, Future }
    
        public class Customer
    
    {


        public CustomerType CustType { get; set; }
        public int CustomerNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }



        public Customer(CustomerType customerType, int customerNumber, string firstName, string lastName, string email)
        {
            CustType = customerType;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public Customer()
        {

        }
    }
}
