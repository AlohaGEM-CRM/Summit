using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;

namespace SummitShopApp.BL
{
    public class VehicleInfoBL : BaseEditableItem
    {
        #region "Constructor"

        public VehicleInfoBL()
        {

        }

        public VehicleInfoBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        Nullable<Int32> m_iUserId;
        String m_strModel;
        String m_strMake;
        String m_strYear;
        String m_strOtherInfo;
        Nullable<Boolean> m_bIsUsing;
        String m_strStyle;
        String m_strColor;
        String m_strPaintCode;
        String m_strVIN;
        String m_strLicense;
        Nullable<DateTime> m_dtProductionDate;
        String m_strEstimateFileIdentifier;
        String m_strEstimatorName;

        #endregion "Members"

        #region "Accessors"

        public Nullable<Int32> iUserId
        {
            get { return this.m_iUserId; }
            set { this.m_iUserId = value; }
        }

        public String strModel
        {
            get { return this.m_strModel; }
            set { this.m_strModel = value; }
        }

        public String strMake
        {
            get { return this.m_strMake; }
            set { this.m_strMake = value; }
        }

        public String strYear
        {
            get { return this.m_strYear; }
            set { this.m_strYear = value; }
        }

        public String strOtherInfo
        {
            get { return this.m_strOtherInfo; }
            set { this.m_strOtherInfo = value; }
        }

        public Nullable<Boolean> bIsUsing
        {
            get { return this.m_bIsUsing; }
            set { this.m_bIsUsing = value; }
        }

        public String strStyle
        {
            get { return this.m_strStyle; }
            set { this.m_strStyle = value; }
        }

        public String strColor
        {
            get { return this.m_strColor; }
            set { this.m_strColor = value; }
        }

        public String strPaintCode
        {
            get { return this.m_strPaintCode; }
            set { this.m_strPaintCode = value; }
        }

        public String strVIN
        {
            get { return this.m_strVIN; }
            set { this.m_strVIN = value; }
        }

        public String strLicense
        {
            get { return this.m_strLicense; }
            set { this.m_strLicense = value; }
        }

        public Nullable<DateTime> dtProductionDate
        {
            get { return this.m_dtProductionDate; }
            set { this.m_dtProductionDate = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }

        public String strEstimateFileIdentifier
        {
            get { return this.m_strEstimateFileIdentifier; }
            set { this.m_strEstimateFileIdentifier = value; }
        }

        public String strEstimatorName
        {
            get { return this.m_strEstimatorName; }
            set { this.m_strEstimatorName = value; }
        }

        #endregion "Accessors"

        #region "Static Methods"

        private static VehicleInfoTableAdapter getAdapter()
        {
            return new VehicleInfoTableAdapter();
        }

        public static List<VehicleInfoBL> getDataByUserId(Int32 iUserId)
        {
            SummitDS.VehicleInfoDataTable thisTable = getAdapter().GetDataByUserId(iUserId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromTable(thisTable);
            }
            return null;
        }

        public static VehicleInfoBL getDataId(Int32 iId)
        {
            SummitDS.VehicleInfoDataTable thisTable = getAdapter().GetDataById(iId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        private static VehicleInfoBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new VehicleInfoBL(drRow);
            }
            return null;
        }

        private static List<VehicleInfoBL> BuildFromTable(DataTable dtTable)
        {
            List<VehicleInfoBL> _list = new List<VehicleInfoBL>();

            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    VehicleInfoBL _thisMember = new VehicleInfoBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }

        #endregion "Static Methods"

        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.VehicleInfoRow _thisRow = _dataRow as SummitDS.VehicleInfoRow;

            if (_thisRow != null)
            {
                this._ID = _thisRow.vehicle_id;
                this.m_iUserId = _thisRow.Isuser_idNull() ? (Nullable<Int32>)null : _thisRow.user_id;
                this.m_strModel = _thisRow.IsmodelNull() ? String.Empty : _thisRow.model;
                this.m_strMake = _thisRow.IsmakeNull() ? String.Empty : _thisRow.make;
                this.m_strYear = _thisRow.IsyearNull() ? String.Empty : _thisRow.year;
                this.m_strOtherInfo = _thisRow.Isother_infoNull() ? String.Empty : _thisRow.other_info;
                this.m_bIsUsing = _thisRow.Isis_usingNull() ? (Nullable<Boolean>)null : _thisRow.is_using;
                this.m_strStyle = _thisRow.IsstyleNull() ? String.Empty : _thisRow.style;
                this.m_strColor = _thisRow.IscolorNull() ? String.Empty : _thisRow.color;
                this.m_strPaintCode = _thisRow.Ispaint_codeNull() ? String.Empty : _thisRow.paint_code;
                this.m_strVIN = _thisRow.IsvinNull() ? String.Empty : _thisRow.vin;
                this.m_strLicense = _thisRow.IslicenseNull() ? String.Empty : _thisRow.license;
                this.m_dtProductionDate = _thisRow.Isproduction_dateNull() ? (Nullable<DateTime>)null : _thisRow.production_date;
                this.m_strEstimateFileIdentifier = _thisRow.Isestimate_file_identifierNull() ? String.Empty : _thisRow.estimate_file_identifier;
                this.m_strEstimatorName = _thisRow.Isestimator_nameNull() ? String.Empty : _thisRow.estimator_name;
                _rowToSave = _thisRow;
            }

        }

