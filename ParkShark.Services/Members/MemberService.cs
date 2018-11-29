using Microsoft.EntityFrameworkCore;
using ParkShark.Data;
using ParkShark.Domain.Members;
using ParkShark.Services.Members.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //You're assuming givenMember is a tracked entity, while it could easily be outside of the context
        //Either create the entire Member graph (including its list of numbers and license plates) in one method and .SaveChanges, or use a transaction
        //Possible hazard of having inconsistent data (Member was saved, phone numbers weren't)
        public bool AddPhonenumersAndLicensPlatesToMember(DummyMemberObject dummyMember, Member givenMember)
        {
            try
            {
                List<PhoneNumber> listOfNumbers =  CreatePhonenumberList(dummyMember, givenMember);
                List<LicensePlate> listOfLicensePlates =  CreateLicensePlatesList(dummyMember, givenMember);

                _parkSharkDBContext.AddRangeAsync(listOfNumbers);
                _parkSharkDBContext.AddRangeAsync(listOfLicensePlates);
                _parkSharkDBContext.SaveChanges();
                return true;
            }
            catch
            {
                //Catch return false should be used in exceptional circumstances, use a transaction with rollback instead
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

        //Only require what you need, you don't need the entire Member object, just its MemberId, refactor the parameter and make life (and testing) easier
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
                    //Usage of Set for entities you don't want to expose, good job!
                    .Set<MembershipLevel>()
                    .FirstOrDefault(x => x.MemberShipLevelId == dummyMember.MembershipLevel);
        }

        public List<Member> GetAllMembers()
        {
            var MemberList = new List<Member>();
            var MemberDbSet = _parkSharkDBContext.Set<Member>();
            
            //Unnecessary foreach, use _parkSharkDBContext.Set<Member>().ToList(), no iteration required

            foreach (var member in MemberDbSet.Include(m => m.MembershipLevel).Include(m => m.Address).ThenInclude(c => c.City).Include(p => p.ListOfPhones).Include(l => l.ListOfplates))
            {
                MemberList.Add(member);
            }

            return MemberList;
        }

        public Member GetMember(Guid memberID)
        {
            var member = _parkSharkDBContext.Members
                .Include(m => m.Address)
                .ThenInclude(c => c.City)
                .Include(ml => ml.MembershipLevel)
                .Include(p => p.ListOfPhones)
                .Include(l => l.ListOfplates)
                //Use Find or FindAsync
                .SingleOrDefault(x => x.MemberId == memberID);

            if (member == null)
            {
                return null;
            }

            return member;

        }

        public City ZIPExistsInDB(int zip)
        {
            //Method name should be GetZipOrDefault or TryGetZip, because it could return NULL
            //Or return a boolean
            return _parkSharkDBContext.Set<City>().SingleOrDefault(x => x.ZIP == zip);
        }
    }
}
