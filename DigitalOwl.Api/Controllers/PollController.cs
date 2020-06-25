using System.Threading.Tasks;
using AutoMapper;
using DigitalOwl.Api.Controllers.Base;
using DigitalOwl.Api.Model;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace DigitalOwl.Api.Controllers
{
    /// <summary>
    /// Endpoint of Poll
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PollController : BaseController<PollController>
    {
        private readonly IPollService _pollService;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        /// <param name="pollService"></param>
        public PollController(IMapper mapper, ILogger<PollController> logger,
                              IPollService pollService) : base(mapper, logger)
        {
            _pollService = pollService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dto = await _pollService.GetAllIncluded();
            return Ok(dto.Result);
        }

        /// <summary>
        /// Get poll by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(System.Collections.Generic.IEnumerable<string>), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var dto = await _pollService.GetByIdIncluded(id);

            if (!dto.Succeeded)
            {
                return BadRequest(dto.Errors);
            }

            return Ok(dto.Result);
        }

        /// <summary>
        /// Create poll
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CreatePoll), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreatePoll x)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(x);
            }

            var dto = _mapper.Map<DtoPoll>(x);
            dto.Id = 0;

            var result = await _pollService.CreateAsync(dto, UserId);

            if (!result.Succeeded)
            {
                return UnprocessableEntity();
            }

            return Ok(result.Result);
        }

        /// <summary>
        /// Update poll
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary),
            StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody] CreatePoll model, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var dto = await _pollService.GetById(id);

            if (!dto.Succeeded)
            {
                return UnprocessableEntity(dto.Errors);
            }

            _mapper.Map(model, dto.Result);
            var updated = await _pollService.UpdateAsync(dto.Result, UserId);

            if (!updated.Succeeded)
                return UnprocessableEntity(updated.Errors);

            return Ok(updated.Result);
        }

        /// <summary>
        /// Delete poll
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(System.Collections.Generic.IEnumerable<string>), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _pollService.Delete(id);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return NoContent();
        }
    }
}