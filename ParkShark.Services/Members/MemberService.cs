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

            Member newMember = CreateMemberFromDummyMemberAndMembershipLevel(dummyMember, membershipLevel);

            if (newMember == null)
            {
                return null;
            }

            _parkSharkDBContext.Add(newMember);
            _parkSharkDBContext.SaveChanges();

            return newMember;
        }

        private static Member CreateMemberFromDummyMemberAndMembershipLevel(DummyMemberObject dummyMember, MembershipLevel membershipLevel)
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

            foreach (var member in MemberDbSet.Include(m => m.MembershipLevel).Include(m =>m.Address).ThenInclude(c => c.City))
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
