using Microsoft.AspNetCore.Mvc;

namespace website.Controllers;

public class ExhibitionController : Controller
{
    public IActionResult Index()
    {
        var exhibitions = new List<Exhibition>
    {
        new Exhibition
        {
            Title = "It's Classified How To Utilize Free",
            Description = "Acres of Diamonds... you've read the famous story.",
            ImageUrl = "/images/e1.jpg",
            Date = new DateTime(2018, 1, 31),
            Tags = new List<string> { "Travel", "Life Style" }
        },
        new Exhibition
        {
            Title = "Low Cost Advertising",
            Description = "Acres of Diamonds... you've read the famous story.",
            ImageUrl = "/images/e2.jpg",
            Date = new DateTime(2018, 1, 31),
            Tags = new List<string> { "Travel", "Life Style" }
        },
        new Exhibition
        {
            Title = "Creative Outdoor Ads",
            Description = "Acres of Diamonds... you've read the famous story.",
            ImageUrl = "/images/e3.jpg",
            Date = new DateTime(2018, 1, 31),
            Tags = new List<string> { "Travel", "Life Style" }
        },
        new Exhibition
        {
            Title = "It's Classified How To Utilize Free",
            Description = "Acres of Diamonds... you've read the famous story.",
            ImageUrl = "/images/e1.jpg",
            Date = new DateTime(2018, 1, 31),
            Tags = new List<string> { "Travel", "Life Style" }
        },
        new Exhibition
        {
            Title = "Low Cost Advertising",
            Description = "Acres of Diamonds... you've read the famous story.",
            ImageUrl = "/images/e2.jpg",
            Date = new DateTime(2018, 1, 31),
            Tags = new List<string> { "Travel", "Life Style" }
        },
        new Exhibition
        {
            Title = "Creative Outdoor Ad",
            Description = "Acres of Diamonds... you've read the famous story.",
            ImageUrl = "/images/e3.jpg",
            Date = new DateTime(2018, 1, 31),
            Tags = new List<string> { "Travel", "Life Style" }
        }
    };

        return View(exhibitions);
    }
}