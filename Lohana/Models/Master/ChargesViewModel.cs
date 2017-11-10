using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Charges;

namespace Lohana.Models.Master
{
    public class ChargesViewModel
    {
        public ChargesViewModel()
        {
            Charges = new ChargesInfo();

            ChargesList = new List<ChargesInfo>();

            Filter = new ChargesFilter();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();
        }
        public ChargesInfo Charges { get; set; }

        public List<ChargesInfo> ChargesList { get; set; }

        public PaginationInfo Pager { get; set; }

        public ChargesFilter Filter { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public object Vendor { get; set; }
    }

    public class ChargesFilter
    {
        public string ChargesName { get; set; }
       
    }
}