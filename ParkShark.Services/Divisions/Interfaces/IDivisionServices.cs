using ParkShark.Domain.Divisions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Services.Divisions.Interfaces
{
    public interface IDivisionServices
    {
        Division CreateDivision(Division division);

        List<Division> GetAllDivisions();

        Division GetSingleDivision(Guid givenID);

    }
}
