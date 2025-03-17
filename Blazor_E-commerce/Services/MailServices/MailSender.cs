namespace Services.MailServices;

using MailKit;
using MimeKit;
using MailKit.Net.Smtp;
using Blazor_E_commerce.Client.Pages.UserPages;

public class MailSender : IMailSender
{
    private string sendFrom { get; set; } = default!;
    private string sendTo { get; set; } = default!;
    private KeyValuePair<string, string> userInfo { get; set; }

    public MailSender(string from, string to, string user, string password)
    {
        sendFrom = from;
        sendTo = to;
        userInfo = new KeyValuePair<string, string>(user, password);
    }

    public async Task SendMail()
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("blazor e-commerce", sendFrom));
        message.To.Add(new MailboxAddress(userInfo.Key, sendTo));
        message.Subject = "Confirm your email";

        message.Body = new TextPart("html")
        {
            Text = $"Please confirm your account by <a href='\'>clicking here</a>."
        };


        using (var client = new SmtpClient())
        {
            client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);

            // Note: only needed if the SMTP server requires authentication
            client.Authenticate(sendTo, userInfo.Value);

            await client.SendAsync(message);
            client.Disconnect(true);
        }

    }
}