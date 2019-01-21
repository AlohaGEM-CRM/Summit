using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;
using System.Data;

namespace SummitShopApp.BL
{
    public class CommunicationHistoryBL : BaseEditableItem
    {
        #region "Constructor"

        public CommunicationHistoryBL()
        {

        }

        public CommunicationHistoryBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        # region members
        private Nullable<Int32> m_iShopId;
        private Nullable<Int32> m_iUserId;
        private Nullable<Int32> m_iCommunicationTypeId;
        private String m_strMessageText;
        private Nullable<DateTime> m_dtCreatedDate;
        private String m_strPhone;
        private String m_strEmail;
        private Nullable<Int32> m_iFromAppSection;
        private String m_strMessageId;

        private String m_strDeliveryStatus;
        private Nullable<DateTime> m_dtDeliveryDate;
        #endregion members

        # region Accessors
        public Nullable<Int32> iShopId
        {
            get
            {
                return m_iShopId;
            }
            set
            {
                m_iShopId = value;
            }
        }
        public Nullable<Int32> iUserId
        {
            get
            {
                return m_iUserId;
            }
            set
            {
                m_iUserId = value;
            }
        }
        public Nullable<Int32> iCommunicationTypeId
        {
            get
            {
                return m_iCommunicationTypeId;
            }
            set
            {
                m_iCommunicationTypeId = value;
            }
        }
        public String strMessageText
        {
            get
            {
                return m_strMessageText;
            }
            set
            {
                m_strMessageText = value;
            }
        }
        public Nullable<DateTime> dtCreatedDate
        {
            get
            {
                return m_dtCreatedDate;
            }
            set
            {
                m_dtCreatedDate = value.HasValue ? value.Value.ToUniversalTime() : value;
            }
        }
        public String strPhone
        {
            get
            {
                return m_strPhone;
            }
            set
            {
                m_strPhone = value;
            }
        }
        public String strEmail
        {
            get
            {
                return m_strEmail;
            }
            set
            {
                m_strEmail = value;
            }
        }
        public Nullable<Int32> iFromAppSection
        {
            get
            {
                return m_iFromAppSection;
            }
            set
            {
                m_iFromAppSection = value;
            }
        }
        public String strMessageId
        {
            get
            {
                return m_strMessageId;
            }
            set
            {
                m_strMessageId = value;
            }
        }

        public String strDeliveryStatus
        {
            get
            {
                return m_strDeliveryStatus;
            }
            set
            {
                m_strDeliveryStatus = value;
            }
        }
        public Nullable<DateTime> dtDeliveryDate
        {
            get
            {
                return m_dtDeliveryDate;
            }
            set
            {
                m_dtDeliveryDate = value.HasValue ? value.Value.ToUniversalTime() : value;
            }
        }

        #endregion Accessors

        #region static

        private static CommunicationHistoryTableAdapter getAdapter()
        {
            return new CommunicationHistoryTableAdapter();
        }



