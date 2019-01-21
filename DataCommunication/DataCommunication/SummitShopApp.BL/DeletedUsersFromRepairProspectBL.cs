using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;

namespace SummitShopApp.BL
{
    public class DeletedUsersFromRepairProspectBL : BaseEditableItem
    {
        #region "Constructor"
        public DeletedUsersFromRepairProspectBL()
        {
        }
        public DeletedUsersFromRepairProspectBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }
        #endregion "Constructor"

        #region "Members"
        Nullable<Int32> m_iUseID;
        public Nullable<Int32> User_id
        {
            get { return this.m_iUseID; }
            set { this.m_iUseID = value; }
        }
        Nullable<Int32> m_iShopID;
        public Nullable<Int32> ShopID
        {
            get { return this.m_iShopID; }
            set { this.m_iShopID = value; }
        }
        #endregion "Members"

        #region "overrides"
        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.DeletedUsersFromRepairProspectRow row = _dataRow as SummitDS.DeletedUsersFromRepairProspectRow;
            if (row != null)
            {
                this._ID = row.ID;
                this.m_iUseID = row.user_id;
                this.m_iShopID = row.shop_id;
                _rowToSave = row;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.DeletedUsersFromRepairProspectDataTable _thisTable = new SummitDS.DeletedUsersFromRepairProspectDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewDeletedUsersFromRepairProspectRow();
            SummitDS.DeletedUsersFromRepairProspectRow _dataRow = _rowToSave as SummitDS.DeletedUsersFromRepairProspectRow;

            if (_dataRow != null)
            {
                if (IsExisting())
                {
                    if (m_iUseID.HasValue) _dataRow.user_id = m_iUseID.Value;
                    else _dataRow.Setuser_idNull();
                    if (m_iShopID.HasValue) _dataRow.shop_id = m_iShopID.Value;
                    else _dataRow.Setshop_idNull();
                }
                else
                {
                    if (m_iUseID.HasValue) _dataRow.user_id = User_id.Value;
                    else _dataRow.Setuser_idNull();

                    if (m_iShopID.HasValue) _dataRow.shop_id = ShopID.Value;
                    else _dataRow.Setuser_idNull();

                    _thisTable.AddDeletedUsersFromRepairProspectRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
            SummitDS.DeletedUsersFromRepairProspectRow thisRow = _rowToSave as SummitDS.DeletedUsersFromRepairProspectRow;
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

        #endregion "overrides"

        #region "Static Methods"

        private static DeletedUsersFromRepairProspectTableAdapter getAdapter()
        {
            return new DeletedUsersFromRepairProspectTableAdapter();
        }

        public static Int32 DeleteAllByUserId(Int32 iUserId)
        {
            Object NoOfRowDeleted = getAdapter().DeleteAllByUserId(iUserId);
            Int32 iNoOfRowDeleted = 0;
            if (NoOfRowDeleted != null)
                iNoOfRowDeleted = (Int32)NoOfRowDeleted;
            return iNoOfRowDeleted;
        }

        public static DeletedUsersFromRepairProspectBL getDataByShopId(Int32 iShopId, Int32 iUserId)
        {
            SummitDS.DeletedUsersFromRepairProspectDataTable thisTable = getAdapter().GetDataByShopIdAndUserId(iShopId, iUserId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }


        private static DeletedUsersFromRepairProspectBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new DeletedUsersFromRepairProspectBL(drRow);
            }
            return null;
        }

        private static List<DeletedUsersFromRepairProspectBL> BuildFromTable(DataTable dtTable)
        {
            List<DeletedUsersFromRepairProspectBL> list = new List<DeletedUsersFromRepairProspectBL>();
            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    DeletedUsersFromRepairProspectBL thisMember = new DeletedUsersFromRepairProspectBL(dr);
                    list.Add(thisMember);
                }
            }
            return list;
        }

        # endregion


    }
}
