using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCar
{
    public class Car
    {
        int ID_car;
        public string name { get; set; }
        public string model { get; set; }
        public int manufacturing_year { get; set; }
        public string color { get; set; }
        string[] options;
        public int price { get; set; }
        
        string sellerName;
        string buyerName;
        string buyDate;

        public void SetCar(int aID, string aName, string aModel, int aManufacturing_year, string aColor, string[] aOptions, int aPrice)
        {
            //In this case, the 'a' before the variable's name stands for 'argument'.
            //Example:  argumentID   -> aID
            //          argumentName -> aName ...

            this.ID_car = aID;
            name = aName;
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
            Console.WriteLine("Brand: {0}", name);
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
                    return name;
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

        public void setID(int aID)
        {
            this.ID_car = aID;
        }
    }
}
