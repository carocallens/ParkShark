using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkShark.API.Controllers.Divisions.DTO;
using ParkShark.API.Controllers.Divisions.Mappers.Interfaces;
using ParkShark.Domain.Divisions;
using ParkShark.Services.Divisions.Interfaces;

namespace ParkShark.API.Controllers.Divisions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionsController : ControllerBase
    {

        private readonly IDivisionServices _divisionSerices;
        private readonly IDivisionMapper _divisionMapper;

        public DivisionsController(IDivisionServices divisionSerices, IDivisionMapper divisionMapper)
        {
            _divisionSerices = divisionSerices;
            _divisionMapper = divisionMapper;
        }



        // GET: api/Divisions
        [HttpGet]
        public List<DivisionDTO_Return> GetAllDivisions()
        {
            return _divisionMapper.CreateListOfDivisionDTOsFromDivisionList(_divisionSerices.GetAllDivisions());
        }

        // GET: api/Divisions/5
        [HttpGet("{DivisionID}")]
        public ActionResult<DivisionDTO_Return> GetSingleDivision(string DivisionID)
        {
            var result = _divisionSerices.GetSingleDivision(DivisionID);

            if (result == null)
            { return BadRequest("invalid"); }

            return Ok(_divisionMapper.CreateDivisionDTOReturnFromDivision(result));
        }

        // POST: api/Divisions
        [HttpPost]
        public ActionResult<DivisionDTO_Return> CreateDivision([FromBody] DivisionDTO_Create divisionDTO)
        {
            var division = _divisionMapper.CreateDivisionFromDivisionDTOCreate(divisionDTO);
            if (division == null)
            {
                return BadRequest("not valid");
            }

            _divisionSerices.AddDivisionToDBbContext(division);
            return Ok(_divisionMapper.CreateDivisionDTOReturnFromDivision(division));

        }

        // PUT: api/Divisions/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
