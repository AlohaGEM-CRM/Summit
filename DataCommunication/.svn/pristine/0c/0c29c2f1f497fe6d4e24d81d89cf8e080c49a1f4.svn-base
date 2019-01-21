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
    public partial class InsuranceInformation : System.Web.UI.Page
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
                if(!String.IsNullOrEmpty(strPhoneId))
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
                    if(objUser!=null)
                    {
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
                        //    objUser.strFirstName = strUserName;
                            objUser.Save();
                        //}
                        
                        InsuranceInformationBL objInsuranceInformation = InsuranceInformationBL.getDataByUserId(objUser.ID);
                        if (objInsuranceInformation != null)
                        {
                            objInsuranceInformation.iUserId = objUser.ID;
                            
                            if (Request.QueryString["AgentName"] != null)
                                objInsuranceInformation.strAgentName = Request.QueryString["AgentName"].ToString();
                            else if (Request.Form["AgentName"] != null)
                                objInsuranceInformation.strAgentName = Request.Form["AgentName"].ToString();

                            if (Request.QueryString["AgentPhone"] != null)
                                objInsuranceInformation.strAgentPhone = Request.QueryString["AgentPhone"].ToString();
                            else if (Request.Form["AgentPhone"] != null)
                                objInsuranceInformation.strAgentPhone = Request.Form["AgentPhone"].ToString();

                            if (Request.QueryString["AgentCellPhone"] != null)
                                objInsuranceInformation.strAgentCellPhone = Request.QueryString["AgentCellPhone"].ToString();
                            else if (Request.Form["AgentCellPhone"] != null)
                                objInsuranceInformation.strAgentCellPhone = Request.Form["AgentCellPhone"].ToString();

                            if (Request.QueryString["AgentWebSite"] != null)
                                objInsuranceInformation.strAgentWebSite = Request.QueryString["AgentWebSite"].ToString();
                            else if (Request.Form["AgentWebSite"] != null)
                                objInsuranceInformation.strAgentWebSite = Request.Form["AgentWebSite"].ToString();

                            if (Request.QueryString["CompanyName"] != null)
                                objInsuranceInformation.strCompanyName = Request.QueryString["CompanyName"].ToString();
                            else if (Request.Form["CompanyName"] != null)
                                objInsuranceInformation.strCompanyName = Request.Form["CompanyName"].ToString();

                            if (Request.QueryString["CompanyEmail"] != null)
                                objInsuranceInformation.strCompanyEmail = Request.QueryString["CompanyEmail"].ToString();
                            else if (Request.Form["CompanyEmail"] != null)
                                objInsuranceInformation.strCompanyEmail = Request.Form["CompanyEmail"].ToString();

                            if (Request.QueryString["CompanyCellPhone"] != null)
                                objInsuranceInformation.strCompanyCellPhone = Request.QueryString["CompanyCellPhone"].ToString();
                            else if (Request.Form["CompanyCellPhone"] != null)
                                objInsuranceInformation.strCompanyCellPhone = Request.Form["CompanyCellPhone"].ToString();

                            if (Request.QueryString["CompanyWebSite"] != null)
                                objInsuranceInformation.strCompanyWebSite = Request.QueryString["CompanyWebSite"].ToString();
                            else if (Request.Form["CompanyWebSite"] != null)
                                objInsuranceInformation.strCompanyWebSite = Request.Form["CompanyWebSite"].ToString();

                            if (Request.QueryString["PolicyNo"] != null)
                                objInsuranceInformation.strPolicyNo = Request.QueryString["PolicyNo"].ToString();
                            else if (Request.Form["PolicyNo"] != null)
                                objInsuranceInformation.strPolicyNo = Request.Form["PolicyNo"].ToString();

                            if (Request.QueryString["AgentEmail"] != null)
                                objInsuranceInformation.strAgentEmail = Request.QueryString["AgentEmail"].ToString();
                            else if (Request.Form["AgentEmail"] != null)
                                objInsuranceInformation.strAgentEmail = Request.Form["AgentEmail"].ToString();

                            DateTime objDateTime;
                            if (Request.QueryString["ExpirationDate"] != null)
                                objInsuranceInformation.dtExpirationDate = DateTime.TryParse(Request.QueryString["ExpirationDate"].ToString(),out objDateTime)?objDateTime:DateTime.Now;
                            else if (Request.Form["ExpirationDate"] != null)
                                objInsuranceInformation.dtExpirationDate = DateTime.TryParse(Request.Form["ExpirationDate"].ToString(), out objDateTime) ? objDateTime : DateTime.Now;
                        }
                        else
                        {
                            objInsuranceInformation = new InsuranceInformationBL();
                            objInsuranceInformation.iUserId = objUser.ID;
                            
                            if (Request.QueryString["AgentName"] != null)
                                objInsuranceInformation.strAgentName = Request.QueryString["AgentName"].ToString();
                            else if (Request.Form["AgentName"] != null)
                                objInsuranceInformation.strAgentName = Request.Form["AgentName"].ToString();

                            if (Request.QueryString["AgentPhone"] != null)
                                objInsuranceInformation.strAgentPhone = Request.QueryString["AgentPhone"].ToString();
                            else if (Request.Form["AgentPhone"] != null)
                                objInsuranceInformation.strAgentPhone = Request.Form["AgentPhone"].ToString();

                            if (Request.QueryString["AgentCellPhone"] != null)
                                objInsuranceInformation.strAgentCellPhone = Request.QueryString["AgentCellPhone"].ToString();
                            else if (Request.Form["AgentCellPhone"] != null)
                                objInsuranceInformation.strAgentCellPhone = Request.Form["AgentCellPhone"].ToString();

                            if (Request.QueryString["AgentWebSite"] != null)
                                objInsuranceInformation.strAgentWebSite = Request.QueryString["AgentWebSite"].ToString();
                            else if (Request.Form["AgentWebSite"] != null)
                                objInsuranceInformation.strAgentWebSite = Request.Form["AgentWebSite"].ToString();

                            if (Request.QueryString["CompanyName"] != null)
                                objInsuranceInformation.strCompanyName = Request.QueryString["CompanyName"].ToString();
                            else if (Request.Form["CompanyName"] != null)
                                objInsuranceInformation.strCompanyName = Request.Form["CompanyName"].ToString();

                            if (Request.QueryString["CompanyEmail"] != null)
                                objInsuranceInformation.strCompanyEmail = Request.QueryString["CompanyEmail"].ToString();
                            else if (Request.Form["CompanyEmail"] != null)
                                objInsuranceInformation.strCompanyEmail = Request.Form["CompanyEmail"].ToString();

                            if (Request.QueryString["CompanyCellPhone"] != null)
                                objInsuranceInformation.strCompanyCellPhone = Request.QueryString["CompanyCellPhone"].ToString();
                            else if (Request.Form["CompanyCellPhone"] != null)
                                objInsuranceInformation.strCompanyCellPhone = Request.Form["CompanyCellPhone"].ToString();

                            if (Request.QueryString["CompanyWebSite"] != null)
                                objInsuranceInformation.strCompanyWebSite = Request.QueryString["CompanyWebSite"].ToString();
                            else if (Request.Form["CompanyWebSite"] != null)
                                objInsuranceInformation.strCompanyWebSite = Request.Form["CompanyWebSite"].ToString();

                            if (Request.QueryString["PolicyNo"] != null)
                                objInsuranceInformation.strPolicyNo = Request.QueryString["PolicyNo"].ToString();
                            else if (Request.Form["PolicyNo"] != null)
                                objInsuranceInformation.strPolicyNo = Request.Form["PolicyNo"].ToString();

                            if (Request.QueryString["AgentEmail"] != null)
                                objInsuranceInformation.strAgentEmail = Request.QueryString["AgentEmail"].ToString();
                            else if (Request.Form["AgentEmail"] != null)
                                objInsuranceInformation.strAgentEmail = Request.Form["AgentEmail"].ToString();

                            DateTime objDateTime;
                            if (Request.QueryString["ExpirationDate"] != null)
                                objInsuranceInformation.dtExpirationDate = DateTime.TryParse(Request.QueryString["ExpirationDate"].ToString(), out objDateTime) ? objDateTime : DateTime.Now;
                            else if (Request.Form["ExpirationDate"] != null)
                                objInsuranceInformation.dtExpirationDate = DateTime.TryParse(Request.Form["ExpirationDate"].ToString(), out objDateTime) ? objDateTime : DateTime.Now;
                        }
                        if (objInsuranceInformation.Save())
                        {
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
            xmlWriter.WriteStartElement("InsuranceInformation");
            xmlWriter.WriteElementString("Status", bResult?"Success":"Fail");
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
