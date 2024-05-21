
using web_blog.WebApp.Models;

namespace web_blog.WebApp.Services
{
    public interface IEmailSender
    {
        Task SendEmail(EmailData emailData);
    }
}