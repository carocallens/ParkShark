﻿using ParkShark.Domain.Members;
using Xunit;

namespace ParkShark.Domain.Tests.Members
{
    public class LicensePlateTests
    {
        [Fact]
        public void GivenHappyPath_WhenCreateNewLicensePlate_ThenLicensePlateCreated()
        {
            //given
            var firstName = "firstName";
            var lastName = "lastName";

            var city = new City(
                        1234,
                        "CityName",
                        "CountryName"
                        );

            Address address = Address.CreateAddress(
                                "StreetName",
                                "StreetNumber",
                                city.ZIP
                                );

            var member = Member.CreateMember(
                            firstName,
                            lastName,
                            address.AddressId.ToString()
                            );

            //when
            var licensePlate = LicensePlate.CreateLicensePlate(member.MemberId.ToString(),
                                                                "1-ABC-123",
                                                                "Belgium");

            //then
            Assert.NotNull(licensePlate);
        }

        [Fact]
        public void GivenLicensePlateWithMemberIdNull_WhenCreateLicensePlate_ThenLicensePlateIsNull()
        {

            //given


            //when
            var licensePlate = LicensePlate.CreateLicensePlate(null,
                                                                "1-ABC-123",
                                                                "Belgium");

            //then
            Assert.Null(licensePlate);
        }

        [Fact]
        public void GivenLicensePlateWithLicensePlateValueNull_WhenCreateLicensePlate_ThenLicensePlateIsNull()
        {
            //given
            var firstName = "firstName";
            var lastName = "lastName";

            var city = new City(
                        1234,
                        "CityName",
                        "CountryName"
                        );

            Address address = Address.CreateAddress(
                                "StreetName",
                                "StreetNumber",
                                city.ZIP
                                );

            var member = Member.CreateMember(
                            firstName,
                            lastName,
                            address.AddressId.ToString()
                            );

            //when
            var licensePlate = LicensePlate.CreateLicensePlate(member.MemberId.ToString(),
                                                                null,
                                                                "Belgium");

            //then
            Assert.Null(licensePlate);
        }

        [Fact]
        public void GivenLicensePlateWithIssueingCountryNull_WhenCreateLicensePlate_ThenLicensePlateIsNull()
        {
            //given
            var firstName = "firstName";
            var lastName = "lastName";

            var city = new City(
                        1234,
                        "CityName",
                        "CountryName"
                        );

            Address address = Address.CreateAddress(
                                "StreetName",
                                "StreetNumber",
                                city.ZIP
                                );

            var member = Member.CreateMember(
                            firstName,
                            lastName,
                            address.AddressId.ToString()
                            );

            //when
            var licensePlate = LicensePlate.CreateLicensePlate(member.MemberId.ToString(),
                                                                "1-ABC-123",
                                                                null);

            //then
            Assert.Null(licensePlate);
        }
    }
}
