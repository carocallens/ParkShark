using ParkShark.API.Controllers.Divisions.DTO;
using ParkShark.API.Controllers.Divisions.Mappers;
using ParkShark.Domain.Divisions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParkShark.API.Tests.DivisionApiUnitTests
{
    public class DivisionApiUnitTests
    {

        [Fact]
        public void GivenCreateDivisionFromDivisionDTOCreate_WhenGivenADivisionDTOCreate_ThenCreateADivision()
        {
            var newDivDTO = new DivisionDTO_Create() { Name = "test", Director = "lars", OriginalName = "testorg" };

            var newMapper = new DivisionMapper();
            var result = newMapper.CreateDivisionFromDivisionDTOCreate(newDivDTO);

            Assert.IsType<Division>(result);
        }

        [Fact]
        public void GivenCreateDivisionDTOReturnFromDivision_WhenGivenADivisionToCreate_ThenCreateADivisionDTOReturn()
        {
            var newDiv = Division.CreateNewDivision("test", "testorg", "lars");

            var newMapper = new DivisionMapper();
            var result = newMapper.CreateDivisionDTOReturnFromDivision(newDiv);

            Assert.IsType<DivisionDTO_Return>(result);
        }

        [Fact]
        public void GivenCreateDivisionDTOReturnListFromDivisionList_WhenGivenADivisionList_ThenCreateADivisionDTOReturnList()
        {
            var newDiv = Division.CreateNewDivision("test", "testorg", "lars");
            var newDiv2 = Division.CreateNewDivision("test2", "testorg2", "lars");
            var testList = new List<Division>();
            testList.Add(newDiv);
            testList.Add(newDiv2);

            var newMapper = new DivisionMapper();
            var result = newMapper.CreateListOfDivisionDTOsFromDivisionList(testList);

            Assert.IsType<List<DivisionDTO_Return>>(result);
        }
    }
}
