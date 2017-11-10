using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LohanaBusinessEntities.HotelTypeInfo;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities;

namespace Lohana.Models.Master
{
    public class HotelTypeViewModel
    {
        public HotelTypeViewModel()
        {
            HotelTypeInfo = new HotelTypeInfo();

            Pager = new PaginationInfo();

            HotelTypes = new List<HotelTypeInfo>();

            FriendlyMessage = new List<FriendlyMessage>();

            Filter = new HotelTypeFilter();
        }
        public HotelTypeInfo HotelTypeInfo { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public List<HotelTypeInfo> HotelTypes { get; set; }

        public HotelTypeFilter Filter
        {
            get;
            set;
        }


        public object HotelType { get; set; }
    }

    public class HotelTypeFilter
    {
        public string HotelType { get; set; }

        public int HotelTypeId { get; set; }

    }

}