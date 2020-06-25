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
    /// <summary>
    /// Endpoint to Poll Answer
    /// </summary>
    [ApiController]
    [Route("api/question")]
    [Produces("application/json")]
    public class PollAnswerController : BaseController<PollAnswer>
    {
        private readonly IPollAnswerService _pollAnswerService;
        private readonly IPollQuestionService _pollQuestionService;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        /// <param name="pollAnswerService"></param>
        /// <param name="pollQuestionService"></param>
        public PollAnswerController(IMapper mapper, ILogger<PollAnswer> logger,
                                    IPollAnswerService pollAnswerService,
                                    IPollQuestionService pollQuestionService) : base(mapper, logger)
        {
            _pollAnswerService = pollAnswerService;
            _pollQuestionService = pollQuestionService;
        }


        /// <summary>
        /// Return All answers
        /// </summary>
        /// <returns></returns>
        [HttpGet("answers")]
        [ProducesResponseType(typeof(IEnumerable<DtoPollAnswer>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await _pollAnswerService.GetAll();
            return Ok(dtos.Result);
        }

        /// <summary>
        /// Return All answers in question
        /// </summary>
        /// <param name="questionId">questionId which answers returns</param>
        /// <returns></returns>
        [HttpGet("{questionId}/answers")]
        [ProducesResponseType(typeof(IEnumerable<DtoPollAnswer>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromRoute] int questionId)
        {
            var dtos = await _pollAnswerService.GetAll(questionId);
            return Ok(dtos.Result);
        }

        /// <summary>
        /// Return answer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("answers/{id}")]
        [ProducesResponseType(typeof(DtoPollAnswer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var dto = await _pollAnswerService.GetById(id);

            if (!dto.Succeeded)
            {
                return BadRequest(dto.Errors);
            }

            return Ok(dto.Result);
        }

        /// <summary>
        /// Create new answer
        /// </summary>
        /// <param name="model">new answer</param>
        /// <param name="questionId">id to which answer belongs</param>
        /// <returns></returns>
        [HttpPost("{questionId}/answers")]
        [ProducesResponseType(typeof(DtoPollAnswer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreatePollAnswer model,
                                                [FromRoute] int questionId)
        {
            var resultPQ = await _pollQuestionService.GetById(questionId);
            if (!resultPQ.Succeeded)
            {
                return BadRequest(resultPQ.Errors);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            var dto = _mapper.Map<DtoPollAnswer>(model);

            dto.Id = 0;
            dto.PollQuestionId = questionId;

            var result = await _pollAnswerService.CreateAsync(dto, UserId);

            if (!result.Succeeded)
            {
                return UnprocessableEntity(result.Errors);
            }

            return Ok(result.Result);
        }

        /// <summary>
        /// Create list of answers
        /// </summary>
        /// <param name="models">new answer</param>
        /// <param name="questionId">id to which answer belongs</param>
        /// <returns></returns>
        [HttpPost("{questionId}/answer_list")]
        [ProducesResponseType(typeof(IEnumerable<DtoPollAnswer>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] IEnumerable<CreatePollAnswer> models,
                                                [FromRoute] int questionId)
        {
            var resultPQ = await _pollQuestionService.GetById(questionId);
            if (!resultPQ.Succeeded)
            {
                return BadRequest(resultPQ.Errors);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(models);
            }

            var dtos = _mapper.Map<IEnumerable<DtoPollAnswer>>(models);

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


        /// <summary>
        /// Update answer
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("answers/{id}")]
        [ProducesResponseType(typeof(DtoPollAnswer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary),
            StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody] CreatePollAnswer model,
                                                [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

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

        /// <summary>
        /// Delete answer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("answers/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _pollAnswerService.Delete(id);

            if (!result.Succeeded)
                return BadRequest();

            return NoContent();
        }
    }
}