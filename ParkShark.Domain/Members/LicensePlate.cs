using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Domain.Members
{
    public class LicensePlate
    {
        public string MemberId { get; private set; }
        public string LicensePlateValue { get; private set; }
        public string IssueingCountry { get; private set; }

        private LicensePlate(string memberId, string licensePlateValue, string issueingCountry)
        {
            MemberId = memberId;
            LicensePlateValue = licensePlateValue;
            IssueingCountry = issueingCountry;
        }

        public static LicensePlate CreateLicensePlate(string memberId, string licensePlateValue, string issueingCountry)
        {
            if (string.IsNullOrWhiteSpace(memberId)|| string.IsNullOrWhiteSpace(licensePlateValue) || string.IsNullOrWhiteSpace(issueingCountry))
            {
                return null;
            }

            return new LicensePlate(memberId, licensePlateValue, issueingCountry);
        }
    }
}
