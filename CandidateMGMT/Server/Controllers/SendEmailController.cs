using CandidateMGMT.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CandidateMGMT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        [HttpPost]
        public async Task Post(Candidate candidate)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            message.From = new MailAddress("bqhai.9x@gmail.com");
            message.To.Add(new MailAddress(candidate.Email));
            message.Subject = candidate.MailTitle;
            message.Body = candidate.MailBody.Replace("\n","<br>");
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.UTF8;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("bqhai.9x@gmail.com", "bqhai1011");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }
    }
}
