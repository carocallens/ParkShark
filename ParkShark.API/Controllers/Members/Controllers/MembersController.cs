﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkShark.API.Controllers.Members.DTO;
using ParkShark.API.Controllers.Members.Mappers.Interfaces;
using ParkShark.Domain.Members;
using ParkShark.Services.Members.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var dummyMember = _memberMapper.DTOToDummyMemberObject(memberDTO);

            var member = _memberService.CreateNewMember(dummyMember);

            if (member == null)
            {
                return BadRequest("Not valid");
            }

            var result = _memberService.AddPhonenumersAndLicensPlatesToMember(dummyMember, member);
            if (!result)
            {
                return BadRequest("Not valid");
            }

            return Ok(_memberMapper.MemberToDTOReturn(member));
        }

        [HttpGet]
        public List<MemberDTO_Return> GetAllMembers()
        {
            var MemberList = _memberService.GetAllMembers();
            var MemberDTO_ReturnList = _memberMapper.MemberListToDTOReturnList(MemberList);
            return MemberDTO_ReturnList;
        }

        [HttpGet("{Member_ID}")]
        public ActionResult<MemberDTO_Return> GetSingleMember([FromRoute]string Member_ID)
        {
            var member = _memberService.GetMember(new Guid(Member_ID));

            if (member == null)
            {
                return BadRequest("Not valid");
            }

            return Ok(_memberMapper.MemberToDTOReturn(member));
        }
    }
}