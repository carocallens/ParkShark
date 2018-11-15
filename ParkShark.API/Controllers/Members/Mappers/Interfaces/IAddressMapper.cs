using ParkShark.API.Controllers.Members.DTO;
using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.Members.Mappers.Interfaces
{
    public interface IAddressMapper
    {
        Address DTOToAddress(AddressDTO addressDTO);
        AddressDTO AddressToDTO(Address address);
    }
}
