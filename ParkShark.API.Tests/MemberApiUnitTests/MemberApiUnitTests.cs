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
            AddressDTO addressDTO = new AddressDTO { StreetName = "test", StreetNumber = "5", ZIP = 2050 };
            MemberDTO_Create newMemDTOO = new MemberDTO_Create() { FirstName = "lars", LastName = "ff", Address = addressDTO };

            var newMapper = new MemberMapper(new AddressMapper());
            var result = newMapper.DTOToMember(newMemDTOO);

            Assert.IsType<Member>(result);
        }

        [Fact]
        public void GivenCreateMembenDTOReturnFromMember_WhenGivenAMemberToCreate_ThenCreateAMemberDTOReturn()
        {
            var newMem = Member.CreateMember("lars", "Peelman", Address.CreateAddress("test", "5", 2050));

            var newMapper = new MemberMapper(new AddressMapper());
            var result = newMapper.MemberToDTOReturn(newMem);

            Assert.IsType<MemberDTO_Return>(result);
        }

        [Fact]
        public void GivenCreateDivisionDTOReturnListFromDivisionList_WhenGivenADivisionList_ThenCreateADivisionDTOReturnList()
        {
            var newMem = Member.CreateMember("lars", "Peelman", Address.CreateAddress("test", "5", 2050));
            var newMem2 = Member.CreateMember("lsdsars", "Pesdelman", Address.CreateAddress("test", "5", 2050));
            var testList = new List<Member>();
            testList.Add(newMem);
            testList.Add(newMem2);

            var newMapper = new MemberMapper(new AddressMapper());
            var result = newMapper.MemberListToDTOReturnList(testList);

            Assert.IsType<List<MemberDTO_Return>>(result);
        }

        [Fact]
        public void GivenCreateAdressDTOFromAddress_WhenGivenAnAddressToCreate_ThenCreateAddressDTO()
        {
            Address address = Address.CreateAddress(  "test",  "5", 2050 );

            var newMapper = new AddressMapper();
            var result = newMapper.AddressToDTO(address);

            Assert.IsType<AddressDTO>(result);
        }

        [Fact]
        public void GivenCreateAdressFromAddressDTO_WhenGivenAnAddressDTOToCreate_ThenCreateAddress()
        {
            AddressDTO addressDTO = new AddressDTO { StreetName = "test", StreetNumber = "5", ZIP = 2050 };

            var newMapper = new AddressMapper();
            var result = newMapper.DTOToAddress(addressDTO);

            Assert.IsType<Address>(result);
        }
    }
}
