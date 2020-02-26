using MediatR;

namespace DataingApp.API.Dtos
{
    public class UserForLoginDTO : IRequest<(string, UserForListDto user)>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
