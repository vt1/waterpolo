using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;

namespace ywp.CustomUtilities
{
    public class Mailer
    {
        public SmtpSection smtpSection { get; set; }

        public Mailer()
        {
            smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
        }

        public void SendMessage(string fromAdress, string fromDisplayName, string toAdress, string subject, string body)
        {            
            MailAddress from = new MailAddress(fromAdress, fromDisplayName);
            MailAddress to = new MailAddress(toAdress);
            MailMessage mail = new MailMessage(from, to)
            {
                Subject = subject,
                Body = body
            };

            SmtpClient smtp = new SmtpClient();
            smtp.Send(mail);
        }
    }
}