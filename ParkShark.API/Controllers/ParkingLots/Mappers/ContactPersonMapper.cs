using ParkShark.API.Controllers.Members.Mappers.Interfaces;
using ParkShark.API.Controllers.ParkingLots.DTO;
using ParkShark.API.Controllers.ParkingLots.Mappers.Interfaces;
using ParkShark.Domain.ParkingLots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.ParkingLots.Mappers
{
    public class ContactPersonMapper : IContactPersonMapper
    {
        private readonly IAddressMapper _addressMapper;

        public ContactPersonMapper(IAddressMapper addressMapper)
        {
            _addressMapper = addressMapper;
        }

        public ContactPerson FromContactPersonDTOTOContactPerson(ContactPersonDTO contactPersonDTO)
        {
            ContactPerson contactPerson = ContactPerson.CreateNewContactPerson(
                contactPersonDTO.FirstName,
                contactPersonDTO.LastName,
                _addressMapper.DTOToAddress(contactPersonDTO.Address),
                contactPersonDTO.Email,
                contactPersonDTO.PhoneNumber,
                contactPersonDTO.MobilePhoneNumber);
            return contactPerson;

        }

        public ContactPersonDTO FromContactPersonTOContactPersonDTO(ContactPerson contactPerson)
        {
            var contactPersonDTO = new ContactPersonDTO
            {
                Address = _addressMapper.AddressToDTO(contactPerson.Address),
                Email = contactPerson.Email,
                FirstName = contactPerson.FirstName,
                LastName = contactPerson.LastName,
                MobilePhoneNumber = contactPerson.MobilePhoneNumber,
                PhoneNumber = contactPerson.PhoneNumber
            };
            return contactPersonDTO;
        }
    }
}
