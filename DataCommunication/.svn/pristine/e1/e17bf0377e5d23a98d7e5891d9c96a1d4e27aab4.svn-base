using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;
using System.Data;

namespace SummitShopApp.BL
{
    /// <summary>
    /// ReoccuringCampaignUsers Class
    /// </summary>
    public class ReocurringCampaignUsersBL : BaseEditableItem
    {
        //Get Timezone from SessionBL
        #region "Constructor"

        public ReocurringCampaignUsersBL()
        {

        }
        public ReocurringCampaignUsersBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        Int32 m_iRowId;
        public Int32 iRowId
        {
            get { return this.m_iRowId; }
            set { this.m_iRowId = value; }
        }


        Nullable<Int32> m_iFrequencyID;
        public Nullable<Int32> iFrequencyID
        {
            get { return this.m_iFrequencyID; }
            set { this.m_iFrequencyID = value; }
        }

        Nullable<Int32> m_iShopID;
        public Nullable<Int32> iShopID
        {
            get { return this.m_iShopID; }
            set { this.m_iShopID = value; }
        }

        Nullable<Int32> m_iVehicleID;
        public Nullable<Int32> iVehicleID
        {
            get { return this.m_iVehicleID; }
            set { this.m_iVehicleID = value; }
        }

        Nullable<DateTime> m_dtDeliveredDate;
        public Nullable<DateTime> dtDeliveredDate
        {
            get { return this.m_dtDeliveredDate; }
            set { this.m_dtDeliveredDate = value; }
        }

        String m_strPhone;
        public String strPhone
        {
            get { return this.m_strPhone; }
            set { this.m_strPhone = value; }
        }

        Nullable<Boolean> m_bIsMailSent;
        public Nullable<Boolean> bIsMailSent
        {
            get { return this.m_bIsMailSent; }
            set { this.m_bIsMailSent = value; }
        }

        Nullable<Boolean> m_bIsSmsSent;
        public Nullable<Boolean> bIsSmsSent
        {
            get { return this.m_bIsSmsSent; }
            set { this.m_bIsSmsSent = value; }
        }

        Nullable<Int32> m_iUserID;
        public Nullable<Int32> iUserID
        {
            get { return this.m_iUserID; }
            set { this.m_iUserID = value; }
        }

        String m_strFirstName;
        public String strFirstName
        {
            get { return this.m_strFirstName; }
            set { this.m_strFirstName = value; }
        }

        String m_strEmail;
        public String strEmail
        {
            get { return this.m_strEmail; }
            set { this.m_strEmail = value; }
        }

        String m_strUserName;
        public String strUserName
        {
            get { return this.m_strUserName; }
            set { this.m_strUserName = value; }
        }

        private Nullable<Int32> m_iEmailTemplateId;
        public Nullable<Int32> iEmailTemplateId
        {
            get { return this.m_iEmailTemplateId; }
            set { this.m_iEmailTemplateId = value; }
        }


        #endregion "Members"

        #region "overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.ReocurringCampaignUsersRow row = _dataRow as SummitDS.ReocurringCampaignUsersRow;

