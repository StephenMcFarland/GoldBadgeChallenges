using System;
using System.Collections.Generic;
using _06_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class CarRepository_Tests
    {
        [TestMethod]
        public void AddMenuItemToList_ShouldBeCorrectCount()
        {
            //Arrange
            CarRepository _carRepo = new CarRepository();
            Car car = new Car();
            Car carTwo = new Car();
            Car carThree = new Car();
            List<Car> list = new List<Car>();

            _carRepo.AddCarItemToList(car, list);
            _carRepo.AddCarItemToList(carTwo, list);
            _carRepo.AddCarItemToList(carThree, list);
            //Act
            int actual = _carRepo.GetAllCarItems(list).Count;
            int expected = 3;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CarRepository_RemoveMenuBySpecification_BoolShouldReturnTrue()
        {
            //Arrange
            CarRepository _carRepo = new CarRepository();
            Car car = new Car(1, "red", CarType.Electric, 23000, 3, "na", true);
            Car carTwo = new Car(2, "blue", CarType.Hybrid, 53000, 4, "automatic", true);
            Car carThree = new Car(3, "green", CarType.Gas, 73000, 5, "manual", true);
            List<Car> list = new List<Car>();

            _carRepo.AddCarItemToList(car, list);
            _carRepo.AddCarItemToList(carTwo, list);
            _carRepo.AddCarItemToList(carThree, list);

            //Act
            bool actual = _carRepo.RemoveCarItemBySpecifications(carTwo.CarNumber, list);
            bool expected = true;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
