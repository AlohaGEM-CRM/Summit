using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SummitShopApp.DAL.SummitDSTableAdapters;
using SummitShopApp.DAL;

namespace SummitShopApp.BL
{
    public class UserPreferredShopBL:BaseEditableItem
    {
        #region "Constructor"

        public UserPreferredShopBL()
        {

        }

        public UserPreferredShopBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        Nullable<Int32> m_iUserId;
        Nullable<Int32> m_iShopId;

        #endregion "Members"

        #region "Accessors"

        public Nullable<Int32> iShopId
        {
            get { return this.m_iShopId; }
            set { this.m_iShopId = value; }
        }

        public Nullable<Int32> iUserId
        {
            get { return this.m_iUserId; }
            set { this.m_iUserId = value; }
        }

        #endregion "Accessors"

        #region "Static Methods"

        private static User_PreferredShopTableAdapter getAdapter()
        {
            return new User_PreferredShopTableAdapter();
        }

        public static UserPreferredShopBL getShopByUserId(Int32 iUserId)
        {
            SummitDS.User_PreferredShopDataTable thisTable = getAdapter().GetDataByUserId(iUserId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }

            return null;
        }

        private static UserPreferredShopBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new UserPreferredShopBL(drRow);
            }
            return null;
        }

        private static List<UserPreferredShopBL> BuildFromTable(DataTable dtTable)
        {
            List<UserPreferredShopBL> _list = new List<UserPreferredShopBL>();

            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    UserPreferredShopBL _thisMember = new UserPreferredShopBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }

        #endregion "Static Methods"

        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.User_PreferredShopRow _thisRow = _dataRow as SummitDS.User_PreferredShopRow;

            if (_thisRow != null)
            {
                this._ID = _thisRow.ID;
                
                this.m_iShopId = _thisRow.Isshop_idNull() ? (Nullable<Int32>)null : _thisRow.shop_id;
                this.m_iUserId = _thisRow.Isuser_idNull() ? (Nullable<Int32>)null : _thisRow.user_id;

                //  this.m_dt_ts = _thisRow.Is_tsNull() ? (Nullable<DateTime>) null : _thisRow._ts ;                                
                _rowToSave = _thisRow;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.User_PreferredShopDataTable _thisTable = new SummitDS.User_PreferredShopDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewUser_PreferredShopRow();
            SummitDS.User_PreferredShopRow _dataRow = _rowToSave as SummitDS.User_PreferredShopRow;

            if (_dataRow != null)
            {
                if (IsExisting())
                {
                    if (iShopId.HasValue) _dataRow.shop_id = iShopId.Value;
                    else _dataRow.Setshop_idNull();

                    if (iUserId.HasValue) _dataRow.user_id = iUserId.Value;
                    else _dataRow.Setuser_idNull();

                }
                else
                {
                    if (iShopId.HasValue) _dataRow.shop_id = iShopId.Value;
                    else _dataRow.Setshop_idNull();

                    if (iUserId.HasValue) _dataRow.user_id = iUserId.Value;
                    else _dataRow.Setuser_idNull();

                    _thisTable.AddUser_PreferredShopRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
            SummitDS.User_PreferredShopRow thisRow = _rowToSave as SummitDS.User_PreferredShopRow;
            if (thisRow != null)
            {
                this._ID = thisRow.ID;
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
