using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;

namespace SummitShopApp.BL
{
    public class MessageBL : BaseEditableItem
    {
        #region "Constructor"

        public MessageBL()
        {

        }

        public MessageBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        Nullable<DateTime> m_dtMessageTime;
        String m_strMessage;
        String m_strAttachment;
        Nullable<Int32> m_iType;
        Nullable<Int32> m_iShopID;
        Nullable<Int32> m_iPhoneUserID;
        String m_strLocationLink;
        Nullable<Boolean> m_bIsRead;
        Nullable<double> m_fLatitude;
        Nullable<double> m_fLongitude;
        Nullable<Int32> m_iPrivateLabelID;

        #endregion "Members"

        #region "Accessors"

        public Nullable<DateTime> dtMessageTime
        {
            get { return this.m_dtMessageTime; }
            set { this.m_dtMessageTime = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }

        public String strMessage
        {
            get { return this.m_strMessage; }
            set { this.m_strMessage = value; }
        }

        public String strAttachment
        {
            get { return this.m_strAttachment; }
            set { this.m_strAttachment = value; }
        }

        public Nullable<Int32> iType
        {
            get { return this.m_iType; }
            set { this.m_iType = value; }
        }

        public Nullable<Int32> iShopID
        {
            get { return this.m_iShopID; }
            set { this.m_iShopID = value; }
        }

        public Nullable<Int32> iPhoneUserID
        {
            get { return this.m_iPhoneUserID; }
            set { this.m_iPhoneUserID = value; }
        }

        public String strLocationLink
        {
            get { return this.m_strLocationLink; }
            set { this.m_strLocationLink = value; }
        }

        public Nullable<Boolean> bIsRead
        {
            get { return this.m_bIsRead; }
            set { this.m_bIsRead = value; }
        }

        public Nullable<double> fLatitude
        {
            get { return this.m_fLatitude; }
            set { this.m_fLatitude = value; }
        }

        public Nullable<double> fLongitude
        {
            get { return this.m_fLongitude; }
            set { this.m_fLongitude = value; }
        }
        public Nullable<Int32> iPrivateLabelID
        {
            get { return this.m_iPrivateLabelID; }
            set { this.m_iPrivateLabelID = value; }
        }

        #endregion "Accessors"

        #region "Static Methods"

        private static MessageTableAdapter getAdapter()
        {
            return new MessageTableAdapter();
        }

        public static Int32 getCountUnreadMessages(Int32 iShopID, Int32 iMessageType)
        {
            SummitDS.MessageDataTable thisTable = getAdapter().GetUnreadMessages(iShopID, iMessageType);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return thisTable.Rows.Count;
            }
            return 0;
        }

        public static List<MessageBL> getUnreadMessages(Int32 iShopID, Int32 iMessageType)
        {
            SummitDS.MessageDataTable thisTable = getAdapter().GetUnreadMessages(iShopID, iMessageType);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromTable(thisTable);
            }
            return null;
        }

        public static MessageBL getDataById(Int32 iMessageId)
        {
            SummitDS.MessageDataTable thisTable = getAdapter().GetDataById(iMessageId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        public static List<MessageBL> getDataByUserIdAndType(Int32 iUserId, Int32 iType)
        {
            SummitDS.MessageDataTable thisTable = getAdapter().GetDataByUserIdAndType(iUserId, iType);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromTable(thisTable);
            }
            return null;
        }

        public static MessageBL getDataByUserShopIdAndType(Int32 iUserId, Int32 iShopId, Int32 iType)
        {
            SummitDS.MessageDataTable thisTable = getAdapter().GetDataByUserShopIdAndType(iUserId, iShopId, iType);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        private static MessageBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new MessageBL(drRow);
            }
            return null;
        }

        private static List<MessageBL> BuildFromTable(DataTable dtTable)
        {
            List<MessageBL> _list = new List<MessageBL>();

            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    MessageBL _thisMember = new MessageBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }

        #endregion "Static Methods"

        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.MessageRow _thisRow = _dataRow as SummitDS.MessageRow;

