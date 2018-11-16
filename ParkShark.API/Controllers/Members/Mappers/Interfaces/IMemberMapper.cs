using ParkShark.API.Controllers.Members.DTO;
using ParkShark.Domain.Members;

namespace ParkShark.API.Controllers.Members.Mappers.Interfaces
{
    public interface IMemberMapper
    {
        Member DTOToMember(MemberDTO_Create memberDTO);
        MemberDTO_Return MemberToDTOReturn(Member member);
    }
}
