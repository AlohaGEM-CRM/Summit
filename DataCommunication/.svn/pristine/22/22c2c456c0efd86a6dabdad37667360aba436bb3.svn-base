using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitShopApp.DAL.SummitDSTableAdapters;
using SummitShopApp.DAL;
using System.Data;

namespace SummitShopApp.BL
{
    public class VehicleMediaLinkBL : BaseEditableItem
    {
        #region "Constructor"

        public VehicleMediaLinkBL()
        {

        }

        public VehicleMediaLinkBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        Nullable<DateTime> m_dtSendDate;
        Int32 m_iVehicleId;
        String m_strMediaLink;
        String m_strMediaLinkThumbnail;
        Nullable<Int32> m_iVehicleMediaLinkNoteID;
        Nullable<Boolean> m_bIsNew;
        #endregion "Members"

        #region "Accessors"

        public Int32 iVehicleId
        {
            get { return this.m_iVehicleId; }
            set { this.m_iVehicleId = value; }
        }

        public Nullable<Int32> iVehicleMediaLinkNoteID
        {
            get { return this.m_iVehicleMediaLinkNoteID; }
            set { this.m_iVehicleMediaLinkNoteID = value; }
        }

        public String strMediaLink
        {
            get { return this.m_strMediaLink; }
            set { this.m_strMediaLink = value; }
        }

        public String strMediaLinkThumbnail
        {
            get { return this.m_strMediaLinkThumbnail; }
            set { this.m_strMediaLinkThumbnail = value; }
        }

        public Nullable<Boolean> bIsNew
        {
            get { return this.m_bIsNew; }
            set { this.m_bIsNew = value; }
        }

        #endregion "Accessors"

        #region "Static Methods"

        private static VehicleMediaLinkTableAdapter getAdapter()
        {
            return new VehicleMediaLinkTableAdapter();
        }

        public static List<VehicleMediaLinkBL> getData()
        {
            SummitDS.VehicleMediaLinkDataTable thisTable = getAdapter().GetData();
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromTable(thisTable);
            }
            return null;
        }

        public static int getNewLinkCountByVehicleID(Int32 iVehicleID)
        {

            int iCount = (int)getAdapter().GetCountOfNewLink(iVehicleID);
            if (iCount > 0)
                return iCount;
            else
                return 0;
        }

        private static List<VehicleMediaLinkBL> BuildFromTable(DataTable dtTable)
        {
            List<VehicleMediaLinkBL> list = new List<VehicleMediaLinkBL>();
            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    VehicleMediaLinkBL thisMember = new VehicleMediaLinkBL(dr);
                    list.Add(thisMember);
                }
            }
            return list;
        }

        private static VehicleMediaLinkBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new VehicleMediaLinkBL(drRow);
            }
            return null;
        }


        #endregion "Static Methods"

        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.VehicleMediaLinkRow _thisRow = _dataRow as SummitDS.VehicleMediaLinkRow;

            if (_thisRow != null)
            {
                this._ID = _thisRow.id;

                this.m_iVehicleId = _thisRow.vehicle_id;
                this.m_strMediaLink = _thisRow.media_link;
                this.m_strMediaLinkThumbnail = _thisRow.Ismedia_link_ThumnailNull() ? String.Empty : _thisRow.media_link_Thumnail;
                this.m_iVehicleMediaLinkNoteID = _thisRow.VehicleMediaLinkNoteID;
                this.m_bIsNew = _thisRow.IsIsNewLinkNull() ? (Nullable<Boolean>)null : _thisRow.IsNewLink;
                _rowToSave = _thisRow;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.VehicleMediaLinkDataTable _thisTable = new SummitDS.VehicleMediaLinkDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewVehicleMediaLinkRow();
            SummitDS.VehicleMediaLinkRow _dataRow = _rowToSave as SummitDS.VehicleMediaLinkRow;

            if (_dataRow != null)
            {
                if (IsExisting())
                {
                    _dataRow.vehicle_id = m_iVehicleId;
                    _dataRow.media_link = m_strMediaLink;
                    if (m_iVehicleMediaLinkNoteID.HasValue) _dataRow.VehicleMediaLinkNoteID = m_iVehicleMediaLinkNoteID.Value;
                    else _dataRow.SetVehicleMediaLinkNoteIDNull();

                    if (m_bIsNew.HasValue) _dataRow.IsNewLink = m_bIsNew.Value;
                    else _dataRow.SetIsNewLinkNull();

                    if (String.IsNullOrEmpty(m_strMediaLinkThumbnail)) _dataRow.Setmedia_link_ThumnailNull();
                    else _dataRow.media_link_Thumnail = strMediaLinkThumbnail;

                }
                else
                {
                    _dataRow.vehicle_id = m_iVehicleId;
                    _dataRow.media_link = m_strMediaLink;
                    if (m_iVehicleMediaLinkNoteID.HasValue) _dataRow.VehicleMediaLinkNoteID = m_iVehicleMediaLinkNoteID.Value;
                    else _dataRow.SetVehicleMediaLinkNoteIDNull();

                    if (String.IsNullOrEmpty(m_strMediaLinkThumbnail)) _dataRow.Setmedia_link_ThumnailNull();
                    else _dataRow.media_link_Thumnail = strMediaLinkThumbnail;

                    if (m_bIsNew.HasValue) _dataRow.IsNewLink = m_bIsNew.Value;
                    else _dataRow.SetIsNewLinkNull();

                    _thisTable.AddVehicleMediaLinkRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
            SummitDS.VehicleMediaLinkRow thisRow = _rowToSave as SummitDS.VehicleMediaLinkRow;
            if (thisRow != null)
            {
                this._ID = thisRow.id; ;
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
