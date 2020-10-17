using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailService;
using EmailService.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotificationService.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        [Route("sendemail")]
        public ActionResult SendEmail([FromBody] MessageDTO input)
        {
            try
            {
                _emailSender.SendEmail(input);
            }
            catch (Exception ex)
            {
                return new ContentResult()
                {
                    StatusCode = 400,
                    Content = ex.Message
                };
            }

            return StatusCode(200);
        }
    }
}
