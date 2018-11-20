using ParkShark.API.Controllers.Members.DTO;
using ParkShark.API.Controllers.Members.Mappers;
using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParkShark.API.Tests.MemberApiUnitTests
{
    public class MemberApiUnitTests
    {

        [Fact]
        public void GivenCreateMemberFromMemberDTOCreate_WhenGivenAMemberDTOCreate_ThenCreateAMember()
        {
            CityDTO cityDTO = new CityDTO { ZIP = 2050, CityName = "Antwerpen", CountryName = "Belgium" };
            AddressDTO addressDTO = new AddressDTO { StreetName = "test", StreetNumber = "5", CityDTO =  cityDTO };
            MemberDTO_Create newMemDTOO = new MemberDTO_Create() { FirstName = "lars", LastName = "ff", Address = addressDTO };

            var newMapper = new MemberMapper(new AddressMapper(new CityMapper()), new MembershipLevelMapper());
            var result = newMapper.DTOToDummyMemberObject(newMemDTOO);

            Assert.IsType<DummyMemberObject>(result);
        }

        [Fact]
        public void GivenCreateMembenDTOReturnFromMember_WhenGivenAMemberToCreate_ThenCreateAMemberDTOReturn()
        {
            City city = City.CreateCity(2050, "Antwerpen", "Belgium");
            var MemberShipLevel = new MembershipLevel();
            var newMem = Member.CreateMember("lars", "Peelman", Address.CreateAddress("test", "5", city), MembershipLevelEnum.Gold, MemberShipLevel);

            var newMapper = new MemberMapper(new AddressMapper(new CityMapper()), new MembershipLevelMapper());
            var result = newMapper.MemberToDTOReturn(newMem);

            Assert.IsType<MemberDTO_Return>(result);
        }

        [Fact]
        public void GivenCreateDivisionDTOReturnListFromDivisionList_WhenGivenADivisionList_ThenCreateADivisionDTOReturnList()
        {
            City city = City.CreateCity(2050, "Antwerpen", "Belgium");
            var MemberShipLevel = new MembershipLevel();
            var newMem = Member.CreateMember("lars", "Peelman", Address.CreateAddress("test", "5", city), MembershipLevelEnum.Gold, MemberShipLevel);
            var newMem2 = Member.CreateMember("lsdsars", "Pesdelman", Address.CreateAddress("test", "5", city), MembershipLevelEnum.Gold, MemberShipLevel);
            var testList = new List<Member>();
            testList.Add(newMem);
            testList.Add(newMem2);

            var newMapper = new MemberMapper(new AddressMapper(new CityMapper()), new MembershipLevelMapper());
            var result = newMapper.MemberListToDTOReturnList(testList);

            Assert.IsType<List<MemberDTO_Return>>(result);
        }

        [Fact]
        public void GivenCreateAdressDTOFromAddress_WhenGivenAnAddressToCreate_ThenCreateAddressDTO()
        {
            City city = City.CreateCity(2050, "Antwerpen", "Belgium");
            Address address = Address.CreateAddress("test", "5", city);

            var newMapper = new AddressMapper(new CityMapper());
            var result = newMapper.AddressToDTO(address);

            Assert.IsType<AddressDTO>(result);
        }

        [Fact]
        public void GivenCreateAdressFromAddressDTO_WhenGivenAnAddressDTOToCreate_ThenCreateAddress()
        {
            CityDTO cityDTO = new CityDTO { ZIP = 2050, CityName = "Antwerpen", CountryName = "Belgium" };
            AddressDTO addressDTO = new AddressDTO { StreetName = "test", StreetNumber = "5", CityDTO = cityDTO};

            var newMapper = new AddressMapper(new CityMapper());
            var result = newMapper.DTOToAddress(addressDTO);

            Assert.IsType<Address>(result);
        }
    }
}
