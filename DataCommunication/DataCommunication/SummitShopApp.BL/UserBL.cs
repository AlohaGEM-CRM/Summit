﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;
using System.Data;

namespace SummitShopApp.BL
{
    public class UserBL : BaseEditableItem
    {
        #region "Constructor"

        public UserBL()
        {

        }

        public UserBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        String m_strEmail;
        String m_strPhone;
        String m_strUserName;
        String m_strZip;
        Nullable<DateTime> m_dtAppDownLoadDate;
        Nullable<Boolean> m_bIsRegistred;
        Nullable<Boolean> m_bIsNew;
        Nullable<Boolean> m_bIsRegistred_Shop;
        String m_strPhone_Id;
        String m_strFirstName;
        String m_strLastName;
        String m_strAddress1;
        String m_strAddress2;
        String m_strCity;
        String m_strState;
        Nullable<Int32> m_iDevice_Type;
        String m_strPush_notification_device_id;
        Nullable<Boolean> m_bIsShow;
        Nullable<Boolean> m_bIsShowEmailMarketing;
        Nullable<Boolean> m_bIsShowTextMarketing;
        Nullable<DateTime> m_dtUpdatedEntryTime;
        String m_strPhone2;
        Nullable<Boolean> m_bIsOptOutNotificationSent;
        Nullable<Boolean> m_bIsOptedOutForMobileMessage;
        #endregion "Members"

        #region "Accessors"

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

        public String strUserName
        {
            get { return this.m_strUserName; }
            set { this.m_strUserName = value; }
        }

        public String strZip
        {
            get { return this.m_strZip; }
            set { this.m_strZip = value; }
        }

