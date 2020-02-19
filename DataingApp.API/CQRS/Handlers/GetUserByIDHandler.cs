using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataingApp.API.CQRS.Queries;
using DataingApp.API.Data;
using DataingApp.API.Dtos;
using MediatR;

namespace DataingApp.API.CQRS.Handlers
{
    public class GetUserByIDHandler : IRequestHandler<GetUserByIDQuery, UserforDetailDto>
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;

        public GetUserByIDHandler(IDatingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }



        public async Task<UserforDetailDto> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
        {
            var user = await _repo.GetUserAsync(request.Id);
            
            return user == null ? null : _mapper.Map<UserforDetailDto>(user);
        }
    }
}
