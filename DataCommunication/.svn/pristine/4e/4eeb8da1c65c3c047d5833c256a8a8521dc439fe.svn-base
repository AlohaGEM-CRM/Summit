using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using SummitShopApp.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace SummitShopApp.MasterPage
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        public event EventHandler OkClick;
        public event EventHandler NoClick;
        public event EventHandler DataSaveClick;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, Constants.ExceptionPolicy);
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            String rememberMe = Request.Cookies.Get(Constants.REMEMBER_ME).Value;
            if (String.IsNullOrEmpty(rememberMe))
            {
                Response.Cookies.Add(new HttpCookie(Constants.COOKIE_USERID, ""));
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            }
            Session.Abandon();
            Session.Clear();
            if (Cache["CommunicationList"] != null)
            {
                Cache.Remove("CommunicationList");
            }
            if (Cache["OpportunityList"] != null)
            {
                Cache.Remove("OpportunityList");
            }
            if (Cache["RepairProspect"] != null)
            {
                Cache.Remove("RepairProspect");
            }
            if (Cache["EmailMarketing"] != null)
            {
                Cache.Remove("EmailMarketing");
            }
            if (Cache["TextMarketing"] != null)
            {
                Cache.Remove("TextMarketing");
            }
            if (Cache["InProcessCustomer"] != null)
            {
                Cache.Remove("InProcessCustomer");
            }
            FormsAuthentication.RedirectToLoginPage();

            Response.Redirect(Constants.LOGIN_PAGE);
        }

        public String MessageTitle
        {
            get
            {
                return lblMessageTitle.Text;
            }
            set
            {
                lblMessageTitle.Text = value;
            }
        }

        public String Message
        {
            get
            {
                return lblMessage.Text;
            }
            set
            {
                lblMessage.Text = value;
                if (value != String.Empty)
                {
                    DisplayMsg();
                }
            }
        }

        public String ConfirmMessageTitle
        {
            get
            {
                return lblConfirmMessageTitle.Text;
            }
            set
            {
                lblConfirmMessageTitle.Text = value;
            }
        }

        public String ConfirmMessage
        {
            get
            {
                return lblConfirmMessage.Text;
            }
            set
            {
                lblConfirmMessage.Text = value;
                if (value != String.Empty)
                {
                    DisplayConfirmMsg();
                }
            }
        }

        protected void DisplayMsg()
        {
            Panel1.Style.Value = "visibility:visible";
            ModalPopupExtender1.Show();
        }

        protected void DisplayConfirmMsg()
        {
            pnlConfirmMsg.Style.Value = "visibility:visible";
            modalConfirmExtnder.Show();
        }

        protected void lnkBtnOkClick(object sender, EventArgs e)
        {
            if (OkClick != null)
            {
                OkClick(this, new EventArgs());
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (DataSaveClick != null)
            {
                DataSaveClick(this, new EventArgs());
            }
        }

        protected void lnkBtnCancelClick(object sender, EventArgs e)
        {
            try
            {
                if (NoClick != null)
                {
                    NoClick(this, new EventArgs());
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
            }
        }

        protected void btnBackToMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect(Constants.LANDING_PAGE);
        }        
    }
}
