//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xunit;
//using ParkShark.Domain.Members;

//namespace ParkShark.Domain.Tests.Members
//{
//    public class PhoneNumberTests
//    {
//        [Fact]
//        public void GivenHappyPath_WhenCreatePhoneNumber_ThenPhoneNumberIsCreated()
//        {
//            var address = Address.CreateAddress("sn", "sn", 1234);
//            var member = Member.CreateMember("fn", "ln", address);
//            var phoneNumberValue = "0472 80 50 40";

//            var PhoneNumberObject = PhoneNumber.CreatePhoneNumber(member.MemberId, phoneNumberValue);

//            Assert.NotNull(PhoneNumberObject);
//        }

//        [Fact]
//        public void GivenPhoneNumberWithNoPhoneNumberValue_WhenCreatePhoneNumber_ThenPhoneNumberIsNullObject()
//        {
//        var address = Address.CreateAddress("sn", "sn", 1234);
//        var member = Member.CreateMember("fn", "ln", address);
//        var phoneNumberValue = "0472 80 50 40";

//        var PhoneNumberObject = PhoneNumber.CreatePhoneNumber(member.MemberId, null);

//        Assert.Null(PhoneNumberObject);
//        }

//        //memberId filled in but invalid

//    }
//}
