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

        public MemberMapper(IAddressMapper addressMapper, IMembershipLevelMapper membershipLevelMapper)
        {
            _addressMapper = addressMapper;
            _membershipLevelMapper = membershipLevelMapper;
        }

        public DummyMemberObject DTOToDummyMemberObject(MemberDTO_Create memberDTO)
        {
            MembershipLevelEnum memLevel;

            try
            {
                memLevel = (MembershipLevelEnum)Enum.Parse(typeof(MembershipLevelEnum), memberDTO.MembershipLevel);
            }
            catch
            {
                memLevel = MembershipLevelEnum.Bronze;
            }


            return new DummyMemberObject()
            {
                FirstName = memberDTO.FirstName,
                LastName = memberDTO.LastName,
                Address = _addressMapper.DTOToAddress(memberDTO.Address),
                MembershipLevel = memLevel
            };
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
                MembershipLevel = _membershipLevelMapper.MembershipLevel_To_DTO(member.MembershipLevel)
            };
        }
    }
}
