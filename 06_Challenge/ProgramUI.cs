using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Challenge
{
    public class ProgramUI
    {
        private CarRepository _carRepo = new CarRepository();
        private List<Car> _car = new List<Car>();
        private List<Car> _carElectric = new List<Car>();
        private List<Car> _carHybrid = new List<Car>();
        private List<Car> _carGas = new List<Car>();
        private bool running = true;


        public ProgramUI()
        {
            _carRepo = new CarRepository();
            _car = _carRepo.GetAllCarItems(_car);
            _carElectric = _carRepo.GetAllCarItems(_carElectric);
            _carHybrid = _carRepo.GetAllCarItems(_carHybrid);
            _carGas = _carRepo.GetAllCarItems(_carGas);
        }

        public void Run()
        {
            while (running)
            {
                Console.WriteLine("1. Add car to inventory\n" +
                    "2. Update car details\n" +
                    "3. Remove car in inventory\n" +
                    "4. Show Electric inventory\n"+
                    "5. Show Hybrid inventory\n" +
                    "6. Show Gas inventory\n" +
                    "7. Show all inventory\n" +
                    "8. Exit");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        AddCarItem();
                        break;
                    case 2:
                        UpdateCarItem();
                        break;
                    case 3:
                        RemoveCarItemMenu();
                        break;
                    case 4:
                        ShowCarListByType(_carElectric);
                        break;
                    case 5:
                        ShowCarListByType(_carHybrid);
                        break;
                    case 6:
                        ShowCarListByType(_carGas);
                        break;
                    case 7:
                        ShowCarListAll();
                        break;
                    case 8:
                        running = false;
                    //default:

                        break;

                }
            }
        }
        private void AddCarItem()
        {
            Car entry = new Car();
            List<Car> list = new List<Car>();
            Console.WriteLine("What is the car type?\n" +
                    "1. Electric\n" +
                    "2. Hybrid\n" +
                    "3. Gas\n");

            int cartype = int.Parse(Console.ReadLine());

            //CarType type;
            switch (cartype)
            {
                //default:
                case 1:
                    entry.CarType = CarType.Electric;
                    list = _carElectric;
                    break;
                case 2:
                    entry.CarType = CarType.Hybrid;
                    list = _carHybrid;
                    break;
                case 3:
                    entry.CarType = CarType.Gas;
                    list = _carGas;
                    break;
            }

            Console.WriteLine("Please enter the car number.");
            entry.CarNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the car's color?");
            entry.CarColor = Console.ReadLine();

            Console.WriteLine("How many miles does the car have?");
            entry.CarMiles = int.Parse(Console.ReadLine());

            Console.WriteLine("How many doors does the car have?");
            entry.CarDoors = int.Parse(Console.ReadLine());

            Console.WriteLine("What transmission does the car have? automatic/manual/not applicable");
            entry.CarTransmission = Console.ReadLine();

            Console.WriteLine("Does it have any special features? true or false");
            entry.CarExtras = bool.Parse(Console.ReadLine());

            _carRepo.AddCarItemToList(entry, list);
            Console.WriteLine($"{entry.CarNumber} \"{entry.CarType}\" was added to the list {list} inventory.");
            Console.ReadKey();
        }
        private void ShowCarListAll()
        {
            _car = _carElectric.Concat(_carHybrid).Concat(_carGas).ToList();
            int count = _car.Count;
            if (count == 0)
            {
                Console.WriteLine("There are no cars currently in inventory.");
            }
            foreach (Car car in _car)
            {
                Console.WriteLine($"#{car.CarNumber} Type: {car.CarType} Color: {car.CarColor} Miles: {car.CarMiles} Doors: {car.CarDoors} Transmission: {car.CarTransmission} Special Features: {car.CarExtras}");
            }
        }
        private void ShowCarListByType(List<Car> list)
        {
            int count = list.Count;
            if (count == 0)
            {
                Console.WriteLine($"There are no cars currently in the {list}inventory.");
            }
            foreach (Car car in list)
            {
                Console.WriteLine($"#{car.CarNumber} Type: {car.CarType} Color: {car.CarColor} Miles: {car.CarMiles} Doors: {car.CarDoors} Transmission: {car.CarTransmission} Special Features: {car.CarExtras}");
            }
        }
        private void UpdateCarItem()
        {
            Car update = new Car();
            List<Car> list = new List<Car>();

            Console.WriteLine("Which inventory would you like to see?\n"+
                "1. Electric\n"+
                "2. Hybrid\n"+
                "3. Gas\n");
            int cartype = int.Parse(Console.ReadLine());

            //CarType type;
            switch (cartype)
            {
                //default:
                case 1:
                    update.CarType = CarType.Electric;
                    list = _carElectric;
                    break;
                case 2:
                    update.CarType = CarType.Hybrid;
                    list = _carHybrid;
                    break;
                case 3:
                    update.CarType = CarType.Gas;
                    list = _carGas;
                    break;
            }
            Console.WriteLine("What is the car number you would like to update?");

            int carNumber = int.Parse(Console.ReadLine());

            foreach (Car car in _car)
            {
                if (carNumber == car.CarNumber)
                {
                    update.CarNumber = car.CarNumber;
                    update.CarColor = car.CarColor;
                    update.CarType = car.CarType;
                    update.CarMiles = car.CarMiles;
                    update.CarDoors = car.CarDoors;
                    update.CarTransmission = car.CarTransmission;
                    update.CarExtras = car.CarExtras;

                    Console.WriteLine($"{car.CarNumber} {car.CarType} Color: {car.CarColor} Miles: {car.CarMiles} Doors: {car.CarDoors} Transmission: {car.CarTransmission} Special Features: {car.CarExtras}\n");
                }
            }



            Console.WriteLine("Which detail would you like to update?\n"+
                "1. Car type Electric\n"+
                "2. Car type Hybrid\n"+
                "3. Car type Gas\n"+
                "4. Car color\n"+
                "5. Car miles\n"+
                "6. Car doors\n"+
                "7. Car transmission\n"+
                "8. Car extras\n");

            int choice = int.Parse(Console.ReadLine());

            //CarType type;
            switch (choice)
            {
                //default:
                case 1:
                    update.CarType = CarType.Electric;
                    break;
                case 2:
                    update.CarType = CarType.Hybrid;
                    break;
                case 3:
                    update.CarType = CarType.Gas;
                    break;
                case 4:
                    Console.WriteLine("What is the new color?");
                    update.CarColor = Console.ReadLine();
                    
                    break;
                case 5:
                    Console.WriteLine("What are the new miles?");
                    update.CarMiles = int.Parse(Console.ReadLine());
                    break;
                case 6:
                    Console.WriteLine("What is the new door count?");
                    update.CarDoors = int.Parse(Console.ReadLine());
                    break;
                case 7:
                    Console.WriteLine("What is the new transmission? automatic/manual/not applicable");
                    update.CarTransmission = Console.ReadLine();
                    break;
                case 8:
                    Console.WriteLine("What is the new car features? true or false");
                    update.CarExtras = bool.Parse(Console.ReadLine());
                    break;
            }

            
            _carRepo.RemoveCarItemBySpecifications(update.CarNumber, list);
            _carRepo.AddCarItemToList(update, list);
            Console.WriteLine($"{update.CarNumber} \"{update.CarType}\" was updated in inventory.");
            Console.ReadKey();
        }

        //private void RemoveCarItemBeforeUpdate(List<Car> list)
        //{
        //    Car entry = new Car();
        //    //List<Car> list = new List<Car>();
        //    //Console.Clear();
        //    //ShowCarList();

        //    //Console.WriteLine("What is the car number to remove?");
        //    int carNumber = int.Parse(Console.ReadLine());

        //    bool success = _carRepo.RemoveCarItemBySpecifications(carNumber, list);
        //    //if (success == true)
        //    //{
        //    //    Console.WriteLine($"The entry for {entry.CarType} was successfully deleted.");
        //    //    Console.ReadKey();
        //    //}
        //    //else
        //    //{
        //    //    Console.WriteLine($"The entry for {entry.CarType} was unable to be deleted.");
        //    //    Console.ReadKey();
        //    //    Console.Clear();

        //    //}
        //}
        private void RemoveCarItemMenu()
        {
            List<Car> list = new List<Car>();
            Console.WriteLine("Which inventory would you like to work in?\n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas\n");
            int cartype = int.Parse(Console.ReadLine());

            //CarType type;
            switch (cartype)
            {
                //default:
                case 1:
                    list = _carElectric;
                    break;
                case 2:
                    list = _carHybrid;
                    break;
                case 3:
                    list = _carGas;
                    break;
            }
            RemoveCarItem(list);
        }
        private void RemoveCarItem(List<Car> list)
        {
            Car entry = new Car();
            //Console.Clear();
            ShowCarListByType(list);

            Console.WriteLine("\nWhat is the car number to remove?");
            int carNumber = int.Parse(Console.ReadLine());

            bool success = _carRepo.RemoveCarItemBySpecifications(carNumber, list);
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

