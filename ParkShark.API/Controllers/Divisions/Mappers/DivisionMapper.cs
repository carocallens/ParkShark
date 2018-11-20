using ParkShark.API.Controllers.Divisions.DTO;
using ParkShark.API.Controllers.Divisions.Mappers.Interfaces;
using ParkShark.Domain.Divisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.Divisions.Mappers
{
    public class DivisionMapper : IDivisionMapper
    {
        public Division CreateDivisionFromDivisionDTOCreate(DivisionDTO_Create divisionDTOCreate)
        {
            var division = Division.CreateNewDivision(
                divisionDTOCreate.Name,
                divisionDTOCreate.OriginalName,
                divisionDTOCreate.Director
            );
            return division;
        }

        public DivisionDTO_Return CreateDivisionDTOReturnFromDivision(Division division)
        {
            var divisionDTO = new DivisionDTO_Return
            {
                Name = division.Name,
                Director = division.Director,
                OriginalName = division.OriginalName,
                DivisionID = division.DivisionID,
                ParentGuid = division.ParentDivisionID
            };
            return divisionDTO;
        }

        public List<DivisionDTO_Return> CreateListOfDivisionDTOsFromDivisionList(List<Division> list)
        {
            var newList = new List<DivisionDTO_Return>();

            foreach (var item in list)
            { 
                newList.Add(CreateDivisionDTOReturnFromDivision(item));
            }

            return newList;
        }
    }
}
