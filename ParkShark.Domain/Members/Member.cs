using System;
using System.Collections.Generic;
using System.Text;


namespace ParkShark.Domain.Members
{
    public class Member
    {
        public Guid MemberId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Address Address { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public MembershipLevelEnum MembershipLevelId { get; set; }
        public MembershipLevel MembershipLevel { get; set; }
        public List<PhoneNumber> ListOfPhones { get; set; } = new List<PhoneNumber>();
        public List<LicensePlate> ListOfplates { get; set; } = new List<LicensePlate>();

        private Member()
        {
        }

        private Member(string firstName, string lastName, Address address, MembershipLevelEnum membershipLevelEnum, MembershipLevel membershipLevel)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            RegistrationDate = DateTime.Now;
            MembershipLevelId = membershipLevelEnum;
            MembershipLevel = membershipLevel;
        }

        public static Member CreateMember(string firstName, string lastName, Address address,MembershipLevelEnum membershipLevelEnum, MembershipLevel membershipLevel)
        {
            if (string.IsNullOrWhiteSpace(firstName)|| string.IsNullOrWhiteSpace(lastName) || address == null ||  membershipLevel == null)
            {
                return null;
            }

            return new Member(firstName, lastName, address, membershipLevelEnum, membershipLevel);
        }
    }
}
