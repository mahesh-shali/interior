using Microsoft.AspNetCore.Mvc;

namespace website.Controllers;

public class UploadController : Controller
{
    private readonly CloudinaryService _cloudinary;

    public UploadController(CloudinaryService cloudinary)
    {
        _cloudinary = cloudinary;
    }

    [HttpGet]
    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            TempData["Error"] = "File not selected";
            return RedirectToAction("Index", "Media");
        }

        try
        {
            var url = await _cloudinary.UploadAsync(file);

            TempData["Url"] = url;
            TempData["Success"] = "File uploaded successfully";
        }
        catch
        {
            TempData["Error"] = "Upload failed";
        }

        return RedirectToAction("Index", "Media");
    }
}