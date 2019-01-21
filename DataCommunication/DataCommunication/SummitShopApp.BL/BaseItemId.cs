using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SummitShopApp.BL
{
    [System.Serializable()]
    public abstract class BaseItemId
    {
        #region Members
        protected internal int? _ID;
        #endregion Members

        #region Constructors
        public BaseItemId()
        {
        }
        #endregion Constructors

        #region Accessors
        public int ID
        {
            get { return Convert.ToInt32(this._ID); }
        }
        #endregion Accessors

        #region Virtual Methods

        /// <summary>
        /// This method will check whether the record has primary key value or not.
        /// </summary>
        protected virtual Boolean IsExisting()
        {
            return _ID.HasValue;
        }
        #endregion Virtual Methods
    }

}
