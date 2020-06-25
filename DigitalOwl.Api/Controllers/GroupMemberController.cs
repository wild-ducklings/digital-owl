using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigitalOwl.Api.Controllers.Base;
using DigitalOwl.Api.Helpers;
using DigitalOwl.Api.Model.User;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Interface;
using DigitalOwl.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace DigitalOwl.Api.Controllers
{
    /// <summary>
    /// GroupMember Endpoint
    /// </summary>
    [ApiController]
    [Route("api/group")]
    [Produces("application/json")]
    public class GroupMemberController : BaseController<GroupMemberController>
    {
        private readonly IGroupMemberService _groupMemberService;
        private readonly IGroupService _groupService;
        private readonly IGroupRoleService _groupRoleService;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="mapper">aa</param>
        /// <param name="logger"></param>
        /// <param name="groupMemberService"></param>
        /// <param name="groupService"></param>
        /// <param name="groupRoleService"></param>
        public GroupMemberController(IMapper mapper, ILogger<GroupMemberController> logger,
                                     IGroupMemberService groupMemberService, IGroupService groupService,
                                     IGroupRoleService groupRoleService)
            : base(mapper, logger)
        {
            _groupMemberService = groupMemberService;
            _groupService = groupService;
            _groupRoleService = groupRoleService;
        }

        /// <summary>
        /// Only debug return all group member
        /// </summary>
        /// <returns></returns>
        // TODO delete it only debug never use it on production
        [Obsolete("Debug only")]
        [HttpGet("member")]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await _groupMemberService.GetAll();
            return Ok(dtos.Result);
        }

        /// <summary>
        /// Return member of group 
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpGet("{groupId}/member")]
        public async Task<IActionResult> GetAllByGroupId([FromRoute] int groupId)
        {
            var dtos = await _groupMemberService.GetAllByGroupId(groupId);
            return Ok(dtos.Result);
        }

        /// <summary>
        /// Method adding User to the Group ultimately by User Name 
        /// </summary>
        /// <param name="model">User who is going to add</param>
        /// <param name="groupId">Group which User will be add</param>
        /// <returns></returns>
        [HttpPost("{groupId}/member")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(System.Collections.Generic.IEnumerable<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] ViewUser model, [FromRoute] int groupId)
        {
            // TODO Error checking
            var userResult = await _groupMemberService.GetAllByGroupAndUserId(groupId, UserId);
            var user = userResult.Result;
            var userPolicy = await _groupRoleService.GetPoliceNameById(user.GroupRoleId);
            if (userPolicy.Result != GroupPoliceName.CanAddAndDeleteUser &&
                userPolicy.Result != GroupPoliceName.CanEverything)
            {
                return Unauthorized("You cannot do it in this group");
            }

            var groupResult = await _groupService.GetById(groupId);
            if (!groupResult.Succeeded)
            {
                return BadRequest(groupResult.Errors);
            }

            //Todo Error checking
            var roleId = await _groupRoleService.GeIdByName(model.userRole);

            // TODO use UserService to find Id by Name 
            var dto = new DtoGroupMember
            {
                Id = 0,
                GroupId = groupId,
                UserId = model.Id,
                GroupRoleId = roleId.Result,
            };
            var dtoResult = await _groupMemberService.CreateAsync(dto, UserId);
            if (!dtoResult.Succeeded)
            {
                return BadRequest(dtoResult.Errors);
            }

            return NoContent();
        }

        // path dont contains id 'cause use delete by User 
        /// <summary>
        ///  Delete user in Group if all user will be delete group also will be
        /// </summary>
        /// <param name="model"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpDelete("{groupId}/member")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(System.Collections.Generic.IEnumerable<string>), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete([FromBody] ViewUser model, [FromRoute] int groupId)
        {
            // TODO think about check if group exist and add error about it
            // TODO use UserService
            var dto = await _groupMemberService.GetAllByGroupAndUserId(model.Id, groupId);
            if (!dto.Succeeded)
            {
                return BadRequest(dto.Errors);
            }

            var result = await _groupMemberService.Delete(dto.Result.Id);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var dtos = await _groupMemberService.GetAllByGroupId(groupId);
            if (!dtos.Succeeded)
            {
                return BadRequest(dtos.Errors);
            }

            // if number of GroupMember in Group is equal 0 
            // Group must be deleted 
            if (dtos.Result.Any())
            {
                return NoContent();
            }

            result = await _groupMemberService.Delete(dto.Result.Id);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }
    }
}