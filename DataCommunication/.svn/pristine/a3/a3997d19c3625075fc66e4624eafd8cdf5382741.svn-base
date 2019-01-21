using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace SummitShopApp.Utility
{
    public class SessionInfo
    {
        String m_strKey;
        internal SessionInfo(String _strKey)
        {
            m_strKey = _strKey;
        }

        protected Object SessionObject
        {
            get { return HttpContext.Current.Session[m_strKey]; }
            set { HttpContext.Current.Session[m_strKey] = value; }
        }

        public String strKey
        {
            get { return m_strKey; }
        }

        /// <summary>
        /// Is this set in the session
        /// </summary>
        public Boolean SetInSession
        {
            get { return SessionObject != null; }
        }

        /// <summary>
        /// Clears Sessions object 
        /// </summary>
        public void Unset()
        {
            SessionObject = null;
        }

        /// <summary>
        /// Get query string value and set session varible base on it 
        /// Also will server tranfer back to calling page without query string
        /// </summary>
        /// <param name="Request">The Page request</param>
        /// <returns>true is had Query string Value - false nothing</returns>
        public virtual Boolean GetFromQueryString(Page _page)
        {
            return false;
        }

        /// <summary>
        /// Set so URL can be built that can retrieve this session item
        /// </summary>
        /// <param name="objValue">what we want the session value to be set to on calling url</param>
        /// <returns>query string name=value</returns>
        public virtual String BuildToQueryString(Object objValue)
        {
            return strKey + "=" + objValue.ToString();
        }

        public class SessionId : SessionInfo
        {
            internal SessionId(String strKey)
                : base(strKey)
            {
            }

            /// <summary>
            /// Id for current object in session
            /// </summary>
            public System.Nullable<Int32> id
            {
                get { return (System.Nullable<Int32>)SessionObject; }
                set { SessionObject = value; }
            }

            public System.String strSign
            {
                get { return (System.String)SessionObject; }
                set { SessionObject = value; }
            }

            /// <summary>
            /// We want to create a new Id
            /// </summary>
            public Boolean IsNew
            {
                get { return (id == 0); }
                set { id = (value ? (System.Nullable<Int32>)0 : null); }
            }

            public override Boolean GetFromQueryString(Page _page)
            {
                Int32 work;
                if (Int32.TryParse(_page.Request.QueryString[strKey], out work))
                {
                    id = work;
                    try
                    {
                        _page.Server.Transfer(_page.Request.CurrentExecutionFilePath, false);
                    }
                    catch
                    {
                    }
                    return true;
                }
                return base.GetFromQueryString(_page);
            }

        }

        public class SessionString : SessionInfo
        {
            internal SessionString(String strKey)
                : base(strKey)
            {
            }

            public String str
            {
                get
                {
                    return (String)SessionObject;
                }
                set
                {
                    SessionObject = value;
                }
            }

        }

        public class SessionObj : SessionInfo
        {
            internal SessionObj(String strKey)
                : base(strKey)
            {
            }

            public Object Obj
            {
                get
                {
                    return SessionObject;
                }
                set
                {
                    SessionObject = value;
                }
            }

        }

        static public SessionId User = new SessionId("UserId");
        static public SessionId UserPassword = new SessionId("UserPassword");
        static public SessionId UserShop = new SessionId("ShopId");
        static public SessionId Role = new SessionId("RoleId");
        static public SessionId Admin = new SessionId("AdminId");
    }
}
