using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DigitalOwl.Api.Controllers.Base;
using DigitalOwl.Api.Model;
using DigitalOwl.Repository.Entity;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace DigitalOwl.Api.Controllers
{
    [ApiController]
    [Route("api/poll")]
    [Produces("application/json")]
    public class PollQuestionController : BaseController<PollQuestion>
    {
        private readonly IPollQuestionService _pollQuestionService;
        private readonly IPollService _pollService;


        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        /// <param name="pollQuestionService"></param>
        /// <param name="pollService"></param>
        public PollQuestionController(IMapper mapper, ILogger<PollQuestion> logger,
                                      IPollQuestionService pollQuestionService, IPollService pollService) : base(mapper,
            logger)
        {
            _pollQuestionService = pollQuestionService;
            _pollService = pollService;
        }

        [HttpGet("questions")]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await _pollQuestionService.GetAllIncluded();
            return Ok(dtos.Result);
        }

        [HttpGet("{PollId}/questions")]
        public async Task<IActionResult> GetAll([FromRoute] int pollId)
        {
            var dtos = await _pollQuestionService.GetAllIncluded(pollId);
            return Ok(dtos.Result);
        }

        [HttpGet("questions/{id}")]
        [ProducesResponseType(typeof(DtoPollQuestion), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var dto = await _pollQuestionService.GetByIdIncluded(id);

            if (!dto.Succeeded)
            {
                return BadRequest(dto.Errors);
            }

            var result = dto.Result;
            return Ok(result);
        }

        [HttpPost("{PollId}/questions")]
        [ProducesResponseType(typeof(DtoPollQuestion), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreatePollQuestion x, [FromRoute] int pollId)
        {
            var resultP = await _pollService.GetById(pollId);
            if (!resultP.Succeeded)
            {
                return BadRequest(resultP.Errors);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(x);
            }

            var dto = _mapper.Map<DtoPollQuestion>(x);

            dto.Id = 0;
            dto.PollId = pollId;

            var result = await _pollQuestionService.CreateAsync(dto, UserId);

            if (!result.Succeeded)
            {
                return UnprocessableEntity();
            }

            return Ok(result.Result);
        }

        [HttpPost("{PollId}/question_list")]
        [ProducesResponseType(typeof(DtoPollQuestion), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] IEnumerable<CreatePollQuestion> x,
                                                [FromRoute] int pollId)
        {
            var resultP = await _pollService.GetById(pollId);
            if (!resultP.Succeeded)
            {
                return BadRequest(resultP.Errors);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(x);
            }

            var dtos = _mapper.Map<IEnumerable<DtoPollQuestion>>(x);

            foreach (var e in dtos)
            {
                e.Id = 0;
                e.PollId = pollId;
            }

            var result = await _pollQuestionService.CreateAsync(dtos, UserId);

            if (!result.Succeeded)
            {
                return UnprocessableEntity();
            }

            return Ok(result.Result);
        }


        [HttpPut("questions/{id}")]
        [ProducesResponseType(typeof(DtoPollQuestion), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody] CreatePollQuestion model, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity();

            var dto = await _pollQuestionService.GetById(id);

            if (!dto.Succeeded)
            {
                return UnprocessableEntity();
            }

            _mapper.Map(model, dto.Result);
            var updated = await _pollQuestionService.UpdateAsync(dto.Result, UserId);

            if (!updated.Succeeded)
                return UnprocessableEntity();

            return Ok(updated.Result);
        }

        [HttpDelete("questions/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _pollQuestionService.Delete(id);

            if (!result.Succeeded)
                return BadRequest();

            return NoContent();
        }
    }
}