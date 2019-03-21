using System;
using _01_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddMenuItemToList_ShouldBeCorrectCount()
        {
            //Arrange
            MenuRepository _menuRepo = new MenuRepository();
            Menu menu = new Menu();
            Menu menuTwo = new Menu();
            Menu menuThree = new Menu();
           

            _menuRepo.AddMenuItemToList(menu);
            _menuRepo.AddMenuItemToList(menuTwo);
            _menuRepo.AddMenuItemToList(menuThree);
            //Act
            int actual = _menuRepo.GetAllMenuItems().Count;
            int expected = 3;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuRepository_RemoveMenuBySpecification_BoolShouldReturnTrue()
        {
            //Arrange
            MenuRepository _menuRepo = new MenuRepository();
            Menu menu = new Menu(1, "Meal Name 1", "Meal Description 1", "Meal Ingredients 1", 1);
            Menu menuTwo = new Menu(2, "Meal Name 2", "Meal Description 2", "Meal Ingredients 2", 2);
            Menu menuThree = new Menu(3, "Meal Name 3", "Meal Description 3", "Meal Ingredients 3", 3);

            _menuRepo.AddMenuItemToList(menu);
            _menuRepo.AddMenuItemToList(menuTwo);
            _menuRepo.AddMenuItemToList(menuThree);

            //Act
            bool actual = _menuRepo.RemoveMenuItemBySpecifications(menuTwo.MealNumber);
            bool expected = true;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
