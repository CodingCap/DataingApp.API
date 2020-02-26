using System.Security.Claims;
using System.Threading.Tasks;
using DataingApp.API.CQRS.Queries;
using DataingApp.API.Dtos;
using DataingApp.API.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DataingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery]GetUsersQuery query)
        {
            //var query = new GetUsersQuery();
            var user = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            query.UserID = user;

            var result = await _mediator.Send(query);
            Response.AddPagination(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var query = new GetUserByIDQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserForUpdateDto userForUpdate)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            userForUpdate.DtoId = id;

            return await _mediator.Send(userForUpdate);
        }
    }
}