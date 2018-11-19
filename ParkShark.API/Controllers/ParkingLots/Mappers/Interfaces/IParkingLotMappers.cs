using ParkShark.API.Controllers.ParkingLots.DTO;
using ParkShark.Domain.ParkingLots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.ParkingLots.Mappers.Interfaces
{
    public interface IParkingLotMappers
    {
        ParkingLot FromParkingLotCreateToParkingLot(ParkingLotDTO_Create parkingLotDTO);
        ParkingLotDTO_Return FromParkingLotToParkingLotDTOReturn(ParkingLot parkingLot);
    }
}
