namespace ParkShark.API.Controllers.Members.DTO
{
    public class AddressDTO
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public CityDTO CityDTO { get; set; }

    }
}