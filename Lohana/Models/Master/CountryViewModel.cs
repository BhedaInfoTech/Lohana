using LohanaBusinessEntities;
using LohanaBusinessEntities.Country;
using LohanaBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lohana.Models.Common;

namespace Lohana.Models.Master
{
    public class CountryViewModel : AuthorisationViewModel
    {
        public CountryViewModel()
        {
            Country = new CountryInfo();

            Filter = new CountryFilter();

            Countries = new List<CountryInfo>();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();
        }

        public CountryInfo Country
        {
            get;
            set;
        }

        public CountryFilter Filter
        {
            get;
            set;
        }

        public List<CountryInfo> Countries
        {
            get;
            set;
        }

        public PaginationInfo Pager { get; set; }

        public IEnumerable<string> Items { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }
    }

    public class CountryFilter
    {
        public string CountryName { get; set; }

        public string CountryId { get; set; }

    }
}