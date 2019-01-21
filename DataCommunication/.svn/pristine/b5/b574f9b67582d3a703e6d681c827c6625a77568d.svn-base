using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace SummitShopApp.Services
{
    // NOTE: If you change the interface name "IImport" here, you must also update the reference to "IImport" in Web.config.
    [ServiceContract]
    public interface IImport
    {
        Boolean ValidateUser(String strUserName, String strPassword, out Int32 iShopId);

        [OperationContract]
        String ImportData(String strUserName, String strPassword, ImportData objImportData);

    }
    /// <summary>
    /// Use this class to add your values to appropriate parameters,
    /// Below are the required fields,
    /// Name, Year, Make, Model, Mobile and Email
    /// </summary>
    [DataContract]
    public class ImportData
    {
        #region EMS File Info
        [DataMember]
        public String File_Import_date { get; set; }
        [DataMember]
        public String File_Import_Time { get; set; }
        [DataMember]
        public String File_Status { get; set; }
        [DataMember]
        public String Address { get; set; }
        [DataMember]
        public String Scheduled_In_Date { get; set; }
        [DataMember]
        public String Repair_Start_Date { get; set; }
        [DataMember]
        public String Target_Delivery_Date { get; set; }
        [DataMember]
        public String Actual_Delivery_Date { get; set; }
        [DataMember]
        public String ETA_Hours { get; set; }
        [DataMember]
        public String RO_Hours { get; set; }
        [DataMember]
        public String Claim_Number { get; set; }
        [DataMember]
        public String RO_Number { get; set; }
        [DataMember]
        public String Date_Of_Loss { get; set; }
        [DataMember]
        public String Deductible { get; set; }
        #endregion
        #region Customer Info
        [DataMember(IsRequired = true)]
        public String First_Name { get; set; }
        [DataMember(IsRequired = true)]
        public String Last_Name { get; set; }
        [DataMember]
        public String City { get; set; }
        [DataMember]
        public String State { get; set; }
        [DataMember]
        public String Zip { get; set; }
        #endregion
        #region Vehicle Info
        [DataMember]
        public String Style { get; set; }
        [DataMember]
        public String Color { get; set; }
        [DataMember]
        public String Paint_Code { get; set; }
        [DataMember]
        public String VIN { get; set; }
        [DataMember]
        public String EstimatorName { get; set; }
        [DataMember]
        public String License { get; set; }
        [DataMember(IsRequired = true)]
        public String Year { get; set; }
        [DataMember(IsRequired = true)]
        public String Make { get; set; }
        [DataMember(IsRequired = true)]
        public String Model { get; set; }
        [DataMember(IsRequired = true)]
        public String Mobile { get; set; }
        [DataMember(IsRequired = true)]
        public String Email { get; set; }
        #endregion

        #region Insurance Company Info
        [DataMember]
        public String Insurance_Company { get; set; }
        [DataMember]
        public String Insurance_Company_Contact { get; set; }
        [DataMember]
        public String Insurance_Company_Address { get; set; }
        [DataMember]
        public String Insurance_Company_Email { get; set; }
        [DataMember]
        public String Insurance_Company_City { get; set; }
        [DataMember]
        public String Insurance_Company_State { get; set; }
        [DataMember]
        public String Insurance_Company_Zip { get; set; }
        [DataMember]
        public String Insurance_Company_Fax { get; set; }
        [DataMember]
        public String Agent { get; set; }
        [DataMember]
        public String Agent_Email { get; set; }
        [DataMember]
        public String Total_Amount { get; set; }
        [DataMember]
        public String Total_RO_Amount { get; set; }
        #endregion

        public String strUserName { get { return First_Name + " " + Last_Name; } }

    }
}
