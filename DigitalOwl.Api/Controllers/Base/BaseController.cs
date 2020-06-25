using System;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DigitalOwl.Api.Controllers.Base
{
    /// <summary>
    /// Base Controller which contains method which is using in every controller
    /// </summary>
    /// <typeparam name="TController"></typeparam>
    [Produces("application/json")]
    public class BaseController<TController> : ControllerBase
    {
        /// <summary>
        /// Automapper
        /// </summary>
        protected readonly IMapper _mapper;

        /// <summary>
        /// Logging insatnce
        /// </summary>
        protected readonly ILogger<TController> _logger;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public BaseController(IMapper mapper, ILogger<TController> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// userId whose use this endpoint
        /// </summary>
        protected int UserId
        {
            get
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                var userClaim = claimsIdentity?.FindFirst(Helpers.Constants.Strings.JwtClaimIdentifiers.Id);
                return Convert.ToInt32(userClaim?.Value);
            }
        }

        /// <summary>
        /// Role whose use this endpoint
        /// </summary>
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