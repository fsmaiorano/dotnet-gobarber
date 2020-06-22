using GoBarber.DTO.Authentication;
using GoBarber.Web.Helpers;
using GoBarber.Web.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace GoBarber.Web.Controllers.Authentication
{
    [Route("signin")]
    public class AuthenticationController : Controller
    {
        private IMemoryCache _cache;

        public AuthenticationController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AuthenticationInput input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var signInResponse = await UserService.Authentication(input);

            if (signInResponse.Success)
            {
                _cache.Set(CacheConstants.User, signInResponse.User);
                return Ok(signInResponse);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
