using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LohanaBusinessEntities.Common
{
   public class LookupInfo
    {
       public static Dictionary<int, string> Get_Gender()
       {
           Dictionary<int, string> Get_Gender = new Dictionary<int, string>();

           Get_Gender.Add(1, Gender.Male.ToString());

           Get_Gender.Add(2, Gender.Female.ToString());

           Get_Gender.Add(3, Gender.Transgender.ToString());

           return Get_Gender;
       }

        public static Dictionary<string, string> GetChargesBehaviour()
        {
            Dictionary<string, string> GetChargesBehaviour = new Dictionary<string, string>();

            GetChargesBehaviour.Add(

                 "+",
                 LohanaBusinessEntities.Common.EnumCollection.ChargeBehaviour.Add.ToString()
            );

            GetChargesBehaviour.Add(
            
                 "-",
                 LohanaBusinessEntities.Common.EnumCollection.ChargeBehaviour.Subtract.ToString()
            );

            return GetChargesBehaviour;
        }

        public static Dictionary<int, string> Get_Occupancy_Type()
        {
            Dictionary<int, string> Get_Occupancy_Type = new Dictionary<int, string>();

            Get_Occupancy_Type.Add(1, OccupancyType.Room.ToString());

            Get_Occupancy_Type.Add(2, OccupancyType.Extra.ToString());

            return Get_Occupancy_Type;
        }

        public static Dictionary<int, string> Get_Payment_Option()
        {
            Dictionary<int, string> Get_Payment_Option = new Dictionary<int, string>();

            Get_Payment_Option.Add(1, PaymentOption.DebitCard.ToString());

            Get_Payment_Option.Add(2, PaymentOption.CreditCard.ToString());

            Get_Payment_Option.Add(3, PaymentOption.Cash.ToString());

            Get_Payment_Option.Add(4, PaymentOption.NEFT.ToString());

            Get_Payment_Option.Add(5, PaymentOption.Check.ToString());

            Get_Payment_Option.Add(6, PaymentOption.Cheque.ToString());

            return Get_Payment_Option;
        }

        public static Dictionary<int, string> Get_Contact_Type()
        {
            Dictionary<int, string> Get_Contact_Type = new Dictionary<int, string>();

            Get_Contact_Type.Add(1, ContactType.Vendor.ToString());

            Get_Contact_Type.Add(2, ContactType.Customer.ToString());

            Get_Contact_Type.Add(3, ContactType.Hotel.ToString());

            return Get_Contact_Type;
        }

        public static Dictionary<int, string> Get_Hotel_Type()
        {
            Dictionary<int, string> Get_Hotel_Type = new Dictionary<int, string>();

            Get_Hotel_Type.Add(1, HotelType.Airport_Hotels.ToString().Replace("_", " "));

            Get_Hotel_Type.Add(2, HotelType.Business_Hotels.ToString().Replace("_", " "));

            Get_Hotel_Type.Add(3, HotelType.Casino_Hotels.ToString().Replace("_", " "));

            Get_Hotel_Type.Add(4, HotelType.Conference_And_Resort_Hotels.ToString().Replace("_", " "));

            Get_Hotel_Type.Add(5, HotelType.Extended_Stay_Hotels.ToString().Replace("_", " "));

            Get_Hotel_Type.Add(6, HotelType.Guest_House.ToString().Replace("_", " "));

            Get_Hotel_Type.Add(7, HotelType.Heritage_Hotels.ToString().Replace("_", " "));

            Get_Hotel_Type.Add(8, HotelType.Home_Stays.ToString().Replace("_", " "));

            Get_Hotel_Type.Add(9, HotelType.Resort_Hotels.ToString().Replace("_", " "));

            Get_Hotel_Type.Add(10, HotelType.Service_Apartments.ToString().Replace("_", " "));

            Get_Hotel_Type.Add(11, HotelType.SkyScrappers_Hotels.ToString().Replace("_", " "));

            Get_Hotel_Type.Add(12, HotelType.Spa_Hotel.ToString().Replace("_", " "));

            Get_Hotel_Type.Add(13, HotelType.Suite_Hotels.ToString().Replace("_", " "));

            Get_Hotel_Type.Add(14, HotelType.Timeshare_Hotels.ToString().Replace("_", " "));

            Get_Hotel_Type.Add(15, HotelType.Room_Apartments.ToString().Replace("_", " "));

           
            return Get_Hotel_Type;
        }

        public static Dictionary<int, string> Get_StarCategory_Type()
        {
            Dictionary<int, string> Get_StarCategory_Type = new Dictionary<int, string>();

            Get_StarCategory_Type.Add(1, StarCategory.OneStar.ToString());

            Get_StarCategory_Type.Add(2, StarCategory.TwoStar.ToString());

            Get_StarCategory_Type.Add(3, StarCategory.ThreeStar.ToString());

            Get_StarCategory_Type.Add(4, StarCategory.FourStar.ToString());

            Get_StarCategory_Type.Add(5, StarCategory.FiveStar.ToString());

            return Get_StarCategory_Type;
        }

        public static Dictionary<int, string> Get_LohanaRatings()
        {
            Dictionary<int, string> Get_LohanaRatings = new Dictionary<int, string>();

            Get_LohanaRatings.Add(1, LohanaRatings.One.ToString());

            Get_LohanaRatings.Add(2, LohanaRatings.Two.ToString());

            Get_LohanaRatings.Add(3, LohanaRatings.Three.ToString());

            Get_LohanaRatings.Add(4, LohanaRatings.Four.ToString());

            Get_LohanaRatings.Add(5, LohanaRatings.Five.ToString());

            Get_LohanaRatings.Add(6, LohanaRatings.Six.ToString());

            Get_LohanaRatings.Add(7, LohanaRatings.Seven.ToString());

            Get_LohanaRatings.Add(8, LohanaRatings.Eight.ToString());

            Get_LohanaRatings.Add(9, LohanaRatings.Nine.ToString());

            Get_LohanaRatings.Add(10, LohanaRatings.Ten.ToString());

            return Get_LohanaRatings;
        }

        public static Dictionary<int, string> Get_Vendor_Type()
       {
           Dictionary<int, string> Get_Vendor_Type = new Dictionary<int, string>();

           Get_Vendor_Type.Add(1, VendorType.Individual.ToString());

           Get_Vendor_Type.Add(2, VendorType.Company.ToString());

           Get_Vendor_Type.Add(3, VendorType.Partnership.ToString());

           return Get_Vendor_Type;
       
       }

        public static Dictionary<int, string> GetDays()
        {
            Dictionary<int, string> GetDays = new Dictionary<int, string>();

            GetDays.Add(1, Days.Sunday.ToString());

            GetDays.Add(2, Days.Monday.ToString());

            GetDays.Add(3, Days.Tuesday.ToString());

            GetDays.Add(4, Days.Wednesday.ToString());

            GetDays.Add(5, Days.Thursday.ToString());

            GetDays.Add(6, Days.Friday.ToString());

            GetDays.Add(7, Days.Saturday.ToString());

            return GetDays;

       }

        public static Dictionary<int, string> GetMonths()
        {
            Dictionary<int, string> GetMonths = new Dictionary<int, string>();

            GetMonths.Add(1, Months.Jan.ToString());

            GetMonths.Add(2, Months.Feb.ToString());

            GetMonths.Add(3, Months.Mar.ToString());

            GetMonths.Add(4, Months.Apr.ToString());

            GetMonths.Add(5, Months.May.ToString());

            GetMonths.Add(6, Months.Jun.ToString());

            GetMonths.Add(7, Months.Jul.ToString());

            GetMonths.Add(8, Months.Aug.ToString());

            GetMonths.Add(9, Months.Sep.ToString());

            GetMonths.Add(10, Months.Oct.ToString());

            GetMonths.Add(11, Months.Nov.ToString());

            GetMonths.Add(12, Months.Dec.ToString());

            return GetMonths;

       }


       public static Dictionary<int, string> GetPackageCategories()
        {
            Dictionary<int, string> GetPackageCategories = new Dictionary<int, string>();

            GetPackageCategories.Add(1, PackageCategory.Domestic.ToString());

            GetPackageCategories.Add(2, PackageCategory.Interanational.ToString());

            return GetPackageCategories;
        }

       //public static Dictionary<int, string> Get_Customer_Category()
       //{
       //    Dictionary<int, string> Get_Customer_Category = new Dictionary<int, string>();

       //    Get_Customer_Category.Add(1, CustomerCategory.LoyalCustomer.ToString());

       //    Get_Customer_Category.Add(2, CustomerCategory.RegularCustomer.ToString());

       //    Get_Customer_Category.Add(3, CustomerCategory.WorkingCustomer.ToString());

       //    return Get_Customer_Category;
       //}
        public static Dictionary<int, string> Get_User_Role()
        {
            Dictionary<int, string> Get_User_Role = new Dictionary<int, string>();

            Get_User_Role.Add(1, UserRole.Sale.ToString());

            Get_User_Role.Add(2, UserRole.Admin.ToString());

            Get_User_Role.Add(3, UserRole.Master.ToString());

            return Get_User_Role;
        }


        public static List<KeyValueInfo> GetChargesRateTypes()
		{
            List<KeyValueInfo> GetChargesRateTypes = new List<KeyValueInfo>();

            GetChargesRateTypes.Add(new KeyValueInfo
			{
				Key = 1,
				Value = LohanaBusinessEntities.Common.EnumCollection.RateTypes.Publish_Price.ToString().Replace("_", " ")
			});

            GetChargesRateTypes.Add(new KeyValueInfo
			{
				Key = 2,
				Value = LohanaBusinessEntities.Common.EnumCollection.RateTypes.Commision_Price.ToString().Replace("_", " ")
			});

            GetChargesRateTypes.Add(new KeyValueInfo
			{
				Key = 3,
				Value = LohanaBusinessEntities.Common.EnumCollection.RateTypes.Special_Price.ToString().Replace("_", " ")
			});
            
            return GetChargesRateTypes;
		}

        public static Dictionary<int, string> GetTaxFormulaBehaviour()
        {
            Dictionary<int, string> GetTaxFormulaBehaviour = new Dictionary<int, string>();

            GetTaxFormulaBehaviour.Add(1, TaxFormulaBehaviour.Add.ToString());

            GetTaxFormulaBehaviour.Add(2, TaxFormulaBehaviour.Subtract.ToString());

            return GetTaxFormulaBehaviour;
        }

        public static Dictionary<int, string> GetEnquiryPackage()
        {
            Dictionary<int, string> GetEnquiryPackage = new Dictionary<int, string>();

            GetEnquiryPackage.Add(1, EnquiryPackage.Domestic.ToString());

            GetEnquiryPackage.Add(2, EnquiryPackage.International.ToString());

            return GetEnquiryPackage;
        }


       

        public static Dictionary<int, string> GetRoomRateType()
        {
            Dictionary<int, string> GetRoomRateType = new Dictionary<int, string>();

            GetRoomRateType.Add(1, RoomRateType.Hours24.ToString().Replace("Hours24", "24 Hours"));

            GetRoomRateType.Add(2, RoomRateType.Hours12.ToString().Replace("Hours12", "12 Hours"));

            return GetRoomRateType;
        }


        public static Dictionary<int, string> GetAssignedType()
        {
            Dictionary<int, string> GetAssignedType = new Dictionary<int, string>();

            GetAssignedType.Add(1, AssignedType.Auto.ToString());

            GetAssignedType.Add(2, AssignedType.Manual.ToString());

            return GetAssignedType;
        }

        public static Dictionary<string, string> GetYear()
        {
            Dictionary<string, string> GetYear = new Dictionary<string, string>();

            GetYear.Add(

                 "+",
                 LohanaBusinessEntities.Common.EnumCollection.ChargeBehaviour.Add.ToString()
            );

            GetYear.Add(

                 "-",
                 LohanaBusinessEntities.Common.EnumCollection.ChargeBehaviour.Subtract.ToString()
            );

            return GetYear;
        }

        public static Dictionary<int, string> GetCustomerType()
        {
            Dictionary<int, string> GetCustomerType = new Dictionary<int, string>();

            GetCustomerType.Add(1, CustomerType.Customer.ToString());

            GetCustomerType.Add(2, CustomerType.Agent.ToString());

            GetCustomerType.Add(3, CustomerType.Guest.ToString());

            return GetCustomerType;
        }


        public static Dictionary<int, string> GetEnquiryVersion()
        {
            Dictionary<int, string> GetEnquiryVersion = new Dictionary<int, string>();

            GetEnquiryVersion.Add(1, EnquiryVersion.EV01.ToString());

            GetEnquiryVersion.Add(2, EnquiryVersion.EV02.ToString());

            GetEnquiryVersion.Add(3, EnquiryVersion.EV03.ToString());

            GetEnquiryVersion.Add(4, EnquiryVersion.EV04.ToString());

            GetEnquiryVersion.Add(5, EnquiryVersion.EV05.ToString());

            GetEnquiryVersion.Add(6, EnquiryVersion.EV06.ToString());

            GetEnquiryVersion.Add(7, EnquiryVersion.EV07.ToString());

            GetEnquiryVersion.Add(8, EnquiryVersion.EV08.ToString());

            GetEnquiryVersion.Add(9, EnquiryVersion.EV09.ToString());

            GetEnquiryVersion.Add(10, EnquiryVersion.EV10.ToString());

            return GetEnquiryVersion;
        }

        public static Dictionary<int, string> GetEnquirySource()
        {
            Dictionary<int, string> GetEnquirySource = new Dictionary<int, string>();

            GetEnquirySource.Add(1, EnquirySource.Walkin.ToString());

            GetEnquirySource.Add(2, EnquirySource.Email.ToString());

            GetEnquirySource.Add(3, EnquirySource.Phone.ToString());

            return GetEnquirySource;
        }

        public static Dictionary<int, string> GetEnquiryPriority()
        {
            Dictionary<int, string> GetEnquiryPriority = new Dictionary<int, string>();

            GetEnquiryPriority.Add(1, EnquiryPriority.High.ToString());

            GetEnquiryPriority.Add(2, EnquiryPriority.Medium.ToString());

            GetEnquiryPriority.Add(3, EnquiryPriority.Low.ToString());

            return GetEnquiryPriority;
        }

        public static Dictionary<int, string> GetEnquiryStatus()
        {
            Dictionary<int, string> GetEnquiryStatus = new Dictionary<int, string>();

            GetEnquiryStatus.Add(1, EnquiryStatus.Pending_Quotation.ToString().Replace("_", " "));

            GetEnquiryStatus.Add(2, EnquiryStatus.Pending_Information.ToString().Replace("_", " "));

            //GetEnquiryStatus.Add(3, EnquiryStatus.Closed.ToString());

            return GetEnquiryStatus;
        }

        public static Dictionary<int, string> GetEnquiryTicketDeliveryMode()
        {
            Dictionary<int, string> GetEnquiryTicketDeliveryMode = new Dictionary<int, string>();

            GetEnquiryTicketDeliveryMode.Add(1, EnquiryTicketDeliveryMode.Email.ToString());

            GetEnquiryTicketDeliveryMode.Add(2, EnquiryTicketDeliveryMode.Office.ToString());

            GetEnquiryTicketDeliveryMode.Add(3, EnquiryTicketDeliveryMode.Courier.ToString());

            return GetEnquiryTicketDeliveryMode;
        }


        public static Dictionary<int, string> GetEnquiryAirplaneTicketClass()
        {
            Dictionary<int, string> GetEnquiryAirplaneTicketClass = new Dictionary<int, string>();

            GetEnquiryAirplaneTicketClass.Add(1, AirplaneTicketClass.Business.ToString());

            GetEnquiryAirplaneTicketClass.Add(2, AirplaneTicketClass.First.ToString());

            GetEnquiryAirplaneTicketClass.Add(3, AirplaneTicketClass.Economy.ToString());

            return GetEnquiryAirplaneTicketClass;
        }

        public static Dictionary<int, string> GetEnquiryTrainTicketClass()
        {
            Dictionary<int, string> GetEnquiryTrainTicketClass = new Dictionary<int, string>();

            GetEnquiryTrainTicketClass.Add(1, TrainTicketClass.General.ToString());

            GetEnquiryTrainTicketClass.Add(2, TrainTicketClass.Sleeper.ToString());

            GetEnquiryTrainTicketClass.Add(3, TrainTicketClass.One_Tier_Ac.ToString().Replace("_", " "));

            GetEnquiryTrainTicketClass.Add(4, TrainTicketClass.Two_Tier_Ac.ToString().Replace("_", " "));

            GetEnquiryTrainTicketClass.Add(5, TrainTicketClass.Three_Tier_Ac.ToString().Replace("_", " "));

            return GetEnquiryTrainTicketClass;
        }

        public static Dictionary<int, string> GetEnquiryRailPassRegion()
        {
            Dictionary<int, string> GetEnquiryRailPassRegion = new Dictionary<int, string>();

            GetEnquiryRailPassRegion.Add(1, RailPassRegion.Europe.ToString());

            GetEnquiryRailPassRegion.Add(2, RailPassRegion.Japan.ToString());

            GetEnquiryRailPassRegion.Add(4, RailPassRegion.New_Zealand.ToString().Replace("_", " "));

            return GetEnquiryRailPassRegion;
        }


        public static Dictionary<int, string> GetEnquiryRailPassType()
        {
            Dictionary<int, string> GetEnquiryRailPassType = new Dictionary<int, string>();

            GetEnquiryRailPassType.Add(1, RailPassType.Single_Country_Rail_Pass.ToString().Replace("_", " "));

            GetEnquiryRailPassType.Add(2, RailPassType.Multi_Country_Rail_Pass.ToString().Replace("_", " "));

            GetEnquiryRailPassType.Add(3, RailPassType.Single_Multi_Country_Rail_Pass.ToString().Replace("_", " "));

            return GetEnquiryRailPassType;
        }

        public static Dictionary<int, string> GetEnquiryRailPass()
        {
            Dictionary<int, string> GetEnquiryRailPass = new Dictionary<int, string>();

            GetEnquiryRailPass.Add(1, RailPass.Austrian_Rail_Pass.ToString().Replace("_", " "));

            GetEnquiryRailPass.Add(2, RailPass.France_Rail_Pass.ToString().Replace("_", " "));

            GetEnquiryRailPass.Add(3, RailPass.Italy_Pass.ToString().Replace("_", " "));

            return GetEnquiryRailPass;
        }

        public static Dictionary<int, string> GetEnquiryRailPassClass()
        {
            Dictionary<int, string> GetEnquiryRailPassClass = new Dictionary<int, string>();

            GetEnquiryRailPassClass.Add(1, RailPassClass.First.ToString());

            GetEnquiryRailPassClass.Add(2, RailPassClass.Second.ToString());

            return GetEnquiryRailPassClass;
        }

        public static Dictionary<int, string> GetEnquiryPickUpDropOff()
        {
            Dictionary<int, string> GetEnquiryPickUpDropOff = new Dictionary<int, string>();

            GetEnquiryPickUpDropOff.Add(1, PickUpDropOff.Airport.ToString());

            GetEnquiryPickUpDropOff.Add(2, PickUpDropOff.Accomodation.ToString());

            GetEnquiryPickUpDropOff.Add(3, PickUpDropOff.Port.ToString());

            GetEnquiryPickUpDropOff.Add(4, PickUpDropOff.Station.ToString());

            GetEnquiryPickUpDropOff.Add(5, PickUpDropOff.Other.ToString());

            return GetEnquiryPickUpDropOff;
        }

        public static Dictionary<int, string> GetCurrency()
        {
            Dictionary<int, string> GetCurrency = new Dictionary<int, string>();

            GetCurrency.Add(1, Currency.INR.ToString());

            GetCurrency.Add(2, Currency.EUR.ToString());

            GetCurrency.Add(3, Currency.Dollar.ToString());

            return GetCurrency;
        }

        public static Dictionary<int, string> GetPickUpAndDropOff()
        {
            Dictionary<int, string> GetPickUpAndDropOff = new Dictionary<int, string>();

            GetPickUpAndDropOff.Add(1, PickUpDropOff.Airport.ToString());

           // GetPickUpAndDropOff.Add(2, PickUpDropOff.Hotel.ToString());

            GetPickUpAndDropOff.Add(2, PickUpDropOff.Accomodation.ToString());

            GetPickUpAndDropOff.Add(3, PickUpDropOff.Port.ToString());

            GetPickUpAndDropOff.Add(4, PickUpDropOff.Station.ToString());

            GetPickUpAndDropOff.Add(5, PickUpDropOff.Other.ToString());

            return GetPickUpAndDropOff;
        }

        public static Dictionary<int, string> GetEnquiryVehicleType()
        {
            Dictionary<int, string> GetEnquiryVehicleType = new Dictionary<int, string>();

            GetEnquiryVehicleType.Add(1, EnquiryVehicleType.Seat_In_Counch.ToString().Replace("_", " "));

            GetEnquiryVehicleType.Add(2, EnquiryVehicleType.Private.ToString());

            GetEnquiryVehicleType.Add(3, EnquiryVehicleType.Self_Drive.ToString().Replace("_", " "));

            return GetEnquiryVehicleType;
    }

        public static Dictionary<int, string> GetCXB()
        {
            Dictionary<int, string> GetCXB = new Dictionary<int, string>();

            GetCXB.Add(1, CXB.One.ToString());

            GetCXB.Add(2, CXB.Two.ToString());

            GetCXB.Add(3, CXB.Three.ToString());

            GetCXB.Add(4, CXB.Four.ToString());

            GetCXB.Add(5, CXB.Five.ToString());

            return GetCXB;
}

        public static Dictionary<int, string> GetCNB()
        {
            Dictionary<int, string> GetCNB = new Dictionary<int, string>();

            GetCNB.Add(1, CNB.One.ToString());

            GetCNB.Add(2, CNB.Two.ToString());

            GetCNB.Add(3, CNB.Three.ToString());

            GetCNB.Add(4, CNB.Four.ToString());

            GetCNB.Add(5, CNB.Five.ToString());

            return GetCNB;
        }

        public static Dictionary<int, string> GetFlightType()
        {
            Dictionary<int, string> GetFlightType = new Dictionary<int, string>();

            GetFlightType.Add(1, FlightType.One_Way.ToString().Replace("_", " "));

            GetFlightType.Add(2, FlightType.Round_Trip.ToString().Replace("_", " "));

            GetFlightType.Add(3, FlightType.Multi_City.ToString().Replace("_", " "));

            return GetFlightType;
        }

        public static Dictionary<int, string> GetTrainType()
        {
            Dictionary<int, string> GetTrainType = new Dictionary<int, string>();

            GetTrainType.Add(1, TrainType.One_Way.ToString().Replace("_", " "));

            GetTrainType.Add(2, TrainType.Round_Trip.ToString().Replace("_", " "));

            GetTrainType.Add(3, TrainType.Multi_City.ToString().Replace("_", " "));

            GetTrainType.Add(4, TrainType.Rail_Pass.ToString().Replace("_", " "));

            return GetTrainType;
        }

        public static Dictionary<int, string> Get_Task()
        {
            Dictionary<int, string> Get_Task = new Dictionary<int, string>();

            Get_Task.Add(1, TaskType.Enquiry.ToString());

            Get_Task.Add(2, TaskType.Quotation.ToString());

            Get_Task.Add(3, TaskType.Booking.ToString());

            return Get_Task;
        }

        public static Dictionary<int, string> GetDocumentType()
        {
            Dictionary<int, string> GetDocumentType = new Dictionary<int, string>();

            GetDocumentType.Add(1, DocumentType.AdharCard.ToString());

            GetDocumentType.Add(2, DocumentType.Pancard.ToString());

            GetDocumentType.Add(3, DocumentType.PassportNo.ToString());

            GetDocumentType.Add(4, DocumentType.DrivingLicense.ToString());

            return GetDocumentType;
        }

        public static Dictionary<int, string> GetQuotationStatus()
        {
            Dictionary<int, string> GetQuotationStatus = new Dictionary<int, string>();

            GetQuotationStatus.Add(1, QuotationStatus.Send_for_Approval.ToString().Replace('_', ' '));
            GetQuotationStatus.Add(2, QuotationStatus.Approved.ToString());

            GetQuotationStatus.Add(3, QuotationStatus.Rejected.ToString());
            //GetQuotationStatus.Add(4, QuotationStatus.Completed.ToString());

            return GetQuotationStatus;
        }

        public static Dictionary<int, string> GetSupplierTariffItems()
        {
            Dictionary<int, string> GetSupplierTariffItems = new Dictionary<int, string>();

            GetSupplierTariffItems.Add(1, SupplierTariffItem.Hotel.ToString());

            GetSupplierTariffItems.Add(2, SupplierTariffItem.SightSeeing.ToString());

            GetSupplierTariffItems.Add(3, SupplierTariffItem.Vehicle.ToString());

            GetSupplierTariffItems.Add(3, SupplierTariffItem.Meal.ToString());


            return GetSupplierTariffItems;
        }

        public static Dictionary<int, string> Get_Payment_Mode()
        {
            Dictionary<int, string> Get_Payment_Mode = new Dictionary<int, string>();

            Get_Payment_Mode.Add(1, PaymentOption.DebitCard.ToString());

            Get_Payment_Mode.Add(2, PaymentOption.CreditCard.ToString());

            Get_Payment_Mode.Add(3, PaymentOption.Cash.ToString());

            Get_Payment_Mode.Add(4, PaymentOption.NEFT.ToString());

            Get_Payment_Mode.Add(6, PaymentOption.Cheque.ToString());

            return Get_Payment_Mode;
        }

        public static Dictionary<int, string> GetProductType()
        {
            Dictionary<int, string> GetProductType = new Dictionary<int, string>();

            GetProductType.Add(1, EnquiryType.Git.ToString());

            GetProductType.Add(2, EnquiryType.Fit.ToString());

            GetProductType.Add(3, EnquiryType.Hotel.ToString());

            GetProductType.Add(4, EnquiryType.Flight.ToString());

            GetProductType.Add(5, EnquiryType.Train.ToString());

            GetProductType.Add(6, EnquiryType.Transfer.ToString());

            GetProductType.Add(7, EnquiryType.Sightseeing.ToString());


            return GetProductType;
        }
    }

    
}








