using DataingApp.API.Dtos;
using MediatR;

namespace DataingApp.API.CQRS.Queries
{
    public class GetUserByIDQuery : IRequest<UserforDetailDto>
    {
        public int Id { get; }

        public GetUserByIDQuery(int id)
        {
            Id = id;
        }
    }
}
