<%@ Page Language="C#" %>

<%@ Import Namespace="System.IO" %>

<script language="C#" runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            String strShopId = Request["ShopId"];
            if (strShopId == "63733" || strShopId == "63688" || strShopId == "63737" || strShopId == "63692" || strShopId == "63732")
                return;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            String baseDirectory = Request.MapPath("~");
            String uploadDirectory = SummitShopApp.Utility.Constants.EMSFolderPath + Request["directory"];
            String folders;
            HttpPostedFile PostedFile;

            if (uploadDirectory != null && uploadDirectory != "")
            {
                folders = Path.Combine(baseDirectory, uploadDirectory);
            }
            else
            {
                folders = baseDirectory;
            }
            for (int i = 0; i < Request.Files.Count; i++)
            {
                PostedFile = Request.Files[i];
                // Creates the full path
                String filePath = Path.Combine(folders, HttpUtility.UrlDecode(PostedFile.FileName));
                filePath = Path.Combine(folders, Path.GetFileName(filePath));
                // Create the directories
                DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(filePath));
                if (!dir.Exists)
                    dir.Create();
                if (isValidEMSFile(filePath))
                {
                    // Save the uploaded file
                    PostedFile.SaveAs(filePath);
                }
                if (Path.GetExtension(filePath).ToLower().Equals(".csv"))
                {
                    PostedFile.SaveAs(filePath);
                }
            }
            DirectoryInfo _dir = new DirectoryInfo(folders);
            FileInfo[] files = _dir.GetFiles();
            foreach (FileInfo file in files)
            {
                String filePath = file.FullName;
                String strExt = Path.GetExtension(filePath);
                String fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
                String newFilePath = String.Empty;
                if (strExt.ToLower() != ".dbt" && !strExt.ToLower().Equals(".csv"))
                {
                    newFilePath = Path.Combine(folders, fileNameWithoutExt + "_" + strExt.Replace(".", "") + ".DBF");
                    if (!File.Exists(newFilePath))
                    {
                        if (strExt.ToLower() == ".ad1")
                        {
                            FileInfo[] _files = _dir.GetFiles(fileNameWithoutExt + "*.dbt");
                            foreach (FileInfo _file in _files)
                            {
                                if (!File.Exists(Path.Combine(folders, fileNameWithoutExt + "_AD1.DBT")))
                                    File.Copy(_file.FullName, Path.Combine(folders, fileNameWithoutExt + "_AD1.DBT"));
                                if (!File.Exists(Path.Combine(folders, fileNameWithoutExt + "_AD2.DBT")))
                                    File.Copy(_file.FullName, Path.Combine(folders, fileNameWithoutExt + "_AD2.DBT"));
                                if (!File.Exists(Path.Combine(folders, fileNameWithoutExt + "_VEH.DBT")))
                                    File.Move(_file.FullName, Path.Combine(folders, fileNameWithoutExt + "_VEH.DBT"));
                            }
                        }
                        if (strExt.ToLower() == ".ad2")
                        {
                            FileInfo[] _files = _dir.GetFiles(fileNameWithoutExt + "*.dbt");
                            foreach (FileInfo _file in _files)
                            {
                                if (!File.Exists(Path.Combine(folders, fileNameWithoutExt + "_AD1.DBT")))
                                    File.Copy(_file.FullName, Path.Combine(folders, fileNameWithoutExt + "_AD1.DBT"));
                                if (!File.Exists(Path.Combine(folders, fileNameWithoutExt + "_AD2.DBT")))
                                    File.Copy(_file.FullName, Path.Combine(folders, fileNameWithoutExt + "_AD2.DBT"));
                                if (!File.Exists(Path.Combine(folders, fileNameWithoutExt + "_VEH.DBT")))
                                    File.Move(_file.FullName, Path.Combine(folders, fileNameWithoutExt + "_VEH.DBT"));
                            }
                        }
                        if (strExt.ToLower() == ".veh")
                        {
                            FileInfo[] _files = _dir.GetFiles(fileNameWithoutExt + "*.dbt");
                            foreach (FileInfo _file in _files)
                            {
                                if (!File.Exists(Path.Combine(folders, fileNameWithoutExt + "_AD1.DBT")))
                                    File.Copy(_file.FullName, Path.Combine(folders, fileNameWithoutExt + "_AD1.DBT"));
                                if (!File.Exists(Path.Combine(folders, fileNameWithoutExt + "_AD2.DBT")))
                                    File.Copy(_file.FullName, Path.Combine(folders, fileNameWithoutExt + "_AD2.DBT"));
                                if (!File.Exists(Path.Combine(folders, fileNameWithoutExt + "_VEH.DBT")))
                                    File.Move(_file.FullName, Path.Combine(folders, fileNameWithoutExt + "_VEH.DBT"));
                            }
                        }
                        File.Move(file.FullName, newFilePath);
                    }
                }
            }
            if (Request["AutoImport"] == "true")
            {
                String strShopIdTemp = Request["ShopId"];
                if (strShopId != null)
                {
                    //if (!String.IsNullOrEmpty(Request["Is3rdPartyData"]) && Request["Is3rdPartyData"].ToLower() == "true")
                    //{
                    //    SaveCSVData(_dir.ToString(), strShopId);
                    //}
                    //else
                    //{
                    Save(_dir.ToString(), strShopId);
                    // }
                }
            }
        }
        catch (Exception ex)
        {
            System.IO.File.AppendAllText(SummitShopApp.Utility.Constants.AUTOIMPORTERLOG_FILEPATH, Environment.NewLine);
            System.IO.File.AppendAllText(SummitShopApp.Utility.Constants.AUTOIMPORTERLOG_FILEPATH, "Shop id: " + Request["ShopId"]);
            System.IO.File.AppendAllText(SummitShopApp.Utility.Constants.AUTOIMPORTERLOG_FILEPATH, Environment.NewLine);
            System.IO.File.AppendAllText(SummitShopApp.Utility.Constants.AUTOIMPORTERLOG_FILEPATH, ex.StackTrace);
            Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
            // Internal server error
            Response.StatusCode = 500;
            Response.Status = "500 Error: " + ex.Message;
        }
    }
    /// <summary>
    /// Check for name,year,make,model and mobile# are equals 
    /// </summary>
    /// <param name="objInProcessObject"></param>
    /// <param name="objEMSData"></param>
    /// <returns></returns>
    private Boolean IsEqualsNew(SummitShopApp.BL.MyCustomerBL objInProcessObject, SummitShopApp.Utility.EMSData objEMSData)
    {
        //return (!string.IsNullOrEmpty(objInProcessObject.strUserName) && !string.IsNullOrEmpty(objEMSData.strUserName) && objInProcessObject.strUserName.ToLower().Trim() == objEMSData.strUserName.ToLower().Trim()
        //                       && objInProcessObject.strYear != null && objEMSData.strYear != null && objEMSData.strYear.ToLower().Trim() == objInProcessObject.strYear.ToLower().Trim()
        //                       && objInProcessObject.strMake != null && objEMSData.strMake != null && objInProcessObject.strMake.ToLower().Trim() == objEMSData.strMake.ToLower().Trim()
        //                       && objInProcessObject.strModel != null && objEMSData.strModel != null && objInProcessObject.strModel.ToLower().Trim() == objEMSData.strModel.ToLower().Trim()
        //                       && objInProcessObject.strPhone != null && objEMSData.strOwnerPhone1 != null && objInProcessObject.strPhone.ToLower().Trim() == objEMSData.strOwnerPhone1.ToLower().Trim());

        bool bIsEqual = (objInProcessObject.strUserName != null && objEMSData.strUserName != null && objInProcessObject.strUserName.ToLower().Trim() == objEMSData.strUserName.ToLower().Trim()
                                && objInProcessObject.strYear != null && objEMSData.strYear != null && objEMSData.strYear.ToLower().Trim() == objInProcessObject.strYear.ToLower().Trim()
                                && objInProcessObject.strMake != null && objEMSData.strMake != null && objInProcessObject.strMake.ToLower().Trim() == objEMSData.strMake.ToLower().Trim()
                                && objInProcessObject.strModel != null && objEMSData.strModel != null && objInProcessObject.strModel.ToLower().Trim() == objEMSData.strModel.ToLower().Trim()
                                && objInProcessObject.strPhone != null && objEMSData.strOwnerPhone1 != null && objInProcessObject.strPhone.ToLower().Trim() == objEMSData.strOwnerPhone1.ToLower().Trim());

        //START - Code added for [Simon's Auto Body & Mechanical shop - id : 14817], [427 Auto Collision - CSN shop - id : 41], [City Centre Collision ~ CSN shop - id : 4152]
        try
        {
            if ((objInProcessObject.iShopId == 14817 || objInProcessObject.iShopId == 41 || objInProcessObject.iShopId == 4152) && !bIsEqual)
            {
                if (objInProcessObject.strEmail != null && objEMSData.strOwnerEmail != null)
                {
                    bIsEqual = (objInProcessObject.strUserName != null && objEMSData.strUserName != null && objInProcessObject.strUserName.ToLower().Trim() == objEMSData.strUserName.ToLower().Trim()
                                       && objInProcessObject.strPhone != null && objEMSData.strOwnerPhone1 != null && objInProcessObject.strPhone.ToLower().Trim() == objEMSData.strOwnerPhone1.ToLower().Trim()
                                       && objInProcessObject.strEmail != null && objEMSData.strOwnerEmail != null && objInProcessObject.strEmail.ToLower().Trim() == objEMSData.strOwnerEmail.ToLower().Trim());
                }
                else
                {
                    bIsEqual = (objInProcessObject.strUserName != null && objEMSData.strUserName != null && objInProcessObject.strUserName.ToLower().Trim() == objEMSData.strUserName.ToLower().Trim()
                                       && objInProcessObject.strPhone != null && objEMSData.strOwnerPhone1 != null && objInProcessObject.strPhone.ToLower().Trim() == objEMSData.strOwnerPhone1.ToLower().Trim());
                }
            }
        }
        catch (Exception)
        {
        }
        //END- Code added for [Simon's Auto Body & Mechanical shop - id : 14817], [427 Auto Collision - CSN shop - id : 41], [City Centre Collision ~ CSN shop - id : 4152]

        return bIsEqual;
    }

    /// <summary>
    /// Check for name,year,make,model and mobile# are equals 
    /// </summary>
    /// <param name="objInProcessObject"></param>
    /// <param name="objEMSData"></param>
    /// <returns></returns>
    private Boolean IsEquals(SummitShopApp.BL.InProcessUsersBL objInProcessObject, SummitShopApp.Utility.EMSData objEMSData)
    {
        //return (!string.IsNullOrEmpty(objInProcessObject.strUserName) && !string.IsNullOrEmpty(objEMSData.strUserName) && objInProcessObject.strUserName.ToLower().Trim() == objEMSData.strUserName.ToLower().Trim()
        //                       && objInProcessObject.strYear != null && objEMSData.strYear != null && objEMSData.strYear.ToLower().Trim() == objInProcessObject.strYear.ToLower().Trim()
        //                       && objInProcessObject.strMake != null && objEMSData.strMake != null && objInProcessObject.strMake.ToLower().Trim() == objEMSData.strMake.ToLower().Trim()
        //                       && objInProcessObject.strModel != null && objEMSData.strModel != null && objInProcessObject.strModel.ToLower().Trim() == objEMSData.strModel.ToLower().Trim()
        //                       && objInProcessObject.strPhone != null && objEMSData.strOwnerPhone1 != null && objInProcessObject.strPhone.ToLower().Trim() == objEMSData.strOwnerPhone1.ToLower().Trim());

        bool bIsEqual = (objInProcessObject.strUserName != null && objEMSData.strUserName != null && objInProcessObject.strUserName.ToLower().Trim() == objEMSData.strUserName.ToLower().Trim()
                                && objInProcessObject.strYear != null && objEMSData.strYear != null && objEMSData.strYear.ToLower().Trim() == objInProcessObject.strYear.ToLower().Trim()
                                && objInProcessObject.strMake != null && objEMSData.strMake != null && objInProcessObject.strMake.ToLower().Trim() == objEMSData.strMake.ToLower().Trim()
                                && objInProcessObject.strModel != null && objEMSData.strModel != null && objInProcessObject.strModel.ToLower().Trim() == objEMSData.strModel.ToLower().Trim()
                                && objInProcessObject.strPhone != null && objEMSData.strOwnerPhone1 != null && objInProcessObject.strPhone.ToLower().Trim() == objEMSData.strOwnerPhone1.ToLower().Trim());

        //START - Code added for [Simon's Auto Body & Mechanical shop - id : 14817], [427 Auto Collision - CSN shop - id : 41], [City Centre Collision ~ CSN shop - id : 4152]
        try
        {
            if (objInProcessObject.iShopId.HasValue && (objInProcessObject.iShopId.Value == 14817 || objInProcessObject.iShopId.Value == 41 || objInProcessObject.iShopId.Value == 4152) && !bIsEqual)
            {
                if (objInProcessObject.strEmail != null && objEMSData.strOwnerEmail != null)
                {
                    bIsEqual = (objInProcessObject.strUserName != null && objEMSData.strUserName != null && objInProcessObject.strUserName.ToLower().Trim() == objEMSData.strUserName.ToLower().Trim()
                                       && objInProcessObject.strPhone != null && objEMSData.strOwnerPhone1 != null && objInProcessObject.strPhone.ToLower().Trim() == objEMSData.strOwnerPhone1.ToLower().Trim()
                                       && objInProcessObject.strEmail != null && objEMSData.strOwnerEmail != null && objInProcessObject.strEmail.ToLower().Trim() == objEMSData.strOwnerEmail.ToLower().Trim());
                }
                else
                {
                    bIsEqual = (objInProcessObject.strUserName != null && objEMSData.strUserName != null && objInProcessObject.strUserName.ToLower().Trim() == objEMSData.strUserName.ToLower().Trim()
                                       && objInProcessObject.strPhone != null && objEMSData.strOwnerPhone1 != null && objInProcessObject.strPhone.ToLower().Trim() == objEMSData.strOwnerPhone1.ToLower().Trim());
                }
            }
        }
        catch (Exception)
        {
        }
        //END- Code added for [Simon's Auto Body & Mechanical shop - id : 14817], [427 Auto Collision - CSN shop - id : 41], [City Centre Collision ~ CSN shop - id : 4152]

        return bIsEqual;
    }


    /// <summary>
    /// Save EMS files on server and imoport them into database
    /// </summary>
    /// <param name="folderPath"></param>
    /// <param name="strShopId"></param>
    protected void SaveOldAILogic(System.Collections.Generic.List<SummitShopApp.Utility.EMSData> lstEMSData, String strShopId)
    {
        try
        {


            Boolean bMatch = false;
            int iVehicleStatusId = 0;
            if (lstEMSData != null)
            {
                //Get deleted customers from inprocess
                Int32 iCounter = -1;
                System.Collections.Generic.List<SummitShopApp.BL.InProcessUsersBL> lstDeletedUsers = SummitShopApp.BL.InProcessUsersBL.GetAllDeletedUsers(Convert.ToInt32(strShopId));
                //Loop for extracted data from all files we have imprted
                foreach (SummitShopApp.Utility.EMSData objEMSData in lstEMSData)
                {
                    Boolean bIsDuplicate = false;
                    Boolean bUpdateData = false;
                    //SummitShopApp.BL.InProcessUsersBL objInProcessUser = null;
                    SummitShopApp.BL.MyCustomerBL _objMyCustomer = null;
                    System.Collections.Generic.List<SummitShopApp.BL.MyCustomerBL> lstMyCustomer = SummitShopApp.BL.MyCustomerBL.getCustomersList(Convert.ToInt32(strShopId));
                    ++iCounter;
                    SummitShopApp.Utility.CommonFunctions.LoggingForOld_AILogic(Environment.NewLine);
                    try
                    {
                        SummitShopApp.Utility.CommonFunctions.LoggingForOld_AILogic("Duplicate Check >> Shop : " + strShopId + " User Name : " + objEMSData.strUserName + " with no. of customers : " + lstMyCustomer.Count.ToString());
                        //SummitShopApp.Utility.CommonFunctions.LoggingForOld_AILogic("Duplicate Check >> Shop : " + !String.IsNullOrEmpty(strShopId) ? strShopId : String.Empty + " User Name : " + !String.IsNullOrEmpty(objEMSData.strUserName) ? objEMSData.strUserName : String.Empty + " with no. of customers : " +  lstMyCustomer.Count.ToString());
                    }
                    catch (Exception Ex)
                    {
                    }
                    if (lstMyCustomer != null && lstMyCustomer.Count > 0 && objEMSData != null)
                    {
                        if (!String.IsNullOrEmpty(objEMSData.strEstimateFileId))
                        {
                            try
                            {
                                _objMyCustomer = lstMyCustomer.Find(o => !String.IsNullOrEmpty(o.strEstimateFileIdentifier) && String.Equals(o.strEstimateFileIdentifier.ToLower().Trim(), objEMSData.strEstimateFileId.ToLower().Trim()));
                                if (_objMyCustomer != null)
                                {
                                    bIsDuplicate = true;
                                    bUpdateData = true;
                                    SummitShopApp.Utility.CommonFunctions.LoggingForOld_AILogic("got customer with identifire for : " + objEMSData.strUserName);

                                }
                            }
                            catch (Exception ex)
                            {
                                SummitShopApp.Utility.CommonFunctions.LoggingForOld_AILogic("Exception : Checking Identifier" + ex.ToString());
                                _objMyCustomer = null;
                                bIsDuplicate = false;
                                bUpdateData = false;
                            }
                        }
                        if (!bIsDuplicate)
                        {
                            foreach (SummitShopApp.BL.MyCustomerBL objMyCustomer in lstMyCustomer)
                            {
                                //for older file that has been imported and don't have unique file identifier then check for name,year,make,model and mobile #
                                if (String.IsNullOrEmpty(objMyCustomer.strEstimateFileIdentifier))
                                {
                                    bIsDuplicate = IsEqualsNew(objMyCustomer, objEMSData);
                                }
                                // else check with unique file identifier
                                else
                                {
                                    if (objEMSData.strEstimateFileId != null && objMyCustomer.strEstimateFileIdentifier != null && String.Equals(objMyCustomer.strEstimateFileIdentifier.ToLower().Trim(), objEMSData.strEstimateFileId.ToLower().Trim()))
                                    {
                                        bIsDuplicate = true;
                                    }
                                    //if EstimateID is different then again check with five fields
                                    else
                                    {
                                        bIsDuplicate = IsEqualsNew(objMyCustomer, objEMSData);
                                    }
                                }
                                if (bIsDuplicate)
                                {
                                    bUpdateData = true;
                                    _objMyCustomer = objMyCustomer;
                                    break;
                                }

                            }
                        }
                    }

                    if (!bIsDuplicate)
                    {
                        Boolean bIsDeleted = false;

                        if (lstDeletedUsers != null && lstDeletedUsers.Count > 0)
                        {
                            foreach (SummitShopApp.BL.InProcessUsersBL objInProcessObject in lstDeletedUsers)
                            {
                                //for older file that has been imported and don't have unique file identifier then check for name,year,make,model and mobile #
                                if (String.IsNullOrEmpty(objInProcessObject.strEstimateFileIdentifier))
                                {
                                    bIsDeleted = IsEquals(objInProcessObject, objEMSData);
                                }
                                // else check with unique file identifier
                                else
                                {
                                    if (objEMSData.strEstimateFileId != null && String.Equals(objInProcessObject.strEstimateFileIdentifier.ToLower().Trim(), objEMSData.strEstimateFileId.ToLower().Trim()))
                                    {
                                        bIsDeleted = true;
                                    }
                                    //if EstimateID is different then again check with five fields
                                    else
                                    {
                                        bIsDeleted = IsEquals(objInProcessObject, objEMSData);
                                    }
                                }
                                if (bIsDeleted)
                                {
                                    //bUpdateData = true;
                                    _objMyCustomer = null;
                                    break;
                                }
                            }
                        }
                        if (!bIsDeleted)
                        {
                            //Code added for Delivery Date - START
                            Boolean IsDelivered = false;
                            DateTime dtDeliveryDateTemp;
                            DateTime? dtDeliveryDate = null;
                            try
                            {
                                dtDeliveryDate = DateTime.TryParse(objEMSData.strDeliveryDate, out dtDeliveryDateTemp) ? dtDeliveryDateTemp : (Nullable<DateTime>)null;
                                if (dtDeliveryDate.HasValue && dtDeliveryDate.Value >= Convert.ToDateTime("01/01/1970"))
                                {
                                    IsDelivered = true;//TODO - True
                                }
                            }
                            catch (Exception ex)
                            {

                            }

                            //Code added for Delivery Date - END

                            //Move to Marketign for Imported Estimate
                            Boolean bIsMoveToMarketing = false;
                            try
                            {
                                SummitShopApp.BL.VehicleStatusBL objVehicleStatus = SummitShopApp.BL.VehicleStatusBL.getDataByShopIdAndStatus(Convert.ToInt32(strShopId), "Imported Estimate");
                                if (objVehicleStatus != null && objVehicleStatus.bMoveToMarketing.HasValue)
                                {
                                    bIsMoveToMarketing = objVehicleStatus.bMoveToMarketing.Value;
                                }
                            }
                            catch (Exception) { }


                            SummitShopApp.BL.UserBL objUser = new SummitShopApp.BL.UserBL();

                            String strFormatedUserName = String.IsNullOrEmpty(objEMSData.strUserName) ? String.Empty : objEMSData.strUserName.Trim();
                            if (strFormatedUserName.Length > 50)
                            {
                                strFormatedUserName = strFormatedUserName.Substring(0, 50);
                            }
                            objUser.strUserName = strFormatedUserName;
                            objUser.strFirstName = objEMSData.strOwnerFirstName;
                            objUser.strLastName = objEMSData.strOwnerLastName;
                            objUser.strPhone = objEMSData.strOwnerPhone1;
                            objUser.strPhone2 = objEMSData.strOwnerPhone2;

                            String strFormatedEmail = String.IsNullOrEmpty(objEMSData.strOwnerEmail) ? String.Empty : objEMSData.strOwnerEmail.Trim();
                            if (strFormatedEmail.Length > 50)
                            {
                                strFormatedEmail = strFormatedEmail.Substring(0, 50);
                            }

                            objUser.strEmail = strFormatedEmail;
                            objUser.strAddress1 = objEMSData.strOwnerAddress1;
                            objUser.strAddress2 = objEMSData.strOwnerAddress2;
                            objUser.strCity = objEMSData.strOwnerCity;
                            objUser.strState = objEMSData.strOwnerState;
                            objUser.strZip = objEMSData.strOwnerZipCode;
                            if (!String.IsNullOrEmpty(Request.QueryString["ImportEMSDataTo"]) && (Request.QueryString["ImportEMSDataTo"].ToLower() == "emailmarketing" || Request.QueryString["ImportEMSDataTo"].ToLower() == "textmarketing"))
                            {
                                objUser.bIsShowEmailMarketing = true;
                                objUser.bIsShowTextMarketing = true;
                            }

                            //Code added for Delivery Date - START
                            if (IsDelivered || bIsMoveToMarketing)
                            {
                                objUser.bIsShowEmailMarketing = true;
                                objUser.bIsShowTextMarketing = true;
                            }
                            //Code added for Delivery Date - END

                            objUser.dtUpdatedEntryTime = DateTime.Now;
                            if (objUser.Save())
                            {
                                SummitShopApp.BL.VehicleInfoBL objVehicleInfo = new SummitShopApp.BL.VehicleInfoBL();
                                objVehicleInfo.iUserId = objUser.ID;
                                objVehicleInfo.strYear = objEMSData.strYear;
                                objVehicleInfo.strMake = objEMSData.strMake;
                                objVehicleInfo.strModel = objEMSData.strModel;
                                objVehicleInfo.strStyle = objEMSData.strStyle;
                                objVehicleInfo.strColor = objEMSData.strColor;
                                objVehicleInfo.strPaintCode = objEMSData.strPaintCode;
                                objVehicleInfo.strVIN = objEMSData.strVIN;
                                objVehicleInfo.strLicense = objEMSData.strLicense;
                                objVehicleInfo.strEstimatorName = objEMSData.strEstimatorName;
                                objVehicleInfo.strEstimateFileIdentifier = objEMSData.strEstimateFileId;
                                DateTime dtProductionDate;
                                objVehicleInfo.dtProductionDate = DateTime.TryParse("", out dtProductionDate) ? dtProductionDate : (Nullable<DateTime>)null;
                                objVehicleInfo.bIsUsing = true;
                                objVehicleInfo.Save();
                                SummitShopApp.BL.MarketingUsers objMarUser = new SummitShopApp.BL.MarketingUsers();
                                objMarUser.iShopId = Convert.ToInt32(strShopId);
                                objMarUser.iUserId = objUser.ID;
                                objMarUser.iVehicleId = objVehicleInfo.ID;
                                //Code added for Delivery Date - START
                                if (IsDelivered || bIsMoveToMarketing)
                                    objMarUser.bisShowInProcess = false;
                                else
                                    objMarUser.bisShowInProcess = true;
                                //Code added for Delivery Date - END

                                objMarUser.iVehicleId = objVehicleInfo.ID;
                                objMarUser.Save();

                                SummitShopApp.Utility.CommonFunctions.LoggingForOld_AILogic(Environment.NewLine);
                                SummitShopApp.Utility.CommonFunctions.LoggingForOld_AILogic(" - - - - - New User Method Starts");
                                SummitShopApp.Utility.CommonFunctions.LoggingForOld_AILogic("shop : " + objMarUser.iShopId + " New User : " + objUser.ID + " usename : " + objUser.strUserName);
                                SummitShopApp.Utility.CommonFunctions.LoggingForOld_AILogic("RO Number: " + objEMSData.strRONumbert);
                                SummitShopApp.Utility.CommonFunctions.LoggingForOld_AILogic("Date In : " + objEMSData.strDateIn);
                                SummitShopApp.Utility.CommonFunctions.LoggingForOld_AILogic("RO Complition Date: " + objEMSData.strDateOut_Ro_Cmp_Date);
                                SummitShopApp.Utility.CommonFunctions.LoggingForOld_AILogic("Tar Date Out: " + objEMSData.strDateOut_Tar_Date);

                                SummitShopApp.BL.UserVehicleStatusBL objCustomerVehicleStatus = new SummitShopApp.BL.UserVehicleStatusBL();
                                objCustomerVehicleStatus.iUserId = objUser.ID;
                                objCustomerVehicleStatus.iVehicleId = objVehicleInfo.ID;

                                DateTime dtDateInTemp;
                                DateTime? dtDateIn = null;
                                try
                                {
                                    dtDateIn = DateTime.TryParse(objEMSData.strDateIn, out dtDateInTemp) ? dtDateInTemp : (Nullable<DateTime>)null;
                                    if (dtDateIn.HasValue && dtDateIn.Value >= Convert.ToDateTime("01/01/1970"))
                                    {
                                        objCustomerVehicleStatus.dtDateIn = dtDateIn;
                                    }
                                }
                                catch (Exception ex) { }

                                DateTime dtDateOutTemp_TAR_DATE;
                                DateTime? dtDateOut_TAR_DATE;
                                DateTime dtDateOutTemp_RO_CMPDATE;
                                DateTime? dtDateOut_RO_CMPDATE;
                                try
                                {
                                    dtDateOut_RO_CMPDATE = DateTime.TryParse(objEMSData.strDateOut_Ro_Cmp_Date, out dtDateOutTemp_RO_CMPDATE) ? dtDateOutTemp_RO_CMPDATE : (Nullable<DateTime>)null;
                                    dtDateOut_TAR_DATE = DateTime.TryParse(objEMSData.strDateOut_Tar_Date, out dtDateOutTemp_TAR_DATE) ? dtDateOutTemp_TAR_DATE : (Nullable<DateTime>)null;

                                    if (dtDateOut_RO_CMPDATE.HasValue && dtDateOut_RO_CMPDATE.Value >= Convert.ToDateTime("01/01/1970"))
                                    {
                                        objCustomerVehicleStatus.dtDateOut = dtDateOut_RO_CMPDATE;
                                    }
                                    else if (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value >= Convert.ToDateTime("01/01/1970"))
                                    {
                                        objCustomerVehicleStatus.dtDateOut = dtDateOut_TAR_DATE;
                                    }
                                }
                                catch (Exception ex) { }


                                System.Collections.Generic.List<SummitShopApp.BL.VehicleStatusBL> lstVehicleStatus = new System.Collections.Generic.List<SummitShopApp.BL.VehicleStatusBL>();
                                lstVehicleStatus = SummitShopApp.BL.VehicleStatusBL.getDataByShopId(Convert.ToInt32(strShopId));


                                if (lstVehicleStatus != null)
                                {
                                    foreach (SummitShopApp.BL.VehicleStatusBL objVehicleStatus in lstVehicleStatus)
                                    {
                                        if (objVehicleStatus.strVehicleStatus == "Imported Estimate")
                                        {
                                            iVehicleStatusId = objVehicleStatus.ID;
                                            bMatch = true;
                                            break;
                                        }
                                    }


                                    //Code added for Delivery Date - START
                                    try
                                    {
                                        if (IsDelivered)
                                        {
                                            SummitShopApp.BL.VehicleStatusBL objVehicleStatusBL = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim() == "delivered");
                                            if (objVehicleStatusBL != null)
                                            {
                                                iVehicleStatusId = objVehicleStatusBL.ID;
                                                bMatch = true;
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }

                                //Code added for Delivery Date - END

                                if (bMatch)
                                {
                                    objCustomerVehicleStatus.iVehicleStatusId = iVehicleStatusId;
                                    objCustomerVehicleStatus.dtLastUpdatedStatusDate = DateTime.Now;
                                    //Code added for Delivery Date - START
                                    if (IsDelivered)
                                    {
                                        objCustomerVehicleStatus.dtDeliveryDate = dtDeliveryDate;

                                        //Add records into reoccuring and scheuduled campaign for delivered vehicle status
                                        try
                                        {
                                            //Add record into another table AIManageRecurringActivity - it will processed by AIManageRecurringActivity Service
                                            SummitShopApp.BL.AIManageRecurringActivityBL objAIManageRecurringActivityBL = SummitShopApp.BL.AIManageRecurringActivityBL.getDataByShopIdUserIdAndDeliveryDate(objUser.ID, Convert.ToInt32(strShopId), dtDeliveryDate.Value);
                                            if (objAIManageRecurringActivityBL == null)
                                            {
                                                objAIManageRecurringActivityBL = new SummitShopApp.BL.AIManageRecurringActivityBL();
                                                objAIManageRecurringActivityBL.iShopId = Convert.ToInt32(strShopId);
                                                objAIManageRecurringActivityBL.iUserId = objUser.ID;
                                                objAIManageRecurringActivityBL.dtDeliveryDate = dtDeliveryDate.Value;
                                                objAIManageRecurringActivityBL.Save();
                                            }

                                        }
                                        catch (Exception ex)
                                        {

                                        }

                                    }
                                    //Code added for Delivery Date - END
                                }
                                else
                                {
                                    SummitShopApp.BL.VehicleStatusBL _objVehicleStatus = new SummitShopApp.BL.VehicleStatusBL();
                                    _objVehicleStatus.strVehicleStatus = "Imported Estimate";
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

                                SummitShopApp.BL.InsuranceInformationBL objInsurance = new SummitShopApp.BL.InsuranceInformationBL();
                                objInsurance.iUserId = objUser.ID;
                                objInsurance.strCompanyName = objEMSData.strInsuranceCompanyName;
                                objInsurance.strCompanyAddress = objEMSData.strInsuranceCompanyAddress;
                                objInsurance.strCompanyCity = objEMSData.strInsuranceCompanyCity;
                                objInsurance.strCompanyState = objEMSData.strInsuranceCompanyState;
                                objInsurance.strCompanyZip = objEMSData.strInsuranceCompanyZipCode;
                                objInsurance.strCompanyEmail = objEMSData.strInsuranceCompanyEmail;
                                objInsurance.strCompanyCellPhone = objEMSData.strInsuranceCompanyPhone;
                                objInsurance.strCompanyFax = objEMSData.strInsuranceCompanyFax;
                                objInsurance.strAgentName = objEMSData.strInsuranceAgentName;
                                objInsurance.strClaimNumber = objEMSData.strClaimNumber; //lblClaimNumber.Text;
                                objInsurance.strROIdentifier = objEMSData.strRONumbert; //lblRONumbert.Text;
                                objInsurance.strNetTotalAmount = objEMSData.strNetTotalAmount; //lblNetTotalAmount.Text;
                                DateTime dtDateofLoss;
                                Decimal dDeductible;
                                DateTime.TryParse(objInsurance.dtDateOfLoss.ToString(), out dtDateofLoss);
                                objInsurance.dtDateOfLoss = DateTime.TryParse(objEMSData.strDateOfLoss, out dtDateofLoss) ? dtDateofLoss : (Nullable<DateTime>)null;
                                objInsurance.dDeductible = Decimal.TryParse(objEMSData.strDeductible, out dDeductible) ? dDeductible : (Nullable<Decimal>)null;
                                objInsurance.Save();

                                SummitShopApp.Utility.CommonFunctions.LoggingForOld_AILogic("shop : " + objMarUser.iShopId + " New User : " + objUser.ID + " usename : " + objUser.strUserName);
                                SummitShopApp.Utility.CommonFunctions.LoggingForOld_AILogic(" - - - - - New User Method Ends");
                                SummitShopApp.Utility.CommonFunctions.LoggingForOld_AILogic(Environment.NewLine);
                            }
                        }
                    }

                    #region Update Sync data
                    //If file is already imported and matched with unique file idetifier then update data
                    if (bUpdateData && _objMyCustomer != null)
                    {
                        updateEMSData(_objMyCustomer, objEMSData);
                    }
                    #endregion
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    /// <summary>
    /// Save EMS files on server and imoport them into database
    /// </summary>
    /// <param name="folderPath"></param>
    /// <param name="strShopId"></param>
    protected void Save(String folderPath, String strShopId)
    {
        try
        {
            if (!String.IsNullOrEmpty(strShopId) && Convert.ToInt32(strShopId) > 0)
            {
                SummitShopApp.BL.BodyShopBL objBodyShopBL = SummitShopApp.BL.BodyShopBL.getShopById(Convert.ToInt32(strShopId));

                if (objBodyShopBL != null && objBodyShopBL.bIsPremierShop.HasValue && objBodyShopBL.bIsPremierShop.Value)
                {
                    /*
                     Dev 2: Added changes to add the shop information currently running for auto importer
                     * date : 15/July/2016
                     */
                    Int32 iAILogicShopID = Convert.ToInt32(strShopId);
                    SummitShopApp.BL.AutoImporterShopsBL objAutoImporterShopsBL = SummitShopApp.BL.AutoImporterShopsBL.getDataByShopId(Convert.ToInt32(strShopId));
                    if (objAutoImporterShopsBL != null)
                    {
                        objAutoImporterShopsBL.dtSyncDateTime = DateTime.Now;
                    }
                    else
                    {
                        objAutoImporterShopsBL = new SummitShopApp.BL.AutoImporterShopsBL();
                        objAutoImporterShopsBL.iShopId = Convert.ToInt32(strShopId);
                        objAutoImporterShopsBL.dtSyncDateTime = DateTime.Now;
                    }
                    objAutoImporterShopsBL.Save();

                    //System.Collections.Generic.List<SummitShopApp.Utility.EMSData> lstEMSData = new System.Collections.Generic.List<SummitShopApp.Utility.EMSData>();
                    System.Collections.Generic.List<SummitShopApp.Utility.EMSData> lstEMSData = new System.Collections.Generic.List<SummitShopApp.Utility.EMSData>();

                    //Check IsThirdParty Data Or Not 
                    if (!String.IsNullOrEmpty(Request["Is3rdPartyData"]) && Request["Is3rdPartyData"].ToLower() == "true")
                    {
                        lstEMSData = SummitShopApp.Utility.CommonFunctions.ExtractDataFromExcellFile(folderPath);
                    }
                    else
                        lstEMSData = SummitShopApp.Utility.CommonFunctions.ExtractDataFromEstimateFiles(folderPath);

                    if (lstEMSData != null)
                    {
                        String[] strConfigShops = ConfigurationManager.AppSettings[SummitShopApp.Utility.Constants.Key_NewAILogicShops].Split(SummitShopApp.Utility.Constants.CHAR_Quomma);
                        System.Collections.Generic.List<Int32> lstNewAILogicShops = new System.Collections.Generic.List<Int32>();
                        foreach (String strShop in strConfigShops)
                        {
                            try
                            {
                                if (!String.IsNullOrEmpty(strShop))
                                    lstNewAILogicShops.Add(Convert.ToInt32(strShop));
                            }
                            catch (Exception)
                            {

                            }
                        }
                        if (!String.IsNullOrEmpty(Request["Is3rdPartyData"]) && Request["Is3rdPartyData"].ToLower() == "true")
                        {
                            SaveNewAILocicForCSV(lstEMSData, iAILogicShopID);
                        }
                        else
                        {

                            if (lstNewAILogicShops.Exists(AiLogicShop => AiLogicShop == iAILogicShopID))
                            {
                                SaveNewAILocic(lstEMSData, iAILogicShopID);
                            }
                            else
                            {
                                SaveOldAILogic(lstEMSData, strShopId);
                            }
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
    /// Save EMS files on server and imoport them into database
    /// </summary>
    /// <param name="folderPath"></param>
    /// <param name="strShopId"></param>
    protected void SaveNewAILocic(System.Collections.Generic.List<SummitShopApp.Utility.EMSData> lstEMSData, Int32 iAILogicShopID)
    {
        Boolean bMatch = false;
        int iVehicleStatusId = 0;
        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic(Environment.NewLine);
        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Save function called for shopid : " + iAILogicShopID.ToString());
        if (lstEMSData != null)
        {
            //Get deleted customers from inprocess
            System.Collections.Generic.List<SummitShopApp.BL.InProcessUsersBL> lstDeletedUsers = SummitShopApp.BL.InProcessUsersBL.GetAllDeletedUsers(iAILogicShopID);

            Int32 iCounter = -1;
            //Loop for extracted data from all files we have imprted
            foreach (SummitShopApp.Utility.EMSData objEMSData in lstEMSData)
            {
                System.Collections.Generic.List<SummitShopApp.BL.MyCustomerBL> lstMyCustomer = SummitShopApp.BL.MyCustomerBL.getCustomersList(iAILogicShopID);

                Boolean bIsDuplicate = false;
                Boolean bUpdateData = false;
                SummitShopApp.BL.MyCustomerBL _objMyCustomer = null;

                //Get inprocess customers
                ++iCounter;
                if (lstMyCustomer != null && lstMyCustomer.Count > 0 && objEMSData != null)
                {
                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Check For Duplicate User For Shop : " + iAILogicShopID.ToString() + " User Name : " + objEMSData.strUserName + " with number of customers : " + lstMyCustomer.Count.ToString());
                    if (!String.IsNullOrEmpty(objEMSData.strEstimateFileId))
                    {
                        try
                        {
                            _objMyCustomer = lstMyCustomer.Find(o => !String.IsNullOrEmpty(o.strEstimateFileIdentifier) && String.Equals(o.strEstimateFileIdentifier.ToLower().Trim(), objEMSData.strEstimateFileId.ToLower().Trim()));
                            if (_objMyCustomer != null)
                            {
                                bIsDuplicate = true;
                                bUpdateData = true;
                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("got customer with identifire for : " + objEMSData.strUserName);

                            }
                        }
                        catch (Exception ex)
                        {
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : Checking Identifier" + ex.ToString());
                            _objMyCustomer = null;
                            bIsDuplicate = false;
                            bUpdateData = false;
                        }
                    }
                    if (!bIsDuplicate)
                    {
                        foreach (SummitShopApp.BL.MyCustomerBL objMyCustomer in lstMyCustomer)
                        {

                            //for older file that has been imported and don't have unique file identifier then check for name,year,make,model and mobile #
                            if (String.IsNullOrEmpty(objMyCustomer.strEstimateFileIdentifier))
                            {
                                bIsDuplicate = IsEqualsNew(objMyCustomer, objEMSData);
                            }
                            // else check with unique file identifier
                            else
                            {
                                if (objEMSData.strEstimateFileId != null && objMyCustomer.strEstimateFileIdentifier != null && String.Equals(objMyCustomer.strEstimateFileIdentifier.ToLower().Trim(), objEMSData.strEstimateFileId.ToLower().Trim()))
                                {
                                    bIsDuplicate = true;
                                }
                                //if EstimateID is different then again check with five fields
                                else
                                {
                                    bIsDuplicate = IsEqualsNew(objMyCustomer, objEMSData);
                                }
                            }
                            if (bIsDuplicate)
                            {
                                bUpdateData = true;
                                _objMyCustomer = objMyCustomer;
                                break;
                            }

                        }
                    }
                }

                if (!bIsDuplicate)
                {
                    Boolean bIsDeleted = false;

                    if (lstDeletedUsers != null && lstDeletedUsers.Count > 0)
                    {
                        foreach (SummitShopApp.BL.InProcessUsersBL objInProcessObject in lstDeletedUsers)
                        {
                            //for older file that has been imported and don't have unique file identifier then check for name,year,make,model and mobile #
                            if (String.IsNullOrEmpty(objInProcessObject.strEstimateFileIdentifier))
                            {
                                bIsDeleted = IsEquals(objInProcessObject, objEMSData);
                            }
                            // else check with unique file identifier
                            else
                            {
                                if (objEMSData.strEstimateFileId != null && String.Equals(objInProcessObject.strEstimateFileIdentifier.ToLower().Trim(), objEMSData.strEstimateFileId.ToLower().Trim()))
                                {
                                    bIsDeleted = true;
                                }
                                //if EstimateID is different then again check with five fields
                                else
                                {
                                    bIsDeleted = IsEquals(objInProcessObject, objEMSData);
                                }
                            }
                            if (bIsDeleted)
                            {
                                //bUpdateData = true;
                                _objMyCustomer = null;
                                break;
                            }
                        }
                    }
                    if (!bIsDeleted)
                    {
                        //Code added for Delivery Date - START
                        Boolean IsDelivered = false;
                        Boolean IsUnsoldEstimate = false;
                        Boolean IsRepairOrder = false;
                        DateTime dtDeliveryDateTemp;
                        DateTime? dtDeliveryDate = null;
                        //Move to Marketign for Imported Estimate
                        Boolean bIsMoveToMarketing = false;
                        try
                        {
                            SummitShopApp.BL.VehicleStatusBL objVehicleStatus = SummitShopApp.BL.VehicleStatusBL.getDataByShopIdAndStatus(iAILogicShopID, "Imported Estimate");
                            if (objVehicleStatus != null && objVehicleStatus.bMoveToMarketing.HasValue)
                            {
                                bIsMoveToMarketing = objVehicleStatus.bMoveToMarketing.Value;
                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Imported Estimate has set Rule 'Move To Marketing' to true");
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            dtDeliveryDate = DateTime.TryParse(objEMSData.strDeliveryDate, out dtDeliveryDateTemp) ? dtDeliveryDateTemp : (Nullable<DateTime>)null;
                            if (dtDeliveryDate.HasValue && dtDeliveryDate.Value >= Convert.ToDateTime("01/01/1970"))
                            {
                                IsDelivered = true;//TODO - True
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                        SummitShopApp.BL.UserBL objUser = new SummitShopApp.BL.UserBL();

                        String strFormatedUserName = String.IsNullOrEmpty(objEMSData.strUserName) ? String.Empty : objEMSData.strUserName.Trim();
                        if (strFormatedUserName.Length > 50)
                        {
                            strFormatedUserName = strFormatedUserName.Substring(0, 50);
                        }
                        objUser.strUserName = strFormatedUserName;
                        objUser.strFirstName = objEMSData.strOwnerFirstName;
                        objUser.strLastName = objEMSData.strOwnerLastName;
                        objUser.strPhone = objEMSData.strOwnerPhone1;
                        objUser.strPhone2 = objEMSData.strOwnerPhone2;

                        String strFormatedEmail = String.IsNullOrEmpty(objEMSData.strOwnerEmail) ? String.Empty : objEMSData.strOwnerEmail.Trim();
                        if (strFormatedEmail.Length > 50)
                        {
                            strFormatedEmail = strFormatedEmail.Substring(0, 50);
                        }

                        objUser.strEmail = strFormatedEmail;
                        objUser.strAddress1 = objEMSData.strOwnerAddress1;
                        objUser.strAddress2 = objEMSData.strOwnerAddress2;
                        objUser.strCity = objEMSData.strOwnerCity;
                        objUser.strState = objEMSData.strOwnerState;
                        objUser.strZip = objEMSData.strOwnerZipCode;
                        if (!String.IsNullOrEmpty(Request.QueryString["ImportEMSDataTo"]) && (Request.QueryString["ImportEMSDataTo"].ToLower() == "emailmarketing" || Request.QueryString["ImportEMSDataTo"].ToLower() == "textmarketing"))
                        {
                            objUser.bIsShowEmailMarketing = true;
                            objUser.bIsShowTextMarketing = true;
                        }

                        //Code added for Delivery Date - START
                        if (IsDelivered || bIsMoveToMarketing)
                        {
                            objUser.bIsShowEmailMarketing = true;
                            objUser.bIsShowTextMarketing = true;
                        }
                        //Code added for Delivery Date - END

                        objUser.dtUpdatedEntryTime = DateTime.Now;
                        if (objUser.Save())
                        {
                            SummitShopApp.BL.VehicleInfoBL objVehicleInfo = new SummitShopApp.BL.VehicleInfoBL();
                            objVehicleInfo.iUserId = objUser.ID;
                            objVehicleInfo.strYear = objEMSData.strYear;
                            objVehicleInfo.strMake = objEMSData.strMake;
                            objVehicleInfo.strModel = objEMSData.strModel;
                            objVehicleInfo.strStyle = objEMSData.strStyle;
                            objVehicleInfo.strColor = objEMSData.strColor;
                            objVehicleInfo.strPaintCode = objEMSData.strPaintCode;
                            objVehicleInfo.strVIN = objEMSData.strVIN;
                            objVehicleInfo.strLicense = objEMSData.strLicense;
                            objVehicleInfo.strEstimatorName = objEMSData.strEstimatorName;
                            objVehicleInfo.strEstimateFileIdentifier = objEMSData.strEstimateFileId;
                            DateTime dtProductionDate;
                            objVehicleInfo.dtProductionDate = DateTime.TryParse("", out dtProductionDate) ? dtProductionDate : (Nullable<DateTime>)null;
                            objVehicleInfo.bIsUsing = true;
                            objVehicleInfo.Save();
                            SummitShopApp.BL.MarketingUsers objMarUser = new SummitShopApp.BL.MarketingUsers();
                            objMarUser.iShopId = iAILogicShopID;
                            objMarUser.iUserId = objUser.ID;
                            objMarUser.iVehicleId = objVehicleInfo.ID;
                            //Code added for Delivery Date - START
                            if (IsDelivered || bIsMoveToMarketing)
                                objMarUser.bisShowInProcess = false;
                            else
                                objMarUser.bisShowInProcess = true;
                            //Code added for Delivery Date - END

                            objMarUser.iVehicleId = objVehicleInfo.ID;
                            objMarUser.Save();

                            SummitShopApp.BL.UserVehicleStatusBL objCustomerVehicleStatus = new SummitShopApp.BL.UserVehicleStatusBL();
                            objCustomerVehicleStatus.iUserId = objUser.ID;
                            objCustomerVehicleStatus.iVehicleId = objVehicleInfo.ID;

                            //21915 - Ankeny Auto Body
                            //63470 - Faith Auto Works
                            //62555 - Steves test shop

                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic(" - - - - - New User Method Starts");
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("shop : " + objMarUser.iShopId + " New User : " + objUser.ID + " usename : " + objUser.strUserName);
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("RO Number: " + objEMSData.strRONumbert);
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Date In : " + objEMSData.strDateIn);
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("RO Complition Date: " + objEMSData.strDateOut_Ro_Cmp_Date);
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Tar Date Out: " + objEMSData.strDateOut_Tar_Date);

                            //If we get the Env.RO_No field, it will be saved in the 'RO Number' field and the status of the file would be 'Repair Order' - 3 Hrs
                            try
                            {
                                if (!String.IsNullOrEmpty(objEMSData.strRONumbert) && !objEMSData.strRONumbert.Trim().Equals("0"))
                                {
                                    IsRepairOrder = true;
                                }
                            }
                            catch (Exception)
                            {
                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : RO Exception For New User - - - - -  : while Checking RO Number " + objEMSData.strRONumbert + " of Shop :" + objMarUser.iShopId + " New User : " + objUser.ID + " usename : " + objUser.strUserName);
                            }

                            DateTime dtDateInTemp;
                            DateTime? dtDateIn = null;
                            try
                            {
                                dtDateIn = DateTime.TryParse(objEMSData.strDateIn, out dtDateInTemp) ? dtDateInTemp : (Nullable<DateTime>)null;
                                if (dtDateIn.HasValue && dtDateIn.Value >= Convert.ToDateTime("01/01/1970"))
                                {
                                    objCustomerVehicleStatus.dtDateIn = dtDateIn;
                                    IsRepairOrder = true;
                                }
                            }
                            catch (Exception ex)
                            {
                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : New User Method Save() - - - - -  : while Checking RO Date IN of Shop :" + objMarUser.iShopId + " New User : " + objUser.ID + " usename : " + objUser.strUserName);
                            }

                            DateTime dtDateOutTemp_TAR_DATE;
                            DateTime? dtDateOut_TAR_DATE;
                            DateTime dtDateOutTemp_RO_CMPDATE;
                            DateTime? dtDateOut_RO_CMPDATE;
                            try
                            {
                                dtDateOut_RO_CMPDATE = DateTime.TryParse(objEMSData.strDateOut_Ro_Cmp_Date, out dtDateOutTemp_RO_CMPDATE) ? dtDateOutTemp_RO_CMPDATE : (Nullable<DateTime>)null;
                                dtDateOut_TAR_DATE = DateTime.TryParse(objEMSData.strDateOut_Tar_Date, out dtDateOutTemp_TAR_DATE) ? dtDateOutTemp_TAR_DATE : (Nullable<DateTime>)null;

                                if (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value >= Convert.ToDateTime("01/01/1970"))
                                {
                                    objCustomerVehicleStatus.dtDateOut = dtDateOut_TAR_DATE;
                                }
                                else if (dtDateOut_RO_CMPDATE.HasValue && dtDateOut_RO_CMPDATE.Value >= Convert.ToDateTime("01/01/1970"))
                                {
                                    objCustomerVehicleStatus.dtDateOut = dtDateOut_RO_CMPDATE;
                                }

                                //added code for
                                //If we get the RO_TAR_Date for a customer, need to set that file to 'Delivered' with the delivery date being set what the TAR_Date field has - 4 Hrs
                                //If the Tar_Date is a future date we should mark the file as 'Delivered' and start the triggers(automation emails and sms) if the Tar_Date is equal to the actual date 
                                //15 April 2016 Changes 
                                //1. where the Date_Out will replace the Tar_Date and the customer will be marked as delivered when there is Date_Out for an estimate
                                //2. where tghe customer should be in Repair Order Status if the Tar_Date is a future date and should change to delivered when the Tar_Date is equal to or greater than the actual date
                                try
                                {
                                    if ((dtDateOut_RO_CMPDATE.HasValue && dtDateOut_RO_CMPDATE.Value >= Convert.ToDateTime("01/01/1970")) || (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value >= Convert.ToDateTime("01/01/1970")))
                                    {


                                        if (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value >= Convert.ToDateTime("01/01/1970"))
                                        {
                                            dtDeliveryDate = dtDateOut_TAR_DATE.Value;
                                        }
                                        if (dtDateOut_RO_CMPDATE.HasValue && dtDateOut_RO_CMPDATE.Value >= Convert.ToDateTime("01/01/1970"))
                                        {
                                            dtDeliveryDate = dtDateOut_RO_CMPDATE.Value;
                                        }
                                        if (dtDeliveryDate.Value > DateTime.Now)
                                        {
                                            IsRepairOrder = true;
                                            objCustomerVehicleStatus.dtDeliveryDate = dtDeliveryDate;
                                        }
                                        else
                                        {
                                            IsDelivered = true;
                                            IsUnsoldEstimate = false;
                                            IsRepairOrder = false;
                                        }

                                    }

                                }
                                catch (Exception ex)
                                {
                                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic(" Exception :  New User Method Save() - - - - -  : while Checking dtDateOut_RO_CMPDATE dtDateOut_TAR_DATE of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());

                                }
                                try
                                {
                                    //If we do not get the RO_In_Date, Tar_Date and Env_RO_No, then the status of that file would be 'Unsold Estimate' - 3 Hrs
                                    if (!IsDelivered && !IsRepairOrder && (dtDateOut_TAR_DATE == null || (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value <= Convert.ToDateTime("01/01/1970"))))
                                    {

                                        IsUnsoldEstimate = true;
                                        IsDelivered = false;
                                        IsRepairOrder = false;

                                    }

                                }
                                catch (Exception ex)
                                {
                                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic(" Exception : New User Method Save() - - - - -  : while making Unsold of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                                }
                            }
                            catch (Exception ex)
                            {
                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic(" Exception : New User Method Save() - - - - -  : while checking the New Dates of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                            }


                            System.Collections.Generic.List<SummitShopApp.BL.VehicleStatusBL> lstVehicleStatus = new System.Collections.Generic.List<SummitShopApp.BL.VehicleStatusBL>();
                            lstVehicleStatus = SummitShopApp.BL.VehicleStatusBL.getDataByShopId(iAILogicShopID);


                            if (lstVehicleStatus != null)
                            {
                                try
                                {

                                    objUser = SummitShopApp.BL.UserBL.getByActivityId(objMarUser.iUserId);
                                    objMarUser = SummitShopApp.BL.MarketingUsers.getDataByShopAndUserId(objMarUser.iShopId, objMarUser.iUserId);

                                    try
                                    {
                                        SummitShopApp.BL.VehicleStatusBL objVehicleStatusImportEstimateBL = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim() == "imported estimate");

                                        if (objVehicleStatusImportEstimateBL != null)
                                        {
                                            iVehicleStatusId = objVehicleStatusImportEstimateBL.ID;
                                            bMatch = true;
                                        }

                                        if (IsDelivered)
                                        {
                                            bMatch = true;
                                            objMarUser.bisShowInProcess = false;

                                            objUser.bIsShowEmailMarketing = true;
                                            objUser.bIsShowTextMarketing = true;
                                            objUser.dtUpdatedEntryTime = DateTime.Now;

                                            SummitShopApp.BL.VehicleStatusBL objVehicleStatusBL = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim() == "delivered");
                                            if (objVehicleStatusBL != null)
                                            {
                                                iVehicleStatusId = objVehicleStatusBL.ID;
                                                bMatch = true;
                                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("shop : " + objMarUser.iShopId + " User : " + objUser.ID + " UserName " + objUser.strUserName + " Status : delivered");
                                                //SummitShopApp.Utility.CommonFunctions.SaveUserAuditTrail(objVehicleStatusBL.ID, objMarUser.iUserId, objMarUser.iVehicleId);
                                                //SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Updated Entry in User Audit Trail Table for status : Delivered");
                                            }
                                        }
                                        if (IsUnsoldEstimate)
                                        {
                                            bMatch = true;
                                            objMarUser.bisShowInProcess = false;

                                            objUser.bIsShowEmailMarketing = true;
                                            objUser.bIsShowTextMarketing = true;
                                            objUser.dtUpdatedEntryTime = DateTime.Now;

                                            SummitShopApp.BL.VehicleStatusBL objVehicleStatusBL = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim() == "unsold estimate");
                                            if (objVehicleStatusBL != null)
                                            {
                                                iVehicleStatusId = objVehicleStatusBL.ID;
                                                bMatch = true;
                                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("shop : " + objMarUser.iShopId + " User : " + objUser.ID + " UserName " + objUser.strUserName + " Status : unsold estimate");
                                                //SummitShopApp.Utility.CommonFunctions.SaveUserAuditTrail(objVehicleStatusBL.ID, objMarUser.iUserId, objMarUser.iVehicleId);
                                                //SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Updated Entry in User Audit Trail Table for status : unsold Estimate");
                                            }
                                        }
                                        if (IsRepairOrder)
                                        {
                                            bMatch = true;
                                            objMarUser.bisShowInProcess = true;
                                            objUser.bIsShowEmailMarketing = false;
                                            objUser.bIsShowTextMarketing = false;
                                            objUser.dtUpdatedEntryTime = DateTime.Now;

                                            SummitShopApp.BL.VehicleStatusBL objVehicleStatusBL = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim() == "in process repairs");
                                            if (objVehicleStatusBL != null)
                                            {
                                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("shop : " + objMarUser.iShopId + " User : " + objUser.ID + " UserName " + objUser.strUserName + " Status : in process repairs");
                                                iVehicleStatusId = objVehicleStatusBL.ID;
                                                bMatch = true;
                                                if (objVehicleStatusBL.bMoveToMarketing.HasValue)
                                                {
                                                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("In Process Repairs (RO Number) has set Rule 'Move To Marketing' to true - customer moved to marketing area");
                                                    bIsMoveToMarketing = objVehicleStatusBL.bMoveToMarketing.Value;
                                                    objMarUser.bisShowInProcess = !bIsMoveToMarketing;
                                                    objUser.bIsShowEmailMarketing = bIsMoveToMarketing;
                                                    objUser.bIsShowTextMarketing = bIsMoveToMarketing;
                                                    //SummitShopApp.Utility.CommonFunctions.SaveUserAuditTrail(objVehicleStatusBL.ID, objMarUser.iUserId, objMarUser.iVehicleId);
                                                    //SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Updated Entry in User Audit Trail Table for status : In Process Repairs (Repair Order)");
                                                }
                                            }
                                        }
                                        objMarUser.Save();
                                        objUser.Save();

                                    }
                                    catch (Exception ex)
                                    {
                                        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : New User Method Save() - - - - -  : while applying the New status of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                                    }

                                }
                                catch (Exception ex)
                                {
                                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : New User Method Save() - - - - -  : while applying the New status of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                                }
                            }

                            //Code added for Delivery Date - END

                            if (bMatch)
                            {
                                objCustomerVehicleStatus.iVehicleStatusId = iVehicleStatusId;
                                objCustomerVehicleStatus.dtLastUpdatedStatusDate = DateTime.Now;
                                //Code added for Delivery Date - START
                                if (IsDelivered)
                                {
                                    objCustomerVehicleStatus.dtDeliveryDate = dtDeliveryDate;

                                    //Add records into reoccuring and scheuduled campaign for delivered vehicle status
                                    try
                                    {
                                        //Add record into another table AIManageRecurringActivity - it will processed by AIManageRecurringActivity Service
                                        SummitShopApp.BL.AIManageRecurringActivityBL objAIManageRecurringActivityBL = SummitShopApp.BL.AIManageRecurringActivityBL.getDataByShopIdUserIdAndDeliveryDate(objUser.ID, iAILogicShopID, dtDeliveryDate.Value);
                                        if (objAIManageRecurringActivityBL == null)
                                        {
                                            objAIManageRecurringActivityBL = new SummitShopApp.BL.AIManageRecurringActivityBL();
                                            objAIManageRecurringActivityBL.iShopId = iAILogicShopID;
                                            objAIManageRecurringActivityBL.iUserId = objUser.ID;
                                            objAIManageRecurringActivityBL.dtDeliveryDate = dtDeliveryDate.Value;
                                            objAIManageRecurringActivityBL.Save();
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception :  New User Method Save() - - - - -  :for delivered status of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());

                                    }

                                }
                                //Code added for Delivery Date - END
                            }
                            else
                            {
                                SummitShopApp.BL.VehicleStatusBL _objVehicleStatus = new SummitShopApp.BL.VehicleStatusBL();
                                _objVehicleStatus.strVehicleStatus = "Imported Estimate";
                                _objVehicleStatus.strMessage = String.Empty;
                                _objVehicleStatus.iShopId = iAILogicShopID;
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

                            SummitShopApp.Utility.CommonFunctions.SaveUserAuditTrail(objCustomerVehicleStatus.iVehicleStatusId.Value, objMarUser.iUserId, objMarUser.iVehicleId);
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Updated Entry in User Audit Trail Table for status : " + objCustomerVehicleStatus.iVehicleStatusId.Value);

                            SummitShopApp.BL.InsuranceInformationBL objInsurance = new SummitShopApp.BL.InsuranceInformationBL();
                            objInsurance.iUserId = objUser.ID;
                            objInsurance.strCompanyName = objEMSData.strInsuranceCompanyName;
                            objInsurance.strCompanyAddress = objEMSData.strInsuranceCompanyAddress;
                            objInsurance.strCompanyCity = objEMSData.strInsuranceCompanyCity;
                            objInsurance.strCompanyState = objEMSData.strInsuranceCompanyState;
                            objInsurance.strCompanyZip = objEMSData.strInsuranceCompanyZipCode;
                            objInsurance.strCompanyEmail = objEMSData.strInsuranceCompanyEmail;
                            objInsurance.strCompanyCellPhone = objEMSData.strInsuranceCompanyPhone;
                            objInsurance.strCompanyFax = objEMSData.strInsuranceCompanyFax;
                            objInsurance.strAgentName = objEMSData.strInsuranceAgentName;
                            objInsurance.strClaimNumber = objEMSData.strClaimNumber;
                            if (!String.IsNullOrEmpty(objEMSData.strRONumbert) && !objEMSData.strRONumbert.Trim().Equals("0"))
                                objInsurance.strROIdentifier = objEMSData.strRONumbert;
                            else
                                objInsurance.strROIdentifier = String.Empty;
                            objInsurance.strNetTotalAmount = objEMSData.strNetTotalAmount;
                            DateTime dtDateofLoss;
                            Decimal dDeductible;
                            DateTime.TryParse(objInsurance.dtDateOfLoss.ToString(), out dtDateofLoss);
                            objInsurance.dtDateOfLoss = DateTime.TryParse(objEMSData.strDateOfLoss, out dtDateofLoss) ? dtDateofLoss : (Nullable<DateTime>)null;
                            objInsurance.dDeductible = Decimal.TryParse(objEMSData.strDeductible, out dDeductible) ? dDeductible : (Nullable<Decimal>)null;
                            objInsurance.Save();
                        }
                        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("New User Method Save END ()");
                        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic(Environment.NewLine);
                    }
                }
                #region Update Sync data
                //If file is already imported and matched with unique file idetifier then update data
                if (bUpdateData && _objMyCustomer != null)
                    updateEMSData_New(_objMyCustomer, objEMSData);
                #endregion
            }
        }
    }

    /// <summary>
    /// Method to add reoccuring and scheuduled campaign for delivered vehicle status
    /// </summary>
    /// <param name="iShopId">Shop Id</param>
    /// <param name="iUserId">User Id</param>
    /// <param name="dtDeliveryDate">Delivery Date</param>
    //private void CreateReoccuringScheduledUser(Int32 iShopId, Int32 iUserId, DateTime dtDeliveryDate)
    //{
    //    System.Collections.Generic.List<SummitShopApp.BL.FrequencyBL> lstFrequency = SummitShopApp.BL.FrequencyBL.getFrequencyList();
    //    if (lstFrequency != null && lstFrequency.Count > 0)
    //    {
    //        //code to delete null entries from ReocurringCampaignUsers Table to remove duplicates
    //        SummitShopApp.BL.ReocurringCampaignUsersBL.deleteRecordsForNull(iUserId, iShopId);
    //        foreach (SummitShopApp.BL.FrequencyBL objFrequency in lstFrequency)
    //        {
    //            try
    //            {
    //                //schedule only if days are  not elasped                                    
    //                if (objFrequency.iDays > DateTime.Now.Subtract(dtDeliveryDate).Days)
    //                {
    //                    SummitShopApp.BL.ReocurringCampaignUsersBL ReoccuringUser = null;
    //                    ReoccuringUser = SummitShopApp.BL.ReocurringCampaignUsersBL.getDataByShopIdUserIdAndFreqId(iShopId, iUserId, objFrequency.iID);
    //                    if (ReoccuringUser == null)
    //                        ReoccuringUser = new SummitShopApp.BL.ReocurringCampaignUsersBL();
    //                    ReoccuringUser.bIsMailSent = true;
    //                    ReoccuringUser.bIsSmsSent = true;
    //                    ReoccuringUser.dtDeliveredDate = dtDeliveryDate;
    //                    ReoccuringUser.iUserID = iUserId;
    //                    ReoccuringUser.iShopID = iShopId;
    //                    ReoccuringUser.iFrequencyID = objFrequency.iID;
    //                    if (ReoccuringUser.Save())
    //                    {
    //                        //save the schedule user
    //                        SummitShopApp.BL.ScheduledUsersBL objScheduleUser = SummitShopApp.BL.ScheduledUsersBL.getDataByUserIdShopIdAndFrequencyId(ReoccuringUser.iUserID.Value, ReoccuringUser.iShopID.Value, objFrequency.iID);
    //                        if (objScheduleUser == null)
    //                            objScheduleUser = new SummitShopApp.BL.ScheduledUsersBL();
    //                        objScheduleUser.iUserId = ReoccuringUser.iUserID.Value;
    //                        objScheduleUser.iShopId = ReoccuringUser.iShopID.Value;
    //                        objScheduleUser.iFrequency = objFrequency.iID;
    //                        objScheduleUser.dtSendDate = dtDeliveryDate.AddDays(objFrequency.iDays);
    //                        objScheduleUser.bIsMailSent = true;
    //                        objScheduleUser.bIsSmsSent = true;
    //                        objScheduleUser.Save();
    //                    }
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
    //            }
    //        }
    //    }
    //}
    /// <summary>
    /// Update user data
    /// </summary>
    /// <param name="iUserId"></param>
    /// <param name="objEMSData"></param>
    /// <returns></returns>
    private Boolean updateUserData_New(SummitShopApp.BL.MyCustomerBL objMyCustomer, SummitShopApp.Utility.EMSData objEMSData)
    {
        try
        {
            //Get user object from database using user_id
            SummitShopApp.BL.UserBL objUser = SummitShopApp.BL.UserBL.getByActivityId(objMyCustomer.iUserId.Value);
            if (objUser != null)
            {
                if (!String.IsNullOrEmpty(objEMSData.strOwnerPhone1))
                    objUser.strPhone = objEMSData.strOwnerPhone1;

                if (!String.IsNullOrEmpty(objEMSData.strOwnerPhone2))
                    objUser.strPhone2 = objEMSData.strOwnerPhone2;

                if (!String.IsNullOrEmpty(objEMSData.strOwnerEmail))
                {
                    String strFormatedEmail = String.IsNullOrEmpty(objEMSData.strOwnerEmail) ? String.Empty : objEMSData.strOwnerEmail.Trim();
                    if (strFormatedEmail.Length > 50)
                    {
                        strFormatedEmail = strFormatedEmail.Substring(0, 50);
                    }
                    objUser.strEmail = strFormatedEmail;
                }

                if (!String.IsNullOrEmpty(objEMSData.strOwnerAddress1))
                    objUser.strAddress1 = objEMSData.strOwnerAddress1;

                if (!String.IsNullOrEmpty(objEMSData.strOwnerAddress2))
                    objUser.strAddress2 = objEMSData.strOwnerAddress2;

                if (!String.IsNullOrEmpty(objEMSData.strOwnerCity))
                    objUser.strCity = objEMSData.strOwnerCity;

                if (!String.IsNullOrEmpty(objEMSData.strOwnerState))
                    objUser.strState = objEMSData.strOwnerState;

                if (!String.IsNullOrEmpty(objEMSData.strOwnerZipCode))
                    objUser.strZip = objEMSData.strOwnerZipCode;

                return objUser.Save();
            }
        }
        catch (Exception ex)
        {
            Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
        }
        return false;
    }
    /// <summary>
    /// Sync the data from EMS file with data into database, if file was imported before.
    /// </summary>
    /// <param name="objInProcessUser"></param>
    /// <param name="objEMSData"></param>
    private void updateEMSData_New(SummitShopApp.BL.MyCustomerBL objMyCustomer, SummitShopApp.Utility.EMSData objEMSData)
    {
        try
        {
            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic(Environment.NewLine + "updateEMSData_New() start " + Environment.NewLine + "---------------------- UserName " + objMyCustomer.strUserName + " Shop : " + objMyCustomer.iShopId + " User : " + objMyCustomer.iUserId + " Current Status : " + objMyCustomer.iVehicleStatus + Environment.NewLine + "---------------------- Delivery Date " + objEMSData.strDeliveryDate + Environment.NewLine + " ---------------------- RO Number: " + objEMSData.strRONumbert + Environment.NewLine + "---------------------- Date In : " + objEMSData.strDateIn + Environment.NewLine + "---------------------- RO Complition Date: " + objEMSData.strDateOut_Ro_Cmp_Date + Environment.NewLine + "---------------------- Tar Date Out: " + objEMSData.strDateOut_Tar_Date);

            //Code added for Delivery Date - START
            Boolean IsDelivered = false;
            DateTime dtDeliveryDateTemp;
            DateTime? dtDeliveryDate = null;
            Boolean IsUnsoldEstimate = false;
            Boolean IsRepairOrder = false;

            Boolean bIsMoveToMarketing = false;
            try
            {
                SummitShopApp.BL.VehicleStatusBL objVehicleStatus = SummitShopApp.BL.VehicleStatusBL.getDataByShopIdAndStatus(objMyCustomer.iShopId, "Imported Estimate");
                if (objVehicleStatus != null && objVehicleStatus.bMoveToMarketing.HasValue)
                {
                    bIsMoveToMarketing = objVehicleStatus.bMoveToMarketing.Value;
                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Imported Estimate has set Rule 'Move To Marketing' to true");
                }
            }
            catch (Exception) { }

            try
            {
                dtDeliveryDate = DateTime.TryParse(objEMSData.strDeliveryDate, out dtDeliveryDateTemp) ? dtDeliveryDateTemp : (Nullable<DateTime>)null;
                if (dtDeliveryDate.HasValue && dtDeliveryDate.Value >= Convert.ToDateTime("01/01/1970"))
                {
                    IsDelivered = true;//TODO - True
                }
            }
            catch (Exception ex)
            {
                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : While Converting the strDeliveryDate");
            }
            //Update the Vehicle Info
            if (objMyCustomer.iVehicleId.HasValue)
                updateVehicleData(objMyCustomer.iVehicleId.Value, objEMSData);


            //Update the New User Data
            if (objMyCustomer.iUserId.HasValue && updateUserData_New(objMyCustomer, objEMSData))
            {
                //Update the Vehicle Status
                SummitShopApp.BL.UserVehicleStatusBL objCustomerVehicleStatus = null;
                if (objMyCustomer.iVehicleId.HasValue)
                {
                    objCustomerVehicleStatus = SummitShopApp.BL.UserVehicleStatusBL.getDataByVehicleId(objMyCustomer.iVehicleId.Value);
                    if (objCustomerVehicleStatus == null)
                    {
                        objCustomerVehicleStatus = new SummitShopApp.BL.UserVehicleStatusBL();
                    }
                    objCustomerVehicleStatus.iUserId = objMyCustomer.iUserId.Value;
                    objCustomerVehicleStatus.iVehicleId = objMyCustomer.iVehicleId.Value;
                    if (IsDelivered)
                    {
                        objCustomerVehicleStatus.dtDeliveryDate = dtDeliveryDate;
                    }

                    //if (objCustomerVehicleStatus.Save())
                    //{
                    //SummitShopApp.BL.MarketingUsers objMarketingUser = SummitShopApp.BL.MarketingUsers.getDataByShopUserAndVehicleId(objMyCustomer.iShopId, objMyCustomer.iUserId.Value, objMyCustomer.iVehicleId.Value);
                    //if (objMarketingUser != null)
                    //{
                    //    objMarketingUser.bisShowInProcess = false;
                    //    objMarketingUser.Save();
                    //}

                    //}

                    SummitShopApp.BL.UserBL objUser = SummitShopApp.BL.UserBL.getByActivityId(objMyCustomer.iUserId.Value);
                    SummitShopApp.BL.MarketingUsers objMarUser = SummitShopApp.BL.MarketingUsers.getDataByShopAndUserId(objMyCustomer.iShopId, objMyCustomer.iUserId.Value);

                    //If we get the Env.RO_No field, it will be saved in the 'RO Number' field and the status of the file would be 'Repair Order' - 3 Hrs

                    try
                    {
                        if (!String.IsNullOrEmpty(objEMSData.strRONumbert) && !objEMSData.strRONumbert.Trim().Equals("0"))
                        {
                            IsRepairOrder = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : Update User Method () - - - - -  :for checking the RO Number of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                    }

                    //If we get the RO_In_Date for a customer, need to set that file to 'Repair Order' status - 3 Hrs
                    //If we get both RO_In_Date and the Env.RO_No for a customer, need to set that file to 'Repair Order' status - 0 Hrs [Handled in above 2 conditions]
                    DateTime dtDateInTemp;
                    DateTime? dtDateIn = null;
                    try
                    {
                        dtDateIn = DateTime.TryParse(objEMSData.strDateIn, out dtDateInTemp) ? dtDateInTemp : (Nullable<DateTime>)null;
                        if (dtDateIn.HasValue && dtDateIn.Value >= Convert.ToDateTime("01/01/1970"))
                        {
                            objCustomerVehicleStatus.dtDateIn = dtDateIn;
                            IsRepairOrder = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : Update User Method () - - - - -  :for checking the RO Date In of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                    }

                    DateTime dtDateOutTemp_TAR_DATE;
                    DateTime? dtDateOut_TAR_DATE;
                    DateTime dtDateOutTemp_RO_CMPDATE;
                    DateTime? dtDateOut_RO_CMPDATE;
                    try
                    {
                        dtDateOut_RO_CMPDATE = DateTime.TryParse(objEMSData.strDateOut_Ro_Cmp_Date, out dtDateOutTemp_RO_CMPDATE) ? dtDateOutTemp_RO_CMPDATE : (Nullable<DateTime>)null;
                        dtDateOut_TAR_DATE = DateTime.TryParse(objEMSData.strDateOut_Tar_Date, out dtDateOutTemp_TAR_DATE) ? dtDateOutTemp_TAR_DATE : (Nullable<DateTime>)null;

                        if (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value >= Convert.ToDateTime("01/01/1970"))
                        {
                            objCustomerVehicleStatus.dtDateOut = dtDateOut_TAR_DATE;
                        }
                        else if (dtDateOut_RO_CMPDATE.HasValue && dtDateOut_RO_CMPDATE.Value >= Convert.ToDateTime("01/01/1970"))
                        {
                            objCustomerVehicleStatus.dtDateOut = dtDateOut_RO_CMPDATE;
                        }
                        //added code for
                        //If we get the RO_TAR_Date for a customer, need to set that file to 'Delivered' with the delivery date being set what the TAR_Date field has - 4 Hrs
                        //If the Tar_Date is a future date we should mark the file as 'Delivered' and start the triggers(automation emails and sms) if the Tar_Date is equal to the actual date 

                        //15 April 2016 Changes 
                        //1. where the Date_Out will replace the Tar_Date and the customer will be marked as delivered when there is Date_Out for an estimate
                        //2. where tghe customer should be in Repair Order Status if the Tar_Date is a future date and should change to delivered when the Tar_Date is equal to or greater than the actual date
                        try
                        {
                            if ((dtDateOut_RO_CMPDATE.HasValue && dtDateOut_RO_CMPDATE.Value >= Convert.ToDateTime("01/01/1970")) || (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value >= Convert.ToDateTime("01/01/1970")))
                            {

                                if (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value >= Convert.ToDateTime("01/01/1970"))
                                {
                                    dtDeliveryDate = dtDateOut_TAR_DATE.Value;
                                }
                                if (dtDateOut_RO_CMPDATE.HasValue && dtDateOut_RO_CMPDATE.Value >= Convert.ToDateTime("01/01/1970"))
                                {
                                    dtDeliveryDate = dtDateOut_RO_CMPDATE.Value;
                                }
                                if (dtDeliveryDate.Value > DateTime.Now)
                                {
                                    IsRepairOrder = true;
                                    objCustomerVehicleStatus.dtDeliveryDate = dtDeliveryDate;
                                }
                                else
                                {
                                    IsDelivered = true;
                                    IsUnsoldEstimate = false;
                                    IsRepairOrder = false;

                                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Update shop : " + objMyCustomer.iShopId + " User : " + objMyCustomer.iUserId + " UserName " + objMyCustomer.strUserName + " dtDateOut_TAR_DATE " + dtDateOut_TAR_DATE.Value.ToString() + "Converted Status : Delivered ");
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : Update User Method () - - - - -  :for TarDate and RO cmp Date conversion In of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                        }
                        try
                        {
                            //If we do not get the RO_In_Date, Tar_Date and Env_RO_No, then the status of that file would be 'Unsold Estimate' - 3 Hrs
                            if (!IsDelivered && !IsRepairOrder && (dtDateOut_TAR_DATE == null || (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value <= Convert.ToDateTime("01/01/1970"))))
                            {

                                IsUnsoldEstimate = true;
                                IsDelivered = false;
                                IsRepairOrder = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception :  Update User Method () - - - - -  :for unsold Estimate Flag conversion In of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());

                        }
                        System.Collections.Generic.List<SummitShopApp.BL.VehicleStatusBL> lstVehicleStatus = new System.Collections.Generic.List<SummitShopApp.BL.VehicleStatusBL>();
                        lstVehicleStatus = SummitShopApp.BL.VehicleStatusBL.getDataByShopId(objMyCustomer.iShopId);

                        if (IsDelivered)
                        {
                            objMarUser.bisShowInProcess = false;
                            objUser.bIsShowEmailMarketing = true;
                            objUser.bIsShowTextMarketing = true;


                            SummitShopApp.BL.VehicleStatusBL objVehicleStatusBL = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim() == "delivered");
                            if (objVehicleStatusBL != null)
                            {
                                if (objCustomerVehicleStatus.iVehicleStatusId.HasValue && objCustomerVehicleStatus.iVehicleStatusId != objVehicleStatusBL.ID)
                                {
                                    SummitShopApp.Utility.CommonFunctions.SaveUserAuditTrail(objCustomerVehicleStatus.iVehicleStatusId.Value, objMarUser.iUserId, objMarUser.iVehicleId);
                                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Updated Entry in User Audit Trail Table for old status ID : " + objCustomerVehicleStatus.iVehicleStatusId.Value);

                                    objCustomerVehicleStatus.dtLastUpdatedStatusDate = DateTime.Now;
                                    objUser.dtUpdatedEntryTime = DateTime.Now;
                                }

                                objCustomerVehicleStatus.iVehicleStatusId = objVehicleStatusBL.ID;
                                objCustomerVehicleStatus.dtDeliveryDate = dtDeliveryDate;
                                //Add record into another table AIManageRecurringActivity - it will processed by AIManageRecurringActivity Service
                                SummitShopApp.BL.AIManageRecurringActivityBL objAIManageRecurringActivityBL = SummitShopApp.BL.AIManageRecurringActivityBL.getDataByShopIdUserIdAndDeliveryDate(objMyCustomer.iUserId.Value, objMyCustomer.iShopId, dtDeliveryDate.Value);
                                if (objAIManageRecurringActivityBL == null)
                                {
                                    objAIManageRecurringActivityBL = new SummitShopApp.BL.AIManageRecurringActivityBL();
                                    objAIManageRecurringActivityBL.iShopId = objMyCustomer.iShopId;
                                    objAIManageRecurringActivityBL.iUserId = objMyCustomer.iUserId.Value;
                                    objAIManageRecurringActivityBL.dtDeliveryDate = dtDeliveryDate.Value;
                                    objAIManageRecurringActivityBL.Save();
                                }
                            }
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Update Information shop : " + objMyCustomer.iShopId + " User : " + objMyCustomer.iUserId + " UserName " + objMyCustomer.strUserName + " Converted Status Final : Delivered");
                        }
                        if (IsUnsoldEstimate)
                        {
                            objMarUser.bisShowInProcess = false;
                            objUser.bIsShowEmailMarketing = true;
                            objUser.bIsShowTextMarketing = true;

                            SummitShopApp.BL.VehicleStatusBL objVehicleStatusBL = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim() == "unsold estimate");
                            if (objVehicleStatusBL != null)
                            {
                                if (objCustomerVehicleStatus.iVehicleStatusId.HasValue && objCustomerVehicleStatus.iVehicleStatusId != objVehicleStatusBL.ID)
                                {
                                    SummitShopApp.Utility.CommonFunctions.SaveUserAuditTrail(objCustomerVehicleStatus.iVehicleStatusId.Value, objMarUser.iUserId, objMarUser.iVehicleId);
                                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Updated Entry in User Audit Trail Table for old status ID : " + objCustomerVehicleStatus.iVehicleStatusId.Value);

                                    objCustomerVehicleStatus.dtLastUpdatedStatusDate = DateTime.Now;
                                    objUser.dtUpdatedEntryTime = DateTime.Now;
                                }
                                objCustomerVehicleStatus.iVehicleStatusId = objVehicleStatusBL.ID;
                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Update Information shop : " + objMyCustomer.iShopId + " User : " + objMyCustomer.iUserId + " UserName " + objMyCustomer.strUserName + " Converted Status Final : unsold estimate");
                            }
                        }
                        if (IsRepairOrder)
                        {
                            objMarUser.bisShowInProcess = true;
                            objUser.bIsShowEmailMarketing = false;
                            objUser.bIsShowTextMarketing = false;


                            SummitShopApp.BL.VehicleStatusBL objVehicleStatusBL = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim() == "in process repairs");
                            if (objVehicleStatusBL != null)
                            {
                                if (objCustomerVehicleStatus.iVehicleStatusId.HasValue && objCustomerVehicleStatus.iVehicleStatusId != objVehicleStatusBL.ID)
                                {
                                    SummitShopApp.Utility.CommonFunctions.SaveUserAuditTrail(objCustomerVehicleStatus.iVehicleStatusId.Value, objMarUser.iUserId, objMarUser.iVehicleId);
                                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Updated Entry in User Audit Trail Table for old status ID : " + objCustomerVehicleStatus.iVehicleStatusId.Value);

                                    objCustomerVehicleStatus.dtLastUpdatedStatusDate = DateTime.Now;
                                    objUser.dtUpdatedEntryTime = DateTime.Now;


                                    if (objVehicleStatusBL.bMoveToMarketing.HasValue)
                                    {
                                        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("In Process Repairs (RO Number) has set Rule 'Move To Marketing' to true");
                                        bIsMoveToMarketing = objVehicleStatusBL.bMoveToMarketing.Value;
                                        objMarUser.bisShowInProcess = !bIsMoveToMarketing;
                                        objUser.bIsShowEmailMarketing = bIsMoveToMarketing;
                                        objUser.bIsShowTextMarketing = bIsMoveToMarketing;
                                    }
                                }
                                objCustomerVehicleStatus.iVehicleStatusId = objVehicleStatusBL.ID;
                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Update Information shop : " + objMyCustomer.iShopId + " User : " + objMyCustomer.iUserId + " UserName " + objMyCustomer.strUserName + " Converted Status Final : in process repairs");
                            }
                        }
                        objMarUser.Save();
                        objUser.Save();
                        objCustomerVehicleStatus.Save();
                    }
                    catch (Exception ex)
                    {
                        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception :  Update User Method () - - - - -  : While Applying the new status In of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                    }
                }
                updateInsuranceData(objMyCustomer.iUserId.Value, objEMSData);
                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Update Information shop : " + objMyCustomer.iShopId + " User : " + objMyCustomer.iUserId + " UserName " + objMyCustomer.strUserName + " updated Insurance Data");
                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("updateEMSData_New() end ");
                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic(Environment.NewLine);
            }
        }
        catch (Exception ex)
        {
            Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
        }
    }


    /// <summary>
    /// Sync the data from EMS file with data into database, if file was imported before.
    /// </summary>
    /// <param name="objInProcessUser"></param>
    /// <param name="objEMSData"></param>
    private void updateEMSData(SummitShopApp.BL.MyCustomerBL objMyCustomer, SummitShopApp.Utility.EMSData objEMSData)
    {
        try
        {
            SummitShopApp.Utility.CommonFunctions.LoggingForOld_AILogic(Environment.NewLine);
            SummitShopApp.Utility.CommonFunctions.LoggingForOld_AILogic("update Method Starts for shop : " + objMyCustomer.iShopId + " old User : " + objMyCustomer.iUserId.Value.ToString() + " for user : " + objEMSData.strUserName);

            //Code added for Delivery Date - START
            Boolean IsDelivered = false;
            DateTime dtDeliveryDateTemp;
            DateTime? dtDeliveryDate = null;
            try
            {
                dtDeliveryDate = DateTime.TryParse(objEMSData.strDeliveryDate, out dtDeliveryDateTemp) ? dtDeliveryDateTemp : (Nullable<DateTime>)null;
                if (dtDeliveryDate.HasValue && dtDeliveryDate.Value >= Convert.ToDateTime("01/01/1970"))
                {
                    IsDelivered = true;//TODO - True
                }
            }
            catch (Exception ex)
            {

            }
            //Code added for Delivery Date - END

            //Move to Marketign for Imported Estimate
            Boolean bIsMoveToMarketing = false;
            try
            {
                SummitShopApp.BL.VehicleStatusBL objVehicleStatus = SummitShopApp.BL.VehicleStatusBL.getDataByShopIdAndStatus(objMyCustomer.iShopId, "Imported Estimate");
                if (objVehicleStatus != null && objVehicleStatus.bMoveToMarketing.HasValue)
                {
                    bIsMoveToMarketing = objVehicleStatus.bMoveToMarketing.Value;
                }
            }
            catch (Exception) { }

            if (objMyCustomer.iUserId.HasValue && updateUserData(objMyCustomer.iUserId.Value, objEMSData, IsDelivered, bIsMoveToMarketing))
            {
                if (objMyCustomer.iVehicleId.HasValue)
                {
                    updateVehicleData(objMyCustomer.iVehicleId.Value, objEMSData);
                    try
                    {
                        //Code added for Delivery Date - START
                        if (IsDelivered)
                        {
                            updateUserVehicleStatus(objMyCustomer.iUserId.Value, objMyCustomer.iVehicleId.Value, objMyCustomer.iShopId, dtDeliveryDate.Value);
                            SummitShopApp.Utility.CommonFunctions.LoggingForOld_AILogic("shop : " + objMyCustomer.iShopId + " old User : " + objMyCustomer.iUserId.Value.ToString() + " status changes to Deliverd");

                        }
                        //Code added for Delivery Date - START

                        if (bIsMoveToMarketing)
                        {
                            updateUserInfoforMoveToMarketing(objMyCustomer.iUserId.Value, objMyCustomer.iVehicleId.Value, objMyCustomer.iShopId);
                            SummitShopApp.Utility.CommonFunctions.LoggingForOld_AILogic("shop : " + objMyCustomer.iShopId + " old User : " + objMyCustomer.iUserId.Value.ToString() + " customer moved to Movetomarketing flag");
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                updateInsuranceData(objMyCustomer.iUserId.Value, objEMSData);

                SummitShopApp.Utility.CommonFunctions.LoggingForOld_AILogic(Environment.NewLine);
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
    /// <param name="objEMSData"></param>
    /// <returns></returns>
    private Boolean updateUserData(Int32 iUserId, SummitShopApp.Utility.EMSData objEMSData, Boolean IsDelivered, Boolean IsMoveToMarketing)
    {
        try
        {
            //Get user object from database using user_id
            SummitShopApp.BL.UserBL objUser = SummitShopApp.BL.UserBL.getByActivityId(iUserId);
            if (objUser != null)
            {
                if (!String.IsNullOrEmpty(objEMSData.strOwnerPhone1))
                    objUser.strPhone = objEMSData.strOwnerPhone1;

                if (!String.IsNullOrEmpty(objEMSData.strOwnerPhone2))
                    objUser.strPhone2 = objEMSData.strOwnerPhone2;

                if (!String.IsNullOrEmpty(objEMSData.strOwnerEmail))
                {
                    String strFormatedEmail = String.IsNullOrEmpty(objEMSData.strOwnerEmail) ? String.Empty : objEMSData.strOwnerEmail.Trim();
                    if (strFormatedEmail.Length > 50)
                    {
                        strFormatedEmail = strFormatedEmail.Substring(0, 50);
                    }
                    objUser.strEmail = strFormatedEmail;
                }

                if (!String.IsNullOrEmpty(objEMSData.strOwnerAddress1))
                    objUser.strAddress1 = objEMSData.strOwnerAddress1;

                if (!String.IsNullOrEmpty(objEMSData.strOwnerAddress2))
                    objUser.strAddress2 = objEMSData.strOwnerAddress2;

                if (!String.IsNullOrEmpty(objEMSData.strOwnerCity))
                    objUser.strCity = objEMSData.strOwnerCity;

                if (!String.IsNullOrEmpty(objEMSData.strOwnerState))
                    objUser.strState = objEMSData.strOwnerState;

                if (!String.IsNullOrEmpty(objEMSData.strOwnerZipCode))
                    objUser.strZip = objEMSData.strOwnerZipCode;

                //Code added for Delivery Date - START
                if (IsDelivered || IsMoveToMarketing)
                {
                    objUser.bIsShowEmailMarketing = true;
                    objUser.bIsShowTextMarketing = true;
                }
                //Code added for Delivery Date - END

                return objUser.Save();
            }
        }
        catch (Exception ex)
        {
            Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
        }
        return false;
    }

    /// <summary>
    /// Update Vehicle Information
    /// </summary>
    /// <param name="iVehicleId"></param>
    /// <param name="objEMSData"></param>
    /// <returns></returns>
    private Boolean updateVehicleData(Int32 iVehicleId, SummitShopApp.Utility.EMSData objEMSData)
    {
        try
        {
            //Get Vehicle object from database using vehicle_id
            SummitShopApp.BL.VehicleInfoBL objVehicleInfo = SummitShopApp.BL.VehicleInfoBL.getDataId(iVehicleId);
            if (objVehicleInfo != null)
            {
                if (!String.IsNullOrEmpty(objEMSData.strYear))
                    objVehicleInfo.strYear = objEMSData.strYear;

                if (!String.IsNullOrEmpty(objEMSData.strMake))
                    objVehicleInfo.strMake = objEMSData.strMake;

                if (!String.IsNullOrEmpty(objEMSData.strModel))
                    objVehicleInfo.strModel = objEMSData.strModel;

                if (!String.IsNullOrEmpty(objEMSData.strStyle))
                    objVehicleInfo.strStyle = objEMSData.strStyle;

                if (!String.IsNullOrEmpty(objEMSData.strColor))
                    objVehicleInfo.strColor = objEMSData.strColor;

                if (!String.IsNullOrEmpty(objEMSData.strPaintCode))
                    objVehicleInfo.strPaintCode = objEMSData.strPaintCode;

                if (!String.IsNullOrEmpty(objEMSData.strVIN))
                    objVehicleInfo.strVIN = objEMSData.strVIN;

                if (!String.IsNullOrEmpty(objEMSData.strLicense))
                    objVehicleInfo.strLicense = objEMSData.strLicense;

                if (!String.IsNullOrEmpty(objEMSData.strEstimatorName))
                    objVehicleInfo.strEstimatorName = objEMSData.strEstimatorName;

                //Also update EMS unique id as it may changed and record identified by name, year, make, model, and phone
                if (!String.IsNullOrEmpty(objEMSData.strEstimateFileId))
                    objVehicleInfo.strEstimateFileIdentifier = objEMSData.strEstimateFileId;

                if (!String.IsNullOrEmpty(objEMSData.strProductionDate))
                {
                    DateTime dtProductionDate;
                    objVehicleInfo.dtProductionDate = DateTime.TryParse(objEMSData.strProductionDate, out dtProductionDate) ? dtProductionDate : (Nullable<DateTime>)null;
                }

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
    /// <param name="objEMSData"></param>
    /// <returns></returns>
    private Boolean updateInsuranceData(Int32 iUserId, SummitShopApp.Utility.EMSData objEMSData)
    {
        try
        {
            //Get InsuranceInfo object from database using user_id
            SummitShopApp.BL.InsuranceInformationBL objInsurance = SummitShopApp.BL.InsuranceInformationBL.getDataByUserId(iUserId);
            if (objInsurance == null)
            {
                //Create new object for Insurance if information is not addedpreviously.
                objInsurance = new SummitShopApp.BL.InsuranceInformationBL();
                objInsurance.iUserId = iUserId;
            }
            if (!String.IsNullOrEmpty(objEMSData.strInsuranceCompanyName))
                objInsurance.strCompanyName = objEMSData.strInsuranceCompanyName;
            if (!String.IsNullOrEmpty(objEMSData.strInsuranceCompanyAddress))

                objInsurance.strCompanyAddress = objEMSData.strInsuranceCompanyAddress;

            if (!String.IsNullOrEmpty(objEMSData.strInsuranceCompanyCity))
                objInsurance.strCompanyCity = objEMSData.strInsuranceCompanyCity;

            if (!String.IsNullOrEmpty(objEMSData.strInsuranceCompanyState))
                objInsurance.strCompanyState = objEMSData.strInsuranceCompanyState;

            if (!String.IsNullOrEmpty(objEMSData.strInsuranceCompanyZipCode))
                objInsurance.strCompanyZip = objEMSData.strInsuranceCompanyZipCode;

            if (!String.IsNullOrEmpty(objEMSData.strInsuranceCompanyEmail))
                objInsurance.strCompanyEmail = objEMSData.strInsuranceCompanyEmail;

            if (!String.IsNullOrEmpty(objEMSData.strInsuranceCompanyPhone))
                objInsurance.strCompanyCellPhone = objEMSData.strInsuranceCompanyPhone;

            if (!String.IsNullOrEmpty(objEMSData.strInsuranceCompanyFax))
                objInsurance.strCompanyFax = objEMSData.strInsuranceCompanyFax;

            if (!String.IsNullOrEmpty(objEMSData.strInsuranceAgentName))
                objInsurance.strAgentName = objEMSData.strInsuranceAgentName;

            if (!String.IsNullOrEmpty(objEMSData.strClaimNumber))
                objInsurance.strClaimNumber = objEMSData.strClaimNumber;

            if (!String.IsNullOrEmpty(objEMSData.strRONumbert) && !objEMSData.strRONumbert.Trim().Equals("0"))
                objInsurance.strROIdentifier = objEMSData.strRONumbert;
            else
                objInsurance.strROIdentifier = String.Empty;

            if (!String.IsNullOrEmpty(objEMSData.strNetTotalAmount))
                objInsurance.strNetTotalAmount = objEMSData.strNetTotalAmount;

            if (!String.IsNullOrEmpty(objEMSData.strDateOfLoss))
            {
                DateTime dtDateofLoss;
                objInsurance.dtDateOfLoss = DateTime.TryParse(objEMSData.strDateOfLoss, out dtDateofLoss) ? dtDateofLoss : (Nullable<DateTime>)null;
            }
            if (!String.IsNullOrEmpty(objEMSData.strDeductible))
            {
                Decimal dDeductible;
                objInsurance.dDeductible = Decimal.TryParse(objEMSData.strDeductible, out dDeductible) ? dDeductible : (Nullable<Decimal>)null;
            }
            return objInsurance.Save();
        }
        catch (Exception ex)
        {
            Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
        }
        return false;
    }

    private void updateUserInfoforMoveToMarketing(Int32 iUserId, Int32 iVehicleId, Int32 iShopId)
    {
        try
        {
            SummitShopApp.BL.MarketingUsers objMarketingUser = SummitShopApp.BL.MarketingUsers.getDataByShopUserAndVehicleId(iShopId, iUserId, iVehicleId);
            if (objMarketingUser != null)
            {
                objMarketingUser.bisShowInProcess = false;
                objMarketingUser.Save();
            }
        }
        catch (Exception)
        { }
    }

    /// <summary>
    /// Update User vehicle Status if record is deleted from Inprocess page
    /// </summary>
    /// <param name="iUserId"></param>
    /// <param name="iVehicleId"></param>
    /// <param name="iShopId"></param>
    private void updateUserVehicleStatus(Int32 iUserId, Int32 iVehicleId, Int32 iShopId, DateTime dtDeliveryDate)
    {
        try
        {
            //SummitShopApp.BL.UserVehicleStatusBL objCustomerVehicleStatus = SummitShopApp.BL.UserVehicleStatusBL.getDataByVehicleId(iVehicleId);
            //if (objCustomerVehicleStatus == null)
            //{
            //    objCustomerVehicleStatus = new SummitShopApp.BL.UserVehicleStatusBL();
            //    objCustomerVehicleStatus.iUserId = iUserId;
            //    objCustomerVehicleStatus.iVehicleId = iVehicleId;
            //    objCustomerVehicleStatus.iVehicleStatusId = getUnsoldEstimateId(iShopId);
            //    objCustomerVehicleStatus.dtLastUpdatedStatusDate = DateTime.Now;
            //    if (objCustomerVehicleStatus.Save())
            //    {
            //        SummitShopApp.BL.MarketingUsers objMarketingUser = SummitShopApp.BL.MarketingUsers.getDataByShopUserAndVehicleId(iShopId, iUserId, iVehicleId);
            //        if (objMarketingUser != null)
            //        {
            //            objMarketingUser.bisShowInProcess = true;
            //            objMarketingUser.Save();
            //        }
            //    }
            //}

            //Code added for Delivery Date - START
            SummitShopApp.BL.UserVehicleStatusBL objCustomerVehicleStatus = SummitShopApp.BL.UserVehicleStatusBL.getDataByVehicleId(iVehicleId);
            if (objCustomerVehicleStatus == null)
            {
                objCustomerVehicleStatus = new SummitShopApp.BL.UserVehicleStatusBL();
            }
            objCustomerVehicleStatus.iUserId = iUserId;
            objCustomerVehicleStatus.iVehicleId = iVehicleId;
            objCustomerVehicleStatus.iVehicleStatusId = getDeliveredStatusId(iShopId);
            objCustomerVehicleStatus.dtDeliveryDate = dtDeliveryDate;
            objCustomerVehicleStatus.dtLastUpdatedStatusDate = DateTime.Now;
            if (objCustomerVehicleStatus.Save())
            {
                SummitShopApp.BL.MarketingUsers objMarketingUser = SummitShopApp.BL.MarketingUsers.getDataByShopUserAndVehicleId(iShopId, iUserId, iVehicleId);
                if (objMarketingUser != null)
                {
                    objMarketingUser.bisShowInProcess = false;
                    objMarketingUser.Save();
                }
            }

            //Add record into another table AIManageRecurringActivity - it will processed by AIManageRecurringActivity Service
            SummitShopApp.BL.AIManageRecurringActivityBL objAIManageRecurringActivityBL = SummitShopApp.BL.AIManageRecurringActivityBL.getDataByShopIdUserIdAndDeliveryDate(iUserId, iShopId, dtDeliveryDate);
            if (objAIManageRecurringActivityBL == null)
            {
                objAIManageRecurringActivityBL = new SummitShopApp.BL.AIManageRecurringActivityBL();
                objAIManageRecurringActivityBL.iShopId = iShopId;
                objAIManageRecurringActivityBL.iUserId = iUserId;
                objAIManageRecurringActivityBL.dtDeliveryDate = dtDeliveryDate;
                objAIManageRecurringActivityBL.Save();
            }

            //Code added for Delivery Date - END
        }
        catch (Exception ex)
        {
            Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
        }

    }

    /// <summary>
    /// Create new VehicleStatus as Unsold Estimate if not available for shop
    /// </summary>
    /// <param name="iShopId"></param>
    /// <returns></returns>
    private Int32 getUnsoldEstimateId(Int32 iShopId)
    {
        Boolean bMatch = false;
        Int32 iVehicleStatusId = 0;
        System.Collections.Generic.List<SummitShopApp.BL.VehicleStatusBL> lstVehicleStatus = new System.Collections.Generic.List<SummitShopApp.BL.VehicleStatusBL>();
        lstVehicleStatus = SummitShopApp.BL.VehicleStatusBL.getDataByShopId(iShopId);
        if (lstVehicleStatus != null)
        {
            foreach (SummitShopApp.BL.VehicleStatusBL objVehicleStatus in lstVehicleStatus)
            {
                if (objVehicleStatus.strVehicleStatus == "Imported Estimate")
                {
                    iVehicleStatusId = objVehicleStatus.ID;
                    bMatch = true;
                    break;
                }
            }
        }

        if (bMatch)
        {
            return iVehicleStatusId;
        }
        else
        {
            SummitShopApp.BL.VehicleStatusBL _objVehicleStatus = new SummitShopApp.BL.VehicleStatusBL();
            _objVehicleStatus.strVehicleStatus = "Imported Estimate";
            _objVehicleStatus.strMessage = String.Empty;
            _objVehicleStatus.iShopId = iShopId;
            _objVehicleStatus.bSMS = false;
            _objVehicleStatus.bIsActive = false;
            _objVehicleStatus.bEmail = false;
            if (_objVehicleStatus.Save())
            {
                return iVehicleStatusId;
            }
        }
        return iVehicleStatusId;
    }

    /// <summary>
    /// Create new VehicleStatus as Unsold Estimate if not available for shop
    /// </summary>
    /// <param name="iShopId"></param>
    /// <returns></returns>
    private Int32 getDeliveredStatusId(Int32 iShopId)
    {

        Int32 iVehicleStatusId = 0;
        System.Collections.Generic.List<SummitShopApp.BL.VehicleStatusBL> lstVehicleStatus = new System.Collections.Generic.List<SummitShopApp.BL.VehicleStatusBL>();
        lstVehicleStatus = SummitShopApp.BL.VehicleStatusBL.getDataByShopId(iShopId);
        if (lstVehicleStatus != null)
        {
            foreach (SummitShopApp.BL.VehicleStatusBL objVehicleStatus in lstVehicleStatus)
            {
                if (objVehicleStatus.strVehicleStatus.ToLower().Trim() == "delivered")
                {
                    iVehicleStatusId = objVehicleStatus.ID;
                    break;
                }
            }
        }

        return iVehicleStatusId;
    }

    private Boolean isValidEMSFile(String strFilePath)
    {
        if (!String.IsNullOrEmpty(strFilePath))
        {
            String strExt = Path.GetExtension(strFilePath);
            Boolean bIsValid = false;
            if (!String.IsNullOrEmpty(strExt))
            {
                switch (strExt.ToLower())
                {
                    case ".ad1":
                    case ".ad2":
                    case ".dbt":
                    case ".env":
                    case ".lin":
                    case ".pfh":
                    case ".pfl":
                    case ".pfm":
                    case ".pfp":
                    case ".pfo":
                    case ".pft":
                    case ".stl":
                    case ".ttl":
                    case ".veh":
                    case ".ven":
                        bIsValid = true;
                        break;
                    default:
                        break;
                }
            }
            return bIsValid;
        }
        return false;
    }

    private void SaveCSVData(String folderPath, String strShopId)
    {
        DirectoryInfo dir = new DirectoryInfo(folderPath);
        FileInfo[] files = dir.GetFiles();

        if (files != null && files.Length > 0)
        {
            System.Collections.Generic.List<SummitShopApp.BL.MarketingCenterBL> lstMarketingUser = SummitShopApp.BL.MarketingCenterBL.getMarketinCentersList(Convert.ToInt32(strShopId));
            SummitShopApp.BL.UserBL _lstMarketingUser = new SummitShopApp.BL.UserBL();
            foreach (FileInfo file in files)
            {
                System.Collections.Generic.List<SummitShopApp.Utility.UserInfo> lstCustomerInfo = new System.Collections.Generic.List<SummitShopApp.Utility.UserInfo>();
                Int32 iAddedCustomerCount = 0;
                Boolean isDuplicate = false;
                try
                {
                    StreamReader pt = File.OpenText(file.FullName);
                    int Cnt = 0;

                    pt.ReadLine();

                    //Read file untile last record
                    while (!pt.EndOfStream)
                    {
                        String line = pt.ReadLine();
                        Cnt++;
                        string[] StrArr = Split(line, ",", "\"", true);

                        SummitShopApp.Utility.UserInfo custInfo = new SummitShopApp.Utility.UserInfo();

                        //Save record to the object from the file
                        custInfo.Name = StrArr[0] != null ? StrArr[0].ToString().Replace("\"", string.Empty) : "";
                        custInfo.Year = StrArr[1] != null ? StrArr[1].ToString().Replace("\"", string.Empty) : "";
                        custInfo.Make = StrArr[2] != null ? StrArr[2].ToString().Replace("\"", string.Empty) : "";
                        custInfo.Model = StrArr[3] != null ? StrArr[3].ToString().Replace("\"", string.Empty) : "";
                        try
                        {
                            custInfo.Date = !String.IsNullOrEmpty(StrArr[4]) ? Convert.ToDateTime(StrArr[4].ToString().Replace("\"", string.Empty)) : (Nullable<DateTime>)null;
                        }
                        catch (Exception ex)
                        {
                            Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
                        }
                        try
                        {
                            custInfo.Phone = StrArr[5] != null ? StrArr[5].ToString().Replace("\"", string.Empty).Replace("-", string.Empty).Replace(".", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty) : "";
                            custInfo.Email = StrArr[6] != null ? StrArr[6].ToString().Replace("\"", string.Empty) : "";
                            custInfo.Zip = StrArr[7] != null ? StrArr[7].ToString().Replace("\"", string.Empty) : "";
                            if (custInfo.Zip != null)
                            {
                                if (custInfo.Zip.Length == 4)
                                {
                                    custInfo.Zip = "0" + custInfo.Zip;
                                }
                                if (custInfo.Zip.Contains("-"))
                                {
                                    String[] strZips = custInfo.Zip.Split('-');
                                    if (strZips[0].Length == 4)
                                    {
                                        custInfo.Zip = "0" + strZips[0] + "-" + strZips[1];
                                    }
                                }
                            }
                            if (!String.IsNullOrEmpty(custInfo.Email) && !StringProcessing.StringFunctions.IsEmailAddress(custInfo.Email))
                                custInfo.Email = String.Empty;
                            if (!String.IsNullOrEmpty(custInfo.Zip) && !SummitShopApp.Utility.CommonFunctions.isValidZipCode(custInfo.Zip))
                                custInfo.Zip = String.Empty;
                            if (!String.IsNullOrEmpty(custInfo.Year) && !StringProcessing.StringFunctions.IsNumeric(custInfo.Year))
                                custInfo.Year = String.Empty;
                            if (!String.IsNullOrEmpty(custInfo.Phone) && custInfo.Phone.Length > 10 || !StringProcessing.StringFunctions.IsNumeric(custInfo.Phone))
                                custInfo.Phone = String.Empty;
                        }
                        catch (Exception ex)
                        {
                            Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
                        }

                        // isDuplicate = lstCustomerInfo.Exists(objCustomerInfo => !string.IsNullOrEmpty(objCustomerInfo.Name.Trim()) && !string.IsNullOrEmpty(custInfo.Name) && objCustomerInfo.Name.ToLower().Trim() == custInfo.Name.ToLower().Trim() && objCustomerInfo.Year != null && custInfo.Year != null && custInfo.Year.ToLower().Trim() == objCustomerInfo.Year.ToLower().Trim() && objCustomerInfo.Make != null && custInfo.Make != null && objCustomerInfo.Make.ToLower().Trim() == custInfo.Make.ToLower().Trim() && objCustomerInfo.Model != null && custInfo.Model != null && objCustomerInfo.Model.ToLower().Trim() == custInfo.Model.ToLower().Trim() && objCustomerInfo.Phone != null && custInfo.Phone != null && objCustomerInfo.Phone.ToLower().Trim() == custInfo.Phone.ToLower().Trim());

                        //if (!isDuplicate)
                        //{
                        lstCustomerInfo.Add(custInfo);
                        //}
                        ++iAddedCustomerCount;
                    }
                }
                catch (Exception ex)
                {
                    Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
                }

                if (iAddedCustomerCount > 0)
                {
                    lstCustomerInfo.RemoveAll(delegate(SummitShopApp.Utility.UserInfo c)
                    {
                        return lstCustomerInfo.IndexOf(c) != lstCustomerInfo.FindIndex(
                        delegate(SummitShopApp.Utility.UserInfo f)
                        {
                            return (!string.IsNullOrEmpty(c.Name.Trim()) && !string.IsNullOrEmpty(f.Name) && c.Name.ToLower().Trim() == f.Name.ToLower().Trim() && c.Year != null && f.Year != null && f.Year.ToLower().Trim() == c.Year.ToLower().Trim() && c.Make != null && f.Make != null && c.Make.ToLower().Trim() == f.Make.ToLower().Trim() && c.Model != null && f.Model != null && c.Model.ToLower().Trim() == f.Model.ToLower().Trim() && c.Phone != null && f.Phone != null && c.Phone.ToLower().Trim() == f.Phone.ToLower().Trim());
                        });
                    });

                    foreach (SummitShopApp.Utility.UserInfo CustInfo in lstCustomerInfo)
                    {
                        try
                        {
                            //Check for duplicate entry
                            SummitShopApp.BL.MarketingCenterBL marketingUser = lstMarketingUser.Find(objCustomerInfo => !string.IsNullOrEmpty(objCustomerInfo.UserName.Trim()) && !string.IsNullOrEmpty(CustInfo.Name) && objCustomerInfo.UserName.ToLower().Trim() == CustInfo.Name.ToLower().Trim() && objCustomerInfo.Year != null && CustInfo.Year != null && CustInfo.Year.ToLower().Trim() == objCustomerInfo.Year.ToLower().Trim() && objCustomerInfo.Make != null && CustInfo.Make != null && objCustomerInfo.Make.ToLower().Trim() == CustInfo.Make.ToLower().Trim() && objCustomerInfo.Model != null && CustInfo.Model != null && objCustomerInfo.Model.ToLower().Trim() == CustInfo.Model.ToLower().Trim() && objCustomerInfo.Phone != null && CustInfo.Phone != null && objCustomerInfo.Phone.ToLower().Trim() == CustInfo.Phone.ToLower().Trim());

                            if (marketingUser != null)
                            {
                                //Boolean isEmailDuplicate = lstMarketingUser.Exists(objCustomerInfo => !string.IsNullOrEmpty(objCustomerInfo.UserName.Trim()) && !string.IsNullOrEmpty(CustInfo.Name) && objCustomerInfo.UserName.ToLower().Trim() == CustInfo.Name.ToLower().Trim() && objCustomerInfo.Year != null && CustInfo.Year != null && CustInfo.Year.ToLower().Trim() == objCustomerInfo.Year.ToLower().Trim() && objCustomerInfo.Make != null && CustInfo.Make != null && objCustomerInfo.Make.ToLower().Trim() == CustInfo.Make.ToLower().Trim() && objCustomerInfo.Model != null && CustInfo.Model != null && objCustomerInfo.Model.ToLower().Trim() == CustInfo.Model.ToLower().Trim() && objCustomerInfo.Phone != null && CustInfo.Phone != null && objCustomerInfo.Phone.ToLower().Trim() != CustInfo.Phone.ToLower().Trim() && objCustomerInfo.Email != null && CustInfo.Email != null && objCustomerInfo.Email.ToLower().Trim() == CustInfo.Email.ToLower().Trim());
                                //Boolean isTextDuplicate = lstMarketingUser.Exists(objCustomerInfo => !string.IsNullOrEmpty(objCustomerInfo.UserName.Trim()) && !string.IsNullOrEmpty(CustInfo.Name) && objCustomerInfo.UserName.ToLower().Trim() == CustInfo.Name.ToLower().Trim() && objCustomerInfo.Year != null && CustInfo.Year != null && CustInfo.Year.ToLower().Trim() == objCustomerInfo.Year.ToLower().Trim() && objCustomerInfo.Make != null && CustInfo.Make != null && objCustomerInfo.Make.ToLower().Trim() == CustInfo.Make.ToLower().Trim() && objCustomerInfo.Model != null && CustInfo.Model != null && objCustomerInfo.Model.ToLower().Trim() == CustInfo.Model.ToLower().Trim() && objCustomerInfo.Phone != null && CustInfo.Phone != null && objCustomerInfo.Phone.ToLower().Trim() == CustInfo.Phone.ToLower().Trim() && objCustomerInfo.Email != null && CustInfo.Email != null && objCustomerInfo.Email.ToLower().Trim() != CustInfo.Email.ToLower().Trim());
                                SummitShopApp.BL.UserBL _objUser = SummitShopApp.BL.UserBL.getByActivityId(marketingUser.UserId);

                                if (_objUser != null)
                                {
                                    _objUser.bIsShowEmailMarketing = true;
                                    _objUser.bIsShowTextMarketing = true;
                                    _objUser.Save();
                                }
                            }
                            else
                            {
                                SummitShopApp.BL.UserBL objUser = new SummitShopApp.BL.UserBL();
                                objUser.dtUpdatedEntryTime = DateTime.Now;
                                objUser.bIsNew = true;
                                objUser.bIsRegistred_Shop = true;
                                objUser.bIsShowEmailMarketing = true;
                                objUser.bIsShowTextMarketing = true;


                                String strFormatedUserName = String.IsNullOrEmpty(CustInfo.Name) ? String.Empty : CustInfo.Name.Trim();
                                if (strFormatedUserName.Length > 50)
                                {
                                    strFormatedUserName = strFormatedUserName.Substring(0, 50);
                                }
                                objUser.strUserName = strFormatedUserName;//CustInfo.Name.Trim();

                                String strFormatedEmail = String.IsNullOrEmpty(CustInfo.Email) ? String.Empty : CustInfo.Email.Trim();
                                if (strFormatedEmail.Length > 50)
                                {
                                    strFormatedEmail = strFormatedEmail.Substring(0, 50);
                                }
                                objUser.strEmail = strFormatedEmail;
                                objUser.strPhone = CustInfo.Phone.Trim();
                                objUser.strZip = CustInfo.Zip.Trim();
                                if (objUser.Save())
                                {
                                    try
                                    {
                                        SummitShopApp.BL.VehicleInfoBL objCustomerVehicleInfo = new SummitShopApp.BL.VehicleInfoBL();
                                        objCustomerVehicleInfo.iUserId = objUser.ID;
                                        objCustomerVehicleInfo.strYear = CustInfo.Year;
                                        objCustomerVehicleInfo.strMake = CustInfo.Make;
                                        objCustomerVehicleInfo.strModel = CustInfo.Model;
                                        objCustomerVehicleInfo.bIsUsing = true;
                                        if (objCustomerVehicleInfo.Save())
                                        {
                                            SummitShopApp.BL.MarketingUsers objMarketingUser = new SummitShopApp.BL.MarketingUsers();
                                            objMarketingUser.iShopId = Convert.ToInt32(strShopId);
                                            objMarketingUser.iUserId = objUser.ID;
                                            objMarketingUser.iVehicleId = objCustomerVehicleInfo.ID;
                                            objMarketingUser.bisShowInProcess = false;
                                            try
                                            {
                                                objMarketingUser.Save();
                                            }
                                            catch (Exception ex)
                                            {
                                                Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
                                    }
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Enhanced Split Function
    /// </summary>
    /// <param name="expression">expression</param>
    /// <param name="delimiter">delimiter</param>
    /// <param name="qualifier">qualifier</param>
    /// <param name="ignoreCase">ignoreCase</param>
    /// <returns></returns>
    public static string[] Split(string expression, string delimiter, string qualifier, bool ignoreCase)
    {
        string _Statement = String.Format("{0}(?=(?:[^{1}]*{1}[^{1}]*{1})*(?![^{1}]*{1}))",
                            Regex.Escape(delimiter), Regex.Escape(qualifier));
        RegexOptions _Options = RegexOptions.Compiled | RegexOptions.Multiline;
        if (ignoreCase) _Options = _Options | RegexOptions.IgnoreCase;

        Regex _Expression = new Regex(_Statement, _Options);
        return _Expression.Split(expression);
    }
    /// <summary>
    /// Save EMS files on server and imoport them into database
    /// </summary>
    /// <param name="folderPath"></param>
    /// <param name="strShopId"></param>
    protected void SaveNewAILocicForCSV(System.Collections.Generic.List<SummitShopApp.Utility.EMSData> lstEMSData, Int32 iAILogicShopID)
    {
        Boolean bMatch = false;
        int iVehicleStatusId = 0;
        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic(Environment.NewLine);
        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("SaveNewAILocicForCSV function called for shopid : " + iAILogicShopID.ToString());
        if (lstEMSData != null)
        {
            //Get deleted customers from inprocess
            System.Collections.Generic.List<SummitShopApp.BL.InProcessUsersBL> lstDeletedUsers = SummitShopApp.BL.InProcessUsersBL.GetAllDeletedUsers(iAILogicShopID);

            Int32 iCounter = -1;
            //Loop for extracted data from all files we have imprted
            foreach (SummitShopApp.Utility.EMSData objEMSData in lstEMSData)
            {
                System.Collections.Generic.List<SummitShopApp.BL.MyCustomerBL> lstMyCustomer = SummitShopApp.BL.MyCustomerBL.getCustomersList(iAILogicShopID);

                Boolean bIsDuplicate = false;
                Boolean bUpdateData = false;
                SummitShopApp.BL.MyCustomerBL _objMyCustomer = null;

                //Get inprocess customers
                ++iCounter;
                if (lstMyCustomer != null && lstMyCustomer.Count > 0 && objEMSData != null)
                {
                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Check For Duplicate User For Shop : " + iAILogicShopID.ToString() + " User Name : " + objEMSData.strUserName + " with number of customers : " + lstMyCustomer.Count.ToString());
                    if (!String.IsNullOrEmpty(objEMSData.strEstimateFileId))
                    {
                        try
                        {
                            _objMyCustomer = lstMyCustomer.Find(o => !String.IsNullOrEmpty(o.strEstimateFileIdentifier) && String.Equals(o.strEstimateFileIdentifier.ToLower().Trim(), objEMSData.strEstimateFileId.ToLower().Trim()));
                            if (_objMyCustomer != null)
                            {
                                bIsDuplicate = true;
                                bUpdateData = true;
                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("got customer with identifire for : " + objEMSData.strUserName);
                            }
                        }
                        catch (Exception ex)
                        {
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : Checking Identifier" + ex.ToString());
                            _objMyCustomer = null;
                            bIsDuplicate = false;
                            bUpdateData = false;
                        }
                    }
                    if (!bIsDuplicate)
                    {
                        foreach (SummitShopApp.BL.MyCustomerBL objMyCustomer in lstMyCustomer)
                        {
                            //for older file that has been imported and don't have unique file identifier then check for name,year,make,model and mobile #
                            //if (String.IsNullOrEmpty(objMyCustomer.strEstimateFileIdentifier))
                            //{
                            //    bIsDuplicate = false;
                            //}
                            // else check with unique file identifier
                            //else
                            //{
                            if (objEMSData.strEstimateFileId != null && objMyCustomer.strEstimateFileIdentifier != null && String.Equals(objMyCustomer.strEstimateFileIdentifier.ToLower().Trim(), objEMSData.strEstimateFileId.ToLower().Trim()))
                            {
                                bIsDuplicate = true;
                            }
                            //if EstimateID is different then again check with five fields
                            //else
                            //{
                            //    bIsDuplicate = IsEqualsNew(objMyCustomer, objEMSData);
                            //}
                            //}
                            if (bIsDuplicate)
                            {

                                bUpdateData = true;
                                _objMyCustomer = objMyCustomer;
                                break;
                            }
                        }
                    }
                }
                if (!bIsDuplicate)
                {
                    Boolean bIsDeleted = false;

                    if (lstDeletedUsers != null && lstDeletedUsers.Count > 0)
                    {
                        foreach (SummitShopApp.BL.InProcessUsersBL objInProcessObject in lstDeletedUsers)
                        {
                            //for older file that has been imported and don't have unique file identifier then check for name,year,make,model and mobile #
                            if (String.IsNullOrEmpty(objInProcessObject.strEstimateFileIdentifier))
                            {
                                bIsDeleted = IsEquals(objInProcessObject, objEMSData);
                            }
                            // else check with unique file identifier
                            else
                            {
                                if (objEMSData.strEstimateFileId != null && String.Equals(objInProcessObject.strEstimateFileIdentifier.ToLower().Trim(), objEMSData.strEstimateFileId.ToLower().Trim()))
                                {
                                    bIsDeleted = true;
                                }
                                //if EstimateID is different then again check with five fields
                                else
                                {
                                    bIsDeleted = IsEquals(objInProcessObject, objEMSData);
                                }
                            }
                            if (bIsDeleted)
                            {
                                updateEMSData_NewForCSVForDeletedUser(objInProcessObject, objEMSData);
                                bUpdateData = true;
                                // _objMyCustomer = null;
                                break;
                            }
                        }
                    }
                    if (!bIsDeleted)
                    {
                        //Code added for Delivery Date - START
                        Boolean IsDelivered = false;
                        Boolean IsUnsoldEstimate = false;
                        Boolean IsRepairOrder = false;
                        DateTime dtDeliveryDateTemp;
                        DateTime? dtDeliveryDate = null;
                        //Move to Marketign for Imported Estimate
                        Boolean bIsMoveToMarketing = false;
                        try
                        {
                            SummitShopApp.BL.VehicleStatusBL objVehicleStatus = SummitShopApp.BL.VehicleStatusBL.getDataByShopIdAndStatus(iAILogicShopID, "Imported Estimate");
                            if (objVehicleStatus != null && objVehicleStatus.bMoveToMarketing.HasValue)
                            {
                                bIsMoveToMarketing = objVehicleStatus.bMoveToMarketing.Value;
                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Imported Estimate has set Rule 'Move To Marketing' to true");
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            dtDeliveryDate = DateTime.TryParse(objEMSData.strDeliveryDate, out dtDeliveryDateTemp) ? dtDeliveryDateTemp : (Nullable<DateTime>)null;
                            if (dtDeliveryDate.HasValue && dtDeliveryDate.Value >= Convert.ToDateTime("01/01/1970"))
                            {
                                IsDelivered = true;//TODO - True
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                        SummitShopApp.BL.UserBL objUser = new SummitShopApp.BL.UserBL();

                        String strFormatedUserName = String.IsNullOrEmpty(objEMSData.strUserName) ? String.Empty : objEMSData.strUserName.Trim();
                        if (strFormatedUserName.Length > 50)
                        {
                            strFormatedUserName = strFormatedUserName.Substring(0, 50);
                        }
                        objUser.strUserName = strFormatedUserName;
                        objUser.strFirstName = objEMSData.strOwnerFirstName;
                        objUser.strLastName = objEMSData.strOwnerLastName;
                        objUser.strPhone = objEMSData.strOwnerPhone1;
                        objUser.strPhone2 = objEMSData.strOwnerPhone2;

                        String strFormatedEmail = String.IsNullOrEmpty(objEMSData.strOwnerEmail) ? String.Empty : objEMSData.strOwnerEmail.Trim();
                        if (strFormatedEmail.Length > 50)
                        {
                            strFormatedEmail = strFormatedEmail.Substring(0, 50);
                        }

                        objUser.strEmail = strFormatedEmail;
                        objUser.strAddress1 = objEMSData.strOwnerAddress1;
                        objUser.strAddress2 = objEMSData.strOwnerAddress2;
                        objUser.strCity = objEMSData.strOwnerCity;
                        objUser.strState = objEMSData.strOwnerState;
                        objUser.strZip = objEMSData.strOwnerZipCode;
                        if (!String.IsNullOrEmpty(Request.QueryString["ImportEMSDataTo"]) && (Request.QueryString["ImportEMSDataTo"].ToLower() == "emailmarketing" || Request.QueryString["ImportEMSDataTo"].ToLower() == "textmarketing"))
                        {
                            objUser.bIsShowEmailMarketing = true;
                            objUser.bIsShowTextMarketing = true;
                        }

                        //Code added for Delivery Date - START
                        if (IsDelivered || bIsMoveToMarketing)
                        {
                            objUser.bIsShowEmailMarketing = true;
                            objUser.bIsShowTextMarketing = true;
                        }
                        if (!String.IsNullOrEmpty(objEMSData.status) && objEMSData.status.ToLower().Trim().Equals("cancel"))
                        {
                            objUser.bIsShowEmailMarketing = false;
                            objUser.bIsShowTextMarketing = false;
                            objUser.bIsShow = false;
                            objUser.dtUpdatedEntryTime = DateTime.Now;
                        }
                        //Code added for Delivery Date - END

                        objUser.dtUpdatedEntryTime = DateTime.Now;
                        if (objUser.Save())
                        {
                            SummitShopApp.BL.VehicleInfoBL objVehicleInfo = new SummitShopApp.BL.VehicleInfoBL();
                            objVehicleInfo.iUserId = objUser.ID;
                            objVehicleInfo.strYear = objEMSData.strYear;
                            objVehicleInfo.strMake = objEMSData.strMake;
                            objVehicleInfo.strModel = objEMSData.strModel;
                            objVehicleInfo.strStyle = objEMSData.strStyle;
                            objVehicleInfo.strColor = objEMSData.strColor;
                            objVehicleInfo.strPaintCode = objEMSData.strPaintCode;
                            objVehicleInfo.strVIN = objEMSData.strVIN;
                            objVehicleInfo.strLicense = objEMSData.strLicense;
                            objVehicleInfo.strEstimatorName = objEMSData.strEstimatorName;
                            objVehicleInfo.strEstimateFileIdentifier = objEMSData.strEstimateFileId;
                            DateTime dtProductionDate;
                            objVehicleInfo.dtProductionDate = DateTime.TryParse("", out dtProductionDate) ? dtProductionDate : (Nullable<DateTime>)null;
                            objVehicleInfo.bIsUsing = true;
                            objVehicleInfo.Save();
                            SummitShopApp.BL.MarketingUsers objMarUser = new SummitShopApp.BL.MarketingUsers();
                            objMarUser.iShopId = iAILogicShopID;
                            objMarUser.iUserId = objUser.ID;
                            objMarUser.iVehicleId = objVehicleInfo.ID;
                            //Code added for Delivery Date - START
                            if (IsDelivered || bIsMoveToMarketing)
                                objMarUser.bisShowInProcess = false;
                            else
                                objMarUser.bisShowInProcess = true;
                            if (!String.IsNullOrEmpty(objEMSData.status) && objEMSData.status.ToLower().Trim().Equals("cancel"))
                            {
                                objMarUser.bisShowInProcess = false;
                                objMarUser.Save();
                                continue;
                            }
                            //Code added for Delivery Date - END

                            objMarUser.iVehicleId = objVehicleInfo.ID;
                            objMarUser.Save();

                            SummitShopApp.BL.UserVehicleStatusBL objCustomerVehicleStatus = new SummitShopApp.BL.UserVehicleStatusBL();
                            objCustomerVehicleStatus.iUserId = objUser.ID;
                            objCustomerVehicleStatus.iVehicleId = objVehicleInfo.ID;

                            //21915 - Ankeny Auto Body
                            //63470 - Faith Auto Works
                            //62555 - Steves test shop

                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic(" - - - - - New User Method Starts");
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("shop : " + objMarUser.iShopId + " New User : " + objUser.ID + " usename : " + objUser.strUserName);
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("RO Number: " + objEMSData.strRONumbert);
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Date In : " + objEMSData.strDateIn);
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("RO Complition Date: " + objEMSData.strDateOut_Ro_Cmp_Date);
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Tar Date Out: " + objEMSData.strDateOut_Tar_Date);

                            //If we get the Env.RO_No field, it will be saved in the 'RO Number' field and the status of the file would be 'Repair Order' - 3 Hrs
                            try
                            {
                                if (!String.IsNullOrEmpty(objEMSData.strRONumbert) && !objEMSData.strRONumbert.Trim().Equals("0"))
                                {
                                    IsRepairOrder = true;
                                }
                            }
                            catch (Exception)
                            {
                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : RO Exception For New User - - - - -  : while Checking RO Number " + objEMSData.strRONumbert + " of Shop :" + objMarUser.iShopId + " New User : " + objUser.ID + " usename : " + objUser.strUserName);
                            }

                            DateTime dtDateInTemp;
                            DateTime? dtDateIn = null;
                            try
                            {
                                dtDateIn = DateTime.TryParse(objEMSData.strDateIn, out dtDateInTemp) ? dtDateInTemp : (Nullable<DateTime>)null;
                                if (dtDateIn.HasValue && dtDateIn.Value >= Convert.ToDateTime("01/01/1970"))
                                {
                                    objCustomerVehicleStatus.dtDateIn = dtDateIn;
                                    IsRepairOrder = true;
                                }
                            }
                            catch (Exception ex)
                            {
                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : New User Method Save() - - - - -  : while Checking RO Date IN of Shop :" + objMarUser.iShopId + " New User : " + objUser.ID + " usename : " + objUser.strUserName);
                            }
                            DateTime dtDateOutTemp_TAR_DATE;
                            DateTime? dtDateOut_TAR_DATE;
                            DateTime dtDateOutTemp_RO_CMPDATE;
                            DateTime? dtDateOut_RO_CMPDATE;
                            try
                            {
                                dtDateOut_RO_CMPDATE = DateTime.TryParse(objEMSData.strDateOut_Ro_Cmp_Date, out dtDateOutTemp_RO_CMPDATE) ? dtDateOutTemp_RO_CMPDATE : (Nullable<DateTime>)null;
                                dtDateOut_TAR_DATE = DateTime.TryParse(objEMSData.strDateOut_Tar_Date, out dtDateOutTemp_TAR_DATE) ? dtDateOutTemp_TAR_DATE : (Nullable<DateTime>)null;

                                if (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value >= Convert.ToDateTime("01/01/1970"))
                                {
                                    objCustomerVehicleStatus.dtDateOut = dtDateOut_TAR_DATE;
                                }
                                else if (dtDateOut_RO_CMPDATE.HasValue && dtDateOut_RO_CMPDATE.Value >= Convert.ToDateTime("01/01/1970"))
                                {
                                    objCustomerVehicleStatus.dtDateOut = dtDateOut_RO_CMPDATE;
                                }
                                //added code for
                                //If we get the RO_TAR_Date for a customer, need to set that file to 'Delivered' with the delivery date being set what the TAR_Date field has - 4 Hrs
                                //If the Tar_Date is a future date we should mark the file as 'Delivered' and start the triggers(automation emails and sms) if the Tar_Date is equal to the actual date 
                                //15 April 2016 Changes 
                                //1. where the Date_Out will replace the Tar_Date and the customer will be marked as delivered when there is Date_Out for an estimate
                                //2. where tghe customer should be in Repair Order Status if the Tar_Date is a future date and should change to delivered when the Tar_Date is equal to or greater than the actual date
                                try
                                {
                                    if ((dtDateOut_RO_CMPDATE.HasValue && dtDateOut_RO_CMPDATE.Value >= Convert.ToDateTime("01/01/1970")) || (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value >= Convert.ToDateTime("01/01/1970")))
                                    {

                                        if (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value >= Convert.ToDateTime("01/01/1970"))
                                        {
                                            dtDeliveryDate = dtDateOut_TAR_DATE.Value;
                                        }
                                        if (dtDateOut_RO_CMPDATE.HasValue && dtDateOut_RO_CMPDATE.Value >= Convert.ToDateTime("01/01/1970"))
                                        {
                                            dtDeliveryDate = dtDateOut_RO_CMPDATE.Value;
                                        }
                                        if (dtDeliveryDate.Value > DateTime.Now)
                                        {
                                            IsRepairOrder = true;
                                            objCustomerVehicleStatus.dtDeliveryDate = dtDeliveryDate;
                                        }
                                        else
                                        {
                                            IsDelivered = true;
                                            IsUnsoldEstimate = false;
                                            IsRepairOrder = false;
                                        }

                                    }

                                }
                                catch (Exception ex)
                                {
                                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic(" Exception :  New User Method Save() - - - - -  : while Checking dtDateOut_RO_CMPDATE dtDateOut_TAR_DATE of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                                }
                                try
                                {
                                    //If we do not get the RO_In_Date, Tar_Date and Env_RO_No, then the status of that file would be 'Unsold Estimate' - 3 Hrs
                                    if (!IsDelivered && !IsRepairOrder && (dtDateOut_TAR_DATE == null || (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value <= Convert.ToDateTime("01/01/1970"))))
                                    {
                                        IsUnsoldEstimate = true;
                                        IsDelivered = false;
                                        IsRepairOrder = false;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic(" Exception : New User Method Save() - - - - -  : while making Unsold of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                                }
                            }
                            catch (Exception ex)
                            {
                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic(" Exception : New User Method Save() - - - - -  : while checking the New Dates of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                            }

                            System.Collections.Generic.List<SummitShopApp.BL.VehicleStatusBL> lstVehicleStatus = new System.Collections.Generic.List<SummitShopApp.BL.VehicleStatusBL>();
                            lstVehicleStatus = SummitShopApp.BL.VehicleStatusBL.getDataByShopId(iAILogicShopID);

                            SummitShopApp.BL.VehicleStatusBL objVehicleStatusBLForNewStatus = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim().Equals(objEMSData.status.ToLower().Trim()));
                            if (objVehicleStatusBLForNewStatus == null)
                            {
                                if (!String.IsNullOrEmpty(objEMSData.status) && !objEMSData.status.ToLower().Trim().Equals("cancel"))
                                {
                                    SummitShopApp.BL.VehicleStatusBL objVehicleStatusImportEstimateBLN = new SummitShopApp.BL.VehicleStatusBL();
                                    objVehicleStatusImportEstimateBLN.iShopId = iAILogicShopID;
                                    objVehicleStatusImportEstimateBLN.strVehicleStatus = objEMSData.status;
                                    objVehicleStatusImportEstimateBLN.bIsActive = true;
                                    objVehicleStatusImportEstimateBLN.Save();
                                    iVehicleStatusId = objVehicleStatusImportEstimateBLN.ID;
                                }
                            }
                            if (lstVehicleStatus != null)
                            {
                                try
                                {
                                    objUser = SummitShopApp.BL.UserBL.getByActivityId(objMarUser.iUserId);
                                    objMarUser = SummitShopApp.BL.MarketingUsers.getDataByShopAndUserId(objMarUser.iShopId, objMarUser.iUserId);
                                    try
                                    {
                                        SummitShopApp.BL.VehicleStatusBL objVehicleStatusImportEstimateBL = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim() == "imported estimate");

                                        if (objVehicleStatusImportEstimateBL != null)
                                        {
                                            iVehicleStatusId = objVehicleStatusImportEstimateBL.ID;
                                            bMatch = true;
                                        }

                                        if (IsDelivered)
                                        {
                                            bMatch = true;
                                            objMarUser.bisShowInProcess = false;

                                            objUser.bIsShowEmailMarketing = true;
                                            objUser.bIsShowTextMarketing = true;
                                            objUser.dtUpdatedEntryTime = DateTime.Now;

                                            SummitShopApp.BL.VehicleStatusBL objVehicleStatusBL = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim() == "delivered");
                                            if (objVehicleStatusBL != null)
                                            {
                                                iVehicleStatusId = objVehicleStatusBL.ID;
                                                bMatch = true;
                                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("shop : " + objMarUser.iShopId + " User : " + objUser.ID + " UserName " + objUser.strUserName + " Status : delivered");
                                                //SummitShopApp.Utility.CommonFunctions.SaveUserAuditTrail(objVehicleStatusBL.ID, objMarUser.iUserId, objMarUser.iVehicleId);
                                                //SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Updated Entry in User Audit Trail Table for status : Delivered");
                                            }
                                        }
                                        if (IsUnsoldEstimate)
                                        {
                                            bMatch = true;
                                            objMarUser.bisShowInProcess = false;

                                            objUser.bIsShowEmailMarketing = true;
                                            objUser.bIsShowTextMarketing = true;
                                            objUser.dtUpdatedEntryTime = DateTime.Now;

                                            SummitShopApp.BL.VehicleStatusBL objVehicleStatusBL = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim() == "unsold estimate");
                                            if (objVehicleStatusBL != null)
                                            {
                                                iVehicleStatusId = objVehicleStatusBL.ID;
                                                bMatch = true;
                                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("shop : " + objMarUser.iShopId + " User : " + objUser.ID + " UserName " + objUser.strUserName + " Status : unsold estimate");
                                                //SummitShopApp.Utility.CommonFunctions.SaveUserAuditTrail(objVehicleStatusBL.ID, objMarUser.iUserId, objMarUser.iVehicleId);
                                                //SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Updated Entry in User Audit Trail Table for status : unsold Estimate");
                                            }
                                        }
                                        if (IsRepairOrder)
                                        {
                                            bMatch = true;
                                            objMarUser.bisShowInProcess = true;
                                            objUser.bIsShowEmailMarketing = false;
                                            objUser.bIsShowTextMarketing = false;
                                            objUser.dtUpdatedEntryTime = DateTime.Now;

                                            SummitShopApp.BL.VehicleStatusBL objVehicleStatusBL = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim() == "in process repairs");
                                            if (objVehicleStatusBL != null)
                                            {
                                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("shop : " + objMarUser.iShopId + " User : " + objUser.ID + " UserName " + objUser.strUserName + " Status : in process repairs");
                                                iVehicleStatusId = objVehicleStatusBL.ID;
                                                bMatch = true;
                                                if (objVehicleStatusBL.bMoveToMarketing.HasValue)
                                                {
                                                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("In Process Repairs (RO Number) has set Rule 'Move To Marketing' to true - customer moved to marketing area");
                                                    bIsMoveToMarketing = objVehicleStatusBL.bMoveToMarketing.Value;
                                                    objMarUser.bisShowInProcess = !bIsMoveToMarketing;
                                                    objUser.bIsShowEmailMarketing = bIsMoveToMarketing;
                                                    objUser.bIsShowTextMarketing = bIsMoveToMarketing;
                                                    //SummitShopApp.Utility.CommonFunctions.SaveUserAuditTrail(objVehicleStatusBL.ID, objMarUser.iUserId, objMarUser.iVehicleId);
                                                    //SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Updated Entry in User Audit Trail Table for status : In Process Repairs (Repair Order)");
                                                }
                                            }
                                        }
                                        try
                                        {
                                            System.Collections.Generic.List<SummitShopApp.BL.VehicleStatusBL> lstVehicleStatusForNewStatus = lstVehicleStatus.FindAll(v => v.strVehicleStatus.Replace("?", "").ToLower().Trim().Equals(objEMSData.status.Replace("�", "").ToLower().Trim()));
                                            if (lstVehicleStatusForNewStatus != null && lstVehicleStatusForNewStatus.Count > 0)
                                            {
                                                SummitShopApp.BL.VehicleStatusBL objVehicleStatusImportEstimateBLT = lstVehicleStatus.Find(v => v.strVehicleStatus.Replace("?", "").ToLower().Trim().Equals(objEMSData.status.Replace("�", "").ToLower().Trim()));

                                                if (objVehicleStatusImportEstimateBLT != null)
                                                {
                                                    iVehicleStatusId = objVehicleStatusImportEstimateBLT.ID;
                                                    bMatch = true;
                                                }
                                            }
                                            //lstVehicleStatus = SummitShopApp.BL.VehicleStatusBL.getDataByShopId(iAILogicShopID);
                                            //bMatch = true;
                                        }
                                        catch (Exception Ex)
                                        {
                                        }
                                        objMarUser.Save();
                                        objUser.Save();

                                    }
                                    catch (Exception ex)
                                    {
                                        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : New User Method Save() - - - - -  : while applying the New status of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                                    }

                                }
                                catch (Exception ex)
                                {
                                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : New User Method Save() - - - - -  : while applying the New status of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                                }
                            }

                            //Code added for Delivery Date - END
                            if (bMatch)
                            {
                                objCustomerVehicleStatus.iVehicleStatusId = iVehicleStatusId;
                                objCustomerVehicleStatus.dtLastUpdatedStatusDate = DateTime.Now;
                                //Code added for Delivery Date - START
                                if (IsDelivered)
                                {
                                    objCustomerVehicleStatus.dtDeliveryDate = dtDeliveryDate;

                                    //Add records into reoccuring and scheuduled campaign for delivered vehicle status
                                    try
                                    {
                                        //Add record into another table AIManageRecurringActivity - it will processed by AIManageRecurringActivity Service
                                        SummitShopApp.BL.AIManageRecurringActivityBL objAIManageRecurringActivityBL = SummitShopApp.BL.AIManageRecurringActivityBL.getDataByShopIdUserIdAndDeliveryDate(objUser.ID, iAILogicShopID, dtDeliveryDate.Value);
                                        if (objAIManageRecurringActivityBL == null)
                                        {
                                            objAIManageRecurringActivityBL = new SummitShopApp.BL.AIManageRecurringActivityBL();
                                            objAIManageRecurringActivityBL.iShopId = iAILogicShopID;
                                            objAIManageRecurringActivityBL.iUserId = objUser.ID;
                                            objAIManageRecurringActivityBL.dtDeliveryDate = dtDeliveryDate.Value;
                                            objAIManageRecurringActivityBL.Save();
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception :  New User Method Save() - - - - -  :for delivered status of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                                    }
                                }
                                //Code added for Delivery Date - END
                            }
                            else
                            {
                                SummitShopApp.BL.VehicleStatusBL _objVehicleStatus = new SummitShopApp.BL.VehicleStatusBL();
                                _objVehicleStatus.strVehicleStatus = "Imported Estimate";
                                _objVehicleStatus.strMessage = String.Empty;
                                _objVehicleStatus.iShopId = iAILogicShopID;
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

                            SummitShopApp.Utility.CommonFunctions.SaveUserAuditTrail(objCustomerVehicleStatus.iVehicleStatusId.Value, objMarUser.iUserId, objMarUser.iVehicleId);
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Updated Entry in User Audit Trail Table for status : " + objCustomerVehicleStatus.iVehicleStatusId.Value);

                            SummitShopApp.BL.InsuranceInformationBL objInsurance = new SummitShopApp.BL.InsuranceInformationBL();
                            objInsurance.iUserId = objUser.ID;
                            objInsurance.strCompanyName = objEMSData.strInsuranceCompanyName;
                            objInsurance.strCompanyAddress = objEMSData.strInsuranceCompanyAddress;
                            objInsurance.strCompanyCity = objEMSData.strInsuranceCompanyCity;
                            objInsurance.strCompanyState = objEMSData.strInsuranceCompanyState;
                            objInsurance.strCompanyZip = objEMSData.strInsuranceCompanyZipCode;
                            objInsurance.strCompanyEmail = objEMSData.strInsuranceCompanyEmail;
                            objInsurance.strCompanyCellPhone = objEMSData.strInsuranceCompanyPhone;
                            objInsurance.strCompanyFax = objEMSData.strInsuranceCompanyFax;
                            objInsurance.strAgentName = objEMSData.strInsuranceAgentName;
                            objInsurance.strClaimNumber = objEMSData.strClaimNumber;
                            if (!String.IsNullOrEmpty(objEMSData.strRONumbert) && !objEMSData.strRONumbert.Trim().Equals("0"))
                                objInsurance.strROIdentifier = objEMSData.strRONumbert;
                            else
                                objInsurance.strROIdentifier = String.Empty;
                            objInsurance.strNetTotalAmount = objEMSData.strNetTotalAmount;
                            DateTime dtDateofLoss;
                            Decimal dDeductible;
                            DateTime.TryParse(objInsurance.dtDateOfLoss.ToString(), out dtDateofLoss);
                            objInsurance.dtDateOfLoss = DateTime.TryParse(objEMSData.strDateOfLoss, out dtDateofLoss) ? dtDateofLoss : (Nullable<DateTime>)null;
                            objInsurance.dDeductible = Decimal.TryParse(objEMSData.strDeductible, out dDeductible) ? dDeductible : (Nullable<Decimal>)null;
                            objInsurance.Save();
                        }
                        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("New User Method Save END ()");
                        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic(Environment.NewLine);
                    }
                }
                #region Update Sync data
                //If file is already imported and matched with unique file idetifier then update data
                if (bUpdateData && _objMyCustomer != null)
                    updateEMSData_NewForCSVV(_objMyCustomer, objEMSData);
                #endregion
            }
        }
    }
    /// <summary>
    /// Sync the data from EMS file with data into database, if file was imported before.
    /// </summary>
    /// <param name="objInProcessUser"></param>
    /// <param name="objEMSData"></param>
    private void updateEMSData_NewForCSVV(SummitShopApp.BL.MyCustomerBL objMyCustomer, SummitShopApp.Utility.EMSData objEMSData)
    {
        try
        {
            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic(Environment.NewLine + "updateEMSData_New() start " + Environment.NewLine + "---------------------- UserName " + objMyCustomer.strUserName + " Shop : " + objMyCustomer.iShopId + " User : " + objMyCustomer.iUserId + " Current Status : " + objMyCustomer.iVehicleStatus + Environment.NewLine + "---------------------- Delivery Date " + objEMSData.strDeliveryDate + Environment.NewLine + " ---------------------- RO Number: " + objEMSData.strRONumbert + Environment.NewLine + "---------------------- Date In : " + objEMSData.strDateIn + Environment.NewLine + "---------------------- RO Complition Date: " + objEMSData.strDateOut_Ro_Cmp_Date + Environment.NewLine + "---------------------- Tar Date Out: " + objEMSData.strDateOut_Tar_Date);

            //Code added for Delivery Date - START
            Boolean IsDelivered = false;
            DateTime dtDeliveryDateTemp;
            DateTime? dtDeliveryDate = null;
            Boolean IsUnsoldEstimate = false;
            Boolean IsRepairOrder = false;

            Boolean bIsMoveToMarketing = false;
            try
            {
                SummitShopApp.BL.VehicleStatusBL objVehicleStatus = SummitShopApp.BL.VehicleStatusBL.getDataByShopIdAndStatus(objMyCustomer.iShopId, "Imported Estimate");
                if (objVehicleStatus != null && objVehicleStatus.bMoveToMarketing.HasValue)
                {
                    bIsMoveToMarketing = objVehicleStatus.bMoveToMarketing.Value;
                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Imported Estimate has set Rule 'Move To Marketing' to true");
                }
            }
            catch (Exception) { }
            try
            {
                dtDeliveryDate = DateTime.TryParse(objEMSData.strDeliveryDate, out dtDeliveryDateTemp) ? dtDeliveryDateTemp : (Nullable<DateTime>)null;
                if (dtDeliveryDate.HasValue && dtDeliveryDate.Value >= Convert.ToDateTime("01/01/1970"))
                {
                    IsDelivered = true;//TODO - True
                }
            }
            catch (Exception ex)
            {
                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : While Converting the strDeliveryDate");
            }
            //Update the Vehicle Info
            if (objMyCustomer.iVehicleId.HasValue)
                updateVehicleData(objMyCustomer.iVehicleId.Value, objEMSData);


            //Update the New User Data
            if (objMyCustomer.iUserId.HasValue && updateUserData_New(objMyCustomer, objEMSData))
            {
                //Update the Vehicle Status
                SummitShopApp.BL.UserVehicleStatusBL objCustomerVehicleStatus = null;
                if (objMyCustomer.iVehicleId.HasValue)
                {
                    objCustomerVehicleStatus = SummitShopApp.BL.UserVehicleStatusBL.getDataByVehicleId(objMyCustomer.iVehicleId.Value);
                    if (objCustomerVehicleStatus == null)
                    {
                        objCustomerVehicleStatus = new SummitShopApp.BL.UserVehicleStatusBL();
                    }
                    objCustomerVehicleStatus.iUserId = objMyCustomer.iUserId.Value;
                    objCustomerVehicleStatus.iVehicleId = objMyCustomer.iVehicleId.Value;
                    if (IsDelivered)
                    {
                        objCustomerVehicleStatus.dtDeliveryDate = dtDeliveryDate;
                    }
                    //if (objCustomerVehicleStatus.Save())
                    //{
                    //SummitShopApp.BL.MarketingUsers objMarketingUser = SummitShopApp.BL.MarketingUsers.getDataByShopUserAndVehicleId(objMyCustomer.iShopId, objMyCustomer.iUserId.Value, objMyCustomer.iVehicleId.Value);
                    //if (objMarketingUser != null)
                    //{
                    //    objMarketingUser.bisShowInProcess = false;
                    //    objMarketingUser.Save();
                    //}

                    //}

                    SummitShopApp.BL.UserBL objUser = SummitShopApp.BL.UserBL.getByActivityId(objMyCustomer.iUserId.Value);

                    String strFormatedUserName = String.IsNullOrEmpty(objEMSData.strUserName) ? String.Empty : objEMSData.strUserName.Trim();
                    if (strFormatedUserName.Length > 50)
                    {
                        strFormatedUserName = strFormatedUserName.Substring(0, 50);
                    }
                    objUser.strUserName = strFormatedUserName;
                    objUser.strFirstName = objEMSData.strOwnerFirstName;
                    objUser.strLastName = objEMSData.strOwnerLastName;
                    objUser.strPhone = objEMSData.strOwnerPhone1;
                    objUser.strPhone2 = objEMSData.strOwnerPhone2;

                    String strFormatedEmail = String.IsNullOrEmpty(objEMSData.strOwnerEmail) ? String.Empty : objEMSData.strOwnerEmail.Trim();
                    if (strFormatedEmail.Length > 50)
                    {
                        strFormatedEmail = strFormatedEmail.Substring(0, 50);
                    }

                    objUser.strEmail = strFormatedEmail;
                    objUser.strAddress1 = objEMSData.strOwnerAddress1;
                    objUser.strAddress2 = objEMSData.strOwnerAddress2;
                    objUser.strCity = objEMSData.strOwnerCity;
                    objUser.strState = objEMSData.strOwnerState;
                    objUser.strZip = objEMSData.strOwnerZipCode;
                    if (!String.IsNullOrEmpty(Request.QueryString["ImportEMSDataTo"]) && (Request.QueryString["ImportEMSDataTo"].ToLower() == "emailmarketing" || Request.QueryString["ImportEMSDataTo"].ToLower() == "textmarketing"))
                    {
                        objUser.bIsShowEmailMarketing = true;
                        objUser.bIsShowTextMarketing = true;
                    }
                    //Code added for Delivery Date - START
                    if (IsDelivered || bIsMoveToMarketing)
                    {
                        objUser.bIsShowEmailMarketing = true;
                        objUser.bIsShowTextMarketing = true;
                    }
                    if (!String.IsNullOrEmpty(objEMSData.status) && objEMSData.status.ToLower().Trim().Equals("cancel"))
                    {
                        objUser.bIsShowEmailMarketing = false;
                        objUser.bIsShowTextMarketing = false;
                        objUser.bIsShow = false;
                        objUser.dtUpdatedEntryTime = DateTime.Now;
                    }
                    if (objUser.Save())
                    {
                        SummitShopApp.BL.VehicleInfoBL objVehicleInfo = SummitShopApp.BL.VehicleInfoBL.getDataId(objMyCustomer.iVehicleId.Value);
                        objVehicleInfo.iUserId = objUser.ID;
                        objVehicleInfo.strYear = objEMSData.strYear;
                        objVehicleInfo.strMake = objEMSData.strMake;
                        objVehicleInfo.strModel = objEMSData.strModel;
                        objVehicleInfo.strStyle = objEMSData.strStyle;
                        objVehicleInfo.strColor = objEMSData.strColor;
                        objVehicleInfo.strPaintCode = objEMSData.strPaintCode;
                        objVehicleInfo.strVIN = objEMSData.strVIN;
                        objVehicleInfo.strLicense = objEMSData.strLicense;
                        objVehicleInfo.strEstimatorName = objEMSData.strEstimatorName;
                        objVehicleInfo.strEstimateFileIdentifier = objEMSData.strEstimateFileId;
                        DateTime dtProductionDate;
                        objVehicleInfo.dtProductionDate = DateTime.TryParse("", out dtProductionDate) ? dtProductionDate : (Nullable<DateTime>)null;
                        objVehicleInfo.bIsUsing = true;
                        objVehicleInfo.Save();
                        SummitShopApp.BL.MarketingUsers objMarUser = SummitShopApp.BL.MarketingUsers.getDataByShopAndUserId(objMyCustomer.iShopId, objMyCustomer.iUserId.Value);
                        objMarUser.iShopId = objMyCustomer.iShopId;
                        objMarUser.iUserId = objUser.ID;
                        objMarUser.iVehicleId = objVehicleInfo.ID;
                        //Code added for Delivery Date - START
                        if (IsDelivered || bIsMoveToMarketing)
                            objMarUser.bisShowInProcess = false;
                        else
                            objMarUser.bisShowInProcess = true;
                        if (!String.IsNullOrEmpty(objEMSData.status) && objEMSData.status.ToLower().Trim().Equals("cancel"))
                        {
                            objMarUser.bisShowInProcess = false;
                        }
                        //Code added for Delivery Date - END
                        objMarUser.iVehicleId = objVehicleInfo.ID;
                        objMarUser.Save();
                        objCustomerVehicleStatus.iUserId = objUser.ID;
                        objCustomerVehicleStatus.iVehicleId = objVehicleInfo.ID;

                        //If we get the Env.RO_No field, it will be saved in the 'RO Number' field and the status of the file would be 'Repair Order' - 3 Hrs

                        try
                        {
                            if (!String.IsNullOrEmpty(objEMSData.strRONumbert) && !objEMSData.strRONumbert.Trim().Equals("0"))
                            {
                                IsRepairOrder = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : Update User Method () - - - - -  :for checking the RO Number of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                        }

                        //If we get the RO_In_Date for a customer, need to set that file to 'Repair Order' status - 3 Hrs
                        //If we get both RO_In_Date and the Env.RO_No for a customer, need to set that file to 'Repair Order' status - 0 Hrs [Handled in above 2 conditions]
                        DateTime dtDateInTemp;
                        DateTime? dtDateIn = null;
                        try
                        {
                            dtDateIn = DateTime.TryParse(objEMSData.strDateIn, out dtDateInTemp) ? dtDateInTemp : (Nullable<DateTime>)null;
                            if (dtDateIn.HasValue && dtDateIn.Value >= Convert.ToDateTime("01/01/1970"))
                            {
                                objCustomerVehicleStatus.dtDateIn = dtDateIn;
                                IsRepairOrder = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : Update User Method () - - - - -  :for checking the RO Date In of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                        }
                        DateTime dtDateOutTemp_TAR_DATE;
                        DateTime? dtDateOut_TAR_DATE;
                        DateTime dtDateOutTemp_RO_CMPDATE;
                        DateTime? dtDateOut_RO_CMPDATE;
                        try
                        {
                            dtDateOut_RO_CMPDATE = DateTime.TryParse(objEMSData.strDateOut_Ro_Cmp_Date, out dtDateOutTemp_RO_CMPDATE) ? dtDateOutTemp_RO_CMPDATE : (Nullable<DateTime>)null;
                            dtDateOut_TAR_DATE = DateTime.TryParse(objEMSData.strDateOut_Tar_Date, out dtDateOutTemp_TAR_DATE) ? dtDateOutTemp_TAR_DATE : (Nullable<DateTime>)null;

                            if (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value >= Convert.ToDateTime("01/01/1970"))
                            {
                                objCustomerVehicleStatus.dtDateOut = dtDateOut_TAR_DATE;
                            }
                            else if (dtDateOut_RO_CMPDATE.HasValue && dtDateOut_RO_CMPDATE.Value >= Convert.ToDateTime("01/01/1970"))
                            {
                                objCustomerVehicleStatus.dtDateOut = dtDateOut_RO_CMPDATE;
                            }
                            //added code for
                            //If we get the RO_TAR_Date for a customer, need to set that file to 'Delivered' with the delivery date being set what the TAR_Date field has - 4 Hrs
                            //If the Tar_Date is a future date we should mark the file as 'Delivered' and start the triggers(automation emails and sms) if the Tar_Date is equal to the actual date 

                            //15 April 2016 Changes 
                            //1. where the Date_Out will replace the Tar_Date and the customer will be marked as delivered when there is Date_Out for an estimate
                            //2. where tghe customer should be in Repair Order Status if the Tar_Date is a future date and should change to delivered when the Tar_Date is equal to or greater than the actual date
                            try
                            {
                                if ((dtDateOut_RO_CMPDATE.HasValue && dtDateOut_RO_CMPDATE.Value >= Convert.ToDateTime("01/01/1970")) || (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value >= Convert.ToDateTime("01/01/1970")))
                                {

                                    if (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value >= Convert.ToDateTime("01/01/1970"))
                                    {
                                        dtDeliveryDate = dtDateOut_TAR_DATE.Value;
                                    }
                                    if (dtDateOut_RO_CMPDATE.HasValue && dtDateOut_RO_CMPDATE.Value >= Convert.ToDateTime("01/01/1970"))
                                    {
                                        dtDeliveryDate = dtDateOut_RO_CMPDATE.Value;
                                    }
                                    if (dtDeliveryDate.Value > DateTime.Now)
                                    {
                                        IsRepairOrder = true;
                                        objCustomerVehicleStatus.dtDeliveryDate = dtDeliveryDate;
                                    }
                                    else
                                    {
                                        IsDelivered = true;
                                        IsUnsoldEstimate = false;
                                        IsRepairOrder = false;

                                        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Update shop : " + objMyCustomer.iShopId + " User : " + objMyCustomer.iUserId + " UserName " + objMyCustomer.strUserName + " dtDateOut_TAR_DATE " + dtDateOut_TAR_DATE.Value.ToString() + "Converted Status : Delivered ");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : Update User Method () - - - - -  :for TarDate and RO cmp Date conversion In of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                            }
                            try
                            {
                                //If we do not get the RO_In_Date, Tar_Date and Env_RO_No, then the status of that file would be 'Unsold Estimate' - 3 Hrs
                                if (!IsDelivered && !IsRepairOrder && (dtDateOut_TAR_DATE == null || (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value <= Convert.ToDateTime("01/01/1970"))))
                                {
                                    IsUnsoldEstimate = true;
                                    IsDelivered = false;
                                    IsRepairOrder = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception :  Update User Method () - - - - -  :for unsold Estimate Flag conversion In of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                            }
                            System.Collections.Generic.List<SummitShopApp.BL.VehicleStatusBL> lstVehicleStatus = new System.Collections.Generic.List<SummitShopApp.BL.VehicleStatusBL>();
                            lstVehicleStatus = SummitShopApp.BL.VehicleStatusBL.getDataByShopId(objMyCustomer.iShopId);

                            SummitShopApp.BL.VehicleStatusBL objVehicleStatusBLForNewStatus = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim().Equals(objEMSData.status.ToLower().Trim()));
                            if (objVehicleStatusBLForNewStatus == null)
                            {
                                if (!String.IsNullOrEmpty(objEMSData.status) && !objEMSData.status.ToLower().Trim().Equals("cancel"))
                                {
                                    SummitShopApp.BL.VehicleStatusBL objVehicleStatusBL = new SummitShopApp.BL.VehicleStatusBL();
                                    objVehicleStatusBL.iShopId = Convert.ToInt32(objMyCustomer.iShopId);
                                    objVehicleStatusBL.strVehicleStatus = objEMSData.status;
                                    objVehicleStatusBL.bIsActive = true;
                                    objVehicleStatusBL.Save();
                                    objCustomerVehicleStatus.iVehicleStatusId = objVehicleStatusBL.ID;
                                    objCustomerVehicleStatus.dtLastUpdatedStatusDate = DateTime.Now;
                                    objUser.dtUpdatedEntryTime = DateTime.Now;
                                }
                            }
                            lstVehicleStatus = SummitShopApp.BL.VehicleStatusBL.getDataByShopId(objMyCustomer.iShopId);
                            if (IsDelivered)
                            {
                                objMarUser.bisShowInProcess = false;
                                objUser.bIsShowEmailMarketing = true;
                                objUser.bIsShowTextMarketing = true;

                                SummitShopApp.BL.VehicleStatusBL objVehicleStatusBL = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim() == "delivered");
                                if (objVehicleStatusBL != null)
                                {
                                    if (objCustomerVehicleStatus.iVehicleStatusId.HasValue && objCustomerVehicleStatus.iVehicleStatusId != objVehicleStatusBL.ID)
                                    {
                                        if (!String.IsNullOrEmpty(objEMSData.status) && objEMSData.status.ToLower().Trim().Equals("delivered"))
                                        {
                                            SummitShopApp.Utility.CommonFunctions.SaveUserAuditTrail(objCustomerVehicleStatus.iVehicleStatusId.Value, objMarUser.iUserId, objMarUser.iVehicleId);
                                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Updated Entry in User Audit Trail Table for old status ID : " + objCustomerVehicleStatus.iVehicleStatusId.Value);
                                            objCustomerVehicleStatus.dtLastUpdatedStatusDate = DateTime.Now;
                                            objUser.dtUpdatedEntryTime = DateTime.Now;
                                            objCustomerVehicleStatus.iVehicleStatusId = objVehicleStatusBL.ID;
                                        }
                                    }
                                    objCustomerVehicleStatus.dtDeliveryDate = dtDeliveryDate;
                                    //Add record into another table AIManageRecurringActivity - it will processed by AIManageRecurringActivity Service
                                    SummitShopApp.BL.AIManageRecurringActivityBL objAIManageRecurringActivityBL = SummitShopApp.BL.AIManageRecurringActivityBL.getDataByShopIdUserIdAndDeliveryDate(objMyCustomer.iUserId.Value, objMyCustomer.iShopId, dtDeliveryDate.Value);
                                    if (objAIManageRecurringActivityBL == null)
                                    {
                                        objAIManageRecurringActivityBL = new SummitShopApp.BL.AIManageRecurringActivityBL();
                                        objAIManageRecurringActivityBL.iShopId = objMyCustomer.iShopId;
                                        objAIManageRecurringActivityBL.iUserId = objMyCustomer.iUserId.Value;
                                        objAIManageRecurringActivityBL.dtDeliveryDate = dtDeliveryDate.Value;
                                        objAIManageRecurringActivityBL.Save();
                                    }
                                }
                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Update Information shop : " + objMyCustomer.iShopId + " User : " + objMyCustomer.iUserId + " UserName " + objMyCustomer.strUserName + " Converted Status Final : Delivered");
                            }
                            if (IsUnsoldEstimate)
                            {

                                objMarUser.bisShowInProcess = false;
                                objUser.bIsShowEmailMarketing = true;
                                objUser.bIsShowTextMarketing = true;

                                SummitShopApp.BL.VehicleStatusBL objVehicleStatusBL = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim() == "unsold estimate");
                                if (objVehicleStatusBL != null)
                                {
                                    if (objCustomerVehicleStatus.iVehicleStatusId.HasValue && objCustomerVehicleStatus.iVehicleStatusId != objVehicleStatusBL.ID)
                                    {

                                        if (!String.IsNullOrEmpty(objEMSData.status) && objEMSData.status.ToLower().Trim().Equals("unsoldestimate"))
                                        {
                                            SummitShopApp.Utility.CommonFunctions.SaveUserAuditTrail(objCustomerVehicleStatus.iVehicleStatusId.Value, objMarUser.iUserId, objMarUser.iVehicleId);
                                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Updated Entry in User Audit Trail Table for old status ID : " + objCustomerVehicleStatus.iVehicleStatusId.Value);

                                            objCustomerVehicleStatus.dtLastUpdatedStatusDate = DateTime.Now;
                                            objUser.dtUpdatedEntryTime = DateTime.Now;
                                            objCustomerVehicleStatus.iVehicleStatusId = objVehicleStatusBL.ID;
                                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Update Information shop : " + objMyCustomer.iShopId + " User : " + objMyCustomer.iUserId + " UserName " + objMyCustomer.strUserName + " Converted Status Final : unsold estimate");
                                        }
                                    }
                                }
                            }
                            if (IsRepairOrder)
                            {
                                objMarUser.bisShowInProcess = true;
                                objUser.bIsShowEmailMarketing = false;
                                objUser.bIsShowTextMarketing = false;

                                SummitShopApp.BL.VehicleStatusBL objVehicleStatusBL = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim() == "in process repairs");
                                if (objVehicleStatusBL != null)
                                {
                                    if (objCustomerVehicleStatus.iVehicleStatusId.HasValue && objCustomerVehicleStatus.iVehicleStatusId != objVehicleStatusBL.ID)
                                    {
                                        if (!String.IsNullOrEmpty(objEMSData.status) && objEMSData.status.ToLower().Trim().Equals("inprocessrepairs"))
                                        {

                                            SummitShopApp.Utility.CommonFunctions.SaveUserAuditTrail(objCustomerVehicleStatus.iVehicleStatusId.Value, objMarUser.iUserId, objMarUser.iVehicleId);
                                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Updated Entry in User Audit Trail Table for old status ID : " + objCustomerVehicleStatus.iVehicleStatusId.Value);

                                            objCustomerVehicleStatus.dtLastUpdatedStatusDate = DateTime.Now;
                                            objUser.dtUpdatedEntryTime = DateTime.Now;

                                            if (objVehicleStatusBL.bMoveToMarketing.HasValue)
                                            {
                                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("In Process Repairs (RO Number) has set Rule 'Move To Marketing' to true");
                                                bIsMoveToMarketing = objVehicleStatusBL.bMoveToMarketing.Value;
                                                objMarUser.bisShowInProcess = !bIsMoveToMarketing;
                                                objUser.bIsShowEmailMarketing = bIsMoveToMarketing;
                                                objUser.bIsShowTextMarketing = bIsMoveToMarketing;
                                            }
                                            objCustomerVehicleStatus.iVehicleStatusId = objVehicleStatusBL.ID;
                                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Update Information shop : " + objMyCustomer.iShopId + " User : " + objMyCustomer.iUserId + " UserName " + objMyCustomer.strUserName + " Converted Status Final : in process repairs");
                                        }
                                    }
                                }
                            }
                            #region NewVehicleStatus
                            try
                            {
                                if (!String.IsNullOrEmpty(objEMSData.status) && (!objEMSData.status.ToLower().Trim().Equals("inprocessrepairs") && !objEMSData.status.ToLower().Trim().Equals("delivered") && !objEMSData.status.ToLower().Trim().Equals("unsoldestimate")))
                                {
                                    SummitShopApp.BL.VehicleStatusBL objVehicleStatusBL = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim().Equals(objEMSData.status.ToLower().Trim()));
                                    if (objVehicleStatusBL != null)
                                    {
                                        objCustomerVehicleStatus.iVehicleStatusId = objVehicleStatusBL.ID;
                                        if (objCustomerVehicleStatus.iVehicleStatusId.HasValue && objCustomerVehicleStatus.iVehicleStatusId != objVehicleStatusBL.ID)
                                        {
                                            SummitShopApp.Utility.CommonFunctions.SaveUserAuditTrail(objCustomerVehicleStatus.iVehicleStatusId.Value, objMarUser.iUserId, objMarUser.iVehicleId);
                                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Updated Entry in User Audit Trail Table for old status ID : " + objCustomerVehicleStatus.iVehicleStatusId.Value);

                                            objCustomerVehicleStatus.dtLastUpdatedStatusDate = DateTime.Now;
                                            objUser.dtUpdatedEntryTime = DateTime.Now;
                                            if (objVehicleStatusBL.bMoveToMarketing.HasValue)
                                            {
                                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("New Vehicle Status has set Rule 'Move To Marketing' to true" + objVehicleStatusBL.strVehicleStatus);
                                                bIsMoveToMarketing = objVehicleStatusBL.bMoveToMarketing.Value;
                                                objMarUser.bisShowInProcess = !bIsMoveToMarketing;
                                                objUser.bIsShowEmailMarketing = bIsMoveToMarketing;
                                                objUser.bIsShowTextMarketing = bIsMoveToMarketing;
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception Ex)
                            {
                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception :  Save New Vehicle Status- - - - -  for Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + Ex.ToString());
                            }
                            #endregion
                            objMarUser.Save();
                            objUser.Save();
                            objCustomerVehicleStatus.Save();
                        }
                        catch (Exception ex)
                        {
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception :  Update User Method () - - - - -  : While Applying the new status In of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                        }
                    }
                    updateInsuranceData(objMyCustomer.iUserId.Value, objEMSData);
                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Update Information shop : " + objMyCustomer.iShopId + " User : " + objMyCustomer.iUserId + " UserName " + objMyCustomer.strUserName + " updated Insurance Data");
                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("updateEMSData_New() end ");
                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic(Environment.NewLine);
                }
            }
        }
        catch (Exception ex)
        {
            Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
        }
    }
    /// <summary>
    /// Sync the data from EMS file with data into database, if file was imported before.
    /// </summary>
    /// <param name="objInProcessUser"></param>
    /// <param name="objEMSData"></param>
    private void updateEMSData_NewForCSVForDeletedUser(SummitShopApp.BL.InProcessUsersBL objMyCustomer, SummitShopApp.Utility.EMSData objEMSData)
    {
        try
        {
            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic(Environment.NewLine + "updateEMSData_New() start " + Environment.NewLine + "---------------------- UserName " + objMyCustomer.strUserName + " Shop : " + objMyCustomer.iShopId + " User : " + objMyCustomer.iUserId + " Current Status : " + objMyCustomer.iVehicleStatus + Environment.NewLine + "---------------------- Delivery Date " + objEMSData.strDeliveryDate + Environment.NewLine + " ---------------------- RO Number: " + objEMSData.strRONumbert + Environment.NewLine + "---------------------- Date In : " + objEMSData.strDateIn + Environment.NewLine + "---------------------- RO Complition Date: " + objEMSData.strDateOut_Ro_Cmp_Date + Environment.NewLine + "---------------------- Tar Date Out: " + objEMSData.strDateOut_Tar_Date);

            //Code added for Delivery Date - START
            Boolean IsDelivered = false;
            DateTime dtDeliveryDateTemp;
            DateTime? dtDeliveryDate = null;
            Boolean IsUnsoldEstimate = false;
            Boolean IsRepairOrder = false;

            Boolean bIsMoveToMarketing = false;
            try
            {
                SummitShopApp.BL.VehicleStatusBL objVehicleStatus = SummitShopApp.BL.VehicleStatusBL.getDataByShopIdAndStatus(objMyCustomer.iShopId.Value, "Imported Estimate");
                if (objVehicleStatus != null && objVehicleStatus.bMoveToMarketing.HasValue)
                {
                    bIsMoveToMarketing = objVehicleStatus.bMoveToMarketing.Value;
                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Imported Estimate has set Rule 'Move To Marketing' to true");
                }
            }
            catch (Exception) { }

            try
            {
                dtDeliveryDate = DateTime.TryParse(objEMSData.strDeliveryDate, out dtDeliveryDateTemp) ? dtDeliveryDateTemp : (Nullable<DateTime>)null;
                if (dtDeliveryDate.HasValue && dtDeliveryDate.Value >= Convert.ToDateTime("01/01/1970"))
                {
                    IsDelivered = true;//TODO - True
                }
            }
            catch (Exception ex)
            {
                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : While Converting the strDeliveryDate");
            }
            //Update the Vehicle Info
            if (objMyCustomer.iVehicleId.HasValue)
                updateVehicleData(objMyCustomer.iVehicleId.Value, objEMSData);


            //Update the New User Data
            if (objMyCustomer.iUserId.HasValue)
            {
                //Update the Vehicle Status
                SummitShopApp.BL.UserVehicleStatusBL objCustomerVehicleStatus = null;
                if (objMyCustomer.iVehicleId.HasValue)
                {
                    objCustomerVehicleStatus = SummitShopApp.BL.UserVehicleStatusBL.getDataByVehicleId(objMyCustomer.iVehicleId.Value);
                    if (objCustomerVehicleStatus == null)
                    {
                        objCustomerVehicleStatus = new SummitShopApp.BL.UserVehicleStatusBL();
                    }
                    objCustomerVehicleStatus.iUserId = objMyCustomer.iUserId.Value;
                    objCustomerVehicleStatus.iVehicleId = objMyCustomer.iVehicleId.Value;
                    if (IsDelivered)
                    {
                        objCustomerVehicleStatus.dtDeliveryDate = dtDeliveryDate;
                    }
                    //if (objCustomerVehicleStatus.Save())
                    //{
                    //SummitShopApp.BL.MarketingUsers objMarketingUser = SummitShopApp.BL.MarketingUsers.getDataByShopUserAndVehicleId(objMyCustomer.iShopId, objMyCustomer.iUserId.Value, objMyCustomer.iVehicleId.Value);
                    //if (objMarketingUser != null)
                    //{
                    //    objMarketingUser.bisShowInProcess = false;
                    //    objMarketingUser.Save();
                    //}

                    //}

                    SummitShopApp.BL.UserBL objUser = SummitShopApp.BL.UserBL.getByActivityId(objMyCustomer.iUserId.Value);

                    String strFormatedUserName = String.IsNullOrEmpty(objEMSData.strUserName) ? String.Empty : objEMSData.strUserName.Trim();
                    if (strFormatedUserName.Length > 50)
                    {
                        strFormatedUserName = strFormatedUserName.Substring(0, 50);
                    }
                    objUser.strUserName = strFormatedUserName;
                    objUser.strFirstName = objEMSData.strOwnerFirstName;
                    objUser.strLastName = objEMSData.strOwnerLastName;
                    objUser.strPhone = objEMSData.strOwnerPhone1;
                    objUser.strPhone2 = objEMSData.strOwnerPhone2;

                    String strFormatedEmail = String.IsNullOrEmpty(objEMSData.strOwnerEmail) ? String.Empty : objEMSData.strOwnerEmail.Trim();
                    if (strFormatedEmail.Length > 50)
                    {
                        strFormatedEmail = strFormatedEmail.Substring(0, 50);
                    }

                    objUser.strEmail = strFormatedEmail;
                    objUser.strAddress1 = objEMSData.strOwnerAddress1;
                    objUser.strAddress2 = objEMSData.strOwnerAddress2;
                    objUser.strCity = objEMSData.strOwnerCity;
                    objUser.strState = objEMSData.strOwnerState;
                    objUser.strZip = objEMSData.strOwnerZipCode;
                    if (!String.IsNullOrEmpty(Request.QueryString["ImportEMSDataTo"]) && (Request.QueryString["ImportEMSDataTo"].ToLower() == "emailmarketing" || Request.QueryString["ImportEMSDataTo"].ToLower() == "textmarketing"))
                    {
                        objUser.bIsShowEmailMarketing = true;
                        objUser.bIsShowTextMarketing = true;
                    }

                    //Code added for Delivery Date - START
                    if (IsDelivered || bIsMoveToMarketing)
                    {
                        objUser.bIsShowEmailMarketing = true;
                        objUser.bIsShowTextMarketing = true;
                    }
                    if (!String.IsNullOrEmpty(objEMSData.status) && objEMSData.status.ToLower().Trim().Equals("cancel"))
                    {
                        objUser.bIsShowEmailMarketing = false;
                        objUser.bIsShowTextMarketing = false;
                        objUser.bIsShow = false;
                        objUser.dtUpdatedEntryTime = DateTime.Now;
                    }
                    //Code added for Delivery Date - END
                    objUser.dtUpdatedEntryTime = DateTime.Now;

                    if (objUser.Save())
                    {
                        SummitShopApp.BL.VehicleInfoBL objVehicleInfo = SummitShopApp.BL.VehicleInfoBL.getDataId(objMyCustomer.iVehicleId.Value);
                        objVehicleInfo.iUserId = objUser.ID;
                        objVehicleInfo.strYear = objEMSData.strYear;
                        objVehicleInfo.strMake = objEMSData.strMake;
                        objVehicleInfo.strModel = objEMSData.strModel;
                        objVehicleInfo.strStyle = objEMSData.strStyle;
                        objVehicleInfo.strColor = objEMSData.strColor;
                        objVehicleInfo.strPaintCode = objEMSData.strPaintCode;
                        objVehicleInfo.strVIN = objEMSData.strVIN;
                        objVehicleInfo.strLicense = objEMSData.strLicense;
                        objVehicleInfo.strEstimatorName = objEMSData.strEstimatorName;
                        objVehicleInfo.strEstimateFileIdentifier = objEMSData.strEstimateFileId;
                        DateTime dtProductionDate;
                        objVehicleInfo.dtProductionDate = DateTime.TryParse("", out dtProductionDate) ? dtProductionDate : (Nullable<DateTime>)null;
                        objVehicleInfo.bIsUsing = true;
                        objVehicleInfo.Save();
                        SummitShopApp.BL.MarketingUsers objMarUser = SummitShopApp.BL.MarketingUsers.getDataByShopAndUserId(objMyCustomer.iShopId.Value, objMyCustomer.iUserId.Value);
                        objMarUser.iShopId = objMyCustomer.iShopId.Value;
                        objMarUser.iUserId = objUser.ID;
                        objMarUser.iVehicleId = objVehicleInfo.ID;
                        //Code added for Delivery Date - START
                        if (IsDelivered || bIsMoveToMarketing)
                            objMarUser.bisShowInProcess = false;
                        else
                            objMarUser.bisShowInProcess = true;
                        if (!String.IsNullOrEmpty(objEMSData.status) && objEMSData.status.ToLower().Trim().Equals("cancel"))
                        {
                            objMarUser.bisShowInProcess = false;
                        }

                        //Code added for Delivery Date - END

                        objMarUser.iVehicleId = objVehicleInfo.ID;
                        objMarUser.Save();

                        objCustomerVehicleStatus.iUserId = objUser.ID;
                        objCustomerVehicleStatus.iVehicleId = objVehicleInfo.ID;

                        //If we get the Env.RO_No field, it will be saved in the 'RO Number' field and the status of the file would be 'Repair Order' - 3 Hrs

                        try
                        {
                            if (!String.IsNullOrEmpty(objEMSData.strRONumbert) && !objEMSData.strRONumbert.Trim().Equals("0"))
                            {
                                IsRepairOrder = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : Update User Method () - - - - -  :for checking the RO Number of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                        }

                        //If we get the RO_In_Date for a customer, need to set that file to 'Repair Order' status - 3 Hrs
                        //If we get both RO_In_Date and the Env.RO_No for a customer, need to set that file to 'Repair Order' status - 0 Hrs [Handled in above 2 conditions]
                        DateTime dtDateInTemp;
                        DateTime? dtDateIn = null;
                        try
                        {
                            dtDateIn = DateTime.TryParse(objEMSData.strDateIn, out dtDateInTemp) ? dtDateInTemp : (Nullable<DateTime>)null;
                            if (dtDateIn.HasValue && dtDateIn.Value >= Convert.ToDateTime("01/01/1970"))
                            {
                                objCustomerVehicleStatus.dtDateIn = dtDateIn;
                                IsRepairOrder = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : Update User Method () - - - - -  :for checking the RO Date In of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                        }
                        DateTime dtDateOutTemp_TAR_DATE;
                        DateTime? dtDateOut_TAR_DATE;
                        DateTime dtDateOutTemp_RO_CMPDATE;
                        DateTime? dtDateOut_RO_CMPDATE;
                        try
                        {
                            dtDateOut_RO_CMPDATE = DateTime.TryParse(objEMSData.strDateOut_Ro_Cmp_Date, out dtDateOutTemp_RO_CMPDATE) ? dtDateOutTemp_RO_CMPDATE : (Nullable<DateTime>)null;
                            dtDateOut_TAR_DATE = DateTime.TryParse(objEMSData.strDateOut_Tar_Date, out dtDateOutTemp_TAR_DATE) ? dtDateOutTemp_TAR_DATE : (Nullable<DateTime>)null;

                            if (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value >= Convert.ToDateTime("01/01/1970"))
                            {
                                objCustomerVehicleStatus.dtDateOut = dtDateOut_TAR_DATE;
                            }
                            else if (dtDateOut_RO_CMPDATE.HasValue && dtDateOut_RO_CMPDATE.Value >= Convert.ToDateTime("01/01/1970"))
                            {
                                objCustomerVehicleStatus.dtDateOut = dtDateOut_RO_CMPDATE;
                            }
                            //added code for
                            //If we get the RO_TAR_Date for a customer, need to set that file to 'Delivered' with the delivery date being set what the TAR_Date field has - 4 Hrs
                            //If the Tar_Date is a future date we should mark the file as 'Delivered' and start the triggers(automation emails and sms) if the Tar_Date is equal to the actual date 

                            //15 April 2016 Changes 
                            //1. where the Date_Out will replace the Tar_Date and the customer will be marked as delivered when there is Date_Out for an estimate
                            //2. where tghe customer should be in Repair Order Status if the Tar_Date is a future date and should change to delivered when the Tar_Date is equal to or greater than the actual date
                            try
                            {
                                if ((dtDateOut_RO_CMPDATE.HasValue && dtDateOut_RO_CMPDATE.Value >= Convert.ToDateTime("01/01/1970")) || (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value >= Convert.ToDateTime("01/01/1970")))
                                {

                                    if (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value >= Convert.ToDateTime("01/01/1970"))
                                    {
                                        dtDeliveryDate = dtDateOut_TAR_DATE.Value;
                                    }
                                    if (dtDateOut_RO_CMPDATE.HasValue && dtDateOut_RO_CMPDATE.Value >= Convert.ToDateTime("01/01/1970"))
                                    {
                                        dtDeliveryDate = dtDateOut_RO_CMPDATE.Value;
                                    }
                                    if (dtDeliveryDate.Value > DateTime.Now)
                                    {
                                        IsRepairOrder = true;
                                        objCustomerVehicleStatus.dtDeliveryDate = dtDeliveryDate;
                                    }
                                    else
                                    {
                                        IsDelivered = true;
                                        IsUnsoldEstimate = false;
                                        IsRepairOrder = false;

                                        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Update shop : " + objMyCustomer.iShopId + " User : " + objMyCustomer.iUserId + " UserName " + objMyCustomer.strUserName + " dtDateOut_TAR_DATE " + dtDateOut_TAR_DATE.Value.ToString() + "Converted Status : Delivered ");
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception : Update User Method () - - - - -  :for TarDate and RO cmp Date conversion In of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                            }
                            try
                            {
                                //If we do not get the RO_In_Date, Tar_Date and Env_RO_No, then the status of that file would be 'Unsold Estimate' - 3 Hrs
                                if (!IsDelivered && !IsRepairOrder && (dtDateOut_TAR_DATE == null || (dtDateOut_TAR_DATE.HasValue && dtDateOut_TAR_DATE.Value <= Convert.ToDateTime("01/01/1970"))))
                                {

                                    IsUnsoldEstimate = true;
                                    IsDelivered = false;
                                    IsRepairOrder = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception :  Update User Method () - - - - -  :for unsold Estimate Flag conversion In of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());

                            }
                            System.Collections.Generic.List<SummitShopApp.BL.VehicleStatusBL> lstVehicleStatus = new System.Collections.Generic.List<SummitShopApp.BL.VehicleStatusBL>();
                            lstVehicleStatus = SummitShopApp.BL.VehicleStatusBL.getDataByShopId(objMyCustomer.iShopId.Value);


                            if (IsDelivered)
                            {
                                objMarUser.bisShowInProcess = false;
                                objUser.bIsShowEmailMarketing = true;
                                objUser.bIsShowTextMarketing = true;

                                SummitShopApp.BL.VehicleStatusBL objVehicleStatusBL = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim() == "delivered");
                                if (objVehicleStatusBL != null)
                                {
                                    if (objCustomerVehicleStatus.iVehicleStatusId.HasValue && objCustomerVehicleStatus.iVehicleStatusId != objVehicleStatusBL.ID)
                                    {
                                        SummitShopApp.Utility.CommonFunctions.SaveUserAuditTrail(objCustomerVehicleStatus.iVehicleStatusId.Value, objMarUser.iUserId, objMarUser.iVehicleId);
                                        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Updated Entry in User Audit Trail Table for old status ID : " + objCustomerVehicleStatus.iVehicleStatusId.Value);

                                        objCustomerVehicleStatus.dtLastUpdatedStatusDate = DateTime.Now;
                                        objUser.dtUpdatedEntryTime = DateTime.Now;
                                    }

                                    objCustomerVehicleStatus.iVehicleStatusId = objVehicleStatusBL.ID;
                                    objCustomerVehicleStatus.dtDeliveryDate = dtDeliveryDate;
                                    //Add record into another table AIManageRecurringActivity - it will processed by AIManageRecurringActivity Service
                                    SummitShopApp.BL.AIManageRecurringActivityBL objAIManageRecurringActivityBL = SummitShopApp.BL.AIManageRecurringActivityBL.getDataByShopIdUserIdAndDeliveryDate(objMyCustomer.iUserId.Value, objMyCustomer.iShopId.Value, dtDeliveryDate.Value);
                                    if (objAIManageRecurringActivityBL == null)
                                    {
                                        objAIManageRecurringActivityBL = new SummitShopApp.BL.AIManageRecurringActivityBL();
                                        objAIManageRecurringActivityBL.iShopId = objMyCustomer.iShopId.Value;
                                        objAIManageRecurringActivityBL.iUserId = objMyCustomer.iUserId.Value;
                                        objAIManageRecurringActivityBL.dtDeliveryDate = dtDeliveryDate.Value;
                                        objAIManageRecurringActivityBL.Save();
                                    }
                                }
                                SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Update Information shop : " + objMyCustomer.iShopId + " User : " + objMyCustomer.iUserId + " UserName " + objMyCustomer.strUserName + " Converted Status Final : Delivered");
                            }
                            if (IsUnsoldEstimate)
                            {
                                objMarUser.bisShowInProcess = false;
                                objUser.bIsShowEmailMarketing = true;
                                objUser.bIsShowTextMarketing = true;

                                SummitShopApp.BL.VehicleStatusBL objVehicleStatusBL = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim() == "unsold estimate");
                                if (objVehicleStatusBL != null)
                                {
                                    if (objCustomerVehicleStatus.iVehicleStatusId.HasValue && objCustomerVehicleStatus.iVehicleStatusId != objVehicleStatusBL.ID)
                                    {
                                        SummitShopApp.Utility.CommonFunctions.SaveUserAuditTrail(objCustomerVehicleStatus.iVehicleStatusId.Value, objMarUser.iUserId, objMarUser.iVehicleId);
                                        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Updated Entry in User Audit Trail Table for old status ID : " + objCustomerVehicleStatus.iVehicleStatusId.Value);

                                        objCustomerVehicleStatus.dtLastUpdatedStatusDate = DateTime.Now;
                                        objUser.dtUpdatedEntryTime = DateTime.Now;
                                    }
                                    objCustomerVehicleStatus.iVehicleStatusId = objVehicleStatusBL.ID;
                                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Update Information shop : " + objMyCustomer.iShopId + " User : " + objMyCustomer.iUserId + " UserName " + objMyCustomer.strUserName + " Converted Status Final : unsold estimate");
                                }
                            }
                            if (IsRepairOrder)
                            {
                                objMarUser.bisShowInProcess = true;
                                objUser.bIsShowEmailMarketing = false;
                                objUser.bIsShowTextMarketing = false;

                                SummitShopApp.BL.VehicleStatusBL objVehicleStatusBL = lstVehicleStatus.Find(a => a.strVehicleStatus.ToLower().Trim() == "in process repairs");
                                if (objVehicleStatusBL != null)
                                {
                                    if (objCustomerVehicleStatus.iVehicleStatusId.HasValue && objCustomerVehicleStatus.iVehicleStatusId != objVehicleStatusBL.ID)
                                    {
                                        SummitShopApp.Utility.CommonFunctions.SaveUserAuditTrail(objCustomerVehicleStatus.iVehicleStatusId.Value, objMarUser.iUserId, objMarUser.iVehicleId);
                                        SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Updated Entry in User Audit Trail Table for old status ID : " + objCustomerVehicleStatus.iVehicleStatusId.Value);

                                        objCustomerVehicleStatus.dtLastUpdatedStatusDate = DateTime.Now;
                                        objUser.dtUpdatedEntryTime = DateTime.Now;


                                        if (objVehicleStatusBL.bMoveToMarketing.HasValue)
                                        {
                                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("In Process Repairs (RO Number) has set Rule 'Move To Marketing' to true");
                                            bIsMoveToMarketing = objVehicleStatusBL.bMoveToMarketing.Value;
                                            objMarUser.bisShowInProcess = !bIsMoveToMarketing;
                                            objUser.bIsShowEmailMarketing = bIsMoveToMarketing;
                                            objUser.bIsShowTextMarketing = bIsMoveToMarketing;


                                        }
                                    }
                                    objCustomerVehicleStatus.iVehicleStatusId = objVehicleStatusBL.ID;
                                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Update Information shop : " + objMyCustomer.iShopId + " User : " + objMyCustomer.iUserId + " UserName " + objMyCustomer.strUserName + " Converted Status Final : in process repairs");

                                }
                            }
                            try
                            {
                                if (lstVehicleStatus != null)
                                {
                                    System.Collections.Generic.List<SummitShopApp.BL.VehicleStatusBL> lstVehicleStatusForNewStatus = lstVehicleStatus.FindAll(v => v.strVehicleStatus.Replace("?", "").ToLower().Trim().Equals(objEMSData.status.Replace("�", "").ToLower().Trim()));

                                    if (lstVehicleStatusForNewStatus != null && lstVehicleStatusForNewStatus.Count > 0)
                                    {
                                        SummitShopApp.BL.VehicleStatusBL objVehicleStatusImportEstimateBLT = lstVehicleStatus.Find(v => v.strVehicleStatus.Replace("?", "").ToLower().Trim().Equals(objEMSData.status.Replace("�", "").ToLower().Trim()));

                                        if (objVehicleStatusImportEstimateBLT != null)
                                        {
                                            objCustomerVehicleStatus.iVehicleStatusId = objVehicleStatusImportEstimateBLT.ID;
                                        }
                                    }
                                    else
                                    {
                                        if (!String.IsNullOrEmpty(objEMSData.status))
                                        {
                                            if (objEMSData.status.ToLower().Trim().Equals("cancel"))
                                            { }
                                            else
                                            {
                                                SummitShopApp.BL.VehicleStatusBL objVehicleStatusImportEstimateBLN = new SummitShopApp.BL.VehicleStatusBL();
                                                objVehicleStatusImportEstimateBLN.iShopId = Convert.ToInt32(objMyCustomer.iShopId);
                                                objVehicleStatusImportEstimateBLN.strVehicleStatus = objEMSData.status.Replace("�", "");
                                                objVehicleStatusImportEstimateBLN.bIsActive = true;
                                                objVehicleStatusImportEstimateBLN.Save();
                                                objCustomerVehicleStatus.iVehicleStatusId = objVehicleStatusImportEstimateBLN.ID;
                                            }
                                        }
                                    }
                                }
                                lstVehicleStatus = SummitShopApp.BL.VehicleStatusBL.getDataByShopId(objMyCustomer.iShopId.Value);
                            }
                            catch (Exception Ex)
                            {
                            }
                            objMarUser.Save();
                            objUser.Save();
                            objCustomerVehicleStatus.Save();
                        }

                        catch (Exception ex)
                        {
                            SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Exception :  Update User Method () - - - - -  : While Applying the new status In of Shop :" + objMarUser.iShopId + " usename : " + objUser.strUserName + "Exception : " + ex.ToString());
                        }
                    }
                    updateInsuranceData(objMyCustomer.iUserId.Value, objEMSData);
                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("Update Information shop : " + objMyCustomer.iShopId + " User : " + objMyCustomer.iUserId + " UserName " + objMyCustomer.strUserName + " updated Insurance Data");
                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("updateEMSData_New() end ");
                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic(Environment.NewLine);
                }
            }
        }
        catch (Exception ex)
        {
            Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
        }
    }
</script>

