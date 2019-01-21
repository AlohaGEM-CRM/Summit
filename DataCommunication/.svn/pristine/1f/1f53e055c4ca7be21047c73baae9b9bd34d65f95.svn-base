using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;
using System.Data;

namespace SummitShopApp.BL
{
    public class User_Audit_TrailBL : BaseEditableItem
    {
        //Get Timezone from SessionBL
        //String strTimeZone = SessionBL.TimeZone.str;

        #region "Constructor"

        public User_Audit_TrailBL()
        {

        }

        public User_Audit_TrailBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        Int32 m_user_id;
        Int32 m_vehicle_id;
        Int32 m_vehicle_status_id;
        DateTime m_last_updated;
        bool m_is_Last_Unsold_Status;

        #endregion "Members"

        #region "Accessors"

        public int user_id
        {
            get { return this.m_user_id; }
            set { this.m_user_id = value; }
        }

        public int vehicle_id
        {
            get { return this.m_vehicle_id; }
            set { this.m_vehicle_id = value; }
        }

        public int vehicle_status_id
        {
            get { return this.m_vehicle_status_id; }
            set { this.m_vehicle_status_id = value; }
        }

        public DateTime last_updated
        {
            get { return this.m_last_updated; }
            set { this.m_last_updated = value; }
        }

        public bool isLastUnsoldStatus
        {
            get { return this.m_is_Last_Unsold_Status; }
            set { this.m_is_Last_Unsold_Status = value; }
        }

        #endregion "Accessors"

        #region "Static Methods"

        private static User_Audit_TrailTableAdapter getAdapter()
        {
            return new User_Audit_TrailTableAdapter();
        }
        public static User_Audit_TrailBL getDataByUserIDVehicleIdandStatusID(Int32 iUserId, Int32 iVehicleId, Int32 iStatusId)
        {
            SummitDS.User_Audit_TrailDataTable thisTable = getAdapter().GetDataByUserIDVehicleIdAndStatusID(iUserId,iVehicleId,iStatusId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        private static User_Audit_TrailBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new User_Audit_TrailBL(drRow);
            }
            return null;
        }

        private static List<User_Audit_TrailBL> BuildFromTable(DataTable dtTable)
        {
            List<User_Audit_TrailBL> _list = new List<User_Audit_TrailBL>();

            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    User_Audit_TrailBL _thisMember = new User_Audit_TrailBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }

        #endregion "Static Methods"

        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.User_Audit_TrailRow _thisRow = _dataRow as SummitDS.User_Audit_TrailRow;

            if (_thisRow != null)
            {
                this._ID = _thisRow.id;
                this.m_user_id = _thisRow.user_id;
                this.m_vehicle_id = _thisRow.vehicle_id;
                this.m_last_updated = _thisRow.last_updated;
                this.m_is_Last_Unsold_Status = _thisRow.isLastUnsoldStatus;
                _rowToSave = _thisRow;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.User_Audit_TrailDataTable _thisTable = new SummitDS.User_Audit_TrailDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewUser_Audit_TrailRow();
            SummitDS.User_Audit_TrailRow _dataRow = _rowToSave as SummitDS.User_Audit_TrailRow;

            if (_dataRow != null)
            {
                _dataRow.user_id = user_id;
                _dataRow.vehicle_id = vehicle_id;
                _dataRow.vehicle_status_id = vehicle_status_id;
                _dataRow.last_updated = DateTime.Now;
                _dataRow.isLastUnsoldStatus = isLastUnsoldStatus;
                if (!IsExisting())
                {
                    _thisTable.AddUser_Audit_TrailRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
            SummitDS.User_Audit_TrailRow thisRow = _rowToSave as SummitDS.User_Audit_TrailRow;
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
