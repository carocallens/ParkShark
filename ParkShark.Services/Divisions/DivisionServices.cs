using ParkShark.Domain.Divisions;
using ParkShark.Domain.Divisions.Repository;
using ParkShark.Services.Divisions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ParkShark.Services.Divisions
{
    public class DivisionServices : IDivisionServices
    {
        private readonly DivisionDbContext _divisionDbContext;

        public DivisionServices(DivisionDbContext divisionDbContext)
        {
            _divisionDbContext = divisionDbContext;
        }

        public Division AddDivisionToDBbContext(Division division)
        {

            _divisionDbContext.Add(division);
            _divisionDbContext.SaveChanges();

            return division;
        }

        public List<Division> GetAllDivisions()
        {
            return _divisionDbContext.Division.Select(x => x).ToList();
        }

        public Division GetSingleDivision(string givenID)
        {
            var result = _divisionDbContext.Division.SingleOrDefault(x => x.GuidID == givenID);

            if (result == null)
            { return null; }

            return result;
        }
    }
}
