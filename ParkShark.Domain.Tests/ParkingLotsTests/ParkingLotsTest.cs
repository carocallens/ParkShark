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
        public void GivenParkingLot_WhenOneValueNull_ThenWholeObjectNull()
        {
            var parkinglot = ParkingLotBuilder.CreateNewParkingLot()
                .WithName(" ")
                .WithBuildingType(1)
                .WithCapacity(2)
                .WithAddress(Address.CreateAddress("test", "test", 1234))
                .WithContactPersonID(null)
                .WithDivision(1)
                .WithPricePerHour(5)
                .Build();

            Assert.Null(parkinglot);
        }
    }
}
