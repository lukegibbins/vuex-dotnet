using Microsoft.AspNetCore.Mvc;

namespace vuex_personal.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Contacts()
    {
        // returns the generated bundle to the view
        return Json("This is temporary");
    }
  }
}
