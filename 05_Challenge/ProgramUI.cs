using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Challenge
{
    class ProgramUI
    {
        private static CustomerRepository _customerRepo = new CustomerRepository();
        private List<Customer> _customer = new List<Customer>();


        private bool running = true;


        public ProgramUI()
        {
            _customerRepo = new CustomerRepository();
            _customer = _customerRepo.GetAllCustomerItems();


        }

        public void Run()
        {
            while (running)
            {
                Console.WriteLine("1. Add customer to database\n" +
                       "2. Update customer details\n" +
                       "3. Remove customer in database\n" +
                       "4. Show customer database\n" +
                       "5. Exit");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        AddCustomerItem();
                        break;
                    case 2:
                        UpdateCustomerItem();
                        break;
                    case 3:
                        RemoveCustomerItem();
                        break;
                    case 4:
                        ShowCustomerListAll();
                        break;
                    case 5:
                        running = false;
                        //default:

                        break;

                }
            }
        }


        private void AddCustomerItem()
        {
            Customer entry = new Customer();

            Console.WriteLine("What is the customer type?\n" +
                    "1. Current\n" +
                    "2. Past\n" +
                    "3. Future\n");

            int customertype = int.Parse(Console.ReadLine());


            switch (customertype)
            {

                case 1:
                    entry.CustType = CustomerType.Current;
                    entry.Email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    break;
                case 2:
                    entry.CustType = CustomerType.Past;
                    entry.Email = "It's been a long time since we've heard from you, we want you back!";
                    break;
                case 3:
                    entry.CustType = CustomerType.Future;
                    entry.Email = "We currently have the lowest rates on Helicopter Insurance!";
                    break;
            }

            Console.WriteLine("Please create a unique customer number.");
            entry.CustomerNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the customer's first name.");
            entry.FirstName = Console.ReadLine();

            Console.WriteLine("Please enter the customer's last name.");
            entry.LastName = Console.ReadLine();

            _customerRepo.AddCustomerItemToList(entry);
            Console.WriteLine($"Customer: {entry.FirstName} {entry.LastName} was added to the database.");
            Console.ReadKey();
        }
        private void ShowCustomerListAll()
        {
            
            List<Customer> _SortedList = _customer.OrderBy(o=>o.FirstName).ToList();
            int count = _customer.Count;
            if (count == 0)
            {
                Console.WriteLine("There are no customers currently in the database.");
            }
            Console.WriteLine("\n    FirstName      LastName     CustomerType      Email");
            
            foreach (Customer customer in _SortedList)
            {
                Console.WriteLine($"Customer: {customer.CustomerNumber} {customer.FirstName} {customer.LastName} Type: {customer.CustType} Email: {customer.Email}");
            }
        }

        private void UpdateCustomerItem()
        {
            Customer update = new Customer();
            List<Customer> list = new List<Customer>();

            Console.WriteLine("What is the customer number you would like to update?");

            int customerNumber = int.Parse(Console.ReadLine());

            foreach (Customer customer in _customer)
            {
                if (customerNumber == customer.CustomerNumber)
                {
                    update.CustomerNumber = customer.CustomerNumber;
                    update.FirstName = customer.FirstName;
                    update.LastName = customer.LastName;
                    update.CustType = customer.CustType;
                    update.Email = customer.Email;

                    Console.WriteLine($"{customer.CustomerNumber} Customer: {customer.FirstName} {customer.LastName} Type: {customer.CustType} Email: {customer.Email}\n");
                }
            }



            Console.WriteLine("Which detail would you like to update?\n" +
                "1. Customer number\n" +
                "2. Customer first name\n" +
                "3. Customer last name\n" +
                "4. Change customer type to Current\n" +
                "5. Change customer type to Past\n" +
                "6. Change customer type to Future\n" +
                "7. Exit\n");

            int choice = int.Parse(Console.ReadLine());

            //CarType type;
            switch (choice)
            {
                //default:
                case 1:
                    Console.WriteLine("What is the new Customer Number?");
                    update.CustomerNumber = int.Parse(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("What is the new Customer First Name?");
                    update.FirstName = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("What is the new Customer Last Name?");
                    update.LastName = Console.ReadLine();
                    break;
                case 4:
                    update.CustType = CustomerType.Current;
                    break;
                case 5:
                    update.CustType = CustomerType.Past;
                    break;
                case 6:
                    update.CustType = CustomerType.Future;
                    break;
                case 7:
                    break;
            }


            _customerRepo.RemoveCustomerItemBySpecifications(update.CustomerNumber);
            _customerRepo.AddCustomerItemToList(update);
            Console.WriteLine($"{update.CustomerNumber} {update.FirstName} {update.LastName} was updated in inventory.");
            Console.ReadKey();
        }

        private void RemoveCustomerItem()
        {
            Customer entry = new Customer();
            //Console.Clear();
            ShowCustomerListAll();

            Console.WriteLine("\nWhat is the Customer Number to remove?");
            int customerNumber = int.Parse(Console.ReadLine());

            bool success = _customerRepo.RemoveCustomerItemBySpecifications(customerNumber);
            if (success == true)
            {
                Console.WriteLine($"The entry was successfully deleted.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"The entry was unable to be deleted.");
                Console.ReadKey();
                Console.Clear();

            }
        }
    }
}


