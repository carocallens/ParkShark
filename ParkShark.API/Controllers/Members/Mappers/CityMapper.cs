using ParkShark.API.Controllers.Members.DTO;
using ParkShark.API.Controllers.Members.Mappers.Interfaces;
using ParkShark.Domain.Members;
using ParkShark.Services.Members.Interfaces;

namespace ParkShark.API.Controllers.Members.Mappers
{
    public class CityMapper : ICityMapper
    {
        private readonly IMemberServices _memberService;

        public CityMapper(IMemberServices memberService)
        {
            _memberService = memberService;
        }

        public CityDTO CityToDTO(City city)
        {
            return new CityDTO() { CityName = city.CityName, CountryName = city.CountryName, ZIP = city.ZIP };
        }

        public City DTOToCity(CityDTO cityDTO)
        {
            var result = _memberService.ZIPExistsInDB(cityDTO.ZIP);

            if (result == null)
            {
                return new City(cityDTO.ZIP, cityDTO.CountryName, cityDTO.CountryName);
            }

            else return result;
        }
    }
}
