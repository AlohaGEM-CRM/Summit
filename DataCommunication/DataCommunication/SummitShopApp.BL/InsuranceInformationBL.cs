using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;


namespace SummitShopApp.BL
{
    public class InsuranceInformationBL : BaseEditableItem
    {
        #region "Constructor"

        public InsuranceInformationBL()
        {

        }

        public InsuranceInformationBL(DataRow _drRow)
        {
            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        Int32 m_iUserId;
        String m_strAgentName;
        String m_strAgentPhone;
        String m_strAgentCellPhone;
        String m_strAgentWebSite;
        String m_strCompanyName;
        String m_strCompanyEmail;
        String m_strCompanyCellPhone;
        String m_strCompanyWebSite;
        String m_strPolicyNo;
        String m_strAgentEmail;
        Nullable<DateTime> m_dtExpirationDate;
        String m_strCompanyFax;
        String m_strCompanyAddress;
        String m_strCompanyCity;
        String m_strCompanyState;
        String m_strCompanyZip;
        String m_strClaimNumber;
        String m_strROIdentifier;
        String m_strNetTotalAmount;
        String m_strTotalROAmount;
        Nullable<DateTime> m_dtDateOfLoss;
        Nullable<Decimal> m_dDeductible;

        #endregion "Members"

        #region "Accessors"

        public Int32 iUserId
        {
            get { return this.m_iUserId; }
            set { this.m_iUserId = value; }
        }

        public String strAgentName
        {
            get { return this.m_strAgentName; }
            set { this.m_strAgentName = value; }
        }

        public String strAgentPhone
        {
            get { return this.m_strAgentPhone; }
            set { this.m_strAgentPhone = value; }
        }

        public String strAgentCellPhone
        {
            get { return this.m_strAgentCellPhone; }
            set { this.m_strAgentCellPhone = value; }
        }

        public String strAgentWebSite
        {
            get { return this.m_strAgentWebSite; }
            set { this.m_strAgentWebSite = value; }
        }

        public String strCompanyName
        {
            get { return this.m_strCompanyName; }
            set { this.m_strCompanyName = value; }
        }

        public String strCompanyEmail
        {
            get { return this.m_strCompanyEmail; }
            set { this.m_strCompanyEmail = value; }
        }

        public String strCompanyCellPhone
        {
            get { return this.m_strCompanyCellPhone; }
            set { this.m_strCompanyCellPhone = value; }
        }

        public String strCompanyWebSite
        {
            get { return this.m_strCompanyWebSite; }
            set { this.m_strCompanyWebSite = value; }
        }

        public String strPolicyNo
        {
            get { return this.m_strPolicyNo; }
            set { this.m_strPolicyNo = value; }
        }

        public String strAgentEmail
        {
            get { return this.m_strAgentEmail; }
            set { this.m_strAgentEmail = value; }
        }

        public String strClaimNumber
        {
            get { return this.m_strClaimNumber; }
            set { this.m_strClaimNumber = value; }
        }

        public String strROIdentifier
        {
            get { return this.m_strROIdentifier; }
            set { this.m_strROIdentifier = value; }
        }

        public String strNetTotalAmount
        {
            get { return this.m_strNetTotalAmount; }
            set { this.m_strNetTotalAmount = value; }
        }

        public String strTotalROAmount
        {
            get { return this.m_strTotalROAmount; }
            set { this.m_strTotalROAmount = value; }
        }

        public Nullable<DateTime> dtExpirationDate
        {
            get { return this.m_dtExpirationDate; }
            set { this.m_dtExpirationDate = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }

        public String strCompanyFax
        {
            get { return this.m_strCompanyFax; }
            set { this.m_strCompanyFax = value; }
        }

        public String strCompanyAddress
        {
            get { return this.m_strCompanyAddress; }
            set { this.m_strCompanyAddress = value; }
        }

        public String strCompanyCity
        {
            get { return this.m_strCompanyCity; }
            set { this.m_strCompanyCity = value; }
        }

        public String strCompanyState
        {
            get { return this.m_strCompanyState; }
            set { this.m_strCompanyState = value; }
        }

        public String strCompanyZip
        {
            get { return this.m_strCompanyZip; }
            set { this.m_strCompanyZip = value; }
        }

        public Nullable<DateTime> dtDateOfLoss
        {
            get { return this.m_dtDateOfLoss; }
            set { this.m_dtDateOfLoss = value.HasValue ? value.Value.ToUniversalTime() : value; }
        }

        public Nullable<Decimal> dDeductible
        {
            get { return this.m_dDeductible; }
            set { this.m_dDeductible = value; }
        }


        #endregion "Accessors"

        #region "Static Methods"

        private static InsuranceInformationTableAdapter getAdapter()
        {
            return new InsuranceInformationTableAdapter();
        }

        public static InsuranceInformationBL getDataByUserId(Int32 iUserId)
        {
            SummitDS.InsuranceInformationDataTable thisTable = getAdapter().GetDataByUserId(iUserId);
            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                return BuildFromRow(thisTable.Rows[0]);
            }
            return null;
        }

        private static InsuranceInformationBL BuildFromRow(DataRow drRow)
        {
            if (drRow != null)
            {
                return new InsuranceInformationBL(drRow);
            }
            return null;
        }

        private static List<InsuranceInformationBL> BuildFromTable(DataTable dtTable)
        {
            List<InsuranceInformationBL> _list = new List<InsuranceInformationBL>();

            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    InsuranceInformationBL _thisMember = new InsuranceInformationBL(dr);
                    _list.Add(_thisMember);
                }
            }
            return _list;
        }

