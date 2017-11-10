using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LohanaBusinessEntities.Accessories;

namespace LohanaBusinessEntities.SightSeeing
{
   public class SightSeeingInfo
    {
       public SightSeeingInfo()
       {
         Images = new List<AccessoriesInfo>();
        }
        public int SightSeeingId { get; set; }

        public string SightSeeingName { get; set; }

        public int CityId { get; set; }

        public string location { get; set; } 

        public string Description { get; set; }

        public string TimeFrom { get; set; }

        public string TimeTo { get; set; }

        public string VisitTime { get; set; }

        public int TotalCost { get; set; }

        public int AdultCount { get; set; }

        public int ChildCount { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public string OperationalDays { get; set; }

        public int VehicleType { get; set; }

        public string VendorName { get; set; }

        public string VendorId { get;set;}

        public string Duration { get; set; }

        public string DeparturePoint { get; set; }

        public string Disclaimer { get; set; }

        public string Highlights { get; set; }

        public string AdditionalInformation { get; set; }

        public string DepartureTimeTo { get; set; }

        public string DepartureTimeFrom { get; set; }

        public List<AccessoriesInfo> Images { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int StateId { get; set; }

        public int CountryId { get; set; }

        public int OccupancyValue { get; set; }

        public string OccupancyName { get; set; }

        public Decimal PackageCost { get; set; }

        public int OccupancyId { get; set; }

        public int SightSeeingTariffId { get; set; }

        public decimal NetRate { get; set; }

        public DateTime TravelDate { get; set; }

        public bool BtnFlag { get; set; }

        public int EnquiryitemId { get; set; }

        public decimal Budget { get; set; }
   }
}
