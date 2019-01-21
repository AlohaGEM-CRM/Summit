using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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

namespace SummitShopApp
{
    public partial class PreferredShop : System.Web.UI.Page
    {
        private byte[] byteImageData = null;
        Int32 iShopID = 0;
        Int32 iCount = 0;
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
                }
                else
                {

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
                    Int32.TryParse(strNewApp, out iShopID);

                }
                if (!String.IsNullOrEmpty(strPhoneId))
                {
                    UserBL objUser = null;
                    if (iShopID != 0)
                    {
                        MyCustomerBL objMyCustomer = MyCustomerBL.getDataByShopIdNPhone(iShopID, strPhoneId);
                        if (objMyCustomer != null)
                            objUser = UserBL.getByActivityId(objMyCustomer.iUserId.Value);

                    }
                    else
                    {
                        objUser = UserBL.getDataByPhoneId(strPhoneId);
                    }
                    String strShopName = String.Empty;
                    String strPhone = String.Empty;
                    String strEMail = String.Empty;
                    String strCell = String.Empty;
                    String strWebSite = String.Empty;
                    String strLogo = String.Empty;
                    string strShopID = String.Empty;
                    BodyShopBL objBodyShop = null;

                    {

                        if (iShopID == 0)
                        {
                            if (objUser != null)
                                objBodyShop = BodyShopBL.getShopByUserId(objUser.ID);
                        }
                        else
                            objBodyShop = BodyShopBL.getShopById(iShopID);
                        if (objBodyShop != null)
                        {
                            if (iShopID == 0)
                                strShopID  = objBodyShop.ID.ToString();
                            strShopName = objBodyShop.strShopName;
                            strPhone = objBodyShop.strPhone;
                            strEMail = objBodyShop.strEmail;
                            strWebSite = GetWebSiteURL(objBodyShop.ID, objBodyShop.bIsPremierShop);
                            strCell = objBodyShop.strPhone;
                            strLogo = objBodyShop.strImagePath;
                            //strLogo = "E:\\SummitApp\\Bentley\\px_bentley_main.jpg";
                            if (!string.IsNullOrEmpty(strLogo) && File.Exists(Constants.SHOP_APP_PHY_PATH + strLogo))
                            {
                                strLogo = Constants.SHOP_APP_PHY_PATH + strLogo;
                                byteImageData = ReadImage(strLogo.ToLower(), new string[] { ".gif", ".jpg", ".bmp", ".png" });
                            }
                            else
                            {
                                byteImageData = null;
                            }
                        }
                    }

                    XmlDocument xmlDoc = new XmlDocument();
                    MemoryStream stream = new MemoryStream();
                    //XmlTextWriter xmlWriter = new XmlTextWriter(stream, System.Text.Encoding.ASCII);
                    XmlTextWriter xmlWriter = new XmlTextWriter(stream, System.Text.Encoding.UTF8);
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("MyPreferredShop");
                    xmlWriter.WriteElementString("Name", String.IsNullOrEmpty(strShopName) ? "" : strShopName);
                    xmlWriter.WriteElementString("Phone", String.IsNullOrEmpty(strPhone) ? "" : strPhone);
                    xmlWriter.WriteElementString("EMail", String.IsNullOrEmpty(strEMail) ? "" : strEMail);
                    xmlWriter.WriteElementString("Cell", String.IsNullOrEmpty(strCell) ? "" : strCell);
                    xmlWriter.WriteElementString("WebSite", String.IsNullOrEmpty(strWebSite) ? "" : strWebSite);
                    if(iShopID==0)
                        xmlWriter.WriteElementString("ShopID", String.IsNullOrEmpty(Security.EncodeNumbers(strShopID)) ? "" : strWebSite);

                    // New attribute 'N' for New Prototype App with value 'T' for True has to be recieved to PreferredShop.aspx,
                    // so as to identify new App and get the dynamic logo in response.
                    // This attribute is only for New Prototype app.
                    if (!String.IsNullOrEmpty(strNewApp))
                    {
                        if (strNewApp.Equals("T"))
                        {
                            xmlWriter.WriteElementString("Logo", String.IsNullOrEmpty(byteImageData != null ? Convert.ToBase64String(byteImageData) : strImage) ? strImage : Convert.ToBase64String(byteImageData));
                        }
                    }
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
                ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
            }
        }

        protected String GetWebSiteURL(Object strShopId, Object bIsPremierShop)
        {
            try
            {
                StringBuilder sbURL = new StringBuilder();
                sbURL.Append("http://");
                sbURL.Append(Request.Url.Host);
                sbURL.Append("/Summit");

                //String strQueryString = Request.RawUrl;
                //strQueryString = strQueryString.Remove(0, strQueryString.IndexOf("?"));
                ////sbURL = sbURL.Remove(strURL.LastIndexOf("/"), strURL.Length - strURL.LastIndexOf("/"));

                //StringBuilder sbURL = new StringBuilder(Request.Url.AbsoluteUri);
                //String strURL = Request.Url.AbsoluteUri;
                //String strQueryString = Request.RawUrl;
                //strQueryString = strQueryString.Remove(0, strQueryString.IndexOf("?"));
                //sbURL = sbURL.Remove(strURL.LastIndexOf("/"), strURL.Length - strURL.LastIndexOf("/"));

                if (bIsPremierShop != null)
                {
                    if (Convert.ToBoolean(bIsPremierShop))
                    {
                        sbURL.Append("/BodyShopDetails.aspx");
                    }
                    else
                    {
                        sbURL.Append("/ShowBodyShop.aspx");
                    }
                }
                else
                {
                    sbURL.Append("/ShowBodyShop.aspx");
                }

                //sbURL.Append(strQueryString);
                sbURL.Append("?ShopId=" + Convert.ToString(strShopId));

                return Convert.ToString(sbURL);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
                return String.Empty;
            }
        }
        # region Converting Image to Byte

        private static byte[] ReadImage(string p_postedImageFileName, string[] p_fileType)
        {

            bool isValidFileType = false;

            try
            {

                FileInfo file = new FileInfo(p_postedImageFileName);

                foreach (string strExtensionType in p_fileType)
                {
                    if (strExtensionType == file.Extension)
                    {
                        isValidFileType = true;
                        break;
                    }

                }

                if (isValidFileType)
                {

                    FileStream fs = new FileStream(p_postedImageFileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);

                    byte[] image = br.ReadBytes((int)fs.Length);

                    br.Close();

                    fs.Close();

                    MemoryStream ms = new MemoryStream();
                    ms.Write(image, 0, image.Length);
                    Bitmap unrenderedImage = new Bitmap(ms);
                    ms.Close();
                    image = WarpImageDimensions(unrenderedImage);

                    return image;
                }

                return null;

            }

            catch (Exception ex)
            {

                throw ex;

            }

        }

        #endregion
        private static byte[] WarpImageDimensions(Bitmap imageToSave)
        {
            /* RE-SIZE THE IMAGE ACCORDING TO A FIXED WIDTH OF 200 PIXELS */
            Bitmap resizedImage = ResizeSubmittedImage(imageToSave);

            /* SET THE RESOLUTION OF THE IMAGE TO 72dpi */
            const float res = 72;
            resizedImage.SetResolution(res, res);


            /* SET THE INTERPOLATION MODE */
            Graphics g = Graphics.FromImage(resizedImage);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            /* RE-SET THE IMAGE'S COMPRESSION QUALITY TO "100" */
            EncoderParameters encoderParams = new EncoderParameters();
            long[] quality = new long[1];
            quality[0] = 100;

            EncoderParameter ep = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = ep;

            ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo jpegICI = null;

            for (int x = 0; x < arrayICI.Length; x++)
            {
                if (arrayICI[x].FormatDescription.Equals("JPEG"))
                {
                    jpegICI = arrayICI[x];
                    break;
                }
            }

            MemoryStream mem = new MemoryStream();
            resizedImage.Save(mem, jpegICI, encoderParams);

            /* SAVE THE IMAGE TO THE DATABASE AS A BINARY BYTE ARRAY */
            return mem.ToArray();

            // do database INSERT operations into DB field of type IMAGE here
            mem.Close();
            g.Dispose();
        }



        private static Bitmap ResizeSubmittedImage(Bitmap bmpIn)
        {

            // re-size a submitted image while maintaining its aspect ratio
            Bitmap bmpOut = null;
            int newHeight = 0;
            int newWidth = 0;
            const int fixedWidth = 300;
            const int fixedHeight = 300;
            decimal ratio;

            //This code is commentted beause small width images are resized to height=200, and width in ratio of 200 to origional height.
            // if the image is too small, then just use it as is
            if (bmpIn.Height > fixedHeight)
            {
                ratio = (decimal)fixedHeight / bmpIn.Height;
                newWidth = Convert.ToInt32(ratio * bmpIn.Width);
                newHeight = fixedHeight;
            }
            else
            {
                newHeight = bmpIn.Height;
                newWidth = bmpIn.Width;
            }

            bmpOut = new Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(bmpOut);
            g.FillRectangle(Brushes.White, 0, 0, newWidth, newHeight);
            g.DrawImage(bmpIn, 0, 0, newWidth, newHeight);
            bmpIn.Dispose();
            return bmpOut;

        }
    }
}
