using System.Collections.Generic;
using DataingApp.API.Dtos;
using DataingApp.API.Helpers;
using MediatR;

namespace DataingApp.API.CQRS.Queries
{
    //parametru generic trebuie sa fie de tipul pe care il intoarce requestul din controller
    public class GetUsersQuery : IRequest<PagedList<UserForListDto>>
    {
        private const int MazPageSize = 50;

        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MazPageSize) ? MazPageSize : value;
        }

        public int UserID { get; set; }
        public string Gender { get; set; }

        public int MinAge { get; set; } = 18;
        public int MaxAge { get; set; } = 99;
        public string OrderBy { get; set; }
    }
}