            if (_thisRow != null)
            {
                this._ID = _thisRow.ID;
                this.m_dtMessageTime = _thisRow.IsmessageTimeNull() ? (Nullable<DateTime>)null : _thisRow.messageTime;
                this.m_strMessage = _thisRow.IsmessageNull() ? String.Empty : _thisRow.message;
                this.m_strAttachment = _thisRow.IsattachemetNull() ? String.Empty : _thisRow.attachemet;
                this.m_iType = _thisRow.IstypeNull() ? (Nullable<Int32>)null : _thisRow.type;
                this.m_iShopID = _thisRow.Isshop_idNull() ? (Nullable<Int32>)null : _thisRow.shop_id;
                this.m_iPhoneUserID = _thisRow.IsphoneUser_idNull() ? (Nullable<Int32>)null : _thisRow.phoneUser_id;
                this.m_strLocationLink = _thisRow.IslocationLinkNull() ? String.Empty : _thisRow.locationLink;
                this.m_bIsRead = _thisRow.Isis_readNull() ? (Nullable<Boolean>)null : _thisRow.is_read;
                this.m_fLatitude = _thisRow.IslatitudeNull() ? (Nullable<double>)null : _thisRow.latitude;
                this.m_fLongitude = _thisRow.IslongitudeNull() ? (Nullable<double>)null : _thisRow.longitude;
                this.iPrivateLabelID = _thisRow.Isprivate_label_idNull() ? (Nullable<Int32>)null : _thisRow.private_label_id;

                //  this.m_dt_ts = _thisRow.Is_tsNull() ? (Nullable<DateTime>) null : _thisRow._ts ;                                
                _rowToSave = _thisRow;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.MessageDataTable _thisTable = new SummitDS.MessageDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewMessageRow();
            SummitDS.MessageRow _dataRow = _rowToSave as SummitDS.MessageRow;

            if (_dataRow != null)
            {
                if (IsExisting())
                {
                    if (!m_dtMessageTime.HasValue) { if (!_dataRow.IsmessageTimeNull()) _dataRow.SetmessageTimeNull(); }
                    else if (_dataRow.IsmessageTimeNull() ? true : _dataRow.messageTime != m_dtMessageTime.Value) _dataRow.messageTime = m_dtMessageTime.Value;

                    if (String.IsNullOrEmpty(m_strMessage)) { if (!_dataRow.IsmessageNull()) _dataRow.SetmessageNull(); }
                    else if (_dataRow.IsmessageNull() ? true : _dataRow.message != m_strMessage) _dataRow.message = m_strMessage;

                    if (String.IsNullOrEmpty(m_strAttachment)) { if (!_dataRow.IsattachemetNull()) _dataRow.SetattachemetNull(); }
                    else if (_dataRow.IsattachemetNull() ? true : _dataRow.attachemet != m_strAttachment) _dataRow.attachemet = m_strAttachment;

                    if (iType.HasValue) _dataRow.type = iType.Value;
                    else _dataRow.SettypeNull();

                    if (iShopID.HasValue) _dataRow.shop_id = iShopID.Value;
                    else _dataRow.Setshop_idNull();

                    if (_dataRow.phoneUser_id != m_iPhoneUserID) _dataRow.phoneUser_id = Convert.ToInt32(m_iPhoneUserID);

                    if (String.IsNullOrEmpty(m_strLocationLink)) { if (!_dataRow.IslocationLinkNull()) _dataRow.SetlocationLinkNull(); }
                    else if (_dataRow.IslocationLinkNull() ? true : _dataRow.locationLink != m_strLocationLink) _dataRow.locationLink = m_strLocationLink;

                    if (bIsRead.HasValue) _dataRow.is_read = bIsRead.Value;
                    else _dataRow.Setis_readNull();

                    if (fLatitude.HasValue) _dataRow.latitude = fLatitude.Value;
                    else _dataRow.SetlatitudeNull();

                    if (fLongitude.HasValue) _dataRow.longitude = fLongitude.Value;
                    else _dataRow.SetlongitudeNull();

                    if (m_iPrivateLabelID.HasValue) _dataRow.private_label_id = iPrivateLabelID.Value;
                    else _dataRow.Setprivate_label_idNull();
                }
                else
                {
                    if (dtMessageTime.HasValue) _dataRow.messageTime = dtMessageTime.Value;
                    else _dataRow.SetmessageTimeNull();

                    if (String.IsNullOrEmpty(strMessage)) _dataRow.SetmessageNull();
                    else _dataRow.message = strMessage;

                    if (String.IsNullOrEmpty(strAttachment)) _dataRow.SetattachemetNull();
                    else _dataRow.attachemet = strAttachment;

                    if (iType.HasValue) _dataRow.type = iType.Value;
                    else _dataRow.SettypeNull();

                    if (iShopID.HasValue) _dataRow.shop_id = iShopID.Value;
                    else _dataRow.Setshop_idNull();

                    if (iPhoneUserID.HasValue) _dataRow.phoneUser_id = iPhoneUserID.Value;
                    else _dataRow.SetphoneUser_idNull();

                    if (String.IsNullOrEmpty(strLocationLink)) _dataRow.SetlocationLinkNull();
                    else _dataRow.locationLink = strLocationLink;

                    if (bIsRead.HasValue) _dataRow.is_read = bIsRead.Value;
                    else _dataRow.Setis_readNull();

                    if (fLatitude.HasValue) _dataRow.latitude = fLatitude.Value;
                    else _dataRow.SetlatitudeNull();

                    if (fLongitude.HasValue) _dataRow.longitude = fLongitude.Value;
                    else _dataRow.SetlongitudeNull();

                    if (m_iPrivateLabelID.HasValue) _dataRow.private_label_id = iPrivateLabelID.Value;
                    else _dataRow.Setprivate_label_idNull();

                    _thisTable.AddMessageRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
            SummitDS.MessageRow thisRow = _rowToSave as SummitDS.MessageRow;
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
