using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LohanaBusinessEntities;
using LohanaBusinessEntities.Quotation;
using LohanaBusinessEntities.Enquiry;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.City;
using LohanaBusinessEntities.Customer;
using LohanaBusinessEntities.HotelSearch;
using LohanaBusinessEntities.Package;


namespace Lohana.Models.Quotation
{
    public class QuotationViewModel
    {

        public QuotationViewModel()
        {

            FriendlyMessage = new List<FriendlyMessage>();

            Pager = new PaginationInfo();

            Quotation = new QuotationInfo();

            QuotaionItems = new List<QuotationInfo>();

            FlightQuotations = new List<QuotationInfo>();

            TrainQuotations = new List<QuotationInfo>();

            QuotationFilter = new QuotationFilter();

            Enquiry = new EnquiryInfo();

            Enquiries = new List<EnquiryInfo>();

            EnquiryItemRoomDetail = new EnquiryItemRoomDetailsInfo();

            EnquiryItemRoomDetails = new List<EnquiryItemRoomDetailsInfo>();

            EnquiryItemPassDetail = new EnquiryItemPassDetailsInfo();

            EnquiryItemPassDetails = new List<EnquiryItemPassDetailsInfo>();

            EnquiryItemTypeDetail = new EnquiryItemTypeDetailsInfo();

            EnquiryItemTypeDetails = new List<EnquiryItemTypeDetailsInfo>();

            EnquiryItemTransferDetail = new EnquiryItemTransferDetailsInfo();

            EnquiryItemTransferDetails = new List<EnquiryItemTransferDetailsInfo>();


            QuotationItemRoomDetail = new QuotationItemRoomDetailsInfo();

            QuotationItemRoomDetails = new List<QuotationItemRoomDetailsInfo>();

            QuotationItemPassDetail = new QuotationItemPassDetailsInfo();

            TrainQuotationItemPassDetails = new List<QuotationItemPassDetailsInfo>();

            QuotationItemTypeDetail = new QuotationItemTypeDetailsInfo();

            FlightQuotationItemTypeDetails = new List<QuotationItemTypeDetailsInfo>();

            QuotationItemTransferDetail = new QuotationItemTransferDetailsInfo();

            QuotationItemTransferDetails = new List<QuotationItemTransferDetailsInfo>();

            HotelSearch = new HotelSearchInfo();
            PackageSearchList = new List<PackageInfo>();

            Package = new PackageInfo();


            HotelSearchList = new List<HotelSearchInfo>();

            HotelSearchExtraList = new List<HotelSearchInfo>();

            HotelSearchRoomList = new List<HotelSearchInfo>();

            HotelSearchRoomMealOccupancyPrice = new HotelSearchRoomMealOccupancyPrice();

            HotelSearchRoomMealOccupancyPriceList = new List<HotelSearchRoomMealOccupancyPrice>();


            Cities = new List<CityInfo>();

            Users = new List<UserInfo>();

            GitQuotation = new List<QuotationInfo>();

            SightSeeingQuatation= new List<QuotationInfo>();

            HotelQuotation = new List<QuotationInfo>();

        }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public PaginationInfo Pager { get; set; }

        public QuotationInfo Quotation { get; set; }

        public List<QuotationInfo> QuotaionItems { get; set; }

        public List<QuotationInfo> FlightQuotations { get; set; }

        public List<QuotationInfo> TrainQuotations { get; set; }

        public List<QuotationInfo> GitQuotation { get; set; }

        public List<QuotationInfo> HotelQuotation { get; set; }

        public QuotationFilter QuotationFilter { get; set; }

        public EnquiryInfo Enquiry { get; set; }

        public EnquiryItemRoomDetailsInfo EnquiryItemRoomDetail { get; set; }

        public EnquiryItemTypeDetailsInfo EnquiryItemTypeDetail { get; set; }

        public EnquiryItemPassDetailsInfo EnquiryItemPassDetail { get; set; }

        public List<EnquiryItemRoomDetailsInfo> EnquiryItemRoomDetails { get; set; }

        public List<EnquiryItemPassDetailsInfo> EnquiryItemPassDetails { get; set; }

        public List<EnquiryItemTypeDetailsInfo> EnquiryItemTypeDetails { get; set; }

        public EnquiryItemTransferDetailsInfo EnquiryItemTransferDetail { get; set; }

        public List<EnquiryItemTransferDetailsInfo> EnquiryItemTransferDetails { get; set; }


        public QuotationItemRoomDetailsInfo QuotationItemRoomDetail { get; set; }

        public QuotationItemTypeDetailsInfo QuotationItemTypeDetail { get; set; }

        public QuotationItemPassDetailsInfo QuotationItemPassDetail { get; set; }

        public List<QuotationItemRoomDetailsInfo> QuotationItemRoomDetails { get; set; }

        public List<QuotationItemPassDetailsInfo> TrainQuotationItemPassDetails { get; set; }

        public List<QuotationItemTypeDetailsInfo> FlightQuotationItemTypeDetails { get; set; }

        public List<QuotationItemTypeDetailsInfo> TrainQuotationItemTypeDetails { get; set; }

        public QuotationItemTransferDetailsInfo QuotationItemTransferDetail { get; set; }

        public List<QuotationItemTransferDetailsInfo> QuotationItemTransferDetails { get; set; }

        public List<PackageInfo> PackageSearchList { get; set; }

        public PackageInfo Package { get; set; }




        public List<EnquiryInfo> Enquiries { get; set; }

        public List<CityInfo> Cities { get; set; }

        public List<UserInfo> Users { get; set; }


        // Hotel Quotation

        public HotelSearchInfo HotelSearch { get; set; }

        public List<HotelSearchInfo> HotelSearchList { get; set; }

        public List<HotelSearchInfo> HotelSearchExtraList { get; set; }

        public List<HotelSearchInfo> HotelSearchRoomList { get; set; }

        public HotelSearchRoomMealOccupancyPrice HotelSearchRoomMealOccupancyPrice { get; set; }

        public List<HotelSearchRoomMealOccupancyPrice> HotelSearchRoomMealOccupancyPriceList { get; set; }

        public List<QuotationInfo> SightSeeingQuatation { get; set; }
        public bool IsApproval { get; set; }

    }


    public class QuotationFilter
    {
        public int QuotationId { get; set; }
    }

}