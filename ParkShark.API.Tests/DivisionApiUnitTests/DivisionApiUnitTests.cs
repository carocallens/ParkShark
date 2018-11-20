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
            var divisionDTO = new DivisionDTO_Create() { Name = "test", Director = "lars", OriginalName = "testorg" };

            var divisionMapper = new DivisionMapper();
            var result = divisionMapper.CreateDivisionFromDivisionDTOCreate(divisionDTO);

            Assert.IsType<Division>(result);
        }

        [Fact]
        public void GivenCreateDivisionDTOReturnFromDivision_WhenGivenADivisionToCreate_ThenCreateADivisionDTOReturn()
        {
            var divisionDTO = Division.CreateNewDivision("test", "testorg", "lars");

            var divisionMapper = new DivisionMapper();
            var result = divisionMapper.CreateDivisionDTOReturnFromDivision(divisionDTO);

            Assert.IsType<DivisionDTO_Return>(result);
        }

        [Fact]
        public void GivenCreateDivisionDTOReturnListFromDivisionList_WhenGivenADivisionList_ThenCreateADivisionDTOReturnList()
        {
            var divisionDTO = Division.CreateNewDivision("test", "testorg", "lars");
            var divisionDTO2 = Division.CreateNewDivision("test2", "testorg2", "lars");
            var testList = new List<Division>();
            testList.Add(divisionDTO);
            testList.Add(divisionDTO2);

            var divisionMapper = new DivisionMapper();
            var result = divisionMapper.CreateListOfDivisionDTOsFromDivisionList(testList);

            Assert.IsType<List<DivisionDTO_Return>>(result);
        }
    }
}
