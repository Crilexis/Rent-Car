using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinq.RentCar.Abstractions.Models
{
    public class Car : ICar
    {
        public Car(EnumCategory category, EnumModel model, int year)
        {
            Category = category;
            Model = model;
            Year = year;
        }

        public Car()
        { }

        public EnumCategory Category { get; set; }

        public EnumModel Model { get; set; }

        public int Year { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Model.ToString(), Category.ToString(), Year);
        }
    }
}
