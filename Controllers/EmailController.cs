using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace website.Controllers;

public class EmailController : Controller
{
    [HttpPost]
    public async Task<IActionResult> Send(ContactForm model)
    {
        if (!ModelState.IsValid)
        {
            TempData["Error"] = "Please fill all required fields.";
            return RedirectToAction("Contact", "Contact");
        }

        try
        {
            var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("maheshshali20@gmail.com", "isrb ctpv apjd fxoj"),
                EnableSsl = true,
            };

            var mail = new MailMessage
            {
                From = new MailAddress("maheshshali20@gmail.com"),
                Subject = model.Subject,
                Body = $"Name: {model.Name}\nEmail: {model.Email}\nMessage: {model.Message}",
                IsBodyHtml = false,
            };

            mail.To.Add("maheshshali20@gmail.com");

            await smtp.SendMailAsync(mail);

            TempData["Success"] = "Message sent successfully!";
        }
        catch
        {
            TempData["Error"] = "Failed to send message.";
        }

        return RedirectToAction("Contact", "Contact");
    }
}