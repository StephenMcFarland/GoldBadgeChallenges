using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Challenge
{
    public class CarRepository
    {
        List<Car> _car = new List<Car>();
        List<Car> _carElectric = new List<Car>();
        List<Car> _carHybrid = new List<Car>();
        List<Car> _carGas = new List<Car>();

        public void AddCarItemToList(Car car, List<Car> list)
        {
            list.Add(car);
        }

        public List<Car> GetAllCarItems(List<Car> list)
        {
            return list;
        }

        public void RemoveMenuItem(Car car, List<Car> list)
        {
            list.Remove(car);
        }


        public bool RemoveCarItemBySpecifications(int carNumber, List<Car> list)
        {
            bool successful = false;
            foreach (Car car in list)
            {
                if (car.CarNumber == carNumber)
                {
                    RemoveMenuItem(car, list);
                    successful = true;
                    break;
                }
            }
            return successful;
        }


    }
}

