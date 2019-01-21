using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;

namespace SummitShopApp.BL
{
    public class UnreadUsersFromRepairProspectBL : BaseEditableItem
    {
         #region "Constructor"

        public UnreadUsersFromRepairProspectBL()
        {

        }
        public UnreadUsersFromRepairProspectBL(DataRow _drRow)
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
            SummitDS.UnreadUsersFromRepairProspectRow row = _dataRow as SummitDS.UnreadUsersFromRepairProspectRow;

            if (row != null)
            {
                this._ID = row.id;
                this.m_iUseID = row.user_id;
                this.m_iShopID = row.shop_id;
                _rowToSave = row;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.UnreadUsersFromRepairProspectDataTable _thisTable = new SummitDS.UnreadUsersFromRepairProspectDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewUnreadUsersFromRepairProspectRow();
            SummitDS.UnreadUsersFromRepairProspectRow _dataRow = _rowToSave as SummitDS.UnreadUsersFromRepairProspectRow;

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

                    _thisTable.AddUnreadUsersFromRepairProspectRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
            SummitDS.UnreadUsersFromRepairProspectRow thisRow = _rowToSave as SummitDS.UnreadUsersFromRepairProspectRow;
            if (thisRow != null)
            {
                this._ID = thisRow.id;
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

        private static UnreadUsersFromRepairProspectTableAdapter getAdapter()
        {
            return new UnreadUsersFromRepairProspectTableAdapter();
        }

        public static UnreadUsersFromRepairProspectBL getDataByShopId(Int32 iShopId, Int32 iUserId)
        {
            SummitDS.UnreadUsersFromRepairProspectDataTable thisTable = getAdapter().GetDataByShopIdAndUserId(iShopId, iUserId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        public static List<UnreadUsersFromRepairProspectBL> getDataByUnReadUsers(string zipCode,Int32 userID)
        {
            SummitDS.UnreadUsersFromRepairProspectDataTable thisTable = getAdapter().GetUnReadRepairProspects(zipCode, userID);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromTable(thisTable);
            }
            return null;
        }

        public static UnreadUsersFromRepairProspectBL getDataByUserId(Int32 iUserId)
        {
            SummitDS.UnreadUsersFromRepairProspectDataTable thisTable = getAdapter().GetUnreadUserByUserId(iUserId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        private static List<UnreadUsersFromRepairProspectBL> BuildFromTable(DataTable dtTable)
        {
            List<UnreadUsersFromRepairProspectBL> _list = new List<UnreadUsersFromRepairProspectBL>();

            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    UnreadUsersFromRepairProspectBL _thisMember = new UnreadUsersFromRepairProspectBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }


        private static UnreadUsersFromRepairProspectBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new UnreadUsersFromRepairProspectBL(drRow);
            }
            return null;
        }


        # endregion
    }
}
