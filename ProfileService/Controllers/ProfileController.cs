using AutoMapper;
using IBusiness;
using IBusiness.Dto;
using Microsoft.AspNetCore.Mvc;
using ProfileService.Models;

namespace ProfileService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileLogic _profilelogic;
        private readonly IMapper _mapper;

        public ProfileController(IProfileLogic profileLogic, IMapper mapper)
        {
            _profilelogic = profileLogic;
            _mapper = mapper;
        }
        [HttpPost(Name = "CreateProfile")]
        public async Task<ActionResult<ProfileModel>> CreateProfile(ProfileModel profile)
        {
            ProfileCreateDto profileCreateDto = _mapper.Map<ProfileCreateDto>(profile);
            _profilelogic.Create(profileCreateDto);
            return Ok(profile);
        }
    }
}
