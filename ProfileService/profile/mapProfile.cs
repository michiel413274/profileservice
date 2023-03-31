using IBusiness.Dto;
using ProfileService.Models;
using AutoMapper;
using iDal.Dto;

namespace ProfileService.profile
{
    public class mapProfile : Profile
    {
        public mapProfile()
        {
            CreateMap<ProfileCreateDto, ProfileModel>();
            CreateMap<ProfileModel, ProfileCreateDto>();
            CreateMap<ProfileCreateDto, ProfileSaveDto>();
        }
    }
}
