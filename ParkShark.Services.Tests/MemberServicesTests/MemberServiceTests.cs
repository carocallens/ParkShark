using Microsoft.EntityFrameworkCore;
using ParkShark.Data;
using ParkShark.Domain.Members;
using ParkShark.Services.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ParkShark.Services.Tests.MemberServicesTests
{
    public class MemberServiceTests
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
                context.Set<MembershipLevel>().Add(new MembershipLevel() { MemberShipLevelId = 0, Name = "Bronze", MonthlyCost = 0, PSAPriceReductionPercentage = 0, PSAMaxTimeInHours = new TimeSpan(4, 0, 0) });
                context.SaveChanges();

                var city = City.CreateCity(2050, "Antwerpen", "Belgium");

                var service = new MemberService(context);

                var newMem = new DummyMemberObject() { FirstName = "lars", LastName = "Peelman", Address = Address.CreateAddress("test", "5", city), MembershipLevel = MembershipLevelEnum.Bronze };

                var result = service.CreateNewMember(newMem);

                Assert.IsType<Member>(result);
            }
        }

        [Fact]
        public void GivenHappyPath2_WhenAddingNewMemberToDb_ObjectIsAddedToDb()
        {
            using (var context = new ParkSharkDbContext(CreateNewInMemoryDatabase()))
            {
                context.Set<MembershipLevel>().Add(new MembershipLevel() { MemberShipLevelId = 0, Name = "Bronze", MonthlyCost = 0, PSAPriceReductionPercentage = 0, PSAMaxTimeInHours = new TimeSpan(4, 0, 0) });
                context.SaveChanges();

                var city = City.CreateCity(2050, "Antwerpen", "Belgium");

                var newMem = new DummyMemberObject() { FirstName = "lars", LastName = "Peelman", Address = Address.CreateAddress("test", "5", city), MembershipLevel = MembershipLevelEnum.Bronze };

                var service = new MemberService(context);
                var result = service.CreateNewMember(newMem);

                Assert.Single(service.GetAllMembers());
            }
        }


        [Fact]
        public void GivenGetAllMembers_WhenRequestingAllMembers_ThenReturnListOfAllMembers()
        {
            using (var context = new ParkSharkDbContext(CreateNewInMemoryDatabase()))
            {
                var MemLev = new MembershipLevel();
                var city = City.CreateCity(2050, "Antwerpen", "Belgium");

                context.Set<Member>().Add(Member.CreateMember("lars", "Peelman", Address.CreateAddress("test", "5", city), MembershipLevelEnum.Bronze, MemLev));
                context.Set<Member>().Add(Member.CreateMember("laeeers", "ee", Address.CreateAddress("test", "5", city), MembershipLevelEnum.Bronze, MemLev));
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
                var MemLev = new MembershipLevel();
                var city = City.CreateCity(2050, "Antwerpen", "Belgium");

                var newMem = Member.CreateMember("lars", "Peelman", Address.CreateAddress("test", "5", city), MembershipLevelEnum.Gold, MemLev);
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
                var MemLev = new MembershipLevel();
                var city = City.CreateCity(2050, "Antwerpen", "Belgium");
                var newMem = Member.CreateMember("lars", "Peelman", Address.CreateAddress("test", "5", city), MembershipLevelEnum.Gold, MemLev);
                context.Set<Member>().Add(newMem);
                var id = Guid.NewGuid();
                context.SaveChanges();

                var result = service.GetMember(id);

                Assert.Null(result);
            }
        }
    }
}