        public Nullable<DateTime> dtAppDownLoadDate
        {
            get { return this.m_dtAppDownLoadDate; }
            set { this.m_dtAppDownLoadDate = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }

        public Nullable<Boolean> bIsRegistred
        {
            get { return this.m_bIsRegistred; }
            set { this.m_bIsRegistred = value; }
        }

        public Nullable<Boolean> bIsNew
        {
            get { return this.m_bIsNew; }
            set { this.m_bIsNew = value; }
        }

        public Nullable<Boolean> bIsRegistred_Shop
        {
            get { return this.m_bIsRegistred_Shop; }
            set { this.m_bIsRegistred_Shop = value; }
        }

        public String strPhone_Id
        {
            get { return this.m_strPhone_Id; }
            set { this.m_strPhone_Id = value; }
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

        public String strAddress1
        {
            get { return this.m_strAddress1; }
            set { this.m_strAddress1 = value; }
        }

        public String strAddress2
        {
            get { return this.m_strAddress2; }
            set { this.m_strAddress2 = value; }
        }

        public String strCity
        {
            get { return this.m_strCity; }
            set { this.m_strCity = value; }
        }

        public String strState
        {
            get { return this.m_strState; }
            set { this.m_strState = value; }
        }

        public Nullable<Boolean> bIsShow
        {
            get { return this.m_bIsShow; }
            set { this.m_bIsShow = value; }
        }

        public Nullable<Boolean> bIsShowEmailMarketing
        {
            get { return this.m_bIsShowEmailMarketing; }
            set { this.m_bIsShowEmailMarketing = value; }
        }

        public Nullable<Boolean> bIsShowTextMarketing
        {
            get { return this.m_bIsShowTextMarketing; }
            set { this.m_bIsShowTextMarketing = value; }
        }

        public Nullable<DateTime> dtUpdatedEntryTime
        {
            get { return this.m_dtUpdatedEntryTime; }
            set { this.m_dtUpdatedEntryTime = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }

        public String strPhone2
        {
            get { return this.m_strPhone2; }
            set { this.m_strPhone2 = value; }
        }

        public Nullable<Boolean> bIsOptOutNotificationSent
        {
            get { return this.m_bIsOptOutNotificationSent; }
            set { this.m_bIsOptOutNotificationSent = value; }
        }

        public Nullable<Boolean> bIsOptedOutForMobileMessage
        {
            get { return this.m_bIsOptedOutForMobileMessage; }
            set { this.m_bIsOptedOutForMobileMessage = value; }
        }

        public Nullable<int> iDeviceType
        {
            get { return this.m_iDevice_Type; }
            set { this.m_iDevice_Type = value; }
        }

        public String strPush_notification_device_id
        {
            get { return this.m_strPush_notification_device_id; }
            set { this.m_strPush_notification_device_id = value; }
        }

        #endregion "Accessors"

        #region "Static Methods"

        private static UserTableAdapter getAdapter()
        {
            return new UserTableAdapter();
        }

        public static List<UserBL> GetUserData()
        {
            List<UserBL> _list = new List<UserBL>();
            SummitDS.UserDataTable thisTable = getAdapter().GetData();
            if (thisTable != null)
            {
                foreach (DataRow dr in thisTable.Rows)
                {
                    UserBL _thisMember = new UserBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }

        public static UserBL getByActivityId(Int32 iUserId)
        {
            SummitDS.UserDataTable thisTable = getAdapter().GetDataById(iUserId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        public static Int32 getCountNewProspects(Int32 iUserId)
        {
            List<ZipCodeBL> objlstZipCode = ZipCodeBL.getDataByLoginId(iUserId);
            List<UserBL> lstUser = new List<UserBL>();

            if (objlstZipCode != null)
            {
                foreach (ZipCodeBL objZipCode in objlstZipCode)
                {
                    SummitDS.UserDataTable thisTable = getAdapter().GetDataByNewProspects(objZipCode.strZipCode);
                    List<UserBL> lstTempUserBL = null;
                    if (thisTable != null && thisTable.Rows.Count > 0)
                    {
                        lstTempUserBL = BuildFromTable(thisTable);
                        foreach (UserBL objUser in lstTempUserBL)
                        {
                            lstUser.Add(objUser);
                        }
                    }
                }
            }
            if (lstUser != null && lstUser.Count > 0)
            {
                return lstUser.Count;
            }
            return 0;
        }

        public static List<UserBL> getNewProspects(Int32 iUserId)
        {
            List<ZipCodeBL> objlstZipCode = ZipCodeBL.getDataByLoginId(iUserId);
            List<UserBL> lstUser = new List<UserBL>();

            if (objlstZipCode != null)
            {
                foreach (ZipCodeBL objZipCode in objlstZipCode)
                {
                    SummitDS.UserDataTable thisTable = getAdapter().GetDataByNewProspects(objZipCode.strZipCode);
                    List<UserBL> lstTempUserBL = null;
                    if (thisTable != null && thisTable.Rows.Count > 0)
                    {
                        lstTempUserBL = BuildFromTable(thisTable);
                        foreach (UserBL objUser in lstTempUserBL)
                        {
                            lstUser.Add(objUser);
                        }
                    }
                }
            }
            return lstUser;
        }

        public static UserBL getDataByPhoneId(String strPhoneId)
        {
            SummitDS.UserDataTable thisTable = getAdapter().GetDataByPhoneId(strPhoneId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        public static Int32 getCountToRegistredShop(Int32 iShopId)
        {
            SummitDS.UserDataTable thisTable = getAdapter().GetDataByShopId(iShopId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                List<SummitDS.UserRow> lstUser = new List<SummitDS.UserRow>();
                foreach (SummitDS.UserRow objUser in thisTable)
                {
                    if (!objUser.IsisRegistred_ShopNull() && objUser.isRegistred_Shop == true)
                    {
                        lstUser.Add(objUser);
                    }
                }
                if (lstUser.Count > 0)
                {
                    return lstUser.Count;
                }
            }
            return 0;
        }

        public static List<UserBL> getdataByShop(Int32 iShopId)
        {
            SummitDS.UserDataTable thisTable = getAdapter().GetDataByShopId(iShopId);


            List<UserBL> lstUser = null;
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                lstUser = BuildFromTable(thisTable);
                foreach (UserBL objUser in lstUser)
                {
                    lstUser.Add(objUser);
                }
            }


            return lstUser;
        }

        private static UserBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new UserBL(drRow);
            }
            return null;
        }

        private static List<UserBL> BuildFromTable(DataTable dtTable)
        {
            List<UserBL> _list = new List<UserBL>();

            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    UserBL _thisMember = new UserBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }

        public static void UpdateUsersOnOptOutNotificationSent(String strPhoneNumber)
        {
            getAdapter().UpdateUsersForOptOutNotificationSentByPhone(strPhoneNumber);
        }

        public static UserBL GetDataByPhoneNumber(String strPhoneId)
        {
            SummitDS.UserDataTable thisTable = getAdapter().GetDataByPhoneNumber(strPhoneId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        public static int getDataByUserPhoneAndNotificationSent(String strPhoneNumber)
        {
            return Convert.ToInt32(getAdapter().GetDataByUserPhoneAndNotificationSent(strPhoneNumber));
        }

        #endregion "Static Methods"

        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.UserRow _thisRow = _dataRow as SummitDS.UserRow;

            if (_thisRow != null)
            {
                this._ID = _thisRow.user_id;
                this.m_strEmail = _thisRow.IsemailNull() ? String.Empty : _thisRow.email;
                this.m_strPhone = _thisRow.IsphoneNull() ? String.Empty : _thisRow.phone;
                this.m_strUserName = _thisRow.IsusernameNull() ? String.Empty : _thisRow.username;
                this.m_strZip = _thisRow.IszipNull() ? String.Empty : _thisRow.zip;
                this.m_dtAppDownLoadDate = _thisRow.IsappDownLoadDateNull() ? (Nullable<DateTime>)null : _thisRow.appDownLoadDate;
                this.m_bIsRegistred = _thisRow.IsisRegistredNull() ? (Nullable<Boolean>)null : _thisRow.isRegistred;
                this.m_bIsNew = _thisRow.IsisNewNull() ? (Nullable<Boolean>)null : _thisRow.isNew;
                this.m_bIsRegistred_Shop = _thisRow.IsisRegistred_ShopNull() ? (Nullable<Boolean>)null : _thisRow.isRegistred_Shop;
                this.m_strPhone_Id = _thisRow.Isphone_idNull() ? String.Empty : _thisRow.phone_id;
                this.m_strFirstName = _thisRow.Isfirst_nameNull() ? String.Empty : _thisRow.first_name;
                this.m_strLastName = _thisRow.Islast_nameNull() ? String.Empty : _thisRow.last_name;
                this.m_strAddress1 = _thisRow.Isaddress1Null() ? String.Empty : _thisRow.address1;
                this.m_strAddress2 = _thisRow.Isaddress2Null() ? String.Empty : _thisRow.address2;
                this.m_strCity = _thisRow.IscityNull() ? String.Empty : _thisRow.city;
                this.m_strState = _thisRow.IsstateNull() ? String.Empty : _thisRow.state;
                this.m_bIsShow = _thisRow.IsisShowNull() ? (Nullable<Boolean>)null : _thisRow.isShow;
                this.m_bIsShowEmailMarketing = _thisRow.IsisShowEmailMarketingNull() ? (Nullable<Boolean>)null : _thisRow.isShowEmailMarketing;
                this.m_bIsShowTextMarketing = _thisRow.IsisShowTextMarketingNull() ? (Nullable<Boolean>)null : _thisRow.isShowTextMarketing;
                this.m_dtUpdatedEntryTime = _thisRow.IsupdatedEntryTimeNull() ? (Nullable<DateTime>)null : _thisRow.updatedEntryTime;
                this.m_strPhone2 = _thisRow.Isphone2Null() ? String.Empty : _thisRow.phone2;
                this.m_bIsOptOutNotificationSent = _thisRow.IsisOptOutNotificationSentNull() ? (Nullable<Boolean>)null : _thisRow.isOptOutNotificationSent;
                this.m_bIsOptedOutForMobileMessage = _thisRow.IsisOptedOutForMobileMessageNull() ? (Nullable<Boolean>)null : _thisRow.isOptedOutForMobileMessage;
                this.m_strPush_notification_device_id = _thisRow.Ispush_notification_device_idNull() ? String.Empty : _thisRow.push_notification_device_id;
                this.m_iDevice_Type = _thisRow.IsDevice_TypeNull() ? (Nullable<int>)null : _thisRow.Device_Type;
                //  this.m_dt_ts = _thisRow.Is_tsNull() ? (Nullable<DateTime>) null : _thisRow._ts ;                                
                _rowToSave = _thisRow;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.UserDataTable _thisTable = new SummitDS.UserDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewUserRow();
            SummitDS.UserRow _dataRow = _rowToSave as SummitDS.UserRow;

            if (_dataRow != null)
            {
                if (IsExisting())
                {
                    if (String.IsNullOrEmpty(m_strEmail)) { if (!_dataRow.IsemailNull()) _dataRow.SetemailNull(); }
                    else if (_dataRow.IsemailNull() ? true : _dataRow.email != m_strEmail) _dataRow.email = m_strEmail;

                    if (String.IsNullOrEmpty(m_strPhone)) { if (!_dataRow.IsphoneNull()) _dataRow.SetphoneNull(); }
                    else if (_dataRow.IsphoneNull() ? true : _dataRow.phone != m_strPhone) _dataRow.phone = m_strPhone;

                    if (String.IsNullOrEmpty(m_strUserName)) { if (!_dataRow.IsusernameNull()) _dataRow.SetusernameNull(); }
                    else if (_dataRow.IsusernameNull() ? true : _dataRow.username != m_strUserName) _dataRow.username = m_strUserName;

                    if (String.IsNullOrEmpty(m_strZip)) { if (!_dataRow.IszipNull()) _dataRow.SetzipNull(); }
                    else if (_dataRow.IszipNull() ? true : _dataRow.zip != m_strZip) _dataRow.zip = m_strZip;

                    if (!m_dtAppDownLoadDate.HasValue) { if (!_dataRow.IsappDownLoadDateNull()) _dataRow.SetappDownLoadDateNull(); }
                    else if (_dataRow.IsappDownLoadDateNull() ? true : _dataRow.appDownLoadDate != m_dtAppDownLoadDate.Value) _dataRow.appDownLoadDate = m_dtAppDownLoadDate.Value;

                    if (bIsRegistred.HasValue) _dataRow.isRegistred = bIsRegistred.Value;
                    else _dataRow.SetisRegistredNull();

                    if (bIsNew.HasValue) _dataRow.isNew = bIsNew.Value;
                    else _dataRow.SetisNewNull();

                    if (bIsRegistred_Shop.HasValue) _dataRow.isRegistred_Shop = bIsRegistred_Shop.Value;
                    else _dataRow.SetisRegistred_ShopNull();

                    if (String.IsNullOrEmpty(m_strPhone_Id)) { if (!_dataRow.Isphone_idNull()) _dataRow.Setphone_idNull(); }
                    else if (_dataRow.Isphone_idNull() ? true : _dataRow.phone_id != m_strPhone_Id) _dataRow.phone_id = m_strPhone_Id;

                    if (String.IsNullOrEmpty(m_strFirstName)) { if (!_dataRow.Isfirst_nameNull()) _dataRow.Setfirst_nameNull(); }
                    else if (_dataRow.Isfirst_nameNull() ? true : _dataRow.first_name != m_strFirstName) _dataRow.first_name = m_strFirstName;

                    if (String.IsNullOrEmpty(m_strLastName)) { if (!_dataRow.Islast_nameNull()) _dataRow.Setlast_nameNull(); }
                    else if (_dataRow.Islast_nameNull() ? true : _dataRow.last_name != m_strLastName) _dataRow.last_name = m_strLastName;

                    if (String.IsNullOrEmpty(m_strAddress1)) { if (!_dataRow.Isaddress1Null()) _dataRow.Setaddress1Null(); }
                    else if (_dataRow.Isaddress1Null() ? true : _dataRow.address1 != m_strAddress1) _dataRow.address1 = m_strAddress1;

                    if (String.IsNullOrEmpty(m_strAddress2)) { if (!_dataRow.Isaddress2Null()) _dataRow.Setaddress2Null(); }
                    else if (_dataRow.Isaddress2Null() ? true : _dataRow.address2 != m_strAddress2) _dataRow.address2 = m_strAddress2;

                    if (String.IsNullOrEmpty(m_strCity)) { if (!_dataRow.IscityNull()) _dataRow.SetcityNull(); }
                    else if (_dataRow.IscityNull() ? true : _dataRow.city != m_strCity) _dataRow.city = m_strCity;

                    if (String.IsNullOrEmpty(m_strState)) { if (!_dataRow.IsstateNull()) _dataRow.SetstateNull(); }
                    else if (_dataRow.IsstateNull() ? true : _dataRow.state != m_strState) _dataRow.state = m_strState;

                    if (bIsShow.HasValue) _dataRow.isShow = bIsShow.Value;
                    else _dataRow.SetisShowNull();

                    if (bIsShowEmailMarketing.HasValue) _dataRow.isShowEmailMarketing = bIsShowEmailMarketing.Value;
                    else _dataRow.SetisShowEmailMarketingNull();

                    if (bIsShowTextMarketing.HasValue) _dataRow.isShowTextMarketing = bIsShowTextMarketing.Value;
                    else _dataRow.SetisShowTextMarketingNull();

                    if (dtUpdatedEntryTime.HasValue) _dataRow.updatedEntryTime = dtUpdatedEntryTime.Value;
                    else _dataRow.SetupdatedEntryTimeNull();

                    if (String.IsNullOrEmpty(m_strPhone2)) { if (!_dataRow.Isphone2Null()) _dataRow.Setphone2Null(); }
                    else if (_dataRow.Isphone2Null() ? true : _dataRow.phone2 != m_strPhone2) _dataRow.phone2 = m_strPhone2;

                    if (bIsOptOutNotificationSent.HasValue) _dataRow.isOptOutNotificationSent = bIsOptOutNotificationSent.Value;
                    else _dataRow.SetisOptOutNotificationSentNull();

                    if (bIsOptedOutForMobileMessage.HasValue) _dataRow.isOptedOutForMobileMessage = bIsOptedOutForMobileMessage.Value;
                    else _dataRow.SetisOptedOutForMobileMessageNull();

                    if (String.IsNullOrEmpty(m_strPush_notification_device_id)) _dataRow.Setpush_notification_device_idNull();
                    else _dataRow.push_notification_device_id = strPush_notification_device_id;

                    if (iDeviceType.HasValue) _dataRow.Device_Type = iDeviceType.Value;
                    else _dataRow.SetDevice_TypeNull();
                }
                else
                {
                    if (String.IsNullOrEmpty(strEmail)) _dataRow.SetemailNull();
                    else _dataRow.email = strEmail;

                    if (String.IsNullOrEmpty(strPhone)) _dataRow.SetphoneNull();
                    else _dataRow.phone = strPhone;

                    if (String.IsNullOrEmpty(m_strUserName)) { if (!_dataRow.IsusernameNull()) _dataRow.SetusernameNull(); }
                    else if (_dataRow.IsusernameNull() ? true : _dataRow.username != m_strUserName) _dataRow.username = m_strUserName;

                    if (String.IsNullOrEmpty(strZip)) _dataRow.SetzipNull();
                    else _dataRow.zip = strZip;

                    if (dtAppDownLoadDate.HasValue) _dataRow.appDownLoadDate = dtAppDownLoadDate.Value;
                    else _dataRow.SetappDownLoadDateNull();

                    if (bIsRegistred.HasValue) _dataRow.isRegistred = bIsRegistred.Value;
                    else _dataRow.SetisRegistredNull();

                    if (bIsNew.HasValue) _dataRow.isNew = bIsNew.Value;
                    else _dataRow.SetisNewNull();

                    if (bIsRegistred_Shop.HasValue) _dataRow.isRegistred_Shop = bIsRegistred_Shop.Value;
                    else _dataRow.SetisRegistred_ShopNull();

                    if (String.IsNullOrEmpty(strPhone_Id)) _dataRow.Setphone_idNull();
                    else _dataRow.phone_id = strPhone_Id;

                    if (String.IsNullOrEmpty(strFirstName)) _dataRow.Setfirst_nameNull();
                    else _dataRow.first_name = strFirstName;

                    if (String.IsNullOrEmpty(strLastName)) _dataRow.Setlast_nameNull();
                    else _dataRow.last_name = strLastName;

                    if (String.IsNullOrEmpty(strAddress1)) _dataRow.Setaddress1Null();
                    else _dataRow.address1 = strAddress1;

                    if (String.IsNullOrEmpty(strAddress2)) _dataRow.Setaddress2Null();
                    else _dataRow.address2 = strAddress2;

                    if (String.IsNullOrEmpty(strCity)) _dataRow.SetcityNull();
                    else _dataRow.city = strCity;

                    if (String.IsNullOrEmpty(strState)) _dataRow.SetstateNull();
                    else _dataRow.state = strState;

                    if (bIsShow.HasValue) _dataRow.isShow = bIsShow.Value;
                    else _dataRow.SetisShowNull();

                    if (bIsShowEmailMarketing.HasValue) _dataRow.isShowEmailMarketing = bIsShowEmailMarketing.Value;
                    else _dataRow.SetisShowEmailMarketingNull();

                    if (bIsShowTextMarketing.HasValue) _dataRow.isShowTextMarketing = bIsShowTextMarketing.Value;
                    else _dataRow.SetisShowTextMarketingNull();

                    if (dtUpdatedEntryTime.HasValue) _dataRow.updatedEntryTime = dtUpdatedEntryTime.Value;
                    else _dataRow.SetupdatedEntryTimeNull();

                    if (String.IsNullOrEmpty(m_strPhone2)) { if (!_dataRow.Isphone2Null()) _dataRow.Setphone2Null(); }
                    else if (_dataRow.Isphone2Null() ? true : _dataRow.phone2 != m_strPhone2) _dataRow.phone2 = m_strPhone2;

                    if (bIsOptOutNotificationSent.HasValue) _dataRow.isOptOutNotificationSent = bIsOptOutNotificationSent.Value;
                    else _dataRow.SetisOptOutNotificationSentNull();

                    if (bIsOptedOutForMobileMessage.HasValue) _dataRow.isOptedOutForMobileMessage = bIsOptedOutForMobileMessage.Value;
                    else _dataRow.SetisOptedOutForMobileMessageNull();

                    if (String.IsNullOrEmpty(m_strPush_notification_device_id)) _dataRow.Setpush_notification_device_idNull();
                    else _dataRow.push_notification_device_id = strPush_notification_device_id;

                    if (iDeviceType.HasValue) _dataRow.Device_Type = iDeviceType.Value;
                    else _dataRow.SetDevice_TypeNull();

                    _thisTable.AddUserRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
            SummitDS.UserRow thisRow = _rowToSave as SummitDS.UserRow;
            if (thisRow != null)
            {
                this._ID = thisRow.user_id;
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


    }
}
