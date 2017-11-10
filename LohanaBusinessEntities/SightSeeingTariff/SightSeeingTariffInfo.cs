using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.SightSeeingTariff
{
  public class SightSeeingTariffInfo
    {
        public int SightSeeingTariffId { get; set; }

          public int VendorId { get; set; }

          public int SightSeeingId { get; set; }

          public string SightSeeingname { get; set; }

          public string VendorName { get; set; }

          public string PackageName { get; set; }        

          public string CancellationPolicy { get; set; }

          public string Inclusions { get; set; }

          public string Exclusions { get; set; }

          public bool IsActive { get; set; }

          public DateTime CreatedDate { get; set; }

          public int CreatedBy { get; set; }

          public DateTime UpdatedDate { get; set; }

          public int UpdatedBy { get; set; }

          public DurationInfo Duration { get; set; }

          public SightSeeingDetailInfo SightSeeingDetail { get; set; }  

          public SightSeeingTariffInfo()
        {
            Duration = new DurationInfo();

            SightSeeingDetail = new SightSeeingDetailInfo();

        }
  
  }

  public class DurationInfo
  {

      public int DurationId { get; set; }

      public int SightSeeingTariffId { get; set; }

      public DateTime FromDate { get; set; }

      public DateTime ToDate { get; set; }

      public string OperationalDays { get; set; }

      public DateTime CreatedDate { get; set; }

      public int CreatedBy { get; set; }

      public DateTime UpdatedDate { get; set; }

      public int UpdatedBy { get; set; }

      public int SightSeeingDateDetailsId { get; set; }

      public DateTime Date { get; set; }

      public int NetRate { get; set; }

      public string Dates { get; set; }

      public string Day { get; set; }

  }

  public class SightSeeingDetailInfo
  {
      public int SightSeeingDetailsId { get; set; }

      public int SightSeeingId { get; set; }

      public int SightSeeingTariffId { get; set; }

      public DateTime CreatedDate { get; set; }

      public int CreatedBy { get; set; }

      public DateTime UpdatedDate { get; set; }

      public int UpdatedBy { get; set; }
  }

  public class SightSeeingTariffOccupancyInfo
  {
      public int SightSeeingTariffOccupancyId { get; set; }

      public int SightSeeingTariffId { get; set; }

      public int OccupancyId { get; set; }

      public int MealId { get; set; }

      public string Inclusion { get; set; }

      public string Exclusion { get; set; }

      public decimal AgeFrom { get; set; }

      public decimal AgeTo { get; set; }

      public DateTime CreatedDate { get; set; }

      public int CreatedBy { get; set; }

      public DateTime UpdatedDate { get; set; }

      public int UpdatedBy { get; set; }
  }

  public class SightSeeingTariffPriceInfo
  {
      public SightSeeingTariffPriceInfo()
      {
          SightSeeingTariffCharges = new List<SightSeeingTariffChargesInfo>();

      }
      public List<SightSeeingTariffChargesInfo> SightSeeingTariffCharges
      {
          get;
          set;
      }

      public int SightSeeingTariffPriceId
      {
          get;
          set;
      }

      public int SightSeeingTariffOccupancyId
      {
          get;
          set;
      }

      public int SightSeeingTariffDurationId
      {
          get;
          set;
      }

      public int SightSeeingTariffId
      {
          get;
          set;
      }

      public decimal PublishPrice
      {
          get;
          set;
      }

      public decimal SpecialPrice
      {
          get;
          set;
      }

      public decimal CommissionPrice
      {
          get;
          set;
      }

      public int FormulaId
      {
          get;
          set;
      }

      public decimal TotalTaxPrice
      {
          get;
          set;
      }

      public decimal NetRate
      {
          get;
          set;
      }

      public string Color
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


  public class SightSeeingTariffDateInfo
  {
      public int SightSeeingTariffDatesId
      {
          get;
          set;
      }

      public int SightSeeingTariffCustomerCategoryId
      {
          get;
          set;
      }

      public int SightSeeingTariffPriceId
      {
          get;
          set;
      }

      public int SightSeeingTariffOccupancyId
      {
          get;
          set;
      }

      public DateTime TariffDate
      {
          get;
          set;
      }

      public decimal NetRate
      {
          get;
          set;
      }

  }


  public class SightSeeingTariffChargesInfo
  {
      public int SightSeeingTariffChargesId
      {
          get;
          set;
      }
      public int SightSeeingTariffPriceId
      {
          get;
          set;
      }
      public int ChargesId
      {
          get;
          set;
      }

      public decimal Percentage
      {
          get;
          set;
      }

      public decimal CalculatedPrice
      {
          get;
          set;
      }
      public decimal TotalTaxPrice
      {
          get;
          set;
      }

      public string SightSeeingTariffCalOn { get; set; }

  }

  public class SightSeeingTariffDurationInfo
  {
      public int SightSeeingTariffDurationId
      {
          get;
          set;
      }

      public int SightSeeingTariffPriceId
      {
          get;
          set;
      }

      public int SightSeeingTariffOccupancyId
      {
          get;
          set;
      }

      public int SightSeeingTariffId
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

      public string OperationalDays
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

  public class SightSeeingTariffCustomerCategoryInfo
  {
      public int SightSeeingTariffDateId
      {
          get;
          set;
      }

      public int SightSeeingTariffOccupancyId
      {
          get;
          set;
      }

      public int CustomerCategoryId { get; set; }

      public string CustomerCategoryName { get; set; }

      public decimal TariffMargin { get; set; }

      public decimal GlobalMargin
      {
          get;
          set;
      }

      public DateTime CreatedDate { get; set; }

      public int CreatedBy { get; set; }

      public DateTime UpdatedDate { get; set; }

      public int UpdatedBy { get; set; }


      public int SightSeeingTariffDatesId { get; set; }
  }
}
