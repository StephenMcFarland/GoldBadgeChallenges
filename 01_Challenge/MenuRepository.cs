using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge
{
    public class MenuRepository
    {
        List<Menu> _menu = new List<Menu>();

        public void AddMenuItemToList(Menu menu)
        {
            _menu.Add(menu);
        }

        public List<Menu> GetAllMenuItems()
        {
            return _menu;
        }

        public void RemoveMenuItem(Menu menu)
        {
            _menu.Remove(menu);
        }

      
        public bool RemoveMenuItemBySpecifications(int mealNumber)
        {
            bool successful = false;
            foreach (Menu menu in _menu)
            {
                if (menu.MealNumber == mealNumber)
                {
                    RemoveMenuItem(menu);
                    successful = true;
                    break;
                }
            }
            return successful;
        }


    }
}
