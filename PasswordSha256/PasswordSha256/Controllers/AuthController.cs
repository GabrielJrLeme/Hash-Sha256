using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PasswordSha256.Model;
using PasswordSha256.Services;

namespace PasswordSha256.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class AuthController : ControllerBase
    {

        private readonly AuthService _auth;

        public AuthController(AuthService auth)
        {
            _auth = auth;         
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetUsers()
            => Ok(_auth.ListUsers());

        
        [HttpPost]
        [Route("login")]
        public IActionResult PostUserLogin(Usuario model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_auth.LoginUser(model))
                NotFound("Erro de log");

            return Ok("Logado");
        }


        [HttpPost]
        [Route("create")]
        public IActionResult PostCreateUser(Usuario model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = _auth.GenerationPassword(model);

            return Created("Gerado", user);
        }

    }
}