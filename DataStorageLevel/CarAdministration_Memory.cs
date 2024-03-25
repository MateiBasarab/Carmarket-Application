using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassCar;

namespace DataStorageLevel
{
    public class CarAdministration_Memory
    {
        private const int maxNoCars = 50; //maximum number of cars

        private Car[] cars;
        private int numberOfCars;

        public CarAdministration_Memory()
        {
            cars = new Car[maxNoCars];
            numberOfCars = 0;
        }

        public void AddCar(Car car)
        {
            cars[numberOfCars] = car;
            numberOfCars++;
        }

        public Car[] GetCars(out int noCars)
        {
            noCars = this.numberOfCars;
            return cars;
        }

        public Car GetLastCar()
        {
            if (numberOfCars == 0)
            {
                return null;
            }
            return cars[numberOfCars - 1];
        }
    }
}
