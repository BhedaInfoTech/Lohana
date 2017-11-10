using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.FacilityType;


namespace Lohana.Models.Master
{
    public class FacilityTypeViewModel
    {

        public FacilityTypeViewModel()
        {
            FriendlyMessage = new List<FriendlyMessage>();

            Pager = new PaginationInfo();

            FacilityType = new FacilityTypeInfo();

            FacilityTypes = new List<FacilityTypeInfo>();

            Filter = new FacilityTypeFilter();
        }


        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public PaginationInfo Pager { get; set; }

        public FacilityTypeInfo FacilityType { get; set; }

        public List<FacilityTypeInfo> FacilityTypes { get; set; }

        public FacilityTypeFilter Filter { get; set; }

    }

    public class FacilityTypeFilter
    {
        public string FacilityName { get; set; }
    }

}