using ParkShark.Domain.Divisions;
using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Domain.ParkingLots
{
    public class ParkingLot
    {
        public string ParkingLotID { get; private set; }
        public string Name { get; private set; }
        public int DivisionID { get; private set; }
        public int BuildingtypeID { get; private set; }
        public int Capacity { get; private set; }
        public int ContactPersonID { get; private set; }
        public Address Address { get; private set; }
        public decimal PricePerHour { get; private set; }

        public ParkingLot(string parkingLotID)
        {
            ParkingLotID = Guid.NewGuid().ToString();
        }
    }
}
