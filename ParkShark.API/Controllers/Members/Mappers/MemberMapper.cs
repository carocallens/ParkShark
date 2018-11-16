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

        public MemberMapper(IAddressMapper addressMapper)
        {
            _addressMapper = addressMapper;
        }

        public Member DTOToMember(MemberDTO_Create memberDTO)
        {
            return Member.CreateMember(
                memberDTO.FirstName, 
                memberDTO.LastName, 
                _addressMapper.DTOToAddress(memberDTO.Address)
                );
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
                Address = _addressMapper.AddressToDTO(member.Address)
            };
        }
    }
}
