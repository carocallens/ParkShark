﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkShark.API.Controllers.Divisions.DTO;
using ParkShark.API.Controllers.Divisions.Mappers.Interfaces;
using ParkShark.Domain.Divisions;
using ParkShark.Services.Divisions;
using ParkShark.Services.Divisions.Interfaces;

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
            var result = _divisionServices.CreateDivision(_divisionMapper.CreateDivisionFromDivisionDTOCreate(divisionDTO));
            if (result == null)
            {
                return BadRequest("not valid");
            }
            return Ok(_divisionMapper.CreateDivisionDTOReturnFromDivision(result));

        }



        // PUT: api/Divisions/5
        [HttpPut("{parentId}")]
        public ActionResult<DivisionDTO_Return> AssignParentDivision([FromRoute]Guid parentId, [FromBody]Guid subId)
        {
            Division parent = null;
            Division sub = null;

            parent = _divisionServices.GetSingleDivision(parentId);
            sub = _divisionServices.GetSingleDivision(subId);

            if (parent == null || sub == null)
            {
                return BadRequest();
            }

            var DivisionWithParent = DivisionService.AssignParentDivision(sub, parent);

            if(DivisionWithParent == null)
            {
                return BadRequest();
            }

            return Ok(_divisionMapper.CreateDivisionDTOReturnFromDivision(DivisionWithParent));
        }


    }
}
