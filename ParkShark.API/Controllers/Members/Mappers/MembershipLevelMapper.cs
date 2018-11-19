using ParkShark.API.Controllers.Members.DTO;
using ParkShark.API.Controllers.Members.Mappers.Interfaces;
using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.Members.Mappers
{
    public class MembershipLevelMapper : IMembershipLevelMapper
    {
        public MembershipLevel DTO_To_MembershipLevel(MembershipLevelDTO membershipLevelDTO)
        {
            return new MembershipLevel()
            {
                MembershipId = (MembershipLevelEnum)Enum.Parse(typeof(MembershipLevelEnum), membershipLevelDTO.Membership),
                Name = membershipLevelDTO.Name,
                MonthlyCost = membershipLevelDTO.MonthlyCost,
                PSAMaxTimeInHours = membershipLevelDTO.PSAMaxTimeInHours,
                PSAPriceReductionPercentage = membershipLevelDTO.PSAPriceReductionPercentage
            };
        }

        public MembershipLevelDTO MembershipLevel_To_DTO(MembershipLevel membershipLevel)
        {
            return new MembershipLevelDTO()
            {
                Membership = membershipLevel.MembershipId.ToString(),
                Name = membershipLevel.Name,
                MonthlyCost = membershipLevel.MonthlyCost,
                PSAMaxTimeInHours = membershipLevel.PSAMaxTimeInHours,
                PSAPriceReductionPercentage = membershipLevel.PSAPriceReductionPercentage
            };
        }
    }
}
