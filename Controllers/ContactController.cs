using Microsoft.AspNetCore.Mvc;

namespace website.Controllers;

public class ContactController : Controller
{
    public IActionResult Contact()
    {
        return View("~/Views/Home/contact.cshtml");
    }

    
}
