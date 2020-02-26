using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Mappers;
using DataingApp.API.CQRS.Queries;
using DataingApp.API.Data;
using DataingApp.API.Dtos;
using DataingApp.API.Helpers;
using MediatR;

namespace DataingApp.API.CQRS.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, PagedList<UserForListDto>>
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;

        public GetUsersHandler(IMapper mapper, IDatingRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }


        public async Task<PagedList<UserForListDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var userFormRepor = await _repo.GetUserAsync(request.UserID);
            if (string.IsNullOrEmpty(request.Gender))
            {
                request.Gender = userFormRepor.Gender == "male" ? "female" : "male";
            }


            var users = await _repo.GetUsersAsync(request);

            var userToReturn = _mapper.Map<PagedList<UserForListDto>>(users);

            return userToReturn;
        }
    }
}
