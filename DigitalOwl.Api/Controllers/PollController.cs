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
    [Route("api/[controller]")]
    public class PollController : BaseController<PollController>
    {
        private readonly IPollService _pollService;

        public PollController(IMapper mapper, ILogger<PollController> logger,
                              IPollService pollService) : base(mapper, logger)
        {
            _pollService = pollService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dto =  _pollService.GetAll();
            return Ok(dto.Result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var dto = await _pollService.GetById(id);

            if (!dto.Succeeded)
            {
                return BadRequest();
            }

            return Ok(dto.Result);
        }

        [HttpPost("")]
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CreatePoll model, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity();

            var dto = await _pollService.GetById(id);

            if (!dto.Succeeded)
            {
                return UnprocessableEntity();
            }

            _mapper.Map(model, dto.Result);
            var updated = await _pollService.UpdateAsync(dto.Result, UserId);

            if (!updated.Succeeded)
                return UnprocessableEntity();

            return Ok(updated.Result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _pollService.Delete(id);

            if (!result.Succeeded)
                return BadRequest();

            return NoContent();
        }
    }
}