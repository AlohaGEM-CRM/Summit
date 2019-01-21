using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;
using System.Data;

namespace SummitShopApp.BL
{
    public class MarketingCenterBL : BaseListItem
    {
        #region "Constructor"

        public MarketingCenterBL()
        {

        }
        public MarketingCenterBL(DataRow _drRow)
        {

            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        Nullable<DateTime> appDownLoadDate;
        public Nullable<DateTime> AppDownLoadDate
        {
            get { return appDownLoadDate; }
            set { appDownLoadDate = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }


        String userName;
        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        String phone;
        public String Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        String model;
        public String Model
        {
            get { return model; }
            set { model = value; }
        }

        String make;
        public String Make
        {
            get { return make; }
            set { make = value; }
        }

        String year;
        public String Year
        {
            get { return year; }
            set { year = value; }
        }


        String email;
        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        String zip;
        public String Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        String claimNumber;
        public String ClaimNumber
        {
            get { return claimNumber; }
            set { claimNumber = value; }
        }

        String ro_Identifier;
        public String ROIdentifier
        {
            get { return ro_Identifier; }
            set { ro_Identifier = value; }
        }

        String m_strNetTotalAmount;
        public String strNetTotalAmount
        {
            get { return m_strNetTotalAmount; }
            set { m_strNetTotalAmount = value; }
        }

        String companyName;
        public String CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        String m_strAgentName;
        public String strAgentName
        {
            get { return m_strAgentName; }
            set { m_strAgentName = value; }
        }

        Int32 userId;
        public Int32 UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        Nullable<DateTime> updatedEntryTime;
        public Nullable<DateTime> UpdatedEntryTime
        {
            get { return updatedEntryTime; }
            set { updatedEntryTime = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }

        Nullable<Int32> vehicleId;
        public Nullable<Int32> VehicleId
        {
            get { return vehicleId; }
            set { vehicleId = value; }
        }

        Nullable<Int32> m_iShopId;
        public Nullable<Int32> iShopId
        {
            get { return m_iShopId; }
            set { m_iShopId = value; }
        }

        Nullable<DateTime> deliveryDate;
        public Nullable<DateTime> DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }

        Boolean bIsShowEmailMarketing;
        public Boolean IsShowEmailMarketing
        {
            get { return bIsShowEmailMarketing; }
            set { bIsShowEmailMarketing = value; }
        }

        Boolean bIsTextEmailMarketing;
        public Boolean IsTextEmailMarketing
        {
            get { return bIsTextEmailMarketing; }
            set { bIsTextEmailMarketing = value; }
        }
        #endregion "Members"


        #region "overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.SP_Search_EmailTextMarketingCentersRow row = _dataRow as SummitDS.SP_Search_EmailTextMarketingCentersRow;

            if (row != null)
            {
                appDownLoadDate = row.IsappDownLoadDateNull() ? (Nullable<DateTime>)null : row.appDownLoadDate;
                //userName = row.userName;
                userName = row.IsuserNameNull() ? String.Empty : row.userName;
                phone = row.IsphoneNull() ? String.Empty : row.phone;
                model = row.IsmodelNull() ? String.Empty : row.model;
                make = row.IsmakeNull() ? String.Empty : row.make;
                year = row.IsyearNull() ? String.Empty : row.year;
                iShopId = row.Isshop_idNull() ? (Nullable<Int32>)null : row.shop_id;
                email = row.IsemailNull() ? String.Empty : row.email;
                zip = row.IszipNull() ? String.Empty : row.zip;
                userId = row.user_id;
                updatedEntryTime = row.IsupdatedEntryTimeNull() ? (Nullable<DateTime>)null : row.updatedEntryTime;
                vehicleId = row.Isvehicle_idNull() ? (Nullable<Int32>)null : row.vehicle_id;
                deliveryDate = row.IsdeliverydateNull() ? (Nullable<DateTime>)null : row.deliverydate;
                claimNumber = row.Isclaim_numberNull() ? String.Empty : row.claim_number;
                ro_Identifier = row.Isro_IdentifierNull() ? String.Empty : row.ro_Identifier;
                companyName = row.Iscompany_nameNull() ? String.Empty : row.company_name;
                strAgentName = row.Isagent_nameNull() ? String.Empty : row.agent_name;
                strNetTotalAmount = row.Isnet__Total_AmountNull() ? String.Empty : row.net__Total_Amount;
                bIsShowEmailMarketing = row.isShowEmailMarketing;
                bIsTextEmailMarketing = row.isShowTextMarketing;
            }
        }



        #endregion

        #region "Static Methods"

        private static SP_Search_EmailTextMarketingCentersTableAdapter getAdapter()
        {
            return new SP_Search_EmailTextMarketingCentersTableAdapter();
        }

        public static List<MarketingCenterBL> getMarketinCentersList(Int32 iShopId)
        {
            SummitDS.SP_Search_EmailTextMarketingCentersDataTable thisTable = getAdapter().GetData(iShopId);
            List<MarketingCenterBL> lstCommnicationList = new List<MarketingCenterBL>();
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                lstCommnicationList = BuildFromTable(thisTable);
            }
            return lstCommnicationList;
        }

