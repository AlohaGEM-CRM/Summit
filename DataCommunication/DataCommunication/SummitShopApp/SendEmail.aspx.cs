using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SummitShopApp.BL;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using SummitShopApp.Utility;

namespace SummitShopApp
{
    public partial class SendEmail : System.Web.UI.Page
    {
        Int32 iShopID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Boolean bResult = false;
            try
            {
                String strPhoneId = String.Empty;
                String strPhoneId1 = String.Empty;

                if (!String.IsNullOrEmpty(Request.QueryString["ShopID"]))
                {
                    if (Request.QueryString["User_ID"] != null)
                        strPhoneId1 = Request.QueryString["User_ID"];
                    else if (Request.Headers["User_ID"] != null)
                        strPhoneId = Request.Headers["User_ID"];
                    else if (Request.Form["User_ID"] != null)
                        strPhoneId1 = Request.Form["User_ID"];
                    if (!Int32.TryParse(Security.DecodeNumbers(Request.QueryString["ShopID"]), out iShopID)) 
                        return;
                }
                else
                {
                if (Request.QueryString["User_ID"] != null)
                    strPhoneId = Request.QueryString["User_ID"];
                    else if (Request.Headers["User_ID"] != null)
                        strPhoneId = Request.Headers["User_ID"];
                else if (Request.Form["User_ID"] != null)
                    strPhoneId = Request.Form["User_ID"];
                }
                UserBL objUser = null;
                if (!String.IsNullOrEmpty(strPhoneId))
                {
                    //if phone user id is found
                    objUser = UserBL.getDataByPhoneId(strPhoneId);
                }
                else
                {
                    MyCustomerBL objMyCustomer = MyCustomerBL.getDataByShopIdNPhone(iShopID, strPhoneId1);
                    if (objMyCustomer != null)
                        objUser = UserBL.getByActivityId(objMyCustomer.iUserId.Value);
                }
                if (!String.IsNullOrEmpty(Request.Headers["To"]))
                {

                    if (objUser != null)
                    {
                        bResult = EmailService.SendEmail.SendMail(Request.Headers["To"], objUser.strEmail, Request.Headers["Body"], ConfigurationManager.AppSettings["SmtpUserName"], ConfigurationManager.AppSettings["SmtpUserPassword"], ConfigurationManager.AppSettings["SmtpHost"], Request.Headers["Subject"]);
                    }
                }
            }
            catch (Exception ex)
            {
                bResult = false;
            }
            XmlDocument xmlDoc = new XmlDocument();
            MemoryStream stream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(stream, System.Text.Encoding.UTF8);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("SendEmail");
            xmlWriter.WriteElementString("Sent", bResult.ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();
        }
    }
}
