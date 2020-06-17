using System;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DigitalOwl.Api.Controllers.Base
{
    public class BaseController<TController> : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly ILogger<TController> _logger;
        
        public BaseController(IMapper mapper, ILogger<TController> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }



        protected int UserId
        {
            get
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                var userClaim = claimsIdentity?.FindFirst(Helpers.Constants.Strings.JwtClaimIdentifiers.Id);
                return Convert.ToInt32(userClaim?.Value);
            }
        }

        protected string Role
        {
            get
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                var roleClaim = claimsIdentity?.FindFirst(Helpers.Constants.Strings.JwtClaimIdentifiers.Rol);
                return roleClaim?.Value;
            }
        }
    }
}