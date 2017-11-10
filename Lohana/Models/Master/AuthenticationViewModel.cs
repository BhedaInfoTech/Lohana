using LohanaBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lohana.Models.Master
{
    public class AuthenticationViewModel
    {
        public AuthenticationViewModel()
        {
            Session = new SessionInfo();

            FriendlyMessage = new List<FriendlyMessage>();
        }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public SessionInfo Session
        {
            get;
            set;
        }

    
    }
}