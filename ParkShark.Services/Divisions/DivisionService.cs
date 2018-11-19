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


        public static Division AssignParentDivision(Division DivisionToAssignParentTo, Division ParentDivisionToAssign)
        {
            if (ParentDivisionToAssign.ID == DivisionToAssignParentTo.ID
                || DivisionToAssignParentTo.ParentDivisionGuidID != null
                || ParentDivisionToAssign.SubdivisionsList.Any(x => x.ID == DivisionToAssignParentTo.ID))
            {
                return null;
            }

            DivisionToAssignParentTo.ParentDivisionGuidID = ParentDivisionToAssign.ID;
            DivisionToAssignParentTo.ParentDivision = ParentDivisionToAssign;
            ParentDivisionToAssign.SubdivisionsList.Add(DivisionToAssignParentTo);

            return DivisionToAssignParentTo;
        }

        //public static Division RemoveParentDivision(Division DivToRemoveParentFrom, Division ParentToRemoveSubFrom)
        //{
        //    DivToRemoveParentFrom.ParentDivisionGuidID = null;
        //    DivToRemoveParentFrom.ParentDivision = null;

        //    if (!ParentToRemoveSubFrom.SubdivisionsList.Any(x => x.GuidID == DivToRemoveParentFrom.GuidID))
        //    {
        //        return null;
        //    }
        //    ParentToRemoveSubFrom.SubdivisionsList.Remove(DivToRemoveParentFrom);

        //    return DivToRemoveParentFrom;
        //}
    }
}
