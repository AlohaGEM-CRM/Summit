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
    public class CampaignBL : BaseEditableItem
    {
        #region "Constructor"

        public CampaignBL()
        {

        }

        public CampaignBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        String m_strName;
        String m_strMessage;
        Nullable<Int32> m_iShopId;
        bool m_IsEmail;
        bool m_IsZipCodeMatchesMessage;
        bool m_IsPreferredShopMessage;
        #endregion "Members"

        #region "Accessors"

        public String strName
        {
            get { return this.m_strName; }
            set { this.m_strName = value; }
        }

        public Boolean IsEmail
        {
            get { return this.m_IsEmail; }
            set { this.m_IsEmail = value; }
        }


        public String strMessage
        {
            get { return this.m_strMessage; }
            set { this.m_strMessage = value; }
        }

        public Nullable<Int32> iShopId
        {
            get { return this.m_iShopId; }
            set { this.m_iShopId = value; }
        }

        public Boolean IsZipCodeMatchesMessage
        {
            get { return this.m_IsZipCodeMatchesMessage; }
            set { this.m_IsZipCodeMatchesMessage = value; }
        }

        public Boolean IsPreferredShopMessage
        {
            get { return this.m_IsPreferredShopMessage; }
            set { this.m_IsPreferredShopMessage = value; }
        }

        
        #endregion "Accessors"

        #region "Static Methods"

        private static CampaignTableAdapter getAdapter()
        {
            return new CampaignTableAdapter();
        }

        public static List<CampaignBL> getData()
        {
            SummitDS.CampaignDataTable thisTable = getAdapter().GetData();
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromTable(thisTable);
            }
            return null;
        }

        private static CampaignBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new CampaignBL(drRow);
            }
            return null;
        }

        private static List<CampaignBL> BuildFromTable(DataTable dtTable)
        {
            List<CampaignBL> _list = new List<CampaignBL>();

            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    CampaignBL _thisMember = new CampaignBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }

        public static CampaignBL GetPreferredShopMessageByShopId(Int32 iShopId)
        {
            SummitDS.CampaignDataTable thisTable = getAdapter().GetPreferredShopMessageByShopId(iShopId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        public static CampaignBL GetZipCodeMatchesMessageByShopId(Int32 iShopId)
        {
            SummitDS.CampaignDataTable thisTable = getAdapter().GetZipCodeMatchesMessageByShopId(iShopId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }


        #endregion "Static Methods"

        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.CampaignRow _thisRow = _dataRow as SummitDS.CampaignRow;

            if (_thisRow != null)
            {
                this._ID = _thisRow.campaign_id;
                this.m_strName = _thisRow.name;
                this.m_strMessage = _thisRow.IsmessageNull() ? String.Empty : _thisRow.message;
                this.m_iShopId = _thisRow.Isshop_idNull() ? (Nullable<Int32>)null : _thisRow.shop_id;
                this.m_IsEmail = _thisRow.IsisEmailNull() ? Convert.ToBoolean((Nullable<Boolean>)null) : _thisRow.isEmail;
                this.m_IsZipCodeMatchesMessage = _thisRow.Isis_zip_code_matches_messageNull() ? Convert.ToBoolean((Nullable<Boolean>)null) : _thisRow.is_zip_code_matches_message;
                this.m_IsPreferredShopMessage = _thisRow.Isis_preferred_shop_messageNull() ? Convert.ToBoolean((Nullable<Boolean>)null) : _thisRow.is_preferred_shop_message;

                _rowToSave = _thisRow;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.CampaignDataTable _thisTable = new SummitDS.CampaignDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewCampaignRow();
            SummitDS.CampaignRow _dataRow = _rowToSave as SummitDS.CampaignRow;

            if (_dataRow != null)
            {
                if (IsExisting())
                {
                    _dataRow.name = m_strName;

                    if (String.IsNullOrEmpty(m_strMessage)) { if (!_dataRow.IsmessageNull()) _dataRow.SetmessageNull(); }
                    else if (_dataRow.IsmessageNull() ? true : _dataRow.message != m_strMessage) _dataRow.message = m_strMessage;

                    if (iShopId.HasValue) _dataRow.shop_id = iShopId.Value;
                    else _dataRow.Setshop_idNull();

                    if (m_IsEmail == null) { if (!_dataRow.IsisEmailNull()) _dataRow.SetisEmailNull(); }
                    else if (_dataRow.IsisEmailNull() ? true : _dataRow.isEmail != m_IsEmail) _dataRow.isEmail = m_IsEmail;

                    if (m_IsZipCodeMatchesMessage == null) { if (!_dataRow.Isis_zip_code_matches_messageNull()) _dataRow.Setis_zip_code_matches_messageNull(); }
                    else if (_dataRow.Isis_zip_code_matches_messageNull() ? true : _dataRow.is_zip_code_matches_message != m_IsZipCodeMatchesMessage) _dataRow.is_zip_code_matches_message = m_IsZipCodeMatchesMessage;

                    if (m_IsPreferredShopMessage == null) { if (!_dataRow.Isis_preferred_shop_messageNull()) _dataRow.Setis_preferred_shop_messageNull(); }
                    else if (_dataRow.Isis_preferred_shop_messageNull() ? true : _dataRow.is_preferred_shop_message != m_IsPreferredShopMessage) _dataRow.is_preferred_shop_message = m_IsPreferredShopMessage;

                }
                else
                {
                    _dataRow.name = m_strName;

                    if (String.IsNullOrEmpty(strMessage)) _dataRow.SetmessageNull();
                    else _dataRow.message = strMessage;

                    if (iShopId.HasValue) _dataRow.shop_id = iShopId.Value;
                    else _dataRow.Setshop_idNull();

                    if (m_IsEmail == null) { if (!_dataRow.IsisEmailNull()) _dataRow.SetisEmailNull(); }
                    else if (_dataRow.IsisEmailNull() ? true : _dataRow.isEmail != m_IsEmail) _dataRow.isEmail = m_IsEmail;

                    if (m_IsZipCodeMatchesMessage == null) { if (!_dataRow.Isis_zip_code_matches_messageNull()) _dataRow.Setis_zip_code_matches_messageNull(); }
                    else if (_dataRow.Isis_zip_code_matches_messageNull() ? true : _dataRow.is_zip_code_matches_message != m_IsZipCodeMatchesMessage) _dataRow.is_zip_code_matches_message = m_IsZipCodeMatchesMessage;

                    if (m_IsPreferredShopMessage == null) { if (!_dataRow.Isis_preferred_shop_messageNull()) _dataRow.Setis_preferred_shop_messageNull(); }
                    else if (_dataRow.Isis_preferred_shop_messageNull() ? true : _dataRow.is_preferred_shop_message != m_IsPreferredShopMessage) _dataRow.is_preferred_shop_message = m_IsPreferredShopMessage;
                                        
                    _thisTable.AddCampaignRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
            SummitDS.CampaignRow thisRow = _rowToSave as SummitDS.CampaignRow;
            if (thisRow != null)
            {
                this._ID = thisRow.campaign_id;
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
