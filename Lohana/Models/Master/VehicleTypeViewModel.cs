using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.VehicleType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lohana.Models.Master
{
    public class VehicleTypeViewModel
    {
        public VehicleTypeViewModel()
        {
            VehicleType = new VehicleTypeInfo();

            Filter = new VehicleTypeFilter();

            VehicleTypes = new List<VehicleTypeInfo>();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();

        }

        public VehicleTypeInfo VehicleType
        {
            get;
            set;
        }

        public VehicleTypeFilter Filter
        {
            get;
            set;
        }

        public List<VehicleTypeInfo> VehicleTypes
        {
            get;
            set;
        }

        public PaginationInfo Pager { get; set; }

        public IEnumerable<string> Items { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }
    }



    public class VehicleTypeFilter
    {
        public string VehicleTypeName { get; set; }

        public string VehicleTypedId { get; set; }



    }

}