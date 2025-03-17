namespace Blazor_E_commerce.Services;

using MailKit;
using MimeKit;
using MailKit.Net.Smtp;
using static System.Net.Mime.MediaTypeNames;

public class MailSender : IMailSender
{
    public MimeMessage message { get; set; }
    private string sendFrom { get; set; } = default!;
    private string sendTo { get; set; } = default!;
    private KeyValuePair<string, string> userInfo { get; set; }

    public MailSender(string from, string to, string user, string password)
    {
        message = new MimeMessage();
        sendFrom = from;
        sendTo = to;
        userInfo = new KeyValuePair<string, string>(user, password);
    }

    public void SendMail()
    {
        try
        {
            message.From.Add(new MailboxAddress("BlazorApplication", sendFrom));
            message.To.Add(new MailboxAddress(userInfo.Key, sendTo));
            message.Subject = "Complete your registration for Blazor_E-Commerce";

            message.Body = new TextPart("html")
            {
                Text = @"<p>Hello, we have recived a request for the creation of an account with your e-mail, click the link down below to complete your registration, otherwise ingore</p>

<a href='localhost:7197/Account/ConfirmEmail'></a>"
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(sendTo, userInfo.Value);

                client.Send(message);
                client.Disconnect(true);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

}
