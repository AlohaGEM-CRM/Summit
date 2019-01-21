using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SummitShopApp.BL;
using SummitShopApp.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace SummitShopApp
{
    public partial class Certifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SecurityCheck1.checkAccess();
                if (!IsPostBack)
                {
                    showData();
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
            }
        }

        //select the appropriate vehicle checkboxes for which the shop is certified
        protected void chkVehicles_DataBound(object sender, EventArgs e)
        {
            try
            {
                if (SessionInfo.UserShop.SetInSession)
                {
                    List<BodyShopVehiclesBL> objBodyShopNetworks = BodyShopVehiclesBL.getDataByShopId(Convert.ToInt32(SessionInfo.UserShop.id));

                    if (objBodyShopNetworks != null)
                    {
                        foreach (ListItem lstItem in chkVehicles.Items)
                        {
                            BodyShopVehiclesBL obj = objBodyShopNetworks.Find(c => c.iVehicleId == Convert.ToInt32(lstItem.Value));
                            if (obj != null)
                            {
                                lstItem.Selected = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
            }
        }

        // save the changes if new certification is added save that or if deselected delete this
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SessionInfo.UserShop.SetInSession)
                {
                    List<BodyShopVehiclesBL> objlstBodyShopNetworks = BodyShopVehiclesBL.getDataByShopId(Convert.ToInt32(SessionInfo.UserShop.id));

                    if (objlstBodyShopNetworks != null)
                    {
                        Boolean flag = true;
                        foreach (ListItem lstItem in chkVehicles.Items)
                        {
                            if (lstItem.Selected)
                            {
                                BodyShopVehiclesBL obj = objlstBodyShopNetworks.Find(c => c.iVehicleId == Convert.ToInt32(lstItem.Value));
                                if (obj == null)
                                {
                                    BodyShopVehiclesBL objBodyShopNetwork = new BodyShopVehiclesBL();
                                    objBodyShopNetwork.iShopId = Convert.ToInt32(SessionInfo.UserShop.id);
                                    objBodyShopNetwork.iVehicleId = Convert.ToInt32(lstItem.Value);

                                    if (!objBodyShopNetwork.Save())
                                    {
                                        flag = false;
                                    }
                                }
                            }
                            else
                            {
                                BodyShopVehiclesBL obj = objlstBodyShopNetworks.Find(c => c.iVehicleId == Convert.ToInt32(lstItem.Value));
                                if (obj != null)
                                {
                                    if (!obj.Delete())
                                    {
                                        flag = false;
                                    }
                                }
                            }
                        }
                        if (flag == true)
                        {
                            Master.MessageTitle = Constants.SUCCESS;
                            Master.Message = Constants.SAVE_SUCCESS;
                        }
                        else
                        {
                            Master.MessageTitle = Constants.ERROR;
                            Master.Message = Constants.SAVE_FAILED;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
            }
        }

        //show the all certifications 
        private void showData()
        {
            List<VehiclesBL> objlstNetworkName = VehiclesBL.getData();

            if (objlstNetworkName != null && objlstNetworkName.Count > 0)
            {
                chkVehicles.DataSource = objlstNetworkName;
                chkVehicles.DataTextField = "strVehicleName";
                chkVehicles.DataValueField = "ID";
                chkVehicles.DataBind();
            }
        }

        //redirect back to company information
        protected void btnCompanyInfo_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(Constants.COMPANYINFO_PAGE);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
            }
        }
    }
}
