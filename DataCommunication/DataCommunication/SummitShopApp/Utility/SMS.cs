using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.IO;
using System.Xml;
using System.Configuration;
using SummitShopApp.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using SummitShopApp.BL;

namespace SummitShopApp.Utility
{
    public class SMS
    {
        #region Member Variables

        private String m_strListName = String.Empty;
        private String m_strListID = String.Empty;
        private String m_strMessageBody = String.Empty;
        private static String m_strMessageName = String.Empty;
        private static Random _random = new Random();

        private String m_strMessageID = String.Empty;

        #endregion Member Variables

        #region Properties

        public String strListName
        {
            get
            {
                return m_strListName;
            }

            set
            {
                m_strListName = value;
            }
        }

        public String strListID
        {
            get
            {
                return m_strListID;
            }
            set
            {
                m_strListID = value;
            }
        }

        public String strMessageBody
        {
            get
            {
                return m_strMessageBody;
            }
            set
            {
                m_strMessageBody = value;
            }
        }

        public String strMessageName
        {
            get
            {
                return m_strMessageName;
            }
            set
            {
                m_strMessageName = value;
            }

        }

        #endregion Properties

        #region Member Functions

        // This Method is used to send SMS from Cdyne Gateway. 
        private Boolean SendSMSFromCdyne(String strMobileNumber, String strMessageBody)
        {
            try
            {
                strMobileNumber = strMobileNumber.Replace("-", String.Empty);
                strMobileNumber = strMobileNumber.Replace("(", string.Empty);
                strMobileNumber = strMobileNumber.Replace(")", string.Empty);
                strMobileNumber = strMobileNumber.Replace(" ", string.Empty);
            }
            catch (Exception ex)
            { }

            try
            {
                CdyneSmsService.IsmsClient client = new CdyneSmsService.IsmsClient(Constants.ENDPOINT_CONFIGURATION_NAME);
                CdyneSmsService.SMSResponse resp = client.SimpleSMSsendWithPostback(Constants.CDYNE_SMS_INTERNATIONAL_CODE + strMobileNumber, strMessageBody, new Guid(Constants.CDYNE_LICENSE_KEY.ToString()), Constants.SMS_POSTBACKURL.ToString());
                m_strMessageID = resp.MessageID.ToString();
                client.Close();

                //check response if it is 'NoError' then message submitted successfully
                if (resp.SMSError.ToString() == Constants.CDYNE_SMS_ERROR_RETURNS)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
                return false;
            }
        }

        public Boolean SendSMS(String strMobileNumber, String strMessageBody, String strFrom, Int32 iToUserId)
        {
            try
            {
                StringBuilder sbMessage = new StringBuilder();
                sbMessage.Append("From ");
                if (strFrom.Length > 20)
                {
                    sbMessage.Append(strFrom.Remove(20));
                }
                else
                {
                    sbMessage.Append(strFrom);
                }

                strMessageBody = sbMessage.ToString() + ": " + strMessageBody;

                /////////// Call Method to send SMS from cdyne sms gateway ////////////////////

                if (this.SendSMSFromCdyne(strMobileNumber, strMessageBody))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
                return false;
            }
        }


        //This method is use to send sms from admin user
        public Boolean SendSMS(String strMobileNumber, String strMessageBody, Int32 iToUserId, FromAppSection eFromSection, Int32 iShopId)
        {

            Boolean bSent = false;

            //Check available message of shop
            BodyShopBL objBodyShop = BodyShopBL.getShopById(iShopId);
            if ((objBodyShop == null && objBodyShop.iAvailableMessages == null) || (objBodyShop.iAvailableMessages - (objBodyShop.iMessageCount == null ? 0 : objBodyShop.iMessageCount) <= 0))
                return false;

            //System.Threading.Thread.Sleep(10000);

            if (SendSMS(strMobileNumber, strMessageBody, objBodyShop.strShopName, iToUserId))
            {
                bSent = true;

                //Update body Shop message count
                if (objBodyShop.iMessageCount == null)
                    objBodyShop.iMessageCount = 1;
                else
                    objBodyShop.iMessageCount += 1;

                CommunicationHistoryBL objComHistory = new CommunicationHistoryBL();
                objComHistory.iUserId = iToUserId;
                objComHistory.iShopId = iShopId;
                objComHistory.iCommunicationTypeId = 1;
                objComHistory.dtCreatedDate = DateTime.Now;
                objComHistory.strMessageText = strMessageBody;
                objComHistory.strPhone = strMobileNumber;
                objComHistory.iFromAppSection = (Int32)eFromSection;
                objComHistory.strMessageId = m_strMessageID;
                objComHistory.strDeliveryStatus = "PENDING";
                objComHistory.Save();

            }
            //This code will make entry into "C:\\MessagingList.csv" file for all sms whether sent or not.
            try
            {
                StreamWriter sw = new StreamWriter("C:\\MessagingList.csv", true);
                sw.Write(DateTime.Now.ToString() + ",");
                sw.Write(strMobileNumber + ",");
                sw.Write(strMessageBody + ",");
                sw.Write(SessionInfo.UserShop.id.ToString() + ",");
                sw.Write(m_strMessageID + ",");
                sw.WriteLine();
                sw.Dispose();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
                return false;

            }


            // To send Opt out Notification for first time only
            if (bSent)
            {
                String subStringMobile = String.Empty;
                if (strMobileNumber.Length >= 10)
                    subStringMobile = strMobileNumber.Substring(strMobileNumber.Length - 10, 10);

                int count = UserBL.getDataByUserPhoneAndNotificationSent(subStringMobile);
                if (count == 0)
                {
                    if (SendSMS(strMobileNumber, Constants.OPT_OUT_PROCEDURE_MESSAGE, objBodyShop.strShopName, iToUserId))
                    {
                        UserBL.UpdateUsersOnOptOutNotificationSent(subStringMobile);

                        bSent = true;


                        //Update body Shop message count
                        if (objBodyShop.iMessageCount == null)
                            objBodyShop.iMessageCount = 1;
                        else
                            objBodyShop.iMessageCount += 1;


                        CommunicationHistoryBL objComHistory = new CommunicationHistoryBL();
                        objComHistory.iUserId = iToUserId;
                        objComHistory.iShopId = iShopId;
                        objComHistory.iCommunicationTypeId = 1;
                        objComHistory.dtCreatedDate = DateTime.Now;
                        objComHistory.strMessageText = Constants.OPT_OUT_PROCEDURE_MESSAGE;
                        objComHistory.strPhone = strMobileNumber;
                        objComHistory.iFromAppSection = (Int32)eFromSection;
                        objComHistory.strMessageId = m_strMessageID;
                        objComHistory.strDeliveryStatus = "PENDING";
                        objComHistory.Save();

                    }
                }
            }

            if (objBodyShop != null)
            {
                objBodyShop.Save();
            }

            return bSent;
        }


        #endregion
    }
}
