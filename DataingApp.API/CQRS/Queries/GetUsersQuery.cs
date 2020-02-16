using System.Collections.Generic;
using DataingApp.API.Dtos;
using MediatR;

namespace DataingApp.API.CQRS.Queries
{
    //parametru generic trebuie sa fie de tipul pe care il intoarce requestul din controller
    public class GetUsersQuery : IRequest<IEnumerable<UserForListDto>>
    {
    }
}
