using ParkShark.API.Controllers.Members.DTO;
using ParkShark.Domain.Members;

namespace ParkShark.API.Controllers.Members.Mappers.Interfaces
{
    public interface ICityMapper
    {
        City DTOToCity(CityDTO cityDTO);
    }
}
