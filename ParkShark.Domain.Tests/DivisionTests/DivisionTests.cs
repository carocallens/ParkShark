using ParkShark.Domain.Divisions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParkShark.Domain.Tests.DivisionTests
{
    public class DivisionTests
    {
        [Fact]
        public void GivenHappyPath1_WhenCreateNewDivision_TheDivisoionIsCreated()
        {
            var name = "Test1";
            var originalName = "Test1";
            var director = "Test1";

            var division = Division.CreateNewDivision(name, originalName, director);

            Assert.IsType<Division>(division);
            Assert.NotNull(division);
        }

        [Fact]
        public void GivenHappyPath2_WhenCreateNewDivision_ContentOfObjectMatchesGivenContent()
        {
            var name = "Test1";
            var originalName = "Test1";
            var director = "Test1";

            var division = Division.CreateNewDivision(name, originalName, director);

            Assert.Equal(division.Name, name);
            Assert.Equal(division.OriginalName, originalName);
            Assert.Equal(division.Director, director);
        }

        [Fact]
        public void GivenNullValue1_WhenCreateNewDivision_ObjectIsNull()
        {
            var name = "Test1";
            var originalName = "Test1";
            string director = null;

            var division = Division.CreateNewDivision(name, originalName, director);

            Assert.Null(division);
        }
        [Fact]
        public void GivenNullValue2_WhenCreateNewDivision_ObjectIsNull()
        {
            var name = "";
            var originalName = "Test1";
            string director = "test1";

            var division = Division.CreateNewDivision(name, originalName, director);

            Assert.Null(division);
        }

        [Fact]
        public void GivenNullValue3_WhenCreateNewDivision_ObjectIsNull()
        {
            var name = "    ";
            var originalName = "Test1";
            string director = "test1";

            var division = Division.CreateNewDivision(name, originalName, director);

            Assert.Null(division);
        }

        [Fact]
        public void GivenADivision_WhenAddingToList_ListCountIncreased()
        {
            var div = Division.CreateNewDivision("name", "orgname", "dir");
            div.SubdivisionsList.Add(Division.CreateNewDivision("str2", "", ""));
            Assert.Single(div.SubdivisionsList);
        }

    }
}
