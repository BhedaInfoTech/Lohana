using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using LohanaHelper.Logging;

namespace LohanaHelper.Utilities
{
    public class Communication
    {
        public static string SendEmail(MailAddress To, string Subject, string Body, bool IsBodyHtml, List<Attachment> Attachments)
        {
            try
            {
                //LookupSystemConfigurationRepo lookupRepo = new LookupSystemConfigurationRepo();
                SmtpClient smtp = new SmtpClient();

                string fromMail = (ConfigurationManager.AppSettings["SMTP_Username"]);//(ConfigurationManager.AppSettings["SenderEmail"]);
                string fromUserName = (ConfigurationManager.AppSettings["SMTP_Username"]);//(ConfigurationManager.AppSettings["SenderName"]);
                MailAddress From = new MailAddress(fromMail, fromUserName);
                MailMessage mm = new MailMessage(From, To);

                smtp.Host = (ConfigurationManager.AppSettings["SMTP_Host"]);//lookupRepo.GetDefaultConfigValue(LookupSystemConfigurationEnum.SmtpHost.ToString());
                smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SMTP_Port"]);//Convert.ToInt32(lookupRepo.GetDefaultConfigValue(LookupSystemConfigurationEnum.SmtpPort.ToString()));
                smtp.Credentials = new System.Net.NetworkCredential(fromMail, (ConfigurationManager.AppSettings["SMTP_Password"]));//new System.Net.NetworkCredential(lookupRepo.GetDefaultConfigValue(LookupSystemConfigurationEnum.SmtpLoginUserName.ToString()), lookupRepo.GetDefaultConfigValue(LookupSystemConfigurationEnum.SmtpLoginPassword.ToString()));
                smtp.EnableSsl = Convert.ToBoolean(Convert.ToInt32(ConfigurationManager.AppSettings["SMTP_Ssl"]));//Convert.ToBoolean(lookupRepo.GetDefaultConfigValue(LookupSystemConfigurationEnum.SmtpEnableSsl.ToString()));

                mm.Subject = Subject;
                mm.Body = Body;
                mm.IsBodyHtml = IsBodyHtml;

                if (Attachments != null && Attachments.Any())
                {
                    foreach (var Attachment in Attachments)
                    {
                        mm.Attachments.Add(Attachment);
                    }
                }

                smtp.Send(mm);
                return string.Empty;
            }
            catch (Exception ex)
            {
                Logger.Error("Communication Sending Email " + ex);
                return ex.Message;
            }
        }
    }
}
