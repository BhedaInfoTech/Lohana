using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LohanaBusinessEntities;
using LohanaBusinessEntities.Hotel;
using LohanaBusinessEntities.HotelTypeInfo;
using LohanaBusinessEntities.City;
using LohanaBusinessEntities.State;
using LohanaBusinessEntities.Country;
using LohanaBusinessEntities.RoomType;
using LohanaBusinessEntities.Facility;
using LohanaBusinessEntities.FacilityType;
using LohanaBusinessEntities.Designation;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Accessories;


namespace Lohana.Models.Master
{
    public class HotelViewModel
    {

        public HotelViewModel()
        {

            FriendlyMessage = new List<FriendlyMessage>();

            Pager = new PaginationInfo();

            Hotel = new HotelInfo();

            Hotels = new List<HotelInfo>();

            Cities = new List<CityInfo>();

            RoomTypes = new List<RoomTypeInfo>();

            HotelTypes = new List<HotelTypeInfo>();

            Designations = new List<DesignationInfo>();

            HotelFacility = new FacilityInfo();

            HotelFacilities = new List<FacilityInfo>();

            HotelRoomType = new HotelRoomTypeDetailsInfo();

            HotelRoomTypes = new List<HotelRoomTypeDetailsInfo>();

            ContactPerson = new HotelContactPersonInfo();

            ContactPersons = new List<HotelContactPersonInfo>();

            HotelFacilityDetails = new List<HotelFacilityDetailsInfo>();

            HotelBankFilter = new HotelBankFilter();

            Images = new List<AccessoriesInfo>();

        }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public PaginationInfo Pager { get; set; }

        public HotelInfo Hotel { get; set; }

        public List<HotelInfo> Hotels { get; set; }

        public HotelFilter HotelFilter { get; set; }

        public List<CityInfo> Cities { get; set; }

        public List<RoomTypeInfo> RoomTypes { get; set; }

        public List<DesignationInfo> Designations { get; set; }

        public FacilityInfo HotelFacility { get; set; }

        public List<FacilityInfo> HotelFacilities { get; set; }

        public HotelRoomTypeDetailsInfo HotelRoomType { get; set; }

        public List<HotelRoomTypeDetailsInfo> HotelRoomTypes { get; set; }

        public HotelFacilityDetailsInfo HotelFacilityDetail { get; set; }

        public List<HotelFacilityDetailsInfo> HotelFacilityDetails { get; set; }

        public HotelRoomTypeDetailsFilter HotelRoomTypeFilter { get; set; }

        public HotelContactPersonInfo ContactPerson { get; set; }

        public List<HotelContactPersonInfo> ContactPersons { get; set; }

        public HotelBankDetailsInfo HotelBank { get; set; }

        public List<HotelBankDetailsInfo> HotelBanks { get; set; }

        public HotelBankFilter HotelBankFilter { get; set; }

        public List<HotelTypeInfo> HotelTypes { get; set; }

        public List<AccessoriesInfo> Images { get; set; }

    }

    public class HotelRoomTypeDetailsFilter
    {
        public int RoomTypeDetailsId { get; set; }
    }

    public class HotelFilter
    {
        public int HotelId { get; set; }
    }

    public class HotelBankFilter
    {
        public int BankId { get; set; }
    }

}