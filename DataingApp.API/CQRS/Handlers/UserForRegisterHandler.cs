using System;
using System.Threading;
using System.Threading.Tasks;
using DataingApp.API.Data;
using DataingApp.API.Dtos;
using DataingApp.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataingApp.API.CQRS.Handlers
{
    public class UserForRegisterHandler : IRequestHandler<UserForRegisterDto, IActionResult>
    {
        private readonly IAuthRepository _repo;

        public UserForRegisterHandler(IAuthRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Handle(UserForRegisterDto request, CancellationToken cancellationToken)
        {
            //throw new Exception("in handkler");

            request.UserName = request.UserName.ToLower();

            if (await _repo.UserExists(request.UserName))
                return new BadRequestObjectResult("User name already exists");

            var userToCreate = new User
            {
                UserName = request.UserName
            };

            var createdUser = await _repo.Register(userToCreate, request.Password);

            //201 created
            //si ar trebui intors si obiectul creat
            return new StatusCodeResult(201);
        }
    }
}
