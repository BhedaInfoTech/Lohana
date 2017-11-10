using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Vehicle;
using LohanaBusinessEntities.VehicleBrand;
using LohanaBusinessEntities.VehicleType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lohana.Models.Master
{
    public class VehicleViewModel
    {
        public VehicleViewModel ()
        {
            Vehicle = new VehicleInfo();

            Filter = new VehicleFilter();

            Vehicles = new List<VehicleInfo>();

            VehicleTypeId= new List<VehicleTypeInfo>();

            VehicleBrandId = new List<VehicleBrandInfo>();
                     
            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();

        }

        public VehicleInfo Vehicle
        {
            get;
            set;
        }

        public VehicleFilter Filter
        {
            get;
            set;
        }

        public List<VehicleInfo> Vehicles
        {
            get;
            set;
        }

        public List<VehicleTypeInfo> VehicleTypeId { get; set; }

        public List<VehicleBrandInfo> VehicleBrandId { get; set; }

        public PaginationInfo Pager { get; set; }

        public IEnumerable<string> Items { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

    }

    public class VehicleFilter
    {
        public int VehicleId { get; set; }

        public string VehicleName { get; set; }

    }
}