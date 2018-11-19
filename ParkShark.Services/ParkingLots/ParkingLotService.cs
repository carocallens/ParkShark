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


        public ParkingLot AddParkingLotToDBContext(ParkingLot parkingLot)
        {
            if(parkingLot == null)
            {
                return null;
            }

            _context.ParkingLots.Add(parkingLot);
            _context.SaveChanges();

            return parkingLot;
        }

        public List<ParkingLot> GetAllParkingLots()
        {
            return _context.ParkingLots.Select(x => x).ToList();
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
