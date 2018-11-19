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

        public List<ParkingLotDTO_Return> CreateListOfParkingLotDTOReturnsFromParkingLotList(List<ParkingLot> getAllParkingLots)
        {
            var newList = new List<ParkingLotDTO_Return>();

            foreach (var item in getAllParkingLots)
            {
                newList.Add(FromParkingLotToParkingLotDTOReturn(item));
            }

            return newList;
        }

        public ParkingLot FromParkingLotCreateToParkingLot(ParkingLotDTO_Create parkingLotDTO)
        {
            BuildingType buildingType = (BuildingType)Enum.Parse(typeof(BuildingType), parkingLotDTO.Buildingtype);

            var parkingLot = ParkingLotBuilder.CreateNewParkingLot()
                .WithBuildingType(buildingType)
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
                ParkingLotID = parkingLot.ParkingLotID,
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
