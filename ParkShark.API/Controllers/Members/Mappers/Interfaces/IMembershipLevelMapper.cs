using ParkShark.API.Controllers.Members.DTO;
using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.Members.Mappers.Interfaces
{
    public interface IMembershipLevelMapper
    {
        MembershipLevel DTO_To_MembershipLevel(MembershipLevelDTO membershipLevelDTO);
        MembershipLevelDTO MembershipLevel_To_DTO(MembershipLevel membershipLevel);
    }
}
