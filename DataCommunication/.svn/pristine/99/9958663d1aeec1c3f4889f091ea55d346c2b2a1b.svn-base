using System;
using System.Collections.Generic;
using System.Web;
using SummitShopApp.BL;
using System.Xml;
using System.IO;
using SummitShopApp.Utility;

namespace SummitShopApp
{
    public partial class ChangePhone : System.Web.UI.Page
    {
        Int32 iShopID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Boolean bResult = false;
            UserBL objUser = null;
            Boolean bcreateUser = true;
            try
            {
                String strPhoneId = String.Empty;
                String strPhoneId1 = String.Empty;
                String strPhoneNo = String.Empty;
                if (!string.IsNullOrEmpty(Request.QueryString["ShopID"]))
                {
                    if (Request.QueryString["User_ID"] != null)
                        strPhoneId1 = Request.QueryString["User_ID"];
                    else if (Request.Form["User_ID"] != null)
                        strPhoneId1 = Request.Form["User_ID"];

                    if (Request.QueryString["Phone_Number"] != null)
                        strPhoneNo = Request.QueryString["Phone_Number"];
                    else if (Request.Form["Phone_Number"] != null)
                        strPhoneNo = Request.Form["Phone_Number"];

                    if (Request.QueryString["create_user"] != null)
                        Boolean.TryParse(Request.QueryString["create_user"], out bcreateUser);
                    else if (Request.Form["create_user"] != null)
                        Boolean.TryParse(Request.Form["create_user"], out bcreateUser);

                    if (!Int32.TryParse(Security.DecodeNumbers(Request.QueryString["ShopID"]), out iShopID)) 
                        return;
                }
                else
                {
                if (Request.QueryString["User_ID"] != null)
                    strPhoneId = Request.QueryString["User_ID"];
                else if (Request.Form["User_ID"] != null)
                    strPhoneId = Request.Form["User_ID"];

                if (Request.QueryString["Phone_Number"] != null)
                    strPhoneNo = Request.QueryString["Phone_Number"];
                else if (Request.Form["Phone_Number"] != null)
                    strPhoneNo = Request.Form["Phone_Number"];

                if (Request.QueryString["create_user"] != null)
                    Boolean.TryParse(Request.QueryString["create_user"], out bcreateUser);
                else if (Request.Form["create_user"] != null)
                    Boolean.TryParse(Request.Form["create_user"], out bcreateUser);
                }
                if (String.IsNullOrEmpty(strPhoneId1))
                {
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
                        //To add or update Notification ID
                        if (Request.QueryString["Push_Notification_Device_ID"] != null)
                            objUser.strPush_notification_device_id = Request.QueryString["Push_Notification_Device_ID"];
                        else if (Request.Form["Push_Notification_Device_ID"] != null && !string.IsNullOrEmpty(Request.Form["Push_Notification_Device_ID"].ToString()))
                            objUser.strPush_notification_device_id = Request.Form["Push_Notification_Device_ID"];

                        if (Request.QueryString["Is_Push_Notification_Enabled"] != null && (Request.QueryString["Is_Push_Notification_Enabled"].Equals("false", StringComparison.OrdinalIgnoreCase) || Request.QueryString["Is_Push_Notification_Enabled"].Equals("NO", StringComparison.OrdinalIgnoreCase)))
                            objUser.strPush_notification_device_id = "";
                        else if (Request.Form["Is_Push_Notification_Enabled"] != null && (Request.Form["Is_Push_Notification_Enabled"].Equals("false", StringComparison.OrdinalIgnoreCase) || Request.Form["Is_Push_Notification_Enabled"].Equals("NO", StringComparison.OrdinalIgnoreCase)))
                            objUser.strPush_notification_device_id = "";

                        //To add Device Type
                        if (Request.QueryString["Device_Type"] != null)
                        {
                            phoneIdentifier deviceType = (phoneIdentifier)Enum.Parse(typeof(phoneIdentifier), Request.QueryString["Device_Type"], true);
                            objUser.iDeviceType = (Int32)deviceType;
                        }
                        else if (Request.Form["Device_Type"] != null && !string.IsNullOrEmpty(Request.Form["Device_Type"].ToString()))
                        {
                            phoneIdentifier deviceType = (phoneIdentifier)Enum.Parse(typeof(phoneIdentifier), Request.Form["Device_Type"], true);
                            objUser.iDeviceType = (Int32)deviceType;
                        }




                        //if (!String.IsNullOrEmpty(strPhoneNo))
                        //{
                        //objUser.strFirstName = strUserName;
                        //objUser.Save();
                        //}

                        if (!String.IsNullOrEmpty(strPhoneNo))
                        {
                            objUser.strPhone = strPhoneNo;
                            if (objUser.Save())
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
                    else
                    {
                        bResult = true;
                        if (bcreateUser)
                        {
                            objUser = new UserBL();
                            if (string.IsNullOrEmpty(objUser.strUserName))
                            {
                                if (Request.QueryString["Phone_Owner_Name"] != null)
                                    objUser.strUserName = Request.QueryString["Phone_Owner_Name"];
                                else if (Request.Form["Phone_Owner_Name"] != null && !string.IsNullOrEmpty(Request.Form["Phone_Owner_Name"].ToString()))
                                    objUser.strUserName = Request.Form["Phone_Owner_Name"];
                            }
                            objUser.strPhone = strPhoneNo;
                        if (String.IsNullOrEmpty(strPhoneId1))
                            objUser.strPhone_Id = strPhoneId;
                        else
                            objUser.strPhone_Id = strPhoneId1;
                            if (!objUser.Save())
                            {
                                bResult = false;
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
            xmlWriter.WriteStartElement("ChangePhone");
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
            HttpContext.Current.Response.Flush();
            //added for private label shop 
            if (Request.QueryString[Constants.QUERYSTRING_PRIVATELABELSHOPID] != null || Request.Form[Constants.QUERYSTRING_PRIVATELABELSHOPID] != null && bcreateUser)
                performPostOperation(objUser.ID, objUser.strZip);
        }
        private bool saveMessage(Int32 iUserId)
        {
            Int32 iShopId;
            Boolean hasGroupOfPrivateShops;
            Boolean bPerformOperation;
            Boolean bHasShop = setUserPrefferedShop(iUserId, out iShopId, out hasGroupOfPrivateShops, out bPerformOperation);
            if (hasGroupOfPrivateShops || !(bPerformOperation))
            {
                return false;
            }
            if (bHasShop)
            {
                DeletedUsersFromRepairProspectBL objDeletedUsersFromRepairProspectBL = DeletedUsersFromRepairProspectBL.getDataByShopId(iShopId, iUserId);
                if (objDeletedUsersFromRepairProspectBL != null)
                {
                    objDeletedUsersFromRepairProspectBL.Delete();
                }
                UnreadUsersFromRepairProspectBL OldPrefferedShop = UnreadUsersFromRepairProspectBL.getDataByUserId(iUserId);
                if (OldPrefferedShop != null)
                {
                    if (OldPrefferedShop.ShopID != iShopId)
                    {
                        OldPrefferedShop.Delete();
                    }
                }
                UnreadUsersFromRepairProspectBL objOldEntry = UnreadUsersFromRepairProspectBL.getDataByShopId(iShopId, iUserId);
                if (objOldEntry == null)
                {
                    UnreadUsersFromRepairProspectBL objUnreadUsersFromRepairProspectBL = new UnreadUsersFromRepairProspectBL();
                    objUnreadUsersFromRepairProspectBL.User_id = iUserId;
                    objUnreadUsersFromRepairProspectBL.ShopID = iShopId;
                    objUnreadUsersFromRepairProspectBL.Save();
                }
            }
            try
            {
                Int32 iPrivateLabelId = 0;
                if (Request.QueryString[Constants.QUERYSTRING_PRIVATELABELSHOPID] != null)
                {
                    Int32.TryParse(Request.QueryString[Constants.QUERYSTRING_PRIVATELABELSHOPID], out iPrivateLabelId);
                }
                else if (Request.Form[Constants.QUERYSTRING_PRIVATELABELSHOPID] != null)
                {
                    Int32.TryParse(Request.Form[Constants.QUERYSTRING_PRIVATELABELSHOPID], out iPrivateLabelId);
                }
                if (iPrivateLabelId == 0)
                {
                    return false;
                }
                List<BodyShopPrivateLabelBL> lstBodyShopPrivateLabel = BodyShopPrivateLabelBL.GetShopListByPrivateLabelId(iPrivateLabelId);
                if (lstBodyShopPrivateLabel == null || lstBodyShopPrivateLabel.Count == 0)
                {
                    return false;
                }
                List<MessageBL> lstMessage = MessageBL.getDataByUserIdAndType(iUserId, Constants.REGISTRATIONMESSAGTYPE);
                Boolean bFound = false;
                if (lstMessage != null && lstMessage.Count > 0)
                {
                    foreach (MessageBL objMessage in lstMessage)
                    {
                        if (objMessage.iShopID == null)
                        {
                            objMessage.bIsRead = true;
                            objMessage.strMessage = Constants.REGISTRATIONMESSAGE;
                            if (iPrivateLabelId != 0)
                            {
                                objMessage.iPrivateLabelID = iPrivateLabelId;
                            }
                        }
                        else
                        {
                            objMessage.bIsRead = false;
                            objMessage.iShopID = iShopId;
                            objMessage.strMessage = Constants.PREFFEREDSHOPMESSAGE;
                            bFound = true;
                        }
                        objMessage.Save();
                    }
                }
                else
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

                    MessageBL _objMessage = new MessageBL();
                    _objMessage.iShopID = iShopId;
                    _objMessage.iPhoneUserID = iUserId;
                    _objMessage.iType = Constants.REGISTRATIONMESSAGTYPE;
                    _objMessage.strMessage = Constants.PREFFEREDSHOPMESSAGE;
                    _objMessage.bIsRead = false;
                    _objMessage.dtMessageTime = DateTime.Now;
                    _objMessage.Save();
                    bFound = true;
                }
                if (!bFound)
                {
                    MessageBL _objMessage = new MessageBL();
                    _objMessage.iShopID = iShopId;
                    _objMessage.iPhoneUserID = iUserId;
                    _objMessage.iType = Constants.REGISTRATIONMESSAGTYPE;
                    _objMessage.strMessage = Constants.PREFFEREDSHOPMESSAGE;
                    _objMessage.bIsRead = false;
                    _objMessage.dtMessageTime = DateTime.Now;
                    _objMessage.Save();
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        private bool setUserPrefferedShop(Int32 iUserId, out Int32 iShopId, out Boolean hasGroupOfPrivateShops, out Boolean bPerfromOperation)
        {
            iShopId = 0;
            hasGroupOfPrivateShops = false;
            bPerfromOperation = true;
            UserPreferredShopBL objPrefferedShop = UserPreferredShopBL.getShopByUserId(iUserId);
            Int32 iPrivateShopId = 0;
            if (Request.QueryString[Constants.QUERYSTRING_PRIVATELABELSHOPID] != null)
                iPrivateShopId = Convert.ToInt32(Request.QueryString[Constants.QUERYSTRING_PRIVATELABELSHOPID]);
            else if (Request.Form[Constants.QUERYSTRING_PRIVATELABELSHOPID] != null)
                iPrivateShopId = Convert.ToInt32(Request.Form[Constants.QUERYSTRING_PRIVATELABELSHOPID]);
            if (iPrivateShopId > 0)
            {
                BodyShopBL objShop = null;
                List<BodyShopPrivateLabelBL> lstBodyShopPrivateLabelBL = new List<BodyShopPrivateLabelBL>();
                lstBodyShopPrivateLabelBL = BodyShopPrivateLabelBL.GetShopListByPrivateLabelId(iPrivateShopId);

                //Check that more than one shop within this private labeling group? if yes then don't assign preferred shop
                if (lstBodyShopPrivateLabelBL.Count > 1)
                {
                    //This privateLabelId exist for a group of shops; user need to select preferred shop from "Select Preferred Shop" page
                    hasGroupOfPrivateShops = true;
                    return false;
                }
                else
                {
                    objShop = BodyShopBL.getShopById(Convert.ToInt32(lstBodyShopPrivateLabelBL[0].iShopID));
                }
                if (objShop != null)
                {
                    if (objPrefferedShop == null)
                    {
                        objPrefferedShop = new UserPreferredShopBL();
                    }
                    else
                    {
                        //If user has alredy set same preferred shop then return.
                        if (objShop.ID == objPrefferedShop.iShopId)
                        {
                            bPerfromOperation = false;
                            return false;
                        }
                        MessageBL objMesssage = MessageBL.getDataByUserShopIdAndType(iUserId, objShop.ID, Constants.REGISTRATIONMESSAGTYPE);
                        if (objMesssage != null)
                        {
                            objMesssage.Delete();
                        }
                    }
                    objPrefferedShop.iShopId = objShop.ID;
                    objPrefferedShop.iUserId = iUserId;
                    if (objPrefferedShop.Save())
                    {
                        iShopId = objShop.ID;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        private void performPostOperation(Int32 iUserId, String ZipCode)
        {
            try
            {
                saveMessage(iUserId);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
