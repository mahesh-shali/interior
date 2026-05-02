using Microsoft.AspNetCore.Mvc;

namespace website.Controllers;

public class ServicesController : Controller
{
    public IActionResult Contact()
    {
        return View("~/Views/Home/Services.cshtml");
    }
}
