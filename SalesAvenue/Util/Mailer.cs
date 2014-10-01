using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;


namespace SalesAvenue.Util
{
    public class Mailer
    {
        public static void SendMail(string email, Guid tokenId)
        {
            string msgBody = "Congratulations...Your Store has been created... Please click the link below to setup your store <br>";
            msgBody += "www.SalezAvenue.com/Admin?TokenID=" + tokenId;
            var message = new System.Net.Mail.MailMessage();
            message.From = new MailAddress("savenuesales2014@gmail.com");
            message.To.Add(email);
            message.Subject = "Sales Avenue - Notification";
            message.Body = msgBody;
            message.IsBodyHtml = true;
            var client = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("avenuesales2014@gmail.com", "Webdev@123")
            };
            client.Send(message);
        }
    }
}