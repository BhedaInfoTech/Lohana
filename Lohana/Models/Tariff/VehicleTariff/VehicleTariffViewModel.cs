using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Tariff.VehicleTariff;
using LohanaBusinessEntities.Vendor;
using LohanaBusinessEntities.Vehicle;
using LohanaBusinessEntities.CustomerCategory;

namespace Lohana.Models.Tariff.VehicleTariff
{
    public class VehicleTariffViewModel
    {

        public VehicleTariffViewModel()
        {

            FriendlyMessage = new List<FriendlyMessage>();

            Pager = new PaginationInfo();

            VehicleTariff = new VehicleTariffInfo();

            VehicleTariffs = new List<VehicleTariffInfo>();

            VehicleTariffFilter = new VehcileTariffFilter();

            VehicleTariffPriceDetail = new VehicleTariffPriceDetailsInfo();
            
            VehicleTariffPriceDetails = new List<VehicleTariffPriceDetailsInfo>();

            VehicleTariffCustomerCategory = new VehicleTariffCustomerCategoryDetailsInfo();

            VehicleTariffCustomerCategories = new List<VehicleTariffCustomerCategoryDetailsInfo>();

            Vendor = new VendorInfo();

            Vendors = new List<VendorInfo>();

            Vehicle = new VehicleInfo();

            Vehicles = new List<VehicleInfo>();

            CustomerCategory = new CustomerCategoryInfo();

            CustomerCategories = new List<CustomerCategoryInfo>();
            

        }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public PaginationInfo Pager { get; set; }

        public VehicleTariffInfo VehicleTariff { get; set; }

        public List<VehicleTariffInfo> VehicleTariffs { get; set; }

        public VehcileTariffFilter VehicleTariffFilter { get; set; }

        public VehicleTariffPriceDetailsInfo VehicleTariffPriceDetail { get; set; }

        public List<VehicleTariffPriceDetailsInfo> VehicleTariffPriceDetails { get; set; }

        public VehicleTariffCustomerCategoryDetailsInfo VehicleTariffCustomerCategory { get; set; }

        public List<VehicleTariffCustomerCategoryDetailsInfo> VehicleTariffCustomerCategories { get; set; }

        public VendorInfo Vendor { get; set; }

        public List<VendorInfo> Vendors { get; set; }

        public VehicleInfo Vehicle { get; set; }

        public List<VehicleInfo> Vehicles { get; set; }

        public CustomerCategoryInfo CustomerCategory { get; set; }

        public List<CustomerCategoryInfo> CustomerCategories { get; set; }
        
    }

    public class VehcileTariffFilter
    {
        public int VehicleTariffId { get; set; }
    }
}