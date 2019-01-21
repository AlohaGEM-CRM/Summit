using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using SummitShopApp.BL;
using SummitShopApp.Utility;
using System.Drawing;
using System.Text;
using EmailService;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Configuration;
using System.Net.Mail;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;

namespace SummitShopApp
{
    public partial class ScheduleRepairAppointment : System.Web.UI.Page
    {
        Int32 iShopID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Boolean bResult = false;
            try
            {
                //String strPhoneId = String.Empty;

                ////get the phone user id
                //if (Request.QueryString["User_ID"] != null)
                //    strPhoneId = Request.QueryString["User_ID"];
                //else if (Request.Headers["User_ID"] != null)
                //    strPhoneId = Request.Headers["User_ID"];
                //else if (Request.Form["User_ID"] != null)
                //    strPhoneId = Request.Form["User_ID"];
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
                    string[] strPhones = strPhoneId.Split('_');

                    //find user using phoneID for private label
                    if (strPhones.Length == 3)
                        objUser = UserBL.getDataByPhoneId(strPhoneId);
                    else
                        objUser = UserBL.GetDataByPhoneNumber(strPhones[0]);
                    if (objUser != null)
                    {
                        MyCustomerBL objMyCustomer = MyCustomerBL.getDataByUserId(objUser.ID);
                        if (objMyCustomer != null)
                            iShopID = objMyCustomer.iShopId;
                    }
                }
                else
                {
                    MyCustomerBL objMyCustomer = MyCustomerBL.getDataByShopIdNPhone(iShopID, strPhoneId1);
                    if (objMyCustomer != null)
                        objUser = UserBL.getByActivityId(objMyCustomer.iUserId.Value);
                }
                if (objUser != null)
                {
                    //if user of previous phone user id is found fill his accident report information
                    String strUserName = String.Empty;

                    if (String.IsNullOrEmpty(objUser.strUserName))
                    {

                        if (Request.QueryString["Phone_Owner_Name"] != null)
                            strUserName = Request.QueryString["Phone_Owner_Name"];
                        else if (Request.Headers["Phone_Owner_Name"] != null)
                            strUserName = Request.Headers["Phone_Owner_Name"];
                        else if (Request.Form["Phone_Owner_Name"] != null)
                            strUserName = Request.Form["Phone_Owner_Name"];

                    }

                    if (!String.IsNullOrEmpty(strUserName) && objUser.strFirstName != strUserName)
                    {
                        //if user's first name is changed
                        objUser.strFirstName = strUserName;
                        objUser.Save();
                    }
                    UserPreferredShopBL objUserPreferredShop = UserPreferredShopBL.getShopByUserId(objUser.ID);


                    MessageBL objMessage = null;
                    if (objUserPreferredShop != null || iShopID > 0)
                    {
                        String strMessage = "Requested Appointment on: ";
                        if (Request.QueryString["datetime"] != null)
                            strMessage = strMessage + String.Format("{0:g}", Convert.ToDateTime(Request.QueryString["datetime"].ToString()));
                        else if (Request.Headers["datetime"] != null)
                            strMessage = strMessage + String.Format("{0:g}", Convert.ToDateTime(Request.Headers["datetime"].ToString()));
                        else if (Request.Form["datetime"] != null)
                        {
                            DateTime dtAppointmentDate;
                            DateTime.TryParse((Request.Form["datetime"].ToString()), out dtAppointmentDate);
                            strMessage = strMessage + String.Format("{0:g}", dtAppointmentDate.ToString());
                        }



                        if (Request.QueryString["reason"] != null)
                            strMessage = strMessage + " For: " + Request.QueryString["reason"].ToString();
                        else if (Request.Headers["reason"] != null)
                            strMessage = strMessage + " For: " + Request.Headers["reason"].ToString();
                        else if (Request.Form["reason"] != null)
                            strMessage = strMessage + " For: " + Request.Form["reason"].ToString();
                        //add one message against his preferred shop
                        objMessage = new MessageBL();
                        objMessage.strMessage = strMessage;
                        objMessage.iPhoneUserID = objUser.ID;
                        if (objUserPreferredShop != null)
                            objMessage.iShopID = objUserPreferredShop.iShopId;
                        else
                            objMessage.iShopID = iShopID;
                        objMessage.dtMessageTime = DateTime.Now;
                        objMessage.iType = Constants.REQUEST_APPOINTMENT;
                        if (objMessage.Save())
                            bResult = true;
                    }
                    else if (iShopID > 0)
                    {
                        String strMessage = "Requested Appointment on: ";
                        if (Request.QueryString["datetime"] != null)
                            strMessage = strMessage + String.Format("{0:g}", Convert.ToDateTime(Request.QueryString["datetime"].ToString()));
                        else if (Request.Headers["datetime"] != null)
                            strMessage = strMessage + String.Format("{0:g}", Convert.ToDateTime(Request.Headers["datetime"].ToString()));
                        else if (Request.Form["datetime"] != null)
                        {
                            DateTime dtAppointmentDate;
                            DateTime.TryParse((Request.Form["datetime"].ToString()), out dtAppointmentDate);
                            strMessage = strMessage + String.Format("{0:g}", dtAppointmentDate.ToString());
                        }



                        if (Request.QueryString["reason"] != null)
                            strMessage = strMessage + " For: " + Request.QueryString["reason"].ToString();
                        else if (Request.Headers["reason"] != null)
                            strMessage = strMessage + " For: " + Request.Headers["reason"].ToString();
                        else if (Request.Form["reason"] != null)
                            strMessage = strMessage + " For: " + Request.Form["reason"].ToString();
                        //add one message against his preferred shop
                        objMessage = new MessageBL();
                        objMessage.strMessage = strMessage;
                        objMessage.iPhoneUserID = objUser.ID;
                        objMessage.iShopID = iShopID;
                        objMessage.dtMessageTime = DateTime.Now;
                        objMessage.iType = Constants.REQUEST_APPOINTMENT;
                        if (objMessage.Save())
                            bResult = true;
                    }
                }
            }
            catch (Exception ex)
            {
                bResult = false;
            }

            XmlDocument xmlDoc = new XmlDocument();
            MemoryStream stream = new MemoryStream();
            //XmlTextWriter xmlWriter = new XmlTextWriter(stream, System.Text.Encoding.ASCII);
            XmlTextWriter xmlWriter = new XmlTextWriter(stream, System.Text.Encoding.UTF8);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("ScheduleRepairAppointment");
            xmlWriter.WriteElementString("Status", bResult ? "Success" : "Fail");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();
            byte[] byteArray = stream.ToArray();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "filename=MyExportedFile.xml");
            HttpContext.Current.Response.AppendHeader("Content-Length", byteArray.Length.ToString());
            HttpContext.Current.Response.ContentType = "text/xml";
            HttpContext.Current.Response.BinaryWrite(byteArray);
        }
    }
}
