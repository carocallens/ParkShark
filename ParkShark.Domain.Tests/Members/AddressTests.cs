using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParkShark.Domain.Tests.Members
{
    public class AddressTests
    {
        [Fact]
        public void GivenHappyPath_WhenCreateNewAddress_ThenAddressCreated()
        {
            //given
            var city = new City(1234, "CityName", "CountryName");

            var streetName = "StreetName";
            var streetNumber = "StreetNumber";

            //when
            Address address = Address.CreateAddress(streetName, streetNumber, city);

            //then
            Assert.True(address != null);
        }

        [Fact]
        public void GivenAddressWithNoStreetName_WhenCreateAddress_ThenAddressIsNullObject()
        {
            //given
            var city = new City(1234, "CityName", "CountryName");

            string streetName = null;
            var streetNumber = "StreetNumber";

            //when
            Address address = Address.CreateAddress(streetName, streetNumber, city);

            //then
            Assert.Null(address);
        }

        [Fact]
        public void GivenAddressWithNoStreetNumber_WhenCreateAddress_ThenAddressIsNullObject()
        {
            //given
            var city = new City(1234, "CityName", "CountryName");

            var streetName = "StreetName";
            string streetNumber = null;

            //when
            Address address = Address.CreateAddress(streetName, streetNumber, city);

            //then
            Assert.Null(address);
        }
        
        [Fact]
        public void GivenAddressWithZIPNotFourNumbers_WhenCreateAddress_ThenAddresIsNullObject()
        {
            //given
            var streetName = "StreetName";
            string streetNumber = null;
            var city = City.CreateCity(12345, "Antwepren", "Belgium");

            //when
            Address address = Address.CreateAddress(streetName, streetNumber, city);

            //then
            Assert.Null(address);
        }
    }
}
