using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Domain.Members
{
    public class City
    {
        public int ZIP { get; private set; }
        public string CityName { get; private set; }
        public string CountryName { get; private set; }

        private City()
        {
        }

        public City(int zip, string cityName, string countryName)
        {
            ZIP = zip;
            CityName = cityName;
            CountryName = countryName;
        }

        public static City CreateCity(int zip, string cityName, string country)
        {
            //Throw validation exception, not return null, make it explicit that the consumer has made an error
            if (zip.ToString().Length != 4 || string.IsNullOrWhiteSpace(cityName)|| string.IsNullOrWhiteSpace(country))
            {
                return null;
            }
            return new City(zip, cityName, country);
        }
    }
}
