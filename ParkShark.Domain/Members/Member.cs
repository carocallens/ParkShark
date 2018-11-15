using System;
using System.Collections.Generic;
using System.Text;


namespace ParkShark.Domain.Members
{
    public class Member
    {
        public Guid MemberId { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string AddressId { get; private set; }
        public DateTime RegistrationDate { get; private set; }

        private Member(string firstName, string lastName, string addressId)
        {
            MemberId = new Guid();
            FirstName = firstName;
            LastName = lastName;
            AddressId = addressId;
            RegistrationDate = DateTime.Now;
        }

        public static Member CreateMember(string firstName, string lastName, string addressId)
        {
            if (firstName == null || lastName == null || addressId == null)
            {
                return null;
            }
            return new Member(firstName, lastName, addressId);
        }
    }
}
