using System;
using System.Threading.Tasks;
using AutoMapper;
using DigitalOwl.Api.Controllers.Base;
using DigitalOwl.Api.Model;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;
using DigitalOwl.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace DigitalOwl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : BaseController<GroupController>
    {
        private IGroupService _groupService;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        /// <param name="groupService"></param>
        public GroupController(IMapper mapper, ILogger<GroupController> logger, IGroupService groupService)
            : base(mapper, logger)
        {
            _groupService = groupService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await _groupService.GetAll();

            return Ok(dtos.Result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _groupService.GetById(id);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Result);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] CreateGroup model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = _mapper.Map<DtoGroup>(model);
            dto.Id = 0;

            var newDto = await _groupService.CreateAsync(dto, UserId);

            if (!newDto.Succeeded)
            {
                return UnprocessableEntity(newDto.Errors);
            }

            return Ok(newDto.Result);
        }

        [HttpPut("{id}")]
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

            var newDto = (DtoResponseResult<DtoGroup>) result;

            return Ok(newDto.Result);
        }

        [HttpDelete("{id}")]
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