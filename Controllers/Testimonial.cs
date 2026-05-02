using Microsoft.AspNetCore.Mvc;

namespace website.Controllers;

public class TestimonialController : Controller
{
    public IActionResult Index()
    {
        var testimonials = new List<Testimonial>
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
        };

        return View(testimonials);
    }
}