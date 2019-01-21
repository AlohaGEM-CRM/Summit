using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SummitShopApp.BL;
using System.Xml;
using System.IO;
using SummitShopApp.Utility;

namespace SummitShopApp
{
    public partial class AddMessage : System.Web.UI.Page
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
                    else if (Request.Form["User_ID"] != null)
                        strPhoneId1 = Request.Form["User_ID"];
                    if (!Int32.TryParse(Security.DecodeNumbers(Request.QueryString["ShopID"]), out iShopID))
                        return;
                }
                else
                {
                    if (Request.QueryString["User_ID"] != null)
                        strPhoneId = Request.QueryString["User_ID"];
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
                if (objUser != null)
                {
                    //if user of that phone user id is found fill message info
                    String strUserName = String.Empty;

                    if (string.IsNullOrEmpty(objUser.strUserName))
                    {
                        if (Request.QueryString["Phone_Owner_Name"] != null)
                            objUser.strUserName = Request.QueryString["Phone_Owner_Name"];
                        else if (Request.Form["Phone_Owner_Name"] != null && !string.IsNullOrEmpty(Request.Form["Phone_Owner_Name"].ToString()))
                            objUser.strUserName = Request.Form["Phone_Owner_Name"];
                    }

                    //if (!String.IsNullOrEmpty(strUserName) && objUser.strFirstName != strUserName)
                    //{
                    //if user's first name is changed replace it 
                    //objUser.strFirstName = strUserName;
                    objUser.Save();
                    //}

                    UserPreferredShopBL objUserPreferredShop = UserPreferredShopBL.getShopByUserId(objUser.ID);



                    if (objUserPreferredShop != null || iShopID > 0)
                    {
                        String strMSG = String.Empty;
                        //save the message against his preferred body shop
                        MessageBL objMessage = new MessageBL();
                        objMessage.iPhoneUserID = objUser.ID;
                        if (objUserPreferredShop != null)
                            objMessage.iShopID = objUserPreferredShop.iShopId;
                        else
                            objMessage.iShopID = iShopID;
                        objMessage.dtMessageTime = DateTime.Now;

                        if (Request.QueryString["Message"] != null)
                        {
                            objMessage.strMessage = Request.QueryString["Message"].ToString();
                        }
                        else if (Request.Form["Message"] != null)
                        {
                            objMessage.strMessage = Request.Form["Message"].ToString();
                        }

                        String strType = String.Empty;
                        if (Request.QueryString["MessageType"] != null)
                            strType = Request.QueryString["MessageType"].ToString();
                        else if (Request.Form["MessageType"] != null)
                            strType = Request.Form["MessageType"].ToString();

                        //Check isSendSMS flag to send SMS via Web Application
                        Boolean bIsSendSMS = false;
                        String strBodyShopPhone = String.Empty;
                        if (Request.QueryString["sendSMS"] != null && Request.QueryString["sendSMS"].ToString() == "1")
                            bIsSendSMS = true;

                        BodyShopBL objBodyShop = null;
                        if (objUserPreferredShop!=null && objUserPreferredShop.iShopId.HasValue)
                            objBodyShop = BodyShopBL.getShopById(objUserPreferredShop.iShopId.Value);
                        else if (iShopID > 0)
                            objBodyShop = BodyShopBL.getShopById(iShopID);
                        if (objBodyShop != null && objBodyShop.strPhone != null)
                        {
                            strBodyShopPhone = objBodyShop.strPhone;
                        }

                        if (!String.IsNullOrEmpty(strType))
                        {
                            switch (strType.ToLower())
                            {
                                //select the message type eg. SMS, Email, Predefined SMS
                                case "sms":
                                    objMessage.iType = Constants.SMS;
                                    if (bIsSendSMS)
                                    {
                                        if (!String.IsNullOrEmpty(strBodyShopPhone))
                                        {
                                            SMS objSMS = new SMS();
                                            objSMS.SendSMS(strBodyShopPhone, objMessage.strMessage, objUser.strPhone, objUser.ID);
                                        }
                                    }
                                    break;
                                case "email":
                                    objMessage.iType = Constants.Email;
                                    break;
                                case "predefinedsms":
                                    objMessage.iType = Constants.PredefinedSMS;
                                    break;
                            }
                        }

                        //save the message n if saved return true to phone n remove cache
                        if (objMessage.Save())
                        {
                            bResult = true;
                            if (objMessage.iType == Constants.PredefinedSMS)
                            {
                                if (Cache["OpportunityList"] != null)
                                {
                                    Cache.Remove("OpportunityList");
                                }
                            }
                            else if (objMessage.iType == Constants.SMS || objMessage.iType == Constants.Email)
                            {
                                if (Cache["CommunicationList"] != null)
                                {
                                    Cache.Remove("CommunicationList");
                                }
                            }
                        }
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
            xmlWriter.WriteStartElement("MessageReport");
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
