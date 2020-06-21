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

namespace DigitalOwl.Api.Controllers
{
    [ApiController]
    [Route("api/question")]
    public class PollAnswerController : BaseController<PollAnswer>
    {
        private readonly IPollAnswerService _pollAnswerService;
        private readonly IPollQuestionService _pollQuestionService;

        public PollAnswerController(IMapper mapper, ILogger<PollAnswer> logger,
                                    IPollAnswerService pollAnswerService,
                                    IPollQuestionService pollQuestionService) : base(mapper, logger)
        {
            _pollAnswerService = pollAnswerService;
            _pollQuestionService = pollQuestionService;
        }

        [HttpGet("answers")]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await _pollAnswerService.GetAll();
            return Ok(dtos.Result);
        }

        [HttpGet("{questionId}/answers")]
        public async Task<IActionResult> GetAll([FromRoute] int questionId)
        {
            var dtos = await _pollAnswerService.GetAll(questionId);
            return Ok(dtos.Result);
        }

        [HttpGet("answers/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var dto = await _pollAnswerService.GetById(id);

            if (!dto.Succeeded)
            {
                return BadRequest();
            }

            return Ok(dto.Result);
        }

        [HttpPost("{questionId}/answers")]
        public async Task<IActionResult> Create([FromBody] CreatePollAnswer x,
                                                [FromRoute] int questionId)
        {
            var resultPQ = await _pollQuestionService.GetById(questionId);
            if (!resultPQ.Succeeded)
            {
                return BadRequest(resultPQ.Errors);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(x);
            }

            var dto = _mapper.Map<DtoPollAnswer>(x);

            dto.Id = 0;
            dto.PollQuestionId = questionId;

            var result = await _pollAnswerService.CreateAsync(dto, UserId);

            if (!result.Succeeded)
            {
                return UnprocessableEntity();
            }

            return Ok(result.Result);
        }

        [HttpPost("{questionId}/answer_list")]
        public async Task<IActionResult> Create([FromBody] IEnumerable<CreatePollAnswer> x,
                                                [FromRoute] int questionId)
        {
            var resultPQ = await _pollQuestionService.GetById(questionId);
            if (!resultPQ.Succeeded)
            {
                return BadRequest(resultPQ.Errors);
            }
            
            if (!ModelState.IsValid)
            {
                return BadRequest(x);
            }

            var dtos = _mapper.Map<IEnumerable<DtoPollAnswer>>(x);

            foreach (var e in dtos)
            {
                e.Id = 0;
                e.PollQuestionId = questionId;
            }

            var result = await _pollAnswerService.CreateAsync(dtos, UserId);

            if (!result.Succeeded)
            {
                return UnprocessableEntity();
            }

            return Ok(result.Result);
        }


        [HttpPut("answers/{id}")]
        public async Task<IActionResult> Update([FromBody] CreatePollAnswer model,
                                                [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity();

            var dto = await _pollAnswerService.GetById(id);

            if (!dto.Succeeded)
            {
                return UnprocessableEntity();
            }

            _mapper.Map(model, dto.Result);
            var updated = await _pollAnswerService.UpdateAsync(dto.Result, UserId);

            if (!updated.Succeeded)
                return UnprocessableEntity();

            return Ok(updated.Result);
        }

        [HttpDelete("answers/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _pollAnswerService.Delete(id);

            if (!result.Succeeded)
                return BadRequest();

            return NoContent();
        }
    }
}