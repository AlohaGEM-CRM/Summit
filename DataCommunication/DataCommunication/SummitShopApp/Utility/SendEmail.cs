using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Xml;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using SummitShopApp.Utility;

namespace EmailService
{
    public class SendEmail
    {
        public static Boolean SendMail(String strTo, String strMessage)
        {

            try
            {
                SmtpClient objClient = new SmtpClient();
                Email objEmail = new Email();
                //objEmail.To = strTo;
                objEmail.Bcc = strTo;
                objEmail.From = "prashantn@alohatechnology.com";
                objEmail.Subject = "Subject Line";
                String strEmailBody = strMessage;
                objEmail.Body = strEmailBody;
                if (objEmail.SendEmail(objClient))
                {
                    //Configuration.WriteToLog("Email Send successfully");
                    return true;
                }
                else
                {
                    //Configuration.WriteToLog("Email was not sent ");
                    return false;
                }
            }
            catch (System.Net.Mail.SmtpFailedRecipientsException smtpFailedRecipientsException)
            {
                //Configuration.WriteToLog(smtpFailedRecipientsException.Message);
                return false;
            }
            catch (System.Net.Mail.SmtpException smtpException)
            {
                //Configuration.WriteToLog(smtpException.Message);
                return false;
            }
            catch (Exception exception)
            {
                //Configuration.WriteToLog(exception.Message);
                return false;
            }


        }

        public static Boolean SendMail(String strTo, String strFrom, String strMessage, String strUserName, String strUserPassword, String strSmtpServerName, String strSubject)
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = strSmtpServerName;
                if (strSmtpServerName.Contains("gmail"))
                {
                    smtp.Port = 465;
                }
                else
                {
                    smtp.Port = 25;
                }
                smtp.Credentials = new System.Net.NetworkCredential(strUserName, strUserPassword);
                smtp.EnableSsl = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                Email objEmail = new Email();
                objEmail.To = strTo;
                if (String.IsNullOrEmpty(strFrom))
                {
                    objEmail.From = "donotreply@mymitchell.com";
                }
                else
                {
                    objEmail.From = strFrom;
                }
                objEmail.Subject = strSubject;
                String strEmailBody = strMessage;
                objEmail.Body = strEmailBody;
                if (objEmail.SendEmail(smtp))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Net.Mail.SmtpFailedRecipientsException smtpFailedRecipientsException)
            {
                return false;
            }
            catch (System.Net.Mail.SmtpException smtpException)
            {
                return false;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public static Boolean SendMail(String strTo, String strFrom, String strMessage, String strUserName, String strUserPassword, String strSmtpServerName, String strSubject, List<MailResource> lstMailResource, List<Attachment> lstAttachment)
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = strSmtpServerName;
                if (strSmtpServerName.Contains("gmail"))
                {
                    smtp.Port = 465;
                }
                else
                {
                    smtp.Port = 25;
                }
                smtp.Credentials = new System.Net.NetworkCredential(strUserName, strUserPassword);
                smtp.EnableSsl = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                Email objEmail = new Email();
                objEmail.To = strTo;
                if (String.IsNullOrEmpty(strFrom))
                {
                    objEmail.From = "donotreply@mymitchell.com";
                }
                else
                {
                    objEmail.From = strFrom;
                }
                objEmail.Subject = strSubject;
                String strEmailBody = strMessage;
                objEmail.Body = strEmailBody;
                if (lstMailResource != null && lstMailResource.Count > 0)
                {
                    foreach (MailResource objMailResource in lstMailResource)
                    {
                        objEmail.AddResource(objMailResource.strResourceType, objMailResource.strResourcePath, objMailResource.strContentId);
                    }
                }
                if (lstAttachment != null && lstAttachment.Count > 0)
                {
                    foreach (Attachment objAttachement in lstAttachment)
                    {
                        objEmail.Attachments.Add(objAttachement);
                    }
                }
                if (objEmail.SendEmail(smtp))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Net.Mail.SmtpFailedRecipientsException smtpFailedRecipientsException)
            {
                return false;
            }
            catch (System.Net.Mail.SmtpException smtpException)
            {
                return false;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }

    public class Email
    {
        #region Member Variables

