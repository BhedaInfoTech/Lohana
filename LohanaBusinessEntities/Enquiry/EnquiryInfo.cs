using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.Enquiry
{
    public class EnquiryInfo
    {

        public List<EnquiryItemRoomDetailsInfo> EnquiryItemRoomDetails { get; set; }

        public List<EnquiryItemPassDetailsInfo> EnquiryItemPassDetails { get; set; }

        public List<EnquiryItemTypeDetailsInfo> EnquiryItemTypeDetails { get; set; }

        public List<EnquiryItemTransferDetailsInfo> EnquiryItemTransferDetails { get; set; }





        public EnquiryInfo()
        {

            EnquiryItemRoomDetails = new List<EnquiryItemRoomDetailsInfo>();

            EnquiryItemPassDetails = new List<EnquiryItemPassDetailsInfo>();

            EnquiryItemTypeDetails = new List<EnquiryItemTypeDetailsInfo>();

            EnquiryItemTransferDetails = new List<EnquiryItemTransferDetailsInfo>();

        }

        public int EnquiryId { get; set; }

        public int EnquiryType { get; set; }

        public string EnquiryTypeName { get; set; }

        public int EnquiryItemId { get; set; }

        public int QuotationItemId { get; set; }

        public int CustomerType { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int VendorId { get; set; }

        public string VendorName { get; set; }

        public string GuestName { get; set; }

        public string GuestEmail { get; set; }

        public string GuestMobileNo { get; set; }

        public int EnquiryVersion { get; set; }

        public int EnquirySource { get; set; }

        public string EnquirySourceName { get; set; }

        public int EnquiryPriority { get; set; }

        public int EnquiryStatus { get; set; }

        public int EnquiryTicketDeliveryType { get; set; }

        public string BestTimeToReachYou { get; set; }

        public string AdditionalInformation { get; set; }

        public DateTime FollowupDate { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int PackageType { get; set; }

        public string PackageTypeName { get; set; }

        public string PackageName { get; set; }

        public int NoOfNights { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public int AdultCount { get; set; }

        public int ChildCount { get; set; }

        public int Budget { get; set; }

        public int EnquiryAssignedType { get; set; }

        public string EnquiryAssignedTypeName { get; set; }

        public int EnquiryAssigneeName { get; set; }

        public string UserName { get; set; }

        //public int EnquiryAssigneId { get; set; }

        public int Location { get; set; }

        public string CityName { get; set; }

        public int HotelTypeId { get; set; }

        public string HotelTypeName { get; set; }

        public int StarCategory { get; set; }

        public string StarCategoryStr { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public int RoomCount { get; set; }

        public int RoomType { get; set; }

        public string RoomTypeName { get; set; }

        public int CXBCount { get; set; }

        public string CXBAge { get; set; }

        public int CNBCount { get; set; }

        public string CNBAge { get; set; }

        public string HotelName { get; set; }

        public int EnquiryFlightType { get; set; }

        public int InfantCount { get; set; }

        public int EnquiryTrainType { get; set; }

        public int EnquiryVehicleType { get; set; }

        public int Currency { get; set; }

        public string CurrencyName { get; set; }

        public string SightseeingName { get; set; }

        public DateTime TravelDate { get; set; }

        public int VehicleType { get; set; }

        public string VehicleTypeName { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int SpecializationId { get; set; }

        public string SpecializationName { get; set; }

        public int EnquiryTypeID { get; set; }

        public int UserID { get; set; }

        public int CountryId { get; set; }

        public int StateId { get; set; }

        public int CityId { get; set; }


        public string CountryName { get; set; }

        public string StateName { get; set; }

        public string City{ get; set; }

        public int OccupancyId { get; set; }

        public string OccupancyName { get; set; }

    }

    public class EnquiryItemRoomDetailsInfo
    {
        public int EnquiryItemRoomDetailsId { get; set; }

        public int EnquiryId { get; set; }

        public int EnquiryItemId { get; set; }

        public int EnquiryRoomCount { get; set; }

        public int EnquiryRoomType { get; set; }

        public int FitCXB { get; set; }

        public string FitCXBAge { get; set; }

        public int FitCNB { get; set; }

        public string FitCNBAge { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

    }

    public class EnquiryItemPassDetailsInfo
    {
        public int EnquiryItemPassDetailsId { get; set; }

        public int EnquiryItemId { get; set; }

        public int EnquiryId { get; set; }

        public int Region { get; set; }

        public string RegionName { get; set; }

        public int PassType { get; set; }

        public string PassTypeName { get; set; }

        public int RailPass { get; set; }

        public string RailPassName { get; set; }

        public int RailClass { get; set; }

        public string RailClassName { get; set; }

        public int NoOfDays { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

    }

    public class EnquiryItemTypeDetailsInfo
    {
        public int EnquiryItemTypeDetailsId { get; set; }

        public int EnquiryItemId { get; set; }

        public int EnquiryId { get; set; }

        public int TicketClass { get; set; }

        public string TicketClassName { get; set; }

        public int PickUpFrom { get; set; }

        public string PickUpFromName { get; set; }

        public int DropTo { get; set; }

        public string DropToName { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

    }

    public class EnquiryItemTransferDetailsInfo
    {
        public int EnquiryItemTransferDetailsId { get; set; }

        public int EnquiryItemId { get; set; }

        public int EnquiryId { get; set; }

        public DateTime TransferDate { get; set; }

        public int PickUpId { get; set; }

        public string PickUpTypeName { get; set; }

        public string PickUpName { get; set; }

        public string PickUpTime { get; set; }

        public int DropOffId { get; set; }

        public string DropOffTypeName { get; set; }

        public string DropOffName { get; set; }

        public string DropOffTime { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
        

    }

    public class SpecializationInfo
    {
          public int SpecializationId { get; set; }

        public string Specializationname { get; set; }
    }

    

}
