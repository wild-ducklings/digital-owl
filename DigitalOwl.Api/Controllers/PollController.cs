using System.Threading.Tasks;
using AutoMapper;
using DigitalOwl.Api.Controllers.Base;
using DigitalOwl.Api.Model;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;
using DigitalOwl.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DigitalOwl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PollController : BaseController<PollController>
    {
        private IPollService _pollService;

        public PollController(IMapper mapper, ILogger<PollController> logger, IPollService pollService) : base(mapper, logger)
        {
            _pollService = pollService;
        }

        [HttpGet("")]
        public async Task<IActionResult> getAll()
        {
            var _dto = await _pollService.GetAll();
            return Ok(_dto.Result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getById([FromRoute] int id)
        {
            var _dto = await _pollService.GetById(id);

            if (!_dto.Succeeded)
            {
                return UnprocessableEntity();
            }
            return Ok(_dto.Result);
        }

        [HttpPost]
        public async Task<IActionResult> create([FromBody] CreatePoll x)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(x);
            }

            var _dto = _mapper.Map<DtoPoll>(x);
            _dto.Id = 0;
            
            var result = await _pollService.CreateAsync(_dto, 6);

            if (!result.Succeeded)
            {
                return UnprocessableEntity();
            }

            return Ok(result.Result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> update([FromBody] CreatePoll x, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity();

            var _dto = await _pollService.GetById(id);

            if (!_dto.Succeeded)
            {
                return UnprocessableEntity();
            }

            _mapper.Map(x, _dto.Result);
            // TODO: userID
            var updated = await _pollService.UpdateAsync(_dto.Result, 6);
            if (!updated.Succeeded)
                return UnprocessableEntity();
            return Ok(((DtoResponseResult<DtoPoll>) updated).Result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete([FromRoute] int id)
        {
            var result = await _pollService.Delete(id);
            
            if(!result.Succeeded)
                return BadRequest();

            return NoContent();
        }
    }
}