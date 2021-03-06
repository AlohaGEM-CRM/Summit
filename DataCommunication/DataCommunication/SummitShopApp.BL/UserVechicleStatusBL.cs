﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitShopApp.DAL.SummitDSTableAdapters;
using SummitShopApp.DAL;
using System.Data;

namespace SummitShopApp.BL
{
    public class UserVehicleStatusBL : BaseEditableItem
    {
        #region "Constructor"

        public UserVehicleStatusBL()
        {
        }

        public UserVehicleStatusBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        Nullable<Int32> m_iVehicleId;
        Nullable<DateTime> m_dtDateIn;
        Nullable<DateTime> m_dtDateOut;
        Nullable<Int32> m_iUserId;
        Nullable<Int32> m_iVehicleStatusId;
        Nullable<DateTime> m_dtLastUpdatedStatusDate;
        Nullable<DateTime> m_dtDeliveryDate;
        Nullable<DateTime> m_dtRepair_Start_Date;
        Nullable<DateTime> m_dtActual_Delivery_Date;
        Nullable<DateTime> m_dtFile_Import_Date;
        Nullable<DateTime> m_dtFile_Import_Time;
        String m_strFile_Status;
        Nullable<Int32> m_iETA_Hours;
        Nullable<Int32> m_iRO_Hours;
        Nullable<Int32> m_bIsRead;
        #endregion "Members"

        #region "Accessors"

        public Nullable<Int32> iVehicleId
        {
            get { return this.m_iVehicleId; }
            set { this.m_iVehicleId = value; }
        }

