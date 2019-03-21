using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Challenge
{
    public enum CarType { Electric, Hybrid, Gas }
    public class Car
    {
        

        public int CarNumber { get; set; }
        public string CarColor { get; set; }
        public CarType CarType { get; set; }
        public int CarMiles { get; set; }
        public int CarDoors { get; set; }
        public string CarTransmission { get; set; }
        public bool CarExtras { get; set; }
        


        public Car(int carNumber, string carColor, CarType carType, int carMiles, int carDoors, string carTransmission, bool carExtras)
        {
            CarNumber = carNumber;
            CarColor = carColor;
            CarType = carType;
            CarMiles = carMiles;
            CarDoors = carDoors;
            CarTransmission = carTransmission;
            CarExtras = carExtras;

            
        }

        public Car()
        {

        }
    }
}
