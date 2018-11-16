using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkShark.API.Controllers.Members.DTO;
using ParkShark.API.Controllers.Members.Mappers.Interfaces;
using ParkShark.Services.Members.Interfaces;

namespace ParkShark.API.Controllers.Members.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberServices _memberService;
        private readonly IMemberMapper _memberMapper;

        public MembersController(IMemberServices memberService, IMemberMapper memberMapper)
        {
            _memberService = memberService;
            _memberMapper = memberMapper;
        }

        [HttpPost]
        public ActionResult<MemberDTO_Return> CreateMember(MemberDTO_Create memberDTO)
        {
            var member = _memberMapper.DTOToMember(memberDTO);

            if(member == null)
            {
                return BadRequest("Not valid");
            }

            _memberService.AddMemberToDBContext(member);

            return Ok(_memberMapper.MemberToDTOReturn(member));
        }
    }
}