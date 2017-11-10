using LohanaBusinessEntities.Charges;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Hotel;
using LohanaBusinessEntities.HotelTariffTaxUpdation;
using LohanaBusinessEntities.Meal;
using LohanaBusinessEntities.RoomType;
using LohanaBusinessEntities.TaxFormula;
using LohanaBusinessEntities.Vendor;
using LohanaBusinessEntities.HotelTariff;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lohana.Models.Tariff.HotelTariffTaxUpdation
{
    public class HotelTariffTaxUpdationViewModel
    {

        public HotelTariffTaxUpdationViewModel()
        {

            HotelTariffTax = new HotelTariffTaxUpdationInfo();

            HotelTariffTaxes = new List<HotelTariffTaxUpdationInfo>();

            Vendors = new List<VendorInfo>();

            Hotels = new List<HotelInfo>();

            Meals = new List<MealInfo>();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();

            //for date details

            HotelTariffDate = new HotelTariffDateDetailsInfo();

            HotelTariffDates = new List<HotelTariffDateDetailsInfo>();

            //for duration

            HotelTariffDuration = new HotelTariffDurationDetailsInfo();

            HotelTariffDurations = new List<HotelTariffDurationDetailsInfo>();

            //for price

            HotelTariffPrice = new HotelTariffPriceDetailsInfo();

            HotelTariffPrices = new List<HotelTariffPriceDetailsInfo>();

            //for room

            HotelTariffRoom = new HotelTariffRoomDetailsInfo();

            HotelTariffRooms = new List<HotelTariffRoomDetailsInfo>();

            // Tax Formula

            LstStandardCharges = new List<ChargesInfo>();

            LstTaxFormula = new List<TaxFormulaInfo>();

            LstTaxFormula = new List<TaxFormulaInfo>();

            //Charges

            Charges = new ChargesInfo();

        }

        public HotelTariffTaxUpdationInfo HotelTariffTax { get; set; }

        public List<HotelTariffTaxUpdationInfo> HotelTariffTaxes { get; set; }

        public List<VendorInfo> Vendors { get; set; }

        public List<HotelInfo> Hotels { get; set; }

        public List<RoomTypeInfo> RoomTypes { get; set; }

        public List<MealInfo> Meals { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }
          
        // Tax Formula Charges

        public List<ChargesInfo> LstStandardCharges { get; set; }

        public List<TaxFormulaInfo> LstTaxFormula { get; set; }

        public List<TaxFormulaChargesInfo> LstTaxFormulaCharges { get; set; }


        public HotelTariffDateDetailsInfo HotelTariffDate { get; set; }

        public List<HotelTariffDateDetailsInfo> HotelTariffDates { get; set; }


        public HotelTariffDurationDetailsInfo HotelTariffDuration { get; set; }

        public List<HotelTariffDurationDetailsInfo> HotelTariffDurations { get; set; }


        public HotelTariffPriceDetailsInfo HotelTariffPrice { get; set; }

        public List<HotelTariffPriceDetailsInfo> HotelTariffPrices { get; set; }


        public HotelTariffRoomDetailsInfo HotelTariffRoom { get; set; }

        public List<HotelTariffRoomDetailsInfo> HotelTariffRooms { get; set; }

        public ChargesInfo Charges { get; set; }

        public int[][] UpdateTaxCharges { get; set; }
    }
}