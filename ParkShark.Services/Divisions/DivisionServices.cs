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


        public static Division AssignParentDivision(Division DivisionToAssignParentTo, Division ParentDivisionToAssign)
        {
            if (ParentDivisionToAssign.GuidID == DivisionToAssignParentTo.GuidID
                || DivisionToAssignParentTo.ParentDivisionGuidID != null
                || ParentDivisionToAssign.SubdivisionsList.Any(x => x.GuidID == DivisionToAssignParentTo.GuidID))
            {
                return null;
            }

            DivisionToAssignParentTo.ParentDivisionGuidID = ParentDivisionToAssign.GuidID;
            DivisionToAssignParentTo.ParentDivision = ParentDivisionToAssign;
            ParentDivisionToAssign.SubdivisionsList.Add(DivisionToAssignParentTo);

            return DivisionToAssignParentTo;
        }

        public static Division RemoveParentDivision(Division DivToRemoveParentFrom, Division ParentToRemoveSubFrom)
        {
            DivToRemoveParentFrom.ParentDivisionGuidID = null;
            DivToRemoveParentFrom.ParentDivision = null;
            if (ParentToRemoveSubFrom.SubdivisionsList.Any(x => x.GuidID == DivToRemoveParentFrom.GuidID))
            {
                ParentToRemoveSubFrom.SubdivisionsList.Remove(DivToRemoveParentFrom);
            }
            return DivToRemoveParentFrom;
        }
    }
}
