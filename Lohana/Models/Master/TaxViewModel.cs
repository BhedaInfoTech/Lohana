using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Tax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lohana.Models.Master
{
    public class TaxViewModel
    {
        public TaxViewModel()
        {
            Tax = new TaxInfo();

            Filter = new TaxFilter();

            Taxes = new List<TaxInfo>();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();

        }

        public TaxInfo Tax
        {
            get;
            set;
        }

        public TaxFilter Filter
        {
            get;
            set;
        }

        public List<TaxInfo> Taxes
        {
            get;
            set;
        }
        public PaginationInfo Pager { get; set; }

        public IEnumerable<string> Items { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }
            
    }

    public class TaxFilter
    {
     
       public string TaxName { get; set; }

       public bool IsActive { get; set; }

    }
}