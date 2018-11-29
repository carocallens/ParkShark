using ParkShark.API.Controllers.Members.DTO;
using ParkShark.Domain.ParkingLots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.ParkingLots.DTO
{
    public class ParkingLotDTO_Return
    {
        public Guid ParkingLotID { get;  set; }
        public string Name { get;  set; }
        public Guid DivisionID { get;  set; }
        //Enums in return types are better viewed as strings, this is easier to read than ints (Enum becomes int when serialized)
        public BuildingType Buildingtype { get;  set; }
        public int Capacity { get;  set; }
        public ContactPersonDTO ContactPerson { get;  set; }
        public AddressDTO Address { get;  set; }
        public decimal PricePerHour { get;  set; }
    }
}
