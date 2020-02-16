using System;
using System.Threading.Tasks;
using DataingApp.API.Dtos;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        //daca scot atributul ApiController nu va sti sa mapeze DTO cu parmaetri. Atunci se adauga atributul [FromBody] la parametri din metoda
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //TODO
            //validate request
            //daca scot atributul ApiController de la clasa atunci tre sa validez model statul
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);


            //throw new ValidationException("de la mine");
            return await _mediator.Send(userForRegisterDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDTO userForLoginDto)
        {
            var result = await _mediator.Send(userForLoginDto);

            if (string.IsNullOrEmpty(result))
                return Unauthorized();
            return Ok(new
            {
                token = result
            });
        }
    }
}
