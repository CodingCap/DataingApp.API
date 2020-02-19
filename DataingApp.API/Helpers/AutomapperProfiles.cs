using System.Linq;
using AutoMapper;
using DataingApp.API.Dtos;
using DataingApp.API.Models;

namespace DataingApp.API.Helpers
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(d => d.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(d => d.Age, opt => opt.MapFrom(s => s.DathOfBirth.CalculateAge()));
            
            CreateMap<User, UserforDetailDto>()
                .ForMember(d => d.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(d => d.Age, opt => opt.MapFrom(s => s.DathOfBirth.CalculateAge()));
            
            CreateMap<Photo, PhotosForDetailedDto>();
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto, Photo>();

            CreateMap<UserForUpdateDto, User>();
        }
    }
}
