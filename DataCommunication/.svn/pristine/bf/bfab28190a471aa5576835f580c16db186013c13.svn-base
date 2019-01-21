using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;
using System.Data;

namespace SummitShopApp.BL
{
    public class BodyShopPrivateLabelBL:BaseEditableItem
    {
          #region Constructor
        public BodyShopPrivateLabelBL()
        {

        }

        public BodyShopPrivateLabelBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }
        #endregion

        #region Members        
        Nullable<Int32> m_iPrivateLabelID;
        Nullable<Int32> m_iShopID;
        String m_strImagePageLogoPath;
        String m_strImageBtnLogoPath;
        #endregion

        #region Accessors
        public Nullable<Int32> iPrivateLabelID
        {
            get { return this.m_iPrivateLabelID; }
            set { this.m_iPrivateLabelID = value; }
        }

        public Nullable<Int32> iShopID
        {
            get { return this.m_iShopID; }
            set { this.m_iShopID = value; }
        }

        public String strImagePageLogoPath
        {
            get { return this.m_strImagePageLogoPath; }
            set { this.m_strImagePageLogoPath = value; }
        }

        public String strImageBtnLogoPath
        {
            get { return this.m_strImageBtnLogoPath; }
            set { this.m_strImageBtnLogoPath = value; }
        }     
        #endregion

        #region Static Methods
        public static BodyShop_PrivateLabelTableAdapter  getAdapter()
        {
            return new BodyShop_PrivateLabelTableAdapter();
        }

        public static List<BodyShopPrivateLabelBL> getData()
        {
            SummitDS.BodyShop_PrivateLabelDataTable thisTable = getAdapter().GetData();
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromTable(thisTable);
            }
            return null;
        }

        public static BodyShopPrivateLabelBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new BodyShopPrivateLabelBL(drRow);
            }
            return null;
        }

        public static List<BodyShopPrivateLabelBL> BuildFromTable(DataTable dtTable)
        {
            List<BodyShopPrivateLabelBL> _list = new List<BodyShopPrivateLabelBL>();
            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    BodyShopPrivateLabelBL _thisMember = new BodyShopPrivateLabelBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }

        /// <summary>
        /// Returns list of private label shop 
        /// </summary>
        /// <param name="iPrivateLabelId"></param>
        /// <returns></returns>
        public static List<BodyShopPrivateLabelBL> GetShopListByPrivateLabelId(Int32 iPrivateLabelId)
        {
            List<BodyShopPrivateLabelBL> _list = new List<BodyShopPrivateLabelBL>();
            SummitDS.BodyShop_PrivateLabelDataTable thisTable = getAdapter().GetShopListByPrivateLabelId(iPrivateLabelId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                foreach (DataRow dr in thisTable.Rows)
                {
                    BodyShopPrivateLabelBL _thisMember = new BodyShopPrivateLabelBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }
        #endregion

        #region Overrides
        protected override void SaveToRow()
        {

        }

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.BodyShop_PrivateLabelRow _thisRow = _dataRow as SummitDS.BodyShop_PrivateLabelRow;

            if (_thisRow != null)
            {
                this._ID = _thisRow.id;
                this.iPrivateLabelID = _thisRow.Isprivate_label_idNull() ? (Nullable<Int32>)null : _thisRow.private_label_id;
                this.m_iShopID = _thisRow.Isshop_idNull() ? (Nullable<Int32>)null : _thisRow.shop_id;
                this.m_strImagePageLogoPath = _thisRow.Ispage_logo_pathNull() ? String.Empty : _thisRow.page_logo_path;
                this.m_strImageBtnLogoPath = _thisRow.Isbtn_logo_pathNull() ? String.Empty : _thisRow.btn_logo_path;
                
                _rowToSave = _thisRow;
            }
        } 
        
        protected override void Update()
        {
            
        }

        protected override void DeleteRecord()
        {
        }

        protected override void SetID()
        {
            SummitDS.BodyShop_PrivateLabelRow thisRow = _rowToSave as SummitDS.BodyShop_PrivateLabelRow;
            if (thisRow != null)
            {
                this._ID = thisRow.id;
            }
        }
        #endregion
    }
}