        private String mstrSubject = String.Empty;
        private String mstrFrom = String.Empty;
        private String mstrTo = String.Empty;
        private String mstrCc = String.Empty;
        private String mstrBcc = String.Empty;
        private String mstrBody = String.Empty;
        List<MailResource> mlstMailResources = new List<MailResource>();
        private List<Attachment> m_lstAttachments = new List<Attachment>();

        #endregion Member Variables

        #region Properties

        public String Subject
        {
            get
            {
                return mstrSubject;
            }

            set
            {
                mstrSubject = value;
            }
        }

        public String From
        {
            get
            {
                return mstrFrom;
            }
            set
            {
                mstrFrom = value;
            }
        }

        public String To
        {
            get
            {
                return mstrTo;
            }
            set
            {
                mstrTo = value;
            }
        }

        public String Cc
        {
            get
            {
                return mstrCc;
            }
            set
            {
                mstrCc = value;
            }

        }

        public String Bcc
        {
            get
            {
                return mstrBcc;
            }
            set
            {
                mstrBcc = value;
            }

        }

        public String Body
        {
            get
            {
                return mstrBody;
            }
            set
            {
                mstrBody = value;
            }
        }

        public List<Attachment> Attachments
        {
            get { return this.m_lstAttachments; }
            set { this.m_lstAttachments = value; }
        }

        #endregion Properties

        #region Member Functions

        /// <summary>
        /// Sends Mail
        /// </summary>
        /// <returns>bool</returns>
        public Boolean SendEmail(SmtpClient smtpClient)
        {
            System.Net.Mail.MailMessage meridianMail = new MailMessage();

            #region Extract email addresses

            #region Extract To Adresses

            char[] chrSplit = { ',' };
            this.To = this.To.Replace(';', ',');
            string[] strToaddresses = this.To.Split(chrSplit, StringSplitOptions.RemoveEmptyEntries);

            #endregion Extract To Adresses

            #region Extract CC Adresses

            this.Cc = this.Cc.Replace(';', ',');
            string[] strCcaddresses = this.Cc.Split(chrSplit, StringSplitOptions.RemoveEmptyEntries);

            #endregion Extract CC Adresses

            #region Extract Bcc Addresses

            this.Bcc = this.Bcc.Replace(';', ',');
            string[] strBccAddresses = this.Bcc.Split(chrSplit, StringSplitOptions.RemoveEmptyEntries);

            #endregion Extract Bcc Addresses

            #endregion Extract email addresses

            #region Set Mail Properties

            for (int intCount = 0; intCount < strToaddresses.Length; intCount++)
                meridianMail.To.Add(strToaddresses[intCount].Trim());

            for (int intCount = 0; intCount < strCcaddresses.Length; intCount++)
                meridianMail.CC.Add(strCcaddresses[intCount].Trim());

            for (int intCount = 0; intCount < strBccAddresses.Length; intCount++)
                meridianMail.Bcc.Add(strBccAddresses[intCount].Trim());

            meridianMail.From = new MailAddress(Convert.ToString(this.From));
            meridianMail.Subject = Convert.ToString(this.Subject);
            meridianMail.Body = Convert.ToString(this.Body);
            meridianMail.IsBodyHtml = true;
            meridianMail.Priority = MailPriority.Normal;

            AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(Convert.ToString(this.Body), null, "text/html");

            if (Attachments != null && Attachments.Count > 0)
            {
                foreach (Attachment thisAttachment in Attachments)
                {
                    meridianMail.Attachments.Add(thisAttachment);
                }
            }

            if (mlstMailResources != null && mlstMailResources.Count > 0)
            {
                foreach (MailResource objMailResource in mlstMailResources)
                {
                    try
                    {
                        LinkedResource objResourceEs = new LinkedResource(objMailResource.strResourcePath, objMailResource.strResourceType);
                        objResourceEs.ContentId = objMailResource.strContentId;
                        objResourceEs.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                        htmlView.LinkedResources.Add(objResourceEs);
                    }
                    catch (Exception ex)
                    {
                        ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
                    }
                }
                meridianMail.AlternateViews.Add(htmlView);
            }
            #endregion Set Mail Properties

            #region Send Mail

            try
            {
                smtpClient.Send(meridianMail);
                return true;
            }
            catch (Exception exp)
            {
                //Configuration.WriteToLog("Email Sned successfully and \r\n\r\n\r\n"+exp.Message);
                return false;
            }

            #endregion Send Mail

        }

