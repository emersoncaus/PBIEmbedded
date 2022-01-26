using AutoMapper;
using PBIEmbedded.Application.Dtos;
using PBIEmbedded.Domain;

namespace PBIEmbedded.Application.Helpers
{
    public class PBIEmbeddedProfile : Profile
    {
        public PBIEmbeddedProfile()
        {
            CreateMap<Dashboard, DashboardDto>().ReverseMap();
            CreateMap<ServicePrincipal, ServicePrincipalDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}