using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitShopApp.DAL;
using SummitShopApp.DAL.SummitDSTableAdapters;
using System.Data;
using System.Collections;

namespace SummitShopApp.BL
{
    public class FrequencyBL : BaseListItem
    {
        #region "Constructor"

        public FrequencyBL()
        {

        }
        public FrequencyBL(DataRow _drRow)
        {

            LoadFromRow(_drRow);
        }

        #endregion "Constructor"

        #region "Members"

        String m_strFrequency;
        public String strFrequency
        {
            get { return this.m_strFrequency; }
            set { this.m_strFrequency = value; }
        }

        Int32 m_iDays;
        public Int32 iDays
        {
            get { return this.m_iDays; }
            set { this.m_iDays = value; }
        }

        Int32 m_iID;
        public Int32 iID
        {
            get { return this.m_iID; }
            set { this.m_iID = value; }
        }


        #endregion "Members"

        #region "overrides"

        protected override void LoadFromRow(DataRow _dataRow)
        {
            SummitDS.FrequencyRow row = _dataRow as SummitDS.FrequencyRow;

            if (row != null)
            {
                this.m_iID = row.frequency_id;
                this.m_strFrequency = row.frequency;
                this.m_iDays = row.days;
            }
        }

        #endregion "overrides"

        #region "Static Methods"

        private static FrequencyTableAdapter getAdapter()
        {
            return new FrequencyTableAdapter();
        }

        public static List<FrequencyBL> getFrequencyList()
        {
            SummitDS.FrequencyDataTable thisTable = getAdapter().GetData();
            List<FrequencyBL> lstCustomerList = null;

            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                lstCustomerList = BuildFromTable(thisTable);
                lstCustomerList.Sort(new FrequencyBLComparer());
            }
            return lstCustomerList;
        }

        public static FrequencyBL getFrequencyByDays(Int32 iDays)
        {
            SummitDS.FrequencyDataTable thisTable = getAdapter().GetDataByDays(iDays);
            List<FrequencyBL> lstCustomerList = null;

            if (thisTable != null && thisTable.Rows.Count > 0)
            {
                lstCustomerList = BuildFromTable(thisTable);
                if (lstCustomerList != null && lstCustomerList.Count > 0)
                {
                    return lstCustomerList[0];
                }
            }
            return null;
        }

        private static List<FrequencyBL> BuildFromTable(DataTable dtTable)
        {
            List<FrequencyBL> list = new List<FrequencyBL>();
            if (dtTable != null)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    FrequencyBL thisMember = new FrequencyBL(dr);
                    list.Add(thisMember);
                }
            }
            return list;
        }

        #endregion "Static Methods"

        #region "IComparable"

        public int CompareTo(FrequencyBL au2, FrequencyBLComparer.ComparisonType comparisonType)
        {
            FrequencyBLComparer.ComparisonType baseComparisonType = comparisonType;
            Int32 compareResult = 0;
            Int32 descFlag = 1; //-1 for descending, + 1 for ascending, multiply by compare result

            switch (comparisonType)
            {

                case FrequencyBLComparer.ComparisonType.iDays:
                    descFlag = 1;
                    compareResult = iDays.CompareTo(au2.iDays);
                    break;

                case FrequencyBLComparer.ComparisonType.strFrequency:
                    descFlag = 1;
                    compareResult = strFrequency.CompareTo(au2.strFrequency);
                    break;

                default:
                    descFlag = 1;
                    compareResult = iDays.CompareTo(au2.iDays);
                    break;

            }
            return compareResult * descFlag; //desc flag of -1 returns negative result for descending sort
        }
        #endregion
    }

    public class FrequencyBLComparer : IComparer<FrequencyBL>
    {
        public enum ComparisonType
        { strFrequency = 1, iDays = 2, iID = 3 }

        private ComparisonType _comparisonType;

        public ComparisonType ComparisonMethod
        {
            get { return _comparisonType; }
            set { _comparisonType = value; }
        }

        #region IComparer Members

        public int Compare(FrequencyBL objFrequency1, FrequencyBL objFrequency2)
        {
            return objFrequency1.CompareTo(objFrequency2, _comparisonType);
        }

        #endregion
    }
}
