using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.Divisions.DTO
{
    public class DivisionDTO_Return
    {
        public string DivisionID { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string Director { get; set; }
        public string ParentGuid { get; set; }
    }
}
