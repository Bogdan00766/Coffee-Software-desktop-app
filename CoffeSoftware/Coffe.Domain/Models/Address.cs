using Coffe.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffe.Domain.Models
{
    public class Address : Entity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public List<User> Users { get; set; }

        public Address()
        {

        }

        public Address(string street, 
            string city, 
            string state, 
            int postalCode, 
            string country, 
            List<User> users)
        {
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;
            Users = users;
        }
    }
}
