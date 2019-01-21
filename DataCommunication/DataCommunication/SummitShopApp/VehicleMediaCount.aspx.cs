using System.Web.UI.WebControls;
using SummitShopApp.BL;
using System.Xml;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using SummitShopApp.Utility;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System;
using System.Collections.Generic;
using System.Web;

namespace SummitShopApp
{
    public partial class VehicleMediaCount : System.Web.UI.Page
    {
        private byte[] byteImageData = null;
        Int32 iShopID = 0;
        Int32 iCount = 0;
        String strVehicleStatus = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String strPhoneId = String.Empty;
                String strImage = String.Empty;
                String strNewApp = String.Empty;

                if (!String.IsNullOrEmpty(Request.QueryString["ShopID"]))
                {
                    if (!Int32.TryParse(Security.DecodeNumbers(Request.QueryString["ShopID"]), out iShopID))
                        return;
                }
                //else
                //{
                //    Int32.TryParse(strNewApp, out iShopID);
                //}


                if (Request.QueryString["User_Id"] != null)
                {
                    strPhoneId = Request.QueryString["User_Id"];
                    strNewApp = Request.QueryString["N"];
                }
                else if (Request.Form["User_Id"] != null)
                {
                    strPhoneId = Request.Form["User_Id"];
                    strNewApp = Request.Form["N"];
                }

                //Check phone no is not empty/null
                if (!String.IsNullOrEmpty(strPhoneId))
                {
                    List<MyCustomerBL> lstMyCustomer = null;
                    UserBL objUser = null;
                    if (iShopID != 0)
                    {

                        MyCustomerBL objMyCustomer = null;
                        lstMyCustomer = MyCustomerBL.getDataByShopIDandMobileList(iShopID, strPhoneId);

                        if (lstMyCustomer != null && lstMyCustomer.Count > 0)
                            objMyCustomer = lstMyCustomer.Find(t => t.strStatusOfVehicle.ToLower().Trim() != Constants.VEHICLE_STATUS_DELIVERED.ToLower().Trim());

                        if (objMyCustomer != null)
                        {
                            if (!String.IsNullOrEmpty(objMyCustomer.strStatusOfVehicle))
                            {
                                //If status is delivered then dont show details for this customer
                                if (objMyCustomer.strStatusOfVehicle.ToLower().Trim() == Constants.VEHICLE_STATUS_DELIVERED.ToLower().Trim())
                                {
                                    return;
                                }
                            }


                            
                            objUser = UserBL.getByActivityId(objMyCustomer.iUserId.Value);
                            //remove diffrent name customers, there should be only same name customers
                            lstMyCustomer.RemoveAll(p1 => p1.strUserName != objMyCustomer.strUserName);

                            
                        }

                        ////Find User using phone no & shopID
                        //MyCustomerBL objMyCustomer = MyCustomerBL.getDataByShopIdNPhone(iShopID, strPhoneId);
                        //if (objMyCustomer != null)
                        //{
                        //    objUser = UserBL.getByActivityId(objMyCustomer.iUserId.Value);

                        //}
                    }
                    else
                    {
                        string[] strPhones = strPhoneId.Split('_');

                        //find user using phoneID for private label
                        if (strPhones.Length == 3)
                            objUser = UserBL.getDataByPhoneId(strPhoneId);
                        else
                            objUser = UserBL.GetDataByPhoneNumber(strPhones[0]);

                    }
                    if (objUser != null)
                    {
                        List<VehicleInfoBL> lstVehicleInfo = null;
                        if (lstMyCustomer != null)
                        {
                            lstVehicleInfo = new List<VehicleInfoBL>();
                            foreach (MyCustomerBL objMyCustomerBL in lstMyCustomer)
                            {

                                //get Customer's Vehicle Details
                                lstVehicleInfo.AddRange(VehicleInfoBL.getDataByUserId(objMyCustomerBL.iUserId.Value));
                            }
                        }
                        else
                        {
                            //if user found get vehicle info
                            lstVehicleInfo = VehicleInfoBL.getDataByUserId(objUser.ID);
                        }
                        if (lstVehicleInfo != null)
                        {
                            foreach (var objVehicleInfo in lstVehicleInfo)
                            {
                                //get count of vehicle media links newly uploaded
                                iCount += VehicleMediaLinkBL.getNewLinkCountByVehicleID(objVehicleInfo.ID);
                                //get Vehicle status Changed
                                UserVehicleStatusBL objUserVehicleStatusBL = UserVehicleStatusBL.getDataByVehicleId(objVehicleInfo.ID);
                                if (objUserVehicleStatusBL != null && objUserVehicleStatusBL.bIsRead.HasValue && objUserVehicleStatusBL.bIsRead.Value == 1)
                                    strVehicleStatus = "true";
                            }
                            ////Find current vehicle info
                            //VehicleInfoBL objVehicleInfo = lstVehicleInfo.Find(p => p.bIsUsing == true || p.bIsUsing == null);
                            //if (objVehicleInfo != null)
                            //{
                            //    //get count of vehicle media links newly uploaded
                            //    iCount = VehicleMediaLinkBL.getNewLinkCountByVehicleID(objVehicleInfo.ID);
                            //    //get Vehicle status Changed
                            //    UserVehicleStatusBL objUserVehicleStatusBL = UserVehicleStatusBL.getDataByVehicleId(objVehicleInfo.ID);
                            //    if (objUserVehicleStatusBL != null && objUserVehicleStatusBL.bIsRead.HasValue && objUserVehicleStatusBL.bIsRead.Value == 1)
                            //        strVehicleStatus = "true";
                            //}
                        }

                    }
                    //for sending info to html5 app using xml
                    XmlDocument xmlDoc = new XmlDocument();
                    MemoryStream stream = new MemoryStream();
                    //XmlTextWriter xmlWriter = new XmlTextWriter(stream, System.Text.Encoding.ASCII);
                    XmlTextWriter xmlWriter = new XmlTextWriter(stream, System.Text.Encoding.UTF8);
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("VehicleMediaCount");
                    //count for newly uploaded vehiclemedia links
                    xmlWriter.WriteElementString("Count", String.IsNullOrEmpty(iCount.ToString()) ? "" : iCount.ToString());
                    //check vehicleStatus
                    xmlWriter.WriteElementString("VehicleStatus", String.IsNullOrEmpty(strVehicleStatus) ? "" : strVehicleStatus);


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
            catch (Exception ex)
            {

            }
        }

    }
}
