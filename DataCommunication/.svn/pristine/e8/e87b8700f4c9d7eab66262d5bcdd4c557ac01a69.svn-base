using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;
using System.Data;

namespace SummitShopApp.BL
{
    public class MyCustomerBL : BaseEditableItem
    {
        #region "Constructor"

        public MyCustomerBL()
        {

        }
        public MyCustomerBL(DataRow _drRow)
        {

            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        Nullable<Int32> m_iUserId;
        public Nullable<Int32> iUserId
        {
            get { return m_iUserId; }
            set { m_iUserId = value; }
        }

        Int32 m_iShopId;
        public Int32 iShopId
        {
            get { return m_iShopId; }
            set { m_iShopId = value; }
        }

        Nullable<Int32> m_iUserVehicleStatusId;
        public Nullable<Int32> iUserVehicleStatusId
        {
            get { return m_iUserVehicleStatusId; }
            set { m_iUserVehicleStatusId = value; }
        }

        Nullable<Int32> m_iVehicleId;
        public Nullable<Int32> iVehicleId
        {
            get { return m_iVehicleId; }
            set { m_iVehicleId = value; }
        }

        String m_strUserName;
        public String strUserName
        {
            get { return m_strUserName; }
            set { m_strUserName = value; }
        }

        String m_strFirstName;
        public String strFirstName
        {
            get { return m_strFirstName; }
            set { m_strFirstName = value; }
        }

        String m_strLastName;
        public String strLastName
        {
            get { return m_strLastName; }
            set { m_strLastName = value; }
        }

        String m_strPhone;
        public String strPhone
        {
            get { return m_strPhone; }
            set { m_strPhone = value; }
        }

        String m_strModel;
        public String strModel
        {
            get { return m_strModel; }
            set { m_strModel = value; }
        }

        String m_strMake;
        public String strMake
        {
            get { return m_strMake; }
            set { m_strMake = value; }
        }

        String m_strYear;
        public String strYear
        {
            get { return m_strYear; }
            set { m_strYear = value; }
        }

        String m_strEmail;
        public String strEmail
        {
            get { return m_strEmail; }
            set { m_strEmail = value; }
        }

        String m_strShopName;
        public String strShopName
        {
            get { return m_strShopName; }
            set { m_strShopName = value; }
        }

        String m_strClaimNumber;
        public String strClaimNumber
        {
            get { return m_strClaimNumber; }
            set { m_strClaimNumber = value; }
        }

        String m_strROIdentifier;
        public String strROIdentifier
        {
            get { return m_strROIdentifier; }
            set { m_strROIdentifier = value; }
        }

        String companyName;
        public String CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        String zip;
        public String Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        String m_strAgentName;
        public String strAgentName
        {
            get { return m_strAgentName; }
            set { m_strAgentName = value; }
        }

        String m_strEstimateFileIdentifier;
        public String strEstimateFileIdentifier
        {
            get { return m_strEstimateFileIdentifier; }
            set { m_strEstimateFileIdentifier = value; }
        }

        String m_strEstimatorName;
        public String strEstimatorName
        {
            get { return m_strEstimatorName; }
            set { m_strEstimatorName = value; }
        }

        String m_strNetTotalAmount;
        public String strNetTotalAmount
        {
            get { return m_strNetTotalAmount; }
            set { m_strNetTotalAmount = value; }
        }


        Nullable<DateTime> m_dtInDate;
        public Nullable<DateTime> dtInDate
        {
            get { return m_dtInDate; }
            set { m_dtInDate = value; }
        }

        Nullable<DateTime> m_dtOutDate;
        public Nullable<DateTime> dtOutDate
        {
            get { return m_dtOutDate; }
            set { m_dtOutDate = value; }
        }

        Nullable<DateTime> m_dtUpdatedDate;
        public Nullable<DateTime> dtUpdatedDate
        {
            get { return m_dtUpdatedDate; }
            set { m_dtUpdatedDate = value; }
        }

        Nullable<DateTime> m_dtCreatedDate;
        public Nullable<DateTime> dtCreatedDate
        {
            get { return m_dtCreatedDate; }
            set { m_dtCreatedDate = value; }
        }

        Nullable<DateTime> m_dtDeliveryDate;
        public Nullable<DateTime> dtDeliveryDate
        {
            get { return m_dtDeliveryDate; }
            set { m_dtDeliveryDate = value; }
        }

        Nullable<Int32> m_iVehicleStatus;
        public Nullable<Int32> iVehicleStatus
        {
            get { return m_iVehicleStatus; }
            set { m_iVehicleStatus = value; }
        }

        Nullable<Int32> m_iContactMethod;
        public Nullable<Int32> iContactMethod
        {
            get { return m_iContactMethod; }
            set { m_iContactMethod = value; }
        }


        String m_strPushNotificationdeviceId;
        public String strPushNotificationDeviceId
        {
            get { return m_strPushNotificationdeviceId; }
            set { m_strPushNotificationdeviceId = value; }
        }

        String m_strStatusOfVehicle;
        public String strStatusOfVehicle
        {
            get { return m_strStatusOfVehicle; }
            set { m_strStatusOfVehicle = value; }
        }
        #endregion "Members"

        #region "overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.View_MyCustomerRow row = _dataRow as SummitDS.View_MyCustomerRow;

            if (row != null)
            {
                this._ID = row.user_id;
                iUserId = row.user_id;
                iShopId = row.shop_id;
                strUserName = row.IsusernameNull() ? String.Empty : row.username;
                this.Zip = row.IszipNull() ? String.Empty : row.zip;
                strFirstName = row.Isfirst_nameNull() ? String.Empty : row.first_name;
                strLastName = row.Islast_nameNull() ? String.Empty : row.last_name;
                strPhone = row.IsphoneNull() ? String.Empty : row.phone;
                strModel = row.IsmodelNull() ? String.Empty : row.model;
                strMake = row.IsmakeNull() ? String.Empty : row.make;
                strYear = row.IsyearNull() ? String.Empty : row.year;
                strEmail = row.IsemailNull() ? String.Empty : row.email;
                iVehicleId = row.Isvehicle_idNull() ? (Nullable<Int32>)null : row.vehicle_id;
                dtInDate = row.IsDateInNull() ? (Nullable<DateTime>)null : row.DateIn;
                dtOutDate = row.IsDateOutNull() ? (Nullable<DateTime>)null : row.DateOut;
                iVehicleStatus = row.IsVehicleStatusNull() ? (Nullable<Int32>)null : row.VehicleStatus;
                iContactMethod = row.IscontactMethodNull() ? (Nullable<Int32>)null : row.contactMethod;
                strShopName = row.Isshop_nameNull() ? String.Empty : row.shop_name;
                strClaimNumber = row.Isclaim_numberNull() ? String.Empty : row.claim_number;
                strROIdentifier = row.Isrepair_order_identifierNull() ? String.Empty : row.repair_order_identifier;
                companyName = row.Iscompany_nameNull() ? String.Empty : row.company_name;
                strAgentName = row.Isagent_nameNull() ? String.Empty : row.agent_name;
                strEstimatorName = row.Isestimate_file_identifierNull() ? String.Empty : row.estimate_file_identifier;
                strNetTotalAmount = row.Isnet_total_amountNull() ? String.Empty : row.net_total_amount;
                dtUpdatedDate = row.IsupdatedEntryTimeNull() ? (Nullable<DateTime>)null : row.updatedEntryTime;
                strPushNotificationDeviceId = row.Ispush_notification_device_idNull() ? String.Empty : row.push_notification_device_id;
                dtCreatedDate = row.IscreateddateNull() ? (Nullable<DateTime>)null : row.createddate;
                dtDeliveryDate = row.IsDeliveryDateNull() ? (Nullable<DateTime>)null : row.DeliveryDate;
                strStatusOfVehicle = row.IsStatusNull() ? String.Empty : row.Status;
                strEstimateFileIdentifier = row.Isestimate_file_identifierNull() ? String.Empty : row.estimate_file_identifier;
            }
        }

