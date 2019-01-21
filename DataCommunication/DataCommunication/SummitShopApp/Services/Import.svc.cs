using System;
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
using System.Collections.Generic;
using SummitShopApp.BL;
using SummitShopApp.Utility;
using System.ServiceModel;


namespace SummitShopApp.Services
{
    // NOTE: If you change the class name "Import" here, you must also update the reference to "Import" in Web.config.
    public class Import : IImport
    {
        /// <summary>
        /// Validate User and get ShopId for that user
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strPassword"></param>
        /// <param name="iShopId"></param>
        /// <returns></returns>
        public Boolean ValidateUser(String strUserName, String strPassword, out Int32 iShopId)
        {
            iShopId = 0;
            LoginBL thisUser = LoginBL.getByUserName(strUserName);
            BodyShopBL objBodyShop = null;
            strPassword = Security.encode(strPassword);
            if (thisUser != null)
            {
                if (Security.decode(thisUser.strPassword) == Security.decode(strPassword))
                {
                    if (thisUser.iRoleID == Constants.OWNER)
                    {
                        objBodyShop = BodyShopBL.getShopById(Convert.ToInt32(thisUser.iShopID));
                        if (objBodyShop != null)
                        {
                            iShopId = objBodyShop.ID;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Use this method to Import your data in Shop Application,
        /// Below are the required fields,
        /// Name, Year, Make, Model, Mobile, Email
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strPassword"></param>
        /// <param name="objImportData"></param>
        /// <returns></returns>
        public String ImportData(String strUserName, String strPassword, ImportData objImportData)
        {
            SummitShopApp.Utility.CommonFunctions.LoggingForImportStatus(Constants.IMPORTDATA_CALLED + strUserName);
            Int32 iShopId = 0;
            if (ValidateUser(strUserName, strPassword, out iShopId))
            {
                BodyShopBL objBodyShopBL = BodyShopBL.getShopById(iShopId);
                if (objBodyShopBL != null && objImportData != null)
                {
                    String ErrorCode = String.Empty;
                    ErrorCode = ValidateData(objImportData);
                    //Add values in particular table
                    if (!ErrorCode.Contains(Constants.ERROR))
                    {
                        SaveData(Convert.ToString(iShopId), objImportData);
                        return Constants.SUCCESS;
                    }
                    else
                    {
                        throw new FaultException(ErrorCode);
                    }
                }
                throw new FaultException(Constants.ERROR_NOBODYSHOP_FOUND);
            }
            return Constants.ERROR_CREDENTIALS;
        }
        public void SaveData(String strShopId, ImportData objImportData)
        {
            SummitShopApp.Utility.CommonFunctions.LoggingForImportStatus(Constants.SAVING_DATA + strShopId);
            Boolean bIsDuplicate = false;
            Boolean bUpdateData = false;
            //Get inprocess customers
            System.Collections.Generic.List<InProcessUsersBL> lstInProcessUsers = InProcessUsersBL.getCustomersList(Convert.ToInt32(strShopId));

            //Get deleted customers from inprocess
            System.Collections.Generic.List<InProcessUsersBL> lstDeletedInProcessUsers = InProcessUsersBL.GetDeletedUsers(Convert.ToInt32(strShopId));

            InProcessUsersBL objInProcessUser = null;
            if (objImportData != null && lstInProcessUsers != null)
            {
                //Check in Inprocess users
                objInProcessUser = getInprocessObject(lstInProcessUsers, objImportData, out bUpdateData);
            }
            if (!bUpdateData)
            {
                //Check in Delete users
                objInProcessUser = getInprocessObject(lstDeletedInProcessUsers, objImportData, out bUpdateData);

                if (objInProcessUser == null)
                {
                    UserBL objUser = new UserBL();
                    objUser.strUserName = objImportData.strUserName;
                    objUser.strFirstName = objImportData.First_Name;
                    objUser.strLastName = objImportData.Last_Name;
                    objUser.strPhone = objImportData.Mobile;
                    objUser.strPhone2 = objImportData.Mobile;
                    objUser.strEmail = objImportData.Email;
                    objUser.strAddress1 = objImportData.Address;
                    objUser.strAddress2 = objImportData.Address;
                    objUser.strCity = objImportData.City;
                    objUser.strState = objImportData.State;
                    objUser.strZip = objImportData.Zip;
                    objUser.dtUpdatedEntryTime = DateTime.Now;
                    if (objUser.Save())
                    {
                        InsertData(strShopId, objImportData, objUser);
                    }
                }
            }
            #region Update Sync data
            //If file is already imported and matched with unique file idetifier then update data
            if (bUpdateData && objInProcessUser != null)
            {
                updateEMSData(objInProcessUser, objImportData);
            }
            #endregion

        }

        private InProcessUsersBL getInprocessObject(List<InProcessUsersBL> lstInProcessUsers, ImportData objImportData, out Boolean bUpdateData)
        {
            Boolean bIsDuplicate = false;
            foreach (InProcessUsersBL objInProcessObject in lstInProcessUsers)
            {

                //for older file that has been imported and don't have unique file identifier then check for name,year,make,model and mobile #
                if (String.IsNullOrEmpty(objInProcessObject.strEstimateFileIdentifier))
                {
                    bIsDuplicate = (!string.IsNullOrEmpty(objInProcessObject.strUserName) && !string.IsNullOrEmpty(objImportData.strUserName) && objInProcessObject.strUserName.ToLower().Trim() == objImportData.strUserName.ToLower().Trim() && objInProcessObject.strYear != null && objImportData.Year != null && objImportData.Year.ToLower().Trim() == objInProcessObject.strYear.ToLower().Trim() && objInProcessObject.strMake != null && objImportData.Make != null && objInProcessObject.strMake.ToLower().Trim() == objImportData.Make.ToLower().Trim() && objInProcessObject.strModel != null && objImportData.Model != null && objInProcessObject.strModel.ToLower().Trim() == objImportData.Model.ToLower().Trim() && objInProcessObject.strPhone != null && objImportData.Mobile != null && objInProcessObject.strPhone.ToLower().Trim() == objImportData.Mobile.ToLower().Trim());
                }
                if (bIsDuplicate)
                {
                    bUpdateData = true;
                    return objInProcessObject;
                }

            }
            bUpdateData = false;
            return null;
        }

        /// <summary>
        /// Insert data in appropriate tables
        /// </summary>
        /// <param name="strShopId"></param>
        /// <param name="objImportData"></param>
        /// <param name="objUser"></param>
        public void InsertData(String strShopId, ImportData objImportData, UserBL objUser)
        {
            SummitShopApp.Utility.CommonFunctions.LoggingForImportStatus(Constants.INSERTING_DATA + strShopId);
            VehicleInfoBL objVehicleInfo = new VehicleInfoBL();
            //Add values to Vehicle Info
            objVehicleInfo = SaveVehicleinfo(objVehicleInfo, objImportData, objUser);
            //Save MArketing User 
            SaveMarketingUser(objVehicleInfo, objUser, strShopId);

            //Save Vehicle Status Information
            SaveVehicleStatus(objVehicleInfo, objImportData, objUser, strShopId);
            //Save Insurance Info
            SaveInsuranceInfo(objImportData, objUser);
        }

        public VehicleInfoBL SaveVehicleinfo(VehicleInfoBL objVehicleInfo, ImportData objImportData, UserBL objUser)
        {
            objVehicleInfo.iUserId = objUser.ID;
            objVehicleInfo.strYear = objImportData.Year;
            objVehicleInfo.strMake = objImportData.Make;
            objVehicleInfo.strModel = objImportData.Model;
            objVehicleInfo.strStyle = objImportData.Style;
            objVehicleInfo.strColor = objImportData.Color;
            objVehicleInfo.strPaintCode = objImportData.Paint_Code;
            objVehicleInfo.strVIN = objImportData.VIN;
            objVehicleInfo.strEstimatorName = objImportData.EstimatorName.Trim();
            objVehicleInfo.strLicense = objImportData.License;
            DateTime dtProductionDate;
            objVehicleInfo.dtProductionDate = DateTime.TryParse("", out dtProductionDate) ? dtProductionDate : (Nullable<DateTime>)null;
            objVehicleInfo.bIsUsing = true;
            objVehicleInfo.Save();
            return objVehicleInfo;
        }

        public void SaveMarketingUser(VehicleInfoBL objVehicleInfo, UserBL objUser, String strShopId)
        {
            MarketingUsers objMarUser = new MarketingUsers();
            objMarUser.iShopId = Convert.ToInt32(strShopId);
            objMarUser.iUserId = objUser.ID;
            objMarUser.iVehicleId = objVehicleInfo.ID;
            objMarUser.bisShowInProcess = true;
            objMarUser.iVehicleId = objVehicleInfo.ID;
            objMarUser.Save();
        }

        public void SaveVehicleStatus(VehicleInfoBL objVehicleInfo, ImportData objImportData, UserBL objUser, String strShopId)
        {
            String strStatus = String.Empty;
            VehicleStatusBL objTemp = null;
            Boolean bIsStatusChanged = false;
            int iVehicleStatusId = 0;
            UserVehicleStatusBL objCustomerVehicleStatus = new UserVehicleStatusBL();
            DateTime dtOut;
            objCustomerVehicleStatus.iUserId = objUser.ID;
            objCustomerVehicleStatus.iVehicleId = objVehicleInfo.ID;
            objCustomerVehicleStatus.dtDateIn = DateTime.TryParse(objImportData.Scheduled_In_Date, out dtOut) ? dtOut : (Nullable<DateTime>)null;
            objCustomerVehicleStatus.dtDateOut = DateTime.TryParse(objImportData.Target_Delivery_Date, out dtOut) ? dtOut : (Nullable<DateTime>)null;
            objCustomerVehicleStatus.dtActual_Delivery_Date = DateTime.TryParse(objImportData.Actual_Delivery_Date, out dtOut) ? dtOut : (Nullable<DateTime>)null;
            objCustomerVehicleStatus.dtFile_Import_Date = DateTime.TryParse(objImportData.File_Import_date, out dtOut) ? dtOut : (Nullable<DateTime>)null;
            objCustomerVehicleStatus.dtFile_Import_Time = DateTime.TryParse(objImportData.File_Import_Time, out dtOut) ? dtOut : (Nullable<DateTime>)null;
            objCustomerVehicleStatus.dtRepair_Start_Date = DateTime.TryParse(objImportData.Repair_Start_Date, out dtOut) ? dtOut : (Nullable<DateTime>)null;
            objCustomerVehicleStatus.dtDeliveryDate = DateTime.TryParse(objImportData.Actual_Delivery_Date, out dtOut) ? dtOut : (Nullable<DateTime>)null;
            objCustomerVehicleStatus.iETA_Hours = Convert.ToInt32(objImportData.ETA_Hours);
            objCustomerVehicleStatus.iRO_Hours = Convert.ToInt32(objImportData.RO_Hours);
            objCustomerVehicleStatus.strFile_Status = objImportData.File_Status;

            System.Collections.Generic.List<SummitShopApp.BL.VehicleStatusBL> lstVehicleStatus = new List<SummitShopApp.BL.VehicleStatusBL>();
            lstVehicleStatus = VehicleStatusBL.getDataByShopId(Convert.ToInt32(strShopId));

            DateTime? dtImportDate = DateTime.TryParse(objImportData.File_Import_date, out dtOut) ? dtOut : (Nullable<DateTime>)null;
            DateTime? dtRepairStartDate = DateTime.TryParse(objImportData.Repair_Start_Date, out dtOut) ? dtOut : (Nullable<DateTime>)null;
            DateTime? dtActualDeliveryDate = DateTime.TryParse(objImportData.Actual_Delivery_Date, out dtOut) ? dtOut : (Nullable<DateTime>)null;
            DateTime dtToday = DateTime.Today;

            //Update Vehicle Status depending Matching Date

            if (dtToday.Date.Equals(dtImportDate))
            {
                strStatus = Constants.IMPORTED_ESTIMATE;
                bIsStatusChanged = true;
            }
            if (dtToday.Date.Equals(dtRepairStartDate))
            {
                strStatus = Constants.INPROCESS_REPAIR;
                bIsStatusChanged = true;
            }
            if (dtToday.Date.Equals(dtActualDeliveryDate))
            {
                strStatus = Constants.DELIVERED;
                bIsStatusChanged = true;
            }

            if (!bIsStatusChanged)
            {
                strStatus = Constants.UNSOLD_ESTIMATE;
            }

            if (lstVehicleStatus.Count > 0)
                objTemp = lstVehicleStatus.Find(vs => vs.strVehicleStatus == strStatus);
            if (objTemp != null)
            {
                objTemp = lstVehicleStatus.Find(vs => vs.strVehicleStatus == strStatus);
                iVehicleStatusId = objTemp.ID;
                objCustomerVehicleStatus.iVehicleStatusId = iVehicleStatusId;
                objCustomerVehicleStatus.dtLastUpdatedStatusDate = DateTime.Now;
                if (String.Equals(strStatus, Constants.DELIVERED))
                {
                    objCustomerVehicleStatus.dtDeliveryDate = DateTime.Now;
                }
                if (strStatus == Constants.UNSOLD_ESTIMATE || strStatus == Constants.DELIVERED)
                {
                    objUser.bIsShowEmailMarketing = true;
                    objUser.bIsShowTextMarketing = true;
                    objUser.Save();
                    MarketingUsers objMarUser = MarketingUsers.getDataByShopAndUserId(Convert.ToInt32(strShopId), Convert.ToInt32(objUser.ID));
                    if (objMarUser != null)
                    {
                        objMarUser.bisShowInProcess = false;
                        objMarUser.Save();
                    }
                }
            }
            else
            {
                VehicleStatusBL _objVehicleStatus = new VehicleStatusBL();
                _objVehicleStatus.strVehicleStatus = strStatus;
                _objVehicleStatus.strMessage = String.Empty;
                _objVehicleStatus.iShopId = Convert.ToInt32(strShopId);
                _objVehicleStatus.bSMS = false;
                _objVehicleStatus.bIsActive = false;
                _objVehicleStatus.bEmail = false;
                if (_objVehicleStatus.Save())
                {
                    objCustomerVehicleStatus.iVehicleStatusId = _objVehicleStatus.ID;
                    objCustomerVehicleStatus.dtLastUpdatedStatusDate = DateTime.Now;
                }
            }
            objCustomerVehicleStatus.Save();
        }

        public void SaveInsuranceInfo(ImportData objImportData, UserBL objUser)
        {
            InsuranceInformationBL objInsurance = new InsuranceInformationBL();
            objInsurance.iUserId = objUser.ID;
            objInsurance.strCompanyName = objImportData.Insurance_Company;
            objInsurance.strCompanyAddress = objImportData.Insurance_Company_Contact;
            objInsurance.strCompanyCity = objImportData.Insurance_Company_City;
            objInsurance.strCompanyState = objImportData.Insurance_Company_State;
            objInsurance.strCompanyZip = objImportData.Insurance_Company_Zip;
            objInsurance.strCompanyEmail = objImportData.Insurance_Company_Email;
            objInsurance.strCompanyCellPhone = objImportData.Insurance_Company_Contact;
            objInsurance.strCompanyFax = objImportData.Insurance_Company_Fax;
            objInsurance.strAgentName = objImportData.Agent;
            objInsurance.strClaimNumber = objImportData.Claim_Number;
            objInsurance.strROIdentifier = objImportData.RO_Number;
            objInsurance.strNetTotalAmount = objImportData.Total_Amount;
            objInsurance.strTotalROAmount = objImportData.Total_RO_Amount;
            DateTime dtDateofLoss;
            Decimal dDeductible;
            DateTime.TryParse(objInsurance.dtDateOfLoss.ToString(), out dtDateofLoss);
            objInsurance.dtDateOfLoss = DateTime.TryParse(objImportData.Date_Of_Loss, out dtDateofLoss) ? dtDateofLoss : (Nullable<DateTime>)null;
            objInsurance.dDeductible = Decimal.TryParse(objImportData.Deductible, out dDeductible) ? dDeductible : (Nullable<Decimal>)null;
            objInsurance.Save();

        }

        /// <summary>
        /// Validate Data before Import
        /// </summary>
        /// <param name="objImportData"></param>
        /// <returns></returns>
        public String ValidateData(ImportData objImportData)
        {
            String strError = String.Empty;
            if (String.IsNullOrEmpty(objImportData.First_Name) || objImportData.First_Name.Length > 50)
            {
                strError = strError + Constants.ERROR_FIRSTNAME + Constants.BR;
            }
            if (String.IsNullOrEmpty(objImportData.Last_Name) || objImportData.Last_Name.Length > 50)
            {
                strError = strError + Constants.ERROR_LASTNAME + Constants.BR;
            }
            if (String.IsNullOrEmpty(objImportData.Year) || (!String.IsNullOrEmpty(objImportData.Year) && !StringProcessing.StringFunctions.IsNumeric(objImportData.Year.Trim())))
            {
                strError = strError + Constants.ERROR_YEAR + Constants.BR;
            }
            if (String.IsNullOrEmpty(objImportData.Make) || objImportData.Make.Length > 50)
            {
                strError = strError + Constants.ERROR_MAKE + Constants.BR;
            }
            if (String.IsNullOrEmpty(objImportData.Model) || objImportData.Model.Length > 50)
            {
                strError = strError + Constants.ERROR_MODEL + Constants.BR;
            }
            if (String.IsNullOrEmpty(objImportData.Mobile) || (!String.IsNullOrEmpty(objImportData.Mobile) && !(StringProcessing.StringFunctions.IsNumeric(objImportData.Mobile.Trim()) && objImportData.Mobile.Trim().Length == 10)))
            {
                strError = strError + Constants.ERROR_PHONE + Constants.BR;
            }
            if ((!String.IsNullOrEmpty(objImportData.Email) && !StringProcessing.StringFunctions.IsEmailAddress(objImportData.Email)))
            {
                strError = strError + Constants.ERROR_EMAIL + Constants.BR;
            }

            strError = ValidateDates(objImportData, strError);
            strError = ValidateNonRequiredFields(objImportData, strError);

            return strError;
        }

        public String ValidateDates(ImportData objImportData, String strError)
        {
            DateTime dtTemp = DateTime.Now;
            if (!String.IsNullOrEmpty(objImportData.File_Import_date) && !DateTime.TryParse(objImportData.File_Import_date, out dtTemp))
            {
                strError = strError + Constants.INVALID + " File Import Date" + Constants.VALID_DATE_FORMAT;
            }
            if (!String.IsNullOrEmpty(objImportData.Repair_Start_Date) && !DateTime.TryParse(objImportData.Repair_Start_Date, out dtTemp))
            {
                strError = strError + Constants.INVALID + " Repair Start Date" + Constants.VALID_DATE_FORMAT + Constants.BR;
            }
            if (!String.IsNullOrEmpty(objImportData.Scheduled_In_Date) && !DateTime.TryParse(objImportData.Scheduled_In_Date, out dtTemp))
            {
                strError = strError + Constants.INVALID + " Scheduled In Date" + Constants.VALID_DATE_FORMAT + Constants.BR;
            }
            if (!String.IsNullOrEmpty(objImportData.Target_Delivery_Date) && !DateTime.TryParse(objImportData.Target_Delivery_Date, out dtTemp))
            {
                strError = strError + Constants.INVALID + " Target Delivery Date" + Constants.VALID_DATE_FORMAT + Constants.BR;
            }
            if (!String.IsNullOrEmpty(objImportData.Actual_Delivery_Date) && !DateTime.TryParse(objImportData.Actual_Delivery_Date, out dtTemp))
            {
                strError = strError + Constants.INVALID + " Actual Delivery Date" + Constants.VALID_DATE_FORMAT + Constants.BR;
            }
            return strError;
        }

        public String ValidateNonRequiredFields(ImportData objImportData, String strError)
        {

            if (!String.IsNullOrEmpty(objImportData.Claim_Number) && objImportData.Claim_Number.Length > 50)
            {
                strError = strError + Constants.ERROR + ": Claim number " + Constants.MUST_BE_INRANGE + Constants.BR;
            }
            if (!String.IsNullOrEmpty(objImportData.RO_Number) && objImportData.RO_Number.Length > 50)
            {
                strError = strError + Constants.ERROR + ":RO number " + Constants.MUST_BE_INRANGE + Constants.BR;
            }
            if (!String.IsNullOrEmpty(objImportData.Agent_Email) && StringProcessing.StringFunctions.IsEmailAddress(objImportData.Agent_Email.Trim()))
            {
                strError = strError + Constants.INVALID + " Agent Email " + Constants.BR;
            }
            if (!String.IsNullOrEmpty(objImportData.City) && objImportData.City.Length > 50)
            {
                strError = strError + Constants.ERROR + ": City " + Constants.MUST_BE_INRANGE + Constants.BR;
            }
            if (!String.IsNullOrEmpty(objImportData.Color) && objImportData.Color.Length > 50)
            {
                strError = strError + Constants.ERROR + ": Color " + Constants.MUST_BE_INRANGE + Constants.BR;
            }
            if (!String.IsNullOrEmpty(objImportData.Agent) && objImportData.Agent.Length > 50)
            {
                strError = strError + Constants.ERROR + ": Agent name " + Constants.MUST_BE_INRANGE + Constants.BR;
            }
            if (!String.IsNullOrEmpty(objImportData.Insurance_Company) && objImportData.Insurance_Company.Length > 50)
            {
                strError = strError + Constants.ERROR + ": Insurance Company name " + Constants.MUST_BE_INRANGE + Constants.BR;
            }
            if (!String.IsNullOrEmpty(objImportData.Insurance_Company_Address) && objImportData.Insurance_Company_Address.Length > 50)
            {
                strError = strError + Constants.ERROR + ": Insurance Company address must be less than 200 characters " + Constants.BR;
            }
            if (!String.IsNullOrEmpty(objImportData.Insurance_Company_City) && objImportData.Insurance_Company_City.Length > 50)
            {
                strError = strError + Constants.ERROR + ": Insurance Company City " + Constants.MUST_BE_INRANGE + Constants.BR;
            }
            if (!String.IsNullOrEmpty(objImportData.Paint_Code) && objImportData.Paint_Code.Length > 50)
            {
                strError = strError + Constants.ERROR + ": Paint_Code " + Constants.MUST_BE_INRANGE + Constants.BR;
            }
            if (!String.IsNullOrEmpty(objImportData.Style) && objImportData.Style.Length > 50)
            {
                strError = strError + Constants.ERROR + ": Style " + Constants.MUST_BE_INRANGE + Constants.BR;
            }
            if (!String.IsNullOrEmpty(objImportData.Total_Amount) && objImportData.Total_Amount.Length > 50)
            {
                strError = strError + Constants.ERROR + ": Total Amount " + Constants.MUST_BE_INRANGE + Constants.BR;
            }
            if (!String.IsNullOrEmpty(objImportData.Total_RO_Amount) && objImportData.Total_RO_Amount.Length > 50)
            {
                strError = strError + Constants.ERROR + ": Total RO Amount " + Constants.MUST_BE_INRANGE + Constants.BR;
            }
            if (!String.IsNullOrEmpty(objImportData.VIN) && objImportData.VIN.Length > 50)
            {
                strError = strError + Constants.ERROR + ": Vehicle Identification Number " + Constants.MUST_BE_INRANGE + Constants.BR;
            }
            if (!String.IsNullOrEmpty(objImportData.EstimatorName) && objImportData.EstimatorName.Length > 100)
            {
                strError = strError + Constants.ERROR + ": Estimator Name must be less than 100 characters " + Constants.BR;
            }

            Decimal dc;
            if (!String.IsNullOrEmpty(objImportData.Deductible) && !(Decimal.TryParse(objImportData.Deductible.Trim(), out dc) && objImportData.Deductible.Trim().Length < 20))
            {
                strError = strError + Constants.ERROR + ": Deductible must be in decimal format and less than 20 characteres " + Constants.BR;
            }
            return strError;
        }


        /// <summary>
        /// Sync the data from EMS file with data into database, if file was imported before.
        /// </summary>
        /// <param name="objInProcessUser"></param>
        /// <param name="objImportData"></param>
        private void updateEMSData(InProcessUsersBL objInProcessUser, ImportData objImportData)
        {
            try
            {
                if (objInProcessUser.iUserId.HasValue && updateUserData(objInProcessUser.iUserId.Value, objImportData))
                {
                    if (objInProcessUser.iVehicleId.HasValue)
                    {
                        updateVehicleStatus(objInProcessUser.iVehicleId.Value, objInProcessUser.iShopId.Value, objImportData);
                        updateVehicleData(objInProcessUser.iVehicleId.Value, objImportData);
                    }
                    updateInsuranceData(objInProcessUser.iUserId.Value, objImportData);

                }

            }
            catch (Exception ex)
            {
                Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
            }
        }

        /// <summary>
        /// Update user data
        /// </summary>
        /// <param name="iUserId"></param>
        /// <param name="objImportData"></param>
        /// <returns></returns>
        private Boolean updateUserData(Int32 iUserId, ImportData objImportData)
        {
            try
            {
                //Get user object from database using user_id
                UserBL objUser = UserBL.getByActivityId(iUserId);
                if (objUser != null)
                {
                    if (!String.IsNullOrEmpty(objImportData.Mobile))
                        objUser.strPhone = objImportData.Mobile;

                    if (!String.IsNullOrEmpty(objImportData.Email))
                        objUser.strEmail = objImportData.Email;

                    if (!String.IsNullOrEmpty(objImportData.Address))
                        objUser.strAddress1 = objImportData.Address;

                    if (!String.IsNullOrEmpty(objImportData.City))
                        objUser.strCity = objImportData.City;

                    if (!String.IsNullOrEmpty(objImportData.State))
                        objUser.strState = objImportData.State;

                    if (!String.IsNullOrEmpty(objImportData.Zip))
                        objUser.strZip = objImportData.Zip;

                    return objUser.Save();
                }
            }
            catch (Exception ex)
            {
                Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
            }
            return false;
        }

        private Boolean updateVehicleStatus(Int32 iVehicleId, Int32 iShopId, ImportData objImportData)
        {
            try
            {
                UserVehicleStatusBL objCustomerVehicleStatus = UserVehicleStatusBL.getDataByVehicleId(iVehicleId);
                if (objCustomerVehicleStatus != null)
                {
                    DateTime dtOut;
                    objCustomerVehicleStatus.dtDateIn = DateTime.TryParse(objImportData.Scheduled_In_Date, out dtOut) ? dtOut : (Nullable<DateTime>)null;
                    objCustomerVehicleStatus.dtDateOut = DateTime.TryParse(objImportData.Target_Delivery_Date, out dtOut) ? dtOut : (Nullable<DateTime>)null;
                    objCustomerVehicleStatus.dtActual_Delivery_Date = DateTime.TryParse(objImportData.Actual_Delivery_Date, out dtOut) ? dtOut : (Nullable<DateTime>)null;
                    objCustomerVehicleStatus.dtFile_Import_Date = DateTime.TryParse(objImportData.File_Import_date, out dtOut) ? dtOut : (Nullable<DateTime>)null;
                    objCustomerVehicleStatus.dtFile_Import_Time = DateTime.TryParse(objImportData.File_Import_Time, out dtOut) ? dtOut : (Nullable<DateTime>)null;
                    objCustomerVehicleStatus.dtRepair_Start_Date = DateTime.TryParse(objImportData.Repair_Start_Date, out dtOut) ? dtOut : (Nullable<DateTime>)null;
                    objCustomerVehicleStatus.dtDeliveryDate = DateTime.TryParse(objImportData.Actual_Delivery_Date, out dtOut) ? dtOut : (Nullable<DateTime>)null;
                    objCustomerVehicleStatus.iETA_Hours = Convert.ToInt32(objImportData.ETA_Hours);
                    objCustomerVehicleStatus.iRO_Hours = Convert.ToInt32(objImportData.RO_Hours);
                    objCustomerVehicleStatus.strFile_Status = objImportData.File_Status;
                    objCustomerVehicleStatus.Save();


                    //Set Show InProcess true for current vehicle
                    //MarketingUsers objMarUser = MarketingUsers.getDataByShopUserAndVehicleId(iShopId, Convert.ToInt32(objCustomerVehicleStatus.iUserId), iVehicleId);
                    //objMarUser.bisShowInProcess = true;
                    //return objMarUser.Save();
                }
                else
                {

                    //SaveVehicleStatus(VehicleInfoBL objVehicleInfo, ImportData objImportData, UserBL objUser, String strShopId)
                    //Insert new record in UserVehicleStatus table
                    AddnewRecordInVehicleStatus(iVehicleId, iShopId, objImportData);

                }
            }
            catch (Exception ex)
            {
                Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
            }
            return false;
        }


        public void AddnewRecordInVehicleStatus(Int32 iVehicleId, Int32 iShopId, ImportData objImportData)
        {
            UserBL objUserBL = null;
            String strShopId = String.Empty;
            //Get Vehicle Info object from current vehicle ID
            VehicleInfoBL objVehicleInfoBL = VehicleInfoBL.getDataId(iVehicleId);
            if (objVehicleInfoBL != null)
            {
                //Create UserBL object from user ID used in Vehicle Info table
                objUserBL = UserBL.getByActivityId(Convert.ToInt32(objVehicleInfoBL.iUserId));
                strShopId = Convert.ToString(iShopId);
            }

            if (objUserBL != null && objVehicleInfoBL != null && !String.IsNullOrEmpty(strShopId))
            {
                SaveVehicleStatus(objVehicleInfoBL, objImportData, objUserBL, strShopId);
                UserVehicleStatusBL objUserVehicleStatusBL = UserVehicleStatusBL.getDataByVehicleId(iVehicleId);
                if (objUserVehicleStatusBL != null)
                {
                    MarketingUsers objMarUser = MarketingUsers.getDataByShopUserAndVehicleId(iShopId, Convert.ToInt32(objVehicleInfoBL.iUserId), iVehicleId);
                    objMarUser.bisShowInProcess = true;
                    objMarUser.Save();
                }
            }
            else
                return;
        }

        /// <summary>
        /// Update Vehicle Information
        /// </summary>
        /// <param name="iVehicleId"></param>
        /// <param name="objImportData"></param>
        /// <returns></returns>
        private Boolean updateVehicleData(Int32 iVehicleId, ImportData objImportData)
        {
            try
            {
                //Get Vehicle object from database using vehicle_id
                VehicleInfoBL objVehicleInfo = VehicleInfoBL.getDataId(iVehicleId);
                if (objVehicleInfo != null)
                {
                    if (!String.IsNullOrEmpty(objImportData.Style))
                        objVehicleInfo.strStyle = objImportData.Style;

                    if (!String.IsNullOrEmpty(objImportData.Color))
                        objVehicleInfo.strColor = objImportData.Color;

                    if (!String.IsNullOrEmpty(objImportData.Paint_Code))
                        objVehicleInfo.strPaintCode = objImportData.Paint_Code;

                    if (!String.IsNullOrEmpty(objImportData.VIN))
                        objVehicleInfo.strVIN = objImportData.VIN;

                    if (!String.IsNullOrEmpty(objImportData.EstimatorName.Trim()))
                        objVehicleInfo.strEstimatorName = objImportData.EstimatorName;

                    if (!String.IsNullOrEmpty(objImportData.License))
                        objVehicleInfo.strLicense = objImportData.License;

                    return objVehicleInfo.Save();
                }
            }
            catch (Exception ex)
            {
                Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
            }
            return false;
        }

        /// <summary>
        /// Update Insurance Information
        /// </summary>
        /// <param name="iUserId"></param>
        /// <param name="objImportData"></param>
        /// <returns></returns>
        private Boolean updateInsuranceData(Int32 iUserId, ImportData objImportData)
        {
            try
            {
                //Get InsuranceInfo object from database using user_id
                InsuranceInformationBL objInsurance = InsuranceInformationBL.getDataByUserId(iUserId);
                if (objInsurance == null)
                {
                    //Create new object for Insurance if information is not addedpreviously.
                    objInsurance = new InsuranceInformationBL();
                    objInsurance.iUserId = iUserId;
                }
                if (!String.IsNullOrEmpty(objImportData.Insurance_Company))
                    objInsurance.strCompanyName = objImportData.Insurance_Company;
                if (!String.IsNullOrEmpty(objImportData.Insurance_Company_Address))

                    objInsurance.strCompanyAddress = objImportData.Insurance_Company_Address;

                if (!String.IsNullOrEmpty(objImportData.Insurance_Company_City))
                    objInsurance.strCompanyCity = objImportData.Insurance_Company_City;

                if (!String.IsNullOrEmpty(objImportData.Insurance_Company_State))
                    objInsurance.strCompanyState = objImportData.Insurance_Company_State;

                if (!String.IsNullOrEmpty(objImportData.Insurance_Company_Zip))
                    objInsurance.strCompanyZip = objImportData.Insurance_Company_Zip;

                if (!String.IsNullOrEmpty(objImportData.Insurance_Company_Email))
                    objInsurance.strCompanyEmail = objImportData.Insurance_Company_Email;

                if (!String.IsNullOrEmpty(objImportData.Insurance_Company_Contact))
                    objInsurance.strCompanyCellPhone = objImportData.Insurance_Company_Contact;

                if (!String.IsNullOrEmpty(objImportData.Insurance_Company_Fax))
                    objInsurance.strCompanyFax = objImportData.Insurance_Company_Fax;

                if (!String.IsNullOrEmpty(objImportData.Agent))
                    objInsurance.strAgentName = objImportData.Agent;

                if (!String.IsNullOrEmpty(objImportData.Claim_Number))
                    objInsurance.strClaimNumber = objImportData.Claim_Number;

                if (!String.IsNullOrEmpty(objImportData.RO_Number))
                    objInsurance.strROIdentifier = objImportData.RO_Number;

                if (!String.IsNullOrEmpty(objImportData.Total_Amount))
                    objInsurance.strNetTotalAmount = objImportData.Total_Amount;


                if (!String.IsNullOrEmpty(objImportData.Total_RO_Amount))
                    objInsurance.strTotalROAmount = objImportData.Total_RO_Amount;

                if (!String.IsNullOrEmpty(objImportData.Date_Of_Loss))
                {
                    DateTime dtDateofLoss;
                    objInsurance.dtDateOfLoss = DateTime.TryParse(objImportData.Date_Of_Loss, out dtDateofLoss) ? dtDateofLoss : (Nullable<DateTime>)null;
                }
                if (!String.IsNullOrEmpty(objImportData.Deductible))
                {
                    Decimal dDeductible;
                    objInsurance.dDeductible = Decimal.TryParse(objImportData.Deductible, out dDeductible) ? dDeductible : (Nullable<Decimal>)null;
                }
                return objInsurance.Save();
            }
            catch (Exception ex)
            {
                Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
            }
            return false;
        }

    }
}