        #endregion "Static Methods"

        #region "Overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.InsuranceInformationRow _thisRow = _dataRow as SummitDS.InsuranceInformationRow;
            if (_thisRow != null)
            {
                this._ID = _thisRow.insurance_id;
                this.m_iUserId = _thisRow.user_id;
                this.m_strAgentName = _thisRow.Isagent_nameNull() ? String.Empty : _thisRow.agent_name;
                this.m_strAgentPhone = _thisRow.Isagent_phoneNull() ? String.Empty : _thisRow.agent_phone;
                this.m_strAgentCellPhone = _thisRow.Isagent_cell_phoneNull() ? String.Empty : _thisRow.agent_cell_phone;
                this.m_strAgentWebSite = _thisRow.Isagent_websiteNull() ? String.Empty : _thisRow.agent_website;
                this.m_strCompanyName = _thisRow.Iscompany_nameNull() ? String.Empty : _thisRow.company_name;
                this.m_strCompanyEmail = _thisRow.Iscompany_emailNull() ? String.Empty : _thisRow.company_email;
                this.m_strCompanyCellPhone = _thisRow.Iscompany_cell_phoneNull() ? String.Empty : _thisRow.company_cell_phone;
                this.m_strCompanyWebSite = _thisRow.Iscompany_websiteNull() ? String.Empty : _thisRow.company_website;
                this.m_strPolicyNo = _thisRow.Ispolicy_noNull() ? String.Empty : _thisRow.policy_no;
                this.m_strAgentEmail = _thisRow.Isagent_emailNull() ? String.Empty : _thisRow.agent_email;
                this.m_dtExpirationDate = _thisRow.Isexpiration_dateNull() ? (Nullable<DateTime>)null : _thisRow.expiration_date;
                this.m_strCompanyFax = _thisRow.Iscompany_faxNull() ? String.Empty : _thisRow.company_fax;
                this.m_strCompanyAddress = _thisRow.Iscompany_addressNull() ? String.Empty : _thisRow.company_address;
                this.m_strCompanyCity = _thisRow.Iscompany_cityNull() ? String.Empty : _thisRow.company_city;
                this.m_strCompanyState = _thisRow.Iscompany_stateNull() ? String.Empty : _thisRow.company_state;
                this.m_strCompanyZip = _thisRow.Iscompany_zipNull() ? String.Empty : _thisRow.company_zip;
                this.m_strClaimNumber = _thisRow.Isclaim_numberNull() ? String.Empty : _thisRow.claim_number;
                this.m_strROIdentifier = _thisRow.Isrepair_order_identifierNull() ? String.Empty : _thisRow.repair_order_identifier;
                this.m_strNetTotalAmount = _thisRow.Isnet_total_amountNull() ? String.Empty : _thisRow.net_total_amount;
                this.m_strTotalROAmount = _thisRow.Istotal_ro_amountNull() ? String.Empty : _thisRow.total_ro_amount;
                this.m_dtDateOfLoss = _thisRow.Isdate_of_lossNull() ? (Nullable<DateTime>)null : _thisRow.date_of_loss;
                this.m_dDeductible = _thisRow.IsdeductibleNull() ? (Nullable<Decimal>)null : _thisRow.deductible;
                _rowToSave = _thisRow;
            }
        }

        protected override void SaveToRow()
        {
            SummitDS.InsuranceInformationDataTable _thisTable = new SummitDS.InsuranceInformationDataTable();
            if (_rowToSave == null)
                _rowToSave = _thisTable.NewInsuranceInformationRow();
            SummitDS.InsuranceInformationRow _dataRow = _rowToSave as SummitDS.InsuranceInformationRow;

            if (_dataRow != null)
            {
                if (IsExisting())
                {
                    if (_dataRow.user_id != m_iUserId) _dataRow.user_id = m_iUserId;

                    if (String.IsNullOrEmpty(m_strAgentName)) { if (!_dataRow.Isagent_nameNull()) _dataRow.Setagent_nameNull(); }
                    else if (_dataRow.Isagent_nameNull() ? true : _dataRow.agent_name != m_strAgentName) _dataRow.agent_name = m_strAgentName;

                    if (String.IsNullOrEmpty(m_strAgentPhone)) { if (!_dataRow.Isagent_phoneNull()) _dataRow.Setagent_phoneNull(); }
                    else if (_dataRow.Isagent_phoneNull() ? true : _dataRow.agent_phone != m_strAgentPhone) _dataRow.agent_phone = m_strAgentPhone;

                    if (String.IsNullOrEmpty(m_strAgentCellPhone)) { if (!_dataRow.Isagent_cell_phoneNull()) _dataRow.Setagent_cell_phoneNull(); }
                    else if (_dataRow.Isagent_cell_phoneNull() ? true : _dataRow.agent_cell_phone != m_strAgentCellPhone) _dataRow.agent_cell_phone = m_strAgentCellPhone;

                    if (String.IsNullOrEmpty(m_strAgentWebSite)) { if (!_dataRow.Isagent_websiteNull()) _dataRow.Setagent_websiteNull(); }
                    else if (_dataRow.Isagent_websiteNull() ? true : _dataRow.agent_website != m_strAgentWebSite) _dataRow.agent_website = m_strAgentWebSite;

                    if (String.IsNullOrEmpty(m_strCompanyName)) { if (!_dataRow.Iscompany_nameNull()) _dataRow.Setcompany_nameNull(); }
                    else if (_dataRow.Iscompany_nameNull() ? true : _dataRow.company_name != m_strCompanyName) _dataRow.company_name = m_strCompanyName;

                    if (String.IsNullOrEmpty(m_strCompanyEmail)) { if (!_dataRow.Iscompany_emailNull()) _dataRow.Setcompany_emailNull(); }
                    else if (_dataRow.Iscompany_emailNull() ? true : _dataRow.company_email != m_strCompanyEmail) _dataRow.company_email = m_strCompanyEmail;

                    if (String.IsNullOrEmpty(m_strCompanyCellPhone)) { if (!_dataRow.Iscompany_cell_phoneNull()) _dataRow.Setcompany_cell_phoneNull(); }
                    else if (_dataRow.Iscompany_cell_phoneNull() ? true : _dataRow.company_cell_phone != m_strCompanyCellPhone) _dataRow.company_cell_phone = m_strCompanyCellPhone;

                    if (String.IsNullOrEmpty(m_strCompanyWebSite)) { if (!_dataRow.Iscompany_websiteNull()) _dataRow.Setcompany_websiteNull(); }
                    else if (_dataRow.Iscompany_websiteNull() ? true : _dataRow.company_website != m_strCompanyWebSite) _dataRow.company_website = m_strCompanyWebSite;

                    if (String.IsNullOrEmpty(m_strPolicyNo)) { if (!_dataRow.Ispolicy_noNull()) _dataRow.Setpolicy_noNull(); }
                    else if (_dataRow.Ispolicy_noNull() ? true : _dataRow.policy_no != m_strPolicyNo) _dataRow.policy_no = m_strPolicyNo;

                    if (String.IsNullOrEmpty(m_strAgentEmail)) { if (!_dataRow.Isagent_emailNull()) _dataRow.Setagent_emailNull(); }
                    else if (_dataRow.Isagent_emailNull() ? true : _dataRow.agent_email != m_strAgentEmail) _dataRow.agent_email = m_strAgentEmail;

                    if (!m_dtExpirationDate.HasValue) { if (!_dataRow.Isexpiration_dateNull()) _dataRow.Setexpiration_dateNull(); }
                    else if (_dataRow.Isexpiration_dateNull() ? true : _dataRow.expiration_date != m_dtExpirationDate.Value) _dataRow.expiration_date = m_dtExpirationDate.Value;

                    if (String.IsNullOrEmpty(m_strCompanyFax)) { if (!_dataRow.Iscompany_faxNull()) _dataRow.Setcompany_faxNull(); }
                    else if (_dataRow.Iscompany_faxNull() ? true : _dataRow.company_fax != m_strCompanyFax) _dataRow.company_fax = m_strCompanyFax;

                    if (String.IsNullOrEmpty(m_strCompanyAddress)) { if (!_dataRow.Iscompany_addressNull()) _dataRow.Setcompany_addressNull(); }
                    else if (_dataRow.Iscompany_addressNull() ? true : _dataRow.company_address != m_strCompanyAddress) _dataRow.company_address = m_strCompanyAddress;

                    if (String.IsNullOrEmpty(m_strCompanyCity)) { if (!_dataRow.Iscompany_cityNull()) _dataRow.Setcompany_cityNull(); }
                    else if (_dataRow.Iscompany_cityNull() ? true : _dataRow.company_city != m_strCompanyCity) _dataRow.company_city = m_strCompanyCity;

                    if (String.IsNullOrEmpty(m_strCompanyState)) { if (!_dataRow.Iscompany_stateNull()) _dataRow.Setcompany_stateNull(); }
                    else if (_dataRow.Iscompany_stateNull() ? true : _dataRow.company_state != m_strCompanyState) _dataRow.company_state = m_strCompanyState;

                    if (String.IsNullOrEmpty(m_strCompanyZip)) { if (!_dataRow.Iscompany_zipNull()) _dataRow.Setcompany_zipNull(); }
                    else if (_dataRow.Iscompany_zipNull() ? true : _dataRow.company_zip != m_strCompanyZip) _dataRow.company_zip = m_strCompanyZip;

                    if (String.IsNullOrEmpty(m_strClaimNumber)) { if (!_dataRow.Isclaim_numberNull()) _dataRow.Setclaim_numberNull(); }
                    else if (_dataRow.Isclaim_numberNull() ? true : _dataRow.claim_number != m_strClaimNumber) _dataRow.claim_number = m_strClaimNumber;

                    if (String.IsNullOrEmpty(m_strROIdentifier)) { if (!_dataRow.Isrepair_order_identifierNull()) _dataRow.Setrepair_order_identifierNull(); }
                    else if (_dataRow.Isrepair_order_identifierNull() ? true : _dataRow.repair_order_identifier != m_strROIdentifier) _dataRow.repair_order_identifier = m_strROIdentifier;

                    if (String.IsNullOrEmpty(m_strNetTotalAmount)) { if (!_dataRow.Isnet_total_amountNull()) _dataRow.Setnet_total_amountNull(); }
                    else if (_dataRow.Isnet_total_amountNull() ? true : _dataRow.net_total_amount != m_strNetTotalAmount) _dataRow.net_total_amount = m_strNetTotalAmount;

                    if (String.IsNullOrEmpty(m_strTotalROAmount)) { if (!_dataRow.Istotal_ro_amountNull()) _dataRow.Settotal_ro_amountNull(); }
                    else if (_dataRow.Istotal_ro_amountNull() ? true : _dataRow.total_ro_amount != m_strTotalROAmount) _dataRow.total_ro_amount = m_strTotalROAmount;

                    if (dtDateOfLoss.HasValue) _dataRow.date_of_loss = dtDateOfLoss.Value;
                    else _dataRow.Setdate_of_lossNull();

                    if (dDeductible.HasValue) _dataRow.deductible = dDeductible.Value;
                    else _dataRow.SetdeductibleNull();
                }
                else
                {
                    _dataRow.user_id = iUserId;

                    if (String.IsNullOrEmpty(strAgentName)) _dataRow.Setagent_nameNull();
                    else _dataRow.agent_name = strAgentName;

                    if (String.IsNullOrEmpty(strAgentPhone)) _dataRow.Setagent_phoneNull();
                    else _dataRow.agent_phone = strAgentPhone;

                    if (String.IsNullOrEmpty(strAgentCellPhone)) _dataRow.Setagent_cell_phoneNull();
                    else _dataRow.agent_cell_phone = strAgentCellPhone;

                    if (String.IsNullOrEmpty(strAgentWebSite)) _dataRow.Setagent_websiteNull();
                    else _dataRow.agent_website = strAgentWebSite;

                    if (String.IsNullOrEmpty(strCompanyName)) _dataRow.Setcompany_nameNull();
                    else _dataRow.company_name = strCompanyName;

                    if (String.IsNullOrEmpty(strCompanyEmail)) _dataRow.Setcompany_emailNull();
                    else _dataRow.company_email = strCompanyEmail;

                    if (String.IsNullOrEmpty(strCompanyCellPhone)) _dataRow.Setcompany_cell_phoneNull();
                    else _dataRow.company_cell_phone = strCompanyCellPhone;

                    if (String.IsNullOrEmpty(strCompanyWebSite)) _dataRow.Setcompany_websiteNull();
                    else _dataRow.company_website = strCompanyWebSite;

                    if (String.IsNullOrEmpty(strPolicyNo)) _dataRow.Setpolicy_noNull();
                    else _dataRow.policy_no = strPolicyNo;

                    if (String.IsNullOrEmpty(strAgentEmail)) _dataRow.Setagent_emailNull();
                    else _dataRow.agent_email = strAgentEmail;

                    if (dtExpirationDate.HasValue) _dataRow.expiration_date = dtExpirationDate.Value;
                    else _dataRow.Setexpiration_dateNull();

                    if (String.IsNullOrEmpty(m_strCompanyFax)) { if (!_dataRow.Iscompany_faxNull()) _dataRow.Setcompany_faxNull(); }
                    else if (_dataRow.Iscompany_faxNull() ? true : _dataRow.company_fax != m_strCompanyFax) _dataRow.company_fax = m_strCompanyFax;

                    if (String.IsNullOrEmpty(m_strCompanyAddress)) { if (!_dataRow.Iscompany_addressNull()) _dataRow.Setcompany_addressNull(); }
                    else if (_dataRow.Iscompany_addressNull() ? true : _dataRow.company_address != m_strCompanyAddress) _dataRow.company_address = m_strCompanyAddress;

                    if (String.IsNullOrEmpty(m_strCompanyCity)) { if (!_dataRow.Iscompany_cityNull()) _dataRow.Setcompany_cityNull(); }
                    else if (_dataRow.Iscompany_cityNull() ? true : _dataRow.company_city != m_strCompanyCity) _dataRow.company_city = m_strCompanyCity;

                    if (String.IsNullOrEmpty(m_strCompanyState)) { if (!_dataRow.Iscompany_stateNull()) _dataRow.Setcompany_stateNull(); }
                    else if (_dataRow.Iscompany_stateNull() ? true : _dataRow.company_state != m_strCompanyState) _dataRow.company_state = m_strCompanyState;

                    if (String.IsNullOrEmpty(m_strCompanyZip)) { if (!_dataRow.Iscompany_zipNull()) _dataRow.Setcompany_zipNull(); }
                    else if (_dataRow.Iscompany_zipNull() ? true : _dataRow.company_zip != m_strCompanyZip) _dataRow.company_zip = m_strCompanyZip;

                    if (String.IsNullOrEmpty(m_strClaimNumber)) { if (!_dataRow.Isclaim_numberNull()) _dataRow.Setclaim_numberNull(); }
                    else if (_dataRow.Isclaim_numberNull() ? true : _dataRow.claim_number != m_strClaimNumber) _dataRow.claim_number = m_strClaimNumber;

                    if (String.IsNullOrEmpty(m_strROIdentifier)) { if (!_dataRow.Isrepair_order_identifierNull()) _dataRow.Setrepair_order_identifierNull(); }
                    else if (_dataRow.Isrepair_order_identifierNull() ? true : _dataRow.repair_order_identifier != m_strROIdentifier) _dataRow.repair_order_identifier = m_strROIdentifier;

                    if (String.IsNullOrEmpty(m_strNetTotalAmount)) { if (!_dataRow.Isnet_total_amountNull()) _dataRow.Setnet_total_amountNull(); }
                    else if (_dataRow.Isnet_total_amountNull() ? true : _dataRow.net_total_amount != m_strNetTotalAmount) _dataRow.net_total_amount = m_strNetTotalAmount;

                    if (String.IsNullOrEmpty(m_strTotalROAmount)) { if (!_dataRow.Istotal_ro_amountNull()) _dataRow.Settotal_ro_amountNull(); }
                    else if (_dataRow.Istotal_ro_amountNull() ? true : _dataRow.total_ro_amount != m_strTotalROAmount) _dataRow.total_ro_amount = m_strTotalROAmount;

                    if (dtDateOfLoss.HasValue) _dataRow.date_of_loss = dtDateOfLoss.Value;
                    else _dataRow.Setdate_of_lossNull();

                    if (dDeductible.HasValue) _dataRow.deductible = dDeductible.Value;
                    else _dataRow.SetdeductibleNull();

                    _thisTable.AddInsuranceInformationRow(_dataRow);
                }
            }
        }

        protected override void SetID()
        {
            SummitDS.InsuranceInformationRow thisRow = _rowToSave as SummitDS.InsuranceInformationRow;
            if (thisRow != null)
            {
                this._ID = thisRow.insurance_id;
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
