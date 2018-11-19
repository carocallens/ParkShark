using ParkShark.API.Controllers.Members.DTO;
using ParkShark.Domain.Members;
using System.Collections.Generic;

namespace ParkShark.API.Controllers.Members.Mappers.Interfaces
{
    public interface IMemberMapper
    {
        MemberCreationOptions DTOToMemberCriationOptions(MemberDTO_Create memberDTO);
        MemberDTO_Return MemberToDTOReturn(Member member);
        List<MemberDTO_Return> MemberListToDTOReturnList(List<Member> MemberList);
    }
}
