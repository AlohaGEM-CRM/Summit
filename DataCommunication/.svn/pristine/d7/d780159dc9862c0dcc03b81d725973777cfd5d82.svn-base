using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;
using System.Data;

namespace SummitShopApp.BL
{
    public class LoginBL : BaseEditableItem
    {
        #region "Constructor"

        public LoginBL()
        {

        }

        public LoginBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        String m_strUserName;
        String m_strPassword;
        String m_strFirstName;
        String m_strLastName;
        String m_strEmail;
        String m_strPhone;
        String m_strCompany;
        String m_strSMTPServerName;
        String m_strSMTPServerUserName;
        String m_strSMTPServerPassword;
        bool m_boolUseProvidedSMTPServer;
        Nullable<Int32> m_iCompanySize;
        Nullable<Int32> m_iCountryEntityID;
        Nullable<Int32> m_iShopID;
        Nullable<Int32> m_iRoleID;
        Nullable<Int32> m_iAvailableSMS;
        Nullable<Int32> m_iSentSMS;
        Nullable<DateTime> m_dtSMSActivationDate;
        Nullable<Int32> m_iSMTPPort;
        bool m_boolEnableSSL;
        String m_strSMTPServerEmail;
        #endregion "Members"

        #region "Accessors"

        public String strUserName
        {
            get { return this.m_strUserName; }
            set { this.m_strUserName = value; }
        }

        public String strPassword
        {
            get { return this.m_strPassword; }
            set { this.m_strPassword = value; }
        }

        public String strFirstName
        {
            get { return this.m_strFirstName; }
            set { this.m_strFirstName = value; }
        }

        public String strLastName
        {
            get { return this.m_strLastName; }
            set { this.m_strLastName = value; }
        }

        public String strEmail
        {
            get { return this.m_strEmail; }
            set { this.m_strEmail = value; }
        }

        public String strPhone
        {
            get { return this.m_strPhone; }
            set { this.m_strPhone = value; }
        }

        public String strCompany
        {
            get { return this.m_strCompany; }
            set { this.m_strCompany = value; }
        }

        public String strSMTPServerName
        {
            get { return this.m_strSMTPServerName; }
            set { this.m_strSMTPServerName = value; }
        }

        public String strSMTPServerPassword
        {
            get { return this.m_strSMTPServerPassword; }
            set { this.m_strSMTPServerPassword = value; }
        }

        public String strSMTPServerUserName
        {
            get { return this.m_strSMTPServerUserName; }
            set { this.m_strSMTPServerUserName = value; }
        }

        public bool boolUseProvidedSMTPServer
        {
            get { return this.m_boolUseProvidedSMTPServer; }
            set { this.m_boolUseProvidedSMTPServer = value; }
        }

        public Nullable<Int32> iCompanySize
        {
            get { return this.m_iCompanySize; }
            set { this.m_iCompanySize = value; }
        }

        public Nullable<Int32> iCountryEntityID
        {
            get { return this.m_iCountryEntityID; }
            set { this.m_iCountryEntityID = value; }
        }

        public Nullable<Int32> iShopID
        {
            get { return this.m_iShopID; }
            set { this.m_iShopID = value; }
        }

        public Nullable<Int32> iRoleID
        {
            get { return this.m_iRoleID; }
            set { this.m_iRoleID = value; }
        }
        public Nullable<Int32> iSMTPPort
        {
            get { return this.m_iSMTPPort; }
            set { this.m_iSMTPPort = value; }
        }
        public bool boolEnableSSL
        {
            get { return this.m_boolEnableSSL; }
            set { this.m_boolEnableSSL = value; }
        }

        public Nullable<Int32> iAvailableSMS
        {
            get { return this.m_iAvailableSMS; }
            set { this.m_iAvailableSMS = value; }
        }

        public Nullable<Int32> iSentSMS
        {
            get { return this.m_iSentSMS; }
            set { this.m_iSentSMS = value; }
        }

