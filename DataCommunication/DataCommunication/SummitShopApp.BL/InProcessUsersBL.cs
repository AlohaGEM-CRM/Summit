using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;
using System.Data;

namespace SummitShopApp.BL
{
    public class InProcessUsersBL : BaseEditableItem
    {
        #region "Constructor"

        public InProcessUsersBL()
        {

        }
        public InProcessUsersBL(DataRow _drRow)
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

        Nullable<Int32> m_iShopId;
        public Nullable<Int32> iShopId
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

        String m_strAgentName;
        public String strAgentName
        {
            get { return m_strAgentName; }
            set { m_strAgentName = value; }
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
            set { m_dtInDate = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }

        Nullable<DateTime> m_dtUpdatedDate;
        public Nullable<DateTime> dtUpdatedDate
        {
            get { return m_dtUpdatedDate; }
            set { m_dtUpdatedDate = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }

        Nullable<DateTime> m_dtOutDate;
        public Nullable<DateTime> dtOutDate
        {
            get { return m_dtOutDate; }
            set { m_dtOutDate = value.HasValue ? value.Value.ToUniversalTime() : value; }
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

        String m_strEstimateFileIdentifier;
        public String strEstimateFileIdentifier
        {
            get { return m_strEstimateFileIdentifier; }
            set { m_strEstimateFileIdentifier = value; }
        }
        #endregion "Members"

        #region "overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.SP_Search_InProcessUsersRow row = _dataRow as SummitDS.SP_Search_InProcessUsersRow;

            if (row != null)
            {
                this._ID = row.id;
                iUserId = row.user_id;
                iUserVehicleStatusId = row.IsuserVehicleStatusIdNull() ? (Nullable<Int32>)null : row.userVehicleStatusId;
                iVehicleId = row.Isvehicle_idNull() ? (Nullable<Int32>)null : row.vehicle_id;
                strUserName = row.IsusernameNull() ? String.Empty : row.username;
                strPhone = row.IsphoneNull() ? String.Empty : row.phone;
                strModel = row.IsmodelNull() ? String.Empty : row.model;
                strMake = row.IsmakeNull() ? String.Empty : row.make;
                strYear = row.IsyearNull() ? String.Empty : row.year;
                strEmail = row.IsemailNull() ? String.Empty : row.email;
                iShopId = row.Isshop_idNull() ? (Nullable<Int32>)null : row.shop_id;
                dtInDate = row.IsdateInNull() ? (Nullable<DateTime>)null : row.dateIn;
                dtOutDate = row.IsdateOutNull() ? (Nullable<DateTime>)null : row.dateOut;
                iVehicleStatus = row.IsvehicleStatusNull() ? (Nullable<Int32>)null : row.vehicleStatus;
                iContactMethod = row.IscontactMethodNull() ? (Nullable<Int32>)null : row.contactMethod;
                strShopName = row.Isshop_nameNull() ? String.Empty : row.shop_name;
                strClaimNumber = row.Isclaim_numberNull() ? String.Empty : row.claim_number;
                strROIdentifier = row.Isro_IdentifierNull() ? String.Empty : row.ro_Identifier;
                companyName = row.Iscompany_nameNull() ? String.Empty : row.company_name;
                strAgentName = row.Isagent_nameNull() ? String.Empty : row.agent_name;
                strNetTotalAmount = row.Isnet__Total_AmountNull() ? String.Empty : row.net__Total_Amount;
                dtUpdatedDate = row.IsUpdatedDateNull() ? (Nullable<DateTime>)null : row.UpdatedDate;
                strEstimateFileIdentifier = row.Isestimate_file_identifierNull() ? String.Empty : row.estimate_file_identifier;
            }
        }

        protected override void SaveToRow()
        {
        }

        protected override void SetID()
        {
            SummitDS.SP_Search_InProcessUsersRow thisRow = _rowToSave as SummitDS.SP_Search_InProcessUsersRow;
            if (thisRow != null)
            {
                this._ID = thisRow.id;
            }
        }

        protected override void Update()
        {
        }

        protected override void DeleteRecord()
        {
        }

        #region "Static Methods"

        private static SP_Search_InProcessUsersTableAdapter getAdapter()
        {
            return new SP_Search_InProcessUsersTableAdapter();
        }

        public static List<InProcessUsersBL> getCustomersList(int shopId)
        {
            SummitDS.SP_Search_InProcessUsersDataTable thisTable = getAdapter().GetData(shopId);
            List<InProcessUsersBL> lstCustomerList = null;

            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                lstCustomerList = BuildFromTable(thisTable);
            }
            return lstCustomerList;
        }

        /// <summary>
        /// Get All Users deleted by shop user
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public static List<InProcessUsersBL> GetDeletedUsers(int shopId)
        {
            SummitDS.SP_Search_InProcessUsersDataTable thisTable = getAdapter().GetDeletedInProcessUsers(shopId);
            List<InProcessUsersBL> lstCustomerList = null;
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                lstCustomerList = BuildFromTable(thisTable);
            }
            return lstCustomerList;
        }

