using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.Members.DTO
{
    public class MembershipLevelDTO
    {
        public string Membership { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal MonthlyCost { get; set; }
        public double PSAPriceReductionPercentage { get; set; }
        public TimeSpan PSAMaxTimeInHours { get; set; }
    }
}
