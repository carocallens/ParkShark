using Microsoft.EntityFrameworkCore;
using NSubstitute;
using ParkShark.Data;
using ParkShark.Domain.Divisions;
using ParkShark.Services.Divisions;
using ParkShark.Services.Divisions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ParkShark.Services.Tests.DivisionServicesTests
{
    public class DivisionServiceTests
    {

        private static DbContextOptions CreateNewInMemoryDatabase()
        {
            return new DbContextOptionsBuilder<ParkSharkDbContext>()
                .UseInMemoryDatabase("DivisionDb" + Guid.NewGuid().ToString("N"))
                .Options;
        }

        [Fact]
        public void GivenHappyPath1_WhenAddingNewDivisionToDb_ObjectIsFlushedAndReturned()
        {
            using (var context = new ParkSharkDbContext(CreateNewInMemoryDatabase()))
            {
                var division = Division.CreateNewDivision("test", "testorg", "lars");

                var divisionService = new DivisionService(context);
                var result = divisionService.CreateDivision(division);

                Assert.IsType<Division>(result);
            }
        }


        [Fact]
        public void GivenHappyPath2_WhenAddingNewDivisionToDb_ObjectIsAddedToDb()
        {
            using (var context = new ParkSharkDbContext(CreateNewInMemoryDatabase()))
            {
                var division = Division.CreateNewDivision("test", "testorg", "lars");

                var divisionService = new DivisionService(context);
                var result = divisionService.CreateDivision(division);

                Assert.Single(divisionService.GetAllDivisions());
            }
        }

        [Fact]
        public void GivenGetSingledivision_WhenRequestingSingleDivision_ReturnRequestedDivision()
        {
            using (var context = new ParkSharkDbContext(CreateNewInMemoryDatabase()))
            {
                var divisionService = new DivisionService(context);

                var division = Division.CreateNewDivision("test", "testorg", "lars");
                context.Set<Division>().Add(division);
                var divsionID = division.DivisionID;
                context.SaveChanges();



                var result = divisionService.GetSingleDivision(divsionID);

                Assert.IsType<Division>(result);
                Assert.Equal(divsionID, result.DivisionID);
                Assert.Equal("test", result.Name);
                Assert.Equal("testorg", result.OriginalName);
            }
        }
        [Fact]
        public void GivenGetSingledivisionUnHappyPath_WhenRequestingSingleDivision_ReturnNull()
        {
            using (var context = new ParkSharkDbContext(CreateNewInMemoryDatabase()))
            {
                var divisionService = new DivisionService(context);

                var division = Division.CreateNewDivision("test", "testorg", "lars");
                context.Set<Division>().Add(division);
                var fakeID = Guid.NewGuid();
                context.SaveChanges();



                var result = divisionService.GetSingleDivision(fakeID);


                Assert.Null(result);
            }
        }

        [Fact]
        public void GivenGetAllDivisions_WhenRequestingAllDivisions_ThenReturnListOfAllDivisions()
        {
            using (var context = new ParkSharkDbContext(CreateNewInMemoryDatabase()))
            {

                context.Set<Division>().Add(Division.CreateNewDivision("test", "testorg", "lars"));
                context.Set<Division>().Add(Division.CreateNewDivision("test2", "testorg2", "lars"));
                context.SaveChanges();

                var divisionService = new DivisionService(context);
                var result = divisionService.GetAllDivisions().Count;
                Assert.Equal(2, result);

            }
        }

        [Fact]
        public void Given2Divisions_WhenAssigningParentTOSUb_SubdevisionIsReturnedWithParentGuidID()
        {
            using (var context = new ParkSharkDbContext(CreateNewInMemoryDatabase()))
            {
                var divisionService = new DivisionService(context);

                var name = "Test1";
                var originalName = "Test1";
                string director = "test1";

                var parentDivision = Division.CreateNewDivision(name, originalName, director);
                divisionService.CreateDivision(parentDivision);
                var subDivision = Division.CreateNewDivision(name, originalName, director);
                divisionService.CreateDivision(subDivision);

                var result = DivisionService.AssignParentDivision(subDivision, parentDivision);


                Assert.Equal(parentDivision.DivisionID, subDivision.ParentDivisionID);
                Assert.Single(parentDivision.SubdivisionsList);
            }
        }

        [Fact]
        public void GivenADivision_WhenAssigningSelfAsParentDivision_ParentDivisionRemainsNull()
        {
            var division = Division.CreateNewDivision("name", "orgname", "director");

            var result = DivisionService.AssignParentDivision(division, division);

            Assert.Null(division.ParentDivisionID);
            Assert.Null(result);
        }
        [Fact]
        public void GivenADivision_WhenAssigningParentDivisonToADivisionThatAlreadyHasAParentDivision_ThenReturnsNull()
        {
            var division = Division.CreateNewDivision("name", "orgname", "director");
            var parentDivision = Division.CreateNewDivision("name", "orgname", "director");
            var secondParentDivsion = Division.CreateNewDivision("name", "orgname", "director");

            division.ParentDivisionID = parentDivision.DivisionID;
            division.ParentDivision = parentDivision;

            var result = DivisionService.AssignParentDivision(division, secondParentDivsion);
            
            Assert.Null(result);
        }

        [Fact]
        public void GivenADivision_WhenAssigningAnAlreadyAssignedSubDivision_ThenReturnsNull()
        {
            //given
            var parentDivision = Division.CreateNewDivision("name", "orgname", "director");
            var subDivision = Division.CreateNewDivision("name", "orgname", "director");

            parentDivision.SubdivisionsList.Add(subDivision);

            var result = DivisionService.AssignParentDivision(subDivision, parentDivision);

            Assert.Null(result);
        }
    }
}