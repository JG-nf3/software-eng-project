using System;
using System.Net;
using System.Net.Mail;

namespace Air_3550.Utils
{
    /// <summary>
    /// Class to help with sending email to customer
    /// </summary>
    internal class Email
    {
        /// <summary>
        /// Send email to user
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="messageSubject"></param>
        /// <param name="messageBody"></param>
        public static void SendEmail(string userEmail, string messageSubject, string messageBody)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("air3550customerservice@gmail.com");
                message.To.Add(new MailAddress(userEmail));
                message.Subject = messageSubject;
                message.IsBodyHtml = false; //to make message body as html
                message.Body = messageBody;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("air3550customerservice@gmail.com", "Hesoyam.007");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception)
            {
            }
        }
    }
}