using AutoMapper;
using GetriWebApi.Models;

namespace Application.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Activity, Activity>();
        }
    }
}
