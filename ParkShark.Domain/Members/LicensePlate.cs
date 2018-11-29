using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Domain.Members
{
    public class LicensePlate
    {
        public Guid MemberId { get; private set; }
        public Member Member { get; private set; }
        public string LicensePlateValue { get; private set; }
        public string IssueingCountry { get; private set; }

        private LicensePlate()
        {
        }

        private LicensePlate(Guid memberId, string licensePlateValue, string issueingCountry)
        {
            MemberId = memberId;
            LicensePlateValue = licensePlateValue;
            IssueingCountry = issueingCountry;
        }

        public static LicensePlate CreateLicensePlate(Guid memberId, string licensePlateValue, string issueingCountry)
        {
            //Throw validation exception, not return null, make it explicit that the consumer has made an error
            if (memberId == null|| string.IsNullOrWhiteSpace(licensePlateValue) || string.IsNullOrWhiteSpace(issueingCountry))
            {
                return null;
            }

            return new LicensePlate(memberId, licensePlateValue, issueingCountry);
        }
    }
}
