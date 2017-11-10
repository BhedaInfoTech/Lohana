using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Facility;
using LohanaBusinessEntities.FacilityType;

namespace Lohana.Models.Master
{
    public class FacilityViewModel
    {

        public FacilityViewModel()
        {
            FriendlyMessage = new List<FriendlyMessage>();

            Pager = new PaginationInfo();

            Facility = new FacilityInfo();

            Facilities = new List<FacilityInfo>();

            FacilityTypes = new List<FacilityTypeInfo>();

            Filter = new FacilityFilter();
        }


        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public PaginationInfo Pager { get; set; }

        public FacilityInfo Facility { get; set; }

        public List<FacilityInfo> Facilities { get; set; }

        public List<FacilityTypeInfo> FacilityTypes { get; set; }

        public FacilityFilter Filter { get; set; }


    }

    public class FacilityFilter
    {
        public string FacilityName { get; set; }


    }


}