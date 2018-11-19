using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParkShark.Domain.Tests.Members
{
    public class PhoneNumberTests
    {
        [Fact]
        public void GivenHappyPath_WhenCreatePhoneNumber_ThenPhoneNumberIsCreated()
        {
            var address = Address.CreateAddress("sn", "sn", 1234);
            var memLevel = new MembershipLevel();
            var member = Member.CreateMember(
                            "fn",
                            "ln",
                            address,
                            MembershipLevelEnum.Bronze,
                            memLevel
                            );
            var phoneNumberValue = "0472 80 50 40";

            var PhoneNumberObject = PhoneNumber.CreatePhoneNumber(member.MemberId, phoneNumberValue);

            Assert.NotNull(PhoneNumberObject);
        }

        [Fact]
        public void GivenPhoneNumberWithOutMemberId_WhenCreatePhoneNumber_ThenPhoneNumberIsNullObject()
        {
            var address = Address.CreateAddress("sn", "sn", 1234);
            var member = Member.CreateMember(
                                "fn",
                                "ln",
                                address,
                                MembershipLevelEnum.Bronze,
                                new MembershipLevel()
                                );
            var phoneNumberValue = "0472 80 50 40";

            var PhoneNumberObject = PhoneNumber.CreatePhoneNumber(Guid.Empty, phoneNumberValue);

            Assert.Null(PhoneNumberObject);
        }

        [Fact]
        public void GivenPhoneNumberWithNoPhoneNumberValue_WhenCreatePhoneNumber_ThenPhoneNumberIsNullObject()
        {
            var address = Address.CreateAddress("sn", "sn", 1234);
            var member = Member.CreateMember(
                            "fn",
                            "ln",
                            address,
                            MembershipLevelEnum.Bronze,
                            new MembershipLevel()
                            );

            var PhoneNumberObject = PhoneNumber.CreatePhoneNumber(member.MemberId, null);

            Assert.Null(PhoneNumberObject);
        }

        //memberId filled in but invalid

    }
}
