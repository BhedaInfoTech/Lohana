using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities
{
    public enum DataTypes
    {
        Int,
        String,
        DateTime,
        Boolean,
    }

    public enum GenderType
    {
        Male,
        Female,
        Transgender,
    }

	public enum MessageType
	{
		Information = 1,
		Error = 2,
		Success = 3,
		Warning = 4,
        AcessDenied = 5
	}

    public enum Gender
    {
        Male = 1,
        Female = 2,
        Transgender = 3, 
    }

    public enum ChargesBehaviour
    {
        Add = 1,
        Subtract = 2,
    }

    public enum OccupancyType
    { 
        Room = 1,
        Extra = 2,
    }

    public enum PaymentOption
    { 
        DebitCard = 1,
        CreditCard = 2,
        Cash = 3,
        NEFT = 4,
        Check = 5,
        Cheque=6,
    }


    public enum PaymentMode
    {
        DebitCard = 1,
        CreditCard = 2,
        Cash = 3,       
        Cheque = 6,
    }



    public enum ContactType
    { 
        Vendor = 1,
        Customer = 2,
        Hotel = 3,
    }
   
    public enum StarCategory
    {
        OneStar = 1,
        TwoStar = 2,
        ThreeStar = 3,
        FourStar = 4,
        FiveStar = 5,

    }

    public enum LohanaRatings
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6, 
        Seven = 7, 
        Eight = 8,
        Nine = 9,
        Ten = 10

    }

    public enum HotelType
    {
        Business_Hotels,
        Airport_Hotels,
        Suite_Hotels,
        Extended_Stay_Hotels,
        Service_Apartments,
        Spa_Hotel,
        Resort_Hotels,
        Room_Apartments,
        Home_Stays,
        Timeshare_Hotels,
        Casino_Hotels,
        Conference_And_Resort_Hotels,
        Heritage_Hotels,
        SkyScrappers_Hotels,
        Guest_House,
    }

    public enum Attachment
    { 
        Hotel = 1,
        Package = 2,
        User = 3,
        SightSeeing = 4,
    
    }

    public enum VendorType
    { 
        Individual = 1,
        Company = 2,
        Partnership = 3,
    }

    public enum TaxFormulaBehaviour
    {
        Add = 1,
        Subtract = 2,
    }

    public enum UserRole
    { 
        Sale = 1,
        Admin = 2,
        Master = 3,
    }

    public enum PackageCategory
    {
        Domestic = 1,
        Interanational = 2,
    }


  ////  public enum CustomerCategory
  //  { 
  //  LoyalCustomer=1,
  //  WorkingCustomer=2,
  //  RegularCustomer=3,
  //  }

    public enum Days
    {
        Sunday = 1,
        Monday = 2,
        Tuesday = 3,
        Wednesday = 4,
        Thursday = 5,
        Friday = 6,
        Saturday = 7,
    }

    public enum Months
    {

        Jan = 1,
        Feb = 2, 
        Mar = 3,
        Apr = 4,
        May = 5,
        Jun = 6,
        Jul = 7,
        Aug = 8,
        Sep = 9,
        Oct = 10,
        Nov = 11,
        Dec = 12,

    }


    public enum AssignedType
    {
        Auto = 1,
        Manual = 2,

    }


    public enum RoleModule 
    {
        Country = 1,                 
        City = 2,                    
        State = 3,        
        Currency = 4,
        RoomType = 5,               
        Meal = 6,
        FacilityType = 7,         
        Facility = 8,                
        Hotel = 9,                   
        Occupancy = 10,               
        Charges = 11,                 
        Business = 12,                
        TaxFormula = 13,             
        PackageItienaryBased = 14,
        Designation = 15,             
        Customer = 16,                
        CustomerCategory = 17,       
        Vendor = 18,                  
        Vehicle = 19,                 
        SightSeeing = 20,             
        HotelTariff = 21,            
        SupplierPackageTariff = 22,
        LohanaPackageTariff = 23,   
        VehicleTariff = 24,           
        SightSeeingTariff = 25,
        PackageItienaryHotelBased = 26,
        PackageItienaryFlightBased = 27,
        PackageItienaryTrainBased = 28,
        PackageItienaryBusBased = 29,
        PackageItienaryVehicleBased = 30, 
        HotelType = 26,
        Payable=27

    }

    public enum Function
    {
        Null = 0,
        Create = 1,
        Edit = 2,
        View = 3,
        Delete = 4,
    }

    public enum RoomRateType
    { 
        Hours24 = 1,
        Hours12 = 2,
    }


    public enum CustomerType
    {
        Customer = 1,
        Agent = 2,
        Guest = 3,
    }

    public enum EnquiryVersion
    {
        EV01 = 1,
        EV02 = 2,
        EV03 = 3,
        EV04 = 4,
        EV05 = 5,
        EV06 = 6,
        EV07 = 7,
        EV08 = 8,
        EV09 = 9,
        EV10 = 10,
    }

    public enum EnquirySource
    {
        Walkin = 1,
        Email = 2, 
        Phone = 3,
    }

    public enum EnquiryPriority
    {
        High = 1,
        Medium = 2, 
        Low = 3,
    }

    public enum EnquiryStatus
    {
        Pending_Quotation = 1,
        Pending_Information = 2,
        /*Request_for_Approval = 3,
        Approved = 4,
        Rejected = 5,*/
        //Closed = 3,
    }

    public enum EnquiryTicketDeliveryMode
    {
        Email = 1,
        Office = 2,
        Courier = 3,
    }

    public enum AirplaneTicketClass
    {
        Business = 1,
        First = 2,
        Economy = 3,
    }

    public enum TrainTicketClass
    {
        General = 1,
        Sleeper = 2,
        One_Tier_Ac = 3,
        Two_Tier_Ac = 4,
        Three_Tier_Ac = 5,
       
    }

    public enum EnquiryPackage
    {
        Domestic = 1,
        International = 2,
    }

    public enum RailPassRegion
    {
        Europe = 1,
        Japan = 2,
        New_Zealand = 3,
    }

    public enum RailPass
    {
        Austrian_Rail_Pass = 1,
        France_Rail_Pass = 2,
        Italy_Pass = 3,
    }

    public enum RailPassType
    {
        Single_Country_Rail_Pass = 1,
        Multi_Country_Rail_Pass = 2,
        Single_Multi_Country_Rail_Pass = 3,
    }

    public enum RailPassClass
    {
        First = 1,
        Second = 2,
    }

    public enum PickUpDropOff
    {
        Airport = 1,
        Accomodation = 2,
        Port = 3,
        Station = 4,
        Other = 5,
    }

    public enum Currency
    {
        INR = 1,
        EUR = 2,
        Dollar = 3,
    }

    public enum EnquiryVehicleType
    {
        Seat_In_Counch = 1,
        Private = 2,
        Self_Drive = 3,
    }


    public enum EnquiryType
    {
        Git = 1,
        Fit = 2,
        Hotel = 3,
        Flight = 4,
        Train = 5,
        Transfer = 6,
        Sightseeing = 7,
        Spt = 8,
    }

    public enum CXB
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
    }

    public enum CNB
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
    }

    public enum FlightType
    {
        One_Way = 1,
        Round_Trip = 2,
        Multi_City = 3,
    }


    public enum TrainType
    {
        One_Way = 1,
        Round_Trip = 2,
        Multi_City = 3,
        Rail_Pass = 4,
    }

    public enum TaskType
    {
        Enquiry = 1,
        Quotation = 2,
        Booking = 3,
    }

    public enum DocumentType
    {
        AdharCard = 1,
        Pancard = 2,
        PassportNo = 3,
        DrivingLicense=4,
    }

    public enum QuotationStatus
    {
        Send_for_Approval = 1,
        Approved = 2,
        Rejected = 3,
        //Completed = 4,
        //Closed = 3,
    }
    public enum SupplierTariffItem
    { 
    Hotel=1,
        SightSeeing=2,
        Vehicle=3,
        Meal=4
    }
}
