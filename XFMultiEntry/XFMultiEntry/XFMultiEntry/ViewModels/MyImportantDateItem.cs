using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XFMultiEntry.ViewModels
{
    public class MyImportantDateItem : BindableBase
    {

        #region Name
        private string _Name;
        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get { return this._Name; }
            set { this.SetProperty(ref this._Name, value); }
        }
        #endregion

        #region Date
        private DateTime _Date;
        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date
        {
            get { return this._Date; }
            set { this.SetProperty(ref this._Date, value); }
        }
        #endregion

        #region MyColor
        private Color _MyColor = Color.Yellow;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public Color MyColor
        {
            get { return this._MyColor; }
            set { this.SetProperty(ref this._MyColor, value); }
        }
        #endregion

        public MyImportantDateItem()
        {

        }
    }
}
