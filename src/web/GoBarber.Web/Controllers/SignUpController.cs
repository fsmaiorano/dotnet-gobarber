using Microsoft.AspNetCore.Mvc;

namespace GoBarber.Web.Controllers
{
    [Route("signup")]
    public class SignUpController: Controller
    {
         [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}