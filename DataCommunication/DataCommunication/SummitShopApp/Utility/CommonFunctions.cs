using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using StringProcessing;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.IO;
using SummitShopApp.BL;
using System.Data.OleDb;
using System.Globalization;
using System.Net;
using System.Collections.Specialized;
using System.Reflection;

namespace SummitShopApp.Utility
{
    public class CommonFunctions
    {

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

        /// <summary>
        /// Delete Images from Email 
        /// </summary>
        /// <param name="lstFiles">List Image of file</param>
        /// <returns>true if all deleted</returns>
        public static Boolean deleteEmailImages(List<String> lstFiles)
        {
            if (lstFiles != null && lstFiles.Count > 0)
            {
                try
                {
                    foreach (string file in lstFiles)
                    {
                        if (File.Exists(file))
                        {
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            GC.Collect();
                            File.Delete(file);
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
                }
            }
            return false;
        }

        /// <summary>
        /// Check for valid User Name
        /// </summary>
        /// <param name="strUserName">User Name</param>
        /// <returns>true if valid</returns>
        public static Boolean isValidUserName(String strUserName)
        {
            if (!String.IsNullOrEmpty(strUserName))
            {
                String strPattern = "[a-zA-Z0-9_]{6,16}";
                Regex _rgx = new Regex(strPattern, RegexOptions.IgnoreCase);
                Match _match = _rgx.Match(strUserName);
                return _match.Success;
            }
            return false;
        }

        /// <summary>
        /// Check for valid zip code in US,CANADA
        /// </summary>
        /// <param name="strZipcode">ZipCode</param>
        /// <returns>true if is valid.</returns>
        public static Boolean isValidZipCode(String strZipcode)
        {
            if (!String.IsNullOrEmpty(strZipcode))
            {
                String strPattern = @"(^\d{5}(-\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\d{1}[A-Z]{1} *\d{1}[A-Z]{1}\d{1}$)";
                Regex _rgx = new Regex(strPattern, RegexOptions.IgnoreCase);
                Match _match = _rgx.Match(strZipcode);
                return _match.Success;
            }
            return false;
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
        /// Extract information from EMS files
        /// </summary>
        /// <param name="strFromPath">EMS file path</param>
        /// <returns>list fo EMS Data</returns>
        public static List<EMSData> ExtractDataFromEstimateFiles(String strFromPath)
        {
            string strConn;
            // strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+strFromPath+";Extended Properties=dBase IV;";
            strConn = "Provider=VFPOLEDB;Data Source=" + strFromPath + ";Mode=ReadWrite|Share Exclusive;Collating Sequence=machine;";
            DataSet EMSDataSet = new DataSet();
            DirectoryInfo dir = new DirectoryInfo(strFromPath);
            FileInfo[] files = dir.GetFiles();
            List<EMSData> lstEMSData = new List<EMSData>();
            EMSData objEMSData = null;
            foreach (FileInfo file in files)
            {
                if (file.Name.ToLower().Contains("_ad1.dbf"))
                {
                    //Select Customer/Owner Info from table
                    OleDbDataAdapter EMSTableAdapter = new OleDbDataAdapter("SELECT * FROM " + file.Name, strConn);
                    Boolean bSuccess = false;
                    try
                    {
                        EMSTableAdapter.Fill(EMSDataSet, file.Name);
                        bSuccess = true;
                    }
                    catch (Exception ex)
                    {
                        LoggingForIncomingResponse("Exception occured :" + ex.Message);
                        ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
                    }
                    if (bSuccess)
                    {

                        String vehicleTableName = null;
                        String strVehicleTableName = null;
                        String strPattern = null;
                        if (file.Name.ToLower().Contains("_ad1.dbf"))
                        {
                            strPattern = StringProcessing.StringFunctions.SubstringEnd(file.Name, 0, file.Name.ToLower().IndexOf("_ad1.dbf")) + "_veh\\.DBF";
                            strPattern += "," + StringProcessing.StringFunctions.SubstringEnd(file.Name, 0, file.Name.ToLower().IndexOf("_ad1.dbf")) + "_env\\.DBF";
                            strPattern += "," + StringProcessing.StringFunctions.SubstringEnd(file.Name, 0, file.Name.ToLower().IndexOf("_ad1.dbf")) + "_ttl\\.DBF";
                            strPattern += "," + StringProcessing.StringFunctions.SubstringEnd(file.Name, 0, file.Name.ToLower().IndexOf("_ad1.dbf")) + "_ad2\\.DBF";
                        }

                        String[] strAryPattern = strPattern.Split(',');
                        foreach (String strNewPattern in strAryPattern)
                        {
                            Boolean bMatch = false;
                            Regex rgx = new Regex(strNewPattern, RegexOptions.IgnoreCase);
                            foreach (FileInfo _file in files)
                            {
                                if (rgx.Match(_file.Name).Success)
                                {
                                    bMatch = true;
                                    vehicleTableName = _file.Name;
                                    if (strVehicleTableName == null)
                                        strVehicleTableName = _file.Name;
                                    else
                                        strVehicleTableName += "," + _file.Name;
                                    break;
                                }
                            }
                            if (!bMatch)
                            {
                                String _strNewPattern = String.Empty;
                                if (strNewPattern.Contains("_env"))
                                {
                                    _strNewPattern = StringProcessing.StringFunctions.SubstringEnd(file.Name, 0, file.Name.ToLower().IndexOf("_ad1.dbf") - 1) + "_env\\.DBF";
                                }
                                if (strNewPattern.Contains("_ttl"))
                                {
                                    _strNewPattern = StringProcessing.StringFunctions.SubstringEnd(file.Name, 0, file.Name.ToLower().IndexOf("_ad1.dbf") - 1) + "_ttl\\.DBF";
                                }
                                if (strNewPattern.Contains("_veh"))
                                {
                                    _strNewPattern = StringProcessing.StringFunctions.SubstringEnd(file.Name, 0, file.Name.ToLower().IndexOf("_ad1.dbf") - 1) + "._veh\\.DBF";
                                }
                                if (strNewPattern.Contains("_ad2"))
                                {
                                    _strNewPattern = StringProcessing.StringFunctions.SubstringEnd(file.Name, 0, file.Name.ToLower().IndexOf("_ad1.dbf") - 1) + "._ad2\\.DBF";
                                }



                                Regex _rgx = new Regex(_strNewPattern, RegexOptions.IgnoreCase);
                                foreach (FileInfo _file in files)
                                {
                                    if (_rgx.Match(_file.Name).Success)
                                    {
                                        vehicleTableName = _file.Name;
                                        if (strVehicleTableName == null)
                                            strVehicleTableName = _file.Name;
                                        else
                                            strVehicleTableName += "," + _file.Name;
                                        break;
                                    }
                                }
                            }
                            if (vehicleTableName != null)
                            {
                                OleDbDataAdapter _EMSTableAdapter = new OleDbDataAdapter("SELECT * FROM " + vehicleTableName, strConn);
                                try
                                {
                                    _EMSTableAdapter.Fill(EMSDataSet, vehicleTableName);
                                }
                                catch (Exception ex)
                                {
                                    ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
                                }
                            }
                        }
                        try
                        {
                            objEMSData = BuildFromTables(file.Name, strVehicleTableName, EMSDataSet);
                        }
                        catch (Exception ex)
                        {
                            ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
                        }

                        if (objEMSData != null)
                            lstEMSData.Add(objEMSData);
                    }
                }
            }
            try
            {
                Directory.Delete(strFromPath, true);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
            }
            if (lstEMSData != null && lstEMSData.Count > 0)
            {
                try
                {
                    EMSDataComparer EMSDataCmp = new EMSDataComparer();
                    EMSDataCmp.ComparisonType = "UserNameASC";
                    lstEMSData.Sort(EMSDataCmp);
                }
                catch (Exception ex)
                {
                    ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
                }
            }
            return lstEMSData;
        }

        /// <summary>
        /// obsolete
        /// </summary>
        public static void EstimatesFile()
        {
            String targetPath = "H:\\Summit\\March 04\\ShopApplication\\SummitShopApp\\Images\\UploadedFile\\EMS\\";
            String sourcePath = "H:\\Summit\\Docs\\EMS Example\\ADP Example\\ADP Example1\\";
            System.IO.Directory.CreateDirectory(targetPath);

            DirectoryInfo di = new DirectoryInfo(sourcePath);

            DataGrid dg = new DataGrid();

            dg.DataSource = di.GetFiles();

            dg.DataBind();


            foreach (DataGridItem item in dg.Items)
            {

                String fn0 = item.Cells[0].Text;

                String ext = item.Cells[6].Text;

                String fn = fn0;

                fn = fn.Replace(ext, "");

                ext = ext.Replace(".", "");

                string targetFile = fn + "_" + ext + ".DBF";
                int extractFlag = 0;
                if (File.Exists(targetPath + targetFile))
                {

                    DateTime tfDate = File.GetLastAccessTime(targetPath + targetFile);
                    DateTime sfDate = File.GetLastAccessTime(sourcePath + fn0);
                    int compared = tfDate.CompareTo(sfDate);

                    if (compared < 0)
                    {
                        File.Delete(targetPath + targetFile);

                        File.Copy(sourcePath + fn0, targetPath + targetFile);

                        extractFlag = 1;
                    }
                }
                else
                {
                    File.Copy(sourcePath + fn0, targetPath + targetFile);
                    extractFlag = 1;
                }

                if (extractFlag == 1)
                {
                    //ExtractDataFromEstimateFiles(targetPath, fn, ext);
                }
            }

        }

        /// <summary>
        /// Get Data from DataTables
        /// </summary>
        /// <param name="strOwnerTableName" >Owner Table Name </param>
        /// <param name="strOwnerVehicleTableName">Vehicle Table Name</param>
        /// <param name="EMSDataSet">EMS DataSet</param>
        /// <returns>Return EMS data</returns>
        public static EMSData BuildFromTables(String strOwnerTableName, String strOwnerVehicleTableName, DataSet EMSDataSet)
        {
            if (EMSDataSet != null && EMSDataSet.Tables.Count > 0)
            {
                LogForSavingDates("--------------------------- Loading Data starts-------------------------------------");
                EMSData objEMSData = new EMSData();
                if (!String.IsNullOrEmpty(strOwnerTableName))
                {
                    if (EMSDataSet.Tables[strOwnerTableName] != null && EMSDataSet.Tables[strOwnerTableName].Rows.Count > 0)
                    {
                        LogForSavingDates("=== .AD1 Files Data ==== ");
                        foreach (DataRow dr in EMSDataSet.Tables[strOwnerTableName].Rows)
                        {
                            String strFileName = StringFunctions.SubstringEnd(strOwnerTableName, 0, strOwnerTableName.LastIndexOf('.'));
                            objEMSData.strFileName = StringFunctions.SubstringEnd(strFileName, 0, strFileName.LastIndexOf('_')) + '.' + StringFunctions.SubstringEnd(strFileName, strFileName.LastIndexOf('_') + 1, strFileName.Length);
                            objEMSData.strOwnerLastName = dr.IsNull(100) ? String.Empty : dr[100].ToString().Trim();
                            objEMSData.strOwnerFirstName = dr.IsNull(101) ? String.Empty : dr[101].ToString().Trim();
                            objEMSData.strOwnerSocialTitle = dr.IsNull(102) ? String.Empty : dr[102].ToString().Trim();
                            objEMSData.strOwnerCompanyName = dr.IsNull(103) ? String.Empty : dr[103].ToString().Trim();
                            objEMSData.strOwnerAddress1 = dr.IsNull(104) ? String.Empty : dr[104].ToString().Trim();
                            objEMSData.strOwnerAddress2 = dr.IsNull(105) ? String.Empty : dr[105].ToString().Trim();
                            objEMSData.strOwnerCity = dr.IsNull(106) ? String.Empty : dr[106].ToString().Trim();
                            objEMSData.strOwnerState = dr.IsNull(107) ? String.Empty : dr[107].ToString().Trim();
                            objEMSData.strOwnerZipCode = dr.IsNull(108) ? String.Empty : dr[108].ToString().Trim();
                            objEMSData.strOwnerCountryCode = dr.IsNull(109) ? String.Empty : dr[109].ToString().Trim();
                            objEMSData.strOwnerPhone1 = dr.IsNull(110) ? String.Empty : dr[110].ToString().Trim();
                            objEMSData.strOwnerPhone1Ext = dr.IsNull(111) ? String.Empty : dr[111].ToString().Trim();
                            objEMSData.strOwnerPhone2 = dr.IsNull(112) ? String.Empty : dr[112].ToString().Trim();
                            objEMSData.strOwnerPhone2Ext = dr.IsNull(113) ? String.Empty : dr[113].ToString().Trim();
                            objEMSData.strOwnerFax = dr.IsNull(114) ? String.Empty : dr[114].ToString().Trim();
                            objEMSData.strOwnerFaxExt = dr.IsNull(115) ? String.Empty : dr[115].ToString().Trim();
                            objEMSData.strOwnerEmail = dr.IsNull(116) ? String.Empty : dr[116].ToString().Trim();
                            objEMSData.strDateOfLoss = dr.IsNull(74) ? String.Empty : dr[74].ToString().Trim();
                            objEMSData.strDeductible = dr.IsNull(22) ? String.Empty : dr[22].ToString().Trim();
                            objEMSData.strInsuranceCompanyName = dr.IsNull(1) ? String.Empty : dr[1].ToString().Trim();
                            objEMSData.strInsuranceCompanyAddress = dr.IsNull(2) ? String.Empty : dr[2].ToString().Trim();
                            objEMSData.strInsuranceCompanyCity = dr.IsNull(4) ? String.Empty : dr[4].ToString().Trim();
                            objEMSData.strInsuranceCompanyState = dr.IsNull(5) ? String.Empty : dr[5].ToString().Trim();
                            objEMSData.strInsuranceCompanyZipCode = dr.IsNull(6) ? String.Empty : dr[6].ToString().Trim();
                            objEMSData.strInsuranceCompanyPhone = dr.IsNull(8) ? String.Empty : dr[8].ToString().Trim();
                            objEMSData.strInsuranceCompanyFax = dr.IsNull(12) ? String.Empty : dr[12].ToString().Trim();
                            objEMSData.strInsuranceCompanyEmail = dr.IsNull(19) ? String.Empty : dr[19].ToString().Trim();

                            objEMSData.strClaimNumber = dr.IsNull(27) ? String.Empty : dr[27].ToString().Trim();
                            objEMSData.strInsuranceAgentName = (dr.IsNull(69) ? String.Empty : dr[69].ToString().Trim()) + " " + (dr.IsNull(68) ? String.Empty : dr[68].ToString().Trim());

                            //new if condition added for testing dates
                            string dtassignment = dr.IsNull(25) ? String.Empty : dr[25].ToString().Trim();//assignment
                            if (!String.IsNullOrEmpty(dtassignment))
                                LogForSavingDates("Assignment Date : " + dtassignment);
                            string dtissued = dr.IsNull(50) ? String.Empty : dr[50].ToString().Trim();//issued
                            if (!String.IsNullOrEmpty(dtissued))
                                LogForSavingDates("Date Issued : " + dtassignment);
                            string dtloss = dr.IsNull(74) ? String.Empty : dr[74].ToString().Trim();//loss of date
                            if (!String.IsNullOrEmpty(dtassignment))
                                LogForSavingDates("Date of Loss : " + dtassignment);


                        }
                    }
                }
                if (!String.IsNullOrEmpty(strOwnerVehicleTableName))
                {
                    LogForSavingDates("");
                    String[] strAryOwnerVehicleTableName = strOwnerVehicleTableName.Split(',');
                    foreach (String strNewOwnerVehicleTableName in strAryOwnerVehicleTableName)
                    {
                        if (EMSDataSet.Tables[strNewOwnerVehicleTableName] != null && EMSDataSet.Tables[strNewOwnerVehicleTableName].Rows.Count > 0)
                        {
                            foreach (DataRow dr in EMSDataSet.Tables[strNewOwnerVehicleTableName].Rows)
                            {
                                if (strNewOwnerVehicleTableName.ToLower().Contains("_env.dbf"))
                                {
                                    LogForSavingDates("");
                                    LogForSavingDates("=== .ENV Files Data ==== ");

                                    LogForSavingDates("User Name : " + objEMSData.strOwnerFirstName + " " + objEMSData.strOwnerLastName);

                                    objEMSData.strRONumbert = dr.IsNull(5) ? String.Empty : dr[5].ToString().Trim();
                                    LogForSavingDates("Repair Order Identifier : " + objEMSData.strRONumbert);

                                    string strFileId = dr.IsNull(4) ? String.Empty : dr[4].ToString().Trim();//Unique File Identifier
                                    if (String.IsNullOrEmpty(strFileId))
                                        strFileId = dr.IsNull(6) ? String.Empty : dr[6].ToString().Trim();//Estimate File Identifier


                                    //new condition added for testing
                                    string dtcreatein = dr.IsNull(14) ? String.Empty : dr[14].ToString().Trim();//Create
                                    LogForSavingDates("Creation Date : " + dtcreatein);
                                    string dttransmit = dr.IsNull(16) ? String.Empty : dr[16].ToString().Trim();//transmit

                                    LogForSavingDates("Transmit Date : " + dttransmit);

                                    objEMSData.strEstimateFileId = strFileId;
                                    LogForSavingDates("");
                                }

                                else if (strNewOwnerVehicleTableName.ToLower().Contains("_ad2.dbf"))
                                {
                                    LogForSavingDates("");
                                    LogForSavingDates("=== .AD2 Files Data ==== ");
                                    objEMSData.strEstimatorName = (dr.IsNull(32) ? String.Empty : dr[32].ToString().Trim()) + " " + (dr.IsNull(31) ? String.Empty : dr[31].ToString().Trim());
                                    //Code added for Delivery Date - START
                                    objEMSData.strDeliveryDate = dr.IsNull(82) ? String.Empty : dr[82].ToString().Trim();
                                    LogForSavingDates("Vehicle Date Delivered  (DATE_OUT) : " + objEMSData.strDeliveryDate);
                                    //Code added for Delivery Date - END
                                    //added 76 => Ro_In_Date to date in :  as per ems standard
                                    objEMSData.strDateIn = dr.IsNull(75) ? String.Empty : dr[75].ToString().Trim();
                                    LogForSavingDates("Vehicle Date In Shop (RO_IN_DATE) : " + objEMSData.strDateIn);
                                    //added 79 => TAR_DATE  OR 81 => RO_CMPDATE to date out :  if 
                                    //The RO_CMP_Date should overwrite the Tar_Date when both the fields are present in the EMS files
                                    objEMSData.strDateOut_Ro_Cmp_Date = dr.IsNull(80) ? String.Empty : dr[80].ToString().Trim();

                                    LogForSavingDates("Vehicle Completion Date (RO_CMPDATE) : " + objEMSData.strDateOut_Ro_Cmp_Date);


                                    objEMSData.strDateOut_Tar_Date = dr.IsNull(78) ? String.Empty : dr[78].ToString().Trim();

                                    LogForSavingDates("Vehicle Target Completion Date (TAR_DATE) : " + objEMSData.strDateOut_Tar_Date);
                                    //new date for testing

                                    var dtinspection = dr.IsNull(53) ? String.Empty : dr[53].ToString().Trim();
                                    LogForSavingDates("Inspection Date (INSP_DATE) : " + dtinspection);
                                    LogForSavingDates("");
                                }
                                else
                                {
                                    if (strNewOwnerVehicleTableName.ToLower().Contains("_ttl.dbf"))
                                    {
                                        objEMSData.strNetTotalAmount = dr.IsNull(0) ? String.Empty : dr[0].ToString().Trim();//Gross Total Amount
                                    }
                                    else
                                    {
                                        String strYear = String.Empty;
                                        if (!dr.IsNull(9))
                                        {
                                            strYear = dr[9].ToString().Trim();
                                            if (strYear.Length == 2)
                                            {
                                                strYear = new GregorianCalendar().ToFourDigitYear(Convert.ToInt16(strYear)).ToString();
                                            }
                                        }
                                        objEMSData.strYear = strYear;

                                        //Importing Vehicle make description if description is not available then import make code
                                        //objEMSData.strMake = dr.IsNull(11) ? String.Empty : dr[11].ToString().Trim();
                                        objEMSData.strMake = (dr.IsNull(11) ? String.Empty : (String.IsNullOrEmpty(dr[11].ToString().Trim()) ? dr.IsNull(10) ? String.Empty : dr[10].ToString().Trim() : dr[11].ToString().Trim()));

                                        //Importing Vehicle model description/name
                                        objEMSData.strModel = dr.IsNull(12) ? String.Empty : dr[12].ToString().Trim();

                                        //Importing Vehicle body style
                                        objEMSData.strStyle = dr.IsNull(14) ? String.Empty : dr[14].ToString().Trim();

                                        //Importing Vehicle exterior color
                                        objEMSData.strColor = dr.IsNull(21) ? String.Empty : dr[21].ToString().Trim();

                                        //Importing OEM paint code or color
                                        objEMSData.strPaintCode = dr.IsNull(24) ? String.Empty : dr[24].ToString().Trim();

                                        //Importing Vehicle Identification Number
                                        objEMSData.strVIN = dr.IsNull(6) ? String.Empty : dr[6].ToString().Trim();

                                        //Importing Vehicle license plate/tag number
                                        objEMSData.strLicense = dr.IsNull(4) ? String.Empty : dr[4].ToString().Trim();

                                        //Importing Vehicle production date (MMYY)
                                        objEMSData.strProductionDate = dr.IsNull(8) ? String.Empty : dr[8].ToString().Trim();


                                    }
                                }
                            }
                        }
                    }
                }
                LogForSavingDates("--------------------------- Loading Data Ends-------------------------------------");
                return objEMSData;
            }
            return null;
        }

        /// <summary>
        /// Save Initial Vehicle Status Setting
        /// </summary>
        /// <param name="ShopID">Shop ID</param>
        public static void SaveInitialVehicalStatus(int ShopID)
        {
            try
            {
                if (ShopID > 0)
                {
                    VehicleStatusBL objVehicalInfo = new VehicleStatusBL();
                    objVehicalInfo.iShopId = ShopID;
                    objVehicalInfo.bSMS = false;
                    objVehicalInfo.bEmail = false;
                    objVehicalInfo.strVehicleStatus = "Scheduled In";
                    objVehicalInfo.Save();

                    //objVehicalInfo = new VehicleStatusBL();
                    //objVehicalInfo.iShopId = ShopID;
                    //objVehicalInfo.bSMS = false;
                    //objVehicalInfo.bEmail = false;
                    //objVehicalInfo.strVehicleStatus = "Scheduled In Parts on Order";
                    //objVehicalInfo.Save();

                    //objVehicalInfo = new VehicleStatusBL();
                    //objVehicalInfo.iShopId = ShopID;
                    //objVehicalInfo.bSMS = true;
                    //objVehicalInfo.bEmail = true;
                    //objVehicalInfo.strVehicleStatus = "Vehicle Here (Waiting for Ins Approval)";
                    //objVehicalInfo.strMessage = "We are awaiting approval to repair ";
                    //objVehicalInfo.Save();

                    //objVehicalInfo = new VehicleStatusBL();
                    //objVehicalInfo.iShopId = ShopID;
                    //objVehicalInfo.bSMS = false;
                    //objVehicalInfo.bEmail = false;
                    //objVehicalInfo.strVehicleStatus = "Vehicle Here (Tow In)";
                    //objVehicalInfo.Save();

                    //objVehicalInfo = new VehicleStatusBL();
                    //objVehicalInfo.iShopId = ShopID;
                    //objVehicalInfo.bSMS = true;
                    //objVehicalInfo.bEmail = true;
                    //objVehicalInfo.strVehicleStatus = "Disassembly";
                    //objVehicalInfo.strMessage = "We are inspecting your vehicle for potential additional damage";
                    //objVehicalInfo.Save();

                    //objVehicalInfo = new VehicleStatusBL();
                    //objVehicalInfo.iShopId = ShopID;
                    //objVehicalInfo.bSMS = true;
                    //objVehicalInfo.bEmail = true;
                    //objVehicalInfo.strVehicleStatus = "Vehicle Disassembled – Waiting for Approval ";
                    //objVehicalInfo.strMessage = "We are awaiting approval to repair";
                    //objVehicalInfo.Save();

                    //objVehicalInfo = new VehicleStatusBL();
                    //objVehicalInfo.iShopId = ShopID;
                    //objVehicalInfo.bSMS = false;
                    //objVehicalInfo.bEmail = false;
                    //objVehicalInfo.strVehicleStatus = "Ready For Dispatch – No Parts";
                    //objVehicalInfo.Save();

                    //objVehicalInfo = new VehicleStatusBL();
                    //objVehicalInfo.iShopId = ShopID;
                    //objVehicalInfo.bSMS = false;
                    //objVehicalInfo.bEmail = false;
                    //objVehicalInfo.strVehicleStatus = "Ready for Dispatch – All Parts Here";
                    //objVehicalInfo.Save();

                    //objVehicalInfo = new VehicleStatusBL();
                    //objVehicalInfo.iShopId = ShopID;
                    //objVehicalInfo.bSMS = false;
                    //objVehicalInfo.bEmail = false;
                    //objVehicalInfo.strVehicleStatus = "Frame";
                    //objVehicalInfo.Save();

                    //objVehicalInfo = new VehicleStatusBL();
                    //objVehicalInfo.iShopId = ShopID;
                    //objVehicalInfo.bSMS = false;
                    //objVehicalInfo.bEmail = false;
                    //objVehicalInfo.strVehicleStatus = "Sublet";
                    //objVehicalInfo.Save();

                    //objVehicalInfo = new VehicleStatusBL();
                    //objVehicalInfo.iShopId = ShopID;
                    //objVehicalInfo.bSMS = true;
                    //objVehicalInfo.bEmail = true;
                    //objVehicalInfo.strVehicleStatus = "Body Repair";
                    //objVehicalInfo.strMessage = "Your vehicle is now in the Body Repair process";
                    //objVehicalInfo.Save();

                    //objVehicalInfo = new VehicleStatusBL();
                    //objVehicalInfo.iShopId = ShopID;
                    //objVehicalInfo.bSMS = true;
                    //objVehicalInfo.bEmail = true;
                    //objVehicalInfo.strVehicleStatus = "Prep";
                    //objVehicalInfo.strMessage = "We are preparing your vehicle for painting";
                    //objVehicalInfo.Save();


                    //objVehicalInfo = new VehicleStatusBL();
                    //objVehicalInfo.iShopId = ShopID;
                    //objVehicalInfo.bSMS = true;
                    //objVehicalInfo.bEmail = true;
                    //objVehicalInfo.strVehicleStatus = "Refinish";
                    //objVehicalInfo.strMessage = "Your vehicle is being painted";
                    //objVehicalInfo.Save();


                    objVehicalInfo = new VehicleStatusBL();
                    objVehicalInfo.iShopId = ShopID;
                    objVehicalInfo.bSMS = true;
                    objVehicalInfo.bEmail = true;
                    objVehicalInfo.strVehicleStatus = "Reassembly";
                    objVehicalInfo.strMessage = "We are re-assembling your vehicle";
                    objVehicalInfo.Save();

                    //objVehicalInfo = new VehicleStatusBL();
                    //objVehicalInfo.iShopId = ShopID;
                    //objVehicalInfo.bSMS = true;
                    //objVehicalInfo.bEmail = true;
                    //objVehicalInfo.strVehicleStatus = "Mechanical Department";
                    //objVehicalInfo.strMessage = "We are performing mechanical repairs on your vehicle";
                    //objVehicalInfo.Save();

                    objVehicalInfo = new VehicleStatusBL();
                    objVehicalInfo.iShopId = ShopID;
                    objVehicalInfo.bSMS = true;
                    objVehicalInfo.bEmail = true;
                    objVehicalInfo.strVehicleStatus = "Detail";
                    objVehicalInfo.strMessage = "We are detailing your vehicle";
                    objVehicalInfo.Save();

                    objVehicalInfo = new VehicleStatusBL();
                    objVehicalInfo.iShopId = ShopID;
                    objVehicalInfo.bSMS = true;
                    objVehicalInfo.bEmail = true;
                    objVehicalInfo.strVehicleStatus = "Quality Control";
                    objVehicalInfo.strMessage = "Your vehicle is being checked to makes sure it meets our quality repair standards";
                    objVehicalInfo.Save();

                    objVehicalInfo = new VehicleStatusBL();
                    objVehicalInfo.iShopId = ShopID;
                    objVehicalInfo.bSMS = true;
                    objVehicalInfo.bEmail = true;
                    objVehicalInfo.strVehicleStatus = "Ready for Delivery";
                    objVehicalInfo.strMessage = "Your vehicle is ready to be picked up";
                    objVehicalInfo.Save();

                    objVehicalInfo = new VehicleStatusBL();
                    objVehicalInfo.iShopId = ShopID;
                    objVehicalInfo.bSMS = false;
                    objVehicalInfo.bEmail = false;
                    objVehicalInfo.strVehicleStatus = "Imported Estimate";
                    objVehicalInfo.Save();

                    objVehicalInfo = new VehicleStatusBL();
                    objVehicalInfo.iShopId = ShopID;
                    objVehicalInfo.bSMS = false;
                    objVehicalInfo.bEmail = false;
                    objVehicalInfo.strVehicleStatus = "Vehicle Has Arrived";
                    objVehicalInfo.Save();

                    objVehicalInfo = new VehicleStatusBL();
                    objVehicalInfo.iShopId = ShopID;
                    objVehicalInfo.bSMS = true;
                    objVehicalInfo.bEmail = true;
                    objVehicalInfo.strVehicleStatus = "Repairs Started";
                    objVehicalInfo.strMessage = "We have started to repair your vehicle";
                    objVehicalInfo.Save();

                    objVehicalInfo = new VehicleStatusBL();
                    objVehicalInfo.iShopId = ShopID;
                    objVehicalInfo.bSMS = true;
                    objVehicalInfo.bEmail = true;
                    objVehicalInfo.strVehicleStatus = "In Process Repairs";
                    objVehicalInfo.strMessage = "Your vehicle's repairs are progressing as planned";
                    objVehicalInfo.Save();

                    objVehicalInfo = new VehicleStatusBL();
                    objVehicalInfo.iShopId = ShopID;
                    objVehicalInfo.bSMS = true;
                    objVehicalInfo.bEmail = true;
                    objVehicalInfo.strVehicleStatus = "Minor Delay Parts Issue";
                    objVehicalInfo.strMessage = "We have encountered a parts delay please call us for more details";
                    objVehicalInfo.Save();

                    objVehicalInfo = new VehicleStatusBL();
                    objVehicalInfo.iShopId = ShopID;
                    objVehicalInfo.bSMS = true;
                    objVehicalInfo.bEmail = true;
                    objVehicalInfo.strVehicleStatus = "Minor Delay - Additional Damage";
                    objVehicalInfo.strMessage = "We have identified additional damage to your vehicle please call us for more details";
                    objVehicalInfo.Save();

                    objVehicalInfo = new VehicleStatusBL();
                    objVehicalInfo.iShopId = ShopID;
                    objVehicalInfo.bSMS = true;
                    objVehicalInfo.bEmail = true;
                    objVehicalInfo.strVehicleStatus = "Insurance Insection Update";
                    objVehicalInfo.strMessage = "We are waiting for the insurance company to inspect your vehicle.";
                    objVehicalInfo.Save();

                    objVehicalInfo = new VehicleStatusBL();
                    objVehicalInfo.iShopId = ShopID;
                    objVehicalInfo.bSMS = true;
                    objVehicalInfo.bEmail = true;
                    objVehicalInfo.strVehicleStatus = "Vehicle in Paint";
                    objVehicalInfo.strMessage = "Your vehicle is being painted";
                    objVehicalInfo.Save();

                    //objVehicalInfo = new VehicleStatusBL();
                    //objVehicalInfo.iShopId = ShopID;
                    //objVehicalInfo.bSMS = false;
                    //objVehicalInfo.bEmail = false;
                    //objVehicalInfo.strVehicleStatus = "Delivered";
                    //objVehicalInfo.Save();
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
            }
        }

        /// <summary>
        /// Upload file to remote server 
        /// </summary>
        /// <param name="url">URL of remote server</param>
        /// <param name="files">Array of files</param>
        /// <param name="nvc">Named Value Collection</param>
        /// <returns></returns>
        public static String UploadFilesToRemoteUrl(string url, string[] files, NameValueCollection nvc)
        {

            long length = 0;
            string boundary = "----------------------------" +
            DateTime.Now.Ticks.ToString("x");


            HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest2.ContentType = "multipart/form-data; boundary=" +
            boundary;
            httpWebRequest2.Method = "POST";
            httpWebRequest2.KeepAlive = true;
            httpWebRequest2.Credentials =
            System.Net.CredentialCache.DefaultCredentials;



            Stream memStream = new System.IO.MemoryStream();

            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" +
            boundary + "\r\n");


            string formdataTemplate = "\r\n--" + boundary +
            "\r\nContent-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}";

            if (nvc.Keys != null)
            {
                foreach (string key in nvc.Keys)
                {
                    string formitem = string.Format(formdataTemplate, key, nvc[key]);
                    byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                    memStream.Write(formitembytes, 0, formitembytes.Length);
                }
            }

            memStream.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n Content-Type: application/octet-stream\r\n\r\n";

            for (int i = 0; i < files.Length; i++)
            {

                //string header = string.Format(headerTemplate, "file" + i, files[i]); 
                string header = string.Format(headerTemplate, "file", files[i]);

                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);

                memStream.Write(headerbytes, 0, headerbytes.Length);


                FileStream fileStream = new FileStream(files[i], FileMode.Open,
                FileAccess.Read);
                byte[] buffer = new byte[1024];

                int bytesRead = 0;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    memStream.Write(buffer, 0, bytesRead);

                }


                memStream.Write(boundarybytes, 0, boundarybytes.Length);


                fileStream.Close();
            }

            httpWebRequest2.ContentLength = memStream.Length;

            Stream requestStream = httpWebRequest2.GetRequestStream();

            memStream.Position = 0;
            byte[] tempBuffer = new byte[memStream.Length];
            memStream.Read(tempBuffer, 0, tempBuffer.Length);
            memStream.Close();
            requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            requestStream.Close();


            WebResponse webResponse2 = httpWebRequest2.GetResponse();

            Stream stream2 = webResponse2.GetResponseStream();
            StreamReader reader2 = new StreamReader(stream2);

            webResponse2.Close();
            httpWebRequest2 = null;
            webResponse2 = null;
            return reader2.ReadToEnd();
        }


        /// <summary>
        /// Saves all list zip codes to specified ilogin
        /// </summary>
        /// <param name="lstZodeCode"></param>
        /// <param name="iLoginId"></param>
        public static void AddZipCodes(List<String> lstZodeCode, Int32 iLoginId)
        {
            if (lstZodeCode != null && lstZodeCode.Count > 0 && iLoginId > 0)
            {
                try
                {
                    List<ZipCodeBL> _lstZipCode = ZipCodeBL.getDataByLoginId(iLoginId);
                    foreach (String strZipCode in lstZodeCode)
                    {
                        try
                        {
                            if (isValidZipCode(strZipCode))
                            {
                                ZipCodeBL _objZipCode = null;
                                if (_lstZipCode != null && !_lstZipCode.Exists(objZipCode => objZipCode.strZipCode.ToLower() == strZipCode.ToLower()))
                                {
                                    _objZipCode = new ZipCodeBL() { strZipCode = strZipCode, iLoginId = iLoginId };
                                }
                                if (_lstZipCode == null || _lstZipCode.Count == 0)
                                {
                                    _objZipCode = new ZipCodeBL() { strZipCode = strZipCode, iLoginId = iLoginId };
                                }
                                if (_objZipCode != null)
                                {
                                    _objZipCode.Save();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
                }
            }

        }

        /// <summary>
        /// compare the user name according to yelp user name.The yelp return user name as first name followed by first letter of last name and . in the end symbol.
        /// </summary>
        /// <param name="strUserName"></param>
        /// <returns></returns>
        public static String CompareNameWithYelp(String strUserName)
        {
            String _strUserName = String.Empty;
            if (!String.IsNullOrEmpty(strUserName))
            {
                //check for comma ,the EMS import saves the name in last name,first name 
                if (strUserName.Contains(','))
                {
                    String[] strName = strUserName.Split(',');
                    if (strName.Length == 2)
                    {
                        _strUserName = strName[1].Trim() + " " + strName[0].Trim().Substring(0, 1) + ".";
                    }
                }
                else
                {
                    // default , we are considering name in first name last name 
                    String[] strName = strUserName.Split(' ');
                    {
                        if (strName.Length == 2)
                        {
                            _strUserName = strName[0].Trim() + " " + strName[1].Trim().Substring(0, 1) + ".";
                        }
                    }
                }
            }
            return _strUserName;
        }

        public static void LoggingForOld_AILogic(String strMessage)
        {

            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strPath = "D:\\Summit\\DataCommunication\\SummitShopApp\\LogsNewAILogic_FromApril6\\Logs";
                    strPath += @"\OldAILogs";
                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    string strFile = string.Format(@"{0}\{1}_{2}.log", strPath, "MessageLog", DateTime.Today.Date.ToString("dd-MM-yyyy"));

                    foreach (string fileName in Directory.GetFiles(strPath))
                    {
                        string[] splitFileName = Path.GetFileNameWithoutExtension(fileName).Split('_');
                        string[] splitDate = splitFileName[1].Split('-');
                        DateTime logStartDate = new DateTime(Convert.ToInt32(splitDate[2]), Convert.ToInt32(splitDate[1]), Convert.ToInt32(splitDate[0]));
                        if (DateTime.Today.AddDays(-3) > logStartDate)
                            File.Delete(fileName);
                    }

                    if (!File.Exists(strFile))
                    {
                        using (FileStream file = new FileStream(strFile, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            StreamWriter streamWriter = new StreamWriter(file);
                            streamWriter.WriteLine(DateTime.Now + " - " + strMessage.ToString() + "\n");
                            streamWriter.Close();
                        }
                    }
                    else
                    {
                        using (FileStream file = new FileStream(strFile, FileMode.Append, FileAccess.Write))
                        {
                            StreamWriter streamWriter = new StreamWriter(file);
                            streamWriter.WriteLine(DateTime.Now + " - " + strMessage.ToString() + "\n");
                            streamWriter.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
            }

        }

        //RevisedFrom_April6
        public static void LoggingForNew_AILogic(String strMessage)
        {

            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strPath = "D:\\Summit\\DataCommunication\\SummitShopApp\\LogsNewAILogic_FromApril6\\Logs";
                    strPath += @"\Logs";
                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    string strFile = string.Format(@"{0}\{1}_{2}.log", strPath, "MessageLog", DateTime.Today.Date.ToString("dd-MM-yyyy"));

                    foreach (string fileName in Directory.GetFiles(strPath))
                    {
                        string[] splitFileName = Path.GetFileNameWithoutExtension(fileName).Split('_');
                        string[] splitDate = splitFileName[1].Split('-');
                        DateTime logStartDate = new DateTime(Convert.ToInt32(splitDate[2]), Convert.ToInt32(splitDate[1]), Convert.ToInt32(splitDate[0]));
                        if (DateTime.Today.AddDays(-10) > logStartDate)
                            File.Delete(fileName);
                    }

                    if (!File.Exists(strFile))
                    {
                        using (FileStream file = new FileStream(strFile, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            StreamWriter streamWriter = new StreamWriter(file);
                            streamWriter.WriteLine(DateTime.Now + " - " + strMessage.ToString() + "\n");
                            streamWriter.Close();
                        }
                    }
                    else
                    {
                        using (FileStream file = new FileStream(strFile, FileMode.Append, FileAccess.Write))
                        {
                            StreamWriter streamWriter = new StreamWriter(file);
                            streamWriter.WriteLine(DateTime.Now + " - " + strMessage.ToString() + "\n");
                            streamWriter.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
            }

        }
        // saving all logs for Incoming mesages in file "c:\\IncomingMsg.txt"
        public static void LoggingForIncomingResponse(String strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    
                    string strPath = "d:\\Summit\\DataCommunication\\SummitShopApp\\LogsNewAILogic_FromApril6\\Logs";
                    strPath += @"\Logs";
                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    string strFile = string.Format(@"{0}\{1}_{2}.log", strPath, "MessageLog", DateTime.Today.Date.ToString("dd-MM-yyyy"));

                    foreach (string fileName in Directory.GetFiles(strPath))
                    {
                        string[] splitFileName = Path.GetFileNameWithoutExtension(fileName).Split('_');
                        string[] splitDate = splitFileName[1].Split('-');
                        DateTime logStartDate = new DateTime(Convert.ToInt32(splitDate[2]), Convert.ToInt32(splitDate[1]), Convert.ToInt32(splitDate[0]));
                        if (DateTime.Today.AddDays(-7) > logStartDate)
                            File.Delete(fileName);
                    }

                    if (!File.Exists(strFile))
                    {
                        using (FileStream file = new FileStream(strFile, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            StreamWriter streamWriter = new StreamWriter(file);
                            streamWriter.WriteLine(DateTime.Now + " - " + strMessage.ToString() + "\n");
                            streamWriter.Close();
                        }
                    }
                    else
                    {
                        using (FileStream file = new FileStream(strFile, FileMode.Append, FileAccess.Write))
                        {
                            StreamWriter streamWriter = new StreamWriter(file);
                            streamWriter.WriteLine(DateTime.Now + " - " + strMessage.ToString() + "\n");
                            streamWriter.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
            }

        }

        // saving all logs for Incoming mesages in file "c:\\IncomingMsg.txt"
        public static void LogForSavingDates(String message)
        {
            try
            {
                System.IO.File.AppendAllText(Constants.FILEPATH_STRING_DATE, Environment.NewLine);
                System.IO.File.AppendAllText(Constants.FILEPATH_STRING_DATE, String.Format("{0}", message));
            }
            catch (Exception)
            {
            }
        }

        //saving logs for Generic Import API in file "c:\\ImportStatus.txt"
        public static void LoggingForImportStatus(String message)
        {
            try
            {
                System.IO.File.AppendAllText(Constants.IMPORTSTATUS_FILEPATH, Environment.NewLine);
                System.IO.File.AppendAllText(Constants.IMPORTSTATUS_FILEPATH, message);
            }
            catch (Exception)
            {
            }
        }
        public static void LoggingForTest(String message)
        {
            try
            {

                System.IO.File.AppendAllText(Constants.April6_AUTOIMPORTERLOG_FILEPATH, Environment.NewLine);
                System.IO.File.AppendAllText(Constants.April6_AUTOIMPORTERLOG_FILEPATH, message);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 07-18-2016 Added to trackthe vehicle statuses
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="objCustomer"></param>
        public static void SaveUserAuditTrail(int vehicle_status_id, int iUserId, int iVehicleId)
        {
            try
            {
              
                UserVehicleStatusBL objUsrVehicleStatus = UserVehicleStatusBL.getDataByVehicleId(iVehicleId);
                VehicleStatusBL objVehiCleStatus = new VehicleStatusBL();

                if (objUsrVehicleStatus != null && objUsrVehicleStatus.iVehicleStatusId.HasValue)
                {
                    if (vehicle_status_id == -1)
                    {
                        MyCustomerBL objMycustomer = MyCustomerBL.getDataByUserId(iUserId);
                        if (objMycustomer != null)
                            objVehiCleStatus = VehicleStatusBL.getDataByShopIdAndStatus(objMycustomer.iShopId, Constants.UNSOLD_ESTIMATE);
                    }
                    else
                        objVehiCleStatus = VehicleStatusBL.getDataById(objUsrVehicleStatus.iVehicleStatusId.Value);
                }
                User_Audit_TrailBL objUserAudit = User_Audit_TrailBL.getDataByUserIDVehicleIdandStatusID(iUserId,iVehicleId,vehicle_status_id);
                if (objUserAudit == null)
                    objUserAudit = new User_Audit_TrailBL();
                objUserAudit.user_id = iUserId;
                objUserAudit.vehicle_status_id = vehicle_status_id;
                objUserAudit.last_updated = DateTime.Now;
                objUserAudit.vehicle_id = iVehicleId;

                if (objVehiCleStatus != null && objVehiCleStatus.strVehicleStatus.ToLower().Equals(Constants.UNSOLD_ESTIMATE.ToLower()))
                {
                    objUserAudit.isLastUnsoldStatus = true;
                    SummitShopApp.Utility.CommonFunctions.LoggingForNew_AILogic("User Audit Trail set last Unsold estimate to true for userid : "+iUserId +" and vehicle Id :" +iVehicleId);
                }

                objUserAudit.Save();
            }
            catch (Exception ex)
            {

            }
        }
        public static List<EMSData> ExtractDataFromExcellFile(String strFromPath)
        {

            SummitShopApp.Utility.EMSData EMSData = new SummitShopApp.Utility.EMSData();

            #region NewExcellFile
            List<EMSData> lstEMSData = new List<EMSData>();
            DirectoryInfo dir = new DirectoryInfo(strFromPath);
            FileInfo[] files = dir.GetFiles();

            if (files != null && files.Length > 0)
            {
                //  System.Collections.Generic.List<SummitShopApp.BL.MarketingCenterBL> lstMarketingUser = SummitShopApp.BL.MarketingCenterBL.getMarketinCentersList(Convert.ToInt32(strShopId));
                SummitShopApp.BL.UserBL _lstMarketingUser = new SummitShopApp.BL.UserBL();
                foreach (FileInfo file in files)
                {
                    //My Code
                    //  System.Collections.Generic.List<SummitShopApp.Utility.UserInfo> lstCustomerInfo = new System.Collections.Generic.List<SummitShopApp.Utility.UserInfo>();

                    System.Collections.Generic.List<SummitShopApp.Utility.UserInfo> lstCustomerInfo = new System.Collections.Generic.List<SummitShopApp.Utility.UserInfo>();
                    Int32 iAddedCustomerCount = 0;
                    Boolean isDuplicate = false;
                    try
                    {
                        //StreamReader pt = File.OpenText(file.FullName);
                        StreamReader pt = new StreamReader(file.FullName, System.Text.Encoding.GetEncoding(1252),true);
                        int Cnt = 0;

                        //pt.ReadLine();  --- Removed this to skip headers from csv file

                        //Read file untile last record

                        while (!pt.EndOfStream)
                        {
                            try
                            {
                                String line = pt.ReadLine();
                                Cnt++;
                                string[] StrArr = Split(line, "|", "\"", true);
                                EMSData = new SummitShopApp.Utility.EMSData();

                                if (StrArr[0] != null && StrArr[0].ToString().ToLower().Trim() == "estimate file identifier") // added this code to skip header line
                                    continue;

                                EMSData.strEstimateFileId = StrArr[0] != null ? StrArr[0].ToString().Replace("\"", string.Empty) : "";//
                                EMSData.strOwnerFirstName = StrArr[1] != null ? StrArr[1].ToString().Replace("\"", string.Empty) : "";
                                //EMSData.strOwnerLastName = StrArr[2] != null ? StrArr[2].ToString().Replace("\"", string.Empty) : "";

                                EMSData.strOwnerAddress1 = StrArr[2] != null ? StrArr[2].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strOwnerCity = StrArr[3] != null ? StrArr[3].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strOwnerZipCode = StrArr[4] != null ? StrArr[4].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strOwnerPhone1 = StrArr[17] != null ? StrArr[17].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strOwnerEmail = StrArr[6] != null ? StrArr[6].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strMake = StrArr[7] != null ? StrArr[7].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strModel = StrArr[8] != null ? StrArr[8].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strYear = StrArr[9] != null ? StrArr[9].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strVIN = StrArr[10] != null ? StrArr[10].ToString().Replace("\"", string.Empty) : "";

                                EMSData.strProductionDate = StrArr[11] != null ? StrArr[11].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strDateIn = StrArr[12] != null ? StrArr[12].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strDateOut_Tar_Date = StrArr[13] != null ? StrArr[13].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strDeliveryDate = StrArr[13] != null ? StrArr[13].ToString().Replace("\"", string.Empty) : "";

                                EMSData.status = StrArr[14] != null ? StrArr[14].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strNetTotalAmount = StrArr[15] != null ? StrArr[15].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strLicense = StrArr[16] != null ? StrArr[16].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strOwnerPhone2 = StrArr[5] != null ? StrArr[5].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strOwnerAddress2 = StrArr[18] != null ? StrArr[18].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strOwnerState = StrArr[20] != null ? StrArr[20].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strOwnerCountryCode = StrArr[21] != null ? StrArr[21].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strOwnerFax = StrArr[22] != null ? StrArr[22].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strStyle = StrArr[23] != null ? StrArr[23].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strColor = StrArr[24] != null ? StrArr[24].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strPaintCode = StrArr[25] != null ? StrArr[25].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strInsuranceCompanyName = StrArr[26] != null ? StrArr[26].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strInsuranceCompanyAddress = StrArr[27] != null ? StrArr[27].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strInsuranceCompanyCity = StrArr[28] != null ? StrArr[28].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strInsuranceCompanyState = StrArr[29] != null ? StrArr[29].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strInsuranceCompanyZipCode = StrArr[30] != null ? StrArr[30].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strInsuranceCompanyPhone = StrArr[31] != null ? StrArr[31].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strInsuranceCompanyEmail = StrArr[32] != null ? StrArr[32].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strInsuranceCompanyFax = StrArr[33] != null ? StrArr[33].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strDeductible = StrArr[34] != null ? StrArr[34].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strDateOfLoss = StrArr[35] != null ? StrArr[35].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strClaimNumber = StrArr[36] != null ? StrArr[36].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strInsuranceAgentName = StrArr[37] != null ? StrArr[37].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strEstimatorName = StrArr[38] != null ? StrArr[38].ToString().Replace("\"", string.Empty) : "";
                                EMSData.strRONumbert = StrArr[40] != null ? StrArr[40].ToString().Replace("\"", string.Empty) : "";

                                //custInfo.strUnit = StrArr[39] != null ? StrArr[39].ToString().Replace("\"", string.Empty) : "";
                                //custInfo.strInvoiceNumber = StrArr[40] != null ? StrArr[40].ToString().Replace("\"", string.Empty) : "";

                                //custInfo.strCreationDate = !String.IsNullOrEmpty(StrArr[11]) ? Convert.ToDateTime(StrArr[11].ToString().Replace("\"", string.Empty)) : (Nullable<DateTime>)null;

                                //custInfo.Contact_Mehtod = StrArr[0] != null ? StrArr[0].ToString().Replace("\"", string.Empty) : "";
                                //custInfo.Title = StrArr[0] != null ? StrArr[0].ToString().Replace("\"", string.Empty) : "";
                                lstEMSData.Add(EMSData);
                            }
                            catch (Exception Ex)
                            {
                            }
                            ++iAddedCustomerCount;
                        }
                        return lstEMSData;
                    }
                    catch (Exception ex)
                    { }
                }
            }
            return lstEMSData;
            #endregion
        }

    }
}
