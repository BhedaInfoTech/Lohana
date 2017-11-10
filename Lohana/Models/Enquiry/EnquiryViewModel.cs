using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LohanaBusinessEntities;
using LohanaBusinessEntities.Enquiry;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.PackageType;
using LohanaBusinessEntities.Package;
using LohanaBusinessEntities.HotelTypeInfo;
using LohanaBusinessEntities.RoomType;
using LohanaBusinessEntities.City;
using LohanaBusinessEntities.Customer;
using LohanaBusinessEntities.Vendor;
using LohanaBusinessEntities.Country;
using LohanaBusinessEntities.State;
using LohanaBusinessEntities.Occupancy;

    

namespace Lohana.Models.Enquiry
{
    public class EnquiryViewModel
    {

        public EnquiryViewModel()
        {

            FriendlyMessage = new List<FriendlyMessage>();

            Pager = new PaginationInfo();

            Enquiry = new EnquiryInfo();

            EnquiryFilter = new EnquiryFilter();

            Enquiries = new List<EnquiryInfo>();

            EnquiryItemRoomDetail = new EnquiryItemRoomDetailsInfo();

            EnquiryItemRoomDetails = new List<EnquiryItemRoomDetailsInfo>();

            EnquiryItemPassDetail = new EnquiryItemPassDetailsInfo();

            EnquiryItemPassDetails = new List<EnquiryItemPassDetailsInfo>();

            EnquiryItemTypeDetail = new EnquiryItemTypeDetailsInfo();

            EnquiryItemTypeDetails = new List<EnquiryItemTypeDetailsInfo>();

            EnquiryItemTransferDetail = new EnquiryItemTransferDetailsInfo();

            EnquiryItemTransferDetails = new List<EnquiryItemTransferDetailsInfo>();

            PackageTypes = new List<PackageTypeInfo>();

            HotelTypes = new List<HotelTypeInfo>();

            RoomTypes = new List<RoomTypeInfo>();

            Cities = new List<CityInfo>();

            Customers = new List<CustomerInfo>();

            Vendors = new List<VendorInfo>();

            Users = new List<UserInfo>();

            PackageTypeMappings = new List<PackageTypeMappingInfo>();

            Specialization = new List<SpecializationInfo>();

            Countries = new List<CountryInfo>();

            States = new List<StateInfo>();

            cityes = new List<CityInfo>();

            Occupancies = new List<OccupancyInfo>();

        }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public PaginationInfo Pager { get; set; }

        public EnquiryInfo Enquiry { get; set; }

        public EnquiryFilter EnquiryFilter { get; set; }

        public List<EnquiryInfo> Enquiries { get; set; }

        public List<SpecializationInfo> Specialization { get; set; }

        public EnquiryItemRoomDetailsInfo EnquiryItemRoomDetail { get; set; }

        public EnquiryItemTypeDetailsInfo EnquiryItemTypeDetail { get; set; }

        public EnquiryItemPassDetailsInfo EnquiryItemPassDetail { get; set; }

        public List<EnquiryItemRoomDetailsInfo> EnquiryItemRoomDetails { get; set; }

        public List<EnquiryItemPassDetailsInfo> EnquiryItemPassDetails { get; set; }

        public List<EnquiryItemTypeDetailsInfo> EnquiryItemTypeDetails { get; set; }

        public EnquiryItemTransferDetailsInfo EnquiryItemTransferDetail { get; set; }

        public List<EnquiryItemTransferDetailsInfo> EnquiryItemTransferDetails { get; set; }

        public List<PackageTypeInfo> PackageTypes { get; set; }

        public List<HotelTypeInfo> HotelTypes { get; set; }

        public List<RoomTypeInfo> RoomTypes { get; set; }

        public List<CityInfo> Cities { get; set; }

        public List<CustomerInfo> Customers { get; set; }

        public List<VendorInfo> Vendors { get; set; }

        public List<UserInfo> Users { get; set; }

        public List<PackageTypeMappingInfo> PackageTypeMappings { get; set; }
        
        public int EnquiryTypeId {get; set;}

        public List<CountryInfo> Countries { get; set; }


        public List<StateInfo> States { get; set; }


        public List<CityInfo> cityes { get; set; }

        public List<OccupancyInfo> Occupancies { get; set; }

    }


    public class EnquiryFilter
    {
        public int EnquiryId { get; set; }
    }
}