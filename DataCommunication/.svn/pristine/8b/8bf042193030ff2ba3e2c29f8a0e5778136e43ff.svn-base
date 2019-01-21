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
    public partial class AccidentReport : System.Web.UI.Page
    {
        Int32 iShopID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Boolean bResult = false;
            AccidentReportBL objAccidentReport = new AccidentReportBL();
            string strZipFilePath = String.Empty;
            try
            {
                String strPhoneId = String.Empty;
                String strPhoneId1 = String.Empty;
                if (!String.IsNullOrEmpty(Request.QueryString["ShopID"]))
                {
                    //get the phone user id
                    if (Request.QueryString["User_ID"] != null)
                        strPhoneId1 = Request.QueryString["User_ID"];
                    else if (Request.Headers["User_ID"] != null)
                        strPhoneId1 = Request.Headers["User_ID"];
                    if (!Int32.TryParse(Security.DecodeNumbers(Request.QueryString["ShopID"]), out iShopID))
                        return;
                }
                else
                {
                    //get the phone user id
                    if (Request.QueryString["User_ID"] != null)
                        strPhoneId = Request.QueryString["User_ID"];
                    else if (Request.Headers["User_ID"] != null)
                        strPhoneId = Request.Headers["User_ID"];
                }
                //if (!String.IsNullOrEmpty(strPhoneId))
                //{
                //if fphone user id is found
                UserBL objUser = null;
                if (String.IsNullOrEmpty(strPhoneId1))
                    objUser = UserBL.getDataByPhoneId(strPhoneId);
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
                    }

                    if (!String.IsNullOrEmpty(strUserName) && objUser.strFirstName != strUserName)
                    {
                        //if user's first name is changed
                        objUser.strFirstName = strUserName;
                        objUser.Save();
                    }

                    objAccidentReport.iUserId = objUser.ID;

                    if (Request.QueryString["Street_Name"] != null)
                        objAccidentReport.strStreet = Request.QueryString["Street_Name"].ToString();
                    else if (Request.Headers["Street_Name"] != null)
                        objAccidentReport.strStreet = Request.Headers["Street_Name"].ToString();

                    if (Request.QueryString["City_State"] != null)
                        objAccidentReport.strCity = Request.QueryString["City_State"].ToString();
                    else if (Request.Headers["City_State"] != null)
                        objAccidentReport.strCity = Request.Headers["City_State"].ToString();

                    if (Request.QueryString["Accident_Description"] != null)
                        objAccidentReport.strDescription = Request.QueryString["Accident_Description"].ToString();
                    else if (Request.Headers["Accident_Description"] != null)
                        objAccidentReport.strDescription = Request.Headers["Accident_Description"].ToString();

                    if (Request.QueryString["Name"] != null)
                        objAccidentReport.strDriverName = Request.QueryString["Name"].ToString();
                    else if (Request.Headers["Name"] != null)
                        objAccidentReport.strDriverName = Request.Headers["Name"].ToString();

                    if (Request.QueryString["Phone"] != null)
                        objAccidentReport.strDriverPhone = Request.QueryString["Phone"].ToString();
                    else if (Request.Headers["Phone"] != null)
                        objAccidentReport.strDriverPhone = Request.Headers["Phone"].ToString();

                    if (Request.QueryString["License_State_and_Plate"] != null)
                        objAccidentReport.strDriverLicenseStatePlate = Request.QueryString["License_State_and_Plate"].ToString();
                    else if (Request.Headers["License_State_and_Plate"] != null)
                        objAccidentReport.strDriverLicenseStatePlate = Request.Headers["License_State_and_Plate"].ToString();

                    if (Request.QueryString["Driver_License"] != null)
                        objAccidentReport.strDriverLicenseNo = Request.QueryString["Driver_License"].ToString();
                    else if (Request.Headers["Driver_License"] != null)
                        objAccidentReport.strDriverLicenseNo = Request.Headers["Driver_License"].ToString();

                    if (Request.QueryString["Vehicle_Type"] != null)
                        objAccidentReport.strDriverVehicleType = Request.QueryString["Vehicle_Type"].ToString();
                    else if (Request.Headers["Vehicle_Type"] != null)
                        objAccidentReport.strDriverVehicleType = Request.Headers["Vehicle_Type"].ToString();

                    if (Request.QueryString["Their_Insurance_Company"] != null)
                        objAccidentReport.strInsuranceCompanyName = Request.QueryString["Their_Insurance_Company"].ToString();
                    else if (Request.Headers["Their_Insurance_Company"] != null)
                        objAccidentReport.strInsuranceCompanyName = Request.Headers["Their_Insurance_Company"].ToString();

                    if (Request.QueryString["Their_Insurance_Policy"] != null)
                        objAccidentReport.strInsurancePolicyNo = Request.QueryString["Their_Insurance_Policy"].ToString();
                    else if (Request.Headers["Their_Insurance_Policy"] != null)
                        objAccidentReport.strInsurancePolicyNo = Request.Headers["Their_Insurance_Policy"].ToString();

                    if (Request.QueryString["Police_Office_and_Badge"] != null)
                        objAccidentReport.strPoliceOffice = Request.QueryString["Police_Office_and_Badge"].ToString();
                    else if (Request.Headers["Police_Office_and_Badge"] != null)
                        objAccidentReport.strPoliceOffice = Request.Headers["Police_Office_and_Badge"].ToString();

                    if (Request.QueryString["Police_Report"] != null)
                        objAccidentReport.strPoliceReportNo = Request.QueryString["Police_Report"].ToString();
                    else if (Request.Headers["Police_Report"] != null)
                        objAccidentReport.strPoliceReportNo = Request.Headers["Police_Report"].ToString();

                    if (Request.QueryString["Witness"] != null)
                        objAccidentReport.strWitnesses = Request.QueryString["Witness"].ToString();
                    else if (Request.Headers["Witness"] != null)
                        objAccidentReport.strWitnesses = Request.Headers["Witness"].ToString();

                    if (Request.QueryString["Witness_Comment"] != null)
                        objAccidentReport.strWitnessComments = Request.QueryString["Witness_Comment"].ToString();
                    else if (Request.Headers["Witness_Comment"] != null)
                        objAccidentReport.strWitnessComments = Request.Headers["Witness_Comment"].ToString();

                    if (Request.QueryString["Misc_Notes"] != null)
                        objAccidentReport.strMiscNotes = Request.QueryString["Misc_Notes"].ToString();
                    else if (Request.Headers["Misc_Notes"] != null)
                        objAccidentReport.strMiscNotes = Request.Headers["Misc_Notes"].ToString();

                    byte[] photo;

                    UserPreferredShopBL objUserPreferredShop = UserPreferredShopBL.getShopByUserId(objUser.ID);


                    MessageBL objMessage = null;
                    if (objUserPreferredShop != null || iShopID > 0)
                    {
                        //add one message against his preferred shop
                        objMessage = new MessageBL();
                        objMessage.strMessage = "Accident Report";
                        objMessage.iPhoneUserID = objUser.ID;
                        if (objUserPreferredShop != null)
                            objMessage.iShopID = objUserPreferredShop.iShopId;
                        else
                            objMessage.iShopID = iShopID;
                        objMessage.dtMessageTime = DateTime.Now;
                        objMessage.iType = Constants.AccidentReport;
                        if (objMessage.Save())
                        {
                            if (Request.ContentType.Contains("image"))
                            {
                                if (Request.ContentLength > 1)
                                {
                                    photo = Request.BinaryRead(Request.ContentLength);
                                    //int cnt = Request.TotalBytes;
                                    //photo = Request.BinaryRead(cnt);                
                                    MemoryStream bipimag = new MemoryStream(photo);
                                    System.Drawing.Image imag = new Bitmap(bipimag);
                                    if (!String.IsNullOrEmpty(Server.MapPath(Constants.ACIIDENTREPORTIMAGE)))
                                    {
                                        String filePath = Server.MapPath(Constants.ACIIDENTREPORTIMAGE) + "\\" + objMessage.ID + ".jpeg";
                                        imag.Save(Constants.SHOPAPP_PATH_IMAGES + "\\" + objMessage.ID + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                        objMessage.strAttachment = objMessage.ID + ".jpeg";
                                    }
                                }
                            }
                            else if (Request.ContentType.Contains("multipart"))
                            {
                                if (Request.Files.Count > 0 && !String.IsNullOrEmpty(Constants.SHOPAPP_PATH_IMAGES))
                                {
                                    // Zip the file if more than one photo  
                                    if (Request.Files.Count > 1)
                                    {
                                        strZipFilePath = Constants.SHOPAPP_PATH_IMAGES + "\\" + objMessage.ID + ".zip";
                                        ZipOutputStream objZipFile = new ZipOutputStream(File.Create(strZipFilePath));
                                        //0-9, 9 being the highest level of compression
                                        objZipFile.SetLevel(3);
                                        // To permit the zip to be unpacked by built-in extractor in WinXP and Server2003, WinZip 8, Java, and other older code,
                                        // you need to do one of the following: Specify UseZip64.Off, or set the Size.
                                        // If the file may be bigger than 4GB, or you do not need WinXP built-in compatibility, you do not need either,
                                        // but the zip will be in Zip64 format which not all utilities can understand.
                                        objZipFile.UseZip64 = UseZip64.Off;
                                        for (int i = 0; i < Request.Files.Count; i++)
                                        {
                                            HttpPostedFile file = Request.Files[i];
                                            if (!Directory.Exists(Constants.SHOPAPP_PATH_IMAGES + "\\TempZipFiles"))
                                            {
                                                Directory.CreateDirectory(Constants.SHOPAPP_PATH_IMAGES + "\\TempZipFiles");
                                            }
                                            String strFilePath = Constants.SHOPAPP_PATH_IMAGES + "\\TempZipFiles\\" + file.FileName;
                                            if (File.Exists(strFilePath))
                                            {
                                                File.Delete(strFilePath);
                                            }
                                            file.SaveAs(strFilePath);
                                            string strEntryName = Path.GetFileName(strFilePath); // Removes drive from name and fixes slash direction
                                            ZipEntry objZipEntry = new ZipEntry(strEntryName);
                                            objZipEntry.DateTime = DateTime.Now;
                                            objZipFile.PutNextEntry(objZipEntry);
                                            // Zip the file in buffered chunks
                                            // the "using" will close the stream even if an exception occurs
                                            byte[] buffer = new byte[4096];
                                            using (FileStream streamReader = File.OpenRead(strFilePath))
                                            {
                                                StreamUtils.Copy(streamReader, objZipFile, buffer);
                                            }
                                            objZipFile.CloseEntry();
                                            File.Delete(strFilePath);
                                        }
                                        objZipFile.IsStreamOwner = true;	// Makes the Close also Close the underlying stream
                                        objZipFile.Close();
                                        objMessage.strAttachment = objMessage.ID + ".zip";
                                    }
                                    else
                                    {
                                        // String filePath = Server.MapPath(Constants.ACIIDENTREPORTIMAGE) + "\\" + objMessage.ID + Path.GetExtension(Request.Files[0].FileName);
                                        Request.Files[0].SaveAs(Constants.SHOPAPP_PATH_IMAGES + "\\" + objMessage.ID + Path.GetExtension(Request.Files[0].FileName));
                                        objMessage.strAttachment = objMessage.ID + Path.GetExtension(Request.Files[0].FileName);
                                    }
                                }
                            }
                            objMessage.Save();
                            objAccidentReport.iMessageId = objMessage.ID;
                            //save the accident report if saved return true else false
                            if (objAccidentReport.Save())
                            {
                                bResult = true;
                                if (Request.QueryString["Contact_Email_ID"] != null)
                                    SendAccidentReport(objMessage, objAccidentReport, Request.QueryString["Contact_Email_ID"], Request.Headers["Customer_Email_ID"], Request.Headers["Accident_Report_Date"]);
                               else if (!String.IsNullOrEmpty(Request.Headers["Contact_Email_ID"]))
                                    SendAccidentReport(objMessage, objAccidentReport, Request.Headers["Contact_Email_ID"], Request.Headers["Customer_Email_ID"], Request.Headers["Accident_Report_Date"]);
                            }
                        }
                    }
                }
                //}
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
            xmlWriter.WriteStartElement("AccidentReport");
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


        private void SendAccidentReport(MessageBL objMessage, AccidentReportBL objAccidentReport, String strReceiptient, String strCustomerEmail, String strDate)
        {
            if (objMessage != null && objAccidentReport != null && !String.IsNullOrEmpty(strReceiptient))
            {
                StringBuilder strMessage = new StringBuilder();
                strMessage.Append("<table><tr><td colspan='2' align='center'><b>Accident Report</b></td></tr>");
                strMessage.Append("<tr><td colspan='2' style='height:5px;'></td></tr>");
                strMessage.Append("<tr><td>Date:</td><td>" + Convert.ToDateTime(strDate).ToShortDateString() + "</tr>");
                strMessage.Append("<tr><td>Customer Email:</td><td>" + strCustomerEmail + "</tr>");
                strMessage.Append("<tr><td>Street Name:</td><td>" + objAccidentReport.strStreet + "</tr>");
                //since city field comes wtih state seperated by ,
                strMessage.Append("<tr><td>City , State:</td><td>" + objAccidentReport.strCity + "</tr>");
                strMessage.Append("<tr><td>Accident Description:</td><td>" + objAccidentReport.strDescription + "</tr>");
                strMessage.Append("<tr><td colspan='2' style='height:5px;'></td></tr>");
                strMessage.Append("<tr><td colspan='2' align='center'><b>Other Vehicle Driver</b></td></tr>");
                strMessage.Append("<tr><td colspan='2' style='height:5px;'></td></tr>");
                strMessage.Append("<tr><td>Name:</td><td>" + objAccidentReport.strDriverName + "</tr>");
                strMessage.Append("<tr><td>Phone:</td><td>" + objAccidentReport.strDriverPhone + "</tr>");
                strMessage.Append("<tr><td>License State and Plate:</td><td>" + objAccidentReport.strDriverLicenseStatePlate + "</tr>");
                strMessage.Append("<tr><td>Driver License:</td><td>" + objAccidentReport.strDriverLicenseNo + "</tr>");
                strMessage.Append("<tr><td>Vehicle Type:</td><td>" + objAccidentReport.strDriverVehicleType + "</tr>");
                strMessage.Append("<tr><td>Their Insurance Company:</td><td>" + objAccidentReport.strInsuranceCompanyName + "</tr>");
                strMessage.Append("<tr><td>Their Insurance Policy:</td><td>" + objAccidentReport.strInsurancePolicyNo + "</tr>");
                strMessage.Append("<tr><td colspan='2' style='height:5px;'></td></tr>");
                strMessage.Append("<tr><td colspan='2' align='center'><b>Police Information</b></td></tr>");
                strMessage.Append("<tr><td colspan='2' style='height:5px;'></td></tr>");
                strMessage.Append("<tr><td>Police Office and Badge#:</td><td>" + objAccidentReport.strPoliceOffice + "</tr>");
                strMessage.Append("<tr><td>Police Report:</td><td>" + objAccidentReport.strPoliceReportNo + "</tr>");
                strMessage.Append("<tr><td colspan='2' style='height:5px;'></td></tr>");
                strMessage.Append("<tr><td colspan='2' align='center'><b>Other Accident Info</b></td></tr>");
                strMessage.Append("<tr><td colspan='2' style='height:5px;'></td></tr>");
                strMessage.Append("<tr><td>Witness:</td><td>" + objAccidentReport.strWitnesses + "</tr>");
                strMessage.Append("<tr><td>Witness Comment:</td><td>" + objAccidentReport.strWitnessComments + "</tr>");
                strMessage.Append("<tr><td>Misc Notes:</td><td>" + objAccidentReport.strMiscNotes + "</tr>");
                List<Attachment> lstAttachment = null;
                if (objMessage.strAttachment != null)
                {
                    lstAttachment = new List<Attachment>();
                    lstAttachment.Add(new Attachment(Constants.SHOPAPP_PATH_IMAGES + "\\" + objMessage.strAttachment));
                }
                strMessage.Append("</table>");
                EmailService.SendEmail.SendMail(strReceiptient, null, strMessage.ToString(), ConfigurationManager.AppSettings["SmtpUserName"], ConfigurationManager.AppSettings["SmtpUserPassword"], ConfigurationManager.AppSettings["SmtpHost"], "Accident Report", null, lstAttachment);
            }
        }

        /// <summary>
        /// Get content type of image file
        /// </summary>
        /// <param name="strPhysicalPath">file path of image</param>
        /// <returns></returns>
        public static String getContentType(String strPhysicalPath)
        {
            String strContentType = String.Empty;
            try
            {
                FileInfo _objFile = new FileInfo(strPhysicalPath);
                switch (_objFile.Extension.ToLower())
                {
                    case ".bmp":
                        strContentType = "image/bmp";
                        break;
                    case ".png":
                        strContentType = "image/x-png";
                        break;
                    case ".cod":
                        strContentType = "image/cis-cod";
                        break;
                    case ".gif":
                        strContentType = "image/gif";
                        break;
                    case ".ief":
                        strContentType = "image/ief";
                        break;
                    case ".jpe":
                    case ".jpeg":
                    case ".jpg":
                        strContentType = "image/jpeg";
                        break;
                    case ".jfif":
                        strContentType = "image/pipeg";
                        break;
                    case ".svg":
                        strContentType = "image/svg+xml";
                        break;
                    case ".tif":
                    case ".tiff":
                        strContentType = "image/tiff";
                        break;
                    case ".ras":
                        strContentType = "image/x-cmu-raster";
                        break;
                    case ".cmx":
                        strContentType = "image/x-cmx";
                        break;
                    case ".ico":
                        strContentType = "image/x-icon";
                        break;
                    case ".pnm":
                        strContentType = "image/x-portable-anymap";
                        break;
                    case ".pbm":
                        strContentType = "image/x-portable-bitmap";
                        break;
                    case ".pgm":
                        strContentType = "image/x-portable-graymap";
                        break;
                    case ".ppm":
                        strContentType = "image/x-portable-pixmap";
                        break;
                    case ".rgb":
                        strContentType = "image/x-rgb";
                        break;
                    case ".xbm":
                        strContentType = "image/x-xbitmap";
                        break;
                    case ".xpm":
                        strContentType = "image/x-xpixmap";
                        break;
                    case ".xwd":
                        strContentType = "image/x-xwindowdump";
                        break;
                    case ".zip":
                        strContentType = "application/zip";
                        break;
                    default:
                        strContentType = String.Empty;
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
            }
            return strContentType;

        }
    }
}
