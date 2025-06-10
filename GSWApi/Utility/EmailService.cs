using System.Net.Mail;
using System.Net;

namespace GSWApi.Utility
{
    public class EmailService
    {
        private readonly string _fromEmail = "phong260702@gmail.com"; // Thay bằng email thật
        private readonly string _password = "hask ynuj eaxv koja";     // App password nếu dùng Gmail

        public async Task SendOtpEmail(string toEmail, string otp)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(_fromEmail, _password),
                EnableSsl = true,
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_fromEmail),
                Subject = "Your OTP Code",
                Body = $"Your OTP code is: {otp}",
                IsBodyHtml = false,
            };
            mailMessage.To.Add(toEmail);
            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
