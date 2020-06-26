using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoBarber.Web.ViewComponents
{
    [ViewComponent(Name = "CalendarViewComponent")]
    public class CalendarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("_CalendarViewComponent");
        }
    }
}
