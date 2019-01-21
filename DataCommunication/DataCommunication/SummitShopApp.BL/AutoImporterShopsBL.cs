using System;
using System.Collections.Generic;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;
using System.Data;

namespace SummitShopApp.BL
{
    public class AutoImporterShopsBL : BaseEditableItem
    {
        #region "Constructor"

        public AutoImporterShopsBL()
        {

        }

        public AutoImporterShopsBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"
        #region "Members"

        Nullable<Int32> m_iShopId;
        Nullable<DateTime> m_dtSyncDateTime;
        Nullable<DateTime> m_dtSendMailDateTime;
        Nullable<Boolean> m_bIsEmailSend;



        #endregion "Members"
        #region "Accessors"

        public Nullable<DateTime> dtSyncDateTime
        {
            get { return this.m_dtSyncDateTime; }
            set { this.m_dtSyncDateTime = value; }
        }
        public Nullable<DateTime> dtSendMailDateTime
        {
            get { return this.m_dtSendMailDateTime; }
            set { this.m_dtSendMailDateTime = value; }
        }
        public Nullable<Boolean> bIsEmailSend
        {
            get { return this.m_bIsEmailSend; }
            set { this.m_bIsEmailSend = value; }
        }
        public Nullable<Int32> iShopId
        {
            get { return this.m_iShopId; }
            set { this.m_iShopId = value; }
        }

        #endregion "Accessors"
        #region "Static Methods"

        private static AutoImporterShopsTableAdapter getAdapter()
        {
            return new AutoImporterShopsTableAdapter();
        }

        public static List<AutoImporterShopsBL> getData()
        {
            SummitDS.AutoImporterShopsDataTable thisTable = getAdapter().GetData();
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromTable(thisTable);
            }
            return null;
        }

        public static List<AutoImporterShopsBL> getShopIdsByDateDiff()
        {
            SummitDS.AutoImporterShopsDataTable thisTable = getAdapter().GetShopIdsByDateDiff();
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromTable(thisTable);
            }
            return null;
        }

        private static AutoImporterShopsBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new AutoImporterShopsBL(drRow);
            }
            return null;
        }

        private static List<AutoImporterShopsBL> BuildFromTable(DataTable dtTable)
        {
            List<AutoImporterShopsBL> _list = new List<AutoImporterShopsBL>();

            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    AutoImporterShopsBL _thisMember = new AutoImporterShopsBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }

        #endregion "Static Methods"
        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.AutoImporterShopsRow _thisRow = _dataRow as SummitDS.AutoImporterShopsRow;

            if (_thisRow != null)
            {
                this._ID = _thisRow.ID;
                this.m_bIsEmailSend = _thisRow.IsIsEmailSendNull() ? (Nullable<Boolean>)null : _thisRow.IsEmailSend;
                this.m_iShopId = _thisRow.IsShopIDNull() ? (Nullable<Int32>)null : _thisRow.ShopID;
                this.m_dtSyncDateTime = _thisRow.IsSyncDateTimeNull() ? (Nullable<DateTime>)null : _thisRow.SyncDateTime;
                this.m_dtSendMailDateTime = _thisRow.IsSendMailDateNull() ? (Nullable<DateTime>)null : _thisRow.SendMailDate;
                _rowToSave = _thisRow;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.AutoImporterShopsDataTable _thisTable = new SummitDS.AutoImporterShopsDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewAutoImporterShopsRow();
            SummitDS.AutoImporterShopsRow _dataRow = _rowToSave as SummitDS.AutoImporterShopsRow;

            if (_dataRow != null)
            {
                if (IsExisting())
                {
                    if (m_iShopId == null) { if (!_dataRow.IsShopIDNull()) _dataRow.SetShopIDNull(); }
                    else if (_dataRow.IsShopIDNull() ? true : _dataRow.ShopID != m_iShopId) _dataRow.ShopID = m_iShopId.Value;

                    if (m_dtSyncDateTime == null) { if (!_dataRow.IsSyncDateTimeNull()) _dataRow.SetSyncDateTimeNull(); }
                    else if (_dataRow.IsSyncDateTimeNull() ? true : _dataRow.SyncDateTime != m_dtSyncDateTime) _dataRow.SyncDateTime = m_dtSyncDateTime.Value;

                    if (m_bIsEmailSend == null) { if (!_dataRow.IsIsEmailSendNull()) _dataRow.SetIsEmailSendNull(); }
                    else if (_dataRow.IsIsEmailSendNull() ? true : _dataRow.IsEmailSend != m_bIsEmailSend) _dataRow.IsEmailSend = m_bIsEmailSend.Value;

                    if (m_dtSendMailDateTime == null) { if (!_dataRow.IsSendMailDateNull()) _dataRow.SetSendMailDateNull(); }
                    else if (_dataRow.IsSendMailDateNull() ? true : _dataRow.SendMailDate != m_dtSendMailDateTime) _dataRow.SendMailDate = m_dtSendMailDateTime.Value;
                }
                else
                {
                    if (m_iShopId == null) { if (!_dataRow.IsShopIDNull()) _dataRow.SetShopIDNull(); }
                    else if (_dataRow.IsShopIDNull() ? true : _dataRow.ShopID != m_iShopId) _dataRow.ShopID = m_iShopId.Value;

                    if (m_dtSyncDateTime == null) { if (!_dataRow.IsSyncDateTimeNull()) _dataRow.SetSyncDateTimeNull(); }
                    else if (_dataRow.IsSyncDateTimeNull() ? true : _dataRow.SyncDateTime != m_dtSyncDateTime) _dataRow.SyncDateTime = m_dtSyncDateTime.Value;

                    if (m_bIsEmailSend == null) { if (!_dataRow.IsIsEmailSendNull()) _dataRow.SetIsEmailSendNull(); }
                    else if (_dataRow.IsIsEmailSendNull() ? true : _dataRow.IsEmailSend != m_bIsEmailSend) _dataRow.IsEmailSend = m_bIsEmailSend.Value;

                    if (m_dtSendMailDateTime == null) { if (!_dataRow.IsSendMailDateNull()) _dataRow.SetSendMailDateNull(); }
                    else if (_dataRow.IsSendMailDateNull() ? true : _dataRow.SendMailDate != m_dtSendMailDateTime) _dataRow.SendMailDate = m_dtSendMailDateTime.Value;

                    _thisTable.AddAutoImporterShopsRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
            SummitDS.AutoImporterShopsRow thisRow = _rowToSave as SummitDS.AutoImporterShopsRow;
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

        public static AutoImporterShopsBL getDataByShopId(Int32 iShopId)
        {
            SummitDS.AutoImporterShopsDataTable thisTable = getAdapter().getDataByShopID(iShopId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }
    }
}
