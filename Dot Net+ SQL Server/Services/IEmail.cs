using DotNet_Backend.Models;
using System.Threading.Tasks;

namespace DotNet_Backend.Service
{
    public interface IEmail
    {
        Task<string> SignupMail(EmailDetails details);
        string InvoiceEmail(EmailDetails details);
    }
}



/*using DotNet_Backend.Models;

namespace DotNet_Backend.Service
{
    public interface IEmail
    {
        public string SignupMail(EmailDetails details);

        public string InvoiceEmail(EmailDetails details);
    }
}*/