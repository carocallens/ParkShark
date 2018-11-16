using System;

namespace ParkShark.Domain.Members
{
    public class PhoneNumber
    {
        public string MemberId { get; private set; }
        public Member Member { get; private set; }
        public string PhoneNumberValue { get; private set; }

        private PhoneNumber()
        {
        }

        public PhoneNumber(string memberId, string phoneNumberValue)
        {
            MemberId = memberId;
            PhoneNumberValue = phoneNumberValue;
        }
    }
}
