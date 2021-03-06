﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace SummitShopApp.Utility
{
    public class Constants
    {
        public const String DownLoadFilePath = "DownLoadFiles";
        public const String ExceptionPolicy = "Exception Policy";
        public const String COOKIE_USERID = "SessionInfo1";
        public const String REMEMBER_ME = "Remember Me on this computer";
        public const String LOGIN_FAILED = "Invalid login or password";
        public const String SAVE_SUCCESS = "Data Saved";
        public const String SEND_EMAIL_SUCCESS = "Emails Send Successfully.";
        public const String SEND_MESSAGES_SUCCESS = "Messages Send Successfully.";
        public const String SEND_MESSAGE_SUCCESS = "Message Send Successfully.";
        public const String SAVE_FAILED = "Data could not be saved";
        public const String DATA_IMPORT_SUCCESS = "Data Imported Successfully";
        public const String DATA_IMPORT_FAIL = "Data could not be imported";
        public const String DELETE_MESSAGES = "Are you sure you want to delete these messages?";
        public const String DELETE_USERS = "Are you sure you want to delete these users?";
        public const String DELETE_CUSTOMERS = "Are you sure you want to delete these customers?";
        public const String PURCHASE_MORE = "You don't have sufficient SMS to send. Do you want to <a class='hyperlink' href='ConfirmDetails.aspx'>Purchase more</a>";
        public const String SUCCESS = "Success";
        public const String CONFIRM = "Confirm";
        public const String ERROR = "Error";
        public const String SELECT_MESSAGES = "Please select the messages first.";
        public const String SELECT_USERS = "Please select the users first.";
        public const String SELECT_CUSTOMERS = "Please select the customers first.";
        public const Int32 SMS = 1;
        public const Int32 Email = 2;
        public const Int32 PredefinedSMS = 3;
        public const Int32 AccidentReport = 4;
        public const Int32 REQUEST_APPOINTMENT = 7;
        public const Int32 COMMUNICATIONLIST = 1;
        public const Int32 OPPORTUNITYLIST = 2;
        public const String ACIIDENTREPORTIMAGE = "AccidentReportImages";
        public const String MOBILE_LIST_NAME = "New list";
        public const String MOBILE_MESSAGE_NAME = "New_Message";
        public const String ERROR_LIST_EXISTS = "Mailing list already exists!";
        public const Int32 CONTACT_METHOD_MAIL = 3;
        public const Int32 CONTACT_METHOD_PHONE = 2;
        public const String ERROR_MESSAGE_EXISTS = "Message with this name already exists in this";
        public const String URI_SCHEME = "https";
        public const String URI_HOST = "www.graphicmail.com";
        public const String URI_PATH = "/api.aspx";
        public const String USERNAME = "prashant_nirdhar0123@yahoo.co.in";
        public const String PASSWORD = "prashanthn";
        public const String API_FUNCTION_GETMOBILEMESSAGE = "get_mobile_messages";
        public const String API_FUNCTION_GETMOBILELIST = "get_mobilelist";
        public const String MARKETING = "Marketing";
        public const String INPROCESS = "InProcess";
        public const String ENTER_MESSAGE = "Please enter message body.";
        public const Int32 SUPERADMIN = 1;
        public const Int32 ADMIN = 2;
        public const Int32 OWNER = 3;
        //TODO: uncomment before live
        //public const String SHOPAPP_PATH_IMAGES = "C:\\Summit\\DigitalPromoRelease1\\ShopApplication\\SummitShopApp\\AccidentReportImages";
        //public const String SHOPAPP_PATH_IMAGES = "D:\\Summit\\ShopApplication\\ShopApplication\\SummitShopApp\\AccidentReportImages";
        public const String SHOPAPP_PATH_IMAGES = "D:\\Mitchell\\MitchellShopApplication_NewURL\\SummitShopApp\\AccidentReportImages";
        public const String REGISTRATIONMESSAGE = "This customer matches your zip code preference.";
        public const String PREFFEREDSHOPMESSAGE = "This customer has selected you as preferred shop.";
        public const Int32 REGISTRATIONMESSAGTYPE = 5;
        public const String QUERYSTRING_PRIVATELABELSHOPID = "PrivateLabelShopId";
        public const String EMSFolderPath = @"Images\UploadedFile\EMS\";
        //public const String ImageFolderPath = "D:\\Summit\\ShopApplication\\ShopApplication\\SummitShopApp\\";
        public const String ImageFolderPath = "D:\\Mitchell\\MitchellShopApplication_NewURL\\SummitShopApp\\";
        public const String AUTOIMPORTERLOG_FILEPATH = "c:\\AutoImporterLog.txt";
        #region CYDNY SMS
        public const String ENDPOINT_CONFIGURATION_NAME = "sms2wsHttpBinding"; //.NET Framework 3.5+
        //public const String ENDPOINT_CONFIGURATION_NAME = "sms2SOAPbasicHttpBinding"; //.NET Framework 3.5
        //public const String CDYNE_LICENSE_KEY = "BEB5CC70-14AA-4969-B65C-0C1B94C1270A"; //trial license key
        //public const String CDYNE_LICENSE_KEY = "00000000-0000-0000-0000-000000000000"; //test license key
        public const String CDYNE_LICENSE_KEY = "ea8f3f8c-3660-485e-ab15-0d71135d6ea1"; //Live license key
        public const String CDYNE_SMS_ERROR_RETURNS = "NoError"; // Return 'NoError' if sms successfully sent
        public const String CDYNE_SMS_INTERNATIONAL_CODE = "1"; // code for international sms other that US & CANADA
        //This URL for Live
        //public const String SMS_POSTBACKURL = "http://www.helpicrashedmycar.com/SMSDeliveryStatus.aspx"; // Postback url for both DeliveryStatus & Incomming Messages
        //THis URL for Test Server
        public const String SMS_POSTBACKURL = "http://digitalmarketing.mymitchell.com/SMSDeliveryStatus.aspx";
        public const String OPT_OUT_PROCEDURE_MESSAGE = "If you do not wish to receive messages from such shop in future, reply with STOP.";
        //public const String SHOP_APP_PHY_PATH = "D:\\Summit\\ShopApplication\\ShopApplication\\SummitShopApp";
        //public const String SHOP_APP_PHY_PATH = @"D:\Summit\ShopApplication\ShopApplication\SummitShopApp\";
        public const String SHOP_APP_PHY_PATH = @"D:\Mitchell\MitchellShopApplication_NewURL\SummitShopApp\";

        #endregion
        #region Phone Identifiers
        public const Int32 Andriod = 1;
        public const Int32 iPhone = 1;
        public const Int32 Blackberry = 1;
        #endregion

        #region "Page Names"

        public const String LANDING_PAGE = @"~\LandingMenu.aspx";
        public const String LOGIN_PAGE = @"~\Login.aspx";
        public const String PROVIDERS_PAGE = @"~\ThirdPartyProvider.aspx";
        public const String NETWORK_PAGE = @"~\Networks.aspx";
        public const String VEHICLE_PAGE = @"~\Certifications.aspx";
        public const String COMMUNICATION_PAGE = @"~\CommunicationList.aspx";
        public const String OPPORTUNITY_PAGE = @"~\OpportunityList.aspx";
        public const String REPAIRPROSPECT_PAGE = @"~\RepairProspects.aspx";
        public const String INPROCESS_PAGE = @"~\InProcessCustomer.aspx";
        public const String EMAILMARKETING_PAGE = @"~\EmailMarketingCenter.aspx";
        public const String TEXTMARKETING_PAGE = @"~\TextMarketingCenter.aspx";
        public const String REVIWRATING_PAGE = @"~\CustomerReviewNRating.aspx";
        public const String MARKETSETTING_PAGE = @"~\RepairPlaceSettings.aspx";
        public const String COMPANYINFO_PAGE = @"~\CompanyInfoSetting.aspx";
        public const String SHOPSETTING_PAGE = @"~\ShopWebsiteSetting.aspx";
        public const String VEHICLESETTING_PAGE = @"~\VehicleStatusSetting.aspx";
        public const String ZIPCODESETTING_PAGE = @"~\ZipCodeConfiguration.aspx";
        public const String LICENCE_EXPIRED = @"~\LicenceExpired.aspx";
        public const String ADMIN_LANDING = @"~\AdminLanding.aspx";

        #endregion "Page Names"

        #region Javascript function constant

        public const String ChangeAllGridCheckBoxState = "changeAllGridCheckBoxState";
        public const String IMPORTED_ESTIMATE = "Imported Estimate";
        public const String BR = "<br />";
        public const String UNSOLD_ESTIMATE = "Unsold Estimate";
        public const String DELIVERED = "Delivered";
        public const String INPROCESS_REPAIR = "In Process";
        #endregion

        #region Import API Data
        public const String ERROR_FIRSTNAME = "Error: First Name is Required and Should be less than 50 characteres";
        public const String ERROR_LASTNAME = "Error: Last Name is Required and Should be less than 50 characteres";
        public const String ERROR_YEAR = "Error: Invalid Year";
        public const String ERROR_MAKE = "Error: Make is Required and Should be less than 50 characteres";
        public const String ERROR_MODEL = "Error: Model is Required and Should be less than 50 characteres";
        public const String ERROR_PHONE = "Error: Invalid Mobile Number";
        public const String ERROR_EMAIL = "Error: Invalid Email";
        public const String ERROR_CREDENTIALS = "Error: Invalid Credentials";
        public const String ERROR_NOBODYSHOP_FOUND = "Error: Cant Find Body Shop for current user";
        public const String INVALID = "Error: Please enter valid";
        public const String VALID_DATE_FORMAT = ", In MM/DD/YYYY format";
        public const String IMPORTSTATUS_FILEPATH = "c:\\ImportStatus.txt";
        public const String April6_AUTOIMPORTERLOG_FILEPATH = "d:\\DemandEngine\\LogDataCommunication\\AutoImporterLog_April6.txt";
        public const String INSERTING_DATA = "Inserting Data into appropriate tables for ShopID:";
        public const String IMPORTDATA_CALLED = "ImportData Called for User:";
        public const String SAVING_DATA = "Saving data for ShopID:";
        public const String MUST_BE_INRANGE = "must be less than 50 characters";



        public const String VEHICLE_STATUS_DELIVERED = "Delivered";

        public const string FILEPATH_STRING_DATE = "D:\\Summit\\DataCommunication\\SummitShopApp\\log_dates.txt";
        #endregion
        public const string Key_NewAILogicShops = "NewAILogicShops";
        public const Char CHAR_Quomma = ',';
        public const String STRING_STATUS_INVOICED = "invoiced";
    }
}