        protected override void SaveToRow()
        {
            SummitDS.VehicleInfoDataTable _thisTable = new SummitDS.VehicleInfoDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewVehicleInfoRow();
            SummitDS.VehicleInfoRow _dataRow = _rowToSave as SummitDS.VehicleInfoRow;

            if (_dataRow != null)
            {
                if (IsExisting())
                {
                    if (_dataRow.user_id != m_iUserId) _dataRow.user_id = Convert.ToInt32(m_iUserId);

                    if (String.IsNullOrEmpty(m_strModel)) { if (!_dataRow.IsmodelNull()) _dataRow.SetmodelNull(); }
                    else if (_dataRow.IsmodelNull() ? true : _dataRow.model != m_strModel) _dataRow.model = m_strModel;

                    if (String.IsNullOrEmpty(m_strMake)) { if (!_dataRow.IsmakeNull()) _dataRow.SetmakeNull(); }
                    else if (_dataRow.IsmakeNull() ? true : _dataRow.make != m_strMake) _dataRow.make = m_strMake;

                    if (String.IsNullOrEmpty(m_strYear)) { if (!_dataRow.IsyearNull()) _dataRow.SetyearNull(); }
                    else if (_dataRow.IsyearNull() ? true : _dataRow.year != m_strYear) _dataRow.year = m_strYear;

                    if (String.IsNullOrEmpty(m_strOtherInfo)) { if (!_dataRow.Isother_infoNull()) _dataRow.Setother_infoNull(); }
                    else if (_dataRow.Isother_infoNull() ? true : _dataRow.other_info != m_strOtherInfo) _dataRow.other_info = m_strOtherInfo;

                    if (bIsUsing.HasValue) _dataRow.is_using = bIsUsing.Value;
                    else _dataRow.Setis_usingNull();

                    if (String.IsNullOrEmpty(m_strStyle)) { if (!_dataRow.IsstyleNull()) _dataRow.SetstyleNull(); }
                    else if (_dataRow.IsstyleNull() ? true : _dataRow.style != m_strStyle) _dataRow.style = m_strStyle;

                    if (String.IsNullOrEmpty(m_strColor)) { if (!_dataRow.IscolorNull()) _dataRow.SetcolorNull(); }
                    else if (_dataRow.IscolorNull() ? true : _dataRow.color != m_strColor) _dataRow.color = m_strColor;

                    if (String.IsNullOrEmpty(m_strPaintCode)) { if (!_dataRow.Ispaint_codeNull()) _dataRow.Setpaint_codeNull(); }
                    else if (_dataRow.Ispaint_codeNull() ? true : _dataRow.paint_code != m_strPaintCode) _dataRow.paint_code = m_strPaintCode;

                    if (String.IsNullOrEmpty(m_strVIN)) { if (!_dataRow.IsvinNull()) _dataRow.SetvinNull(); }
                    else if (_dataRow.IsvinNull() ? true : _dataRow.vin != m_strVIN) _dataRow.vin = m_strVIN;

                    if (String.IsNullOrEmpty(m_strLicense)) { if (!_dataRow.IslicenseNull()) _dataRow.SetlicenseNull(); }
                    else if (_dataRow.IslicenseNull() ? true : _dataRow.license != m_strLicense) _dataRow.license = m_strLicense;

                    if (String.IsNullOrEmpty(m_strEstimateFileIdentifier)) { if (!_dataRow.Isestimate_file_identifierNull()) _dataRow.Setestimate_file_identifierNull(); }
                    else if (_dataRow.Isestimate_file_identifierNull() ? true : _dataRow.estimate_file_identifier != m_strEstimateFileIdentifier) _dataRow.estimate_file_identifier = m_strEstimateFileIdentifier;

                    if (String.IsNullOrEmpty(m_strEstimatorName)) { if (!_dataRow.Isestimator_nameNull()) _dataRow.Setestimator_nameNull(); }
                    else if (_dataRow.Isestimator_nameNull() ? true : _dataRow.estimator_name != m_strEstimatorName) _dataRow.estimator_name = m_strEstimatorName;

                    if (dtProductionDate.HasValue) _dataRow.production_date = dtProductionDate.Value;
                    else _dataRow.Setproduction_dateNull();
                }
                else
                {
                    if (iUserId.HasValue) _dataRow.user_id = iUserId.Value;
                    else _dataRow.Setuser_idNull();

                    if (String.IsNullOrEmpty(strModel)) _dataRow.SetmodelNull();
                    else _dataRow.model = strModel;

                    if (String.IsNullOrEmpty(strMake)) _dataRow.SetmakeNull();
                    else _dataRow.make = strMake;

                    if (String.IsNullOrEmpty(strYear)) _dataRow.SetyearNull();
                    else _dataRow.year = strYear;

                    if (String.IsNullOrEmpty(strOtherInfo)) _dataRow.Setother_infoNull();
                    else _dataRow.other_info = strOtherInfo;

                    if (bIsUsing.HasValue) _dataRow.is_using = bIsUsing.Value;
                    else _dataRow.Setis_usingNull();

                    if (String.IsNullOrEmpty(strStyle)) _dataRow.SetstyleNull();
                    else _dataRow.style = strStyle;

                    if (String.IsNullOrEmpty(strColor)) _dataRow.SetcolorNull();
                    else _dataRow.color = strColor;

                    if (String.IsNullOrEmpty(strPaintCode)) _dataRow.Setpaint_codeNull();
                    else _dataRow.paint_code = strPaintCode;

                    if (String.IsNullOrEmpty(strVIN)) _dataRow.SetvinNull();
                    else _dataRow.vin = strVIN;

                    if (String.IsNullOrEmpty(strLicense)) _dataRow.SetlicenseNull();
                    else _dataRow.license = strLicense;

                    if (dtProductionDate.HasValue) _dataRow.production_date = dtProductionDate.Value;
                    else _dataRow.Setproduction_dateNull();

                    if (String.IsNullOrEmpty(m_strEstimateFileIdentifier)) { if (!_dataRow.Isestimate_file_identifierNull()) _dataRow.Setestimate_file_identifierNull(); }
                    else if (_dataRow.Isestimate_file_identifierNull() ? true : _dataRow.estimate_file_identifier != m_strEstimateFileIdentifier) _dataRow.estimate_file_identifier = m_strEstimateFileIdentifier;

                    if (String.IsNullOrEmpty(m_strEstimatorName)) { if (!_dataRow.Isestimator_nameNull()) _dataRow.Setestimator_nameNull(); }
                    else if (_dataRow.Isestimator_nameNull() ? true : _dataRow.estimator_name != m_strEstimatorName) _dataRow.estimator_name = m_strEstimatorName;

                    _thisTable.AddVehicleInfoRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
            SummitDS.VehicleInfoRow thisRow = _rowToSave as SummitDS.VehicleInfoRow;
            if (thisRow != null)
            {
                this._ID = thisRow.vehicle_id;
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
