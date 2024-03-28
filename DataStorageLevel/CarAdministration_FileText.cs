using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassCar;

using DataStorageLevel;

namespace DataStorageLevel
{
    public class CarAdministration_FileText
    {
        private const int maxNoCars = 50;  //maximum number of cars
        private string fileName;

        public CarAdministration_FileText(string fileName)
        {
            this.fileName = fileName;
            Stream streamTextFile = File.Open(fileName, FileMode.OpenOrCreate);
            streamTextFile.Close();
        }

        public void AddCarInFile(Car car)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            using (StreamWriter streamWriterTextFile = new StreamWriter(fileName, true))
            {
                streamWriterTextFile.WriteLine(car.StringConversionForFileStorage());
            }
        }

        public Car[] GetCars(out int noCars) // noCars = number of cars
        {
            Car[] cars = new Car[maxNoCars];

            using (StreamReader streamReader = new StreamReader(fileName))
            {
                string fileLine;
                noCars = 0;

                //reads lines and converts it to a Car class
                while ((fileLine = streamReader.ReadLine()) != null)
                {
                    cars[noCars++] = new Car(fileLine);
                }
            }

            return cars;
        }
    }
}
