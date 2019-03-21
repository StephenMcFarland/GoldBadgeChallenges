using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Challenge
{
    public class CustomerRepository
    {
        List<Customer> _customer = new List<Customer>();
        
        public void AddCustomerItemToList(Customer customer)
        {
            _customer.Add(customer);
        }

        public List<Customer> GetAllCustomerItems()
        {
            return _customer;
        }

        public void RemoveMenuItem(Customer customer)
        {
            _customer.Remove(customer);
        }


        public bool RemoveCustomerItemBySpecifications(int customerNumber)
        {
            bool successful = false;
            foreach (Customer customer in _customer)
            {
                if (customer.CustomerNumber == customerNumber)
                {
                    RemoveMenuItem(customer);
                    successful = true;
                    break;
                }
            }
            return successful;
        }


    }
}

