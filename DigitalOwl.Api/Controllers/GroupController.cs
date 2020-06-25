using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DigitalOwl.Api.Controllers.Base;
using DigitalOwl.Api.Model;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;
using DigitalOwl.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace DigitalOwl.Api.Controllers
{
    /// <summary>
    /// Controller to use Group resources
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    // [ApiConventionType(typeof(DefaultApiConventions))]
    public class GroupController : BaseController<GroupController>
    {
        private IGroupService _groupService;
        private IGroupMemberService _groupMemberService;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        /// <param name="groupService"></param>
        /// <param name="groupMemberService"></param>
        public GroupController(IMapper mapper, ILogger<GroupController> logger, IGroupService groupService,
                               IGroupMemberService groupMemberService) : base(mapper, logger)
        {
            _groupService = groupService;
            _groupMemberService = groupMemberService;
        }

        /// <summary>
        /// Return All Group 
        /// </summary>
        /// <returns></returns>
        [Obsolete("Not for Production")]
        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<DtoGroup>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await _groupService.GetAll();

            return Ok(dtos.Result);
        }

        /// <summary>
        /// Get Group by it's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DtoGroup), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _groupService.GetById(id);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Result);
        }

        /// <summary>
        /// Create new group
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("")]
        [ProducesResponseType(typeof(DtoGroup), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary),
            StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(System.Collections.Generic.IEnumerable<string>),
            StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateGroup model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = _mapper.Map<DtoGroup>(model);

            var result = await _groupService.CreateAsync(dto, UserId);

            if (!result.Succeeded)
            {
                return UnprocessableEntity(result.Errors);
            }

            var newDto = result.Result;
            // TODO make GroupRole not by Id but by name
            await _groupMemberService.CreateAsync(new DtoGroupMember
            {
                GroupId = newDto.Id,
                UserId = UserId,
                GroupRoleId = 3
            }, UserId);
            // TODO Error checking
            return CreatedAtAction(nameof(GetById), new {id = newDto.Id}, newDto);
        }

        /// <summary>
        /// Modify Group 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DtoGroup), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary),
            StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody] CreateGroup model, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = await _groupService.GetById(id);
            if (!dto.Succeeded)
            {
                return BadRequest(dto.Errors);
            }

            _mapper.Map(model, dto.Result);

            var result = await _groupService.UpdateAsync(dto.Result, UserId);
            if (!result.Succeeded)
            {
                return UnprocessableEntity(result.Errors);
            }

            var newDto = result.Result;
            return Ok(newDto);
        }

        /// <summary>
        /// Delete group
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _groupService.Delete(id);
            if (!result.Succeeded)
            {
                return UnprocessableEntity(result.Errors);
            }

            return NoContent();
        }
    }
}