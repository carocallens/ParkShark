using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Domain.Members
{
    public class Address
    {
        public string StreetName { get; private set; }
        public string StreetNumber { get; private set; }
        public int ZIP { get; private set; }
        public City City { get; private set; }

        private Address()
        {
        }

        private Address(string streetName, string streetNumber, City givenCity)
        {
            StreetName = streetName;
            StreetNumber = streetNumber;
            ZIP = givenCity.ZIP;
            City = givenCity;
        }

        public static Address CreateAddress(string streetName, string streetNumber, City givenCity)
        {
            //Throw validation exception, not return null, make it explicit that the consumer has made an error
            if (string.IsNullOrWhiteSpace(streetName) || string.IsNullOrWhiteSpace(streetNumber) || givenCity.ZIP.ToString().Length != 4)
            {
                return null;
            }

            return new Address(streetName, streetNumber, givenCity);
        }
    }
}
