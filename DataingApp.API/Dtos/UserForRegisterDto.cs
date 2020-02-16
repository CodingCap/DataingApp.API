using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataingApp.API.Dtos
{
    public class UserForRegisterDto : IRequest<IActionResult>
    {
        //[Required(ErrorMessage = "Username cannot be empty")]
        public string UserName { get; set; }

        //[Required]
        //[StringLength(8, MinimumLength = 4, ErrorMessage = "password must be at least 4 chars long")]
        public string Password { get; set; }
    }
}
