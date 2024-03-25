using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
            throw new NotImplementedException();
        }

        public void AddCar(Car car)
        {
            throw new NotImplementedException();
        }

        public Car[] GetCars(out int noCars)
        {
            throw new NotImplementedException();
        }

        public Car GetLastCar()
        {
            throw new NotImplementedException();
        }
    }
}