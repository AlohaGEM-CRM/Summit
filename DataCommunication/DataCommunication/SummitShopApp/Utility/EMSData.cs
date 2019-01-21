using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

namespace SummitShopApp.Utility
{
    public class EMSData
    {
        public String strOwnerFirstName { get; set; }
        public String strOwnerLastName { get; set; }
        public String strOwnerSocialTitle { get; set; }
        public String strOwnerCompanyName { get; set; }
        public String strOwnerAddress1 { get; set; }
        public String strOwnerAddress2 { get; set; }
        public String strOwnerCity { get; set; }
        public String strOwnerState { get; set; }
        public String strOwnerZipCode { get; set; }
        public String strOwnerCountryCode { get; set; }
        public String strOwnerPhone1 { get; set; }
        public String strOwnerPhone1Ext { get; set; }
        public String strOwnerPhone2 { get; set; }
        public String strOwnerPhone2Ext { get; set; }
        public String strOwnerFax { get; set; }
        public String strOwnerFaxExt { get; set; }
        public String strOwnerEmail { get; set; }
        public String strUserName { get { return strOwnerFirstName + " " + strOwnerLastName; } }
        public String status { get; set; }

        //Vehicle Info
        public String strYear { get; set; }
        public String strMake { get; set; }
        public String strModel { get; set; }
        public String strStyle { get; set; }
        public String strColor { get; set; }
        public String strPaintCode { get; set; }
        public String strVIN { get; set; }
        public String strLicense { get; set; }
        public String strProductionDate { get; set; }

        //Delivery Date
        public String strDeliveryDate { get; set; }

        //File Info 
        public String strFileName { get; set; }

        //insurance information 
        public String strInsuranceCompanyName { get; set; }
        public String strInsuranceCompanyAddress { get; set; }
        public String strInsuranceCompanyCity { get; set; }
        public String strInsuranceCompanyState { get; set; }
        public String strInsuranceCompanyZipCode { get; set; }
        public String strInsuranceCompanyPhone { get; set; }
        public String strInsuranceCompanyEmail { get; set; }
        public String strInsuranceCompanyFax { get; set; }
        public String strDeductible { get; set; }
        public String strDateOfLoss { get; set; }

        public String strNetTotalAmount { get; set; }
        public String strRONumbert { get; set; }
        public String strClaimNumber { get; set; }
        public String strInsuranceAgentName { get; set; }

        public string strEstimateFileId { get; set; }

        public string strEstimatorName { get; set; }

        //added for date in and date out functionality
        public string strDateIn { get; set; }
        public string strDateOut_Tar_Date { get; set; }
        public string strDateOut_Ro_Cmp_Date { get; set; }

        #region "IComparable"
        public int CompareTo(EMSData emsData, String comparisonType)
        {
            String baseComparisonType = comparisonType;
            Int32 compareResult = 0;
            Int32 descFlag = 1; //-1 for descending, + 1 for ascending, multiply by compare result


            String name = String.Empty;
            String au2Name = String.Empty;

            if (comparisonType.Contains("DESC"))
            {
                descFlag = -1;
                string[] compArr = comparisonType.Split(new Char[] { ' ' });
                if (compArr.Length > 0)
                {
                    baseComparisonType = compArr[0];
                }
            }

            switch (comparisonType)
            {
                case "UserNameASC":
                    descFlag = 1;
                    //if (emsData.strUserName != null)
                    //{
                    compareResult = strUserName.CompareTo(emsData.strUserName);
                    // }
                    break;

                case "UserNameDESC":
                    descFlag = -1;
                    compareResult = strUserName.CompareTo(emsData.strUserName);
                    break;

                default:
                    descFlag = 1;
                    compareResult = strUserName.CompareTo(emsData.strUserName);
                    break;

            }
            return compareResult * descFlag; //desc flag of -1 returns negative result for descending sort
        }
        #endregion
    }

    public class EMSDataComparer : IComparer<EMSData>
    {
        private String comparisonType;

        public String ComparisonType
        {
            get { return comparisonType; }
            set { comparisonType = value; }
        }

        public int Compare(EMSData o1, EMSData o2)
        {
            return o1.CompareTo(o2, comparisonType);
        }
    }
}