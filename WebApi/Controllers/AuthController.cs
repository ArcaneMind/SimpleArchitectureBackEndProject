﻿using Business.Abstract;
using Core.Utilities.Security.JWT;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenHandler _tokenHadler;

        public AuthController(IAuthService authService, ITokenHandler tokenHadler)
        {
            _authService = authService;
            _tokenHadler = tokenHadler;
        }

        [HttpPost("register")]
        public IActionResult Register([FromForm] RegisterAuthDto authDto)
        {
            var result = _authService.Register(authDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginAuthDto authDto)
        {
            var result = _authService.Login(authDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
