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
using System.Text;

namespace SummitShopApp
{
    public partial class VehicleInfo : System.Web.UI.Page
    {
        Int32 iShopID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Boolean bResult = false;
            VehicleInfoBL objVehicleInfo = new VehicleInfoBL();
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
                        String strPhone = String.Empty;

                        if (string.IsNullOrEmpty(objUser.strUserName))
                        {
                            if (Request.QueryString["Phone_Owner_Name"] != null)
                                objUser.strUserName = Request.QueryString["Phone_Owner_Name"];
                            else if (Request.Form["Phone_Owner_Name"] != null && !string.IsNullOrEmpty(Request.Form["Phone_Owner_Name"].ToString()))
                                objUser.strUserName = Request.Form["Phone_Owner_Name"];
                        }

                        if (Request.QueryString["Current_Phone_Number"] != null)
                            strPhone = Request.QueryString["Current_Phone_Number"];
                        else if (Request.Form["Current_Phone_Number"] != null)
                            strPhone = Request.Form["Current_Phone_Number"];

                        String strPhoneNumber = strPhone;
                        StringBuilder strNewNumber = new StringBuilder();
                        foreach (char c in strPhoneNumber)
                        {
                            if (Char.IsNumber(c))
                            {
                                strNewNumber.Append(c);
                            }
                        }


                        objUser.strPhone = String.IsNullOrEmpty(strPhone) ? objUser.strPhone : strPhone;                            

                        //if (!String.IsNullOrEmpty(strUserName) && objUser.strFirstName != strUserName)
                        //{
                        //    objUser.strFirstName = strUserName;                            
                        //}
                        objUser.Save();

                        objVehicleInfo.iUserId = objUser.ID;

                    if (Request.QueryString["Model"] != null && Request.QueryString["Model"]!="undefined")
                            objVehicleInfo.strModel = Request.QueryString["Model"].ToString();
                    else if (Request.Form["Model"] != null && Request.Form["Model"] != "undefined")
                            objVehicleInfo.strModel = Request.Form["Model"].ToString();

                    if (Request.QueryString["Make"] != null && Request.QueryString["Make"] != "undefined")
                            objVehicleInfo.strMake = Request.QueryString["Make"].ToString();
                    else if (Request.Form["Make"] != null && Request.Form["Make"] != "undefined")
                            objVehicleInfo.strMake = Request.Form["Make"].ToString();

                    if (Request.QueryString["Year"] != null && Request.QueryString["Year"] != "undefined")
                            objVehicleInfo.strYear = Request.QueryString["Year"].ToString();
                    else if (Request.Form["Year"] != null && Request.Form["Year"] != "undefined")
                            objVehicleInfo.strYear = Request.Form["Year"].ToString();

                    if (Request.QueryString["OtherInfo"] != null && Request.QueryString["OtherInfo"] != "undefined")
                            objVehicleInfo.strOtherInfo = Request.QueryString["OtherInfo"].ToString();
                    else if (Request.Form["OtherInfo"] != null && Request.Form["OtherInfo"] != "undefined")
                            objVehicleInfo.strOtherInfo = Request.Form["OtherInfo"].ToString();

                    if (Request.QueryString["IsUsing"] != null && Request.QueryString["IsUsing"] != "undefined")
                            objVehicleInfo.bIsUsing = Convert.ToBoolean(Request.QueryString["IsUsing"]);
                    else if (Request.Form["IsUsing"] != null && Request.Form["IsUsing"] != "undefined")
                            objVehicleInfo.bIsUsing = Convert.ToBoolean(Request.Form["IsUsing"]);

                        if (objVehicleInfo.bIsUsing != null)
                        {
                            if (Convert.ToBoolean(objVehicleInfo.bIsUsing))
                            {
                                List<VehicleInfoBL> objUserVehicles = VehicleInfoBL.getDataByUserId(objUser.ID);
                                if (objUserVehicles != null)
                                {
                                    foreach (VehicleInfoBL objTemp in objUserVehicles)
                                    {
                                        if (objTemp.strMake.Equals(objVehicleInfo.strMake) && objTemp.strModel.Equals(objVehicleInfo.strModel) && objTemp.strYear.Equals(objVehicleInfo.strYear))
                                        {
                                            objVehicleInfo = objTemp;
                                            objVehicleInfo.bIsUsing = true;
                                        }
                                        else
                                        {
                                            objTemp.bIsUsing = false;
                                            objTemp.Save();
                                        }
                                    }
                                }
                            }
                        }
                        if (objVehicleInfo.Save())
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
            catch (Exception ex)
            {
                bResult = true;
            }

            XmlDocument xmlDoc = new XmlDocument();
            MemoryStream stream = new MemoryStream();
            //XmlTextWriter xmlWriter = new XmlTextWriter(stream, System.Text.Encoding.ASCII);
            XmlTextWriter xmlWriter = new XmlTextWriter(stream, System.Text.Encoding.UTF8);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("VehicleInformation");
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
