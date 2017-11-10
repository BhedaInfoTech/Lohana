using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.Tariff.VehicleTariff
{
    public class VehicleTariffInfo
    {

        public List<VehicleTariffPriceDetailsInfo> VehicleTaiffPriceDetails { get; set; }

        public List<VehicleTariffCustomerCategoryDetailsInfo> VehicleTariffCustomerCategoryDetails { get; set; }

        public VehicleTariffInfo()
        {

            VehicleTaiffPriceDetails = new List<VehicleTariffPriceDetailsInfo>();

            VehicleTariffCustomerCategoryDetails = new List<VehicleTariffCustomerCategoryDetailsInfo>();

        }

        public int VehicleTariffId { get; set; }

        //dropdown

        public int VendorId { get; set; }

        public string VendorName { get; set; }

        public string PackageName { get; set; }

        public string Inclusions { get; set; }

        public string Exclusions { get; set; }

        public string CancellationPolicy { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

    }

    public class VehicleTariffPriceDetailsInfo
    {
        public int VehicleTariffPriceDetailsId { get; set; }

        public int VehicleTariffId { get; set; }

        public int VehicleId { get; set; }

        public string VehicleName { get; set; }

        public string VehicleTypeName { get; set; }

        public int SeatingCapacity { get; set; }

        public int FreeKms { get; set; }

        public int KmAmount { get; set; }

        public int RupeesPerExtraKm { get; set; }

        public int Duration { get; set; }

        public int HoursAmount { get; set; }

        public int RupeesPerExtraHours { get; set; }

        //public string Source { get; set; }

        //public string Destination { get; set; }
        public int Source { get; set; }

        public int Destination { get; set; }

        public int PackageAmount { get; set; }

        public int TransferType { get; set; }

        public int TransferSource { get; set; }

        public int TransferDestination { get; set; }

        public int TransferPackageAmount { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

    }

    public class VehicleTariffCustomerCategoryDetailsInfo
    {
        public int VehicleTariffCustomerCategoryDetailsId { get; set; }

        public int VehicleTariffId { get; set; }

        public int CustomerCategoryId { get; set; }

        public string CustomerCategoryName { get; set; }

        public decimal Margin { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

    }

}
