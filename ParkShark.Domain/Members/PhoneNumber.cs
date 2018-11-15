using System;

namespace ParkShark.Domain.Members
{
    class PhoneNumber
    {
        public string MemberId { get; private set; }
        public string PhoneNumberValue { get; private set; }

        public PhoneNumber(string memberId, string phoneNumberValue)
        {
            MemberId = memberId;
            PhoneNumberValue = phoneNumberValue;
        }
    }
}
