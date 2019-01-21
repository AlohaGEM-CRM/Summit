using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;

namespace SummitShopApp.BL
{
    public class BodyShopBL : BaseEditableItem
    {
        #region "Constructor"

        public BodyShopBL()
        {

        }

        public BodyShopBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        String m_strShopName;
        String m_strAddress1;
        String m_strAddress2;
        Nullable<double> m_fLatitude;
        Nullable<double> m_fLongitude;
        Nullable<Int32> m_iRating;
        String m_strCity;
        String m_strState;
        String m_strZip;
        String m_strPhone;
        String m_strFax;
        String m_strEmail;
        String m_strWebsite;
        String m_strBusinessLicence;
        String m_strEpsLicence;
        String m_strBarLicence;
        String m_strNetWorkName;
        String m_strCertificationVehicles;
        String m_strThirdPartyProviders;
        String m_strManager;
        String m_strSystemAdmin;
        String m_strPortalAdminPassword;
        String m_strTagLine;
        String m_strOwner;
        Nullable<Int32> m_iNoPremierShop;
        Nullable<Int32> m_iNoHelpSelection;
        Nullable<Boolean> m_bIsPremierShop;
        String m_strContent;
        String m_strImagePath;
        Nullable<Int32> m_iMessageCount;
        Nullable<Int32> m_iAvailableMessages;
        Nullable<DateTime> m_dtExpirationDate;

        #endregion "Members"

        #region "Accessors"

        public String strShopName
        {
            get { return this.m_strShopName; }
            set { this.m_strShopName = value; }
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

        public String strZip
        {
            get { return this.m_strZip; }
            set { this.m_strZip = value; }
        }

        public String strPhone
        {
            get { return this.m_strPhone; }
            set { this.m_strPhone = value; }
        }

        public String strFax
        {
            get { return this.m_strFax; }
            set { this.m_strFax = value; }
        }

        public String strEmail
        {
            get { return this.m_strEmail; }
            set { this.m_strEmail = value; }
        }

        public String strWebsite
        {
            get { return this.m_strWebsite; }
            set { this.m_strWebsite = value; }
        }

        public String strBusinessLicence
        {
            get { return this.m_strBusinessLicence; }
            set { this.m_strBusinessLicence = value; }
        }

        public String strEpsLicence
        {
            get { return this.m_strEpsLicence; }
            set { this.m_strEpsLicence = value; }
        }

        public String strBarLicence
        {
            get { return this.m_strBarLicence; }
            set { this.m_strBarLicence = value; }
        }

        public String strNetWorkName
        {
            get { return this.m_strNetWorkName; }
            set { this.m_strNetWorkName = value; }
        }

        public String strCertificationVehicles
        {
            get { return this.m_strCertificationVehicles; }
            set { this.m_strCertificationVehicles = value; }
        }

        public String strThirdPartyProviders
        {
            get { return this.m_strThirdPartyProviders; }
            set { this.m_strThirdPartyProviders = value; }
        }

        public String strManager
        {
            get { return this.m_strManager; }
            set { this.m_strManager = value; }
        }

        public String strSystemAdmin
        {
            get { return this.m_strSystemAdmin; }
            set { this.m_strSystemAdmin = value; }
        }

        public String strPortalAdminPassword
        {
            get { return this.m_strPortalAdminPassword; }
            set { this.m_strPortalAdminPassword = value; }
        }

        public String strTagLine
        {
            get { return this.m_strTagLine; }
            set { this.m_strTagLine = value; }
        }

        public String strOwner
        {
            get { return this.m_strOwner; }
            set { this.m_strOwner = value; }
        }

        public Nullable<Int32> iRating
        {
            get { return this.m_iRating; }
            set { this.m_iRating = value; }
        }

        public Nullable<double> fLatitude
        {
            get { return this.m_fLatitude; }
            set { this.m_fLatitude = value; }
        }

        public Nullable<double> fLongitude
        {
            get { return this.m_fLongitude; }
            set { this.m_fLongitude = value; }
        }

        public Nullable<Int32> iNoPremierShop
        {
            get { return this.m_iNoPremierShop; }
            set { this.m_iNoPremierShop = value; }
        }

        public Nullable<Int32> iNoHelpSelection
        {
            get { return this.m_iNoHelpSelection; }
            set { this.m_iNoHelpSelection = value; }
        }

        public Nullable<Boolean> bIsPremierShop
        {
            get { return this.m_bIsPremierShop; }
            set { this.m_bIsPremierShop = value; }
        }

        public String strContent
        {
            get { return this.m_strContent; }
            set { this.m_strContent = value; }
        }

        public String strImagePath
        {
            get { return this.m_strImagePath; }
            set { this.m_strImagePath = value; }
        }

        public Nullable<Int32> iMessageCount
        {
            get { return this.m_iMessageCount; }
            set { this.m_iMessageCount = value; }
        }

        public Nullable<Int32> iAvailableMessages
        {
            get { return this.m_iAvailableMessages; }
            set { this.m_iAvailableMessages = value; }
        }

        public Nullable<DateTime> dtExpirationDate
        {
            get { return this.m_dtExpirationDate; }
            set { this.m_dtExpirationDate = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }

        #endregion "Accessors"

        #region "Static Methods"

        private static BodyShopTableAdapter getAdapter()
        {
            return new BodyShopTableAdapter();
        }

        public static BodyShopBL getShopById(Int32 iShopId)
        {
            SummitDS.BodyShopDataTable thisTable = getAdapter().GetDataById(iShopId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }

            return null;
        }

        public static BodyShopBL getShopByUserId(Int32 iUserId)
        {
            SummitDS.BodyShopDataTable thisTable = getAdapter().getShopByUserId(iUserId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }

            return null;
        }

        /// <summary>
        /// Get Data By Shop Name
        /// </summary>
        /// <param name="strShopName">Shop Name</param>
        /// <returns>instance of body shop</returns>
        public static BodyShopBL getShopByName(String strShopName)
        {
            if (!String.IsNullOrEmpty(strShopName))
            {
                SummitDS.BodyShopDataTable thisTable = getAdapter().GetDataByShopName(strShopName);
                if (thisTable != null && thisTable.Rows.Count > 0)
                {
                    return BuildFromRow(thisTable.Rows[0]);
                }
                return null;
            }
            return null;
        }

        private static BodyShopBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new BodyShopBL(drRow);
            }
            return null;
        }

