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
      ViewBag.Uri = "../ClientApp/Bundles/ContactsPage.bundle.js";
      return View("RenderVue");
    }
  }
}
