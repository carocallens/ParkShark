using ParkShark.API.Controllers.Divisions.DTO;
using ParkShark.Domain.Divisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.Divisions.Mappers.Interfaces
{
    public interface IDivisionMapper
    {
        Division CreateDivisionFromDivisionDTOCreate(DivisionDTO_Create divisionDTOCreate);
        DivisionDTO_Return CreateDivisionDTOReturnFromDivision(Division division);
    }


}