        private static List<BodyShopBL> BuildFromTable(DataTable dtTable)
        {
            List<BodyShopBL> _list = new List<BodyShopBL>();

            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    BodyShopBL _thisMember = new BodyShopBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }


        #endregion "Static Methods"

        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.BodyShopRow _thisRow = _dataRow as SummitDS.BodyShopRow;

            if (_thisRow != null)
            {
                this._ID = _thisRow.shop_id;
                this.m_strShopName = _thisRow.Isshop_nameNull() ? String.Empty : _thisRow.shop_name;
                this.m_strAddress1 = _thisRow.Isaddress1Null() ? String.Empty : _thisRow.address1;
                this.m_strAddress2 = _thisRow.Isaddress2Null() ? String.Empty : _thisRow.address2;
                this.m_strCity = _thisRow.IscityNull() ? String.Empty : _thisRow.city;
                this.m_strState = _thisRow.IsstateNull() ? String.Empty : _thisRow.state;
                this.m_strZip = _thisRow.IszipNull() ? String.Empty : _thisRow.zip;
                this.m_strPhone = _thisRow.IsphoneNull() ? String.Empty : _thisRow.phone;
                this.m_strFax = _thisRow.IsfaxNull() ? String.Empty : _thisRow.fax;
                this.m_strEmail = _thisRow.IsemailNull() ? String.Empty : _thisRow.email;
                this.m_strWebsite = _thisRow.IswebsiteNull() ? String.Empty : _thisRow.website;
                this.m_strBusinessLicence = _thisRow.Isbusiness_licenseNull() ? String.Empty : _thisRow.business_license;
                this.m_strEpsLicence = _thisRow.Isepa_licenseNull() ? String.Empty : _thisRow.epa_license;
                this.m_strBarLicence = _thisRow.Isbar_licenseNull() ? String.Empty : _thisRow.bar_license;
                this.m_strNetWorkName = _thisRow.Isnetwork_nameNull() ? String.Empty : _thisRow.network_name;
                this.m_strCertificationVehicles = _thisRow.Iscertification_vehiclesNull() ? String.Empty : _thisRow.certification_vehicles;
                this.m_strThirdPartyProviders = _thisRow.Isthird_party_providersNull() ? String.Empty : _thisRow.third_party_providers;
                this.m_iRating = _thisRow.IsratingsNull() ? (Nullable<Int32>)null : _thisRow.ratings;
                this.m_fLatitude = _thisRow.IslatitudeNull() ? (Nullable<double>)null : _thisRow.latitude;
                this.m_fLongitude = _thisRow.IslongitudeNull() ? (Nullable<double>)null : _thisRow.longitude;
                this.m_strManager = _thisRow.IsmanagerNull() ? String.Empty : _thisRow.manager;
                this.m_strSystemAdmin = _thisRow.Issystem_adminNull() ? String.Empty : _thisRow.system_admin;
                this.m_strPortalAdminPassword = _thisRow.Isportal_admin_passwordNull() ? String.Empty : _thisRow.portal_admin_password;
                this.m_strTagLine = _thisRow.Iscompany_tag_lineNull() ? String.Empty : _thisRow.company_tag_line;
                this.m_strOwner = _thisRow.IsownerNull() ? String.Empty : _thisRow.owner;
                this.m_iNoPremierShop = _thisRow.IsnoPremierShopNull() ? (Nullable<Int32>)null : _thisRow.noPremierShop;
                this.m_iNoHelpSelection = _thisRow.IsnoHelpSelectionNull() ? (Nullable<Int32>)null : _thisRow.noHelpSelection;
                this.m_bIsPremierShop = _thisRow.IsisPremierShopNull() ? (Nullable<Boolean>)null : _thisRow.isPremierShop;
                this.m_strContent = _thisRow.IscontentNull() ? String.Empty : _thisRow.content;
                this.m_strImagePath = _thisRow.Isimage_pathNull() ? String.Empty : _thisRow.image_path;
                this.m_iMessageCount = _thisRow.IsmessageCountNull() ? (Nullable<Int32>)null : _thisRow.messageCount;
                this.m_iAvailableMessages = _thisRow.IsavailableMessagesNull() ? (Nullable<Int32>)null : _thisRow.availableMessages;
                this.m_dtExpirationDate = _thisRow.IsexpirationDateNull() ? (Nullable<DateTime>)null : _thisRow.expirationDate;

                //  this.m_dt_ts = _thisRow.Is_tsNull() ? (Nullable<DateTime>) null : _thisRow._ts ;                                
                _rowToSave = _thisRow;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.BodyShopDataTable _thisTable = new SummitDS.BodyShopDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewBodyShopRow();
            SummitDS.BodyShopRow _dataRow = _rowToSave as SummitDS.BodyShopRow;

            if (_dataRow != null)
            {
                if (IsExisting())
                {
                    if (String.IsNullOrEmpty(m_strShopName)) { if (!_dataRow.Isshop_nameNull()) _dataRow.Setshop_nameNull(); }
                    else if (_dataRow.Isshop_nameNull() ? true : _dataRow.shop_name != m_strShopName) _dataRow.shop_name = m_strShopName;

                    if (String.IsNullOrEmpty(m_strAddress1)) { if (!_dataRow.Isaddress1Null()) _dataRow.Setaddress1Null(); }
                    else if (_dataRow.Isaddress1Null() ? true : _dataRow.address1 != m_strAddress1) _dataRow.address1 = m_strAddress1;

                    if (String.IsNullOrEmpty(m_strAddress2)) { if (!_dataRow.Isaddress2Null()) _dataRow.Setaddress2Null(); }
                    else if (_dataRow.Isaddress2Null() ? true : _dataRow.address2 != m_strAddress2) _dataRow.address2 = m_strAddress2;

                    if (String.IsNullOrEmpty(m_strCity)) { if (!_dataRow.IscityNull()) _dataRow.SetcityNull(); }
                    else if (_dataRow.IscityNull() ? true : _dataRow.city != m_strCity) _dataRow.city = m_strCity;

                    if (String.IsNullOrEmpty(m_strState)) { if (!_dataRow.IsstateNull()) _dataRow.SetstateNull(); }
                    else if (_dataRow.IsstateNull() ? true : _dataRow.state != m_strState) _dataRow.state = m_strState;

                    if (String.IsNullOrEmpty(m_strZip)) { if (!_dataRow.IszipNull()) _dataRow.SetzipNull(); }
                    else if (_dataRow.IszipNull() ? true : _dataRow.zip != m_strZip) _dataRow.zip = m_strZip;

                    if (String.IsNullOrEmpty(m_strPhone)) { if (!_dataRow.IsphoneNull()) _dataRow.SetphoneNull(); }
                    else if (_dataRow.IsphoneNull() ? true : _dataRow.phone != m_strPhone) _dataRow.phone = m_strPhone;

                    if (String.IsNullOrEmpty(m_strFax)) { if (!_dataRow.IsfaxNull()) _dataRow.SetfaxNull(); }
                    else if (_dataRow.IsfaxNull() ? true : _dataRow.fax != m_strFax) _dataRow.fax = m_strFax;

                    if (String.IsNullOrEmpty(m_strEmail)) { if (!_dataRow.IsemailNull()) _dataRow.SetemailNull(); }
                    else if (_dataRow.IsemailNull() ? true : _dataRow.email != m_strEmail) _dataRow.email = m_strEmail;

                    if (String.IsNullOrEmpty(m_strWebsite)) { if (!_dataRow.IswebsiteNull()) _dataRow.SetwebsiteNull(); }
                    else if (_dataRow.IswebsiteNull() ? true : _dataRow.website != m_strWebsite) _dataRow.website = m_strWebsite;

                    if (String.IsNullOrEmpty(m_strBusinessLicence)) { if (!_dataRow.Isbusiness_licenseNull()) _dataRow.Setbusiness_licenseNull(); }
                    else if (_dataRow.Isbusiness_licenseNull() ? true : _dataRow.business_license != m_strBusinessLicence) _dataRow.business_license = m_strBusinessLicence;

                    if (String.IsNullOrEmpty(m_strEpsLicence)) { if (!_dataRow.Isepa_licenseNull()) _dataRow.Setepa_licenseNull(); }
                    else if (_dataRow.Isepa_licenseNull() ? true : _dataRow.epa_license != m_strEpsLicence) _dataRow.epa_license = m_strEpsLicence;

                    if (String.IsNullOrEmpty(m_strBarLicence)) { if (!_dataRow.Isbar_licenseNull()) _dataRow.Setbar_licenseNull(); }
                    else if (_dataRow.Isbar_licenseNull() ? true : _dataRow.bar_license != m_strBarLicence) _dataRow.bar_license = m_strBarLicence;

                    if (String.IsNullOrEmpty(m_strNetWorkName)) { if (!_dataRow.Isnetwork_nameNull()) _dataRow.Setnetwork_nameNull(); }
                    else if (_dataRow.Isnetwork_nameNull() ? true : _dataRow.network_name != m_strNetWorkName) _dataRow.network_name = m_strNetWorkName;

                    if (String.IsNullOrEmpty(m_strCertificationVehicles)) { if (!_dataRow.Iscertification_vehiclesNull()) _dataRow.Setcertification_vehiclesNull(); }
                    else if (_dataRow.Iscertification_vehiclesNull() ? true : _dataRow.certification_vehicles != m_strCertificationVehicles) _dataRow.certification_vehicles = m_strCertificationVehicles;

                    if (String.IsNullOrEmpty(m_strThirdPartyProviders)) { if (!_dataRow.Isthird_party_providersNull()) _dataRow.Setthird_party_providersNull(); }
                    else if (_dataRow.Isthird_party_providersNull() ? true : _dataRow.third_party_providers != m_strThirdPartyProviders) _dataRow.third_party_providers = m_strThirdPartyProviders;

                    if (String.IsNullOrEmpty(m_strManager)) { if (!_dataRow.IsmanagerNull()) _dataRow.SetmanagerNull(); }
                    else if (_dataRow.IsmanagerNull() ? true : _dataRow.manager != m_strManager) _dataRow.manager = m_strManager;

                    if (String.IsNullOrEmpty(m_strSystemAdmin)) { if (!_dataRow.Issystem_adminNull()) _dataRow.Setsystem_adminNull(); }
                    else if (_dataRow.Issystem_adminNull() ? true : _dataRow.system_admin != m_strSystemAdmin) _dataRow.system_admin = m_strSystemAdmin;

                    if (String.IsNullOrEmpty(m_strPortalAdminPassword)) { if (!_dataRow.Isportal_admin_passwordNull()) _dataRow.Setportal_admin_passwordNull(); }
                    else if (_dataRow.Isportal_admin_passwordNull() ? true : _dataRow.portal_admin_password != m_strPortalAdminPassword) _dataRow.portal_admin_password = m_strPortalAdminPassword;

                    if (String.IsNullOrEmpty(m_strTagLine)) { if (!_dataRow.Iscompany_tag_lineNull()) _dataRow.Setcompany_tag_lineNull(); }
                    else if (_dataRow.Iscompany_tag_lineNull() ? true : _dataRow.company_tag_line != m_strTagLine) _dataRow.company_tag_line = m_strTagLine;

                    if (String.IsNullOrEmpty(m_strOwner)) { if (!_dataRow.IsownerNull()) _dataRow.SetownerNull(); }
                    else if (_dataRow.IsownerNull() ? true : _dataRow.owner != m_strOwner) _dataRow.owner = m_strOwner;

                    if (iRating.HasValue) _dataRow.ratings = iRating.Value;
                    else _dataRow.SetratingsNull();

                    if (fLatitude.HasValue) _dataRow.latitude = fLatitude.Value;
                    else _dataRow.SetlatitudeNull();

                    if (fLongitude.HasValue) _dataRow.longitude = fLongitude.Value;
                    else _dataRow.SetlongitudeNull();

                    if (iNoHelpSelection.HasValue) _dataRow.noHelpSelection = iNoHelpSelection.Value;
                    else _dataRow.SetnoHelpSelectionNull();

                    if (iNoPremierShop.HasValue) _dataRow.noPremierShop = iNoPremierShop.Value;
                    else _dataRow.SetnoPremierShopNull();

                    if (bIsPremierShop.HasValue) _dataRow.isPremierShop = bIsPremierShop.Value;
                    else _dataRow.SetisPremierShopNull();

                    if (String.IsNullOrEmpty(m_strContent)) { if (!_dataRow.IscontentNull()) _dataRow.SetcontentNull(); }
                    else if (_dataRow.IscontentNull() ? true : _dataRow.content != m_strContent) _dataRow.content = m_strContent;

                    if (String.IsNullOrEmpty(m_strImagePath)) { if (!_dataRow.Isimage_pathNull()) _dataRow.Setimage_pathNull(); }
                    else if (_dataRow.Isimage_pathNull() ? true : _dataRow.image_path != m_strImagePath) _dataRow.image_path = m_strImagePath;

                    if (iMessageCount.HasValue) _dataRow.messageCount = iMessageCount.Value;
                    else _dataRow.SetmessageCountNull();

                    if (iAvailableMessages.HasValue) _dataRow.availableMessages = iAvailableMessages.Value;
                    else _dataRow.SetavailableMessagesNull();

                    if (dtExpirationDate.HasValue) _dataRow.expirationDate = dtExpirationDate.Value;
                    else _dataRow.SetexpirationDateNull();

                }
                else
                {
                    if (String.IsNullOrEmpty(m_strShopName)) { if (!_dataRow.Isshop_nameNull()) _dataRow.Setshop_nameNull(); }
                    else if (_dataRow.Isshop_nameNull() ? true : _dataRow.shop_name != m_strShopName) _dataRow.shop_name = m_strShopName;

                    if (String.IsNullOrEmpty(m_strAddress1)) { if (!_dataRow.Isaddress1Null()) _dataRow.Setaddress1Null(); }
                    else if (_dataRow.Isaddress1Null() ? true : _dataRow.address1 != m_strAddress1) _dataRow.address1 = m_strAddress1;

                    if (String.IsNullOrEmpty(m_strAddress2)) { if (!_dataRow.Isaddress2Null()) _dataRow.Setaddress2Null(); }
                    else if (_dataRow.Isaddress2Null() ? true : _dataRow.address2 != m_strAddress2) _dataRow.address2 = m_strAddress2;

                    if (String.IsNullOrEmpty(m_strCity)) { if (!_dataRow.IscityNull()) _dataRow.SetcityNull(); }
                    else if (_dataRow.IscityNull() ? true : _dataRow.city != m_strCity) _dataRow.city = m_strCity;

                    if (String.IsNullOrEmpty(m_strState)) { if (!_dataRow.IsstateNull()) _dataRow.SetstateNull(); }
                    else if (_dataRow.IsstateNull() ? true : _dataRow.state != m_strState) _dataRow.state = m_strState;

                    if (String.IsNullOrEmpty(m_strZip)) { if (!_dataRow.IszipNull()) _dataRow.SetzipNull(); }
                    else if (_dataRow.IszipNull() ? true : _dataRow.zip != m_strZip) _dataRow.zip = m_strZip;

                    if (String.IsNullOrEmpty(m_strPhone)) { if (!_dataRow.IsphoneNull()) _dataRow.SetphoneNull(); }
                    else if (_dataRow.IsphoneNull() ? true : _dataRow.phone != m_strPhone) _dataRow.phone = m_strPhone;

                    if (String.IsNullOrEmpty(m_strFax)) { if (!_dataRow.IsfaxNull()) _dataRow.SetfaxNull(); }
                    else if (_dataRow.IsfaxNull() ? true : _dataRow.fax != m_strFax) _dataRow.fax = m_strFax;

                    if (String.IsNullOrEmpty(m_strEmail)) { if (!_dataRow.IsemailNull()) _dataRow.SetemailNull(); }
                    else if (_dataRow.IsemailNull() ? true : _dataRow.email != m_strEmail) _dataRow.email = m_strEmail;

                    if (String.IsNullOrEmpty(m_strWebsite)) { if (!_dataRow.IswebsiteNull()) _dataRow.SetwebsiteNull(); }
                    else if (_dataRow.IswebsiteNull() ? true : _dataRow.website != m_strWebsite) _dataRow.website = m_strWebsite;

                    if (String.IsNullOrEmpty(m_strBusinessLicence)) { if (!_dataRow.Isbusiness_licenseNull()) _dataRow.Setbusiness_licenseNull(); }
                    else if (_dataRow.Isbusiness_licenseNull() ? true : _dataRow.business_license != m_strBusinessLicence) _dataRow.business_license = m_strBusinessLicence;

                    if (String.IsNullOrEmpty(m_strEpsLicence)) { if (!_dataRow.Isepa_licenseNull()) _dataRow.Setepa_licenseNull(); }
                    else if (_dataRow.Isepa_licenseNull() ? true : _dataRow.epa_license != m_strEpsLicence) _dataRow.epa_license = m_strEpsLicence;

                    if (String.IsNullOrEmpty(m_strBarLicence)) { if (!_dataRow.Isbar_licenseNull()) _dataRow.Setbar_licenseNull(); }
                    else if (_dataRow.Isbar_licenseNull() ? true : _dataRow.bar_license != m_strBarLicence) _dataRow.bar_license = m_strBarLicence;

                    if (String.IsNullOrEmpty(m_strNetWorkName)) { if (!_dataRow.Isnetwork_nameNull()) _dataRow.Setnetwork_nameNull(); }
                    else if (_dataRow.Isnetwork_nameNull() ? true : _dataRow.network_name != m_strNetWorkName) _dataRow.network_name = m_strNetWorkName;

                    if (String.IsNullOrEmpty(m_strCertificationVehicles)) { if (!_dataRow.Iscertification_vehiclesNull()) _dataRow.Setcertification_vehiclesNull(); }
                    else if (_dataRow.Iscertification_vehiclesNull() ? true : _dataRow.certification_vehicles != m_strCertificationVehicles) _dataRow.certification_vehicles = m_strCertificationVehicles;

                    if (String.IsNullOrEmpty(m_strThirdPartyProviders)) { if (!_dataRow.Isthird_party_providersNull()) _dataRow.Setthird_party_providersNull(); }
                    else if (_dataRow.Isthird_party_providersNull() ? true : _dataRow.third_party_providers != m_strThirdPartyProviders) _dataRow.third_party_providers = m_strThirdPartyProviders;

                    if (String.IsNullOrEmpty(m_strManager)) { if (!_dataRow.IsmanagerNull()) _dataRow.SetmanagerNull(); }
                    else if (_dataRow.IsmanagerNull() ? true : _dataRow.manager != m_strManager) _dataRow.manager = m_strManager;

                    if (String.IsNullOrEmpty(m_strSystemAdmin)) { if (!_dataRow.Issystem_adminNull()) _dataRow.Setsystem_adminNull(); }
                    else if (_dataRow.Issystem_adminNull() ? true : _dataRow.system_admin != m_strSystemAdmin) _dataRow.system_admin = m_strSystemAdmin;

                    if (String.IsNullOrEmpty(m_strPortalAdminPassword)) { if (!_dataRow.Isportal_admin_passwordNull()) _dataRow.Setportal_admin_passwordNull(); }
                    else if (_dataRow.Isportal_admin_passwordNull() ? true : _dataRow.portal_admin_password != m_strPortalAdminPassword) _dataRow.portal_admin_password = m_strPortalAdminPassword;

                    if (String.IsNullOrEmpty(m_strTagLine)) { if (!_dataRow.Iscompany_tag_lineNull()) _dataRow.Setcompany_tag_lineNull(); }
                    else if (_dataRow.Iscompany_tag_lineNull() ? true : _dataRow.company_tag_line != m_strTagLine) _dataRow.company_tag_line = m_strTagLine;

                    if (String.IsNullOrEmpty(m_strOwner)) { if (!_dataRow.IsownerNull()) _dataRow.SetownerNull(); }
                    else if (_dataRow.IsownerNull() ? true : _dataRow.owner != m_strOwner) _dataRow.owner = m_strOwner;

                    if (iRating.HasValue) _dataRow.ratings = iRating.Value;
                    else _dataRow.SetratingsNull();

                    if (fLatitude.HasValue) _dataRow.latitude = fLatitude.Value;
                    else _dataRow.SetlatitudeNull();

                    if (fLongitude.HasValue) _dataRow.longitude = fLongitude.Value;
                    else _dataRow.SetlongitudeNull();

                    if (iNoHelpSelection.HasValue) _dataRow.noHelpSelection = iNoHelpSelection.Value;
                    else _dataRow.SetnoHelpSelectionNull();

                    if (iNoPremierShop.HasValue) _dataRow.noPremierShop = iNoPremierShop.Value;
                    else _dataRow.SetnoPremierShopNull();

                    if (bIsPremierShop.HasValue) _dataRow.isPremierShop = bIsPremierShop.Value;
                    else _dataRow.SetisPremierShopNull();

                    if (String.IsNullOrEmpty(m_strContent)) { if (!_dataRow.IscontentNull()) _dataRow.SetcontentNull(); }
                    else if (_dataRow.IscontentNull() ? true : _dataRow.content != m_strContent) _dataRow.content = m_strContent;

                    if (String.IsNullOrEmpty(m_strImagePath)) { if (!_dataRow.Isimage_pathNull()) _dataRow.Setimage_pathNull(); }
                    else if (_dataRow.Isimage_pathNull() ? true : _dataRow.image_path != m_strImagePath) _dataRow.image_path = m_strImagePath;

                    if (iMessageCount.HasValue) _dataRow.messageCount = iMessageCount.Value;
                    else _dataRow.SetmessageCountNull();

                    if (iAvailableMessages.HasValue) _dataRow.availableMessages = iAvailableMessages.Value;
                    else _dataRow.SetavailableMessagesNull();

                    if (dtExpirationDate.HasValue) _dataRow.expirationDate = dtExpirationDate.Value;
                    else _dataRow.SetexpirationDateNull();

                    _thisTable.AddBodyShopRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
            SummitDS.BodyShopRow thisRow = _rowToSave as SummitDS.BodyShopRow;
            if (thisRow != null)
            {
                this._ID = thisRow.shop_id;
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
