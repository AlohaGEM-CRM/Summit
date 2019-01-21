using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SummitShopApp.DAL.SummitDSTableAdapters;
using SummitShopApp.DAL;

namespace SummitShopApp.BL
{
    public class ScheduledUsersBL : BaseEditableItem
    {
        //Get Timezone from SessionBL
        
        #region "Constructor"

        public ScheduledUsersBL()
        {

        }

        public ScheduledUsersBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        Nullable<DateTime> m_dtSendDate;
        Nullable<Int32> m_iFrequency;
        Nullable<Int32> m_iUserId;
        Nullable<Int32> m_iShopId;
        Nullable<Boolean> m_bIsSmsSent;
        Nullable<Boolean> m_bIsMailSent;

        #endregion "Members"

        #region "Accessors"

        public Nullable<Int32> iShopId
        {
            get { return this.m_iShopId; }
            set { this.m_iShopId = value; }
        }

        public Nullable<Boolean> bIsMailSent
        {
            get { return this.m_bIsMailSent; }
            set { this.m_bIsMailSent = value; }
        }

        public Nullable<Boolean> bIsSmsSent
        {
            get { return this.m_bIsSmsSent; }
            set { this.m_bIsSmsSent = value; }
        }

        public Nullable<DateTime> dtSendDate
        {
            get { return this.m_dtSendDate; }
            set { this.m_dtSendDate = value; }
        }

        public Nullable<Int32> iFrequency
        {
            get { return this.m_iFrequency; }
            set { this.m_iFrequency = value; }
        }

        public Nullable<Int32> iUserId
        {
            get { return this.m_iUserId; }
            set { this.m_iUserId = value; }
        }


        #endregion "Accessors"

        #region "Static Methods"

        private static ScheduledUsersTableAdapter getAdapter()
        {
            return new ScheduledUsersTableAdapter();
        }

        public static List<ScheduledUsersBL> getData()
        {
            SummitDS.ScheduledUsersDataTable thisTable = getAdapter().GetData();
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromTable(thisTable);
            }
            return null;
        }

        private static List<ScheduledUsersBL> BuildFromTable(DataTable dtTable)
        {
            List<ScheduledUsersBL> list = new List<ScheduledUsersBL>();
            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    ScheduledUsersBL thisMember = new ScheduledUsersBL(dr);
                    list.Add(thisMember);
                }
            }
            return list;
        }

        private static ScheduledUsersBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new ScheduledUsersBL(drRow);
            }
            return null;
        }

        public static ScheduledUsersBL getDataByFrequencyId(Int32 iShopId, Int32 iUserId, Int32 iFrequencyId)
        {
            SummitDS.ScheduledUsersDataTable thisTable = getAdapter().GetDataByFrequencyId(iShopId, iUserId, iFrequencyId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        public static ScheduledUsersBL getDataById(Int32 iScheduledUsersId)
        {
            SummitDS.ScheduledUsersDataTable thisTable = getAdapter().GetDataById(iScheduledUsersId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// Get Data By User id , Shop Id and Frequency Id
        /// </summary>
        /// <param name="iUserId"></param>
        /// <param name="iShopId"></param>
        /// <param name="iFrequencyId"></param>
        /// <returns></returns>
        public static ScheduledUsersBL getDataByUserIdShopIdAndFrequencyId(Int32 iUserId, Int32 iShopId, Int32 iFrequencyId)
        {
            SummitDS.ScheduledUsersDataTable thisTable = getAdapter().GetDataByUserIdShopIdAndFrequencyId(iUserId, iShopId, iFrequencyId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }




        #endregion "Static Methods"

        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.ScheduledUsersRow _thisRow = _dataRow as SummitDS.ScheduledUsersRow;

            if (_thisRow != null)
            {
                this._ID = _thisRow.scheduled_users_id;
                this.m_iShopId = _thisRow.Isshop_idNull() ? (Nullable<Int32>)null : _thisRow.shop_id;
                //this.iCustomerId = _thisRow.customer_id;
                //this.iVehicleStatusId = _thisRow.vehiclestatus_id;
                this.m_dtSendDate = _thisRow.Issend_dateNull() ? (Nullable<DateTime>)null : _thisRow.send_date;
                this.m_iFrequency = _thisRow.Isfrequency_idNull() ? (Nullable<Int32>)null : _thisRow.frequency_id;
                this.m_iUserId = _thisRow.Isuser_idNull() ? (Nullable<Int32>)null : _thisRow.user_id;
                this.m_bIsMailSent = _thisRow.IsisMailSentNull() ? (Nullable<Boolean>)null : _thisRow.isMailSent;
                this.m_bIsSmsSent = _thisRow.IsisSmsSentNull() ? (Nullable<Boolean>)null : _thisRow.isSmsSent;

                //  this.m_dt_ts = _thisRow.Is_tsNull() ? (Nullable<DateTime>) null : _thisRow._ts ;                                
                _rowToSave = _thisRow;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.ScheduledUsersDataTable _thisTable = new SummitDS.ScheduledUsersDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewScheduledUsersRow();
            SummitDS.ScheduledUsersRow _dataRow = _rowToSave as SummitDS.ScheduledUsersRow;

            if (_dataRow != null)
            {
                if (IsExisting())
                {
                    if (iShopId.HasValue) _dataRow.shop_id = iShopId.Value;
                    else _dataRow.Setshop_idNull();

                    //_dataRow.customer_id = this.m_iCustomerId;
                    //_dataRow.vehiclestatus_id = this.m_iVehicleStatusId;
                    if (m_dtSendDate.HasValue) _dataRow.send_date = m_dtSendDate.Value;
                    else _dataRow.Setsend_dateNull();

                    if (iFrequency.HasValue) _dataRow.frequency_id = iFrequency.Value;
                    else _dataRow.Setfrequency_idNull();

                    if (bIsMailSent.HasValue) _dataRow.isMailSent = bIsMailSent.Value;
                    else _dataRow.SetisMailSentNull();

                    if (bIsSmsSent.HasValue) _dataRow.isSmsSent = bIsSmsSent.Value;
                    else _dataRow.SetisSmsSentNull();


                    if (iUserId.HasValue) _dataRow.user_id = iUserId.Value;
                    else _dataRow.Setuser_idNull();


                }
                else
                {
                    if (iShopId.HasValue) _dataRow.shop_id = iShopId.Value;
                    else _dataRow.Setshop_idNull();

                    //_dataRow.customer_id = this.m_iCustomerId;
                    //_dataRow.vehiclestatus_id = this.m_iVehicleStatusId;
                    if (m_dtSendDate.HasValue) _dataRow.send_date = m_dtSendDate.Value;
                    else _dataRow.Setsend_dateNull();

                    if (bIsMailSent.HasValue) _dataRow.isMailSent = bIsMailSent.Value;
                    else _dataRow.SetisMailSentNull();

                    if (bIsSmsSent.HasValue) _dataRow.isSmsSent = bIsSmsSent.Value;
                    else _dataRow.SetisSmsSentNull();


                    if (iFrequency.HasValue) _dataRow.frequency_id = iFrequency.Value;
                    else _dataRow.Setfrequency_idNull();

                    if (iUserId.HasValue) _dataRow.user_id = iUserId.Value;
                    else _dataRow.Setuser_idNull();

                    _thisTable.AddScheduledUsersRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
            SummitDS.ScheduledUsersRow thisRow = _rowToSave as SummitDS.ScheduledUsersRow;
            if (thisRow != null)
            {
                this._ID = thisRow.scheduled_users_id; ;
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
