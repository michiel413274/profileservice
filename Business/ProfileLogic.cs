using AutoMapper;
using IBusiness;
using IBusiness.Dto;
using iDal.Dto;
using iDal.Interface;

namespace Business
{
    public class ProfileLogic : IProfileLogic
    {
        private readonly IProfileRepo _profileRepo;
        private readonly IMapper _mapper;

        public ProfileLogic(IProfileRepo profileRepo, IMapper mapper)
        {
            _profileRepo = profileRepo;
            _mapper = mapper;
        }
        public ProfileCreateDto Create(ProfileCreateDto profile)
        {
            ProfileSaveDto profileSave =  _mapper.Map<ProfileSaveDto>(profile);
            _profileRepo.Save(profileSave);
            return profile;
        }
    }
}
