using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.Quotation
{
    public class QuotationInfo
    {


        public List<QuotationItemRoomDetailsInfo> QuotationItemRoomDetails { get; set; }

        public QuotationItemRoomDetailsInfo QuotationItemRoomDetail { get; set; }

        public List<QuotationItemPassDetailsInfo> QuotationItemPassDetails { get; set; }

        public QuotationItemPassDetailsInfo QuotationItemPassDetail { get; set; }

        public List<QuotationItemTypeDetailsInfo> QuotationItemTypeDetails { get; set; }

        public QuotationItemTypeDetailsInfo QuotationItemTypeDetail { get; set; }

        public List<QuotationItemTransferDetailsInfo> QuotationItemTransferDetails { get; set; }

        public QuotationItemTransferDetailsInfo QuotationItemTransferDetail { get; set; }

        public PaymentDetailsInfo PaymentDetail { get; set; }

        //Addition by swapnali | Date:03/07/2017
        public List<BookingCartDetailsInfo> QuatationItem { get; set; }
        //public List<BookingCartDetailsInfo> QuatationItemfitDetails { get; set; }
        //public List<BookingCartDetailsInfo> QuatationItemHotelDetails { get; set; }
        //public List<BookingCartDetailsInfo> QuatationItemFlightDetails { get; set; }
        //public List<BookingCartDetailsInfo> QuatationItemTrainDetails { get; set; }
        //public List<BookingCartDetailsInfo> QuatationItemVahicleDetails { get; set; }
        //public List<BookingCartDetailsInfo> QuatationItemSightSeeingDetails { get; set; }
        //End

        public QuotationInfo()
        {
            QuotationItemRoomDetails = new List<QuotationItemRoomDetailsInfo>();

            QuotationItemPassDetails = new List<QuotationItemPassDetailsInfo>();

            QuotationItemTypeDetails = new List<QuotationItemTypeDetailsInfo>();

            QuotationItemTransferDetails = new List<QuotationItemTransferDetailsInfo>();

            QuotationItemRoomDetail = new QuotationItemRoomDetailsInfo();

            QuotationItemPassDetail = new QuotationItemPassDetailsInfo();

            QuotationItemTypeDetail = new QuotationItemTypeDetailsInfo();

            QuotationItemTransferDetail = new QuotationItemTransferDetailsInfo();

            QuatationItem = new List<BookingCartDetailsInfo>();

            PaymentDetail = new PaymentDetailsInfo();
          
            //QuatationItemfitDetails = new List<BookingCartDetailsInfo>();
            //QuatationItemHotelDetails = new List<BookingCartDetailsInfo>();
            //QuatationItemFlightDetails = new List<BookingCartDetailsInfo>();
            //QuatationItemTrainDetails = new List<BookingCartDetailsInfo>();
            //QuatationItemVahicleDetails = new List<BookingCartDetailsInfo>();
            //QuatationItemSightSeeingDetails = new List<BookingCartDetailsInfo>();

        }

        public int QuotationId { get; set; }

        public int EnquiryId { get; set; }

        public int EnquiryItemId { get; set; }

        public int QuotationItemId { get; set; }

        public int EnquiryType { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int PackageType { get; set; }

        public string PackageTypeName { get; set; }

        public string PackageName { get; set; }

        public string PackageDuration { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public int AdultCount { get; set; }

        public int ChildCount { get; set; }

        public int Cost { get; set; }

        //public int EnquiryAssigneeName { get; set; }

        public string QuoteRate { get; set; }

        public string UserName { get; set; }

        public int Location { get; set; }

        public string CityName { get; set; }

        public int Cityid { get; set; }

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

        public int HotelId { get; set; }

        public int Budget { get; set; }

        public int QuotationFlightType { get; set; }

        public int InfantCount { get; set; }

        public int QuotationTrainType { get; set; }

        public int QuotationVehicleType { get; set; }

        public int Currency { get; set; }

        public string CurrencyName { get; set; }

        public string SightseeingName { get; set; }

        public int SightSeeingId { get; set; }

        public DateTime TravelDate { get; set; }

        public int VehicleType { get; set; }

        public string VehicleTypeName { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int NoOfnight { get; set; }

       // public int QuoteRate { get; set; }

        public int countryId { get; set; }

        public int stateId { get; set; }

        public string StateName { get; set; }

        public string CountryName { get; set; }

        public int QuotationStatus { get; set; }

        public string Remark { get; set; }

        public string CustomerEmailId { get; set; }

        public decimal FinalCost { get; set; }

        public DateTime FollowUpDate { get; set; }

        public int AssigneeToId { get; set; }

    }

    public class BookingInfo
    {
        //Addition by swapnali | Date:03/07/2017
        public List<BookingCartDetailsInfo> QuatationItem { get; set; }
        //public List<BookingCartDetailsInfo> QuatationItemfitDetails { get; set; }
        //public List<BookingCartDetailsInfo> QuatationItemHotelDetails { get; set; }
        //public List<BookingCartDetailsInfo> QuatationItemFlightDetails { get; set; }
        //public List<BookingCartDetailsInfo> QuatationItemTrainDetails { get; set; }
        //public List<BookingCartDetailsInfo> QuatationItemVahicleDetails { get; set; }
        //public List<BookingCartDetailsInfo> QuatationItemSightSeeingDetails { get; set; }
        //End
    }

    public class QuotationItemRoomDetailsInfo
    {
        public int QuotationItemRoomDetailsId { get; set; }

        public int QuotationId { get; set; }

        public int QuotationItemId { get; set; }

        public int QuotationRoomCount { get; set; }

        public int QuotationRoomType { get; set; }

        public int FitCXB { get; set; }

        public string FitCXBAge { get; set; }

        public int FitCNB { get; set; }

        public string FitCNBAge { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

    }

    public class QuotationItemPassDetailsInfo
    {
        public int QuotationItemPassDetailsId { get; set; }

        public int QuotationItemId { get; set; }

        public int QuotationId { get; set; }

        public int QuotationStatus { get; set; }

        public int Region { get; set; }

        public string RegionName { get; set; }

        public int PassType { get; set; }

        public string PassTypeName { get; set; }

        public int RailPass { get; set; }

        public string RailPassName { get; set; }

        public int RailClass { get; set; }

        public string RailClassName { get; set; }

        public int NoOfDays { get; set; }

        public int QuoteRate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

    }

    public class QuotationItemTypeDetailsInfo
    {
        public int QuotationItemTypeDetailsId { get; set; }

        public int QuotationItemId { get; set; }

        public int QuotationId { get; set; }

        public int QuotationStatus { get; set; }

        public int TicketClass { get; set; }

        public string TicketClassName { get; set; }

        public int PickUpFrom { get; set; }

        public string PickUpFromName { get; set; }

        public int DropTo { get; set; }

        public string DropToName { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int QuoteRate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

    }

    public class QuotationItemTransferDetailsInfo
    {
        public int QuotationItemTransferDetailsId { get; set; }

        public int QuotationItemId { get; set; }

        public int QuotationId { get; set; }

        public DateTime TransferDate { get; set; }

        public int PickUpId { get; set; }

        public string PickUpTypeName { get; set; }

        public string PickUpName { get; set; }

        public string PickUpTime { get; set; }

        public int DropOffId { get; set; }

        public string DropOffTypeName { get; set; }

        public string DropOffName { get; set; }

        public string DropOffTime { get; set; }

        public int QuoteRate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

    }

    public class BookingCartDetailsInfo
    {

        public List<BookingCartDetailsInfo> GitDetailsList { get; set; }
        public List<BookingCartDetailsInfo> FitDetailsList { get; set; }
        public List<BookingCartDetailsInfo> TrainFlightDetails { get; set; }
        public List<BookingCartDetailsInfo> TrainFlightPassangerDetails { get; set; }

        public List<BookingCartDetailsInfo> TrainDetails { get; set; }



        public BookingCartDetailsInfo()
        {
            GitDetailsList = new List<BookingCartDetailsInfo>();
            FitDetailsList = new List<BookingCartDetailsInfo>();
            TrainFlightDetails = new List<BookingCartDetailsInfo>();
            TrainFlightPassangerDetails = new List<BookingCartDetailsInfo>();
            ProductDetails = new List<BookingCartDetailsInfo>();
            TrainDetails = new List<BookingCartDetailsInfo>();
        }
                

        public int QuatationId { get; set; }
        public int CategoryId { get; set; }
        public int PackageId { get; set; }
        public decimal QuoteRate { get; set; }
        public string Duration { get; set; }
        public decimal NetRate { get; set; }
        public int StarCategory { get; set; }
        public int PackageTypeId { get; set; }
        public int HotelType { get; set; }
        public string Destination { get; set; } ////
        public string HotelName { get; set; }
        public int HotelId { get; set; }  ///
        public int RoomType { get; set; }
        public string MealPlan { get; set; } ////
        public int OccupancyId { get; set; }
        public decimal Price { get; set; }
        public int month { get; set; }
        public int Year { get; set; }

        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public int RoomCount { get; set; }

        public int CXBCount { get; set; }
        public int CXBAge { get; set; }
        public int CNBCount { get; set; }
        public int CNBAge { get; set; }
        public int Budget { get; set; }

        public int Location { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public int QuotationFlightType { get; set; }
        public int InfantCount { get; set; }
        public int QuotationTrainType { get; set; }
        public int QuotationVehicleType { get; set; }
        public int Currency { get; set; }
        
        public DateTime TravelDate { get; set; }
        

        public string FlightName { get; set; }
        public int ProductType { get; set; }
        public string PackageName { get; set; }

        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public int Age { get; set; }
        public string MobileNo { get; set; }
        public string DocumentName { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNo { get; set; }
        public int TravellerDocumentId { get; set; }
        public string AttachmentName { get; set; }
        public string TravellerName { get; set; }
        public int TravellerId { get; set; }
        public int BookingId { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; } 
        public int CountryId { get; set; }
        public int stateId { get; set; }
        public int CityId { get; set; }

        public int SupplierHotelId { get; set; }

        public string SupplierName { get; set; }
       
        public string VendorId { get; set; }
        public string VendorName { get; set; }

        public int VehicleType { get; set; }
       // public int OccupancyId { get; set; }
        public string OccupancyType { get; set; }
        public string MealType { get; set; }
        public int DayNo { get; set; }
        public string VehicleName { get; set; }
        public string SightseeingName { get; set; }
        public int SightSeeingId { get; set; }
       // public string HotelName { get; set; }

        public int NoOfNight { get; set; }
        public decimal NetRatePerNight { get; set; }
        public string StarCategoryStr { get; set; }
        public string RoomTypeName { get; set; }
        public int OccupancyCapacity { get; set; }
        public string MealName { get; set; }
        public string HotelDescription { get; set; }
        public int HotelRoomPrice { get; set; }
        public int NoOfRooms { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public string OccupancyName { get; set; }


        public int Train_FlightMainId { get; set; }
        public int Train_FlightdetailId { get; set; }
        public int TicketTypeId { get; set; }
        public string TicketTypeName { get; set; }
        public DateTime JourneyDate { get; set; }
        public string JourneyTime { get; set; }
        public string Source { get; set; }
        //public string Destination { get; set; }
        public string SeatNo { get; set; }
        public string  VisitorPass { get; set; }
        public int PassangerId { get; set; }
        public string  PassangerName { get; set; }


        public string TrainName { get; set; }
        public int TicketClassId { get; set; }
        public string TicketClassName { get; set; }
        public DateTime TrainJourneyDate { get; set; }
        public string TrainJourneyTime { get; set; }
        public string TrainSource { get; set; }
        public string TrainDestination { get; set; }
        public string TrainSeatNo { get; set; }
        public string TrainVisitorPass { get; set; }
        public string TrainDuration { get; set; }
        public string TrainVendorId { get; set; }
        public int TrainPassangerId { get; set; }
        public string TrainPassangerName { get; set; }



        //added by Rajani
        public int InvoiceId { get; set; }
        public string InvoiceNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal UnpaidAmount { get; set; }
        public string BookingNo { get; set; }
        public string EmailId { get; set; }       
        public string Address { get; set; }
        public decimal HotelRate { get; set; }
        public decimal SightSeeingRate { get; set; }
        public decimal PackageRate { get; set; }
        public decimal TravellerRate { get; set; }
        public int PackageDetailsId { get; set; }
        public string ItemName { get; set; }
        public decimal Cost { get; set; }
        public int PaymentDetailId { get; set; }
        public int Quantity { get; set; }
        //End

        public List<BookingCartDetailsInfo> ProductDetails { get; set; }
      

}

    public class PaymentDetailsInfo
    {
        public int PaymentReceivableId { get; set; }
        public int PaymentMode { get; set; }
        public DateTime ChequeDate { get; set; }
        public DateTime ReceivableDate { get; set; }
        public string TransactionNo { get; set; }
        public string BankName { get; set; }
        public int PaymentType { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal UnpaidAmount { get; set; }
        public int BookingId { get; set; }
        public string BookingNo { get; set; }
        public int ReceiptId { get; set; }
        public string ReceiptNo { get; set; }
        public string PaymentTypeName { get; set; }
        public string PaymentModeName { get; set; }
        public string CustomerName { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string InvoiceNo { get; set; }
        

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
