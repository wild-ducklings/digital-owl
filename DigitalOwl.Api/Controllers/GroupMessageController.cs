using System.Threading.Tasks;
using AutoMapper;
using DigitalOwl.Api.Controllers.Base;
using DigitalOwl.Api.Model;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DigitalOwl.Api.Controllers
{
    [ApiController]
    [Route("api/group")]
    public class GroupMessageController : BaseController<GroupMessageController>
    {
        private readonly IGroupMessageService _groupMessageService;
        private readonly IGroupService _groupService;

        public GroupMessageController(IMapper mapper, ILogger<GroupMessageController> logger,
                                      IGroupMessageService groupMessageService, IGroupService groupService)
            : base(mapper, logger)
        {
            _groupMessageService = groupMessageService;
            _groupService = groupService;
        }

        [HttpGet("{groupId}/message")]
        public async Task<IActionResult> GetAllByGroupId([FromRoute] int groupId)
        {
            var dtos = await _groupMessageService.GetAllByGroupId(groupId);
            return Ok(dtos.Result);
        }

        [HttpGet("{groupId}/message/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int groupId, [FromRoute] int id)
        {
            var dtos = await _groupMessageService.GetById(id);
            return Ok(dtos.Result);
        }

        [HttpPost("{groupId}/message")]
        public async Task<IActionResult> Create([FromBody] CreateGroupMessage model, [FromRoute] int groupId)
        {
            var group = await _groupService.GetById(groupId);
            if (!group.Succeeded)
            {
                return BadRequest(group.Errors);
            }

            var dto = _mapper.Map<DtoGroupMessage>(model);
            dto.GroupId = groupId;
            dto.UserId = UserId;

            var result = await _groupMessageService.CreateAsync(dto, UserId);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }


            return Ok(result.Result);
        }

        [HttpPut("{groupId}/message/{id}")]
        public async Task<IActionResult> Update([FromBody] CreateGroupMessage model, [FromRoute] int groupId,
                                                [FromRoute] int id)
        {
            var group = await _groupService.GetById(groupId);
            if (!group.Succeeded)
            {
                return BadRequest(group.Errors);
            }

            var messageResult = await _groupMessageService.GetById(id);
            if (!messageResult.Succeeded)
            {
                return BadRequest(messageResult.Errors);
            }

            var message = messageResult.Result;
            if (message.GroupId != groupId)
            {
                return BadRequest("Can not update Group Message to other Group");
            }

            _mapper.Map(model, message);

            var result = await _groupMessageService.UpdateAsync(message, UserId);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Result);
        }

        [HttpDelete("{groupId}/message/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int groupId, [FromRoute] int id)
        {
            var dto = await _groupMessageService.GetById(id);
            if (!dto.Succeeded)
            {
                return BadRequest(dto.Errors);
            }

            var result = await _groupMessageService.Delete(id);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }
    }
}