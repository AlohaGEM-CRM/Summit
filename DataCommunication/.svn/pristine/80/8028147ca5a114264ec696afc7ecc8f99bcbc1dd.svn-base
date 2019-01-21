using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;


namespace SummitShopApp
{
    /// <summary>
    /// Encapsulates the base page for all pages in the application
    /// </summary>
    public abstract class BasePage: Page
    {
       
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            // Registers main javascript file.
            if (!Page.ClientScript.IsClientScriptIncludeRegistered(this.GetType(), "SummitJavaScriptInclude"))
            {
                Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "SummitJavaScriptInclude", "Javascripts/Main.js");
            }

        }
     
    }
}