        private static List<MarketingCenterBL> BuildFromTable(DataTable dtTable)
        {
            List<MarketingCenterBL> list = new List<MarketingCenterBL>();
            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    MarketingCenterBL thisMember = new MarketingCenterBL(dr);
                    list.Add(thisMember);
                }
            }
            return list;
        }

        #endregion
        #region "IComparable"
        public int CompareTo(MarketingCenterBL au2, String comparisonType)
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
                case "PhoneASC":
                    descFlag = 1;
                    if (null != phone && null != au2.phone)
                        compareResult = phone.CompareTo(au2.phone);
                    break;

                case "PhoneDESC":
                    descFlag = -1;
                    if (null != phone && null != au2.phone)
                        compareResult = phone.CompareTo(au2.phone);
                    break;

                case "DateASC":
                    descFlag = 1;
                    if (null != updatedEntryTime && null != au2.updatedEntryTime)
                        compareResult = updatedEntryTime.Value.CompareTo(au2.updatedEntryTime.Value);
                    break;

                case "DateDESC":
                    descFlag = -1;
                    if (null != updatedEntryTime && null != au2.updatedEntryTime)
                        compareResult = updatedEntryTime.Value.CompareTo(au2.updatedEntryTime.Value);
                    break;

                case "TimeASC":
                    descFlag = 1;
                    if (null != updatedEntryTime && null != au2.updatedEntryTime)
                        compareResult = updatedEntryTime.Value.ToShortTimeString().CompareTo(au2.updatedEntryTime.Value.ToShortTimeString());
                    break;

                case "TimeDESC":
                    descFlag = -1;
                    if (null != updatedEntryTime && null != au2.updatedEntryTime)
                        compareResult = updatedEntryTime.Value.ToShortTimeString().CompareTo(au2.updatedEntryTime.Value.ToShortTimeString());
                    break;

                case "NameASC":
                    descFlag = 1;
                    if (null != userName && null != au2.userName)
                        compareResult = userName.CompareTo(au2.userName);
                    break;

                case "NameDESC":
                    descFlag = -1;
                    if (null != userName && null != au2.userName)
                        compareResult = userName.CompareTo(au2.userName);
                    break;

                case "ZipASC":
                    descFlag = 1;
                    if (null != zip && null != au2.zip)
                        compareResult = zip.CompareTo(au2.zip);
                    break;

                case "ZipDESC":
                    descFlag = -1;
                    if (null != zip && null != au2.zip)
                        compareResult = zip.CompareTo(au2.zip);
                    break;

                case "EmailASC":
                    descFlag = 1;
                    if (null != email && null != au2.email)
                        compareResult = email.CompareTo(au2.email);
                    break;

                case "EmailDESC":
                    descFlag = -1;
                    if (null != email && null != au2.email)
                        compareResult = email.CompareTo(au2.email);
                    break;

                case "DeliveryDateASC":
                    descFlag = 1;
                    if (DeliveryDate != null && au2.DeliveryDate != null)
                        compareResult = DeliveryDate.Value.CompareTo(au2.DeliveryDate.Value);
                    else if (DeliveryDate.HasValue && !au2.DeliveryDate.HasValue)
                        compareResult = -1;
                    break;

                case "DeliveryDateDESC":
                    descFlag = -1;
                    if (DeliveryDate.HasValue && au2.DeliveryDate.HasValue)
                        compareResult = DeliveryDate.Value.CompareTo(au2.DeliveryDate.Value);
                    else if (DeliveryDate.HasValue && !au2.DeliveryDate.HasValue)
                        compareResult = 1;
                    break;

                case "VehicleInfoASC":
                    descFlag = 1;
                    String vehicleInfo = (year != null ? year : String.Empty) + "," + (make != null ? make : String.Empty) + "," + (model != null ? model : String.Empty);
                    String vehicleInfo2 = (au2.year != null ? au2.year : String.Empty) + "," + (au2.make != null ? au2.make : String.Empty) + "," + (au2.model != null ? au2.model : String.Empty);
                    if (!String.IsNullOrEmpty(vehicleInfo) && !String.IsNullOrEmpty(vehicleInfo2))
                        compareResult = vehicleInfo.CompareTo(vehicleInfo2);
                    break;

                case "VehicleInfoDESC":
                    descFlag = -1;
                    String _vehicleInfo = (year != null ? year : String.Empty) + "," + (make != null ? make : String.Empty) + "," + (model != null ? model : String.Empty);
                    String _vehicleInfo2 = (au2.year != null ? au2.year : String.Empty) + "," + (au2.make != null ? au2.make : String.Empty) + "," + (au2.model != null ? au2.model : String.Empty);
                    if (!String.IsNullOrEmpty(_vehicleInfo) && !String.IsNullOrEmpty(_vehicleInfo2))
                        compareResult = _vehicleInfo.CompareTo(_vehicleInfo2);
                    break;

                default:
                    descFlag = 1;
                    if (null != userName && null != au2.userName)
                        compareResult = userName.CompareTo(au2.userName);
                    break;

            }
            return compareResult * descFlag; //desc flag of -1 returns negative result for descending sort
        }
        #endregion
    }

    public class MarketingCenterComparer : IComparer<MarketingCenterBL>
    {
        private String comparisonType;

        public String ComparisonType
        {
            get { return comparisonType; }
            set { comparisonType = value; }
        }

        public int Compare(MarketingCenterBL o1, MarketingCenterBL o2)
        {
            return o1.CompareTo(o2, comparisonType);
        }
    }
}
