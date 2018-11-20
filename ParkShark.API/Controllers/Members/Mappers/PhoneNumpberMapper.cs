using ParkShark.API.Controllers.Members.DTO;
using ParkShark.API.Controllers.Members.Mappers.Interfaces;
using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.Members.Mappers
{
    public class PhoneNumpberMapper : IPhoneNumpberMapper
    {
        public List<DummyPhoneNumberObject> DTOListToPhoneNumpberObject(List<PhoneNumberDTO> phoneNumberDTOList)
        {
            var phoneNumberList_ToReturn = new List<DummyPhoneNumberObject>();

            foreach (PhoneNumberDTO item in phoneNumberDTOList)
            {
                var PhoneNumber = DTOToPhoneNumpber(item);
                phoneNumberList_ToReturn.Add(PhoneNumber);
            }

            return phoneNumberList_ToReturn;
        }

        public List<PhoneNumberDTO> PhoneNumpberListToDTO(List<PhoneNumber> phoneNumberList)
        {
            var phoneNumberList_ToReturn = new List<PhoneNumberDTO>();

            foreach (PhoneNumber item in phoneNumberList)
            {
                var PhoneNumber = PhoneNumpberToDTO(item);
                phoneNumberList_ToReturn.Add(PhoneNumber);
            }

            return phoneNumberList_ToReturn;
        }



        private DummyPhoneNumberObject DTOToPhoneNumpber(PhoneNumberDTO phoneNumberDTO)
        {
            return new DummyPhoneNumberObject() { PhoneNumberValue = phoneNumberDTO.PhoneNumberValue };
        }

        private PhoneNumberDTO PhoneNumpberToDTO(PhoneNumber phoneNumber)
        {
            return new PhoneNumberDTO() { PhoneNumberValue = phoneNumber.PhoneNumberValue};
        }
    }
}
