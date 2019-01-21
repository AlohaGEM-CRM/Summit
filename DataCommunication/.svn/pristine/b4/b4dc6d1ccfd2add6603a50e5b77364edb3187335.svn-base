using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;

namespace SummitShopApp.BL
{
    public class BodyShopZipCodeBL : BaseEditableItem
    {
        #region "Constructor"

        public BodyShopZipCodeBL()
        {

        }

        public BodyShopZipCodeBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        String m_strZipCode;
        Int32 m_iShopId;

        #endregion "Members"

        #region "Accessors"

        public String strZipCode
        {
            get { return this.m_strZipCode; }
            set { this.m_strZipCode = value; }
        }

        public Int32 iShopId
        {
            get { return this.m_iShopId; }
            set { this.m_iShopId = value; }
        }

        #endregion "Accessors"

        #region "Static Methods"

        private static GetShopIdsByZipCodeTableAdapter getAdapter()
        {
            return new GetShopIdsByZipCodeTableAdapter();
        }

        public static List<BodyShopZipCodeBL> getDataByZipCode(String strZipcode)
        {
            SummitDS.GetShopIdsByZipCodeDataTable thisTable = getAdapter().GetData(strZipcode);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromTable(thisTable);
            }
            return null;
        }     

        private static BodyShopZipCodeBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new BodyShopZipCodeBL(drRow);
            }
            return null;
        }

        private static List<BodyShopZipCodeBL> BuildFromTable(DataTable dtTable)
        {
            List<BodyShopZipCodeBL> _list = new List<BodyShopZipCodeBL>();

            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    BodyShopZipCodeBL _thisMember = new BodyShopZipCodeBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }

        #endregion "Static Methods"

        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.GetShopIdsByZipCodeRow _thisRow = _dataRow as SummitDS.GetShopIdsByZipCodeRow;

            if (_thisRow != null)
            {                
                this.m_strZipCode = _thisRow.Zip;
                this.m_iShopId = _thisRow.ShopID;

                //  this.m_dt_ts = _thisRow.Is_tsNull() ? (Nullable<DateTime>) null : _thisRow._ts ;                                
                _rowToSave = _thisRow;
            }
        }


        protected override void SetID()
        {
            SummitDS.ZipCodeRow thisRow = _rowToSave as SummitDS.ZipCodeRow;
            if (thisRow != null)
            {
                this._ID = thisRow.Code_id;
            }
        }
        protected override void Update()
        {
           
        }

        protected override void SaveToRow()
        {
           
        }
        protected override void DeleteRecord()
        {
        }

        #endregion "Overrides"
    }
}
