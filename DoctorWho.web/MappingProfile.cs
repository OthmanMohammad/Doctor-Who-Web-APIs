using AutoMapper;
using DoctorWho.Domain;
using DoctorWho.web.DTOs;

namespace DoctorWho.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Companion, CompanionDto>().ReverseMap();
            CreateMap<Episode, EpisodeDto>().ReverseMap();
            CreateMap<Enemy, EnemyDto>().ReverseMap();
        }
    }
}