            if (row != null)
            {
                this._ID = row.reocurring_campaign_user_id;
                this.m_iRowId = row.reocurring_campaign_user_id;
                this.m_iFrequencyID = row.Isfrequency_idNull() ? (Nullable<Int32>)null : row.frequency_id;
                this.m_iShopID = row.Isshop_idNull() ? (Nullable<Int32>)null : row.shop_id;
                this.m_iVehicleID = row.Isvehicle_idNull() ? (Nullable<Int32>)null : row.vehicle_id;
                this.m_iUserID = row.Isshop_idNull() ? (Nullable<Int32>)null : row.user_id;
                this.m_strPhone = row.IsphoneNull() ? String.Empty : row.phone;
                this.m_dtDeliveredDate = row.Isdelivered_dateNull() ? (Nullable<DateTime>)null : row.delivered_date;
                this.m_bIsMailSent = row.IsisMailSentNull() ? (Nullable<Boolean>)null : row.isMailSent;
                this.m_strFirstName = row.Isfirst_nameNull() ? String.Empty : row.first_name;
                this.m_strUserName = row.IsusernameNull() ? String.Empty : row.username;
                this.m_bIsSmsSent = row.IsisSmsSentNull() ? (Nullable<Boolean>)null : row.isSmsSent;
                this.m_strEmail = row.IsemailNull() ? String.Empty : row.email;
                this.m_iEmailTemplateId = row.Isemail_template_idNull() ? (Nullable<Int32>)null : row.email_template_id;
                _rowToSave = row;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.ReocurringCampaignUsersDataTable _thisTable = new SummitDS.ReocurringCampaignUsersDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewReocurringCampaignUsersRow();
            SummitDS.ReocurringCampaignUsersRow _dataRow = _rowToSave as SummitDS.ReocurringCampaignUsersRow;

            if (_dataRow != null)
            {
                if (IsExisting())
                {
                    if (iShopID.HasValue) _dataRow.shop_id = iShopID.Value;
                    else _dataRow.Setshop_idNull();

                    if (iVehicleID.HasValue) _dataRow.vehicle_id = iVehicleID.Value;
                    else _dataRow.Setvehicle_idNull();

                    if (iFrequencyID.HasValue) _dataRow.frequency_id = iFrequencyID.Value;
                    else _dataRow.Setfrequency_idNull();

                    if (iUserID.HasValue) _dataRow.user_id = iUserID.Value;
                    else _dataRow.Setuser_idNull();

                    if (bIsMailSent.HasValue) _dataRow.isMailSent = bIsMailSent.Value;
                    else _dataRow.SetisMailSentNull();

                    if (bIsSmsSent.HasValue) _dataRow.isSmsSent = bIsSmsSent.Value;
                    else _dataRow.SetisSmsSentNull();

                    if (m_dtDeliveredDate.HasValue) _dataRow.delivered_date = m_dtDeliveredDate.Value;
                    else _dataRow.Setdelivered_dateNull();

                    if (m_iEmailTemplateId.HasValue) _dataRow.email_template_id = m_iEmailTemplateId.Value;
                    else _dataRow.Setemail_template_idNull();

                }
                else
                {
                    if (bIsMailSent.HasValue) _dataRow.isMailSent = bIsMailSent.Value;
                    else _dataRow.SetisMailSentNull();

                    if (bIsSmsSent.HasValue) _dataRow.isSmsSent = bIsSmsSent.Value;
                    else _dataRow.SetisSmsSentNull();

                    if (iShopID.HasValue) _dataRow.shop_id = iShopID.Value;
                    else _dataRow.Setshop_idNull();

                    if (iVehicleID.HasValue) _dataRow.vehicle_id = iVehicleID.Value;
                    else _dataRow.Setvehicle_idNull();

                    if (iFrequencyID.HasValue) _dataRow.frequency_id = iFrequencyID.Value;
                    else _dataRow.Setfrequency_idNull();

                    if (iUserID.HasValue) _dataRow.user_id = iUserID.Value;
                    else _dataRow.Setuser_idNull();

                    if (m_dtDeliveredDate.HasValue) _dataRow.delivered_date = m_dtDeliveredDate.Value;
                    else _dataRow.Setdelivered_dateNull();

                    if (m_iEmailTemplateId.HasValue) _dataRow.email_template_id = m_iEmailTemplateId.Value;
                    else _dataRow.Setemail_template_idNull();


                    _thisTable.AddReocurringCampaignUsersRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
            SummitDS.ReocurringCampaignUsersRow thisRow = _rowToSave as SummitDS.ReocurringCampaignUsersRow;
            if (thisRow != null)
            {
                this._ID = thisRow.reocurring_campaign_user_id;
                this.m_iRowId = thisRow.reocurring_campaign_user_id;
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


        #endregion "overrides"

        #region "Static Methods"

        private static ReocurringCampaignUsersTableAdapter getAdapter()
        {
            return new ReocurringCampaignUsersTableAdapter();
        }

        /// <summary>
        /// Get List of ReocurringCampaignUsersBL instances by shop id 
        /// </summary>
        /// <param name="iFrequencyId">frequency id</param>
        /// <param name="iShopId">shop id</param>
        /// <param name="iDays">number of days</param>
        /// <returns></returns>
        public static List<ReocurringCampaignUsersBL> getDataByShopId(Int32 iFrequencyId, Int32 iShopId, Int32 iDays)
        {
            SummitDS.ReocurringCampaignUsersDataTable thisTable = getAdapter().GetDataByShopId(iFrequencyId, iShopId, iDays);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                List<ReocurringCampaignUsersBL> list = new List<ReocurringCampaignUsersBL>();
                list = BuildFromTable(thisTable);
                if (list != null)
                {
                    return list;
                }
            }
            return null;
        }

        /// <summary>
        /// Get List of ReocurringCampaignUsersBL instances by shop id and Frequency id 
        /// </summary>
        /// <param name="iFrequencyId">frequency id</param>
        /// <param name="iShopId">shop id</param>
        /// <returns>List of ReocurringCampaignUsersBL instances</returns>
        public static List<ReocurringCampaignUsersBL> getDataByShopIdandFrequencyId(Int32 iFrequencyId, Int32 iShopId)
        {
            SummitDS.ReocurringCampaignUsersDataTable thisTable = getAdapter().GetDataByShopIdAndFrequencyId(iFrequencyId, iShopId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                List<ReocurringCampaignUsersBL> list = new List<ReocurringCampaignUsersBL>();
                list = BuildFromTable(thisTable);
                if (list != null)
                {
                    return list;
                }
            }
            return null;
        }

        /// <summary>
        /// Get List of ReocurringCampaignUsersBL instances by Frequency id
        /// </summary>
        /// <param name="iFrequencyId">Frequency Id</param>
        /// <param name="iShopId">shop id</param>
        /// <param name="days">number of days</param>
        /// <returns>List of ReocurringCampaignUsersBL instances</returns>
        public static List<ReocurringCampaignUsersBL> getCampaignUsers(Int32 iFrequencyId, Int32 iShopId, Int32 days)
        {
            SummitDS.ReocurringCampaignUsersDataTable thisTable = getAdapter().GetDataByFrequencyId(iFrequencyId, iShopId, days);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                List<ReocurringCampaignUsersBL> list = new List<ReocurringCampaignUsersBL>();
                list = BuildFromTable(thisTable);
                if (list != null)
                {
                    return list;
                }
            }
            return null;
        }

        /// <summary>
        /// Get ReocurringCampaignUsersBL instance by shop id and user id
        /// </summary>
        /// <param name="iShopId">shop id</param>
        /// <param name="iUserId">user id</param>
        /// <returns></returns>
        public static ReocurringCampaignUsersBL getDataByShopIdandUserId(Int32 iShopId, Int32 iUserId)
        {
            SummitDS.ReocurringCampaignUsersDataTable thisTable = getAdapter().GetDataByShopIdAndUserId(iShopId, iUserId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                if (BuildFromRow(thisTable.Rows[0]) != null)
                {
                    return BuildFromRow(thisTable.Rows[0]);
                }
            }
            return null;
        }

        public static ReocurringCampaignUsersBL getDataById(Int32 iRowId)
        {
            SummitDS.ReocurringCampaignUsersDataTable thisTable = getAdapter().GetDataById(iRowId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                if (BuildFromRow(thisTable.Rows[0]) != null)
                {
                    return BuildFromRow(thisTable.Rows[0]);
                }
            }

            return null;
        }

        /// <summary>
        /// Get data by shop ,user and frequency Id
        /// </summary>
        /// <param name="iShopId">shop id</param>
        /// <param name="iUserId">user id</param>
        /// <param name="iFrequencyId">frequency id</param>
        /// <returns>instance of ReocurringCampaignUsersBL</returns>
        public static ReocurringCampaignUsersBL getDataByShopIdUserIdAndFreqId(Int32 iShopId, Int32 iUserId, Int32 iFrequencyId)
        {
            SummitDS.ReocurringCampaignUsersDataTable thisTable = getAdapter().GetDataByShopUserAndFrequencyId(iShopId, iUserId, iFrequencyId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                if (BuildFromRow(thisTable.Rows[0]) != null)
                {
                    return BuildFromRow(thisTable.Rows[0]);
                }
            }
            return null;
        }

        private static ReocurringCampaignUsersBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new ReocurringCampaignUsersBL(drRow);
            }
            return null;
        }


