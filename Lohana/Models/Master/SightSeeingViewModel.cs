using LohanaBusinessEntities.City;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.SightSeeing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LohanaBusinessEntities.Accessories;

namespace Lohana.Models.Master
{
    public class SightSeeingViewModel
    {
        public SightSeeingViewModel()
        {
            SightSeeing = new SightSeeingInfo();

            SightSeeings = new List<SightSeeingInfo>();

            Cities = new List<CityInfo>();           

            Filter = new SightSeeingFilter();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();

            SightSeeingSearchExtraChildList = new List<SightSeeingInfo>();

            SightSeeingSearchExtraAdultList = new List<SightSeeingInfo>();

            SightSeeingSearchList = new List<SightSeeingInfo>();
        }

        public SightSeeingInfo SightSeeing { get; set; }

        public List<SightSeeingInfo> SightSeeings { get; set; }

        public List<CityInfo> Cities { get; set; }

        public PaginationInfo Pager { get; set; }

        public SightSeeingFilter Filter { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public List<SightSeeingInfo> SightSeeingSearchExtraChildList { get; set; }

        public List<SightSeeingInfo> SightSeeingSearchExtraAdultList { get; set; }

        public List<SightSeeingInfo> SightSeeingSearchList { get; set; }

        public List<AccessoriesInfo> Images { get; set; }

        public bool Flags { get; set; }

        public bool AddtoCart { get; set; }
    }

    public class SightSeeingFilter
    {
        public int SightSeeingId {get; set;}

    }
    
}