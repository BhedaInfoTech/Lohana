using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.VehicleBrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lohana.Models.Master
{
    public class VehicleBrandViewModel
    {
        public VehicleBrandViewModel()
        {
            VehicleBrand = new VehicleBrandInfo();

            Filter = new VehicleBrandFilter();

            VehicleBrands = new List<VehicleBrandInfo>();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();

        }

        public VehicleBrandInfo VehicleBrand
        {
            get;
            set;
        }

        public VehicleBrandFilter Filter
        {
            get;
            set;
        }

        public List<VehicleBrandInfo> VehicleBrands
        {
            get;
            set;
        }

        public PaginationInfo Pager { get; set; }

        public IEnumerable<string> Items { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }
    }



    public class VehicleBrandFilter
    {
        public string VehicleBrandName { get; set; }

        public string VehicleBrandId { get; set; }



    }

}