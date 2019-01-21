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
    public partial class HelpCounterUpdate : System.Web.UI.Page
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
                    String strUserName = String.Empty;

                    if (string.IsNullOrEmpty(objUser.strUserName))
                    {
                        if (Request.QueryString["Phone_Owner_Name"] != null)
                            objUser.strUserName = Request.QueryString["Phone_Owner_Name"];
                        else if (Request.Form["Phone_Owner_Name"] != null && !string.IsNullOrEmpty(Request.Form["Phone_Owner_Name"].ToString()))
                            objUser.strUserName = Request.Form["Phone_Owner_Name"];
                    }
                    objUser.Save();

                    UserPreferredShopBL objUserPreferredShop = UserPreferredShopBL.getShopByUserId(objUser.ID);



                    MessageBL objMessage = null;
                    if (objUserPreferredShop != null || iShopID > 0)
                    {
                        objMessage = new MessageBL();
                        objMessage.iPhoneUserID = objUser.ID;
                        if (objUserPreferredShop != null)
                            objMessage.iShopID = objUserPreferredShop.iShopId;
                        else
                            objMessage.iShopID = iShopID;
                        objMessage.dtMessageTime = DateTime.Now;

                        if (Request.QueryString["Message"] != null)
                            objMessage.strMessage = Request.QueryString["Message"].ToString();
                        else if (Request.Form["Message"] != null)
                            objMessage.strMessage = Request.Form["Message"].ToString();

                        String strType = String.Empty;
                        if (Request.QueryString["MessageType"] != null)
                            strType = Request.QueryString["MessageType"].ToString();
                        else if (Request.Form["MessageType"] != null)
                            strType = Request.Form["MessageType"].ToString();

                        String[] strPhoneNumbers = null;
                        if (Request.QueryString["smsTo"] != null)
                        {
                            strPhoneNumbers = Request.QueryString["smsTo"].ToString().Split(',');
                        }

                        if (strType.ToLower() == "predefinedsms" && Request.QueryString["Message"] != null)
                        {
                            String strMSG = Request.QueryString["Message"].ToString();
                            if (strPhoneNumbers != null)
                            {
                                SMS objSMS = new SMS();
                                foreach (String item in strPhoneNumbers)
                                {
                                    objSMS.SendSMS(item, objMessage.strMessage, objUser.strPhone, objUser.ID);
                                }
                            }
                        }

                        try
                        {
                            if (Request.QueryString["Latitude"] != null)
                                objMessage.fLatitude = Convert.ToDouble(Request.QueryString["Latitude"]);
                            else if (Request.Form["Latitude"] != null)
                                objMessage.fLatitude = Convert.ToDouble(Request.Form["Latitude"]);
                        }
                        catch (Exception ex)
                        {
                            objMessage.fLatitude = 0.0;
                        }
                        try
                        {
                            if (Request.QueryString["Longitude"] != null)
                                objMessage.fLongitude = Convert.ToDouble(Request.QueryString["Longitude"]);
                            else if (Request.Form["Longitude"] != null)
                                objMessage.fLongitude = Convert.ToDouble(Request.Form["Longitude"]);
                        }
                        catch (Exception ex)
                        {
                            objMessage.fLongitude = 0.0;
                        }
                        objMessage.iType = Constants.PredefinedSMS;

                        objMessage.Save();

                        BodyShopBL objBodyShop = null;
                        if (objUserPreferredShop!=null)
                        objBodyShop = BodyShopBL.getShopById(Convert.ToInt32(objUserPreferredShop.iShopId));
                        else
                            objBodyShop = BodyShopBL.getShopById(iShopID);

                        if (objBodyShop != null)
                        {
                            objBodyShop.iNoHelpSelection = (objBodyShop.iNoHelpSelection == null) ? 1 : (objBodyShop.iNoHelpSelection + 1);

                            if (objBodyShop.Save())
                            {
                                if (Cache["CommunicationList"] != null)
                                {
                                    Cache.Remove("CommunicationList");
                                }
                                if (Cache["OpportunityList"] != null)
                                {
                                    Cache.Remove("OpportunityList");
                                }
                                if (Cache["RepairProspect"] != null)
                                {
                                    Cache.Remove("RepairProspect");
                                }
                                if (Cache["EmailMarketing"] != null)
                                {
                                    Cache.Remove("EmailMarketing");
                                }
                                if (Cache["TextMarketing"] != null)
                                {
                                    Cache.Remove("TextMarketing");
                                }
                                bResult = true;
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
            xmlWriter.WriteStartElement("EditCountReport");
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
