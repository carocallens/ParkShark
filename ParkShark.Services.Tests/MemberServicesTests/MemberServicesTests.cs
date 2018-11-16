using Microsoft.EntityFrameworkCore;
using ParkShark.Data;
using ParkShark.Domain.Members;
using ParkShark.Services.Members;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParkShark.Services.Tests.MemberServicesTests
{
    public class MemberServicesTests
    {
        private static DbContextOptions CreateNewInMemoryDatabase()
        {
            return new DbContextOptionsBuilder<ParkSharkDbContext>()
                .UseInMemoryDatabase("DivisionDb" + Guid.NewGuid().ToString("N"))
                .Options;
        }

        [Fact]
        public void GivenAddMemberToDBContext_WhenAddMemberToDbContext_ThenMemberIsAdded()
        {
            using (var context = new ParkSharkDbContext(CreateNewInMemoryDatabase()))
            {
                var newMem = Member.CreateMember("lars", "Peelman", Address.CreateAddress("test", "5", 2050));

                var service = new MemberService(context);
                var result = service.AddMemberToDBContext(newMem);

                Assert.IsType<Member>(result);
            }
        }

        [Fact]
        public void GivenHappyPath2_WhenAddingNewMemberToDb_ObjectIsAddedToDb()
        {
            using (var context = new ParkSharkDbContext(CreateNewInMemoryDatabase()))
            {
                var newMem = Member.CreateMember("lars", "Peelman", Address.CreateAddress("test", "5", 2050));

                var service = new MemberService(context);
                var result = service.AddMemberToDBContext(newMem);

                Assert.Single(service.GetAllMembers());
            }
        }


        [Fact]
        public void GivenGetAllMembers_WhenRequestingAllMembers_ThenReturnListOfAllMembers()
        {
            using (var context = new ParkSharkDbContext(CreateNewInMemoryDatabase()))
            {

                context.Set<Member>().Add(Member.CreateMember("lars", "Peelman", Address.CreateAddress("test", "5", 2050)));
                context.Set<Member>().Add(Member.CreateMember("laeeers", "ee", Address.CreateAddress("test", "5", 2050)));
                context.SaveChanges();

                var service = new MemberService(context);
                var result = service.GetAllMembers().Count;
                Assert.Equal(2, result);

            }
        }

        [Fact]
        public void GivenGetSingleMember_WhenRequestingSingleMember_ReturnRequestedMember()
        {
            using (var context = new ParkSharkDbContext(CreateNewInMemoryDatabase()))
            {
                var service = new MemberService(context);

                var newMem = Member.CreateMember("lars", "Peelman", Address.CreateAddress("test", "5", 2050));
                context.Set<Member>().Add(newMem);
                var id = newMem.MemberId;
                context.SaveChanges();

                var result = service.GetMember(id);

                Assert.IsType<Member>(result);
                Assert.Equal(id, result.MemberId);
                Assert.Equal("lars", result.FirstName);
                Assert.Equal("Peelman", result.LastName);
            }
        }

        [Fact]
        public void GivenGetSingleMemberUnHappyPath_WhenRequestingSingleMember_ReturnNull()
        {
            using (var context = new ParkSharkDbContext(CreateNewInMemoryDatabase()))
            {
                var service = new MemberService(context);

                var newMem = Member.CreateMember("lars", "Peelman", Address.CreateAddress("test", "5", 2050));
                context.Set<Member>().Add(newMem);
                var id = "kjekjlkzjzk";
                context.SaveChanges();

                var result = service.GetMember(id);

                Assert.Null(result);
            }
        }
    }
}