        /// <summary>
        /// Get All Users deleted by shop user
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public static List<InProcessUsersBL> GetAllDeletedUsers(int shopId)
        {
            SummitDS.SP_Search_InProcessUsersDataTable thisTable = getAdapter().GetDeletedUsers(shopId);
            List<InProcessUsersBL> lstCustomerList = null;
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                lstCustomerList = BuildFromTable(thisTable);
            }
            return lstCustomerList;
        }

        public static Int32 getDueDeliveriesCount(int shopId)
        {
            SummitDS.SP_Search_InProcessUsersDataTable thisTable = getAdapter().GetData(shopId);
            List<InProcessUsersBL> lstCustomerList = null;
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                lstCustomerList = BuildFromTable(thisTable);
                List<InProcessUsersBL> lstNewUserList = new List<InProcessUsersBL>();
                foreach (InProcessUsersBL objUser in lstCustomerList)
                {
                    if (objUser.dtOutDate > DateTime.Now.ToUniversalTime())
                    {
                        lstNewUserList.Add(objUser);
                    }
                }
                if (lstNewUserList.Count > 0)
                    return lstNewUserList.Count;
            }
            return 0;
        }

        private static List<InProcessUsersBL> BuildFromTable(DataTable dtTable)
        {
            List<InProcessUsersBL> list = new List<InProcessUsersBL>();
            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    InProcessUsersBL thisMember = new InProcessUsersBL(dr);
                    list.Add(thisMember);
                }
            }
            return list;
        }

        #endregion

        #endregion

        #region "IComparable"
        public int CompareTo(InProcessUsersBL au2, String comparisonType)
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
                    if (null != dtInDate && null != au2.dtInDate)
                        compareResult = dtInDate.Value.CompareTo(au2.dtInDate.Value);
                    break;

                case "DateInDESC":
                    descFlag = -1;
                    if (null != dtInDate && null != au2.dtInDate)
                        compareResult = dtInDate.Value.CompareTo(au2.dtInDate.Value);
                    break;

                case "DateOutASC":
                    descFlag = 1;
                    if (null != dtOutDate && null != au2.dtOutDate)
                        compareResult = dtOutDate.Value.CompareTo(au2.dtOutDate.Value);
                    break;

                case "DateOutDESC":
                    descFlag = -1;
                    if (null != dtOutDate && null != au2.dtOutDate)
                        compareResult = dtOutDate.Value.CompareTo(au2.dtOutDate.Value);
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
                    if (null != dtUpdatedDate && null != au2.dtUpdatedDate)
                        compareResult = dtUpdatedDate.Value.CompareTo(au2.dtUpdatedDate.Value);
                    break;

                case "UpdatedDateDESC":
                    descFlag = -1;
                    if (null != dtUpdatedDate && null != au2.dtUpdatedDate)
                        compareResult = dtUpdatedDate.Value.CompareTo(au2.dtUpdatedDate.Value);
                    break;

                case "DateASC":
                    descFlag = 1;
                    if (null != dtUpdatedDate && null != au2.dtUpdatedDate)
                        compareResult = dtUpdatedDate.Value.CompareTo(au2.dtUpdatedDate.Value);
                    break;

                case "DateDESC":
                    descFlag = -1;
                    if (null != dtUpdatedDate && null != au2.dtUpdatedDate)
                        compareResult = dtUpdatedDate.Value.CompareTo(au2.dtUpdatedDate.Value);
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


    public class InProcessUsersComparer : IComparer<InProcessUsersBL>
    {
        private String comparisonType;

        public String ComparisonType
        {
            get { return comparisonType; }
            set { comparisonType = value; }
        }

        public int Compare(InProcessUsersBL o1, InProcessUsersBL o2)
        {
            return o1.CompareTo(o2, comparisonType);
        }
    }
}
