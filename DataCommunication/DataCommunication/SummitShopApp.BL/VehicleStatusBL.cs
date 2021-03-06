﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;

namespace SummitShopApp.BL
{
    public class VehicleStatusBL: BaseEditableItem
    {
        #region "Constructor"

        public VehicleStatusBL()
        {

        }

        public VehicleStatusBL(String statusName, Int32 statusId)
        {
            this._ID = statusId;
            this.m_strVehicleStatus = statusName;
        }

        public VehicleStatusBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        String m_strVehicleStatus;
        String m_strMessage;
        Nullable<Boolean> m_bIsActive;
        Nullable<Int32> m_iShopId;
        Nullable<Boolean> m_bSMS;
        Nullable<Boolean> m_bEmail;
        Nullable<Boolean> m_bMoveToMarketing;
        
        #endregion "Members"

        #region "Accessors"

        public String strVehicleStatus
        {
            get { return this.m_strVehicleStatus; }
            set { this.m_strVehicleStatus = value; }
        }

        public String strMessage
        {
            get { return this.m_strMessage; }
            set { this.m_strMessage = value; }
        }

        public Nullable<Boolean> bIsActive
        {
            get { return this.m_bIsActive; }
            set { this.m_bIsActive = value; }
        }

        public Nullable<Int32> iShopId
        {
            get { return this.m_iShopId; }
            set { this.m_iShopId = value; }
        }

        public Nullable<Boolean> bSMS
        {
            get { return this.m_bSMS; }
            set { this.m_bSMS = value; }
        }

        public Nullable<Boolean> bEmail
        {
            get { return this.m_bEmail; }
            set { this.m_bEmail = value; }
        }

       
        public Nullable<Boolean> bMoveToMarketing
        {
            get { return this.m_bMoveToMarketing; }
            set { this.m_bMoveToMarketing = value; }
        }
       
        #endregion "Accessors"

        #region "Static Methods"

        private static VehicleStatusTableAdapter getAdapter()
        {
            return new VehicleStatusTableAdapter();
        }

       
        public static List<VehicleStatusBL> getDataByShopId(Int32 iShopId)
        {
            SummitDS.VehicleStatusDataTable thisTable = getAdapter().GetDataByShopId(iShopId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromTable(thisTable);
            }
            return null;
        }

