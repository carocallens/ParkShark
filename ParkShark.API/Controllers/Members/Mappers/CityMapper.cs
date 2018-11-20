using ParkShark.API.Controllers.Members.DTO;
using ParkShark.API.Controllers.Members.Mappers.Interfaces;
using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.Members.Mappers
{
    public class CityMapper : ICityMapper
    {
        public CityDTO CityToDTO(City city)
        {
            return new CityDTO() { CityName = city.CityName, CountryName = city.CountryName, ZIP = city.ZIP };
        }

        public City DTOToCity(CityDTO cityDTO)
        {
            return new City(cityDTO.ZIP, cityDTO.CountryName, cityDTO.CountryName);
        }
    }
}
