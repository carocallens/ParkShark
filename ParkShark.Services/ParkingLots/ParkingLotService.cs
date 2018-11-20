using Microsoft.EntityFrameworkCore;
using ParkShark.Data;
using ParkShark.Domain.ParkingLots;
using ParkShark.Services.ParkingLots.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkShark.Services.ParkingLots
{
    public class ParkingLotService : IParkingLotService
    {
        private readonly ParkSharkDbContext _context;

        public ParkingLotService(ParkSharkDbContext context)
        {
            _context = context;
        }


        public ParkingLot CreateParkingLot(ParkingLot parkingLot)
        {
            if (parkingLot == null)
            {
                return null;
            }
            _context.ParkingLots.Add(parkingLot);
            _context.SaveChanges();

            return parkingLot;
        }

        public List<ParkingLot> GetAllParkingLots()
        {
            var parkingLotList = new List<ParkingLot>();
            var ParkingLotDbSet = _context.Set<ParkingLot>()
                        .Include(pl => pl.Address)
                            .ThenInclude(a => a.City)
                        .Include(a => a.ContactPerson)
                            .ThenInclude(c => c.Address)
                        .Include(pl => pl.Division);

            foreach (var member in ParkingLotDbSet)
            {
                parkingLotList.Add(member);
            }

            return parkingLotList;
        }

        public ParkingLot GetSingleParkingLot(Guid parkingLotID)
        {
            var result = _context.ParkingLots.SingleOrDefault(x => x.ParkingLotID == parkingLotID);
            if (result == null)
            {
                return null;
            }
            return result;
        }
    }
}
