using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.IO;
using SummitShopApp.BL;
using SummitShopApp.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
//using SummitBL;

namespace SummitShopApp
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Boolean bResult = false;
            Int32 iUserId = 0;
            Int32 iShopID = 0;
            String ZipCode = String.Empty;
            FileInfo fileInfo = new FileInfo(Server.MapPath("~") + "\\Logger.txt");
            StreamWriter streamWriter = fileInfo.AppendText();
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
                    streamWriter.WriteLine(DateTime.Now + ":\nPhone Id Checked");
                    //if phone user id is found
                    objUser = UserBL.getDataByPhoneId(strPhoneId);
                }
                else
                {
                    streamWriter.WriteLine(DateTime.Now + ":\nPhone Id Checked");
                    MyCustomerBL objMyCustomer = MyCustomerBL.getDataByShopIdNPhone(iShopID, strPhoneId1);
                    if (objMyCustomer != null)
                        objUser = UserBL.getByActivityId(objMyCustomer.iUserId.Value);
                }




                    if (objUser != null)
                    {
                        streamWriter.WriteLine(DateTime.Now + ":\nUser Id Checked");
                        if (Request.QueryString["UserName"] != null)
                            objUser.strUserName = Request.QueryString["UserName"];

                        else if (Request.Form["UserName"] != null)
                            objUser.strUserName = Request.Form["UserName"];


                        //if (CheckAvailability(objUser.strUserName))
                        //{
                        //    return;                        
                        //}

                        if (Request.QueryString["Email"] != null)
                            objUser.strEmail = Request.QueryString["Email"];
                        else if (Request.Form["Email"] != null)
                            objUser.strEmail = Request.Form["Email"];

                        if (Request.QueryString["ZipCode"] != null)
                            objUser.strZip = Request.QueryString["ZipCode"];
                        else if (Request.Form["ZipCode"] != null)
                            objUser.strZip = Request.Form["ZipCode"];

                        //if (!string.IsNullOrEmpty(objUser.strUserName))
                        //{
                        //    if (Request.QueryString["Phone_Owner_Name"] != null)
                        //        objUser.strUserName = Request.QueryString["Phone_Owner_Name"];
                        //    else if (Request.Form["Phone_Owner_Name"] != null && !string.IsNullOrEmpty(Request.Form["Phone_Owner_Name"].ToString()))
                        //        objUser.strUserName = Request.Form["Phone_Owner_Name"];
                        //}

                        if (Request.QueryString["ShareInformation"] != null)
                            objUser.bIsRegistred_Shop = Request.QueryString["ShareInformation"].ToLower() == "yes" ? true : false;
                        else if (Request.Form["ShareInformation"] != null)
                            objUser.bIsRegistred_Shop = Request.Form["ShareInformation"].ToLower() == "yes" ? true : false;

                        objUser.bIsRegistred = true;

                        objUser.bIsShow = true;
                        objUser.bIsShowEmailMarketing = true;
                        objUser.bIsShowTextMarketing = true;
                        objUser.dtAppDownLoadDate = DateTime.Now;
                        objUser.bIsNew = false;

                        if (objUser.Save())
                        {
                            streamWriter.WriteLine(DateTime.Now + ":\nUser Saved");
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
                            iUserId = objUser.ID;
                            ZipCode = objUser.strZip;
                        }
                    }
                    else
                    {
                        objUser = new UserBL();

                        streamWriter.WriteLine(DateTime.Now + ":\nU New User Created");
                        if (Request.QueryString["UserName"] != null)
                            objUser.strUserName = Request.QueryString["UserName"];
                        else if (Request.Form["UserName"] != null)
                            objUser.strUserName = Request.Form["UserName"];

                        if (Request.QueryString["Email"] != null)
                            objUser.strEmail = Request.QueryString["Email"];
                        else if (Request.Form["Email"] != null)
                            objUser.strEmail = Request.Form["Email"];

                        if (Request.QueryString["ZipCode"] != null)
                            objUser.strZip = Request.QueryString["ZipCode"];
                        else if (Request.Form["ZipCode"] != null)
                            objUser.strZip = Request.Form["ZipCode"];

                        if (string.IsNullOrEmpty(objUser.strUserName))
                        {
                            if (Request.QueryString["Phone_Owner_Name"] != null)
                                objUser.strUserName = Request.QueryString["Phone_Owner_Name"];
                            else if (Request.Form["Phone_Owner_Name"] != null && !string.IsNullOrEmpty(Request.Form["Phone_Owner_Name"].ToString()))
                                objUser.strUserName = Request.Form["Phone_Owner_Name"];
                        }

                        if (Request.QueryString["ShareInformation"] != null)
                            objUser.bIsRegistred_Shop = Request.QueryString["ShareInformation"].ToLower() == "yes" ? true : false;
                        else if (Request.Form["ShareInformation"] != null)
                            objUser.bIsRegistred_Shop = Request.Form["ShareInformation"].ToLower() == "yes" ? true : false;

                        //if (objUser.bIsRegistred_Shop!=null &&  Convert.ToBoolean(objUser.bIsRegistred_Shop))
                        //{
                        //    objUser.dtAppDownLoadDate = DateTime.Now;
                        //}
                        objUser.dtAppDownLoadDate = DateTime.Now;
                        objUser.bIsNew = false;
                        objUser.strPhone_Id = strPhoneId;

                        objUser.bIsRegistred = true;
                        objUser.bIsShow = true;
                        objUser.bIsShowEmailMarketing = true;
                        objUser.bIsShowTextMarketing = true;


                        if (objUser.Save())
                        {
                            streamWriter.WriteLine(DateTime.Now + ":\nU New User Saved");
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
                            iUserId = objUser.ID;
                            ZipCode = objUser.strZip;
                        }
                    }


            }
            catch (Exception exp)
            {
                streamWriter.WriteLine(DateTime.Now + ":\nException:" + exp);
                bResult = false;
            }

            XmlDocument xmlDoc = new XmlDocument();
            MemoryStream stream = new MemoryStream();
            //XmlTextWriter xmlWriter = new XmlTextWriter(stream, System.Text.Encoding.ASCII);
            XmlTextWriter xmlWriter = new XmlTextWriter(stream, System.Text.Encoding.UTF8);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Registration");
            xmlWriter.WriteElementString("Authenticated", bResult.ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();
            byte[] byteArray = stream.ToArray();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "filename=MyExportedFile.xml");
            HttpContext.Current.Response.AppendHeader("Content-Length", byteArray.Length.ToString());
            HttpContext.Current.Response.ContentType = "text/xml";
            HttpContext.Current.Response.BinaryWrite(byteArray);
            HttpContext.Current.Response.Flush();
            streamWriter.WriteLine(DateTime.Now + ":\nU Content Flush");
            if (bResult)
                performPostOperation(iUserId, ZipCode);
            streamWriter.WriteLine(DateTime.Now + ":\nU Post Opreration Performed");
            streamWriter.Flush();
            streamWriter.Close();

        }

        #region Private Methods
        private bool CheckAvailability(String strUserName)
        {
            try
            {
                UserBL _objUserBL = new UserBL();
                List<UserBL> _lstUserBL = UserBL.GetUserData();
                UserBL objLogin = _lstUserBL.Find(c => c.strUserName == strUserName);
                if (objLogin != null)
                {
                    lblStatus.Text = "User Name Not Available";
                    return true;
                }
            }
            catch (Exception ex)
            { }
            return false;
        }

        private bool saveMessage(Int32 iUserId, Int32 iPrivateLabelId)
        {
            Int32 iShopId;
            Boolean bFound = false;
            Boolean bHasShop = checkUserPrefferedShop(iUserId, out iShopId);
            List<MessageBL> lstMessage = MessageBL.getDataByUserIdAndType(iUserId, Constants.REGISTRATIONMESSAGTYPE);
            if (lstMessage != null && lstMessage.Count > 0)
            {
                foreach (MessageBL objMessage in lstMessage)
                {
                    if (objMessage.iShopID == null)
                    {
                        objMessage.bIsRead = false;
                        objMessage.dtMessageTime = DateTime.Now;
                        objMessage.strMessage = Constants.REGISTRATIONMESSAGE;
                        if (iPrivateLabelId != 0)
                        {
                            objMessage.iPrivateLabelID = iPrivateLabelId;
                        }
                        bFound = true;
                    }
                    else
                    {
                        objMessage.bIsRead = (bHasShop && iShopId == objMessage.iShopID) ? true : objMessage.bIsRead;
                        objMessage.strMessage = Constants.PREFFEREDSHOPMESSAGE;
                        bFound = true;
                    }
                    objMessage.Save();
                }
            }
            if (!bFound)
            {
                MessageBL objMessage = new MessageBL();
                objMessage.iPhoneUserID = iUserId;
                objMessage.iType = Constants.REGISTRATIONMESSAGTYPE;
                objMessage.strMessage = Constants.REGISTRATIONMESSAGE;
                objMessage.bIsRead = false;
                objMessage.dtMessageTime = DateTime.Now;
                if (iPrivateLabelId != 0)
                {
                    objMessage.iPrivateLabelID = iPrivateLabelId;
                }
                objMessage.Save();

                if (bHasShop)
                {
                    MessageBL _objMessage = new MessageBL();
                    _objMessage.iShopID = iShopId;
                    _objMessage.iPhoneUserID = iUserId;
                    _objMessage.iType = Constants.REGISTRATIONMESSAGTYPE;
                    _objMessage.strMessage = Constants.PREFFEREDSHOPMESSAGE;
                    _objMessage.bIsRead = true;
                    _objMessage.dtMessageTime = DateTime.Now;
                    _objMessage.Save();
                }
            }
            return false;
        }

        /// <summary>
        /// check user preferred shop if found then return shopid as out parameter
        /// </summary>
        /// <param name="iUserId"></param>
        /// <param name="iShopId"></param>
        /// <returns></returns>
        private bool checkUserPrefferedShop(Int32 iUserId, out Int32 iShopId)
        {
            iShopId = 0;
            UserPreferredShopBL objPrefferedShop = UserPreferredShopBL.getShopByUserId(iUserId);
            if (objPrefferedShop != null)
            {
                iShopId = (Int32)objPrefferedShop.iShopId;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Save message for new oppurtunity to shop user
        /// </summary>
        /// <param name="iUserId"></param>
        /// <param name="ZipCode"></param>
        private void performPostOperation(Int32 iUserId, String ZipCode)
        {
            try
            {
                //Check user is from private label app
                Int32 iPrivateLabelId = 0;
                if (Request.QueryString[Constants.QUERYSTRING_PRIVATELABELSHOPID] != null)
                {
                    Int32.TryParse(Request.QueryString[Constants.QUERYSTRING_PRIVATELABELSHOPID], out iPrivateLabelId);
                }
                else if (Request.Form[Constants.QUERYSTRING_PRIVATELABELSHOPID] != null)
                {
                    Int32.TryParse(Request.Form[Constants.QUERYSTRING_PRIVATELABELSHOPID], out iPrivateLabelId);
                }

                saveMessage(iUserId, iPrivateLabelId);




                UserBL objUser = UserBL.getByActivityId(iUserId);

                if (objUser != null && Convert.ToBoolean(objUser.bIsRegistred_Shop))
                {
                    //Send Zip Code matches messages to customer configured by shops
                    SendZipCodeMatchesShopSMS(objUser.ID, objUser.strZip, iPrivateLabelId);

                    DeletedUsersFromRepairProspectBL.DeleteAllByUserId(iUserId);
                    Int32 iShopId;
                    if (checkUserPrefferedShop(iUserId, out iShopId))
                    {
                        UnreadUsersFromRepairProspectBL objOldEntry = UnreadUsersFromRepairProspectBL.getDataByShopId(iShopId, iUserId);
                        if (objOldEntry == null)
                        {
                            UnreadUsersFromRepairProspectBL obj = new UnreadUsersFromRepairProspectBL();
                            obj.ShopID = iShopId;
                            obj.User_id = iUserId;
                            obj.Save();
                        }
                    }
                    else
                    {
                        List<UnreadUsersFromRepairProspectBL> lstUnreadUsersFromRepairProspectBL = UnreadUsersFromRepairProspectBL.getDataByUnReadUsers(ZipCode, iUserId);
                        foreach (UnreadUsersFromRepairProspectBL objUnreadUsersFromRepairProspectBL in lstUnreadUsersFromRepairProspectBL)
                        {
                            UnreadUsersFromRepairProspectBL objOldEntry = UnreadUsersFromRepairProspectBL.getDataByShopId(objUnreadUsersFromRepairProspectBL.ShopID.Value, objUnreadUsersFromRepairProspectBL.User_id.Value);
                            if (objOldEntry == null)
                            {
                                UnreadUsersFromRepairProspectBL obj = new UnreadUsersFromRepairProspectBL();
                                obj.ShopID = objUnreadUsersFromRepairProspectBL.ShopID;
                                obj.User_id = objUnreadUsersFromRepairProspectBL.User_id;
                                obj.Save();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }


        /// <summary>
        /// Send Message to Customer when Customer's zip code matches with shops zip code. 
        /// Shop this may send multiple messages depending on how much shops added this zip code into zip code configuration list, 
        /// the message can be configured by shop user using On-demand-Campaign
        /// </summary>
        /// <param name="objBodyShop"></param>
        /// <param name="objUser"></param>
        private void SendZipCodeMatchesShopSMS(Int32 iUserId, String strZipCode, Int32 iPrivateLabelId)
        {
            try
            {
                List<BodyShopZipCodeBL> lstBodyShopZipCode = BodyShopZipCodeBL.getDataByZipCode(strZipCode);
                if (lstBodyShopZipCode != null && lstBodyShopZipCode.Count > 0)
                {
                    List<BodyShopPrivateLabelBL> lstBodyShopPrivateLabel = new List<BodyShopPrivateLabelBL>();
                    if (iPrivateLabelId != 0)
                    {
                        lstBodyShopPrivateLabel = BodyShopPrivateLabelBL.GetShopListByPrivateLabelId(iPrivateLabelId);
                        if (lstBodyShopPrivateLabel != null && lstBodyShopPrivateLabel.Count > 0)
                        {
                            lstBodyShopZipCode.RemoveAll(objBodyShopZipCode => lstBodyShopPrivateLabel.Exists(objBodyShopPrivateLabel => objBodyShopPrivateLabel.iShopID != objBodyShopZipCode.iShopId));
                        }
                    }
                    UserBL objUser = UserBL.getByActivityId(iUserId);
                    foreach (BodyShopZipCodeBL objBodyShopZipCode in lstBodyShopZipCode)
                    {
                        #region Opted-out Code
                        //Check that user has opted-out for send sms
                        if (objUser.bIsOptedOutForMobileMessage == true)
                        {
                            continue;
                        }
                        #endregion
                        CampaignBL objCampaign = CampaignBL.GetZipCodeMatchesMessageByShopId(objBodyShopZipCode.iShopId);
                        if (objCampaign != null && !String.IsNullOrEmpty(objCampaign.strMessage) && !String.IsNullOrEmpty(objUser.strPhone) && !String.IsNullOrEmpty(objCampaign.strMessage))
                        {
                            SMS objSMS = new SMS();
                            string strMessage = objCampaign.strMessage.Replace("[[ID]]", iUserId.ToString());
                            objSMS.SendSMS(objUser.strPhone, strMessage, objUser.ID, FromAppSection.NewRepairProspect, objBodyShopZipCode.iShopId);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion
    }
}
