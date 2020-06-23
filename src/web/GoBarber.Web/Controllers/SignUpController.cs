using GoBarber.DTO.User;
using GoBarber.Web.Helpers;
using GoBarber.Web.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace GoBarber.Web.Controllers
{
    [Route("signup")]
    public class SignUpController : Controller
    {
        private IMemoryCache _cache;

        public SignUpController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] UserInput input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var signInResponse = await UserService.Register(input);

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