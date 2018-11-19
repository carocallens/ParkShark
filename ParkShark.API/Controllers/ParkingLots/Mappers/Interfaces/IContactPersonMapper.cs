using ParkShark.API.Controllers.ParkingLots.DTO;
using ParkShark.Domain.ParkingLots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.ParkingLots.Mappers.Interfaces
{
    public interface IContactPersonMapper
    {
        ContactPerson FromContactPersonDTOTOContactPerson(ContactPersonDTO contactPersonDTO);
        ContactPersonDTO FromContactPersonTOContactPersonDTO(ContactPerson contactPerson);
    }
}
