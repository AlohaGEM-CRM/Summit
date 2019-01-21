using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using SummitShopApp.BL;
using SummitShopApp.Utility;
using System.Web.UI.WebControls;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace SummitShopApp
{
    public partial class WebForm1 : BasePage
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            CheckBox chkboxHeader = (CheckBox)gridviewMarketingCenter.HeaderRow.FindControl("chkboxHeader");
            chkboxHeader.Attributes.Add("onClick", string.Format("return {0}('{1}', '{2}')", Constants.ChangeAllGridCheckBoxState, chkboxHeader.ClientID, getGridCheckBoxIDList()));

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    getData();
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
            }
        }

        protected String getAppdownloadDate(object input)
        {
            if (null != input)
            {
                DateTime appDownloadDate = Convert.ToDateTime(input);
                return appDownloadDate.ToShortDateString();
            }
            else
            {
                return String.Empty;
            }

        }

        protected String getAppdownloadTime(object input)
        {
            if (null != input)
            {
                DateTime appDownloadDate = Convert.ToDateTime(input);
                return appDownloadDate.ToShortTimeString();
            }
            else
            {
                return String.Empty;
            }


        }

        protected String getVehicleInfo(object inputYear, object inputMake, object inputModel)
        {
            String year = String.Empty;
            String make = String.Empty;
            String model = String.Empty;

            if (null != inputYear)
                year = inputYear.ToString();

            if (null != inputMake)
                make = inputMake.ToString();

            if (null != inputModel)
                model = inputModel.ToString();

            return String.Format("{0}/{1}/{2}", year, make, model);
        }

        protected void gridviewMarketingCenter_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridviewMarketingCenter.PageIndex = e.NewPageIndex;
                getData();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
            }
        }

        protected void gridviewMarketingCenter_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gridviewMarketingCenter_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                if (IsPostBack)
                {
                    String expression = e.SortExpression + getSortDirection(e.SortExpression);
                    if (!String.IsNullOrEmpty(expression))
                    {
                        MarketingCenterComparer comparer = new MarketingCenterComparer();
                        comparer.ComparisonType = expression;

                        List<MarketingCenterBL> lstCommunicationList = MarketingCenterBL.getMarketinCentersList();
                        lstCommunicationList.Sort(comparer);

                        if (lstCommunicationList.Count > 0)
                        {
                            gridviewMarketingCenter.DataSource = lstCommunicationList;
                            gridviewMarketingCenter.DataBind();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
            }
        }

        private void getData()
        {
            List<MarketingCenterBL> lstRepaireProspects = MarketingCenterBL.getMarketinCentersList();

            String expression = String.Empty;
            if (null != ViewState["SortDirection"] && null != ViewState["SortExpression"])
                expression = String.Format("{0}{1}", ViewState["SortExpression"], ViewState["SortDirection"]);

            if (lstRepaireProspects.Count > 0)
            {

                MarketingCenterComparer comparer = new MarketingCenterComparer();
                comparer.ComparisonType = expression;
                lstRepaireProspects.Sort(comparer);

                gridviewMarketingCenter.DataSource = lstRepaireProspects;
                gridviewMarketingCenter.DataBind();
            }
        }

        private string getSortDirection(string column)
        {
            // By default, set the sort direction to ascending.
            string sortDirection = "ASC";
            // Retrieve the last column that was sorted.
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            // Save new values in ViewState.
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }

        private string getGridCheckBoxIDList()
        {
            String gridChkBoxID = String.Empty;
            StringBuilder sbgridCheckBoxID = new StringBuilder();
            for (int i = 0; i < gridviewMarketingCenter.Rows.Count; i++)
            {
                CheckBox chkboxItem = new CheckBox();
                chkboxItem = (CheckBox)gridviewMarketingCenter.Rows[i].FindControl("chkboxItem");
                if (sbgridCheckBoxID.Length != 0)
                {
                    sbgridCheckBoxID.Append(String.Format(";{0}", chkboxItem.ClientID.ToString()));
                }
                else
                {
                    sbgridCheckBoxID.Append(chkboxItem.ClientID.ToString());
                }
            }
            return sbgridCheckBoxID.ToString();
        }
    }
}
