using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkShark.API.Controllers.Divisions.DTO;
using ParkShark.API.Controllers.Divisions.Mappers.Interfaces;
using ParkShark.Domain.Divisions;
using ParkShark.Services.Divisions;
using ParkShark.Services.Divisions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.Divisions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionsController : ControllerBase
    {
        private readonly IDivisionServices _divisionServices;
        private readonly IDivisionMapper _divisionMapper;

        public DivisionsController(IDivisionServices divisionServices, IDivisionMapper divisionMapper)
        {
            _divisionServices = divisionServices;
            _divisionMapper = divisionMapper;
        }

        // GET: api/Divisions
        [HttpGet]
        public List<DivisionDTO_Return> GetAllDivisions()
        {
            return _divisionMapper.CreateListOfDivisionDTOsFromDivisionList(_divisionServices.GetAllDivisions());
        }

        // GET: api/Divisions/5
        [HttpGet("{DivisionID}")]
        public ActionResult<DivisionDTO_Return> GetSingleDivision(Guid DivisionID)
        {
            var result = _divisionServices.GetSingleDivision(DivisionID);

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

            _divisionServices.CreateDivision(division);
            return Ok(_divisionMapper.CreateDivisionDTOReturnFromDivision(division));

        }



        // PUT: api/Divisions/5
        [HttpPut("{parentId}")]
        public ActionResult<DivisionDTO_Return> AssignParentDivision([FromRoute]string parentId, [FromBody]string subId)
        {
            Division parent = null;
            Division sub = null;

            parent = _divisionServices.GetSingleDivision(new Guid(parentId));
            sub = _divisionServices.GetSingleDivision(new Guid(subId));

            if (parent == null || sub == null)
            {
                return BadRequest();
            }

            var DivisionWithParent = _divisionServices.AssignParentDivision(sub, parent);

            if (DivisionWithParent == null)
            {
                return BadRequest();
            }

            return Ok(_divisionMapper.CreateDivisionDTOReturnFromDivision(DivisionWithParent));
        }


    }
}
