using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [Route("mailkit/")]
    public class MailKitController : Controller
    {
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage()
        {
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync("serikzhunu@gmail.com", "Тема письма", "Тест SMTP - Салам!");
            return RedirectToAction("Index");
        }
    }
}
