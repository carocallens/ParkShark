using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParkShark.Domain.Tests.Members
{
    public class CityTests
    {
        [Fact]
        public void GivenHappyPath_WhenCreateNewCity_ThenCityCreated()
        {
            var zip = 1234;
            var cityName = "City";
            var country = "Country";

            var city = City.CreateCity(zip, cityName, country);

            Assert.NotNull(city);
        }

        [Fact]
        public void GivenCityWithZIPNotFourNumbers_WhenCreateNewCity_ThenCityIsNullObject()
        {
            var zip = 12345;
            var cityName = "City";
            var country = "Country";

            var city = City.CreateCity(zip, cityName, country);

            Assert.Null(city);
        }

        [Fact]
        public void GivenCityWithNoCityName_WhenCreateNewCity_ThenCityIsNullObject()
        {
            var zip = 12345;
            string cityName = null;
            var country = "Country";

            var city = City.CreateCity(zip, cityName, country);

            Assert.Null(city);
        }

        [Fact]
        public void GivenCityWithNoCountryName_WhenCreateNewCity_ThenCityIsNullObject()
        {
            var zip = 12345;
            var cityName = "City";
            string country = null;

            var city = City.CreateCity(zip, cityName, country);

            Assert.Null(city);
        }

    }
}
