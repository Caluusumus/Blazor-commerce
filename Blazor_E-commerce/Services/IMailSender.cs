using MimeKit;

namespace Blazor_E_commerce.Services
{
    public interface IMailSender
    {
        MimeMessage message { get; set; }

        void SendMail();
    }
}