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


        public Member CreateNewMember(MemberCreationOptions member)
        {
            MembershipLevel levelOfMember = _parkSharkDBContext.MembershipLevel.SingleOrDefault(x => x.Membership == member.MembershipLevel);

            var newMember = Member.CreateMember(member.FirstName, member.LastName, member.Address, member.MembershipLevel, levelOfMember);

            _parkSharkDBContext.Add(newMember);
            _parkSharkDBContext.SaveChanges();

            return newMember;
        }

        public List<Member> GetAllMembers()
        {
            var MemberList = new List<Member>();
            var MemberDbSet = _parkSharkDBContext.Set<Member>();

            foreach (var member in MemberDbSet)
            {
                MemberList.Add(member);
            }

            return MemberList;
        }

        public Member GetMember(string memberID)
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
