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

        private PhoneNumber(string memberId, string phoneNumberValue)
        {
            MemberId = memberId;
            PhoneNumberValue = phoneNumberValue;
        }

        public static PhoneNumber CreatePhoneNumber(string memberId, string phoneNumberValue)
        {
            if (string.IsNullOrWhiteSpace(memberId) || string.IsNullOrWhiteSpace(phoneNumberValue))
            {
                return null;
            }
            return new PhoneNumber(memberId, phoneNumberValue);
        }
    }
}
