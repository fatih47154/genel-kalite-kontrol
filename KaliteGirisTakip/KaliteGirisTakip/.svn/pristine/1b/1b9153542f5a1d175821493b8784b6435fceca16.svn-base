using System.Configuration.Internal;
using System.Data.Odbc;
using System.Text;

namespace MailSending
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Net;
    using System.Net.Mail;

    public class MailSend
    {
        MailEntity MailEntitiy { get; set; }

        public MailSend(MailEntity mailEntity)
        {
            MailEntitiy = mailEntity;
        }

        public bool MailGonder()
        {
            SmtpClient client = new SmtpClient();
            MailMessage message = new MailMessage();

            //Epostanın kimlere-kime gideceği listesi
            foreach (string adres in MailEntitiy.AdresList)
            {            
                message.To.Add(adres);
            }


            // Eposta ya iliştirelecek eklenti listesi
            if(MailEntitiy.AttachmentList != null)
            foreach (string eklenti in MailEntitiy.AttachmentList)
            {
                message.Attachments.Add(new Attachment(eklenti));
            }

            message.Subject = MailEntitiy.Subject;
            message.Body = MailEntitiy.Body;
            message.IsBodyHtml =MailEntitiy.IsBodyHtml;
            message.From= new MailAddress(MailEntitiy.HostMailAdres,MailEntitiy.NameAppear);
            message.BodyEncoding=Encoding.UTF8;
            message.DeliveryNotificationOptions=DeliveryNotificationOptions.OnFailure;
            


            NetworkCredential credential = new NetworkCredential {
                UserName =MailEntitiy.UserName,
                Password = MailEntitiy.Password             
            };
            client.Credentials = credential;
            client.Port = MailEntitiy.Port;
            client.Host = MailEntitiy.Host;
            client.EnableSsl = MailEntitiy.EnableSSl;
          
            try
            {
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                //Log4NetLibrary.HataDataBaseLog.LogStart.Error(Log4NetLibrary.GetMethodProperties.GetMethodFullName(), ex);
                return false;
            }        
        }
    }
}

