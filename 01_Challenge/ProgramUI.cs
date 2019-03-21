using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge
{
    public class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();
        private List<Menu> _menu = new List<Menu>();
        private bool running = true;
        

        public ProgramUI()
        {
            _menuRepo = new MenuRepository();
            _menu = _menuRepo.GetAllMenuItems();
        }

        public void Run()
        {
            while (running)
            {
                Console.WriteLine("1. Add Menu Item\n" +
                    "2. Show Menu List\n" +
                    "3. Remove Menu Item\n" +
                    "4. Exit");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        AddMenuItem();
                        break;
                    case 2:
                        ShowMenuList();
                        break;
                    case 3:
                        RemoveMenuItem();
                        break;
                    case 4:
                        running = false;
                        break;
                    default:

                        break;

                }
            }
        }
        private void AddMenuItem()
        {
            Menu order = new Menu();
            
            Console.WriteLine("Please enter the meal number.");
            order.MealNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the meal name?");
            order.MealName = Console.ReadLine();

            Console.WriteLine("Enter the meal description.");
            order.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the meal ingredients.");
            order.MealIngredients = Console.ReadLine();

            Console.WriteLine("Enter the meal price.");
            order.MealPrice = decimal.Parse(Console.ReadLine());

            _menuRepo.AddMenuItemToList(order);
            Console.WriteLine($"\"{order.MealName}\" was added to list.");
            Console.ReadKey();
        }
        private void ShowMenuList()
        {
            int count = _menu.Count;
            if (count == 0)
            {
                Console.WriteLine("There are no items in the list.");
            }
            foreach (Menu menu in _menu)
            {
                Console.WriteLine($"{menu.MealNumber} {menu.MealName} {menu.MealDescription} {menu.MealIngredients} {menu.MealPrice}");
            }
        }
        private void RemoveMenuItem()
        {
            Menu order = new Menu();
            Console.Clear();
            ShowMenuList();

            Console.WriteLine("What is the meal number to remove?");
            int mealNumber = int.Parse(Console.ReadLine());

            bool success = _menuRepo.RemoveMenuItemBySpecifications(mealNumber);
            if (success == true)
            {
                Console.WriteLine($"The order for {order.MealName} was successfully removed.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"The order for {order.MealName} was unable to be removed at this time.");
                Console.ReadKey();
                Console.Clear();

            }
        }
    }
}