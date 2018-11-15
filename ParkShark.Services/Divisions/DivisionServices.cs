using ParkShark.Domain.Divisions;
using ParkShark.Domain.Divisions.Repository;
using ParkShark.Services.Divisions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
