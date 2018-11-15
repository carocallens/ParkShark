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

        public City(int zip, string cityName, string countryName)
        {
            ZIP = zip;
            CityName = cityName;
            CountryName = countryName;
        }

        public static City CreateCity(int zip, string cityName, string country)
        {
            if (zip.ToString().Length != 4 || cityName == null || country == null)
            {
                return null;
            }
            return new City(zip, cityName, country);
        }
    }
}
