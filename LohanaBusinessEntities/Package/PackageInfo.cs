using LohanaBusinessEntities.Accessories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.Package
{
    public class PackageInfo
    {

        public List<PackageItineraryInfo> PackageItinerarys { get; set; }

        public List<PackageDatesInfo> PackageDates { get; set; }

        public List<PackageTypeMappingInfo> PackageTypeMappings { get; set; }

        public List<AccessoriesInfo> Images { get; set; }

        public List<PackageDaysTriffInfo> PackageDaysTriffInfo { get; set; }
        public PackageInfo()
        {
            Images = new List<AccessoriesInfo>();

            PackageItinerarys = new List<PackageItineraryInfo>();

            PackageDates = new List<PackageDatesInfo>();

            PackageTypeMappings = new List<PackageTypeMappingInfo>();

            PackageDaysTriffInfo = new List<PackageDaysTriffInfo>();
        }

        public int PackageId { get; set; }

        public string PackageCode { get; set; }

        public int PackageCategoryId { get; set; }

        public string PackageCategoryName { get; set; }

        public int PackageTypeId { get; set; }

        public string PackageTypeIds { get; set; }

        public string PackageType { get; set; }

        public string PackageTypeName { get; set; }

        public string PackageName { get; set; }

        public string PackageDuration { get; set; }

        public int DayDuration { get; set; }

        public int NightDuration { get; set; }

        public string Color { get; set; }

        // Meal Dropdown

        public int MealId { get; set; }

        public string MealName { get; set; }

        // Hotel Dropdown

        public int HotelId { get; set; }

        public string HotelName { get; set; }

        // Vehicle Dropdown

        public int VehicleId { get; set; }

        public string VehicleName { get; set; }

        //City Dropdown

        public int CountryId { get; set; }

        public string Country { get; set; }

        public int StateId { get; set; }

        public string State { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        //End City Dropdown

        public int DepartureCityId { get; set; }

        public string TourReportingPoint { get; set; }

        public string TourDroppingPoint { get; set; }

        public int PackageCost { get; set; }

        public string Adventure { get; set; }

        public string Speciality { get; set; }

        public string PlaceToVisit { get; set; }

        public string Inclusions { get; set; }

        public string Exclusions { get; set; }

        public string PaymentTems { get; set; }

        public string TourRequirements { get; set; }

        public string ThingsToCarryAlong { get; set; }

        public string Weather { get; set; }

        public string Shopping { get; set; }

        public string TermsCondition { get; set; }

        public string CancellationDetails { get; set; }

        public string RouteChanges { get; set; }

        public string DosAndDonts { get; set; }

        public Boolean Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime FromDate { get; set; }

        public int EnquiryitemId { get; set; }

        public int Adultcount { get; set; }

        public int childcount { get; set; }

        

    }

    public class PackageItineraryInfo
    { 
        public int PackageItineraryId { get; set; }

        public int PackageId { get; set; }

        public int Day { get; set; }

        public string DayTitle { get; set; }
         
        public string SightSeeing { get; set; }

        public int MealId { get; set; }

        public string MealName { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public PackageItineraryInfo()
        {
            PackageItineraryHotels = new List<PackageItineraryHotelsInfo>();
            PackageItineraryFlights = new List<PackageItineraryFlightsInfo>();
            PackageItineraryTrains = new List<PackageItineraryTrainsInfo>();
            PackageItineraryBuses = new List<PackageItineraryBusesInfo>();
            PackageItineraryVehicles = new List<PackageItineraryVehiclesInfo>();

            PackageItineraryHotel = new PackageItineraryHotelsInfo();
            PackageItineraryFlight = new PackageItineraryFlightsInfo();
            PackageItineraryTrain = new PackageItineraryTrainsInfo();
            PackageItineraryBus = new PackageItineraryBusesInfo();
            PackageItineraryVehicle = new PackageItineraryVehiclesInfo();
        }

        public List<PackageItineraryHotelsInfo> PackageItineraryHotels { get; set; }
        public List<PackageItineraryFlightsInfo> PackageItineraryFlights { get; set; }
        public List<PackageItineraryTrainsInfo> PackageItineraryTrains { get; set; }
        public List<PackageItineraryBusesInfo> PackageItineraryBuses { get; set; }
        public List<PackageItineraryVehiclesInfo> PackageItineraryVehicles { get; set; }

        public PackageItineraryHotelsInfo PackageItineraryHotel { get; set; }
        public PackageItineraryFlightsInfo PackageItineraryFlight { get; set; }
        public PackageItineraryTrainsInfo PackageItineraryTrain { get; set; }
        public PackageItineraryBusesInfo PackageItineraryBus { get; set; }
        public PackageItineraryVehiclesInfo PackageItineraryVehicle { get; set; } 

    }

    public class PackageItineraryHotelsInfo
    {
        public int PackageItineraryId { get; set; }

        public int PackageItineraryHotelId { get; set; }

        public int HotelId { get; set; }

        public string HotelName { get; set; }

        public string Location { get; set; }

        public int LocationId { get; set; }

        public int SupplierId { get; set; }

        public String SupplierName { get; set; }

        public Decimal HotelCost { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }
    }

    public class PackageItineraryFlightsInfo
    {
        public int PackageItineraryId { get; set; }

        public int PackageItineraryFlightId { get; set; }

        public string FlightName { get; set; }

        public int FlightFrom { get; set; }

        public int FlightTo { get; set; }

        public string FlightFromName { get; set; }

        public string FlightToName { get; set; }

        public DateTime FlightTime { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }
    }

    public class PackageItineraryTrainsInfo
    {
        public int PackageItineraryId { get; set; }

        public int PackageItineraryTrainId { get; set; }

        public string TrainName { get; set; }

        public int TrainFrom { get; set; }

        public int TrainTo { get; set; }
        
        public string TrainFromName { get; set; }

        public string TrainToName { get; set; }

        public DateTime TrainTime { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }
    }

    public class PackageItineraryBusesInfo
    {
        public int PackageItineraryId { get; set; }

        public int PackageItineraryBusId { get; set; }

        public string BusName { get; set; }

        public int BusFrom { get; set; }

        public int BusTo { get; set; }

        public string BusFromName { get; set; }

        public string BusToName { get; set; }

        public DateTime BusTime { get; set; }

        public int SupplierId { get; set; }

        public string SupplierName { get; set; }

        public Decimal BusCost { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }
    }

    public class PackageItineraryVehiclesInfo
    {
        public int PackageItineraryId { get; set; }

        public int PackageItineraryVehicleId { get; set; }

        public string VehicleName { get; set; }

        public int VehicleFrom { get; set; }

        public int VehicleTo { get; set; }

        public string VehicleFromName { get; set; }

        public string VehicleToName { get; set; }

        public int PickUp { get; set; }

        public int DropOff { get; set; }
        
        public string PickUpName { get; set; }

        public string DropOffName { get; set; }

        public DateTime VehicleTime { get; set; }

        public int SupplierId { get; set; }

        public string supplierName { get; set; }

        public Decimal VehicleCost { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }
    }

    public class PackageDatesInfo
    {
        public int PackageId { get; set; }

        public int PackageDateId { get; set; }

        public string PackageStartDate { get; set; }

        public string PackageEndDate { get; set; }

        public int PackageCost { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

    }

    public class PackageTypeMappingInfo
    {

        public int PackageTypeMappingId { get; set; }

        public int PackageTypeId { get; set; }

        public int PackageId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

       

    }


    public class PackageDaysTriffInfo
    {
        public PackageDaysTriffInfo()
        {
            PackageDayitem = new List<PackageDayitemTriffinfo>();
        }
        public int PackageDayId { get; set; }

        public int PackageId { get; set; }

        public int CityId { get; set; }

        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public List<PackageDayitemTriffinfo> PackageDayitem { get; set; }

    }


    public class PackageDayitemTriffinfo
    {
        public int PackageItemDayID { get; set; }

        public int PackageDayId { get; set; }

        public int RefID { get; set; }

        public int HotelId { get; set; }

        public int RoomTypeId { get; set; }

        public int SighSeeingID { get; set; }

        public int VehicalId { get; set; }
        public int MealId { get; set; }

        public string HotelName { get; set; }

        public string SightSeeingName { get; set; }

        public string VehicleName { get; set; }

        public string MealName { get; set; }

        public string RoomTypeName { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }


    }

    public class PackageDuration
    {
        public int PackageDurationId { get; set; }

        public int PackageId { get; set; }

        public decimal price { get; set; }

        public DateTime FormDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Days { get; set; }

        public DateTime TariffDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public string OperationalDays { get; set; }
       

    }


    public class PackageCustomerCategoryInfo
    {
        public int PackagePriceCategoryId { get; set; }

        public int PackageId { get; set; }

        public int PaackageDurationId { get; set; }
               
        public int CustomerCategoryId { get; set; }

        public string CustomerCategoryName { get; set; }

        public decimal Margin { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

    }
}
