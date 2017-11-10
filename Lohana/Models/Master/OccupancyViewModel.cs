using LohanaBusinessEntities;
using LohanaBusinessEntities.Occupancy;
using LohanaBusinessEntities.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lohana.Models.Master
{
    public class OccupancyViewModel
    {
        public OccupancyViewModel()
        {

            Occupancy = new OccupancyInfo();

            Occupancies = new List<OccupancyInfo>();

            Filter = new OccupancyFilter();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();

        }

        public OccupancyInfo Occupancy { get; set; }

        public List<OccupancyInfo> Occupancies { get; set; }

        public PaginationInfo Pager { get; set; }

        public OccupancyFilter Filter { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

    }

        public class OccupancyFilter
        {
            public string OccupancyName { get; set; }

            public int OccupancyValue { get; set; }

        }
}