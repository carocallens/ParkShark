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
            //Throw exception, make it explicit : throw new ArgumentException("division should not be null");
            if (division == null)
            {
                return null;
            }

            _parkSharkDbContext.Add(division);
            _parkSharkDbContext.SaveChanges();

            return division;
        }

        public List<Division> GetAllDivisions()
        {
            return _parkSharkDbContext.Division.Select(div => div).ToList();
        }

        public Division GetSingleDivision(Guid givenID)
        {
            //Use the Find or FindAsync, this is native to EF Core and cuts the overhead of LINQ
            var result = _parkSharkDbContext.Division.SingleOrDefault(x => x.DivisionID == givenID);

            if (result == null)
            { return null; }

            //Not filling up the navigation property using .Include

            return result;
        }


        public Division AssignParentDivision(Division subDivision, Division parentDivision)
        {
            if (parentDivision.DivisionID == subDivision.DivisionID
                || subDivision.ParentDivisionID != null
                || parentDivision.SubdivisionsList.Any(x => x.DivisionID == subDivision.DivisionID))
            {
                return null;
            }

            subDivision.ParentDivisionID = parentDivision.DivisionID;
            subDivision.ParentDivision = parentDivision;
            parentDivision.SubdivisionsList.Add(subDivision);

            _parkSharkDbContext.Update(subDivision);
            _parkSharkDbContext.SaveChanges();


            return subDivision;
        }

    }
}
