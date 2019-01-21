using System;
using System.Collections.Generic;
using System.Data;
using SummitShopApp.DAL.SummitDSTableAdapters;
using SummitShopApp.DAL;


namespace SummitShopApp.BL
{
    public class ConnectAPIBL : BaseEditableItem
    {
        #region "Constructor"

        public ConnectAPIBL()
        {

        }

        public ConnectAPIBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        Int32 m_iShopId;
        String m_strPartnerKey;
        String m_strClientKey;
        Nullable<DateTime> m_dtCreatedDate;
        Nullable<DateTime> m_dtLastSyncDate;
        Nullable<DateTime> m_dtFromDate;

        #endregion "Members"

        #region "Accessors"

        public Int32 iShopId
        {
            get { return this.m_iShopId; }
            set { this.m_iShopId = value; }
        }

        public String strPartnerKey
        {
            get { return this.m_strPartnerKey; }
            set { this.m_strPartnerKey = value; }
        }
        public Nullable<DateTime> dtCreatedDate
        {
            get { return this.m_dtCreatedDate; }
            set { this.m_dtCreatedDate = value; }
        }

        public String strClientKey
        {
            get { return this.m_strClientKey; }
            set { this.m_strClientKey = value; }
        }

        public Nullable<DateTime> dtLastSyncDate
        {
            get { return this.m_dtLastSyncDate; }
            set { this.m_dtLastSyncDate = value; }
        }

        public Nullable<DateTime> dtFromDate
        {
            get { return this.m_dtFromDate; }
            set { this.m_dtFromDate = value; }
        }

        #endregion "Accessors"

        #region "Static Methods"

        private static ConnectAPITableAdapter getAdapter()
        {
            return new ConnectAPITableAdapter();
        }

        public static ConnectAPIBL getDataById(Int32 id)
        {
            SummitDS.ConnectAPIDataTable thisTable = getAdapter().GetData();
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        public static ConnectAPIBL getDataByShopId(Int32 ShopId)
        {
            SummitDS.ConnectAPIDataTable thisTable = getAdapter().GetDataByShopId(ShopId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        public static List<ConnectAPIBL> getDataForAllShops()
        {
            SummitDS.ConnectAPIDataTable thisTable = getAdapter().GetData();
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromTable(thisTable);
            }
            return null;
        }

        private static ConnectAPIBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new ConnectAPIBL(drRow);
            }
            return null;
        }

        private static List<ConnectAPIBL> BuildFromTable(DataTable dtTable)
        {
            List<ConnectAPIBL> _list = new List<ConnectAPIBL>();

            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    ConnectAPIBL _thisMember = new ConnectAPIBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }

        #endregion "Static Methods"

        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.ConnectAPIRow _thisRow = _dataRow as SummitDS.ConnectAPIRow;

            if (_thisRow != null)
            {
                this._ID = _thisRow.Id;
                this.m_iShopId = _thisRow.ShopId;
                this.m_strPartnerKey = _thisRow.IsPartnerKeyNull() ? String.Empty : _thisRow.PartnerKey;
                this.m_strClientKey = _thisRow.IsClientKeyNull() ? String.Empty : _thisRow.ClientKey;
                this.m_dtCreatedDate = _thisRow.IsCreatedDateNull() ? (Nullable<DateTime>)null : _thisRow.CreatedDate;
                this.m_dtLastSyncDate = _thisRow.IsLastSyncDateNull() ? (Nullable<DateTime>)null : _thisRow.LastSyncDate;
                this.m_dtFromDate = _thisRow.IsFromDateNull() ? (Nullable<DateTime>)null : _thisRow.FromDate;

                _rowToSave = _thisRow;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.ConnectAPIDataTable _thisTable = new SummitDS.ConnectAPIDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewConnectAPIRow();
            SummitDS.ConnectAPIRow _dataRow = _rowToSave as SummitDS.ConnectAPIRow;

            if (_dataRow != null)
            {

                _dataRow.ShopId = m_iShopId;

                if (!String.IsNullOrEmpty(m_strPartnerKey)) _dataRow.PartnerKey = m_strPartnerKey;
                else _dataRow.SetPartnerKeyNull();

                if (!String.IsNullOrEmpty(m_strClientKey)) _dataRow.ClientKey = m_strClientKey;
                else _dataRow.SetClientKeyNull();

                if (m_dtCreatedDate.HasValue) _dataRow.CreatedDate = m_dtCreatedDate.Value;
                else _dataRow.SetCreatedDateNull();

                if (m_dtLastSyncDate.HasValue) _dataRow.LastSyncDate = m_dtLastSyncDate.Value;
                else _dataRow.SetLastSyncDateNull();

                if (m_dtFromDate.HasValue) _dataRow.FromDate = m_dtFromDate.Value;
                else _dataRow.SetLastSyncDateNull();

                if (!IsExisting())
                {

                    _thisTable.AddConnectAPIRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
            SummitDS.ConnectAPIRow thisRow = _rowToSave as SummitDS.ConnectAPIRow;
            if (thisRow != null)
            {
                this._ID = thisRow.Id;
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