        private static CommunicationHistoryBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new CommunicationHistoryBL(drRow);
            }
            return null;
        }

        private static List<CommunicationHistoryBL> BuildFromTable(DataTable dtTable)
        {
            List<CommunicationHistoryBL> _list = new List<CommunicationHistoryBL>();

            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    CommunicationHistoryBL _thisMember = new CommunicationHistoryBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }
        #endregion static

        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.CommunicationHistoryRow _thisRow = _dataRow as SummitDS.CommunicationHistoryRow;

            if (_thisRow != null)
            {
                this._ID = _thisRow.ID;
                this.iShopId = _thisRow.IsShop_IdNull() ? this.iShopId = null : _thisRow.Shop_Id;
                this.iUserId = _thisRow.IsUser_IdNull() ? this.iUserId = null : _thisRow.User_Id;
                this.strMessageText = _thisRow.IsMessageTextNull() ? String.Empty : _thisRow.MessageText;
                this.iCommunicationTypeId = _thisRow.IsCommunicationTypeNull() ? this.iCommunicationTypeId = null : _thisRow.CommunicationType;
                this.dtCreatedDate = _thisRow.IsCreatedDateNull() ? this.dtCreatedDate = null : _thisRow.CreatedDate;
                this.strPhone = _thisRow.IsPhoneNull() ? String.Empty : _thisRow.Phone;
                this.strEmail = _thisRow.IsEmailNull() ? String.Empty : _thisRow.Email;
                this.iFromAppSection = _thisRow.IsFromAppSectionNull() ? this.iFromAppSection = null : _thisRow.FromAppSection;
                this.strMessageId = _thisRow.IsMessageIdNull() ? String.Empty : _thisRow.MessageId;
                this.strDeliveryStatus = _thisRow.IsDeliveryStatusNull() ? String.Empty : _thisRow.DeliveryStatus;
                this.dtDeliveryDate = _thisRow.IsDeliveryDateNull() ? this.dtDeliveryDate = null : _thisRow.DeliveryDate;
                _rowToSave = _thisRow;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.CommunicationHistoryDataTable _thisTable = new SummitDS.CommunicationHistoryDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewCommunicationHistoryRow();
            SummitDS.CommunicationHistoryRow _dataRow = _rowToSave as SummitDS.CommunicationHistoryRow;

            if (_dataRow != null)
            {
                if (IsExisting())
                {
                    //throw new DataException("Can not edit communication history");  

                    if (String.IsNullOrEmpty(m_strDeliveryStatus)) { if (!_dataRow.IsDeliveryStatusNull()) _dataRow.SetDeliveryStatusNull(); }
                    else if (_dataRow.IsDeliveryStatusNull() ? true : _dataRow.DeliveryStatus != m_strDeliveryStatus) _dataRow.DeliveryStatus = m_strDeliveryStatus;

                    if (m_dtDeliveryDate == null) { if (!_dataRow.IsDeliveryDateNull()) _dataRow.SetDeliveryDateNull(); }
                    else if (_dataRow.IsDeliveryDateNull() ? true : _dataRow.DeliveryDate != m_dtDeliveryDate) _dataRow.DeliveryDate = (DateTime)m_dtDeliveryDate;

                }
                else
                {
                    if (m_iShopId == null) { if (!_dataRow.IsShop_IdNull()) _dataRow.SetShop_IdNull(); }
                    else if (_dataRow.IsShop_IdNull() ? true : _dataRow.Shop_Id != m_iShopId) _dataRow.Shop_Id = (Int32)m_iShopId;

                    if (m_iUserId == null) { if (!_dataRow.IsUser_IdNull()) _dataRow.SetUser_IdNull(); }
                    else if (_dataRow.IsUser_IdNull() ? true : _dataRow.User_Id != m_iUserId) _dataRow.User_Id = (Int32)m_iUserId;

                    if (m_iCommunicationTypeId == null) { if (!_dataRow.IsCommunicationTypeNull()) _dataRow.SetCommunicationTypeNull(); }
                    else if (_dataRow.IsCommunicationTypeNull() ? true : _dataRow.CommunicationType != m_iCommunicationTypeId) _dataRow.CommunicationType = (Int32)m_iCommunicationTypeId;

                    if (String.IsNullOrEmpty(m_strMessageText)) { if (!_dataRow.IsMessageTextNull()) _dataRow.SetMessageTextNull(); }
                    else if (_dataRow.IsMessageTextNull() ? true : _dataRow.MessageText != m_strMessageText) _dataRow.MessageText = m_strMessageText;

                    if (m_dtCreatedDate == null) { if (!_dataRow.IsCreatedDateNull()) _dataRow.SetCreatedDateNull(); }
                    else if (_dataRow.IsCreatedDateNull() ? true : _dataRow.CreatedDate != m_dtCreatedDate) _dataRow.CreatedDate = (DateTime)m_dtCreatedDate;

                    if (String.IsNullOrEmpty(m_strPhone)) { if (!_dataRow.IsPhoneNull()) _dataRow.SetPhoneNull(); }
                    else if (_dataRow.IsPhoneNull() ? true : _dataRow.Phone != m_strPhone) _dataRow.Phone = m_strPhone;

                    if (String.IsNullOrEmpty(m_strEmail)) { if (!_dataRow.IsEmailNull()) _dataRow.SetEmailNull(); }
                    else if (_dataRow.IsEmailNull() ? true : _dataRow.Email != m_strEmail) _dataRow.Email = m_strEmail;

                    if (m_iFromAppSection == null) { if (!_dataRow.IsFromAppSectionNull()) _dataRow.SetFromAppSectionNull(); }
                    else if (_dataRow.IsFromAppSectionNull() ? true : _dataRow.FromAppSection != m_iFromAppSection) _dataRow.FromAppSection = (Int32)m_iFromAppSection;

                    if (String.IsNullOrEmpty(m_strMessageId)) { if (!_dataRow.IsMessageIdNull()) _dataRow.SetMessageIdNull(); }
                    else if (_dataRow.IsMessageIdNull() ? true : _dataRow.MessageId != m_strMessageId) _dataRow.MessageId = m_strMessageId;

                    if (String.IsNullOrEmpty(m_strDeliveryStatus)) { if (!_dataRow.IsDeliveryStatusNull()) _dataRow.SetDeliveryStatusNull(); }
                    else if (_dataRow.IsDeliveryStatusNull() ? true : _dataRow.DeliveryStatus != m_strDeliveryStatus) _dataRow.DeliveryStatus = m_strDeliveryStatus;

                    if (m_dtDeliveryDate == null) { if (!_dataRow.IsDeliveryDateNull()) _dataRow.SetDeliveryDateNull(); }
                    else if (_dataRow.IsDeliveryDateNull() ? true : _dataRow.DeliveryDate != m_dtDeliveryDate) _dataRow.DeliveryDate = (DateTime)m_dtDeliveryDate;


                    _thisTable.AddCommunicationHistoryRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
            SummitDS.CommunicationHistoryRow thisRow = _rowToSave as SummitDS.CommunicationHistoryRow;
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
