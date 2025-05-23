﻿using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] AuthRequestDTO model)
        {

            var ret = await _service.AuthenticateAsync(model);

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }else
            {
                return Ok(ret);
            }

        }

    }
}
