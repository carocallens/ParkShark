using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Domain.Members
{
    public class MembershipLevel
    {
        public MembershipLevelEnum MembershipId { get; set; }
        public string Name { get; set; }
        public decimal MonthlyCost { get; set; }
        public float PSAPriceReductionPercentage { get; set; }
        public TimeSpan PSAMaxTimeInHours { get; set; }
        public List<Member> Members { get; set; }

        public MembershipLevel()
        {
            Members = new List<Member>();
        }
    }
}
