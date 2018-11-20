using Microsoft.EntityFrameworkCore;
using ParkShark.Data;
using ParkShark.Domain.Members;
using ParkShark.Services.Members.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkShark.Services.Members
{
    public class MemberService : IMemberServices
    {
        private readonly ParkSharkDbContext _parkSharkDBContext;

        public MemberService(ParkSharkDbContext memberDBContext)
        {
            _parkSharkDBContext = memberDBContext;
        }


        public Member CreateNewMember(DummyMemberObject dummyMember)
        {
            MembershipLevel membershipLevel = AssignMembershipLevelFromDummyMember(dummyMember);

            if (membershipLevel == null)
            {
                return null;
            }

            Member newMember = CreateMemberFromDummyObjectsAndMembershipLevel(dummyMember, membershipLevel);
            if (newMember == null)
            {
                return null;
            }
            _parkSharkDBContext.Add(newMember);
            _parkSharkDBContext.SaveChanges();

            return newMember;
        }

        public bool AddPhonenumersAndLicensPlatesToMember(DummyMemberObject dummyMember, Member givenMember)
        {
            try
            {
                List<PhoneNumber> listOfNumbers = CreatePhonenumberList(dummyMember, givenMember);
                List<LicensePlate> listOfLicensePlates = CreateLicensePlatesList(dummyMember, givenMember);

                _parkSharkDBContext.AddRange(listOfNumbers);
                _parkSharkDBContext.AddRange(listOfLicensePlates);
                _parkSharkDBContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        private List<LicensePlate> CreateLicensePlatesList(DummyMemberObject dummyMember, Member member)
        {
            List<LicensePlate> plates = new List<LicensePlate>();
            foreach (var item in dummyMember.LicensePlate)
            {
                plates.Add(LicensePlate.CreateLicensePlate(member.MemberId, item.LicensePlateValue, item.IssueingCountry));
            }
            return plates;
        }

        private List<PhoneNumber> CreatePhonenumberList(DummyMemberObject dummyMember, Member member)
        {
            List<PhoneNumber> phones = new List<PhoneNumber>();
            foreach (var item in dummyMember.PhoneNumber)
            {
                phones.Add(PhoneNumber.CreatePhoneNumber(member.MemberId, item.PhoneNumberValue));
            }
            return phones;
        }

        private static Member CreateMemberFromDummyObjectsAndMembershipLevel(DummyMemberObject dummyMember, MembershipLevel membershipLevel)
        {
            return Member.CreateMember(
                    dummyMember.FirstName,
                    dummyMember.LastName,
                    dummyMember.Address,
                    dummyMember.MembershipLevel,
                    membershipLevel
                    );
        }

        private MembershipLevel AssignMembershipLevelFromDummyMember(DummyMemberObject dummyMember)
        {
            return _parkSharkDBContext
                    .Set<MembershipLevel>()
                    .FirstOrDefault(x => x.MemberShipLevelId == dummyMember.MembershipLevel);
        }

        public List<Member> GetAllMembers()
        {
            var MemberList = new List<Member>();
            var MemberDbSet = _parkSharkDBContext.Set<Member>();

            foreach (var member in MemberDbSet.Include(m => m.MembershipLevel).Include(m => m.Address).ThenInclude(c => c.City))
            {
                MemberList.Add(member);
            }

            return MemberList;
        }

        public Member GetMember(Guid memberID)
        {
            var member = _parkSharkDBContext.Members.SingleOrDefault(x => x.MemberId == memberID);

            if (member == null)
            {
                return null;
            }

            return member;

        }

    }
}
