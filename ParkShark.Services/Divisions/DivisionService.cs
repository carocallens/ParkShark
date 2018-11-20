using ParkShark.Domain.Divisions;
using ParkShark.Services.Divisions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ParkShark.Data;

namespace ParkShark.Services.Divisions
{
    public class DivisionService : IDivisionServices
    {
        private readonly ParkSharkDbContext _parkSharkDbContext;

        public DivisionService(ParkSharkDbContext parkSharkDbContext)
        {
            _parkSharkDbContext = parkSharkDbContext;
        }

        public Division CreateDivision(Division division)
        {

            _parkSharkDbContext.Add(division);
            _parkSharkDbContext.SaveChanges();

            return division;
        }

        public List<Division> GetAllDivisions()
        {
            return _parkSharkDbContext.Division.Select(x => x).ToList();
        }

        public Division GetSingleDivision(Guid givenID)
        {
            var result = _parkSharkDbContext.Division.SingleOrDefault(x => x.ID == givenID);

            if (result == null)
            { return null; }

            return result;
        }


        public static Division AssignParentDivision(Division subDivision, Division parentDivision)
        {
            if (parentDivision.ID == subDivision.ID
                || subDivision.ParentDivisionID != null
                || parentDivision.SubdivisionsList.Any(x => x.ID == subDivision.ID))
            {
                return null;
            }

            subDivision.ParentDivisionID = parentDivision.ID;
            subDivision.ParentDivision = parentDivision;
            parentDivision.SubdivisionsList.Add(subDivision);

            return subDivision;
        }
    }
}
