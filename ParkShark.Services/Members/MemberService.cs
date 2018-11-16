using Microsoft.EntityFrameworkCore;
using ParkShark.Domain.Members;
using ParkShark.Domain.Members.Repository;
using ParkShark.Services.Members.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Services.Members
{
    public class MemberService : IMemberServices
    {
        private readonly MemberDbContext _memberDBContext;

        public MemberService(MemberDbContext memberDBContext)
        {
            _memberDBContext = memberDBContext;
        }

        public Member AddMemberToDBContext(Member member)
        {
            _memberDBContext.Add(member);
            _memberDBContext.SaveChanges();

            return member;
        }

        public List<Member> GetAllMembers()
        {
            var MemberList = new List<Member>();
            var MemberDbSet = _memberDBContext.Set<Member>();

            foreach (var member in MemberDbSet)
            {
                MemberList.Add(member);
            }

            return MemberList;
        }
    }
}
