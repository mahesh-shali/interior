using Microsoft.AspNetCore.Mvc;
using website.Models;

namespace website.Controllers;

public class AuthController : Controller
{
    private const string SessionTokenKey = "AuthToken";

    [HttpGet]
    public IActionResult Login()
    {
        if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionTokenKey)))
        {
            return RedirectToAction("Index", "Media");
        }

        ViewBag.Error = TempData["Error"];
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginModel model)
    {
        if (model.Username == "admin" && model.Password == "123")
        {
            HttpContext.Session.SetString(SessionTokenKey, Guid.NewGuid().ToString("N"));
            HttpContext.Session.SetString("Username", model.Username);
            return RedirectToAction("Index", "Media");
        }

        ViewBag.Error = "Invalid credentials";
        return View();
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        TempData["Error"] = "You have been logged out.";
        return RedirectToAction(nameof(Login));
    }
}