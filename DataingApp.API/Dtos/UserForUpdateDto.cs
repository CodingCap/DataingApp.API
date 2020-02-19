using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataingApp.API.Dtos
{
    public class UserForUpdateDto : IRequest<IActionResult>
    {
        public int DtoId { get; set; }
        public string Introduction { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Interests { get; set; }
    }
}
