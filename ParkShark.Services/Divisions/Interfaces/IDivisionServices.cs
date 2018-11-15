using ParkShark.Domain.Divisions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Services.Divisions.Interfaces
{
    public interface IDivisionServices
    {

        Division AddDivisionToDBbContext(Division division);

        List<Division> GetAllDivisions();

        Division GetSingleDivision(string givenID);

    }
}
