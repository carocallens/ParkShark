using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Domain.Members
{
    public class MembershipLevel
    {
        public MembershipLevelEnum MemberShipLevelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal MonthlyCost { get; set; }
        public double PSAPriceReductionPercentage { get; set; }
        public TimeSpan PSAMaxTimeInHours { get; set; }
        public List<Member> Members { get; set; } = new List<Member>();

        public MembershipLevel()
        {            
        }
    }
}
