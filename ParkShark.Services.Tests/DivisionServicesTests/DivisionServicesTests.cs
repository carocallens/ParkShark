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

        //private static DbContextOptions CreateNewInMemoryDatabase()
        //{
        //    return new DbContextOptionsBuilder<DivisionDbContext>()
        //        .UseInMemoryDatabase("ParkSharkDb" + Guid.NewGuid().ToString("N"))
        //        .Options;
        //}

        //[Fact]
        //public void GivenHappyPath1_WhenAddingNewDivisionToDb_ObjectIsFlushedAndReturned()
        //{
        //    var cont = new DivisionDbContext(CreateNewInMemoryDatabase());
        //    DivisionServices divservice = new DivisionServices(cont);
        //    var division = Division.CreateNewDivision("name", "originalName", "director");

        //    var result = divservice.AddDivisionToDBbContext(division);
        //    Assert.IsType<Division>(result);
        //    Assert.NotNull(result);
        //}
    }
}
