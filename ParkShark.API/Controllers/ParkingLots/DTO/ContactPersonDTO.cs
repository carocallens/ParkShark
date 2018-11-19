using ParkShark.API.Controllers.Members.DTO;
using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.ParkingLots.DTO
{
    public class ContactPersonDTO
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public AddressDTO Address { get;  set; }
        public string Email { get;  set; }
        public string PhoneNumber { get;  set; }
        public string MobilePhoneNumber { get;  set; }
    }
}
