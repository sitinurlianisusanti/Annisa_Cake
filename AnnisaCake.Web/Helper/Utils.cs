using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace AnnisaCake.Web.Helper
{
    public class Utils
    {
        public static string KodeKonfirmasi()
        {
            Random ran = new Random();
            StringBuilder str = new StringBuilder();
            str.Append(ran.Next(0, 10));
            str.Append(ran.Next(0, 10));
            str.Append(ran.Next(0, 10));
            str.Append(ran.Next(0, 10));

            return str.ToString();

        }


        public static  void SendEmail(string to, string subject, string body)
        {

            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            string from = "NoReplayyEmail@gmail.com";
            mail.From = new MailAddress(from);
            mail.Subject = subject;
            string Body = body;
            mail.Body = Body;
            mail.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("NoReplayyEmail@gmail.com", "NoReplayyEmail1234"); // Enter seders User name and password       
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}