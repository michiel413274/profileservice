using Microsoft.AspNetCore.Mvc;
using ProfileService.Models;

namespace ProfileService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        [HttpPost(Name = "CreateProfile")]
        public async Task<ActionResult<ProfileModel>> CreateProfile(ProfileModel profile)
        {

            return Ok(profile);
        }
    }
}
