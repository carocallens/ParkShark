using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.Domain.Members
{
    public class DummyMemberObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public MembershipLevelEnum MembershipLevel { get; set; }
    }
}

