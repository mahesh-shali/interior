using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using website.Models;

namespace website.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var model = new HomeViewModel
        {
            Testimonials = new List<Testimonial>
            {
                new Testimonial
                {
                    Name = "Mark Alviro Wiens",
                    Message = "Accessories Here you can find the best computer accessory for your laptop.",
                    Rating = 5
                },
                new Testimonial
                {
                    Name = "Lina Harrington",
                    Message = "Hypnosis quit smoking methods maintain caused quite world over the last two decades.",
                    Rating = 4
                }
            },
            Exhibitions = new List<Exhibition>
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
                }
            }
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
