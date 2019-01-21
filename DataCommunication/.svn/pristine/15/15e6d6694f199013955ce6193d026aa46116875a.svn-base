using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;

namespace SummitShopApp.BL
{
    public class ZipCodeBL:BaseEditableItem
    {
        #region "Constructor"

        public ZipCodeBL()
        {

        }

        public ZipCodeBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        String m_strZipCode;
        Int32 m_iLoginId;

        #endregion "Members"

        #region "Accessors"

        public String strZipCode
        {
            get { return this.m_strZipCode; }
            set { this.m_strZipCode = value; }
        }

        public Int32 iLoginId
        {
            get { return this.m_iLoginId; }
            set { this.m_iLoginId = value; }
        }

        #endregion "Accessors"

        #region "Static Methods"

        private static ZipCodeTableAdapter getAdapter()
        {
            return new ZipCodeTableAdapter();
        }

        public static List<ZipCodeBL> getData()
        {
            SummitDS.ZipCodeDataTable thisTable = getAdapter().GetData();
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromTable(thisTable);
            }
            return null;
        }

        public static ZipCodeBL getDataById(Int32 iCodeId)
        {
            SummitDS.ZipCodeDataTable thisTable = getAdapter().GetDataById(iCodeId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        public static List<ZipCodeBL> getDataByLoginId(Int32 iLoginId)
        {
            SummitDS.ZipCodeDataTable thisTable = getAdapter().GetDataByLoginId(iLoginId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromTable(thisTable);
            }
            return null;
        }

        private static ZipCodeBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new ZipCodeBL(drRow);
            }
            return null;
        }

        private static List<ZipCodeBL> BuildFromTable(DataTable dtTable)
        {
            List<ZipCodeBL> _list = new List<ZipCodeBL>();

            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    ZipCodeBL _thisMember = new ZipCodeBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }

        #endregion "Static Methods"

        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.ZipCodeRow _thisRow = _dataRow as SummitDS.ZipCodeRow;

            if (_thisRow != null)
            {
                this._ID = _thisRow.Code_id;
                this.m_strZipCode = _thisRow.Zip;
                this.m_iLoginId = _thisRow.Login_id;

                //  this.m_dt_ts = _thisRow.Is_tsNull() ? (Nullable<DateTime>) null : _thisRow._ts ;                                
                _rowToSave = _thisRow;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.ZipCodeDataTable _thisTable = new SummitDS.ZipCodeDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewZipCodeRow();
            SummitDS.ZipCodeRow _dataRow = _rowToSave as SummitDS.ZipCodeRow;

            if (_dataRow != null)
            {
                if (IsExisting())
                {
                    _dataRow.Zip = m_strZipCode;
                    _dataRow.Login_id = m_iLoginId;
                }
                else
                {
                    _dataRow.Zip = m_strZipCode;
                    _dataRow.Login_id = m_iLoginId;

                    _thisTable.AddZipCodeRow(_dataRow);
                }
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
