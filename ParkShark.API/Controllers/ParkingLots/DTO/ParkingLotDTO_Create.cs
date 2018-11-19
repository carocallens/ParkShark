using ParkShark.API.Controllers.Members.DTO;
using ParkShark.Domain.Members;
using ParkShark.Domain.ParkingLots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.ParkingLots.DTO
{
    public class ParkingLotDTO_Create
    {
        public string Name { get;  set; }
        public Guid DivisionID { get;  set; }
        public string Buildingtype { get;  set; }
        public int Capacity { get;  set; }
        public ContactPersonDTO ContactPerson { get;  set; }
        public AddressDTO Address { get;  set; }
        public decimal PricePerHour { get;  set; }
    }
}
