using ParkShark.API.Controllers.Members.DTO;
using ParkShark.API.Controllers.Members.Mappers.Interfaces;
using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.Members.Mappers
{
    public class AddressMapper : IAddressMapper
    {
        public AddressDTO AddressToDTO(Address address)
        {
            return new AddressDTO
            {
                StreetName = address.StreetName,
                StreetNumber = address.StreetNumber,
                ZIP = address.ZIP
            };
        }

        public Address DTOToAddress(AddressDTO addressDTO)
        {
            return Address.CreateAddress(addressDTO.StreetName, addressDTO.StreetNumber, addressDTO.ZIP);
        }
    }
}