        public Nullable<DateTime> dtSMSActivationDate
        {
            get { return this.m_dtSMSActivationDate; }
            set { this.m_dtSMSActivationDate = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }

        public String strSMTPServerEmail
        {
            get { return this.m_strSMTPServerEmail; }
            set { this.m_strSMTPServerEmail = value; }
        }

        #endregion "Accessors"

        #region "Static Methods"

        private static LoginTableAdapter getAdapter()
        {
            return new LoginTableAdapter();
        }

        public static List<LoginBL> getData()
        {
            SummitDS.LoginDataTable thisTable = getAdapter().GetData();
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromTable(thisTable);
            }
            return null;
        }

        public static List<LoginBL> AllAdmins()
        {
            SummitDS.LoginDataTable thisTable = getAdapter().AdminList();
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromTable(thisTable);
            }
            return null;
        }

        public static List<LoginBL> AdminShopList()
        {
            SummitDS.LoginDataTable thisTable = getAdapter().AdminList();
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromTable(thisTable);
            }
            return null;
        }

        public static LoginBL getByUserId(Int32 iUserId)
        {
            SummitDS.LoginDataTable thisTable = getAdapter().GetDataById(iUserId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        public static LoginBL getByShopId(Int32 iShopId)
        {
            SummitDS.LoginDataTable thisTable = getAdapter().GetDataByShopId(iShopId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        public static LoginBL getByUserName(String strUserName)
        {
            SummitDS.LoginDataTable thisTable = getAdapter().GetDataByUserName(strUserName);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        public static List<LoginBL> getByEmail(String strEmail)
        {
            SummitDS.LoginDataTable thisTable = getAdapter().GetDataByEmail(strEmail);
            List<LoginBL> _list = new List<LoginBL>();
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                foreach (DataRow dr in thisTable.Rows)
                {
                    LoginBL _thisMember = new LoginBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }

        /// <summary>
        /// Get all users who are in the role of marketing user  
        /// </summary>
        /// <returns></returns>
        public static List<LoginBL> GetAllMarketingUsers()
        {
            SummitDS.LoginDataTable thisTable = getAdapter().GetAllMarketingUsers();
            List<LoginBL> _list = new List<LoginBL>();
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                foreach (DataRow dr in thisTable.Rows)
                {
                    LoginBL _thisMember = new LoginBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }

        private static LoginBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new LoginBL(drRow);
            }
            return null;
        }

        private static List<LoginBL> BuildFromTable(DataTable dtTable)
        {
            List<LoginBL> _list = new List<LoginBL>();

            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    LoginBL _thisMember = new LoginBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }

        #endregion "Static Methods"

        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.LoginRow _thisRow = _dataRow as SummitDS.LoginRow;

            if (_thisRow != null)
            {
                this._ID = _thisRow.UserID;
                this.m_strUserName = _thisRow.IsUserNameNull() ? String.Empty : _thisRow.UserName;
                this.m_strPassword = _thisRow.IsPasswordNull() ? String.Empty : _thisRow.Password;
                this.m_strFirstName = _thisRow.IsFirstNameNull() ? String.Empty : _thisRow.FirstName;
                this.m_strLastName = _thisRow.IsLastNameNull() ? String.Empty : _thisRow.LastName;
                this.m_strEmail = _thisRow.IsEmailNull() ? String.Empty : _thisRow.Email;
                this.m_strPhone = _thisRow.IsPhoneNull() ? String.Empty : _thisRow.Phone;
                this.m_strCompany = _thisRow.IsCompanyNull() ? String.Empty : _thisRow.Company;
                this.m_strSMTPServerName = _thisRow.IsSMTPServerNameNull() ? String.Empty : _thisRow.SMTPServerName;
                this.m_strSMTPServerUserName = _thisRow.IsSMTPServerUserNameNull() ? String.Empty : _thisRow.SMTPServerUserName;
                this.m_strSMTPServerPassword = _thisRow.IsSMTPServerPasswordNull() ? String.Empty : _thisRow.SMTPServerPassword;
                this.m_boolUseProvidedSMTPServer = _thisRow.IsUseProvidedSMTPServerNull() ? Convert.ToBoolean((Nullable<Boolean>)null) : _thisRow.UseProvidedSMTPServer;
                this.m_iCompanySize = _thisRow.IsCompanySizeNull() ? (Nullable<Int32>)null : _thisRow.CompanySize;
                this.m_iCountryEntityID = _thisRow.IsCountryEntityIDNull() ? (Nullable<Int32>)null : _thisRow.CountryEntityID;
                this.m_iShopID = _thisRow.IsShopIDNull() ? (Nullable<Int32>)null : _thisRow.ShopID;
                this.m_iRoleID = _thisRow.IsRoleIdNull() ? (Nullable<Int32>)null : _thisRow.RoleId;
                this.m_iAvailableSMS = _thisRow.IsAvailableSMSNull() ? (Nullable<Int32>)null : _thisRow.AvailableSMS;
                this.m_iSentSMS = _thisRow.IsSentSMSNull() ? (Nullable<Int32>)null : _thisRow.SentSMS;
                this.m_dtSMSActivationDate = _thisRow.IsSMSActivationDateNull() ? (Nullable<DateTime>)null : _thisRow.SMSActivationDate;
                this.m_iSMTPPort = _thisRow.IsSMTPServerPortNull() ? (Nullable<Int32>)null : _thisRow.SMTPServerPort;
                this.boolEnableSSL = _thisRow.EnableSSL;
                this.m_strSMTPServerEmail = _thisRow.IsSMTPServerEmailNull() ? String.Empty : _thisRow.SMTPServerEmail;

                //  this.m_dt_ts = _thisRow.Is_tsNull() ? (Nullable<DateTime>) null : _thisRow._ts ;                                
                _rowToSave = _thisRow;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.LoginDataTable _thisTable = new SummitDS.LoginDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewLoginRow();
            SummitDS.LoginRow _dataRow = _rowToSave as SummitDS.LoginRow;

            if (_dataRow != null)
            {
                if (IsExisting())
                {
                    if (String.IsNullOrEmpty(m_strUserName)) { if (!_dataRow.IsUserNameNull()) _dataRow.SetUserNameNull(); }
                    else if (_dataRow.IsUserNameNull() ? true : _dataRow.UserName != m_strUserName) _dataRow.UserName = m_strUserName;

                    if (String.IsNullOrEmpty(m_strPassword)) { if (!_dataRow.IsPasswordNull()) _dataRow.SetPasswordNull(); }
                    else if (_dataRow.IsPasswordNull() ? true : _dataRow.Password != m_strPassword) _dataRow.Password = m_strPassword;

                    if (String.IsNullOrEmpty(m_strFirstName)) { if (!_dataRow.IsFirstNameNull()) _dataRow.SetFirstNameNull(); }
                    else if (_dataRow.IsFirstNameNull() ? true : _dataRow.FirstName != m_strFirstName) _dataRow.FirstName = m_strFirstName;

                    if (String.IsNullOrEmpty(m_strLastName)) { if (!_dataRow.IsLastNameNull()) _dataRow.SetLastNameNull(); }
                    else if (_dataRow.IsLastNameNull() ? true : _dataRow.LastName != m_strLastName) _dataRow.LastName = m_strLastName;

                    if (String.IsNullOrEmpty(m_strEmail)) { if (!_dataRow.IsEmailNull()) _dataRow.SetEmailNull(); }
                    else if (_dataRow.IsEmailNull() ? true : _dataRow.Email != m_strEmail) _dataRow.Email = m_strEmail;

                    if (String.IsNullOrEmpty(m_strPhone)) { if (!_dataRow.IsPhoneNull()) _dataRow.SetPhoneNull(); }
                    else if (_dataRow.IsPhoneNull() ? true : _dataRow.Phone != m_strPhone) _dataRow.Phone = m_strPhone;

                    if (String.IsNullOrEmpty(m_strCompany)) { if (!_dataRow.IsCompanyNull()) _dataRow.SetCompanyNull(); }
                    else if (_dataRow.IsCompanyNull() ? true : _dataRow.Company != m_strCompany) _dataRow.Company = m_strCompany;

                    if (String.IsNullOrEmpty(m_strSMTPServerName)) { if (!_dataRow.IsSMTPServerNameNull()) _dataRow.SetSMTPServerNameNull(); }
                    else if (_dataRow.IsSMTPServerNameNull() ? true : _dataRow.SMTPServerName != m_strSMTPServerName) _dataRow.SMTPServerName = m_strSMTPServerName;

                    if (String.IsNullOrEmpty(m_strSMTPServerPassword)) { if (!_dataRow.IsSMTPServerPasswordNull()) _dataRow.SetSMTPServerPasswordNull(); }
                    else if (_dataRow.IsSMTPServerPasswordNull() ? true : _dataRow.SMTPServerPassword != m_strSMTPServerPassword) _dataRow.SMTPServerPassword = m_strSMTPServerPassword;

                    if (String.IsNullOrEmpty(m_strSMTPServerUserName)) { if (!_dataRow.IsSMTPServerUserNameNull()) _dataRow.SetSMTPServerUserNameNull(); }
                    else if (_dataRow.IsSMTPServerUserNameNull() ? true : _dataRow.SMTPServerUserName != m_strSMTPServerUserName) _dataRow.SMTPServerUserName = m_strSMTPServerUserName;

                    if (m_boolUseProvidedSMTPServer == null) { if (!_dataRow.IsUseProvidedSMTPServerNull()) _dataRow.SetUseProvidedSMTPServerNull(); }
                    else if (_dataRow.IsUseProvidedSMTPServerNull() ? true : _dataRow.UseProvidedSMTPServer != m_boolUseProvidedSMTPServer) _dataRow.UseProvidedSMTPServer = m_boolUseProvidedSMTPServer;

                    if (iCompanySize.HasValue) _dataRow.CompanySize = iCompanySize.Value;
                    else _dataRow.SetCompanySizeNull();

                    if (iCountryEntityID.HasValue) _dataRow.CountryEntityID = iCountryEntityID.Value;
                    else _dataRow.SetCountryEntityIDNull();

                    if (iShopID.HasValue) _dataRow.ShopID = iShopID.Value;
                    else _dataRow.SetShopIDNull();

                    if (iRoleID.HasValue) _dataRow.RoleId = iRoleID.Value;
                    else _dataRow.SetRoleIdNull();

                    if (iAvailableSMS.HasValue) _dataRow.AvailableSMS = iAvailableSMS.Value;
                    else _dataRow.SetAvailableSMSNull();

                    if (iSentSMS.HasValue) _dataRow.SentSMS = iSentSMS.Value;
                    else _dataRow.SetSentSMSNull();

                    if (dtSMSActivationDate.HasValue) _dataRow.SMSActivationDate = dtSMSActivationDate.Value;
                    else _dataRow.SetSMSActivationDateNull();

                    if (iSMTPPort.HasValue) _dataRow.SMTPServerPort = iSMTPPort.Value;
                    else _dataRow.SetSMTPServerPortNull();

                    if (m_boolEnableSSL == null) { _dataRow.EnableSSL = false; }
                    else _dataRow.EnableSSL = m_boolEnableSSL;

                    if (String.IsNullOrEmpty(m_strSMTPServerEmail)) { if (!_dataRow.IsSMTPServerEmailNull()) _dataRow.SetSMTPServerEmailNull(); }
                    else if (_dataRow.IsSMTPServerEmailNull() ? true : _dataRow.SMTPServerEmail != m_strSMTPServerEmail) _dataRow.SMTPServerEmail = m_strSMTPServerEmail;

                }
                else
                {
                    if (String.IsNullOrEmpty(m_strUserName)) { if (!_dataRow.IsUserNameNull()) _dataRow.SetUserNameNull(); }
                    else if (_dataRow.IsUserNameNull() ? true : _dataRow.UserName != m_strUserName) _dataRow.UserName = m_strUserName;

                    if (String.IsNullOrEmpty(m_strPassword)) { if (!_dataRow.IsPasswordNull()) _dataRow.SetPasswordNull(); }
                    else if (_dataRow.IsPasswordNull() ? true : _dataRow.Password != m_strPassword) _dataRow.Password = m_strPassword;

                    if (String.IsNullOrEmpty(m_strFirstName)) { if (!_dataRow.IsFirstNameNull()) _dataRow.SetFirstNameNull(); }
                    else if (_dataRow.IsFirstNameNull() ? true : _dataRow.FirstName != m_strFirstName) _dataRow.FirstName = m_strFirstName;

                    if (String.IsNullOrEmpty(m_strLastName)) { if (!_dataRow.IsLastNameNull()) _dataRow.SetLastNameNull(); }
                    else if (_dataRow.IsLastNameNull() ? true : _dataRow.LastName != m_strLastName) _dataRow.LastName = m_strLastName;

                    if (String.IsNullOrEmpty(m_strEmail)) { if (!_dataRow.IsEmailNull()) _dataRow.SetEmailNull(); }
                    else if (_dataRow.IsEmailNull() ? true : _dataRow.Email != m_strEmail) _dataRow.Email = m_strEmail;

                    if (String.IsNullOrEmpty(m_strPhone)) { if (!_dataRow.IsPhoneNull()) _dataRow.SetPhoneNull(); }
                    else if (_dataRow.IsPhoneNull() ? true : _dataRow.Phone != m_strPhone) _dataRow.Phone = m_strPhone;

                    if (String.IsNullOrEmpty(m_strCompany)) { if (!_dataRow.IsCompanyNull()) _dataRow.SetCompanyNull(); }
                    else if (_dataRow.IsCompanyNull() ? true : _dataRow.Company != m_strCompany) _dataRow.Company = m_strCompany;

                    if (String.IsNullOrEmpty(m_strSMTPServerName)) { if (!_dataRow.IsSMTPServerNameNull()) _dataRow.SetSMTPServerNameNull(); }
                    else if (_dataRow.IsSMTPServerNameNull() ? true : _dataRow.SMTPServerName != m_strSMTPServerName) _dataRow.SMTPServerName = m_strSMTPServerName;

                    if (String.IsNullOrEmpty(m_strSMTPServerPassword)) { if (!_dataRow.IsSMTPServerPasswordNull()) _dataRow.SetSMTPServerPasswordNull(); }
                    else if (_dataRow.IsSMTPServerPasswordNull() ? true : _dataRow.SMTPServerPassword != m_strSMTPServerPassword) _dataRow.SMTPServerPassword = m_strSMTPServerPassword;

                    if (String.IsNullOrEmpty(m_strSMTPServerUserName)) { if (!_dataRow.IsSMTPServerUserNameNull()) _dataRow.SetSMTPServerUserNameNull(); }
                    else if (_dataRow.IsSMTPServerUserNameNull() ? true : _dataRow.SMTPServerUserName != m_strSMTPServerUserName) _dataRow.SMTPServerUserName = m_strSMTPServerUserName;

                    if (m_boolUseProvidedSMTPServer == null) { if (!_dataRow.IsUseProvidedSMTPServerNull()) _dataRow.SetUseProvidedSMTPServerNull(); }
                    else if (_dataRow.IsUseProvidedSMTPServerNull() ? true : _dataRow.UseProvidedSMTPServer != m_boolUseProvidedSMTPServer) _dataRow.UseProvidedSMTPServer = m_boolUseProvidedSMTPServer;


                    if (iCompanySize.HasValue) _dataRow.CompanySize = iCompanySize.Value;
                    else _dataRow.SetCompanySizeNull();

                    if (iCountryEntityID.HasValue) _dataRow.CountryEntityID = iCountryEntityID.Value;
                    else _dataRow.SetCountryEntityIDNull();

                    if (iShopID.HasValue) _dataRow.ShopID = iShopID.Value;
                    else _dataRow.SetShopIDNull();

                    if (iRoleID.HasValue) _dataRow.RoleId = iRoleID.Value;
                    else _dataRow.SetRoleIdNull();

                    if (iAvailableSMS.HasValue) _dataRow.AvailableSMS = iAvailableSMS.Value;
                    else _dataRow.SetAvailableSMSNull();

                    if (iSentSMS.HasValue) _dataRow.SentSMS = iSentSMS.Value;
                    else _dataRow.SetSentSMSNull();

                    if (dtSMSActivationDate.HasValue) _dataRow.SMSActivationDate = dtSMSActivationDate.Value;
                    else _dataRow.SetSMSActivationDateNull();

                    if (iSMTPPort.HasValue) _dataRow.SMTPServerPort = iSMTPPort.Value;
                    else _dataRow.SetSMTPServerPortNull();

                    if (m_boolEnableSSL == null) { _dataRow.EnableSSL = false; }
                    else _dataRow.EnableSSL = m_boolEnableSSL;

                    if (String.IsNullOrEmpty(m_strSMTPServerEmail)) { if (!_dataRow.IsSMTPServerEmailNull()) _dataRow.SetSMTPServerEmailNull(); }
                    else if (_dataRow.IsSMTPServerEmailNull() ? true : _dataRow.SMTPServerEmail != m_strSMTPServerEmail) _dataRow.SMTPServerEmail = m_strSMTPServerEmail;

                    _thisTable.AddLoginRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
            SummitDS.LoginRow thisRow = _rowToSave as SummitDS.LoginRow;
            if (thisRow != null)
            {
                this._ID = thisRow.UserID;
            }
        }

        protected override void Update()
        {
            if (_rowToSave.RowState == DataRowState.Unchanged)
            {
                return;
            }
            else
            {
                Int32 iUpdate = getAdapter().Update(_rowToSave);
            }
        }

        protected override void DeleteRecord()
        {
        }
        #endregion "Overrides"

        #region "IComparable"
        public int CompareTo(LoginBL au2, String comparisonType)
        {
            String baseComparisonType = comparisonType;
            Int32 compareResult = 0;
            Int32 descFlag = 1; //-1 for descending, + 1 for ascending, multiply by compare result

            if (comparisonType.Contains("DESC"))
            {
                descFlag = -1;
                string[] compArr = comparisonType.Split(new Char[] { ' ' });
                if (compArr.Length > 0)
                {
                    baseComparisonType = compArr[0];
                }
            }

            switch (comparisonType)
            {
                case "strFirstNameASC":
                    descFlag = 1;
                    compareResult = m_strFirstName.CompareTo(au2.m_strFirstName);
                    break;

                case "strFirstNameDESC":
                    descFlag = -1;
                    compareResult = m_strFirstName.CompareTo(au2.m_strFirstName);
                    break;

                case "strLastNameASC":
                    descFlag = 1;
                    compareResult = m_strLastName.CompareTo(au2.m_strLastName);
                    break;

                case "strLastNameDESC":
                    descFlag = -1;
                    compareResult = m_strLastName.CompareTo(au2.m_strLastName);
                    break;


                case "strUserNameASC":
                    descFlag = 1;
                    compareResult = m_strUserName.CompareTo(au2.m_strUserName);
                    break;


                case "strUserNameDESC":
                    descFlag = -1;
                    compareResult = m_strUserName.CompareTo(au2.m_strUserName);
                    break;


                case "strEmailASC":
                    descFlag = 1;
                    compareResult = strEmail.CompareTo(au2.strEmail);
                    break;

                case "strEmailDESC":
                    descFlag = -1;
                    compareResult = strEmail.CompareTo(au2.strEmail);
                    break;

                case "strPhoneDESC":
                    descFlag = -1;
                    if (strPhone != null && au2.strPhone != null)
                        compareResult = strPhone.CompareTo(au2.strPhone);
                    break;


                case "strPhoneASC":
                    descFlag = 1;
                    if (strPhone != null && au2.strPhone != null)
                        compareResult = strPhone.CompareTo(au2.strPhone);
                    break;

                default:
                    descFlag = 1;
                    compareResult = strFirstName.CompareTo(au2.strFirstName);
                    break;

            }
            return compareResult * descFlag; //desc flag of -1 returns negative result for descending sort
        }
        #endregion




    }

    public class LoginComparer : IComparer<LoginBL>
    {
        private String comparisonType;

        public String ComparisonType
        {
            get { return comparisonType; }
            set { comparisonType = value; }
        }

        public int Compare(LoginBL o1, LoginBL o2)
        {
            return o1.CompareTo(o2, comparisonType);
        }
    }
}
