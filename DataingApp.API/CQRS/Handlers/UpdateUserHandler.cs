using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataingApp.API.Data;
using DataingApp.API.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataingApp.API.CQRS.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UserForUpdateDto, IActionResult>
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IDatingRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(UserForUpdateDto request, CancellationToken cancellationToken)
        {
            var repoUser = await _repo.GetUserAsync(request.DtoId);
            if (repoUser == null) return new NotFoundObjectResult(new {UserID = request.DtoId});
            
            _mapper.Map(request, repoUser);

            if (!await _repo.SaveAllAsync())
                throw new Exception($"Updating user {request.DtoId} failed on save");

            return new NoContentResult();
        }
    }
}
