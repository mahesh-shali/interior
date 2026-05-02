using Microsoft.AspNetCore.Mvc;

namespace website.Controllers;

public class MediaController : Controller
{
    private const string SessionTokenKey = "AuthToken";

    private readonly CloudinaryService _cloudinary;

    public MediaController(CloudinaryService cloudinary)
    {
        _cloudinary = cloudinary;
    }

    [HttpGet("/uploads")]
    public async Task<IActionResult> Index()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionTokenKey)))
        {
            TempData["Error"] = "Session expired. Please login again.";
            return RedirectToAction("Login", "Auth");
        }

        var media = await _cloudinary.GetAllMediaAsync();

        ViewBag.Url = TempData["Url"];
        ViewBag.Error = TempData["Error"];
        ViewBag.Success = TempData["Success"];

        return View("~/Views/Auth/uploads.cshtml", media);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(string publicId, string resourceType)
    {
        try
        {
            await _cloudinary.DeleteAsync(publicId, resourceType);
            TempData["Success"] = "Deleted successfully";
        }
        catch
        {
            TempData["Error"] = "Delete failed";
        }

        return RedirectToAction("Index");
    }
}