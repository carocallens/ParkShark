using ParkShark.API.Controllers.Members.DTO;
using ParkShark.API.Controllers.Members.Mappers.Interfaces;
using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.Members.Mappers
{
    public class MemberMapper : IMemberMapper
    {
        private readonly IAddressMapper _addressMapper;
        private readonly IMembershipLevelMapper _membershipLevelMapper;
        private readonly ILicensePlateMapper _licensePlateMapper;
        private readonly IPhoneNumpberMapper _phoneNumpberMapper;


        public MemberMapper(IAddressMapper addressMapper, IMembershipLevelMapper membershipLevelMapper, ILicensePlateMapper licensePlateMapper, IPhoneNumpberMapper phoneNumpberMapper)
        {
            _addressMapper = addressMapper;
            _membershipLevelMapper = membershipLevelMapper;
            _licensePlateMapper = licensePlateMapper;
            _phoneNumpberMapper = phoneNumpberMapper;
        }

        public DummyMemberObject DTOToDummyMemberObject(MemberDTO_Create memberDTO)
        {
            MembershipLevelEnum memberShipLevel = GetMemberShipLevel(memberDTO);

            return new DummyMemberObject()
            {
                FirstName = memberDTO.FirstName,
                LastName = memberDTO.LastName,
                MembershipLevel = memberShipLevel,
                Address = _addressMapper.DTOToAddress(memberDTO.Address),
                LicensePlate = _licensePlateMapper.DTOListToLicensePlateObject(memberDTO.LicensePlate),
                PhoneNumber = _phoneNumpberMapper.DTOListToPhoneNumpberObject(memberDTO.PhoneNumber)
            };
        }

        private static MembershipLevelEnum GetMemberShipLevel(MemberDTO_Create memberDTO)
        {
            MembershipLevelEnum memberShipLevel;

            try
            {
                //Please use TryParse to handle incorrect parsing
                //Try-catch creates a virtual sandbox for your code, this creates compiler overhead, try to avoid this
                memberShipLevel = (MembershipLevelEnum)Enum.Parse(typeof(MembershipLevelEnum), memberDTO.MembershipLevel);
            }
            catch
            {
                memberShipLevel = MembershipLevelEnum.Bronze;
            }

            return memberShipLevel;
        }

        public List<MemberDTO_Return> MemberListToDTOReturnList(List<Member> MemberList)
        {
            var MemberDTO_ReturnList = new List<MemberDTO_Return>();

            foreach (Member member in MemberList)
            {
                var MemberDTO_Return = MemberToDTOReturn(member);
                MemberDTO_ReturnList.Add(MemberDTO_Return);
            }

            return MemberDTO_ReturnList;
        }

        public MemberDTO_Return MemberToDTOReturn(Member member)
        {
            return new MemberDTO_Return
            {
                Id = member.MemberId,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Address = _addressMapper.AddressToDTO(member.Address),
                MembershipLevel = _membershipLevelMapper.MembershipLevel_To_DTO(member.MembershipLevel),
                LicensePlate = _licensePlateMapper.LicensePlateListToDTO(member.ListOfplates),
                PhoneNumber = _phoneNumpberMapper.PhoneNumpberListToDTO(member.ListOfPhones)
            };
        }
    }
}
