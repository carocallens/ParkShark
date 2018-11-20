using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.Members.DTO
{
    public class MemberDTO_Create
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MembershipLevel { get; set; }
        public AddressDTO Address { get; set; }
        public List<LicensePlateDTO> LicensePlate { get; set; }
        public List<PhoneNumberDTO> PhoneNumber { get; set; }
    }
}