using ParkShark.API.Controllers.Members.DTO;
using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.Members.Mappers.Interfaces
{
    public interface IPhoneNumpberMapper
    {
        List<DummyPhoneNumberObject> DTOListToPhoneNumpberObject(List<PhoneNumberDTO> phoneNumberDTOList);
        List<PhoneNumberDTO> PhoneNumpberListToDTO(List<PhoneNumber> phoneNumberList);
    }
}
