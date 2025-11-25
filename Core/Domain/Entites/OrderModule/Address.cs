using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.OrderModule
{
  
        public class Address
        {

        public Address() { }
        public Address(string firstname, string lastname, string country, string city, string street)
        {
            Firstname = firstname;
            Lastname = lastname;
            Country = country;
            City = city;
            Street = street;
        }

        public string Firstname { get; set; } = string.Empty;

            public string Lastname { get; set; } = string.Empty;

            public string Country { get; set; } = string.Empty;


            public string City { get; set; } = string.Empty;
            public string Street { get; set; } = string.Empty;
        }
}
