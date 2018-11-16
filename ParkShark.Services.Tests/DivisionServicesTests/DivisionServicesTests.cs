using Microsoft.EntityFrameworkCore;
using NSubstitute;
using ParkShark.Domain.Divisions;
using ParkShark.Domain.Divisions.Repository;
using ParkShark.Services.Divisions;
using ParkShark.Services.Divisions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParkShark.Services.Tests.DivisionServicesTests
{
    public class DivisionServicesTests
    {

        private static DbContextOptions CreateNewInMemoryDatabase()
        {
            return new DbContextOptionsBuilder<DivisionDbContext>()
                .UseInMemoryDatabase("DivisionDb" + Guid.NewGuid().ToString("N"))
                .Options;
        }

        [Fact]
        public void GivenHappyPath1_WhenAddingNewDivisionToDb_ObjectIsFlushedAndReturned()
        {
            using (var context = new DivisionDbContext(CreateNewInMemoryDatabase()))
            {
                var newDiv = Division.CreateNewDivision("test", "testorg", "lars");

                var service = new DivisionServices(context);
                var result = service.AddDivisionToDBbContext(newDiv);

                Assert.IsType<Division>(result);
            }
        }


        [Fact]
        public void GivenGetSingledivision_WhenRequestingSingleDivision_ReturnRequestedDivision()
        {
            using (var context = new DivisionDbContext(CreateNewInMemoryDatabase()))
            {
                var service = new DivisionServices(context);

                var newDiv = Division.CreateNewDivision("test", "testorg", "lars");
                context.Set<Division>().Add(newDiv);
                var id = newDiv.GuidID;
                context.SaveChanges();



                var result = service.GetSingleDivision(id);

                Assert.IsType<Division>(result);
                Assert.Equal(id, result.GuidID);
                Assert.Equal("test", result.Name);
                Assert.Equal("testorg", result.OriginalName);
            }
        }
        [Fact]
        public void GivenGetSingledivisionUnHappyPath_WhenRequestingSingleDivision_ReturnNull()
        {
            using (var context = new DivisionDbContext(CreateNewInMemoryDatabase()))
            {
                var service = new DivisionServices(context);

                var newDiv = Division.CreateNewDivision("test", "testorg", "lars");
                context.Set<Division>().Add(newDiv);
                var id = "gehshhehh";
                context.SaveChanges();



                var result = service.GetSingleDivision(id);


                Assert.Null(result);
            }
        }

        [Fact]
        public void GivenGetAllDivisions_WhenRequestingAllDivisions_ThenReturnListOfAllDivisions()
        {
            using (var context = new DivisionDbContext(CreateNewInMemoryDatabase()))
            {

                context.Set<Division>().Add(Division.CreateNewDivision("test", "testorg", "lars"));
                context.Set<Division>().Add(Division.CreateNewDivision("test2", "testorg2", "lars"));
                context.SaveChanges();

                var service = new DivisionServices(context);
                var result = service.GetAllDivisions().Count;
                Assert.Equal(2, result);

            }
        }

        [Fact]
        public void Given2Divisions_WhenAssigningParentTOSUb_SubdevisionIsReturnedWithParentGuidID()
        {
            var name = "Test1";
            var originalName = "Test1";
            string director = "test1";

            var parDivision = Division.CreateNewDivision(name, originalName, director);
            var subDivision = Division.CreateNewDivision(name, originalName, director);

            var result = DivisionServices.AssignParentDivision(subDivision, parDivision);


            Assert.Equal(parDivision.GuidID, subDivision.ParentDivisionGuidID);
        }

        [Fact]
        public void Given1Division_WhenAssigningGuidAsParentGuid_ParentGuidRemainsNull()
        {
            var division = Division.CreateNewDivision("name", "orgname", "director");

            var result = DivisionServices.AssignParentDivision(division, division);

            Assert.Equal(division.ParentDivisionGuidID, null);
            Assert.Null(result);
        }
    }


}