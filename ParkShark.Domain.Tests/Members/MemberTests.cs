using ParkShark.Domain.Members;
using Xunit;

namespace ParkShark.Domain.Tests.Members
{
    public class MemberTests
    {
        [Fact]
        public void GivenHappyPath_WhenCreateNewMember_ThenMemberCreated()
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

            //when
            var member = Member.CreateMember(firstName, lastName, address.AddressId.ToString());

            //then
            Assert.True(member != null);
        }

        [Fact]
        public void GivenMemberWithNoFirstName_WhenCreateMember_ThenMemberIsNullObject()
        {
            //given
            string firstName = null;
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

            //when
            var member = Member.CreateMember(firstName, lastName, address.AddressId.ToString());

            //then
            Assert.Null(member);
        }

        [Fact]
        public void GivenMemberWithNoLastName_WhenCreateMember_ThenMemberIsNullObject()
        {
            //given
            var firstName = "firstName";
            string lastName = null;

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

            //when
            var member = Member.CreateMember(firstName, lastName, address.AddressId.ToString());

            //then
            Assert.Null(member);
        }

        [Fact]
        public void GivenMemberWithNoAddress_WhenCreateMember_ThenMemberIsNullObject()
        {
            //given
            var firstName = "firstName";
            var lastName = "lastName";


            //when
            var member = Member.CreateMember(firstName, lastName, null);

            //then
            Assert.Null(member);
        }
    }
}
