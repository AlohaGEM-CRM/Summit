using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;
using System.Drawing;

namespace SummitShopApp.BL
{
    public class AIManageRecurringActivityBL : BaseEditableItem
    {
         #region "Constructor"

        public AIManageRecurringActivityBL()
        {

        }

        public AIManageRecurringActivityBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        Int32 m_iShopId;
        Int32 m_iUserId;
        DateTime m_dtDeliveryDate;
        Nullable<Boolean> m_IsProcessed;
        Nullable<DateTime> m_dtProcessedDate;
        #endregion "Members"

        #region "Accessors"

        public Int32 iShopId
        {
            get { return this.m_iShopId; }
            set { this.m_iShopId = value; }
        }

        public Int32 iUserId
        {
            get { return this.m_iUserId; }
            set { this.m_iUserId = value; }
        }

        public DateTime dtDeliveryDate
        {
            get { return this.m_dtDeliveryDate; }
            set { this.m_dtDeliveryDate = value; }
        }


        public Nullable<Boolean> IsProcessed
        {
            get { return this.m_IsProcessed; }
            set { this.m_IsProcessed = value; }
        }

        public Nullable<DateTime> dtProcessedDate
        {
            get { return this.m_dtProcessedDate; }
            set { this.m_dtProcessedDate = value; }
        }

        
        #endregion "Accessors"

        #region "Static Methods"

        private static AIManageRecurringActivityTableAdapter getAdapter()
        {
            return new AIManageRecurringActivityTableAdapter();
        }

        public static List<AIManageRecurringActivityBL> getData()
        {
            SummitDS.AIManageRecurringActivityDataTable thisTable = getAdapter().GetData();
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromTable(thisTable);
            }
            return null;
        }

        private static AIManageRecurringActivityBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new AIManageRecurringActivityBL(drRow);
            }
            return null;
        }

        private static List<AIManageRecurringActivityBL> BuildFromTable(DataTable dtTable)
        {
            List<AIManageRecurringActivityBL> _list = new List<AIManageRecurringActivityBL>();

            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    AIManageRecurringActivityBL _thisMember = new AIManageRecurringActivityBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }

        public static AIManageRecurringActivityBL getDataByShopIdUserIdAndDeliveryDate(Int32 iUserId, Int32 iShopId, DateTime dtDeliveryDate)
        {
            SummitDS.AIManageRecurringActivityDataTable thisTable = getAdapter().GetDataByShopIdUserIdAndDeliveryDate(iUserId, iShopId, dtDeliveryDate);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        public static List<AIManageRecurringActivityBL> GetUnprocessedDataForAddingRecurringInfo()
        {
            SummitDS.AIManageRecurringActivityDataTable thisTable = getAdapter().GetUnprocessedDataForAddingRecurringInfo();
            List<AIManageRecurringActivityBL> lstAIManageRecurringActivityBL = null;

            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                lstAIManageRecurringActivityBL = BuildFromTable(thisTable);
            }
            return lstAIManageRecurringActivityBL;
        }

        #endregion "Static Methods"

        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.AIManageRecurringActivityRow _thisRow = _dataRow as SummitDS.AIManageRecurringActivityRow;

            if (_thisRow != null)
            {
                this._ID = _thisRow.Id;
                this.m_iShopId = _thisRow.ShopId;
                this.m_iUserId = _thisRow.UserId;
                this.m_dtDeliveryDate = _thisRow.DeliveryDate;
                this.m_IsProcessed = _thisRow.IsIsProcessedNull() ? (Nullable<Boolean>)null : _thisRow.IsProcessed;
                this.m_dtProcessedDate = _thisRow.IsProcessedDateNull() ? (Nullable<DateTime>)null : _thisRow.ProcessedDate;

                _rowToSave = _thisRow;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.AIManageRecurringActivityDataTable _thisTable = new SummitDS.AIManageRecurringActivityDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewAIManageRecurringActivityRow();
            SummitDS.AIManageRecurringActivityRow _dataRow = _rowToSave as SummitDS.AIManageRecurringActivityRow;

            if (_dataRow != null)
            {
                if (IsExisting())
                {
                    _dataRow.ShopId = m_iShopId;
                    _dataRow.UserId = m_iUserId;
                    _dataRow.DeliveryDate = m_dtDeliveryDate;

                    if (m_IsProcessed == null) { if (!_dataRow.IsIsProcessedNull()) _dataRow.SetIsProcessedNull(); }
                    else if (_dataRow.IsIsProcessedNull() ? true : _dataRow.IsProcessed != m_IsProcessed) _dataRow.IsProcessed = m_IsProcessed.Value;

                    if (dtProcessedDate.HasValue) _dataRow.ProcessedDate = dtProcessedDate.Value;
                    else _dataRow.SetProcessedDateNull();

                }
                else
                {
                    _dataRow.ShopId = m_iShopId;
                    _dataRow.UserId = m_iUserId;
                    _dataRow.DeliveryDate = m_dtDeliveryDate;

                    if (m_IsProcessed == null) { if (!_dataRow.IsIsProcessedNull()) _dataRow.SetIsProcessedNull(); }
                    else if (_dataRow.IsIsProcessedNull() ? true : _dataRow.IsProcessed != m_IsProcessed) _dataRow.IsProcessed = m_IsProcessed.Value;

                    if (dtProcessedDate.HasValue) _dataRow.ProcessedDate = dtProcessedDate.Value;
                    else _dataRow.SetProcessedDateNull();

                    _thisTable.AddAIManageRecurringActivityRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
            SummitDS.AIManageRecurringActivityRow thisRow = _rowToSave as SummitDS.AIManageRecurringActivityRow;
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
