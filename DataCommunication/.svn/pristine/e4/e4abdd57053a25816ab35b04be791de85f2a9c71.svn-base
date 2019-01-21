using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace SummitShopApp.BL
{
    [System.Serializable()]
    public abstract class BaseEditableItem : BaseItemId
    {

        protected DataRow _rowToSave;
        #region Constructors
        public BaseEditableItem()
        {

        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Save The record to DataBase. It will call CanSave,SaveToRow
        /// OnSaving,Update,SetId and OnSaved Methods.
        /// </summary>
        public Boolean Save()
        {
            CanSave();
            SaveToRow();
            OnSaving();
            Update();
            SetID();
            OnSaved();
            return true;
        }

        /// <summary>
        /// Save The record to DataBase. It will call CanSave,SaveToRow
        /// Delete,OnDeleting,Update and OnDeleted Methods.
        /// </summary>
        public Boolean Delete()
        {
            CanSave();
            SaveToRow();
            _rowToSave.Delete();
            OnDeleting();
            Update();
            OnDeleted();
            return true;
        }
        #endregion Methods


        #region Abstract Methods

        protected abstract void SaveToRow();        
        /// <summary>
        /// This is to save the record from datarow to object.
        /// </summary>
        protected abstract void LoadFromRow(DataRow dr);

        /// <summary>
        /// This method is to save/update the record in database.
        /// </summary>
        protected abstract void Update();

        /// <summary>
        /// This method is to delete the record from database.
        /// </summary>
        protected abstract void DeleteRecord();

        /// <summary>
        /// This method is to set Id field of object when record get updated/inserted in database.
        /// </summary>
        protected abstract void SetID();
        #endregion Abstract Methods

        #region Virtual Methods


        /// <summary>
        /// This method will called when the record gets deleted from database.
        /// </summary>
        protected virtual Boolean OnDeleted()
        {
            return true;
        }

        /// <summary>
        /// This method will called when the record is deleting from database.
        /// </summary>
        protected virtual Boolean OnDeleting()
        {
            return true;
        }

        /// <summary>
        /// This method will called when the record is saving to database.
        /// </summary>
        protected virtual Boolean OnSaving()
        {
            return true;
        }

        /// <summary>
        /// This method will called when the record is saved to database.
        /// </summary>
        protected virtual Boolean OnSaved()
        {
            return true;
        }

        /// <summary>
        /// This method will check that whether record can be saved to or deleted from database.
        /// </summary>
        public virtual Boolean CanSave()
        {
            return true;
        }

        #endregion Virtual Methods
    }
}
