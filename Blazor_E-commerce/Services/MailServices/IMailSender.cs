
namespace Services.MailServices
{
    public interface IMailSender
    {
        Task SendMail();
    }
}