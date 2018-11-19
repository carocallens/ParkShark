using ParkShark.Data;
using ParkShark.Domain.ParkingLots;
using ParkShark.Services.ParkingLots.Interfaces;
using System;
using System.Collections.Generic;
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
    }
}
