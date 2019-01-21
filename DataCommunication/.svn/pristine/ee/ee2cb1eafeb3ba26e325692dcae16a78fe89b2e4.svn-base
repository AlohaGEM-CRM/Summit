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
    public class MarketingUsers : BaseEditableItem
    {
        #region "Constructor"

        public MarketingUsers()
        {

        }

        public MarketingUsers(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }
        #endregion "Constructor"

        #region "Members"

        private Int32 m_iShopId;
        private Int32 m_iUserId;
        private Nullable<Boolean> m_bIsShowInProcess;
        private Nullable<Int32> m_iContactMethod;
        private Int32 m_iVehicleId;
        #endregion "Members"


        #region "Accessors"

        public Int32 iShopId
        {
            get { return m_iShopId; }
            set { m_iShopId = value; }
        }

        public Int32 iUserId
        {
            get { return m_iUserId; }
            set { m_iUserId = value; }
        }

        public Nullable<Boolean> bisShowInProcess
        {
            get { return m_bIsShowInProcess; }
            set { m_bIsShowInProcess = value; }
        }

        public Nullable<Int32> iContactMethod
        {
            get { return m_iContactMethod; }
            set { m_iContactMethod = value; }
        }

        public Int32 iVehicleId
        {
            get { return m_iVehicleId; }
            set { m_iVehicleId = value; }
        }
        #endregion "Accessors"

        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.MarketingUsersRow _thisRow = _dataRow as SummitDS.MarketingUsersRow;

            if (_thisRow != null)
            {
                this.iUserId = _thisRow.user_id;
                this.iShopId = _thisRow.shop_id;
                this.m_bIsShowInProcess = _thisRow.IsisShowInProcessNull() ? (Nullable<Boolean>) null : _thisRow.isShowInProcess ;
                this.m_iContactMethod = _thisRow.IscontactMethodNull() ? (Nullable<Int32>)null : _thisRow.contactMethod;
                this.m_iVehicleId = _thisRow.vehicle_id;
                _rowToSave = _thisRow;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.MarketingUsersDataTable _thisTable = new SummitDS.MarketingUsersDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewMarketingUsersRow();
            SummitDS.MarketingUsersRow _dataRow = _rowToSave as SummitDS.MarketingUsersRow;

            if (_dataRow != null)
            {
                if (IsExisting())
                {
                    if (bisShowInProcess.HasValue) _dataRow.isShowInProcess = bisShowInProcess.Value;
                    else _dataRow.SetisShowInProcessNull();

                    if (iContactMethod.HasValue) _dataRow.contactMethod = iContactMethod.Value;
                    else _dataRow.SetcontactMethodNull();

                    // throw new DataException("Record Already Existed.");
                }
                else
                {
                    _dataRow.user_id = iUserId;
                    _dataRow.shop_id = iShopId;
                    _dataRow.vehicle_id = iVehicleId;
                    if (bisShowInProcess.HasValue) _dataRow.isShowInProcess = bisShowInProcess.Value;
                    else _dataRow.SetisShowInProcessNull();

                    if (iContactMethod.HasValue) _dataRow.contactMethod = iContactMethod.Value;
                    else _dataRow.SetcontactMethodNull();

                    _thisTable.AddMarketingUsersRow(_dataRow);
                }
               
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

        protected override void SetID()
        {
        }

        protected override void DeleteRecord()
        {
        }

        protected override bool IsExisting()
        {
            SummitDS.MarketingUsersDataTable thisTable = new SummitDS.MarketingUsersDataTable();
            thisTable=getAdapter().GetDataByShopUserAndVehicleId(this.iShopId, this.iUserId,this.iVehicleId);
            if (thisTable.Rows.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion "Overrides"

        private static MarketingUsersTableAdapter getAdapter()
        {
            return new MarketingUsersTableAdapter();
        }

        public static List<UserBL> getUsersByShopId(Int32 iShopId)
        {
            SummitDS.MarketingUsersDataTable thisTable = getAdapter().GetDataByShopId(iShopId);
            List<UserBL> lstUsers = new List<UserBL>();
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                List<MarketingUsers> lstMarketingUsers = BuildFromTable(thisTable);
                if (lstMarketingUsers != null)
                {
                    foreach (MarketingUsers marketingUsers in lstMarketingUsers)
                    {
                        UserBL objUser = UserBL.getByActivityId(marketingUsers.iUserId);
                        if (objUser != null)
                        {
                            lstUsers.Add(objUser);
                        }
                    }
                }
            }
            return lstUsers;
        }

        public static MarketingUsers getDataByShopAndUserId(Int32 iShopId, Int32 iUserId)
        {
            SummitDS.MarketingUsersDataTable thisTable = new SummitDS.MarketingUsersDataTable();
            thisTable=getAdapter().GetDataByShopAndUserId(iShopId, iUserId);
            MarketingUsers objMarketingUser = null;
            if (thisTable.Rows.Count > 0)
            {
                objMarketingUser = BuildFromRow(thisTable.Rows[0]);
                return objMarketingUser;
            }
            return objMarketingUser;
        }

        public static MarketingUsers getDataByShopUserAndVehicleId(Int32 iShopId, Int32 iUserId,Int32 iVehicleId)
        {
            SummitDS.MarketingUsersDataTable thisTable = new SummitDS.MarketingUsersDataTable();
            thisTable = getAdapter().GetDataByShopUserAndVehicleId(iShopId, iUserId, iVehicleId);
            MarketingUsers objMarketingUser = null;
            if (thisTable.Rows.Count > 0)
            {
                objMarketingUser = BuildFromRow(thisTable.Rows[0]);
                return objMarketingUser;
            }
            return objMarketingUser;
        }

        public static Boolean isInProcess(Int32 iShopId, Int32 iUserId, Int32 iVehicleId)
        {
            SummitDS.MarketingUsersDataTable thisTable = new SummitDS.MarketingUsersDataTable();
            thisTable = getAdapter().GetDataByShopUserAndVehicleId(iShopId, iUserId, iVehicleId);
            MarketingUsers objMarketingUser = null;
            if (thisTable.Rows.Count > 0)
            {
                objMarketingUser = BuildFromRow(thisTable.Rows[0]);
                if (objMarketingUser.bisShowInProcess != null && objMarketingUser.bisShowInProcess==true)
                    return true;
            }
            return false;
        }

        public static Boolean isInEmailMarketing(Int32 iShopId, Int32 iUserId, Int32 iVehicleId)
        {
            SummitDS.MarketingUsersDataTable thisTable = new SummitDS.MarketingUsersDataTable();
            UserBL objUser = UserBL.getByActivityId(iUserId);
            if (objUser != null)
            {
                if (objUser.bIsShowEmailMarketing != null && objUser.bIsShowEmailMarketing == true)
                {
                    thisTable = getAdapter().GetDataByShopUserAndVehicleId(iShopId, iUserId, iVehicleId);
                    MarketingUsers objMarketingUser = null;
                    if (thisTable.Rows.Count > 0)
                    {
                        objMarketingUser = BuildFromRow(thisTable.Rows[0]);
                        if (objMarketingUser != null)
                            return true;
                    }
                }
            }
            return false;
        }

        private static MarketingUsers BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new MarketingUsers(drRow);
            }
            return null;
        }

        private static List<MarketingUsers> BuildFromTable(DataTable dtTable)
        {
            List<MarketingUsers> _list = new List<MarketingUsers>();

            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    MarketingUsers _thisMember = new MarketingUsers(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }

    }
}