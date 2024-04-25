using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassCar
{
    public class Car
    {
        private const char mainFileSeparator = '|';
        private const char secondaryFileSeparator = '/';

        private const int ID = 0;
        private const int Brand = 1;
        private const int Model = 2;
        private const int Manufacturing_Year = 3;
        private const int Color = 4;
        private const int Price = 5;
        private const int Options = 6;

        int ID_car;
        public string brand { get; set; }
        public string model { get; set; }
        public int manufacturing_year { get; set; }
        public string color { get; set; }
        string[] options;
        public int price { get; set; }
        
        string sellerName;
        string buyerName;
        string buyDate;

        public Car()
        {
            brand = model = string.Empty;
        }

        public Car(string fileLine)
        {
            int i = 0;
            var fileData = fileLine.Split(mainFileSeparator);

            this.ID_car = Convert.ToInt32(fileData[ID]);
            this.brand = fileData[Brand];
            this.model = fileData[Model];
            this.manufacturing_year = Convert.ToInt32(fileData[Manufacturing_Year]);
            this.color = fileData[Color];
            this.price = Convert.ToInt32(fileData[Price]);

            string groupedOptions = fileData[Options];
            string[] separatedOptions = groupedOptions.Split(secondaryFileSeparator);

            options = new string[separatedOptions.Length];
            separatedOptions.CopyTo(options, 0);

        }

        public void SetCar(int aID, string aBrand, string aModel, int aManufacturing_year, string aColor, string[] aOptions, int aPrice)
        {
            //In this case, the 'a' before the variable's name stands for 'argument'.
            //Example:  argumentID   -> aID
            //          argumentName -> aName ...

            this.ID_car = aID;
            brand = aBrand;
            model = aModel;
            manufacturing_year = aManufacturing_year;
            color = aColor;

            options = new string[aOptions.Length];
            aOptions.CopyTo(options, 0);

            price = aPrice;
        }

        public void GetCar()
        {
            Console.WriteLine("\n--------------------------------------------");
            Console.WriteLine("The car(ID: {0}) has the next properties: \n", ID_car);
            Console.WriteLine("Brand: {0}", brand);
            Console.WriteLine("Model: {0}", model);
            Console.WriteLine("Manufacturing year: {0}", manufacturing_year);
            Console.WriteLine("Color: {0}", color);
            Console.WriteLine("Options: ");
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(" {0}. {1}", i + 1, options[i]);
            }
            Console.WriteLine("Price(Euro): {0}", price);
            Console.WriteLine("--------------------------------------------");
        }

        public string GetParameter(int aParameter)
        {
            switch (aParameter)
            {
                case 1:
                    return brand;
                case 2:
                    return Convert.ToString(manufacturing_year);
                case 3:
                    return color;
                case 5:
                    return Convert.ToString(price);
                default:
                    return null;
            }
        }

        public bool GetOptions(string aOption)
        {
            foreach (string option in options)
            {
                if (option.ToUpper() == aOption.ToUpper()) return true;
            }
            return false;
        }

        public string GetOptionsAsString()
        {
            string optionsString = "";
            for (int i = 0; i < options.Length; i++)
            {
                if (i != options.Length -1)
                {
                    optionsString += options[i];
                    optionsString += ", ";
                }
                else
                {
                    optionsString += options[i];
                }
            }

            return optionsString;
        }

        public void setID(int aID)
        {
            this.ID_car = aID;
        }

        public string StringConversionForFileStorage()
        {
            //Unk. -> abbreviation for unknown
            string fileFormattedCar = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}",
                mainFileSeparator,
                ID_car.ToString(),
                (brand ?? " Unk. "),
                (model ?? " Unk. "),
                (manufacturing_year.ToString() ?? " Unk. "),
                (color ?? " Unk. "),
                (price.ToString() ?? " Unk. ")
                );

            for (int i = 0; i < options.Length; i++)
            {
                if(i == options.Length - 1 )
                {
                    fileFormattedCar += string.Format("{0}", options[i]);
                }
                else
                {
                    fileFormattedCar += string.Format("{1}{0}", secondaryFileSeparator, options[i]);
                }

            }

            fileFormattedCar += mainFileSeparator;

            return fileFormattedCar;
        }

        public string GetBrand()
        {
            return brand;
        }
    }
}
