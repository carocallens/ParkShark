using ParkShark.Domain.Divisions;
using ParkShark.Services.Divisions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ParkShark.Data;

namespace ParkShark.Services.Divisions
{
    public class DivisionServices : IDivisionServices
    {
        private readonly ParkSharkDbContext _parkSharkDbContext;

        public DivisionServices(ParkSharkDbContext divisionDbContext)
        {
            _parkSharkDbContext = divisionDbContext;
        }

        public Division AddDivisionToDBbContext(Division division)
        {

            _parkSharkDbContext.Add(division);
            _parkSharkDbContext.SaveChanges();

            return division;
        }

        public List<Division> GetAllDivisions()
        {
            return _parkSharkDbContext.Division.Select(x => x).ToList();
        }

        public Division GetSingleDivision(string givenID)
        {
            var result = _parkSharkDbContext.Division.SingleOrDefault(x => x.GuidID == givenID);

            if (result == null)
            { return null; }

            return result;
        }
    }
}
