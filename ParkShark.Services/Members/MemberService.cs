using Microsoft.EntityFrameworkCore;
using ParkShark.Data;
using ParkShark.Domain.Members;
using ParkShark.Services.Members.Interfaces;
using System;
using System.Collections.Generic;
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

        public Member AddMemberToDBContext(Member member)
        {
            _parkSharkDBContext.Add(member);
            _parkSharkDBContext.SaveChanges();

            return member;
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
    }
}
