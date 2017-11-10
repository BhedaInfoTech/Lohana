using LohanaBusinessEntities.Accessories;
using LohanaBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lohana.Models.Accessories
{
    public class AccessoriesViewModel
    {
        public AccessoriesViewModel()
        {
            Accessories = new AccessoriesInfo();

            Images = new List<AccessoriesInfo>();

            FriendlyMessage = new List<FriendlyMessage>();            
        }

        public AccessoriesInfo Accessories { get; set; }

        public string FileName { get; set; }

        public string NewFileName { get; set; }

        public List<AccessoriesInfo> Images { get; set; }

        public HttpFileCollectionBase FileCollection { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }
    }
}