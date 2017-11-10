using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.LohanaPackageTariff
{
    public class LohanaPackageTariffInfo
    {
        public int LohanaPackageTariffId { get; set; }

        public string PackageName { get; set; }

        public int DayDuration { get; set; }

        public int NightDuration { get; set; }

        public int PackageTypeId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

    
    }

    public class LohanaPackageTariffHotelInfo
    {
        public int LohanaPackageTariffHotelId { get; set; }

        public int HotelTariffRoomDetailsId { get; set; }

        public int LohanaPackageTariffId { get; set; }

        //public int HotelTariffRoomOccupancyId { get; set; }

        public int SupplierHotelDetailId { get; set; }

        public int LohanaPackageTariffRootId { get; set; }

        public int LohanaPackageTariffRootDetailId { get; set; }

        public int LohanaPackageTariffRefId { get; set; }

        public int LohanaPackageTariffTypeId { get; set; }

        public int NoOfNight { get; set; }

        public int CityId { get; set; }

        public int HotelId { get; set; }

        public int RoomTypeId { get; set; }

        public int MealId { get; set; }

        public int OldNoOfNight { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

    }

    public class LohanaPackageTariffVehicleInfo
    {
       

        public int LohanaPackageTariffVehicleId { get; set; }

        public int LohanaPackageTariffId { get; set; }

        public int VehicleTariffId { get; set; }

        public int NoOfNight { get; set; }

        public int VendorId { get; set; }

        public int VehicleId { get; set; }

        public int VehicleTypeId { get; set; }

        public int VehicleBrandId { get; set; }

        public int VehicleTariffPriceDetailsId { get; set; }

        public int LohanaPackageTariffRootId { get; set; }

        public int LohanaPackageTariffRootDetailId { get; set; }

        public int LohanaPackageTariffRefId { get; set; }

        public int LohanaPackageTariffTypeId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }
    }

    #region Root Details 

    public class LohanaPackageTariffRootInfo
    {
        public int LohanaPackageTariffId { get; set; }
        public int LohanaPackageTariffRootId { get; set; }
        public int LohanaPackageTariffRootDetailId { get; set; }
        public int LohanaPackageTariffRefId { get; set; }
        public string LohanaPackageTariffRefName { get; set; }
        public int Day { get; set; }
        public string Title { get; set; }
        public int LohanaPackageTariffTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    } 

    #endregion

    #region Sight Seeing
    public class LohanaPackageTariffSightSeeingInfo// : LohanaPackageTariffRootInfo
    {
        public int SightSeeingTariffId { get; set; }
        public int CityId { get; set; }
        public string SightSeeingname { get; set; }
    }
    #endregion
}
