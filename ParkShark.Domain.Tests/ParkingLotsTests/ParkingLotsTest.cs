using ParkShark.Domain.Members;
using ParkShark.Domain.ParkingLots;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParkShark.Domain.Tests.ParkingLotsTests
{
    public class ParkingLotsTest
    {

        [Fact]
        public void GivenHappyPath_WhenCreateNewParkingLot_ThenParkingLotIsCreated()
        {
            var city = City.CreateCity(2050, "Antwerpen", "Belgium");

            var parkinglot = ParkingLotBuilder.CreateNewParkingLot()
                .WithName("name")
                .WithBuildingType(BuildingType.AboveGround)
                .WithCapacity(2)
                .WithAddress(Address.CreateAddress("test", "test", city))
                .WithPricePerHour(5)
                .WithContactPerson(ContactPerson.CreateNewContactPerson("x", "x", Address.CreateAddress("x", "x", city), "valid@mail.com", "x", "x"))
                .Build();

            Assert.NotNull(parkinglot);
        }

        [Fact]
        public void GivenParkingLot_WhenNameIsNullOrWhiteSPace_ThenWholeObjectNull()
        {
            var city = City.CreateCity(2050, "Antwerpen", "Belgium");

            var parkinglot = ParkingLotBuilder.CreateNewParkingLot()
                .WithName(" ")
                .WithBuildingType(BuildingType.AboveGround)
                .WithCapacity(2)
                .WithAddress(Address.CreateAddress("test", "test", city))
                .WithPricePerHour(5)
                .WithContactPerson(ContactPerson.CreateNewContactPerson("x", "x", Address.CreateAddress("x", "x", city), "valid@mail.com", "x", "x"))
                .Build();

            Assert.Null(parkinglot);
        }

        [Fact]
        public void GivenParkingLot_WhenAddressIsNull_ThenWholeObjectIsNull()
        {
            var city = City.CreateCity(2050, "Antwerpen", "Belgium");

            var parkinglot = ParkingLotBuilder.CreateNewParkingLot()
                .WithName("Name")
                .WithBuildingType(BuildingType.AboveGround)
                .WithCapacity(2)
                .WithAddress(null)
                .WithPricePerHour(5)
                .WithContactPerson(ContactPerson.CreateNewContactPerson("x", "x", Address.CreateAddress("x", "x", city), "valid@mail.com", "x", "x"))
                .Build();

            Assert.Null(parkinglot);
        }

        [Fact]
        public void GivenParkingLot_WhenCapacityIsBelowOrEqualTo0_ThenWholeObjectIsNull()
        {
            var city = City.CreateCity(2050, "Antwerpen", "Belgium");

            var parkinglot = ParkingLotBuilder.CreateNewParkingLot()
                .WithName("Name")
                .WithBuildingType(BuildingType.AboveGround)
                .WithCapacity(-2)
                .WithAddress(Address.CreateAddress("test", "test", city))
                .WithPricePerHour(5)
                .WithContactPerson(ContactPerson.CreateNewContactPerson("x", "x", Address.CreateAddress("x", "x", city), "valid@mail.com", "x", "x"))
                .Build();

            Assert.Null(parkinglot);
        }

        [Fact]
        public void GivenParkingLot_WhenContactPersonIsNUllOrWhiteSpace_ThenWholeObjectIsNull()
        {
            var city = City.CreateCity(2050, "Antwerpen", "Belgium");

            var parkinglot = ParkingLotBuilder.CreateNewParkingLot()
                .WithName("Name")
                .WithBuildingType(BuildingType.AboveGround)
                .WithCapacity(2)
                .WithAddress(Address.CreateAddress("test", "test", city))
                .WithPricePerHour(5)
                .WithContactPerson(null)
                .Build();

            Assert.Null(parkinglot);
        }

        [Fact]
        public void GivenParkingLot_WhenPriceIsBelow0_ThenWholeObjectIsNull()
        {
            var city = City.CreateCity(2050, "Antwerpen", "Belgium");

            var parkinglot = ParkingLotBuilder.CreateNewParkingLot()
                .WithName("Name")
                .WithBuildingType(BuildingType.AboveGround)
                .WithCapacity(2)
                .WithAddress(Address.CreateAddress("test", "test", city))
                .WithPricePerHour(-5)
                .WithContactPerson(ContactPerson.CreateNewContactPerson("x", "x", Address.CreateAddress("x", "x", city), "valid@mail.com", "x", "x"))
                .Build();

            Assert.Null(parkinglot);
        }

    }
}
