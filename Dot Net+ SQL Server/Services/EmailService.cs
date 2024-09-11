using DotNet_Backend.Models;
using DotNetProject.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace DotNet_Backend.Service
{
    public class EmailService : IEmail
    {
        private readonly IConfiguration _config;
        private readonly IUser _userService;

        public EmailService(IConfiguration config, IUser userService)
        {
            _config = config;
            _userService = userService;
        }

        public async Task<string> SignupMail(EmailDetails details)
        {
            string eml = details.sendTo;
            var user = await _userService.GetUserByEmailId(eml);

            if (user == null)
            {
                return "User not found";
            }

            var id = user.Userid;
            var pass = user.Password;

            const string SUBJECT = "SignUp Successful :)";
            string BODY = $"Dear Valued User,\n\n" +
              $"Congratulations on successfully logging into our system. We are pleased to welcome you and look forward to serving you.\n\n" +
              $"Below are your credentials:\n\n" +
              $"ID: {id}\n" +
              $"Password: {pass}\n\n" +
              $"Should you have any questions or require assistance, please do not hesitate to contact us.\n\n" +
              $"Best regards,\n" +
              $"Team-Group 4";

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config["EmailFrom"]));
            email.To.Add(MailboxAddress.Parse(details.sendTo));
            email.Subject = SUBJECT;
            email.Body = new TextPart(TextFormat.Text) { Text = BODY };

            using var smtp = new SmtpClient();
            try
            {
                await smtp.ConnectAsync(_config["EmailHost"], int.Parse(_config["EmailPort"]), SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_config["EmailFrom"], _config["EmailPassword"]);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
                return "Signup mail sent successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                return "Email Unsuccessful";
            }
        }

        public string InvoiceEmail(EmailDetails details)
        {
            const string SUBJECT2 = "Your Purchase Was Successful!";

            const string BODY2 = $"Dear Valued Customer,\n\n" +
                                  $"Congratulations on your recent purchase! We are pleased to inform you that your order has been successfully processed. Attached to this email is a PDF invoice for your reference.\n\n" +
                                  $"Thank you for choosing us for your purchase. If you have any questions or need further assistance, please feel free to reach out.\n\n" +
                                  $"Best regards,\n" +
                                  $"Team-Group 4";

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config["EmailFrom"]));
            email.To.Add(MailboxAddress.Parse(details.sendTo));
            email.Subject = SUBJECT2;

            var bodyBuilder = new BodyBuilder { TextBody = BODY2 };

            try
            {
                string invoicePath = details.path;
                Console.WriteLine("============================================================"+invoicePath);
                using (var stream = File.OpenRead(invoicePath))
                {

                    bodyBuilder.Attachments.Add("Invoice.pdf", stream, ContentType.Parse("application/pdf"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error attaching PDF: {ex.Message}");
                return "Error attaching PDF";
            }

            email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new SmtpClient();
            try
            {
                smtp.Connect(_config["EmailHost"], int.Parse(_config["EmailPort"]), SecureSocketOptions.StartTls);
                smtp.Authenticate(_config["EmailFrom"], _config["EmailPassword"]);
                smtp.Send(email);
                smtp.Disconnect(true);
                return "Invoice mail sent successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                return "Email Unsuccessful";
            }
        }


    }
}



/*

using DotNet_Backend.Models;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using DotNetProject.Services;
using DotNetProject.Models;

namespace DotNet_Backend.Service
{
    public class EmailService : IEmail
    {
        private readonly IConfiguration _config;
        private readonly IUser _userService;

        public EmailService(IConfiguration config, IUser userService)
        {
            _config = config;
            _userService = userService;
        }

        public string SignupMail(EmailDetails details)
        {
            string eml = details.sendTo;
           var user = _userService.GetUserByEmailId(eml);
            var id = user.Id;
            var pass = user.Password;
           


            const string SUBJECT = "SignUp Successful :)";
            const string BODY = "Dear Valued User,\n\tCongratulations! You have successfully logged into the system. We are thrilled to have you with us and look forward to serving you.\n\nIf you have any questions or need assistance, please don't hesitate to reach out.\n\nBest regards,\nTeam-Group 4\nID:  \nPassword:";
            
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config["EmailFrom"]));
            email.To.Add(MailboxAddress.Parse(details.sendTo));
            email.Subject = SUBJECT;
            email.Body = new TextPart(TextFormat.Text) { Text = BODY };

            using var smtp = new SmtpClient();
            try
            {
                smtp.Connect(_config["EmailHost"], int.Parse(_config["EmailPort"]), SecureSocketOptions.StartTls);
                smtp.Authenticate(_config["EmailFrom"], _config["EmailPassword"]);
                smtp.Send(email);
                smtp.Disconnect(true);
                return "Signup mail sent successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                return "Email Unsuccessful";
            }
        }

        public string InvoiceEmail(EmailDetails details)
        {
            const string SUBJECT2 = "Your Purchase Was Successful!";
            const string BODY2 = "Dear Valued Customer,\n\nCongratulations on your recent purchase! We are pleased to inform you that your order has been successfully processed. Attached to this email is a PDF invoice for your reference.\n\nThank you for choosing us for your purchase. If you have any questions or need further assistance, please feel free to reach out.\n\nBest regards,\nTeam-Group 4";

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config["EmailFrom"]));
            email.To.Add(MailboxAddress.Parse(details.sendTo));
            email.Subject = SUBJECT2;

            var bodyBuilder = new BodyBuilder { TextBody = BODY2 };

            try
            {
                using (var stream = File.OpenRead(details.path))
                {
                    bodyBuilder.Attachments.Add("Invoice.pdf", stream, ContentType.Parse("application/pdf"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error attaching PDF: {ex.Message}");
                return "Error attaching PDF";
            }

            email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new SmtpClient();
            try
            {
                smtp.Connect(_config["EmailHost"], int.Parse(_config["EmailPort"]), SecureSocketOptions.StartTls);
                smtp.Authenticate(_config["EmailFrom"], _config["EmailPassword"]);
                smtp.Send(email);
                smtp.Disconnect(true);
                return "Invoice mail sent successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                return "Email Unsuccessful";
            }
        }
    }
}


*/