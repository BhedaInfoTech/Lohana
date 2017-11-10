using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Package;
using LohanaBusinessEntities.SightSeeing;
using LohanaBusinessEntities.SightSeeingTariff;
using LohanaBusinessEntities.Meal;
using LohanaBusinessEntities.Occupancy;
using LohanaBusinessEntities.Vendor;
using LohanaBusinessLogic.Utilities;
using LohanaHelper.Logging;
using LohanaRepo.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LohanaBusinessEntities.TaxFormula;

namespace LohanaRepo.SightSeeingTariff
{
  public class SightSeeingTariffRepo
    {
      SQLHelperRepo _sqlHelper = null;

      public SightSeeingTariffRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

      #region DropDowns

      public List<VendorInfo> drpGetVendors()
      {
          List<VendorInfo> vendors = new List<VendorInfo>();

          List<SqlParameter> sqlParams = new List<SqlParameter>();

          DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetVendors.ToString(), CommandType.StoredProcedure);

          if (dt != null && dt.Rows.Count > 0)
          {
              foreach (DataRow dr in dt.Rows)
              {
                  vendors.Add(GetVendorValues(dr));
              }
          }
          return vendors;
      }

      public VendorInfo GetVendorValues(DataRow dr)
      {
          VendorInfo retVal = new VendorInfo();

          retVal.VendorId = Convert.ToInt32(dr["VendorId"]);

          retVal.VendorName = Convert.ToString(dr["VendorName"]);

          return retVal;
      }

      public List<SightSeeingInfo> drpGetSightSeeings()
      {
          List<SightSeeingInfo> sightseeings = new List<SightSeeingInfo>();

          List<SqlParameter> sqlParams = new List<SqlParameter>();

          //DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetSightSeeings.ToString(), CommandType.StoredProcedure);

          //if (dt != null && dt.Rows.Count > 0)
          //{
          //    foreach (DataRow dr in dt.Rows)
          //    {
          //        sightseeings.Add(GetSightSeeingValues(dr));
          //    }
          //}
          return sightseeings;
      }

      public SightSeeingInfo GetSightSeeingValues(DataRow dr)
      {
          SightSeeingInfo retVal = new SightSeeingInfo();

          retVal.SightSeeingId = Convert.ToInt32(dr["SightSeeingId"]);

          retVal.SightSeeingName = Convert.ToString(dr["SightSeeingName"]);

          return retVal;
      }

      #endregion

      #region Bacic Details

