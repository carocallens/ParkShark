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
                MemberShipLevelId = (MembershipLevelEnum)Enum.Parse(typeof(MembershipLevelEnum), membershipLevelDTO.Membership),
                Name = membershipLevelDTO.Name,
                Description = membershipLevelDTO.Description,
                MonthlyCost = membershipLevelDTO.MonthlyCost,
                PSAMaxTimeInHours = membershipLevelDTO.PSAMaxTimeInHours,
                PSAPriceReductionPercentage = membershipLevelDTO.PSAPriceReductionPercentage
            };
        }

        public MembershipLevelDTO MembershipLevel_To_DTO(MembershipLevel membershipLevel)
        {
            return new MembershipLevelDTO()
            {
                Membership = membershipLevel.MemberShipLevelId.ToString(),
                Name = membershipLevel.Name,
                Description = membershipLevel.Description,
                MonthlyCost = membershipLevel.MonthlyCost,
                PSAMaxTimeInHours = membershipLevel.PSAMaxTimeInHours,
                PSAPriceReductionPercentage = membershipLevel.PSAPriceReductionPercentage
            };
        }
    }
}
