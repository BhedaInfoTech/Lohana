using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.HotelTariffTaxUpdation
{
    public class HotelTariffTaxUpdationInfo
    {

        public int VendorId 
        { 
            get; 
            set; 
        }

        public int HotelId
        {
            get;
            set;
        }
        public string VendorName
        {
            get;
            set;
        }

        public string HotelName
        {
            get;
            set;
        }

        public int RoomTypeId
        {
            get;
            set;
        }

        public int MealId
        {
            get;
            set;
        }

        public int FormulaId
        {
            get;
            set;
        }

        public DateTime FromDate
        {
            get;
            set;
        }

        public DateTime ToDate
        {
            get;
            set;
        }

        // HotelTariffTaxCharges

        public int HotelTariffId { get; set; }

        public int HotelTariffRoomDetailsId { get; set; }

        public int HotelTariffPriceDetailsId { get; set; }

        public int HotelTariffDurationDetailsId { get; set; }

        public int TaxFormulaId { get; set; }


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
}
