using LohanaBusinessEntities.Accessories;
using System;
using System.Collections.Generic;

namespace LohanaBusinessEntities.Hotel
{
	public class HotelInfo
	{
		public List<HotelRoomTypeDetailsInfo> RoomTypeDetails
		{
			get;
			set;
		}

		public List<HotelFacilityDetailsInfo> HotelFacilityDetails
		{
			get;
			set;
		}

		public List<HotelContactPersonInfo> ContactPersonDetails
		{
			get;
			set;
		}

		public List<HotelBankDetailsInfo> HotelBankDetails
		{
			get;
			set;
		}

        public List<AccessoriesInfo> Images { get; set; }

        //public List<HotelTypeInfo> HotelTypes { get; set; }

		public HotelInfo()
		{
            Images = new List<AccessoriesInfo>();

			RoomTypeDetails = new List<HotelRoomTypeDetailsInfo>();

			HotelFacilityDetails = new List<HotelFacilityDetailsInfo>();

			ContactPersonDetails = new List<HotelContactPersonInfo>();

			HotelBankDetails = new List<HotelBankDetailsInfo>();

           // HotelTypes = new List<HotelTypeInfo>();
		}

		public int HotelId
		{
			get;
			set;
		}

		public int HotelTypeId
		{
			get;
			set;
		}

        public string HotelType
        {
            get;
            set;
        }

		public string HotelName
		{
			get;
			set;
		}

		public string HotelGroup
		{
			get;
			set;
		}

		public int StarCategory
		{
			get;
			set;
		}

        public int LohanaRatings { get; set; }

		public bool PreferredHotel
		{
			get;
			set;
		}

		public string HotelDescription
		{
			get;
			set;
		}

		public string NearestAirport
		{
			get;
			set;
		}

		public string NearestRailwayStation
		{
			get;
			set;
		}

		// public string NearestLandmark { get; set; }

		public int CityId
		{
			get;
			set;
		}

		//City Dropdown

		public int CountryId
		{
			get;
			set;
		}

		public string Country
		{
			get;
			set;
		}

		public int StateId
		{
			get;
			set;
		}

		public string State
		{
			get;
			set;
		}

		public string City
		{
			get;
			set;
		}

		//End City Dropdown

		// Start Drpdown

		public int FacilityTypeId
		{
			get;
			set;
		}

		public int FacilityId
		{
			get;
			set;
		}

		public int RoomTypeId
		{
			get;
			set;
		}

		public string RoomTypeName
		{
			get;
			set;
		}

		public int DesignationId
		{
			get;
			set;
		}

		public string DesignationName
		{
			get;
			set;
		}

		//End Dropdown

		public string NearestLandMark
		{
			get;
			set;
		}

        public string Pincode
		{
			get;
			set;
		}

		public string Address
		{
			get;
			set;
		}

        public string MobileNo
		{
			get;
			set;
		}

        public string TelephoneCode { get; set; }

        public string TelephoneNo
		{
			get;
			set;
		}

		public string EmailId
		{
			get;
			set;
		}

		public string FaxNo
		{
			get;
			set;
		}

		public string Website
		{
			get;
			set;
		}

		public string TopAttractionsNearBy
		{
			get;
			set;
		}

		public string UsefulHotelStats
		{
			get;
			set;
		}

		public string Notes
		{
			get;
			set;
		}

		public string Comments
		{
			get;
			set;
		}

		public bool Status
		{
			get;
			set;
		}

		public DateTime CreatedDate
		{
			get;
			set;
		}

		public int CreatedBy
		{
			get;
			set;
		}

		public DateTime UpdatedDate
		{
			get;
			set;
		}

		public int UpdatedBy
		{
			get;
			set;
		}
	}

	public class HotelFacilityDetailsInfo
	{
		public int HotelFacilityDetailsId
		{
			get;
			set;
		}

		public int FacilityTypeId
		{
			get;
			set;
		}

		public int FacilityId
		{
			get;
			set;
		}

		public string FacilityName
		{
			get;
			set;
		}

		public string FacilityTypeName
		{
			get;
			set;
		}

		public int HotelId
		{
			get;
			set;
		}

		public bool FacilityStatus
		{
			get;
			set;
		}

		public DateTime CreatedDate
		{
			get;
			set;
		}

		public int CreatedBy
		{
			get;
			set;
		}

		public DateTime UpdatedDate
		{
			get;
			set;
		}

		public int UpdatedBy
		{
			get;
			set;
		}
	}

	public class HotelRoomTypeDetailsInfo
	{
		public int RoomTypeDetailsId
		{
			get;
			set;
		}

		public int RoomTypeId
		{
			get;
			set;
		}

		public string RoomTypeName
		{
			get;
			set;
		}

		public int HotelId
		{
			get;
			set;
		}

		public int NoOfRooms
		{
			get;
			set;
		}

		public int OccupancyCapacity
		{
			get;
			set;
		}

		public DateTime CreatedDate
		{
			get;
			set;
		}

		public int CreatedBy
		{
			get;
			set;
		}

		public DateTime UpdatedDate
		{
			get;
			set;
		}

		public int UpdatedBy
		{
			get;
			set;
		}
	}

	public class HotelContactPersonInfo
	{
		public int ContactPersonId
		{
			get;
			set;
		}

		public string ContactPersonName
		{
			get;
			set;
		}

		public int ContactPersonType
		{
			get;
			set;
		}

		public int RefId
		{
			get;
			set;
		}

		public int RefType
		{
			get;
			set;
		}

		public string MobileNo
		{
			get;
			set;
		}

		public string PhoneNo
		{
			get;
			set;
		}

		public string EmailId
		{
			get;
			set;
		}

		public string FaxNo
		{
			get;
			set;
		}

		public int DesignationId
		{
			get;
			set;
		}

		public string Designation
		{
			get;
			set;
		}

		public int CreatedBy
		{
			get;
			set;
		}

		public DateTime CreatedDate
		{
			get;
			set;
		}

		public int UpdatedBy
		{
			get;
			set;
		}

		public DateTime UpdatedDate
		{
			get;
			set;
		}
	}

	public class HotelBankDetailsInfo
	{
		public int BankId
		{
			get;
			set;
		}

		public int HotelId
		{
			get;
			set;
		}

		public string BankName
		{
			get;
			set;
		}

		public string BranchName
		{
			get;
			set;
		}

        public string AccountHolderName { get; set; }

		public string AccountNo
		{
			get;
			set;
		}

		public string IFSCCode
		{
			get;
			set;
		}

		public string MICRCode
		{
			get;
			set;
		}

        public string SWIFTCode { get; set; }

		public int CreatedBy
		{
			get;
			set;
		}

		public DateTime CreatedDate
		{
			get;
			set;
		}

		public int UpdatedBy
		{
			get;
			set;
		}

		public DateTime UpdatedDate
		{
			get;
			set;
		}
	}


    //public class HotelTypeInfo
    //{
    //    public int HotelTypeId { get; set; }

    //    public string HotelTypeName { get; set; }
    //}

}