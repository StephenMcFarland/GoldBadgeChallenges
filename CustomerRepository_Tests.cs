using System;
using _05_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class CustomerRepository_Tests
    {
        [TestMethod]
        public void AddCustomerItemToList_ShouldBeCorrectCount()
        {
            //Arrange
            CustomerRepository _customerRepo = new CustomerRepository();
            Customer customer = new Customer();
            Customer customerTwo = new Customer();
            Customer customerThree = new Customer();
            

            _customerRepo.AddCustomerItemToList(customer);
            _customerRepo.AddCustomerItemToList(customerTwo);
            _customerRepo.AddCustomerItemToList(customerThree);
            //Act
            int actual = _customerRepo.GetAllCustomerItems().Count;
            int expected = 3;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CustomerRepository_RemoveCustomerBySpecification_BoolShouldReturnTrue()
        {
            //Arrange
            CustomerRepository _customerRepo = new CustomerRepository();
            Customer customer = new Customer(CustomerType.Current, 1, "firstname", "last name", "email message");
            Customer customerTwo = new Customer(CustomerType.Future, 2, "firstname", "last name", "email message");
            Customer customerThree = new Customer(CustomerType.Past, 3, "firstname", "last name", "email message");
            

            _customerRepo.AddCustomerItemToList(customer);
            _customerRepo.AddCustomerItemToList(customerTwo);
            _customerRepo.AddCustomerItemToList(customerThree);

            //Act
            bool actual = _customerRepo.RemoveCustomerItemBySpecifications(customerTwo.CustomerNumber);
            bool expected = true;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
