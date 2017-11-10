
using System.Data;
using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lohana.Models.Lookup
{
    public class LookupViewModel
    {
        public LookupViewModel()
        {
            Pager = new PaginationInfo();

            PartialDt = new DataTable();

            HeaderNames = new string[0];

        }

        public PaginationInfo Pager { get; set; }

        public DataTable PartialDt { get; set; }

        public string[] HeaderNames { get; set; }

        public string Value { get; set; }

        public string EditLookupValue { get; set; }

    }
}