        public static VehicleStatusBL getDataById(Int32 iVahicleStatusId)
        {
            SummitDS.VehicleStatusDataTable thisTable = getAdapter().GetDataById(iVahicleStatusId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        public static VehicleStatusBL getDataByShopIdAndStatus(Int32 iShopId, String strVahicleStatus)
        {
            SummitDS.VehicleStatusDataTable thisTable = getAdapter().GetDataByShopIdAndStatus(iShopId,strVahicleStatus);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        public static List<VehicleStatusBL> getVehicleStatusByShopId(Int32 iShopId)
        {
            List<VehicleStatusBL> lstVehicleStatus = new List<VehicleStatusBL>();
            try
            {
                int iUnsoldEstimateId = -1;
                int iImpoetedEstimateId = -2;
                int iDelivetedId = 0;

                List<VehicleStatusBL> lstVehicleStatusForShop = VehicleStatusBL.getDataByShopId(iShopId);
                if (lstVehicleStatusForShop != null && lstVehicleStatusForShop.Count > 0)
                {
                    lstVehicleStatus = lstVehicleStatusForShop;
                }
                //check for unsold estimate is exist into database; if not then add with index -1; do same for other 2 also
                VehicleStatusBL objUnsoldEstimate = lstVehicleStatus.Find(_objUnsoldEstimate => _objUnsoldEstimate.strVehicleStatus == "Unsold Estimate");
                if (objUnsoldEstimate == null)
                {
                    VehicleStatusBL _objUnsoldEstimate = new VehicleStatusBL("Unsold Estimate", -1);
                    lstVehicleStatus.Add(_objUnsoldEstimate);
                }
                else
                {
                    //If exist then take the id because the old records may contain old id as -1
                    iUnsoldEstimateId = objUnsoldEstimate.ID;
                }

                VehicleStatusBL objImportedEstimate = lstVehicleStatus.Find(_objImportedEstimate => _objImportedEstimate.strVehicleStatus == "Imported Estimate");
                if (objImportedEstimate == null)
                {
                    VehicleStatusBL _objImportedEstimate = new VehicleStatusBL("Imported Estimate", -2);
                    lstVehicleStatus.Add(_objImportedEstimate);
                }
                else
                {
                    iImpoetedEstimateId = objImportedEstimate.ID;
                }

                VehicleStatusBL objDelivered = lstVehicleStatus.Find(_objDelivered => _objDelivered.strVehicleStatus == "Delivered");
                if (objDelivered == null)
                {
                    VehicleStatusBL _objDelivered = new VehicleStatusBL("Delivered", 0);
                    lstVehicleStatus.Add(_objDelivered);
                }
                else
                {
                    iDelivetedId = objDelivered.ID;
                }

                VehicleStatusBL objImportedEstimtes = lstVehicleStatus.Find(_objVehicleStatus => _objVehicleStatus.strVehicleStatus == "Imported Estimate");
                if (objImportedEstimtes != null)
                {
                    lstVehicleStatus.Remove(objImportedEstimtes);
                    lstVehicleStatus.Insert(0, objImportedEstimtes);
                }
            }
            catch (Exception ex)
            {
              
            }
            return lstVehicleStatus;
        }


        private static VehicleStatusBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new VehicleStatusBL(drRow);
            }
            return null;
        }

        private static List<VehicleStatusBL> BuildFromTable(DataTable dtTable)
        {
            List<VehicleStatusBL> _list = new List<VehicleStatusBL>();

            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    VehicleStatusBL _thisMember = new VehicleStatusBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }

        #endregion "Static Methods"

        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.VehicleStatusRow _thisRow = _dataRow as SummitDS.VehicleStatusRow;

            if (_thisRow != null)
            {
                this._ID = _thisRow.VehicleStatusId;
                this.m_strVehicleStatus = _thisRow.VehicleStatus;
                this.m_strMessage = _thisRow.IsMessageNull() ? String.Empty : _thisRow.Message;
                this.m_bIsActive = _thisRow.IsIsActiveNull() ? (Nullable<Boolean>)null : _thisRow.IsActive;
                this.m_iShopId = _thisRow.Isshop_idNull() ? (Nullable<Int32>)null : _thisRow.shop_id;
                this.m_bSMS = _thisRow.IsSMSNull() ? (Nullable<Boolean>)null : _thisRow.SMS;
                this.m_bEmail = _thisRow.IsEmailNull() ? (Nullable<Boolean>)null : _thisRow.Email;
                this.bMoveToMarketing = _thisRow.IsMoveToMarketingNull() ? (Nullable<Boolean>)null : _thisRow.MoveToMarketing;
                //  this.m_dt_ts = _thisRow.Is_tsNull() ? (Nullable<DateTime>) null : _thisRow._ts ;                                
                _rowToSave = _thisRow;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.VehicleStatusDataTable _thisTable = new SummitDS.VehicleStatusDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewVehicleStatusRow();
            SummitDS.VehicleStatusRow _dataRow = _rowToSave as SummitDS.VehicleStatusRow;

            if (_dataRow != null)
            {
                if (IsExisting())
                {
                    _dataRow.VehicleStatus = m_strVehicleStatus;

                    if (String.IsNullOrEmpty(m_strMessage)) { if (!_dataRow.IsMessageNull()) _dataRow.SetMessageNull(); }
                    else if (_dataRow.IsMessageNull() ? true : _dataRow.Message != m_strMessage) _dataRow.Message = m_strMessage;

                    if (bIsActive.HasValue) _dataRow.IsActive = bIsActive.Value;
                    else _dataRow.SetIsActiveNull();

                    if (iShopId.HasValue) _dataRow.shop_id = iShopId.Value;
                    else _dataRow.Setshop_idNull();

                    if (bSMS.HasValue) _dataRow.SMS= bSMS.Value;
                    else _dataRow.SetSMSNull();

                    if (bEmail.HasValue) _dataRow.Email = bEmail.Value;
                    else _dataRow.SetEmailNull();

                    if (bMoveToMarketing.HasValue) _dataRow.MoveToMarketing = bMoveToMarketing.Value;
                    else _dataRow.SetMoveToMarketingNull();
                }
                else
                {
                    _dataRow.VehicleStatus = m_strVehicleStatus;

                    if (String.IsNullOrEmpty(m_strMessage)) { if (!_dataRow.IsMessageNull()) _dataRow.SetMessageNull(); }
                    else if (_dataRow.IsMessageNull() ? true : _dataRow.Message != m_strMessage) _dataRow.Message = m_strMessage;

                    if (bIsActive.HasValue) _dataRow.IsActive = bIsActive.Value;
                    else _dataRow.SetIsActiveNull();

                    if (iShopId.HasValue) _dataRow.shop_id = iShopId.Value;
                    else _dataRow.Setshop_idNull();

                    if (bSMS.HasValue) _dataRow.SMS = bSMS.Value;
                    else _dataRow.SetSMSNull();

                    if (bEmail.HasValue) _dataRow.Email = bEmail.Value;
                    else _dataRow.SetEmailNull();

                    if (bMoveToMarketing.HasValue) _dataRow.MoveToMarketing = bMoveToMarketing.Value;
                    else _dataRow.SetMoveToMarketingNull();

                    _thisTable.AddVehicleStatusRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
            SummitDS.VehicleStatusRow thisRow = _rowToSave as SummitDS.VehicleStatusRow;
            if (thisRow != null)
            {
                this._ID = thisRow.VehicleStatusId;
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