        protected override void SaveToRow()
        {
        }

        protected override void SetID()
        {
            SummitDS.View_MyCustomerRow thisRow = _rowToSave as SummitDS.View_MyCustomerRow;
            if (thisRow != null)
            {
                this._ID = thisRow.user_id;
            }
        }

        protected override void Update()
        {
        }

        protected override void DeleteRecord()
        {
        }



        #endregion
        #region "Static Methods"

        private static View_MyCustomerTableAdapter getAdapter()
        {
            return new View_MyCustomerTableAdapter();
        }

        public static List<MyCustomerBL> getCustomersList(int shopId)
        {
            SummitDS.View_MyCustomerDataTable thisTable = getAdapter().GetDataByShopId(shopId);
            List<MyCustomerBL> lstCustomerList = null;

            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                lstCustomerList = BuildFromTable(thisTable);
            }
            return lstCustomerList;
        }

        public static MyCustomerBL getDataByUserId(Int32 UserId)
        {
            SummitDS.View_MyCustomerDataTable thisTable = getAdapter().GetDataByUserId(UserId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        public static List<MyCustomerBL> getDataByShopIDandMobileList(Int32 iShopID, string strPhone)
        {
            SummitDS.View_MyCustomerDataTable thisTable = getAdapter().GetDataByShopIDNPhone(iShopID, strPhone);
            List<MyCustomerBL> lstCustomerList = null;

            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                lstCustomerList = BuildFromTable(thisTable);
            }
            return lstCustomerList;
        }

        public static MyCustomerBL getDataByShopIdNPhone(Int32 ShopID, string strPhone)
        {
            SummitDS.View_MyCustomerDataTable thisTable = getAdapter().GetDataByShopIDNPhone(ShopID, strPhone);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        private static MyCustomerBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new MyCustomerBL(drRow);
            }
            return null;
        }
        private static List<MyCustomerBL> BuildFromTable(DataTable dtTable)
        {
            List<MyCustomerBL> list = new List<MyCustomerBL>();
            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    MyCustomerBL thisMember = new MyCustomerBL(dr);
                    list.Add(thisMember);
                }
            }
            return list;
        }

        #endregion
        #region "IComparable"
        public int CompareTo(MyCustomerBL au2, String comparisonType)
        {
            String baseComparisonType = comparisonType;
            Int32 compareResult = 0;
            Int32 descFlag = 1; //-1 for descending, + 1 for ascending, multiply by compare result


            String name = String.Empty;
            String au2Name = String.Empty;

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
                case "PhoneASC":
                    descFlag = 1;
                    compareResult = strPhone.CompareTo(au2.strPhone);
                    break;

                case "PhoneDESC":
                    descFlag = -1;
                    compareResult = strPhone.CompareTo(au2.strPhone);
                    break;

                case "NameASC":
                    descFlag = 1;
                    compareResult = strUserName.CompareTo(au2.strUserName);
                    break;

                case "NameDESC":
                    descFlag = -1;
                    compareResult = strUserName.CompareTo(au2.strUserName);
                    break;

                case "DateInASC":
                    descFlag = 1;
                    if (null != dtInDate)
                        compareResult = dtInDate.Value.CompareTo(au2.dtInDate);
                    break;

                case "DateInDESC":
                    descFlag = -1;
                    if (null != dtInDate)
                        compareResult = dtInDate.Value.CompareTo(au2.dtInDate);
                    break;

                case "DateOutASC":
                    descFlag = 1;
                    if (null != dtOutDate)
                        compareResult = dtOutDate.Value.CompareTo(au2.dtOutDate);

                    break;

                case "DateOutDESC":
                    descFlag = -1;
                    if (null != dtOutDate)
                        compareResult = dtOutDate.Value.CompareTo(au2.dtOutDate);
                    break;

                case "EmailASC":
                    descFlag = 1;
                    compareResult = strEmail.CompareTo(au2.strEmail);
                    break;

                case "EmailDESC":
                    descFlag = -1;
                    compareResult = strEmail.CompareTo(au2.strEmail);
                    break;

                case "UpdatedDateASC":
                    descFlag = 1;
                    if (null != dtUpdatedDate)
                        compareResult = dtUpdatedDate.Value.CompareTo(au2.dtUpdatedDate);
                    break;

                case "UpdatedDateDESC":
                    descFlag = -1;
                    if (null != dtUpdatedDate)
                        compareResult = dtUpdatedDate.Value.CompareTo(au2.dtUpdatedDate);
                    break;

                case "DateASC":
                    descFlag = 1;
                    if (null != dtUpdatedDate)
                        compareResult = dtUpdatedDate.Value.CompareTo(au2.dtUpdatedDate);
                    break;

                case "DateDESC":
                    descFlag = -1;
                    if (null != dtUpdatedDate)
                        compareResult = dtUpdatedDate.Value.CompareTo(au2.dtUpdatedDate);
                    break;

                case "NotificationASC":
                    descFlag = 1;
                    compareResult = String.IsNullOrEmpty(strPushNotificationDeviceId).CompareTo(String.IsNullOrEmpty(au2.strPushNotificationDeviceId));
                    break;

                case "NotificationDESC":
                    descFlag = -1;
                    compareResult = String.IsNullOrEmpty(strPushNotificationDeviceId).CompareTo(String.IsNullOrEmpty(au2.strPushNotificationDeviceId));
                    break;

                case "Company NameASC":
                    descFlag = 1;
                    compareResult = companyName.CompareTo(au2.companyName);
                    break;

                case "Company NameDESC":
                    descFlag = -1;
                    compareResult = companyName.CompareTo(au2.companyName);
                    break;

                case "Agent NameASC":
                    descFlag = 1;
                    compareResult = strAgentName.CompareTo(au2.strAgentName);
                    break;

                case "Agent NameDESC":
                    descFlag = -1;
                    compareResult = strAgentName.CompareTo(au2.strAgentName);
                    break;

                case "Estimator NameASC":
                    descFlag = 1;
                    compareResult = strEstimatorName.CompareTo(au2.strEstimatorName);
                    break;

                case "Estimator NameDESC":
                    descFlag = -1;
                    compareResult = strEstimatorName.CompareTo(au2.strEstimatorName);
                    break;
                case "LastNameASC":
                    descFlag = 1;
                    compareResult = strLastName.CompareTo(au2.strLastName);
                    break;
                case "LastNameDESC":
                    descFlag = -1;
                    compareResult = strLastName.CompareTo(au2.strLastName);
                    break;
                case "UserNameASC":
                    descFlag = 1;
                    compareResult = strUserName.CompareTo(au2.strUserName);
                    break;
                case "UserNameDESC":
                    descFlag = -1;
                    compareResult = strUserName.CompareTo(au2.strUserName);
                    break;
                case "StatusASC":
                    descFlag = 1;
                    if (null != strStatusOfVehicle && null != au2.strStatusOfVehicle)
                        compareResult = strStatusOfVehicle.CompareTo(au2.strStatusOfVehicle);
                    break;
                case "StatusDESC":
                    descFlag = -1;
                    if (null != strStatusOfVehicle && null != au2.strStatusOfVehicle)
                        compareResult = strStatusOfVehicle.CompareTo(au2.strStatusOfVehicle);
                    break;
                case "DeliveryDateASC":
                    descFlag = 1;
                    if (null != dtDeliveryDate)
                        compareResult = dtDeliveryDate.Value.CompareTo(au2.dtDeliveryDate);
                    break;

                case "DeliveryDateDESC":
                    descFlag = -1;
                    if (null != dtDeliveryDate)
                        compareResult = dtDeliveryDate.Value.CompareTo(au2.dtDeliveryDate);
                    break;

                case "ShopNameASC":
                    descFlag = 1;
                    if (null != strShopName && null != au2.strShopName)
                        compareResult = strShopName.CompareTo(au2.strShopName);
                    break;

                case "ShopNameDESC":
                    descFlag = -1;
                    if (null != strShopName && null != au2.strShopName)
                        compareResult = strShopName.CompareTo(au2.strShopName);
                    break;

                default:
                    descFlag = 1;
                    compareResult = strUserName.CompareTo(au2.strUserName);
                    break;

            }
            return compareResult * descFlag; //desc flag of -1 returns negative result for descending sort
        }
        #endregion
    }


    public class MyCustomerComparer : IComparer<MyCustomerBL>
    {
        private String comparisonType;

        public String ComparisonType
        {
            get { return comparisonType; }
            set { comparisonType = value; }
        }

        public int Compare(MyCustomerBL o1, MyCustomerBL o2)
        {
            return o1.CompareTo(o2, comparisonType);
        }
    }

    /// <summary>
    /// For Customers Activity like Email,SMS,DigitalDeal,AppDownload,PreferedShop,RoadEmergency/Accident,Notes,Review Rating
    /// </summary>
    //public class CustomerActivity
    //{
    //    //0 for No Record, 1 for Old Record, 2 for New Record
    //    int _Email = 0, _SMS = 0, _DDeal = 0, _RevRating = 0, _AppDownload = 0, _PreferedShop = 0, _RoadEmergency = 0, _Notes = 0;
    //    public CustomerActivity()
    //    {

    //    }

    //    public int Email{get;set;}
    //    public int SMS{get;set;}
    //    public int DDeal { get; set; }
    //    public int RevRating { get; set; }
    //    public int AppDownload { get; set; }
    //    public int PreferedShop { get; set; }
    //    public int RoadEmergency { get; set; }
    //    public int Notes { get; set; }

    //    public CustomerActivity GetDataUserId(int UserId)
    //    {

    //        return object;
    //    }
    //}
}

