using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace SummitShopApp
{
    public partial class AjaxCallBack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string CallbackRef = Page.ClientScript.GetCallbackEventReference(this, "document.getElementById('selRate').value", "RateContent", "null");
           // btnRate.Attributes["onclick"] = String.Format("javascript:{0}", CallbackRef);
        }

        protected void UpdateTimer_Tick(object sender, EventArgs e)
        {
            DateStampLabel.Text = DateTime.Now.ToString();
        }

    }
}