        public Nullable<DateTime> dtDateIn
        {
            get { return this.m_dtDateIn; }
            set { this.m_dtDateIn = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }

        public Nullable<DateTime> dtDateOut
        {
            get { return this.m_dtDateOut; }
            set { this.m_dtDateOut = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }

        public Nullable<Int32> iUserId
        {
            get { return this.m_iUserId; }
            set { this.m_iUserId = value; }
        }

        public Nullable<Int32> iVehicleStatusId
        {
            get { return this.m_iVehicleStatusId; }
            set { this.m_iVehicleStatusId = value; }
        }

        public Nullable<DateTime> dtLastUpdatedStatusDate
        {
            get { return this.m_dtLastUpdatedStatusDate; }
            set { this.m_dtLastUpdatedStatusDate = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }

        public Nullable<DateTime> dtDeliveryDate
        {
            get { return this.m_dtDeliveryDate; }
            set { this.m_dtDeliveryDate = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }


        public Nullable<DateTime> dtRepair_Start_Date
        {
            get { return this.m_dtRepair_Start_Date; }
            set { this.m_dtRepair_Start_Date = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }

        public Nullable<DateTime> dtActual_Delivery_Date
        {
            get { return this.m_dtActual_Delivery_Date; }
            set { this.m_dtActual_Delivery_Date = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }

        public Nullable<DateTime> dtFile_Import_Date
        {
            get { return this.m_dtFile_Import_Date; }
            set { this.m_dtFile_Import_Date = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }

        public Nullable<DateTime> dtFile_Import_Time
        {
            get { return this.m_dtFile_Import_Time; }
            set { this.m_dtFile_Import_Time = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }

        public String strFile_Status
        {
            get { return this.m_strFile_Status; }
            set { this.m_strFile_Status = value; }
        }

        public Nullable<Int32> iETA_Hours
        {
            get { return this.m_iETA_Hours; }
            set { this.m_iETA_Hours = value; }
        }


        public Nullable<Int32> iRO_Hours
        {
            get { return this.m_iRO_Hours; }
            set { this.m_iRO_Hours = value; }
        }

        public Nullable<Int32> bIsRead
        {
            get { return this.m_bIsRead; }
            set { this.m_bIsRead = value; }
        }

        #endregion "Accessors"

        #region "Static Methods"

        private static UserVehicleStatusTableAdapter getAdapter()
        {
            return new UserVehicleStatusTableAdapter();
        }

        public static UserVehicleStatusBL getDataById(Int32 id)
        {
            SummitDS.UserVehicleStatusDataTable thisTable = getAdapter().GetDataById(id);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        public static UserVehicleStatusBL getDataByVehicleId(Int32 iVehicleId)
        {
            SummitDS.UserVehicleStatusDataTable thisTable = getAdapter().GetDataByVehicleId(iVehicleId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        private static UserVehicleStatusBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new UserVehicleStatusBL(drRow);
            }
            return null;
        }

        #endregion "Static Methods"

        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.UserVehicleStatusRow _thisRow = _dataRow as SummitDS.UserVehicleStatusRow;

            if (_thisRow != null)
            {
                this._ID = _thisRow.ID;
                this.iUserId = _thisRow.IsUser_idNull() ? (Nullable<Int32>)null : _thisRow.User_id;
                this.dtDateIn = _thisRow.IsDateInNull() ? (Nullable<DateTime>)null : _thisRow.DateIn;
                this.dtDateOut = _thisRow.IsDateOutNull() ? (Nullable<DateTime>)null : _thisRow.DateOut;
                this.iVehicleId = _thisRow.IsVehicle_idNull() ? (Nullable<Int32>)null : _thisRow.Vehicle_id;
                this.iVehicleStatusId = _thisRow.IsVehicleStatusNull() ? (Nullable<Int32>)null : _thisRow.VehicleStatus;
                this.dtLastUpdatedStatusDate = _thisRow.IsLast_status_updated_dateNull() ? (Nullable<DateTime>)null : _thisRow.Last_status_updated_date;
                this.dtDeliveryDate = _thisRow.IsDeliveryDateNull() ? (Nullable<DateTime>)null : _thisRow.DeliveryDate;
                this.dtActual_Delivery_Date = _thisRow.IsActual_Delivery_DateNull() ? (Nullable<DateTime>)null : _thisRow.Actual_Delivery_Date;
                this.dtRepair_Start_Date = _thisRow.IsRepair_Start_DateNull() ? (Nullable<DateTime>)null : _thisRow.Repair_Start_Date;
                this.dtFile_Import_Date = _thisRow.IsFile_Import_DateNull() ? (Nullable<DateTime>)null : _thisRow.File_Import_Date;
                this.dtFile_Import_Time = _thisRow.IsFile_Import_TimeNull() ? (Nullable<DateTime>)null : _thisRow.File_Import_Time;
                this.strFile_Status = _thisRow.IsFile_StatusNull() ? String.Empty : _thisRow.File_Status;
                this.iETA_Hours = _thisRow.IsETA_HoursNull() ? (Nullable<Int32>)null : _thisRow.ETA_Hours;
                this.iRO_Hours = _thisRow.IsRO_HoursNull() ? (Nullable<Int32>)null : _thisRow.RO_Hours;
                this.bIsRead = _thisRow.IsIsReadNull() ? (Nullable<Int32>)null : _thisRow.IsRead;
                //  this.m_dt_ts = _thisRow.Is_tsNull() ? (Nullable<DateTime>) null : _thisRow._ts ;                                
                _rowToSave = _thisRow;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.UserVehicleStatusDataTable _thisTable = new SummitDS.UserVehicleStatusDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewUserVehicleStatusRow();
            SummitDS.UserVehicleStatusRow _dataRow = _rowToSave as SummitDS.UserVehicleStatusRow;

            if (_dataRow != null)
            {
                if (IsExisting())
                {
                    if (!m_iVehicleId.HasValue) { if (!_dataRow.IsVehicle_idNull()) _dataRow.SetVehicle_idNull(); }
                    else if (_dataRow.IsVehicle_idNull() ? true : _dataRow.Vehicle_id != m_iVehicleId.Value) _dataRow.Vehicle_id = m_iVehicleId.Value;

                    if (!m_dtDateIn.HasValue) { if (!_dataRow.IsDateInNull()) _dataRow.SetDateInNull(); }
                    else if (_dataRow.IsDateInNull() ? true : _dataRow.DateIn != m_dtDateIn.Value) _dataRow.DateIn = m_dtDateIn.Value;

                    if (!m_dtDateOut.HasValue) { if (!_dataRow.IsDateOutNull()) _dataRow.SetDateOutNull(); }
                    else if (_dataRow.IsDateOutNull() ? true : _dataRow.DateOut != m_dtDateOut.Value) _dataRow.DateOut = m_dtDateOut.Value;

                    if (!m_iVehicleStatusId.HasValue) { if (!_dataRow.IsVehicleStatusNull()) _dataRow.SetVehicleStatusNull(); }
                    else if (_dataRow.IsVehicleStatusNull() ? true : _dataRow.VehicleStatus != m_iVehicleStatusId.Value) _dataRow.VehicleStatus = m_iVehicleStatusId.Value;

                    if (!m_iUserId.HasValue) { if (!_dataRow.IsUser_idNull()) _dataRow.SetUser_idNull(); }
                    else if (_dataRow.IsUser_idNull() ? true : _dataRow.User_id != m_iUserId.Value) _dataRow.User_id = m_iUserId.Value;

                    if (!m_dtLastUpdatedStatusDate.HasValue) { if (!_dataRow.IsLast_status_updated_dateNull()) _dataRow.SetLast_status_updated_dateNull(); }
                    else if (_dataRow.IsLast_status_updated_dateNull() ? true : _dataRow.Last_status_updated_date != m_dtLastUpdatedStatusDate.Value) _dataRow.Last_status_updated_date = m_dtLastUpdatedStatusDate.Value;

                    if (!m_dtDeliveryDate.HasValue) { if (!_dataRow.IsDeliveryDateNull()) _dataRow.SetDeliveryDateNull(); }
                    else if (_dataRow.IsDeliveryDateNull() ? true : _dataRow.DeliveryDate != m_dtDeliveryDate.Value) _dataRow.DeliveryDate = m_dtDeliveryDate.Value;

                    if (!m_dtRepair_Start_Date.HasValue) { if (!_dataRow.IsRepair_Start_DateNull()) _dataRow.SetRepair_Start_DateNull(); }
                    else if (_dataRow.IsRepair_Start_DateNull() ? true : _dataRow.Repair_Start_Date != m_dtRepair_Start_Date.Value) _dataRow.Repair_Start_Date = m_dtRepair_Start_Date.Value;

                    if (!m_dtActual_Delivery_Date.HasValue) { if (!_dataRow.IsActual_Delivery_DateNull()) _dataRow.SetActual_Delivery_DateNull(); }
                    else if (_dataRow.IsActual_Delivery_DateNull() ? true : _dataRow.Actual_Delivery_Date != m_dtActual_Delivery_Date.Value) _dataRow.Actual_Delivery_Date = m_dtActual_Delivery_Date.Value;


                    if (!m_dtFile_Import_Date.HasValue) { if (!_dataRow.IsFile_Import_DateNull()) _dataRow.SetFile_Import_DateNull(); }
                    else if (_dataRow.IsFile_Import_DateNull() ? true : _dataRow.File_Import_Date != m_dtFile_Import_Date.Value) _dataRow.File_Import_Date = m_dtFile_Import_Date.Value;

                    if (!m_dtFile_Import_Time.HasValue) { if (!_dataRow.IsFile_Import_TimeNull()) _dataRow.SetFile_Import_TimeNull(); }
                    else if (_dataRow.IsFile_Import_TimeNull() ? true : _dataRow.File_Import_Time != m_dtFile_Import_Time.Value) _dataRow.File_Import_Time = m_dtFile_Import_Time.Value;

                    if (String.IsNullOrEmpty(m_strFile_Status)) { if (!_dataRow.IsFile_StatusNull()) _dataRow.SetFile_StatusNull(); }
                    else if (_dataRow.IsFile_StatusNull() ? true : _dataRow.File_Status != m_strFile_Status) _dataRow.File_Status = m_strFile_Status;

                    if (!m_iRO_Hours.HasValue) { if (!_dataRow.IsRO_HoursNull()) _dataRow.SetRO_HoursNull(); }
                    else if (_dataRow.IsRO_HoursNull() ? true : _dataRow.RO_Hours != m_iRO_Hours.Value) _dataRow.RO_Hours = m_iRO_Hours.Value;

                    if (!m_iETA_Hours.HasValue) { if (!_dataRow.IsETA_HoursNull()) _dataRow.SetETA_HoursNull(); }
                    else if (_dataRow.IsETA_HoursNull() ? true : _dataRow.ETA_Hours != m_iETA_Hours.Value) _dataRow.ETA_Hours = m_iETA_Hours.Value;

                    if (m_bIsRead.HasValue) _dataRow.IsRead = m_bIsRead.Value;
                    else _dataRow.SetIsReadNull();
                }
                else
                {
                    if (!m_iVehicleId.HasValue) { if (!_dataRow.IsVehicle_idNull()) _dataRow.SetVehicle_idNull(); }
                    else if (_dataRow.IsVehicle_idNull() ? true : _dataRow.Vehicle_id != m_iVehicleId.Value) _dataRow.Vehicle_id = m_iVehicleId.Value;

                    if (!m_dtDateIn.HasValue) { if (!_dataRow.IsDateInNull()) _dataRow.SetDateInNull(); }
                    else if (_dataRow.IsDateInNull() ? true : _dataRow.DateIn != m_dtDateIn.Value) _dataRow.DateIn = m_dtDateIn.Value;

                    if (!m_dtDateOut.HasValue) { if (!_dataRow.IsDateOutNull()) _dataRow.SetDateOutNull(); }
                    else if (_dataRow.IsDateOutNull() ? true : _dataRow.DateOut != m_dtDateOut.Value) _dataRow.DateOut = m_dtDateOut.Value;

                    if (!m_iVehicleStatusId.HasValue) { if (!_dataRow.IsVehicleStatusNull()) _dataRow.SetVehicleStatusNull(); }
                    else if (_dataRow.IsVehicleStatusNull() ? true : _dataRow.VehicleStatus != m_iVehicleStatusId.Value) _dataRow.VehicleStatus = m_iVehicleStatusId.Value;

                    if (!m_iUserId.HasValue) { if (!_dataRow.IsUser_idNull()) _dataRow.SetUser_idNull(); }
                    else if (_dataRow.IsUser_idNull() ? true : _dataRow.User_id != m_iUserId.Value) _dataRow.User_id = m_iUserId.Value;

                    if (!m_dtLastUpdatedStatusDate.HasValue) { if (!_dataRow.IsLast_status_updated_dateNull()) _dataRow.SetLast_status_updated_dateNull(); }
                    else if (_dataRow.IsLast_status_updated_dateNull() ? true : _dataRow.Last_status_updated_date != m_dtLastUpdatedStatusDate.Value) _dataRow.Last_status_updated_date = m_dtLastUpdatedStatusDate.Value;

                    if (!m_dtDeliveryDate.HasValue) { if (!_dataRow.IsDeliveryDateNull()) _dataRow.SetDeliveryDateNull(); }
                    else if (_dataRow.IsDeliveryDateNull() ? true : _dataRow.DeliveryDate != m_dtDeliveryDate.Value) _dataRow.DeliveryDate = m_dtDeliveryDate.Value;

                    if (!m_dtRepair_Start_Date.HasValue) { if (!_dataRow.IsRepair_Start_DateNull()) _dataRow.SetRepair_Start_DateNull(); }
                    else if (_dataRow.IsRepair_Start_DateNull() ? true : _dataRow.Repair_Start_Date != m_dtRepair_Start_Date.Value) _dataRow.Repair_Start_Date = m_dtRepair_Start_Date.Value;

                    if (!m_dtActual_Delivery_Date.HasValue) { if (!_dataRow.IsActual_Delivery_DateNull()) _dataRow.SetActual_Delivery_DateNull(); }
                    else if (_dataRow.IsActual_Delivery_DateNull() ? true : _dataRow.Actual_Delivery_Date != m_dtActual_Delivery_Date.Value) _dataRow.Actual_Delivery_Date = m_dtActual_Delivery_Date.Value;


                    if (!m_dtFile_Import_Date.HasValue) { if (!_dataRow.IsFile_Import_DateNull()) _dataRow.SetFile_Import_DateNull(); }
                    else if (_dataRow.IsFile_Import_DateNull() ? true : _dataRow.File_Import_Date != m_dtFile_Import_Date.Value) _dataRow.File_Import_Date = m_dtFile_Import_Date.Value;

                    if (!m_dtFile_Import_Time.HasValue) { if (!_dataRow.IsFile_Import_TimeNull()) _dataRow.SetFile_Import_TimeNull(); }
                    else if (_dataRow.IsFile_Import_TimeNull() ? true : _dataRow.File_Import_Time != m_dtFile_Import_Time.Value) _dataRow.File_Import_Time = m_dtFile_Import_Time.Value;

                    if (String.IsNullOrEmpty(m_strFile_Status)) { if (!_dataRow.IsFile_StatusNull()) _dataRow.SetFile_StatusNull(); }
                    else if (_dataRow.IsFile_StatusNull() ? true : _dataRow.File_Status != m_strFile_Status) _dataRow.File_Status = m_strFile_Status;

                    if (!m_iRO_Hours.HasValue) { if (!_dataRow.IsRO_HoursNull()) _dataRow.SetRO_HoursNull(); }
                    else if (_dataRow.IsRO_HoursNull() ? true : _dataRow.RO_Hours != m_iRO_Hours.Value) _dataRow.RO_Hours = m_iRO_Hours.Value;

                    if (!m_iETA_Hours.HasValue) { if (!_dataRow.IsETA_HoursNull()) _dataRow.SetETA_HoursNull(); }
                    else if (_dataRow.IsETA_HoursNull() ? true : _dataRow.ETA_Hours != m_iETA_Hours.Value) _dataRow.ETA_Hours = m_iETA_Hours.Value;

                    if (m_bIsRead.HasValue) _dataRow.IsRead = m_bIsRead.Value;
                    else _dataRow.SetIsReadNull();
                    _thisTable.AddUserVehicleStatusRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
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
