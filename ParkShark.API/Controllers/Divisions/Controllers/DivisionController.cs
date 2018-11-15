using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkShark.API.Controllers.Divisions.DTO;
using ParkShark.API.Controllers.Divisions.Mappers.Interfaces;
using ParkShark.Services.Divisions.Interfaces;

namespace ParkShark.API.Controllers.Divisions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {

        private readonly IDivisionServices _divisionSerices;
        private readonly IDivisionMapper _divisionMapper;

        public DivisionController(IDivisionServices divisionSerices, IDivisionMapper divisionMapper)
        {
            _divisionSerices = divisionSerices;
            _divisionMapper = divisionMapper;
        }



        // GET: api/Division
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Division/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Division
        [HttpPost]
        public ActionResult<DivisionDTO_Create> CreateDivision([FromBody] DivisionDTO_Create divisionDTO)
        {
            var division = _divisionMapper.CreateDivisionFromDivisionDTOCreate(divisionDTO);
            if (division == null)
            {
                return BadRequest("not valid");
            }

            _divisionSerices.AddDivisionToDBbContext(division);
            return Ok(_divisionMapper.CreateDivisionDTOReturnFromDivision(division));

        }

        // PUT: api/Division/5
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
