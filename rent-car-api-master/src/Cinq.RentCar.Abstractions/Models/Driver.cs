using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinq.RentCar.Abstractions.Models
{
    public class Driver : IDriver
    {
        public Driver(int age, string firstName, string lastName)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
        }

        public Driver()
        { }

        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}, {2}", FirstName, LastName, Age);
        }
    }
}