      public int InsertSightSeeingTariff(SightSeeingTariffInfo sightseeingtariff)
      {
          return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInSightSeeingTariff(sightseeingtariff), Storeprocedures.spInsertSightSeeingTariffBasicDetails.ToString(), CommandType.StoredProcedure));
 
      }

      public List<SqlParameter> SetValuesInSightSeeingTariff(SightSeeingTariffInfo sightseeingtariff)
      {
          List<SqlParameter> sqlParam = new List<SqlParameter>();

          if (sightseeingtariff.SightSeeingTariffId != 0)
          {
              sqlParam.Add(new SqlParameter("SightSeeingTariffId", sightseeingtariff.SightSeeingTariffId));
          }
          else
          {
              sqlParam.Add(new SqlParameter("CreatedDate", sightseeingtariff.CreatedDate));

              sqlParam.Add(new SqlParameter("CreatedBy", sightseeingtariff.CreatedBy));
          }

          sqlParam.Add(new SqlParameter("@VendorId", sightseeingtariff.VendorId));

          Logger.Debug("SightSeeingTariff Controller VendorId:" + sightseeingtariff.VendorId);

          sqlParam.Add(new SqlParameter("@SightSeeingId", sightseeingtariff.SightSeeingId));

          Logger.Debug("SightSeeingTariff Controller VendorId:" + sightseeingtariff.SightSeeingId);

          //sqlParam.Add(new SqlParameter("@PackageName", sightseeingtariff.PackageName));

          //Logger.Debug("SightSeeingTariff Controller PackageName:" + sightseeingtariff.PackageName);

          //sqlParam.Add(new SqlParameter("@CancellationPolicy", sightseeingtariff.CancellationPolicy));

          //Logger.Debug("SightSeeingTariff Controller CancellationPolicy:" + sightseeingtariff.CancellationPolicy);

          //sqlParam.Add(new SqlParameter("@Inclusions", sightseeingtariff.Inclusions));

          //Logger.Debug("SightSeeingTariff Controller Inclusions:" + sightseeingtariff.Inclusions);

          //sqlParam.Add(new SqlParameter("@Exclusions", sightseeingtariff.Exclusions));

          //Logger.Debug("SightSeeingTariff Controller Exclusions:" + sightseeingtariff.Exclusions);

          //sqlParam.Add(new SqlParameter("@IsActive", sightseeingtariff.IsActive));

          sqlParam.Add(new SqlParameter("@UpdatedDate", sightseeingtariff.UpdatedDate));

          sqlParam.Add(new SqlParameter("@UpdatedBy", sightseeingtariff.UpdatedBy));

          return sqlParam;

      }

      public DataTable GetSightSeeingTariffBasic(int vendorId, int sightseeingId, ref PaginationInfo pager)
      {

          List<SqlParameter> sqlParam = new List<SqlParameter>();

          sqlParam.Add(new SqlParameter("@VendorId", vendorId));

          sqlParam.Add(new SqlParameter("@SightSeeingId", sightseeingId));

          DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetSightSeeingTariffBasicDetails.ToString(), CommandType.StoredProcedure);

          List<DataRow> drList = new List<DataRow>();

          return CommonMethods.GetPaginatedTable(dt, ref pager);

      }

      public void UpdateSightSeeingTariff(SightSeeingTariffInfo sightseeingtariff)
      {
          _sqlHelper.ExecuteNonQuery(SetValuesInSightSeeingTariff(sightseeingtariff), Storeprocedures.spUpdateSightSeeingTariffBasicDetails.ToString(), CommandType.StoredProcedure);
      }

      private SightSeeingTariffInfo GetSightSeeingTariffValues(DataRow dr)
      {
          SightSeeingTariffInfo sightseeingtariff = new SightSeeingTariffInfo();

          sightseeingtariff.SightSeeingTariffId = Convert.ToInt32(dr["SightSeeingTariffId"]);
          sightseeingtariff.VendorId = Convert.ToInt32(dr["VendorId"]);
          sightseeingtariff.SightSeeingId = Convert.ToInt32(dr["SightSeeingId"]);
          sightseeingtariff.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
          sightseeingtariff.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
          sightseeingtariff.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
          sightseeingtariff.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
          return sightseeingtariff;
      }

      public bool IsSameSightSeeingVendorExists(int vendorId, int sightseeingId)
      {
          List<SqlParameter> sqlParam = new List<SqlParameter>();

          sqlParam.Add(new SqlParameter("@VendorId", vendorId));

          sqlParam.Add(new SqlParameter("@SightSeeingId", sightseeingId));

          return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParam, Storeprocedures.spIsSameSightSeeingVendorExists.ToString(), CommandType.StoredProcedure));
      }

      #endregion

      #region SightSeeingTariffOccupancy

      public int InsertSightSeeingtTariffOccupancy(SightSeeingTariffOccupancyInfo sightseeingtariffoccupancy)
      {
          return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInSightSeeingTariffOccupancy(sightseeingtariffoccupancy), Storeprocedures.spInsertSightSeeingTariffOccupancy.ToString(), CommandType.StoredProcedure));

      }

      public void UpdateSightSeeingtTariffOccupancy(SightSeeingTariffOccupancyInfo sightseeingtariffoccupancy)
      {
          _sqlHelper.ExecuteNonQuery(SetValuesInSightSeeingTariffOccupancy(sightseeingtariffoccupancy), Storeprocedures.spUpdateSightSeeingtTariffOccupancy.ToString(), CommandType.StoredProcedure);
      }

      private List<SqlParameter> SetValuesInSightSeeingTariffOccupancy(SightSeeingTariffOccupancyInfo sightseeingtariffoccupancy)
      {
          List<SqlParameter> sqlParams = new List<SqlParameter>();

          if (sightseeingtariffoccupancy.SightSeeingTariffOccupancyId != 0)
          {
              sqlParams.Add(new SqlParameter("@SightSeeingTariffOccuapancyId", sightseeingtariffoccupancy.SightSeeingTariffOccupancyId));
          }
          else
          {
              sqlParams.Add(new SqlParameter("@CreatedDate", sightseeingtariffoccupancy.CreatedDate));

              sqlParams.Add(new SqlParameter("@CreatedBy", sightseeingtariffoccupancy.CreatedBy));

              sqlParams.Add(new SqlParameter("@SightSeeingTariffId", sightseeingtariffoccupancy.SightSeeingTariffId));
              Logger.Debug("SightSeeingTariff Controller SightSeeingTariffId:" + sightseeingtariffoccupancy.SightSeeingTariffId);
          }

          sqlParams.Add(new SqlParameter("@OccupancyId", sightseeingtariffoccupancy.OccupancyId));
          Logger.Debug("SightSeeingTariff Controller OccupancyId:" + sightseeingtariffoccupancy.OccupancyId);

          sqlParams.Add(new SqlParameter("@AgeFrom", sightseeingtariffoccupancy.AgeFrom));
          Logger.Debug("SightSeeingTariff Controller AgeFrom:" + sightseeingtariffoccupancy.AgeFrom);

          sqlParams.Add(new SqlParameter("@AgeTo", sightseeingtariffoccupancy.AgeTo));
          Logger.Debug("SightSeeingTariff Controller AgeTo:" + sightseeingtariffoccupancy.AgeTo);

          sqlParams.Add(new SqlParameter("@MealId", sightseeingtariffoccupancy.MealId));
          Logger.Debug("SightSeeingTariff Controller MealId:" + sightseeingtariffoccupancy.MealId);

          sqlParams.Add(new SqlParameter("@Inclusion", sightseeingtariffoccupancy.Inclusion));
          Logger.Debug("SightSeeingTariff Controller Inclusion:" + sightseeingtariffoccupancy.Inclusion);

          sqlParams.Add(new SqlParameter("@Exclusion", sightseeingtariffoccupancy.Exclusion));
          Logger.Debug("SightSeeingTariff Controller Exclusion:" + sightseeingtariffoccupancy.Exclusion);

          sqlParams.Add(new SqlParameter("@UpdatedDate", sightseeingtariffoccupancy.UpdatedDate));

          sqlParams.Add(new SqlParameter("@UpdatedBy", sightseeingtariffoccupancy.UpdatedBy));

          return sqlParams;
      }

      public DataTable GetSightSeeingTariffOccupancy(int sightseeingtariffid, ref PaginationInfo pager)
      {

          List<SqlParameter> sqlParam = new List<SqlParameter>();

          sqlParam.Add(new SqlParameter("@SightSeeingTariffId", sightseeingtariffid));

          DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetSightSeeingTariffOccupancy.ToString(), CommandType.StoredProcedure);

          List<DataRow> drList = new List<DataRow>();

          return CommonMethods.GetPaginatedTable(dt, ref pager);

      }

      private SightSeeingTariffOccupancyInfo GetSightSeeingTariffOccupancyValues(DataRow dr)
      {
          SightSeeingTariffOccupancyInfo sightseeingtariffoccupancy = new SightSeeingTariffOccupancyInfo();

          sightseeingtariffoccupancy.SightSeeingTariffId = Convert.ToInt32(dr["SightSeeingTariffId"]);
          sightseeingtariffoccupancy.OccupancyId = Convert.ToInt32(dr["OccupancyId"]);
          sightseeingtariffoccupancy.AgeFrom = Convert.ToDecimal(dr["AgeFrom"]);
          sightseeingtariffoccupancy.AgeTo = Convert.ToDecimal(dr["AgeFrom"]);
          sightseeingtariffoccupancy.MealId = Convert.ToInt32(dr["MealId"]);
          sightseeingtariffoccupancy.Inclusion = Convert.ToString(dr["Inclusion"]);
          sightseeingtariffoccupancy.Exclusion = Convert.ToString(dr["Exclusion"]);
          sightseeingtariffoccupancy.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
          sightseeingtariffoccupancy.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
          sightseeingtariffoccupancy.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
          sightseeingtariffoccupancy.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

          return sightseeingtariffoccupancy;
      }

      public void DeleteSightSeeingTariffOccupancy(int sightseeingtariffid, int sightseeingtariffoccupancyid)
      {
          List<SqlParameter> sqlParam = new List<SqlParameter>();

          //HotelTariffDurationDetailsInfo HotelTariffDuration = new HotelTariffDurationDetailsInfo();

          sqlParam.Add(new SqlParameter("@SightSeeingTariffId", sightseeingtariffid));

          Logger.Debug("SightSeeingTariff Controller SightSeeingTariffId:" + sightseeingtariffid);

          sqlParam.Add(new SqlParameter("@SightSeeingTariffOccupancyId", sightseeingtariffoccupancyid));

          Logger.Debug("SightSeeingTariff Controller SightSeeingTariffOccupancyId:" + sightseeingtariffoccupancyid);

          _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteSightSeeingTariffOccupancy.ToString(), CommandType.StoredProcedure);


      }

      #endregion


      #region Price Details

      public List<TaxFormulaChargesInfo> GetTaxFormulaChargesByPriceId(int taxFormulaId, int sightseeingtariffpriceid, ref PaginationInfo pager)
      {
          List<TaxFormulaChargesInfo> taxFormulaChargesInfo = new List<TaxFormulaChargesInfo>();

          List<SqlParameter> sqlParam = new List<SqlParameter>();

          sqlParam.Add(new SqlParameter("@TaxFormulaId", taxFormulaId));

          sqlParam.Add(new SqlParameter("@SightSeeingTariffPriceId", sightseeingtariffpriceid));


          DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetSightSeeingTariffTaxCharges.ToString(), CommandType.StoredProcedure);

          foreach (DataRow dr in dt.Rows)
          {
              taxFormulaChargesInfo.Add(GetSightSeeingTariffTaxFormulaCharges(dr));
          }

          return taxFormulaChargesInfo;
      }

      private TaxFormulaChargesInfo GetSightSeeingTariffTaxFormulaCharges(DataRow dr)
      {
          TaxFormulaChargesInfo taxFormulaCharges = new TaxFormulaChargesInfo();

          if (dr["ChargesId"] != DBNull.Value)
          {
              taxFormulaCharges.ChargesId = Convert.ToInt32(dr["ChargesId"]);
          }

          if (dr["ChargesName"] != DBNull.Value)
          {
              taxFormulaCharges.ChargesName = Convert.ToString(dr["ChargesName"]);
          }

          if (dr["ChargeFormula"] != DBNull.Value)
          {
              taxFormulaCharges.ChargeFormula = Convert.ToString(dr["ChargeFormula"]);
          }

          if (dr["ChargeFormulaText"] != DBNull.Value)
          {
              taxFormulaCharges.ChargeFormulaText = Convert.ToString(dr["ChargeFormulaText"]);
          }
          if (dr["Percentage"] != DBNull.Value)
          {
              taxFormulaCharges.SightSeeingTariffCharge.Percentage = Convert.ToDecimal(dr["Percentage"]);
          }

          if (dr["CalculatedPrice"] != DBNull.Value)
          {
              taxFormulaCharges.SightSeeingTariffCharge.CalculatedPrice = Convert.ToDecimal(dr["CalculatedPrice"]);
          }
          if (dr["TotalTaxPrice"] != DBNull.Value)
          {
              taxFormulaCharges.SightSeeingTariffCharge.TotalTaxPrice = Convert.ToDecimal(dr["TotalTaxPrice"]);
          }

          return taxFormulaCharges;
      }

      public List<TaxFormulaChargesInfo> GetTaxFormulaCharges(int taxFormulaId, ref PaginationInfo pager)
      {
          List<TaxFormulaChargesInfo> taxFormulaChargesInfo = new List<TaxFormulaChargesInfo>();

          List<SqlParameter> sqlParam = new List<SqlParameter>();

          sqlParam.Add(new SqlParameter("@TaxFormulaId", taxFormulaId));

          DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetTaxFormulaCharges.ToString(), CommandType.StoredProcedure);

          foreach (DataRow dr in dt.Rows)
          {
              taxFormulaChargesInfo.Add(GetTaxFormulaCharges(dr, taxFormulaId));
          }

          return taxFormulaChargesInfo;
      }

      private TaxFormulaChargesInfo GetTaxFormulaCharges(DataRow dr, int taxFormulaId)
      {
          TaxFormulaChargesInfo taxFormulaCharges = new TaxFormulaChargesInfo();

          taxFormulaCharges.TaxFormulaId = taxFormulaId;

          if (dr["ChargesId"] != DBNull.Value)
          {
              taxFormulaCharges.ChargesId = Convert.ToInt32(dr["ChargesId"]);
          }

          if (dr["ChargesName"] != DBNull.Value)
          {
              taxFormulaCharges.ChargesName = Convert.ToString(dr["ChargesName"]);
          }

          if (dr["ChargeFormula"] != DBNull.Value)
          {
              taxFormulaCharges.ChargeFormula = Convert.ToString(dr["ChargeFormula"]);
          }

          if (dr["ChargeFormulaText"] != DBNull.Value)
          {
              taxFormulaCharges.ChargeFormulaText = Convert.ToString(dr["ChargeFormulaText"]);
          }


          return taxFormulaCharges;
      }

      public int InsertSightSeeingTariffPrice(SightSeeingTariffPriceInfo sightseeingtariffprice)
      {


          sightseeingtariffprice.SightSeeingTariffPriceId = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInSightSeeingTariffPrice(sightseeingtariffprice), Storeprocedures.spInsertSightSeeingTariffPrice.ToString(), CommandType.StoredProcedure));

          InsertPriceChargesDetails(sightseeingtariffprice);


          return sightseeingtariffprice.SightSeeingTariffPriceId;


      }

      private List<SqlParameter> SetValuesInSightSeeingTariffPrice(SightSeeingTariffPriceInfo sightseeingtariffprice)
      {
          List<SqlParameter> sqlParams = new List<SqlParameter>();

          if (sightseeingtariffprice.SightSeeingTariffPriceId != 0)
          {
              sqlParams.Add(new SqlParameter("@SightSeeingTariffPriceId", sightseeingtariffprice.SightSeeingTariffPriceId));
          }
          else
          {
              sqlParams.Add(new SqlParameter("@CreatedDate", sightseeingtariffprice.CreatedDate));

              sqlParams.Add(new SqlParameter("@CreatedBy", sightseeingtariffprice.CreatedBy));
          }
          sqlParams.Add(new SqlParameter("@SightSeeingTariffOccupancyId", sightseeingtariffprice.SightSeeingTariffOccupancyId));
          Logger.Debug("SightSeeing Controller SightSeeingTariffOccupancyId:" + sightseeingtariffprice.SightSeeingTariffOccupancyId);

          sqlParams.Add(new SqlParameter("@PublishPrice", sightseeingtariffprice.PublishPrice));
          Logger.Debug("SightSeeing Controller PublishPrice:" + sightseeingtariffprice.PublishPrice);

          sqlParams.Add(new SqlParameter("@SpecialPrice", sightseeingtariffprice.SpecialPrice));
          Logger.Debug("SightSeeing Controller SpecialPrice:" + sightseeingtariffprice.SpecialPrice);

          sqlParams.Add(new SqlParameter("@CommissionPrice", sightseeingtariffprice.CommissionPrice));
          Logger.Debug("SightSeeing Controller CommissionPrice:" + sightseeingtariffprice.CommissionPrice);

          sqlParams.Add(new SqlParameter("@FormulaId", sightseeingtariffprice.FormulaId));
          Logger.Debug("SightSeeing Controller FormulaId:" + sightseeingtariffprice.FormulaId);

          sqlParams.Add(new SqlParameter("@TotalTaxPrice", sightseeingtariffprice.TotalTaxPrice));
          Logger.Debug("SightSeeing Controller TotalTaxPrice:" + sightseeingtariffprice.TotalTaxPrice);

          sqlParams.Add(new SqlParameter("@NetRate", sightseeingtariffprice.NetRate));
          Logger.Debug("SightSeeing Controller NetRate:" + sightseeingtariffprice.NetRate);

          sqlParams.Add(new SqlParameter("@Color", sightseeingtariffprice.Color));
          Logger.Debug("SightSeeing Controller Color:" + sightseeingtariffprice.Color);

          sqlParams.Add(new SqlParameter("@UpdatedDate", sightseeingtariffprice.UpdatedDate));

          sqlParams.Add(new SqlParameter("@UpdatedBy", sightseeingtariffprice.UpdatedBy));

          return sqlParams;
      }

      public void InsertPriceChargesDetails(SightSeeingTariffPriceInfo sightseeingtariffprice)
      {


          foreach (var item in sightseeingtariffprice.SightSeeingTariffCharges)
          {

              List<SqlParameter> sqlParam = new List<SqlParameter>();

              if (item.SightSeeingTariffChargesId != 0)
              {
                  sqlParam.Add(new SqlParameter("@SightSeeingTariffChargesId", item.SightSeeingTariffChargesId));
              }

              sqlParam.Add(new SqlParameter("@SightSeeingTariffPriceId", sightseeingtariffprice.SightSeeingTariffPriceId));

              sqlParam.Add(new SqlParameter("@ChargesId", item.ChargesId));

              sqlParam.Add(new SqlParameter("@Percentage", item.Percentage));

              sqlParam.Add(new SqlParameter("@CalculatedPrice", item.CalculatedPrice));

              _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spInsertSightSeeingTariffCharges.ToString(), CommandType.StoredProcedure);

          }

      }

      public List<SightSeeingTariffPriceInfo> GetSightSeeingTariffPrice(int sightseeingtariffccupancyid)
      {
          List<SqlParameter> sqlParam = new List<SqlParameter>();

          List<SightSeeingTariffPriceInfo> SightSeeingTariffPrices = new List<SightSeeingTariffPriceInfo>();

          sqlParam.Add(new SqlParameter("@SightSeeingTariffOccupancyId", sightseeingtariffccupancyid));

          DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetSightSeeingTariffPrice.ToString(), CommandType.StoredProcedure);

          if (dt != null && dt.Rows.Count > 0)
          {
              foreach (DataRow dr in dt.Rows)
              {
                  SightSeeingTariffPrices.Add(GetPriceValues(dr));
              }
          }
          return SightSeeingTariffPrices;
      }

      private SightSeeingTariffPriceInfo GetPriceValues(DataRow dr)
      {

          SightSeeingTariffPriceInfo SightSeeingTariffPrice = new SightSeeingTariffPriceInfo();

          SightSeeingTariffPrice.SightSeeingTariffPriceId = Convert.ToInt32(dr["SightSeeingTariffPriceId"]);

          SightSeeingTariffPrice.SightSeeingTariffOccupancyId = Convert.ToInt32(dr["SightSeeingTariffOccupancyId"]);

          SightSeeingTariffPrice.SpecialPrice = Convert.ToDecimal(dr["SpecialPrice"]);

          SightSeeingTariffPrice.PublishPrice = Convert.ToDecimal(dr["PublishPrice"]);

          SightSeeingTariffPrice.CommissionPrice = Convert.ToDecimal(dr["CommissionPrice"]);

          SightSeeingTariffPrice.FormulaId = Convert.ToInt32(dr["FormulaId"]);

          SightSeeingTariffPrice.TotalTaxPrice = Convert.ToDecimal(dr["TotalTaxPrice"]);

          SightSeeingTariffPrice.NetRate = Convert.ToDecimal(dr["NetRate"]);

          SightSeeingTariffPrice.Color = Convert.ToString(dr["Color"]);

          return SightSeeingTariffPrice;

      }

      public void UpdateSightSeeingTariffPrice(SightSeeingTariffPriceInfo sightseeingtariffprice)
      {
          _sqlHelper.ExecuteNonQuery(SetValuesInSightSeeingTariffPrice(sightseeingtariffprice), Storeprocedures.spUpdateSightSeeingTariffPrice.ToString(), CommandType.StoredProcedure);

          DeleteSightSeeingTariffCharges(sightseeingtariffprice);

          InsertPriceChargesDetails(sightseeingtariffprice);

      }

      public void DeleteSightSeeingTariffCharges(SightSeeingTariffPriceInfo sightseeingtariffprice)
      {

          List<SqlParameter> sqlParam = new List<SqlParameter>();

          sqlParam.Add(new SqlParameter("SightSeeingTariffPriceId", sightseeingtariffprice.SightSeeingTariffPriceId));

          _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteSightSeeingTariffCharges.ToString(), CommandType.StoredProcedure);

      }

      public SightSeeingTariffPriceInfo GetSightSeeingTariffPriceById(int sightseeingTariffPriceId)
      {
          SightSeeingTariffPriceInfo sightseeingTariffPrice = new SightSeeingTariffPriceInfo();

          List<SqlParameter> sqlParams = new List<SqlParameter>();

          sqlParams.Add(new SqlParameter("@SightSeeingTariffPriceId", sightseeingTariffPriceId));

          DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spGetSightSeeingTariffPriceById.ToString(), CommandType.StoredProcedure);

          if (dt != null && dt.Rows.Count > 0)
          {
              foreach (DataRow dr in dt.Rows)
              {
                  sightseeingTariffPrice = GetPriceValues(dr);
              }
          }

          return sightseeingTariffPrice;
      }


      #endregion

      #region SightSeeingTariffPriceDuration And Customer Catogories

      public List<SightSeeingTariffDateInfo> GetSightSeeingTariffDurationPrice(int sightseeingTariffOccupancyId)
      {
          List<SightSeeingTariffDateInfo> SightSeeingTariffDateDetails = new List<SightSeeingTariffDateInfo>();

          List<SqlParameter> sqlParam = new List<SqlParameter>();

          SightSeeingTariffDurationInfo duration = new SightSeeingTariffDurationInfo();

          sqlParam.Add(new SqlParameter("@SightSeeingTariffOccupancyId", sightseeingTariffOccupancyId));

          DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetSightSeeingTariffDurationPrice.ToString(), CommandType.StoredProcedure);

          if (dt != null && dt.Rows.Count > 0)
          {
              foreach (DataRow dr in dt.Rows)
              {
                  SightSeeingTariffDateDetails.Add(GetSightSeeingTariffDateValues(dr));
              }
          }

          return SightSeeingTariffDateDetails;
      }

      private SightSeeingTariffDateInfo GetSightSeeingTariffDateValues(DataRow dr)
      {
          SightSeeingTariffDateInfo sightseeingtariffdate = new SightSeeingTariffDateInfo();

          if (dr["TariffDate"] != DBNull.Value)
          {
              sightseeingtariffdate.TariffDate = Convert.ToDateTime(dr["TariffDate"]);
          }

          if (dr["NetRate"] != DBNull.Value)
          {
              sightseeingtariffdate.NetRate = Convert.ToDecimal(dr["NetRate"]);
          }

          if (dr["SightSeeingTariffPriceId"] != DBNull.Value)
          {
              sightseeingtariffdate.SightSeeingTariffPriceId = Convert.ToInt32(dr["SightSeeingTariffPriceId"]);
          }

          if (dr["SightSeeingTariffOccupancyId"] != DBNull.Value)
          {
              sightseeingtariffdate.SightSeeingTariffOccupancyId = Convert.ToInt32(dr["SightSeeingTariffOccupancyId"]);
          }

          if (dr["SightSeeingTariffDatesId"] != DBNull.Value)
          {
              sightseeingtariffdate.SightSeeingTariffDatesId = Convert.ToInt32(dr["SightSeeingTariffDatesId"]);
          }

          return sightseeingtariffdate;
      }

      public List<DateTime> GetFilteredDateForDuration(SightSeeingTariffDurationInfo sightseeingTariffDuration)
      {
          List<DateTime> dates = new List<DateTime>();

          foreach (DateTime day in EachDay(sightseeingTariffDuration.FromDate, sightseeingTariffDuration.ToDate))
          {
              if (sightseeingTariffDuration.OperationalDays.Split(',').Contains(day.DayOfWeek.ToString()))
              {
                  dates.Add(day.Date);
              }
          }
          return dates;
      }

      public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
      {
          for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
              yield return day;
      }

      public void SaveSightSeeingTariffDurationWithCustomerCategories(List<DateTime> dates, SightSeeingTariffDateInfo sightseeingTariffDate, List<SightSeeingTariffCustomerCategoryInfo> sightseeingCustomerCategories)
      {
          foreach (var item in dates)
          {
              List<SqlParameter> sqlParams = new List<SqlParameter>();

              sqlParams.Add(new SqlParameter("@SightSeeingTariffPriceId", sightseeingTariffDate.SightSeeingTariffPriceId));
              Logger.Debug("SaveSightSeeingTariffDuration SightSeeingTariffPriceId:" + sightseeingTariffDate.SightSeeingTariffPriceId);

              sqlParams.Add(new SqlParameter("@TariffDate", item));
              Logger.Debug("SaveSightSeeingTariffDuration TariffDate:" + item);

              sqlParams.Add(new SqlParameter("@NetRate", sightseeingTariffDate.NetRate));
              Logger.Debug("SaveSightSeeingTariffDuration NetRate:" + sightseeingTariffDate.NetRate);

              sqlParams.Add(new SqlParameter("@SightSeeingTariffOccupancyId", sightseeingTariffDate.SightSeeingTariffOccupancyId));
              Logger.Debug("SaveSightSeeingTariffDuration SightSeeingTariffOccupancyId:" + sightseeingTariffDate.SightSeeingTariffOccupancyId);

              sightseeingTariffDate.SightSeeingTariffDatesId = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spInsertSightSeeingTariffDate.ToString(), CommandType.StoredProcedure));

              foreach (var itm in sightseeingCustomerCategories)
              {
                  List<SqlParameter> sqlParam = new List<SqlParameter>();

                  sqlParam.Add(new SqlParameter("@SightSeeingTariffDatesId", sightseeingTariffDate.SightSeeingTariffDatesId));

                  sqlParam.Add(new SqlParameter("@CustomerCategoryId", itm.CustomerCategoryId));

                  sqlParam.Add(new SqlParameter("@Margin", itm.GlobalMargin));

                  sqlParam.Add(new SqlParameter("@CreatedDate", itm.CreatedDate));

                  sqlParam.Add(new SqlParameter("@CreatedBy", itm.CreatedBy));

                  sqlParam.Add(new SqlParameter("@UpdatedDate", itm.UpdatedDate));

                  sqlParam.Add(new SqlParameter("@UpdatedBy", itm.UpdatedBy));

                  _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spInsertSightSeeingTariffCustomerCategory.ToString(), CommandType.StoredProcedure);
              }

          }
      }

      #endregion

      #region SightSeeingTariff Duration

      public int InsertDuration(DurationInfo duration)
      {
          duration.DurationId = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInDuration(duration), Storeprocedures.spInsertSightSeeingTariffDuration.ToString(), CommandType.StoredProcedure));
      
          InsertDurationDates(duration);

          return duration.DurationId;
        
      }

      public void InsertDurationDates(DurationInfo duration)
      {

          var Dates = duration.Dates.Split(',');

          var Days = duration.Day.Split(',');

          foreach(var item in Dates.Zip(Days,(a,b)=> new {date=a,day=b}))
          {
              
              List<SqlParameter> sqlParam = new List<SqlParameter>();

              if (duration.SightSeeingDateDetailsId != 0)
              {
                  sqlParam.Add(new SqlParameter("SightSeeingDateDetailsId", duration.SightSeeingDateDetailsId));
              }
              else
              {
                  sqlParam.Add(new SqlParameter("CreatedDate", duration.CreatedDate));

                  sqlParam.Add(new SqlParameter("CreatedBy", duration.CreatedBy));
              }
              sqlParam.Add(new SqlParameter("@DurationId", duration.DurationId));

              Logger.Debug("SightSeeingTariff Controller DurationId: " + duration.DurationId);

              sqlParam.Add(new SqlParameter("@SightSeeingTariffId", duration.SightSeeingTariffId));

              Logger.Debug("SightSeeingTariff Controller SightSeeingTariffId: " + duration.SightSeeingTariffId);

              sqlParam.Add(new SqlParameter("@Date", item.date));

              Logger.Debug("SightSeeingTariff Controller Date: " + item.date);

              sqlParam.Add(new SqlParameter("@Day",item.day));

              Logger.Debug("SightSeeingTariff Controller Day: " + item.day);

              sqlParam.Add(new SqlParameter("@NetRate", duration.NetRate));

              Logger.Debug("SightSeeingTariff Controller NetRate: " + duration.NetRate);

              sqlParam.Add(new SqlParameter("@UpdatedDate", duration.UpdatedDate));

              sqlParam.Add(new SqlParameter("@UpdatedBy", duration.UpdatedBy));
            
              _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spInsertSightSeeingTariffDurationDate.ToString(), CommandType.StoredProcedure);

              
          }    

      }

      public List<SqlParameter> SetValuesInDuration(DurationInfo duration)
      {
          List<SqlParameter> sqlParam = new List<SqlParameter>();

          if (duration.DurationId != 0)
          {
              sqlParam.Add(new SqlParameter("DurationId",duration.DurationId));
          }
          else
          {
              sqlParam.Add(new SqlParameter("CreatedDate",duration.CreatedDate));

              sqlParam.Add(new SqlParameter("CreatedBy",duration.CreatedBy));
          }

          sqlParam.Add(new SqlParameter("@SightSeeingTariffId",duration.SightSeeingTariffId));

          Logger.Debug("SightSeeingTariff Controller SightSeeingTariffId: " + duration.SightSeeingTariffId);

          sqlParam.Add(new SqlParameter("@FromDate",duration.FromDate));

          Logger.Debug("SightSeeingTariff Controller FromDate: " + duration.FromDate);

          sqlParam.Add(new SqlParameter("@ToDate",duration.ToDate));

          Logger.Debug("SightSeeingTariff Controller ToDate: " + duration.ToDate);

          sqlParam.Add(new SqlParameter("@OperationalDays",duration.OperationalDays));

          Logger.Debug("SightSeeingTariff Controller OperationalDays: " + duration.OperationalDays);

          sqlParam.Add(new SqlParameter("@UpdatedDate", duration.UpdatedDate));

          sqlParam.Add(new SqlParameter("@UpdatedBy", duration.UpdatedBy));

          return sqlParam;

      }

      public DataTable GetDuration(ref PaginationInfo pager)
      {

          List<SqlParameter> sqlParam = new List<SqlParameter>();

          DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetSightSeeingTariffDuration.ToString(), CommandType.StoredProcedure);

          List<DataRow> drList = new List<DataRow>();

          return CommonMethods.GetPaginatedTable(dt, ref pager);

      }

    #endregion

      #region Customer Category

      public void SaveSightSeeingTariffCustomerCategory(SightSeeingTariffCustomerCategoryInfo customercategory)
      {
          _sqlHelper.ExecuteNonQuery(SetValuesInSightSeeingTariffCustomerCategory(customercategory), Storeprocedures.spInsertSightSeeingTariffCustomerCategory.ToString(), CommandType.StoredProcedure);
      }

      private List<SqlParameter> SetValuesInSightSeeingTariffCustomerCategory(SightSeeingTariffCustomerCategoryInfo customercategory)
      {
          List<SqlParameter> sqlParams = new List<SqlParameter>();

          sqlParams.Add(new SqlParameter("@SightSeeingTariffDatesId", customercategory.SightSeeingTariffDatesId));

          sqlParams.Add(new SqlParameter("@CreatedDate", customercategory.CreatedDate));

          sqlParams.Add(new SqlParameter("@CreatedBy", customercategory.CreatedBy));

          sqlParams.Add(new SqlParameter("@CustomerCategoryId", customercategory.CustomerCategoryId));
          Logger.Debug("SightSeeingTariff Controller CustomerCategoryId:" + customercategory.CustomerCategoryId);

          sqlParams.Add(new SqlParameter("@Margin", customercategory.TariffMargin));
          Logger.Debug("SightSeeingTariff Controller Margin:" + customercategory.TariffMargin);

          sqlParams.Add(new SqlParameter("@UpdatedDate", customercategory.UpdatedDate));

          sqlParams.Add(new SqlParameter("@UpdatedBy", customercategory.UpdatedBy));

          return sqlParams;
      }

      public List<SightSeeingTariffCustomerCategoryInfo> GetCustomerCategory()
      {
          List<SightSeeingTariffCustomerCategoryInfo> SightSeeingTariffCustomerCategories = new List<SightSeeingTariffCustomerCategoryInfo>();

          DataTable dt = _sqlHelper.ExecuteDataTable(null, Storeprocedures.spGetSightSeeingTariffCustomerCategory.ToString(), CommandType.StoredProcedure);

          if (dt.Rows.Count > 0)
          {
              foreach (DataRow dr in dt.Rows)
              {
                  SightSeeingTariffCustomerCategories.Add(GetCustomerCategoriesValues(dr));
              }
          }

          return SightSeeingTariffCustomerCategories;
      }

      private SightSeeingTariffCustomerCategoryInfo GetCustomerCategoriesValues(DataRow dr)
      {
          SightSeeingTariffCustomerCategoryInfo CustomerCategory = new SightSeeingTariffCustomerCategoryInfo();

          if (dr["CustomerCategoryId"] != DBNull.Value)
          {
              CustomerCategory.CustomerCategoryId = Convert.ToInt32(dr["CustomerCategoryId"]);
          }

          CustomerCategory.CustomerCategoryName = Convert.ToString(dr["CustomerCategoryName"]);

          if (dr["GlobalMargin"] != DBNull.Value)
          {
              CustomerCategory.GlobalMargin = Convert.ToInt32(dr["GlobalMargin"]);
          }

          return CustomerCategory;
      }

      public void UpdateCustomerCategory(SightSeeingTariffCustomerCategoryInfo customercategory)
      {
          _sqlHelper.ExecuteNonQuery(SetValuesInSightSeeingTariffCustomerCategory(customercategory), Storeprocedures.spUpdateSightSeeingTariffCustomerCategory.ToString(), CommandType.StoredProcedure);
      }

      public List<SightSeeingTariffCustomerCategoryInfo> GetSightSeeingTariffCustomerCategory(int sightseeingTariffOccupancyId, DateTime tariffDate)
      {
          List<SightSeeingTariffCustomerCategoryInfo> SightSeeingTariffCustomerCategory = new List<SightSeeingTariffCustomerCategoryInfo>();

          List<SqlParameter> sqlParam = new List<SqlParameter>();

          SightSeeingTariffDurationInfo duration = new SightSeeingTariffDurationInfo();

          sqlParam.Add(new SqlParameter("@SightSeeingTariffOccupancyId", sightseeingTariffOccupancyId));

          sqlParam.Add(new SqlParameter("@TariffDate", tariffDate));

          DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetSightSeeingTariffCustomerCategories.ToString(), CommandType.StoredProcedure);

          if (dt != null && dt.Rows.Count > 0)
          {
              foreach (DataRow dr in dt.Rows)
              {
                  SightSeeingTariffCustomerCategory.Add(GetSightSeeingTariffCustomerCategoryValues(dr));
              }
          }

          return SightSeeingTariffCustomerCategory;
      }

      private SightSeeingTariffCustomerCategoryInfo GetSightSeeingTariffCustomerCategoryValues(DataRow dr)
      {
          SightSeeingTariffCustomerCategoryInfo sightseeingtariffcustomercategory = new SightSeeingTariffCustomerCategoryInfo();


          if (dr["Margin"] != DBNull.Value)
          {
              sightseeingtariffcustomercategory.TariffMargin = Convert.ToDecimal(dr["Margin"]);
          }

          if (dr["CustomerCategoryName"] != DBNull.Value)
          {
              sightseeingtariffcustomercategory.CustomerCategoryName = Convert.ToString(dr["CustomerCategoryName"]);
          }

          if (dr["CustomerCategoryId"] != DBNull.Value)
          {
              sightseeingtariffcustomercategory.CustomerCategoryId = Convert.ToInt32(dr["CustomerCategoryId"]);
          }

          if (dr["SightSeeingTariffDatesId"] != DBNull.Value)
          {
              sightseeingtariffcustomercategory.SightSeeingTariffDatesId = Convert.ToInt32(dr["SightSeeingTariffDatesId"]);
          }

          if (dr["SightSeeingTariffOccupancyId"] != DBNull.Value)
          {
              sightseeingtariffcustomercategory.SightSeeingTariffOccupancyId = Convert.ToInt32(dr["SightSeeingTariffOccupancyId"]);
          }

          return sightseeingtariffcustomercategory;
      }

      #endregion

      #region SightSeeing

      public SightSeeingInfo GetSightSeeingById(int SightSeeingid)
      {
          List<SqlParameter> sqlParam = new List<SqlParameter>();

          SightSeeingInfo SightSeeing = new SightSeeingInfo();

          sqlParam.Add(new SqlParameter("@SightSeeingId", SightSeeingid));

          Logger.Debug("SightSeeingTariff Controller SightSeeingId: " + SightSeeingid);

          DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetSightSeeingById.ToString(), CommandType.StoredProcedure);

          if (dt != null && dt.Rows.Count > 0)
          {
              foreach (DataRow dr in dt.Rows)
              {
                  SightSeeing = GetSightSeeingData(dr);
              }            
          }
          return SightSeeing;
      }


      public SightSeeingInfo GetSightSeeingData(DataRow dr)
      {

          SightSeeingInfo SightSeeing = new SightSeeingInfo();

          SightSeeing.SightSeeingId = Convert.ToInt32(dr["SightSeeingId"]);

          if (!dr.IsNull("SightSeeingName"))
              SightSeeing.SightSeeingName = Convert.ToString(dr["SightSeeingName"]);

          if (!dr.IsNull("CityId"))
              SightSeeing.CityId = Convert.ToInt32(dr["CityId"]);

          if (!dr.IsNull("Description"))
              SightSeeing.Description = Convert.ToString(dr["Description"]);

          if (!dr.IsNull("TimeFrom"))
              SightSeeing.TimeFrom = Convert.ToString(dr["TimeFrom"]);

          if (!dr.IsNull("TimeTo"))
              SightSeeing.TimeTo = Convert.ToString(dr["TimeTo"]);

          if (!dr.IsNull("VisitTime"))
              SightSeeing.VisitTime = Convert.ToString(dr["VisitTime"]);

          if (!dr.IsNull("TotalCost"))
              SightSeeing.TotalCost = Convert.ToInt32(dr["TotalCost"]);

          if (!dr.IsNull("IsActive"))
              SightSeeing.IsActive = Convert.ToBoolean(dr["IsActive"]);

          if (!dr.IsNull("OperationalDays"))
              SightSeeing.OperationalDays = Convert.ToString(dr["OperationalDays"]);

          return SightSeeing;


      }

      #endregion


      public List<TaxFormulaInfo> drpGetTaxFormula()
      {
          throw new NotImplementedException();
      }
    }
}
