using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.Members.DTO
{
    public class CityDTO
    {
        public int ZIP { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
    }
}
