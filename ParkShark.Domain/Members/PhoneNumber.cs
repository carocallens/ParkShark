using System;

namespace ParkShark.Domain.Members
{
    public class PhoneNumber
    {
        public Guid MemberId { get; private set; }
        public Member Member { get; private set; }
        public string PhoneNumberValue { get; private set; }

        private PhoneNumber()
        {
        }

        private PhoneNumber(Guid memberId, string phoneNumberValue)
        {
            MemberId = memberId;
            PhoneNumberValue = phoneNumberValue;
        }

        public static PhoneNumber CreatePhoneNumber(Guid memberId, string phoneNumberValue)
        {
            if(string.IsNullOrWhiteSpace(phoneNumberValue))
            {
                return null;
            }
            return new PhoneNumber(memberId, phoneNumberValue);
        }
    }
}
