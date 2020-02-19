using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataingApp.API.CQRS.Queries;
using DataingApp.API.Data;
using DataingApp.API.Dtos;
using MediatR;

namespace DataingApp.API.CQRS.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserForListDto>>
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;

        public GetUsersHandler(IMapper mapper, IDatingRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }


        public async Task<IEnumerable<UserForListDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repo.GetUsersAsync();

            var userToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

            return userToReturn;
        }
    }
}
