using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using LohanaBusinessEntities.Common;
using LohanaHelper.Logging;
using LohanaRepo.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

//using LohanaHelper.

namespace LohanaBusinessLogic.Utilities
{
    public class CommonMethods
    {

        public static string GetUniqueKey()
        {
            int maxSize = 8;
            //int minSize = 5;
            char[] chars = new char[62];
            string a;
            a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append((b % (chars.Length)));

            }
            return result.ToString();
        }

        public static DataTable GetPaginatedTable(DataTable dt, ref PaginationInfo pager)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                pager = new PaginationInfo(dt.Rows.Count, pager.CurrentPage);

                if (dt != null && dt.Rows.Count > 0)
                {
                    int count = 0;

                    drList = dt.AsEnumerable().ToList();

                    count = drList.Count();

                    dt = dt.Select().Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).CopyToDataTable();
                }
            }

            return dt;
        }

        //public static DataTable GetTable(DataTable dt)
        //{
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        List<DataRow> drList = new List<DataRow>();

        //        //pager = new PaginationInfo(dt.Rows.Count, pager.CurrentPage);

        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            int count = 0;

        //            drList = dt.AsEnumerable().ToList();

        //            count = drList.Count();

        //            //dt = dt.Select().Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).CopyToDataTable();
        //        }
        //    }

        //    return dt;
        //}

        //public static void SendMail(string to_Email_Id, string cc_Email_Id, string subject, string body)
        //{
        //    Logger.Debug("Inside SendMail");
        //    Logger.Debug("to_Email_Id : " + to_Email_Id);
        //    Logger.Debug("cc_Email_Id : " + cc_Email_Id);
        //    Logger.Debug("subject : " + subject);
        //    Logger.Debug("body : " + body);

        //    if (ConfigurationManager.AppSettings["Is_Mail_Ready"].ToString() == "1")
        //    {
        //        MailMessage mail = new MailMessage();

        //        SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["SMTP_Host"].ToString());

        //        mail.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_Username"].ToString());

        //        Logger.Debug("Mail From : " + mail.From);

        //        if (!string.IsNullOrEmpty(to_Email_Id))
        //        {
        //            if (to_Email_Id.Contains(','))
        //            {
        //                foreach (var item in to_Email_Id.Split(','))
        //                {
        //                    mail.To.Add(item);
        //                    Logger.Debug("Mail To : " + item);

        //                }
        //            }
        //            else
        //            {
        //                mail.To.Add(to_Email_Id);
        //                Logger.Debug("Mail To : " + to_Email_Id);
        //            }
        //        }


        //        if (!string.IsNullOrEmpty(cc_Email_Id))
        //        {
        //            if (cc_Email_Id.Contains(','))
        //            {
        //                foreach (var item in cc_Email_Id.Split(','))
        //                {
        //                    mail.CC.Add(item);
        //                    Logger.Debug("Mail CC : " + item);
        //                }
        //            }
        //            else
        //            {
        //                mail.CC.Add(cc_Email_Id);
        //                Logger.Debug("Mail CC : " + cc_Email_Id);
        //            }
        //        }


        //        mail.Subject = subject;
        //        Logger.Debug("Mail Subject : " + mail.Subject);

        //        mail.Body = body;
        //        Logger.Debug("Mail Body : " + mail.Body);

        //        mail.IsBodyHtml = true;

        //        SmtpServer.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SMTP_Port"]);

        //        SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTP_Username"].ToString(), ConfigurationManager.AppSettings["SMTP_Password"].ToString());

        //        SmtpServer.EnableSsl = ConfigurationManager.AppSettings["SMTP_Ssl"].ToString() == "0" ? false : true;

        //        SmtpServer.Send(mail);
        //    }


        //}


        public static void SendMail(string to_Email_Id, string cc_Email_Id, string AttachmentPath, string subject, string body)
        {
            Logger.Debug("Inside SendMail");
            Logger.Debug("to_Email_Id : " + to_Email_Id);
            Logger.Debug("cc_Email_Id : " + cc_Email_Id);
            Logger.Debug("subject : " + subject);
            Logger.Debug("body : " + body);

            if (ConfigurationManager.AppSettings["Is_Mail_Ready"].ToString() == "1")
            {
                MailMessage mail = new MailMessage();

                SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["SMTP_Host"].ToString());

                mail.From = new MailAddress(ConfigurationManager.AppSettings["SMTP_Username"].ToString());

                Logger.Debug("Mail From : " + mail.From);

                if (!string.IsNullOrEmpty(to_Email_Id))
                {
                    if (to_Email_Id.Contains(','))
                    {
                        foreach (var item in to_Email_Id.Split(','))
                        {
                            mail.To.Add(item);
                            Logger.Debug("Mail To : " + item);

                        }
                    }
                    else
                    {
                        mail.To.Add(to_Email_Id);
                        Logger.Debug("Mail To : " + to_Email_Id);
                    }
                }


                if (!string.IsNullOrEmpty(cc_Email_Id))
                {
                    if (cc_Email_Id.Contains(','))
                    {
                        foreach (var item in cc_Email_Id.Split(','))
                        {
                            mail.CC.Add(item);
                            Logger.Debug("Mail CC : " + item);
                        }
                    }
                    else
                    {
                        mail.CC.Add(cc_Email_Id);
                        Logger.Debug("Mail CC : " + cc_Email_Id);
                    }
                }

                if (!string.IsNullOrEmpty(AttachmentPath))
                {      
                    Attachment attachment = new Attachment(AttachmentPath);
                    foreach (var str in AttachmentPath.Split('/'))
                    {                    
                       if (str.Contains(".pdf"))
                        {                       
                        attachment.Name = str;
                        mail.Attachments.Add(attachment);
                        }
                        else
                       {
                           attachment.Name = str;
                          
                       }                     
                        
                    }                   
                    //if (AttachmentPath.Contains(','))
                    //{
                    //    foreach (var str in AttachmentPath.Split(',')[2])
                    //    {
                    //        Attachment attachment = new Attachment(str.ToString());

                    //        attachment.Name = AttachmentPath;

                    //        mail.Attachments.Add(attachment);                       
                    //    }
                    //}
                    //  else
                    //   {
                    //  mail.Attachments.Add(AttachmentPath);
                    //   }
                }


                mail.Subject = subject;
                Logger.Debug("Mail Subject : " + mail.Subject);

                mail.Body = body;
                Logger.Debug("Mail Body : " + mail.Body);

                mail.IsBodyHtml = true;

                SmtpServer.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SMTP_Port"]);

                SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTP_Username"].ToString(), ConfigurationManager.AppSettings["SMTP_Password"].ToString());

                SmtpServer.EnableSsl = ConfigurationManager.AppSettings["SMTP_Ssl"].ToString() == "0" ? false : true;

                SmtpServer.Send(mail);
            }


        }


     
        public static void GeneratePDF(int obj_Id, string path, string body, string obj_Name)
        {
            if (obj_Name == "Hotel")
            {
                Byte[] bytes;
                StringReader sr = new StringReader(body.ToString());
                using (var ms = new MemoryStream())
                {
                    using (var doc = new Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 10f))
                    {
                        using (var writer = PdfWriter.GetInstance(doc, ms))
                        {
                            doc.Open();

                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, sr);

                            doc.Close();
                        }
                    }
                    bytes = ms.ToArray();
                }
                string FilePath = path + "//test1.pdf";
                System.IO.File.WriteAllBytes(FilePath, bytes);

                CommonMethods.SendMail("abc@gmail.com", "", FilePath, "Hotel Details", "");
            }


            if (obj_Name == "Package")
            {
                Byte[] bytes;
                StringReader sr = new StringReader(body.ToString());
                using (var ms = new MemoryStream())
                {
                    using (var doc = new Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 10f))
                    {
                        using (var writer = PdfWriter.GetInstance(doc, ms))
                        {
                            doc.Open();

                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, sr);

                            doc.Close();
                        }
                    }
                    bytes = ms.ToArray();
                }
                string FilePath = path + "//test1002.pdf";

                System.IO.File.WriteAllBytes(FilePath, bytes);

                CommonMethods.SendMail("abc@gmail.com", "", FilePath, "Package Details", "");
            }

        }
     
    }
}
