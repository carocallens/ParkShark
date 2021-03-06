﻿using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.Members.DTO
{
    public class MemberDTO_Return
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressDTO Address { get; set; }
        public MembershipLevelDTO MembershipLevel { get; set; }
        public List<LicensePlateDTO> LicensePlate { get; set; } = new List<LicensePlateDTO>();
        public List<PhoneNumberDTO> PhoneNumber { get; set; } = new List<PhoneNumberDTO>();
    }
}
