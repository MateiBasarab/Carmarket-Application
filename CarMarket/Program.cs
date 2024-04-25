using System;
using System.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassCar;

using DataStorageLevel;


namespace CarMarket
{

    internal class Program
    {


        static void Main()
        {
            Car carForFile = new Car();

            string fileName = ConfigurationManager.AppSettings["fileName"];
            CarAdministration_FileText carsAdministrationFile = new CarAdministration_FileText(fileName);

            CarAdministration_Memory carsAdministration = new CarAdministration_Memory();
            int noCars = 0;  //number of cars

            string swCase; // swCase -  switch case option
            do
            {
                Console.WriteLine("\nA.  Add a car");
                Console.WriteLine("D.  Display info about the last car entered");
                Console.WriteLine("F.  Display cars from a vector");
                Console.WriteLine("SF. Save car in file");
                Console.WriteLine("DF. Display cars from file");
                Console.WriteLine("S.  Search");
                Console.WriteLine("X.  EXIT");

                Console.Write("\nChoose an option: ");
                swCase = Console.ReadLine();

                switch (swCase.ToUpper())
                {
                    case "A":

                        Car newCar = new Car();             // Create a new Car object
                        ReadCarKB(newCar, noCars++);        // Read car data from keyboard and set it to the new Car object
                        carForFile = newCar;                // A temporary value so we will be able to add the car to a text file
                        carsAdministration.AddCar(newCar);  // Add the new Car object to CarAdministration_Memory
                        break;

                    case "D":  // Display info about the last car entered
                        DisplayCar(carsAdministration.GetLastCar());
                        break;

                    case "F":  // Display cars from a vector
                        Car[] cars = carsAdministration.GetCars(out noCars);
                        DisplayCars(cars, noCars);
                        break;

                    case "S":  // Search a car/cars by a specific facility
                        Car[] Cars = carsAdministration.GetCars(out noCars);
                        Search(Cars);
                        break;

                    case "SF":  //Save a car in a text file
                        carsAdministrationFile.AddCarInFile(carForFile);
                        break;

                    case "DF":  //Display saved cars from a text file
                        Car[] fileCars = carsAdministrationFile.GetCars(out noCars);
                        DisplayCars(fileCars, noCars);
                        break;

                    case "X":  //Quits the application
                        return;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            } while (swCase.ToUpper() != "X");

            Console.ReadKey();
        }


        public Car[] SendCarsToForm()
        {
            string fileName = ConfigurationManager.AppSettings["fileName"];
            CarAdministration_FileText carsAdministrationFile = new CarAdministration_FileText(fileName);

            Car[] fileCars = carsAdministrationFile.GetCars(out int noCars);

            return fileCars;
        }

        static void ReadCarKB(Car Masina, int aID)
        {
            string[] aOptions = new string[20];
            int i = 0;

            Console.WriteLine("\nEnter the coresponding data about the car: ");

            Console.Write("Brand: ");
            string aBrand = Console.ReadLine();


            Console.Write("Model: ");
            string aModel = Console.ReadLine();

            Console.Write("Manufacturing year: ");
            int aManufacturingYear = Convert.ToInt32(Console.ReadLine().Trim());

            Console.Write("Color: ");
            string aColor = Console.ReadLine();

            Console.WriteLine("Options(write 'stop' to stop): ");
            do
            {
                Console.Write("{0}. ", i + 1);
                aOptions[i] = Console.ReadLine();
                i++;

            } while (aOptions[i - 1].ToUpper() != "STOP");
            i--;
            Array.Resize(ref aOptions, i);

            Console.Write("Price(in Euro): ");
            int aPrice = Convert.ToInt32(Console.ReadLine().Trim());

            Masina.SetCar(aID, aBrand, aModel, aManufacturingYear, aColor, aOptions, aPrice);

        }

        static void DisplayCar(Car Masina)
        {
            Masina.GetCar();
        }

        public static void DisplayCars(Car[] cars, int noCars)
        {
            Console.WriteLine("At the moment, we have this cars:");
            for (int j = 0; j < noCars; j++)
            {
                cars[j].GetCar();
            }
        }

        public static void Search(Car[] cars)
        {
            string searchParameter, Case;
            int ok;
            do
            {
                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Search by:\n  1.Brand\n  2.Manufacturing year\n  3.Color\n  4.A specific option\n  5.Price\n  6.Close search");
                Console.Write("Enter the number of your preferred search: ");
                Case = Console.ReadLine().Trim();

                switch (Case)
                {
                    case "1":
                        Console.Write("Enter the brand you'd like to search: ");
                        searchParameter = Console.ReadLine();
                        Console.WriteLine("Results: ");



                        foreach (Car sCar in cars)
                        {
                            if (sCar == null) break;
                            if (searchParameter == sCar.GetParameter(1))
                            {
                                sCar.GetCar();
                            }
                        }
                        break;

                    case "2":
                        Console.Write("Enter the manufacturing year you'd like to search by: ");
                        searchParameter = Console.ReadLine();
                        Console.WriteLine("Results: ");
                        foreach (Car car in cars)
                        {
                            if (car == null) break;
                            if (searchParameter == car.GetParameter(2))
                            {
                                if (car == null) break;
                                car.GetCar();
                            }
                        }
                        break;

                    case "3":
                        Console.Write("Enter the color you'd like to search by: ");
                        searchParameter = Console.ReadLine();
                        Console.WriteLine("Results: ");
                        foreach (Car car in cars)
                        {
                            if (car == null) break;
                            if (searchParameter == car.GetParameter(3))
                            {
                                car.GetCar();
                            }
                        }
                        break;

                    case "4":
                        ok = 0;

                        Console.Write("Enter the option you'd like to search by: ");
                        searchParameter = Console.ReadLine();
                        Console.WriteLine("Results: ");
                        foreach (Car car in cars)
                        {
                            if (car == null) break;
                            if (car.GetOptions(searchParameter))
                            {
                                car.GetCar();
                                ok = 1;
                            }
                        }
                        if (ok == 0) Console.WriteLine("There are no available cars with that option.");
                        break;

                    case "5":
                        ok = 0;

                        int priceLow, priceHigh;
                        Console.WriteLine("Enter the price range you'd like to search by: ");
                        Console.Write("Minimum: ");
                        searchParameter = Console.ReadLine();
                        if (string.IsNullOrEmpty(searchParameter))
                        {
                            priceLow = 0;
                        }
                        else
                        {
                            priceLow = Convert.ToInt32(searchParameter.Trim());
                        }

                        Console.Write("Maximum: ");
                        searchParameter = Console.ReadLine();
                        if (string.IsNullOrEmpty(searchParameter))
                        {
                            priceHigh = Int32.MaxValue;
                        }
                        else
                        {
                            priceHigh = Convert.ToInt32(searchParameter.Trim());
                        }


                        Console.WriteLine("Results: ");
                        foreach (Car car in cars)
                        {
                            if (car == null) break;
                            if (Convert.ToInt32(car.GetParameter(5)) >= priceLow && Convert.ToInt32(car.GetParameter(5)) <= priceHigh)
                            {
                                car.GetCar();
                                ok = 1;
                            }
                        }
                        if (ok == 0) Console.WriteLine("No available cars within that price range.");
                        break;
                    case "6":
                        return;

                    default:
                        Console.WriteLine("Wrong option!");
                        break;
                }

            } while (Case != "6");
        }
    }
}
