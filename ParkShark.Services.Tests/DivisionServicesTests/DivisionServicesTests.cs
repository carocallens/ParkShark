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
    public class DivisionServicesTests
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
                var newDiv = Division.CreateNewDivision("test", "testorg", "lars");

                var service = new DivisionServices(context);
                var result = service.AddDivisionToDBbContext(newDiv);

                Assert.IsType<Division>(result);
            }
        }


        [Fact]
        public void GivenHappyPath2_WhenAddingNewDivisionToDb_ObjectIsAddedToDb()
        {
            using (var context = new ParkSharkDbContext(CreateNewInMemoryDatabase()))
            {
                var newDiv = Division.CreateNewDivision("test", "testorg", "lars");

                var service = new DivisionServices(context);
                var result = service.AddDivisionToDBbContext(newDiv);

                Assert.Single(service.GetAllDivisions());
            }
        }

        [Fact]
        public void GivenGetSingledivision_WhenRequestingSingleDivision_ReturnRequestedDivision()
        {
            using (var context = new ParkSharkDbContext(CreateNewInMemoryDatabase()))
            {
                var service = new DivisionServices(context);

                var newDiv = Division.CreateNewDivision("test", "testorg", "lars");
                context.Set<Division>().Add(newDiv);
                var id = newDiv.ID;
                context.SaveChanges();



                var result = service.GetSingleDivision(id);

                Assert.IsType<Division>(result);
                Assert.Equal(id, result.ID);
                Assert.Equal("test", result.Name);
                Assert.Equal("testorg", result.OriginalName);
            }
        }
        [Fact]
        public void GivenGetSingledivisionUnHappyPath_WhenRequestingSingleDivision_ReturnNull()
        {
            using (var context = new ParkSharkDbContext(CreateNewInMemoryDatabase()))
            {
                var service = new DivisionServices(context);

                var newDiv = Division.CreateNewDivision("test", "testorg", "lars");
                context.Set<Division>().Add(newDiv);
                var id = Guid.NewGuid();
                context.SaveChanges();



                var result = service.GetSingleDivision(id);


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

                var service = new DivisionServices(context);
                var result = service.GetAllDivisions().Count;
                Assert.Equal(2, result);

            }
        }

        [Fact]
        public void Given2Divisions_WhenAssigningParentTOSUb_SubdevisionIsReturnedWithParentGuidID()
        {
            using (var context = new ParkSharkDbContext(CreateNewInMemoryDatabase()))
            {
                var service = new DivisionServices(context);

                var name = "Test1";
                var originalName = "Test1";
                string director = "test1";

                var parDivision = Division.CreateNewDivision(name, originalName, director);
                service.AddDivisionToDBbContext(parDivision);
                var subDivision = Division.CreateNewDivision(name, originalName, director);
                service.AddDivisionToDBbContext(subDivision);

                var result = DivisionServices.AssignParentDivision(subDivision, parDivision);


                Assert.Equal(parDivision.ID, subDivision.ParentDivisionGuidID);
                Assert.Single(parDivision.SubdivisionsList);
            }
        }

        [Fact]
        public void Given1Division_WhenAssigningGuidAsParentGuid_ParentGuidRemainsNull()
        {
            var division = Division.CreateNewDivision("name", "orgname", "director");

            var result = DivisionServices.AssignParentDivision(division, division);

            Assert.Null(division.ParentDivisionGuidID);
            Assert.Null(result);
        }
        [Fact]
        public void Given1Division2_WhenAssigningGuidAsParentGuid_ParentGuidRemainsNull()
        {
            //given
            var division = Division.CreateNewDivision("name", "orgname", "director");
            var Pardivision = Division.CreateNewDivision("name", "orgname", "director");
            var newParDivision = Division.CreateNewDivision("name", "orgname", "director");

            division.ParentDivisionGuidID = Pardivision.ID;
            division.ParentDivision = Pardivision;

            //
            var result = DivisionServices.AssignParentDivision(division, newParDivision);
            //
            Assert.Null(result);
        }

        [Fact]
        public void Given1Division3_WhenAssigningGuidAsParentGuid_ParentGuidRemainsNull()
        {
            //given
            var parentDivision = Division.CreateNewDivision("name", "orgname", "director");
            var Subdivision = Division.CreateNewDivision("name", "orgname", "director");

            parentDivision.SubdivisionsList.Add(Subdivision);

            var result = DivisionServices.AssignParentDivision(Subdivision, parentDivision);

            Assert.Null(result);
        }


        //[Fact]
        //public void HappyPath_RemoveParentDivision()
        //{
        //    var parentDivision = Division.CreateNewDivision("name", "orgname", "director");
        //    var Subdivision = Division.CreateNewDivision("name", "orgname", "director");

        //    parentDivision.SubdivisionsList.Add(Subdivision);
        //    Subdivision.ParentDivisionGuidID = parentDivision.ID;
        //    Subdivision.ParentDivision = parentDivision;

        //    DivisionServices.RemoveParentDivision(Subdivision, parentDivision);

        //    Assert.Null(Subdivision.ParentDivision);
        //    Assert.Null(Subdivision.ParentDivisionGuidID);
        //    Assert.DoesNotContain(Subdivision, parentDivision.SubdivisionsList);
        //}


        //[Fact]
        //public void NoHappyPath_RemoveParentDivision()
        //{
        //    var parentDivision = Division.CreateNewDivision("name", "orgname", "director");
        //    var Subdivision = Division.CreateNewDivision("name", "orgname", "director");

        //    Subdivision.ParentDivisionGuidID = parentDivision.GuidID;
        //    Subdivision.ParentDivision = parentDivision;

        //    var result = DivisionServices.RemoveParentDivision(Subdivision, parentDivision);

        //    Assert.Null(result);
        //}

        //[Fact]
        //public void NoHappyPath2_RemoveParentDivision()
        //{
        //    var parentDivision = Division.CreateNewDivision("name", "orgname", "director");
        //    var Subdivision = Division.CreateNewDivision("name", "orgname", "director");

        //    parentDivision.SubdivisionsList.Add(Subdivision);


        //    var result = DivisionServices.RemoveParentDivision(Subdivision, parentDivision);

        //    Assert.Null(result);
        //}




    }


}