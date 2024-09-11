using DotNet_Backend.Models;
using DotNet_Backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmail _emailService;

        public EmailController(IEmail emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("onSignUp")]
        public IActionResult SignupEmail([FromBody] EmailDetails details)
        {
            try
            {
                var result = _emailService.SignupMail(details);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (use a logging framework or mechanism)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("mailInvoice")]
        public IActionResult InvoiceEmail([FromBody] EmailDetails details)
        {
            try
            {
                var result = _emailService.InvoiceEmail(details);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (use a logging framework or mechanism)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}



/*using DotNet_Backend.Models;
using DotNet_Backend.Service;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace DotNet_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private IEmail _emailService;
        public EmailController(IEmail emailService)
        {
            _emailService = emailService;
        }

        
        [HttpPost("onSignUp")]
        public string signupEmail(EmailDetails details)
        {
            return _emailService.SignupMail(details);
        }

       
        [HttpPost("mailInvoice")]
        public string invoiceEmail(EmailDetails details)
        {
            return _emailService.InvoiceEmail(details);
        }
    }
}

*/