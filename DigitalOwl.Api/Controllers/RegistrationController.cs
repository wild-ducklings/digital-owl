using System.Threading.Tasks;
using AutoMapper;
using DigitalOwl.Api.Helpers;
using DigitalOwl.Api.Model;
using DigitalOwl.Api.Model.User;
using DigitalOwl.Repository;
using DigitalOwl.Repository.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DigitalOwl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
         private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public RegistrationController(UserManager<User> userManager, IMapper mapper, ApplicationDbContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUser model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // TODO: map to DtoUser first 
            var userIdentity = _mapper.Map<User>(model);
            userIdentity.Role = "Customer"; // TODO FIX ME only temporary not for Production

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }
    }
}