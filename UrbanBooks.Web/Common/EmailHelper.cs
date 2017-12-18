using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using UrbanBooks.Entity;
using UrbanBooks.Common;
using System.Web.Mvc;
using System;

namespace UrbanBooks.Web.Common
{
    public class EmailHelper
    {
        public static string Send(EmailLogModel Model)
        {
            var FromEmail = System.Configuration.ConfigurationManager.AppSettings["FromEmail"];
            var password = System.Configuration.ConfigurationManager.AppSettings["passsword"];
            int PortNumber = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PortNumber"]);
            string HostName = System.Configuration.ConfigurationManager.AppSettings["HostName"];
            MailMessage mail = new MailMessage();
            mail.To.Add(Model.ToEmail);
            mail.From = new MailAddress(FromEmail);
            mail.Subject = Model.EmailSubject;
            mail.Body = Model.EmailBody;
            mail.IsBodyHtml = true;

            if (Model.CcEmail != "" && Model.CcEmail != null)
            {
                mail.CC.Add(Model.CcEmail);
            }

            SmtpClient smtp = new SmtpClient();
            smtp.Host = HostName;
            smtp.Port = PortNumber;

            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;

            smtp.Credentials = new System.Net.NetworkCredential(FromEmail, password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

            return "";
        }
    }
}