        private static List<ReocurringCampaignUsersBL> BuildFromTable(DataTable dtTable)
        {
            List<ReocurringCampaignUsersBL> list = new List<ReocurringCampaignUsersBL>();
            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    ReocurringCampaignUsersBL thisMember = new ReocurringCampaignUsersBL(dr);
                    list.Add(thisMember);
                }
            }
            return list;
        }

        /// <summary>
        /// DeleteFromReocurringCampaignUsersForNull using userid and shopid
        /// </summary>
        /// <param name="iUserId">User Id</param>
        /// <param name="iShopId">shop id</param>
        /// <returns></returns>
        public static void deleteRecordsForNull(Int32 iUserId, Int32 iShopId)
        {
            getAdapter().DeleteFromReocurringCampaignUsersForNull(iUserId, iShopId);
        }

        /// <summary>
        /// UpdateDeliveryDateForUserIdAndShopId using userid and shopid
        /// </summary>
        /// / <param name="dtDeliveryDate">Delivery Date</param>
        /// <param name="iUserId">User Id</param>
        /// <param name="iShopId">shop id</param>
        /// <returns></returns>
        public static void updateDeliveryDates(DateTime dtDeliveryDate, Int32 iUserId, Int32 iShopId)
        {
            getAdapter().UpdateDeliveryDateForUserIdAndShopId(dtDeliveryDate, iUserId, iShopId);
        }



        #endregion "Static Methods"

        #region "IComparable"
        public int CompareTo(ReocurringCampaignUsersBL au2, String comparisonType)
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
                case "FirstNameASC":
                    descFlag = 1;
                    compareResult = strFirstName.CompareTo(au2.strFirstName);
                    break;

                case "FirstNameDESC":
                    descFlag = -1;
                    compareResult = strFirstName.CompareTo(au2.strFirstName);
                    break;

                case "EmailASC":
                    descFlag = 1;
                    compareResult = strEmail.CompareTo(au2.strEmail);
                    break;

                case "EmailDESC":
                    descFlag = -1;
                    compareResult = strEmail.CompareTo(au2.strEmail);
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


    public class UserComparer : IComparer<ReocurringCampaignUsersBL>
    {
        private String comparisonType;

        public String ComparisonType
        {
            get { return comparisonType; }
            set { comparisonType = value; }
        }

        public int Compare(ReocurringCampaignUsersBL o1, ReocurringCampaignUsersBL o2)
        {
            return o1.CompareTo(o2, comparisonType);
        }
    }

}
