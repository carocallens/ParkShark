using ParkShark.Domain.ParkingLots;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Services.ParkingLots.Interfaces
{
    public interface IParkingLotService
    {
        ParkingLot AddParkingLotToDBContext(ParkingLot parkingLot);
    }
}
