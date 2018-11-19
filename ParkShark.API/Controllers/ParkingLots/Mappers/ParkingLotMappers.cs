using ParkShark.API.Controllers.Members.Mappers.Interfaces;
using ParkShark.API.Controllers.ParkingLots.DTO;
using ParkShark.API.Controllers.ParkingLots.Mappers.Interfaces;
using ParkShark.Domain.ParkingLots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.ParkingLots.Mappers
{
    public class ParkingLotMappers : IParkingLotMappers
    {
        private readonly IAddressMapper _adressMappers;
        private readonly IContactPersonMapper _contactPersonMapper;

        public ParkingLotMappers(IAddressMapper adressMappers, IContactPersonMapper contactPersonMapper)
        {
            _adressMappers = adressMappers;
            _contactPersonMapper = contactPersonMapper;
        }

        public ParkingLot FromParkingLotCreateToParkingLot(ParkingLotDTO_Create parkingLotDTO)
        {
            var parkingLot = ParkingLotBuilder.CreateNewParkingLot()
                .WithBuildingType(parkingLotDTO.Buildingtype)
                .WithCapacity(parkingLotDTO.Capacity)
                .WithContactPerson(_contactPersonMapper.FromContactPersonDTOTOContactPerson(parkingLotDTO.ContactPerson))
                .WithDivision(parkingLotDTO.DivisionID)
                .WithName(parkingLotDTO.Name)
                .WithPricePerHour(parkingLotDTO.PricePerHour)
                .WithAddress(_adressMappers.DTOToAddress(parkingLotDTO.Address))
                .Build();
            return parkingLot;
        }

        public ParkingLotDTO_Return FromParkingLotToParkingLotDTOReturn(ParkingLot parkingLot)
        {
            ParkingLotDTO_Return parkingLotDTOReturn = new ParkingLotDTO_Return
            {
                Buildingtype = parkingLot.BuildingType,
                Capacity = parkingLot.Capacity,
                ContactPerson = _contactPersonMapper.FromContactPersonTOContactPersonDTO(parkingLot.ContactPerson),
                DivisionID = parkingLot.DivisionID,
                Name = parkingLot.Name,
                PricePerHour = parkingLot.PricePerHour,
                Address = _adressMappers.AddressToDTO(parkingLot.Address)
            };
            return parkingLotDTOReturn;
        }

    }
}
