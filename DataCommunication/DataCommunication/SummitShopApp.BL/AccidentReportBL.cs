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
    public class AccidentReportBL: BaseEditableItem
    {
        #region "Constructor"

        public AccidentReportBL()
        {

        }

        public AccidentReportBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        Nullable<Int32> m_iUserId;
        String m_strStreet;
        String m_strCity;
        String m_strState;
        String m_strDescription;
        String m_strDriverName;
        String m_strDriverPhone;
        String m_strDriverLicenseStatePlate;
        String m_strDriverLicenseNo;
        String m_strDriverVehicleType;
        String m_strInsuranceCompanyName;
        String m_strInsurancePolicyNo;
        String m_strPoliceOffice;
        String m_strPoliceReportNo;
        String m_strWitnesses;
        String m_strWitnessComments;
        String m_strMiscNotes;
        Nullable<Int32> m_iMessageId;
        String m_strImageAttached;

        #endregion "Members"

        #region "Accessors"

        public Nullable<Int32> iUserId
        {
            get { return this.m_iUserId; }
            set { this.m_iUserId = value; }
        }

        public String strStreet
        {
            get { return this.m_strStreet; }
            set { this.m_strStreet = value; }
        }

        public String strCity
        {
            get { return this.m_strCity; }
            set { this.m_strCity = value; }
        }

        public String strState
        {
            get { return this.m_strState; }
            set { this.m_strState= value; }
        }

        public String strDescription
        {
            get { return this.m_strDescription; }
            set { this.m_strDescription= value; }
        }

        public String strDriverName
        {
            get { return this.m_strDriverName; }
            set { this.m_strDriverName= value; }
        }

        public String strDriverPhone
        {
            get { return this.m_strDriverPhone; }
            set { this.m_strDriverPhone= value; }
        }

        public String strDriverLicenseStatePlate
        {
            get { return this.m_strDriverLicenseStatePlate; }
            set { this.m_strDriverLicenseStatePlate= value; }
        }

        public String strDriverLicenseNo
        {
            get { return this.m_strDriverLicenseNo; }
            set { this.m_strDriverLicenseNo= value; }
        }

        public String strDriverVehicleType
        {
            get { return this.m_strDriverVehicleType; }
            set { this.m_strDriverVehicleType= value; }
        }

        public String strInsuranceCompanyName
        {
            get { return this.m_strInsuranceCompanyName; }
            set { this.m_strInsuranceCompanyName= value; }
        }

        public String strInsurancePolicyNo
        {
            get { return this.m_strInsurancePolicyNo; }
            set { this.m_strInsurancePolicyNo= value; }
        }

        public String strPoliceOffice
        {
            get { return this.m_strPoliceOffice; }
            set { this.m_strPoliceOffice= value; }
        }

        public String strPoliceReportNo
        {
            get { return this.m_strPoliceReportNo; }
            set { this.m_strPoliceReportNo= value; }
        }

        public String strWitnesses
        {
            get { return this.m_strWitnesses; }
            set { this.m_strWitnesses= value; }
        }

        public String strWitnessComments
        {
            get { return this.m_strWitnessComments; }
            set { this.m_strWitnessComments = value; }
        }

        public String strMiscNotes
        {
            get { return this.m_strMiscNotes; }
            set { this.m_strMiscNotes= value; }
        }

        public Nullable<Int32> iMessageId
        {
            get { return this.m_iMessageId; }
            set { this.m_iMessageId = value; }
        }

        public String strImageAttached
        {
            get { return this.m_strImageAttached; }
            set { this.m_strImageAttached = value; }
        }

        #endregion "Accessors"

        #region "Static Methods"

        private static AccidentReportTableAdapter getAdapter()
        {
            return new AccidentReportTableAdapter();
        }

        public static AccidentReportBL getDataByMessageId(Int32 iMessageId)
        {
            SummitDS.AccidentReportDataTable thisTable = getAdapter().GetDataByMassageId(iMessageId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        private static AccidentReportBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new AccidentReportBL(drRow);
            }
            return null;
        }

        private static List<AccidentReportBL> BuildFromTable(DataTable dtTable)
        {
            List<AccidentReportBL> _list = new List<AccidentReportBL>();

            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    AccidentReportBL _thisMember = new AccidentReportBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }

        #endregion "Static Methods"

        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.AccidentReportRow _thisRow = _dataRow as SummitDS.AccidentReportRow;

            if (_thisRow != null)
            {
                this._ID = _thisRow.accident_id;
                this.iUserId = _thisRow.Isuser_idNull() ? (Nullable<Int32>)null : _thisRow.user_id;
                this.m_strStreet = _thisRow.IsstreetNull() ? String.Empty : _thisRow.street;
                this.m_strCity = _thisRow.IscityNull() ? String.Empty : _thisRow.city;
                this.m_strState = _thisRow.IsstateNull() ? String.Empty : _thisRow.state;
                this.m_strCity = _thisRow.IscityNull() ? String.Empty : _thisRow.city;
                this.m_strState = _thisRow.IsstateNull() ? String.Empty : _thisRow.state;
                this.m_strDescription = _thisRow.IsdescriptionNull() ? String.Empty : _thisRow.description;
                this.m_strDriverName = _thisRow.Isdriver_nameNull() ? String.Empty : _thisRow.driver_name;
                this.m_strDriverPhone = _thisRow.Isdriver_phoneNull() ? String.Empty : _thisRow.driver_phone;
                this.m_strDriverLicenseStatePlate = _thisRow.Isdriver_license_state_plateNull() ? String.Empty : _thisRow.driver_license_state_plate;
                this.m_strDriverLicenseNo = _thisRow.Isdriver_license_noNull() ? String.Empty : _thisRow.driver_license_no;
                this.m_strDriverVehicleType = _thisRow.Isdriver_vehicle_typeNull() ? String.Empty : _thisRow.driver_vehicle_type;
                this.m_strInsuranceCompanyName= _thisRow.Isinsurance_company_nameNull() ? String.Empty : _thisRow.insurance_company_name;
                this.m_strInsurancePolicyNo= _thisRow.Isinsurance_policy_noNull() ? String.Empty : _thisRow.insurance_policy_no;
                this.m_strPoliceOffice= _thisRow.Ispolice_officeNull() ? String.Empty : _thisRow.police_office;
                this.m_strPoliceReportNo= _thisRow.Ispolice_report_noNull() ? String.Empty : _thisRow.police_report_no;
                this.m_strWitnessComments= _thisRow.Iswitness_commentsNull() ? String.Empty : _thisRow.witness_comments;
                this.m_strWitnesses= _thisRow.IswitnessesNull() ? String.Empty : _thisRow.witnesses;
                this.m_iMessageId= _thisRow.Ismessage_idNull() ? (Nullable<Int32>)null : _thisRow.message_id;

                _rowToSave = _thisRow;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.AccidentReportDataTable _thisTable = new SummitDS.AccidentReportDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewAccidentReportRow();
            SummitDS.AccidentReportRow _dataRow = _rowToSave as SummitDS.AccidentReportRow;

            if (_dataRow != null)
            {
                if (IsExisting())
                {
                    if (iUserId.HasValue) _dataRow.user_id= iUserId.Value;
                    else _dataRow.Setuser_idNull();

                    if (String.IsNullOrEmpty(m_strStreet)) { if (!_dataRow.IsstreetNull()) _dataRow.SetstreetNull(); }
                    else if (_dataRow.IsstreetNull() ? true : _dataRow.street != m_strStreet) _dataRow.street = m_strStreet;

                    if (String.IsNullOrEmpty(m_strCity)) { if (!_dataRow.IscityNull()) _dataRow.SetcityNull(); }
                    else if (_dataRow.IscityNull() ? true : _dataRow.city != m_strCity) _dataRow.city = m_strCity;

                    if (String.IsNullOrEmpty(m_strState)) { if (!_dataRow.IsstateNull()) _dataRow.SetstateNull(); }
                    else if (_dataRow.IsstateNull() ? true : _dataRow.state != m_strState) _dataRow.state = m_strState;

                    if (String.IsNullOrEmpty(m_strDescription)) { if (!_dataRow.IsdescriptionNull()) _dataRow.SetdescriptionNull(); }
                    else if (_dataRow.IsdescriptionNull() ? true : _dataRow.description != m_strDescription) _dataRow.description = m_strDescription;

                    if (String.IsNullOrEmpty(m_strDriverName)) { if (!_dataRow.Isdriver_nameNull()) _dataRow.Setdriver_nameNull(); }
                    else if (_dataRow.Isdriver_nameNull() ? true : _dataRow.driver_name != m_strDriverName) _dataRow.driver_name = m_strDriverName;

                    if (String.IsNullOrEmpty(m_strDriverPhone)) { if (!_dataRow.Isdriver_phoneNull()) _dataRow.Setdriver_phoneNull(); }
                    else if (_dataRow.Isdriver_phoneNull() ? true : _dataRow.driver_phone != m_strDriverPhone) _dataRow.driver_phone = m_strDriverPhone;

                    if (String.IsNullOrEmpty(m_strDriverLicenseStatePlate)) { if (!_dataRow.Isdriver_license_state_plateNull()) _dataRow.Setdriver_license_state_plateNull(); }
                    else if (_dataRow.Isdriver_license_state_plateNull() ? true : _dataRow.driver_license_state_plate != m_strDriverLicenseStatePlate) _dataRow.driver_license_state_plate = m_strDriverLicenseStatePlate;

                    if (String.IsNullOrEmpty(m_strDriverLicenseNo)) { if (!_dataRow.Isdriver_license_noNull()) _dataRow.Setdriver_license_noNull(); }
                    else if (_dataRow.Isdriver_license_noNull() ? true : _dataRow.driver_license_no != m_strDriverLicenseNo) _dataRow.driver_license_no = m_strDriverLicenseNo;

                    if (String.IsNullOrEmpty(m_strDriverVehicleType)) { if (!_dataRow.Isdriver_vehicle_typeNull()) _dataRow.Setdriver_vehicle_typeNull(); }
                    else if (_dataRow.Isdriver_vehicle_typeNull() ? true : _dataRow.driver_vehicle_type != m_strDriverVehicleType) _dataRow.driver_vehicle_type = m_strDriverVehicleType;

                    if (String.IsNullOrEmpty(m_strInsuranceCompanyName)) { if (!_dataRow.Isinsurance_company_nameNull()) _dataRow.Setinsurance_company_nameNull(); }
                    else if (_dataRow.Isinsurance_company_nameNull() ? true : _dataRow.insurance_company_name != m_strInsuranceCompanyName) _dataRow.insurance_company_name = m_strInsuranceCompanyName;

                    if (String.IsNullOrEmpty(m_strInsurancePolicyNo)) { if (!_dataRow.Isinsurance_policy_noNull()) _dataRow.Setinsurance_policy_noNull(); }
                    else if (_dataRow.Isinsurance_policy_noNull() ? true : _dataRow.insurance_policy_no != m_strInsurancePolicyNo) _dataRow.insurance_policy_no = m_strInsurancePolicyNo;

                    if (String.IsNullOrEmpty(m_strPoliceOffice)) { if (!_dataRow.Ispolice_officeNull()) _dataRow.Setpolice_officeNull(); }
                    else if (_dataRow.Ispolice_officeNull() ? true : _dataRow.police_office != m_strPoliceOffice) _dataRow.police_office = m_strPoliceOffice;

                    if (String.IsNullOrEmpty(m_strPoliceReportNo)) { if (!_dataRow.Ispolice_report_noNull()) _dataRow.Setpolice_report_noNull(); }
                    else if (_dataRow.Ispolice_report_noNull() ? true : _dataRow.police_report_no != m_strPoliceReportNo) _dataRow.police_report_no = m_strPoliceReportNo;

                    if (String.IsNullOrEmpty(m_strWitnesses)) { if (!_dataRow.IswitnessesNull()) _dataRow.SetwitnessesNull(); }
                    else if (_dataRow.IswitnessesNull() ? true : _dataRow.witnesses != m_strWitnesses) _dataRow.witnesses = m_strWitnesses;

                    if (String.IsNullOrEmpty(m_strWitnessComments)) { if (!_dataRow.Iswitness_commentsNull()) _dataRow.Setwitness_commentsNull(); }
                    else if (_dataRow.Iswitness_commentsNull() ? true : _dataRow.witness_comments != m_strWitnessComments) _dataRow.witness_comments = m_strWitnessComments;

                    if (String.IsNullOrEmpty(m_strMiscNotes)) { if (!_dataRow.Ismisc_notesNull()) _dataRow.Setmisc_notesNull(); }
                    else if (_dataRow.Ismisc_notesNull() ? true : _dataRow.misc_notes != m_strMiscNotes) _dataRow.misc_notes = m_strMiscNotes;

                    if (String.IsNullOrEmpty(m_strImageAttached)) { if (!_dataRow.Isimage_nameNull()) _dataRow.Setimage_nameNull(); }
                    else if (_dataRow.Isimage_nameNull() ? true : _dataRow.image_name != m_strImageAttached) _dataRow.image_name = m_strImageAttached;

                    if (iMessageId.HasValue) _dataRow.message_id = iMessageId.Value;
                    else _dataRow.Setmessage_idNull();
                   
                }
                else
                {
                    if (iUserId.HasValue) _dataRow.user_id = iUserId.Value;
                    else _dataRow.Setuser_idNull();
                    
                    if (String.IsNullOrEmpty(strStreet)) _dataRow.SetstreetNull();
                    else _dataRow.street = strStreet;

                    if (String.IsNullOrEmpty(strCity)) _dataRow.SetcityNull();
                    else _dataRow.city = strCity;

                    if (String.IsNullOrEmpty(strState)) _dataRow.SetstateNull();
                    else _dataRow.state = strState;

                    if (String.IsNullOrEmpty(strDescription)) _dataRow.SetdescriptionNull();
                    else _dataRow.description = strDescription;

                    if (String.IsNullOrEmpty(strDriverName)) _dataRow.Setdriver_nameNull();
                    else _dataRow.driver_name = strDriverName;

                    if (String.IsNullOrEmpty(strDriverPhone)) _dataRow.Setdriver_phoneNull();
                    else _dataRow.driver_phone = strDriverPhone;

                    if (String.IsNullOrEmpty(strDriverLicenseStatePlate)) _dataRow.Setdriver_license_state_plateNull();
                    else _dataRow.driver_license_state_plate = strDriverLicenseStatePlate;

                    if (String.IsNullOrEmpty(strDriverLicenseNo)) _dataRow.Setdriver_license_noNull();
                    else _dataRow.driver_license_no = strDriverLicenseNo;

                    if (String.IsNullOrEmpty(strDriverVehicleType)) _dataRow.Setdriver_vehicle_typeNull();
                    else _dataRow.driver_vehicle_type = strDriverVehicleType;

                    if (String.IsNullOrEmpty(strInsuranceCompanyName)) _dataRow.Setinsurance_company_nameNull();
                    else _dataRow.insurance_company_name = strInsuranceCompanyName;

                    if (String.IsNullOrEmpty(strInsurancePolicyNo)) _dataRow.Setinsurance_policy_noNull();
                    else _dataRow.insurance_policy_no = strInsurancePolicyNo;

                    if (String.IsNullOrEmpty(strPoliceOffice)) _dataRow.Setpolice_officeNull();
                    else _dataRow.police_office = strPoliceOffice;

                    if (String.IsNullOrEmpty(strPoliceReportNo)) _dataRow.Setpolice_report_noNull();
                    else _dataRow.police_report_no = strPoliceReportNo;

                    if (String.IsNullOrEmpty(strWitnesses)) _dataRow.SetwitnessesNull();
                    else _dataRow.witnesses = strWitnesses;

                    if (String.IsNullOrEmpty(strWitnessComments)) _dataRow.Setwitness_commentsNull();
                    else _dataRow.witness_comments = strWitnessComments;

                    if (String.IsNullOrEmpty(strMiscNotes)) _dataRow.Setmisc_notesNull();
                    else _dataRow.misc_notes = strMiscNotes;

                    if (String.IsNullOrEmpty(strImageAttached)) _dataRow.Setimage_nameNull();
                    else _dataRow.image_name = strImageAttached;

                    if (iMessageId.HasValue) _dataRow.message_id = iMessageId.Value;
                    else _dataRow.Setmessage_idNull();

                    _thisTable.AddAccidentReportRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
            SummitDS.AccidentReportRow thisRow = _rowToSave as SummitDS.AccidentReportRow;
            if (thisRow != null)
            {
                this._ID = thisRow.accident_id;
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