        public virtual void AddResource(String strResourceType, String strResourcePath, String strContentId)
        {
            if (mlstMailResources == null)
                mlstMailResources = new List<MailResource>();
            mlstMailResources.Add(new MailResource(strResourceType, strResourcePath, strContentId));
        }

        #endregion Member Functions
    }

    internal class Configuration
    {
        #region Private Members

        private static string logFileName;

        #endregion

        //Logs the execution of program
        internal static void SetLogFileName()
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            string time = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

            logFileName = "log_" + month + day + year + "_" + time + ".txt";

        }

        internal static void WriteToLog(string message)
        {
            string msgFormat = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ------->  ";
            msgFormat = msgFormat + message;

            StreamWriter sw = new StreamWriter(logFileName, true);
            sw.WriteLine(msgFormat);
            sw.Flush();
            sw.Close();
        }

        internal static string GetConnectionString()
        {
            try
            {
                string server = "", database = "", usrName = "", password = "";
                XmlDocument xmlDoc = new XmlDocument();

                //Configuration.WriteToLog("Loading Config.xml... ");

                xmlDoc.Load("Config.xml");

                //Configuration.WriteToLog("Config.xml has loaded successfully");

                //Configuration.WriteToLog("Reading Config.xml to build connection string");

                XmlNodeList dbList = xmlDoc.GetElementsByTagName("UsageDB");
                if (dbList.Count == 1)
                {
                    foreach (XmlNode node in dbList)
                    {
                        XmlElement dbElement = (XmlElement)node;
                        server = dbElement.GetElementsByTagName("Server")[0].InnerText;
                        database = dbElement.GetElementsByTagName("Database")[0].InnerText;
                        usrName = dbElement.GetElementsByTagName("User")[0].InnerText;
                        password = dbElement.GetElementsByTagName("Password")[0].InnerText;
                    }
                }
                else
                {
                    //Configuration.WriteToLog("Config.xml has not well formatted");
                }

                if (server != "" && database != "")
                {
                    //Configuration.WriteToLog("Succesfully builded the connectionstring from Config.xml");
                    return "Data Source= " + server + ";Initial Catalog=" + database + ";User ID=" + usrName + ";Password=" + password + ";";

                }
                else
                {
                    //Configuration.WriteToLog("Config.xml doesnot valid connection information ");
                }

            }
            catch (Exception ex)
            {
                //Configuration.WriteToLog(ex.Message);
                //throw new Exception(ex.Message);
            }
            return "";
        }

        internal static string GetFileSystemPathFromXML()
        {
            string fileSystemPath = "";
            try
            {

                XmlDocument doc = new XmlDocument();
                doc.Load("Config.xml");
                XmlNodeList path = doc.GetElementsByTagName("SharedLogFilesPath");
                foreach (XmlNode node in path)
                {
                    XmlElement dwebElement = (XmlElement)node;
                    fileSystemPath = dwebElement.GetElementsByTagName("LogFilesPath")[0].InnerText;
                }
                return fileSystemPath;
            }
            catch (Exception ex)
            {
                //Configuration.WriteToLog(ex.Message);
            }
            return fileSystemPath;
        }
    }

    public class MailResource
    {
        #region Private members
        String m_strResourceType;
        String m_strResourcePath;
        String m_strContentId;
        #endregion

        #region Constructor
        public MailResource(String _strResourceType, String _strResourcePath, String _strContentId)
        {
            m_strResourceType = _strResourceType;
            m_strResourcePath = _strResourcePath;
            m_strContentId = _strContentId;
        }
        #endregion

        #region Properties
        public String strResourceType
        {
            get { return m_strResourceType; }
            set { m_strResourceType = value; }
        }
        public String strResourcePath
        {
            get { return m_strResourcePath; }
            set { m_strResourcePath = value; }
        }
        public String strContentId
        {
            get { return m_strContentId; }
            set { m_strContentId = value; }
        }
        #endregion
    }


}
