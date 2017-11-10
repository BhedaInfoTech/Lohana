using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lohana.Models.Common
{
    public class AuthorisationViewModel
    {
        #region Private Member

        private string _displayBtnAdd = "none";

        private string _displayBtnEdit = "none";

        private string _displayBtnView = "none";

        private string _readonly = "false";

        #endregion

        # region Properties

        public string DisplayBtnAdd
        {
            get 
            { 
                return _displayBtnAdd; 
            }
            set 
            { 
                _displayBtnAdd = value; 
            }
        }

        public string DisplayBtnEdit
        {
            get
            {
                return _displayBtnEdit;
            }
            set
            {
                _displayBtnEdit = value;
            }
        }

        public string DisplayBtnView
        {
            get
            {
                return _displayBtnView;
            }
            set
            {
                _displayBtnView = value;
            }
        }

        # endregion
    }
}