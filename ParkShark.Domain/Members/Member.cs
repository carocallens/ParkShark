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
        //A bit of over-engineering, A Member has one phone and a mobile phone
        public List<PhoneNumber> ListOfPhones { get; set; } = new List<PhoneNumber>();
        //List of plates is not a functional requirement, this join is unnecessary
        //A Member has one license plate (functionally speaking)
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

        public static Member CreateMember(string firstName, string lastName, Address address, MembershipLevelEnum membershipLevelEnum, MembershipLevel membershipLevel)
        {
            //Throw validation exception, not return null, make it explicit that the consumer has made an error
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || address == null || membershipLevel == null)
            {
                return null;
            }

            return new Member(firstName, lastName, address, membershipLevelEnum, membershipLevel);
        }
    }
}
