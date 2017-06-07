using SCAHelpDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SCAHelpDesk.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Email(Ticket ticket)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var message = new MailMessage();
                    message.To.Add(new MailAddress("noorcustomer2@gmail.com"));
                    message.From = new MailAddress("noor.chervu@gmail.com");
                    message.Subject = "Test Email";
                    message.Body = $"<p>Email From: {ticket.Name} ({ticket.Email})</p><p>Message:</p><p>{ticket.IssueDescription}</p>";
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient())
                    {
                        var credential = new NetworkCredential
                        {
                            UserName = "",
                            Password = ""
                        };

                        smtp.Credentials = credential;
                        smtp.Host = "smtp-mail.outlook.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        await smtp.SendMailAsync(message);
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }

            return View();
        }      
    }
}
