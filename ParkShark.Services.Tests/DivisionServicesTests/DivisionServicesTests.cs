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
            using (var context = new ParkSharkDbContext(CreateNewInMemoryDatabase()))
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
    }


}