using ParkShark.API.Controllers.Members.DTO;
using ParkShark.API.Controllers.Members.Mappers.Interfaces;
using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.Members.Mappers
{
    public class LicensePlateMapper : ILicensePlateMapper
    {
        public List<DummyLicensePlateObject> DTOListToLicensePlateObject(List<LicensePlateDTO> licensePlateDTOList)
        {
            var LicensePlate_ReturnList = new List<DummyLicensePlateObject>();

            foreach (LicensePlateDTO item in licensePlateDTOList)
            {
                var LicensePlate = DTOToLicensePlateObject(item);
                LicensePlate_ReturnList.Add(LicensePlate);
            }

            return LicensePlate_ReturnList;
        }
        private DummyLicensePlateObject DTOToLicensePlateObject(LicensePlateDTO licensePlateDTO)
        {
            return new DummyLicensePlateObject() { LicensePlateValue = licensePlateDTO.LicensePlateValue, IssueingCountry = licensePlateDTO.IssueingCountry };
        }

        public List<LicensePlateDTO> LicensePlateListToDTO(List<LicensePlate> licensePlateList)
        {
            var LicensePlate_ReturnList = new List<LicensePlateDTO>();

            foreach (LicensePlate item in licensePlateList)
            {
                var LicensePlate = LicensePlateToDTO(item);
                LicensePlate_ReturnList.Add(LicensePlate);
            }

            return LicensePlate_ReturnList;
        }
        private LicensePlateDTO LicensePlateToDTO(LicensePlate licensePlate)
        {
            return new LicensePlateDTO() { IssueingCountry = licensePlate.IssueingCountry, LicensePlateValue = licensePlate.LicensePlateValue };
        }
    }
}
