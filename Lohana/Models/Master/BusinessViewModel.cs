using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Business;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lohana.Models.Master
{
    public class BusinessViewModel
    {

        public BusinessViewModel()
        {
            Business = new BusinessInfo();

            Businesses = new List<BusinessInfo>();

            Filter = new BusinessFilter();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();
        }

        public BusinessInfo Business { get; set; }

        public List<BusinessInfo> Businesses { get; set; }

        public PaginationInfo Pager { get; set; }

        public BusinessFilter Filter { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

    }

    public class BusinessFilter
    {
        public string BusinessName {get; set;}

    }
}