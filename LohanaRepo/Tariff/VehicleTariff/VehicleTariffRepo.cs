using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Tariff.VehicleTariff;
using LohanaBusinessEntities.CustomerCategory;
using LohanaBusinessEntities.Vehicle;
using LohanaBusinessEntities.Vendor;
using LohanaBusinessLogic.Utilities;
using LohanaRepo.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LohanaHelper.Logging;

namespace LohanaRepo.Tariff.VehicleTariff
{
    public class VehicleTariffRepo
    {

         SQLHelperRepo _sqlHelper = null;


      public VehicleTariffRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

      #region Vehicle Tariff Dropdown

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

      public List<VehicleInfo> drpGetVehicles()
      {
          List<VehicleInfo> vehicles = new List<VehicleInfo>();

          List<SqlParameter> sqlParams = new List<SqlParameter>();

          DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetVehicles.ToString(), CommandType.StoredProcedure);

          if (dt != null && dt.Rows.Count > 0)
          {
              foreach (DataRow dr in dt.Rows)
              {
                  vehicles.Add(GetVehicleValues(dr));
              }
          }
          return vehicles;
      }

      public VehicleInfo GetVehicleValues(DataRow dr)
      {
          VehicleInfo retVal = new VehicleInfo();

          retVal.VehicleId = Convert.ToInt32(dr["VehicleId"]);

          retVal.VehicleName = Convert.ToString(dr["VehicleName"]);

          return retVal;
      }

      public List<CustomerCategoryInfo> drpGetCustomerCategories()
      {
          List<CustomerCategoryInfo> CustomerCategories = new List<CustomerCategoryInfo>();

          List<SqlParameter> sqlParams = new List<SqlParameter>();

          DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetCustomerCategory.ToString(), CommandType.StoredProcedure);

          if (dt != null && dt.Rows.Count > 0)
          {
              foreach (DataRow dr in dt.Rows)
              {
                  CustomerCategories.Add(GetCustomerCategoryValues(dr));
              }
          }
          return CustomerCategories;
      }

      public CustomerCategoryInfo GetCustomerCategoryValues(DataRow dr)
      {
          CustomerCategoryInfo retVal = new CustomerCategoryInfo();

          retVal.CustomerCategoryId = Convert.ToInt32(dr["CustomerCategoryId"]);

          retVal.CustomerCategoryName = Convert.ToString(dr["CustomerCategoryName"]);

          retVal.Margin = Convert.ToInt32(dr["Margin"]);

          return retVal;
      }

      #endregion

      #region Vehicle Tariff Basic

      public int InsertVehicleTariff(VehicleTariffInfo vehicletariff)
      {
          return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInVehicleTariff(vehicletariff), Storeprocedures.spInsertVehicleTariff.ToString(), CommandType.StoredProcedure));
 
      }

      public List<SqlParameter> SetValuesInVehicleTariff(VehicleTariffInfo vehicletariff)
      {
          List<SqlParameter> sqlParam = new List<SqlParameter>();

          if (vehicletariff.VehicleTariffId != 0)
          {
              sqlParam.Add(new SqlParameter("VehicleTariffId", vehicletariff.VehicleTariffId));
          }
          else
          {
              sqlParam.Add(new SqlParameter("CreatedDate", vehicletariff.CreatedDate));

              sqlParam.Add(new SqlParameter("CreatedBy", vehicletariff.CreatedBy));
          }

          sqlParam.Add(new SqlParameter("@VendorId", vehicletariff.VendorId));

          Logger.Debug("VehicleTariff Controller VendorId:" + vehicletariff.VendorId);

          sqlParam.Add(new SqlParameter("@PackageName", vehicletariff.PackageName));

          Logger.Debug("VehicleTariff Controller PackageName:" + vehicletariff.PackageName);

          sqlParam.Add(new SqlParameter("@CancellationPolicy", vehicletariff.CancellationPolicy));

          Logger.Debug("VehicleTariff Controller CancellationPolicy:" + vehicletariff.CancellationPolicy);

          sqlParam.Add(new SqlParameter("@Inclusions", vehicletariff.Inclusions));

          Logger.Debug("VehicleTariff Controller Inclusions:" + vehicletariff.Inclusions);

          sqlParam.Add(new SqlParameter("@Exclusions", vehicletariff.Exclusions));

          Logger.Debug("VehicleTariff Controller Exclusions:" + vehicletariff.Exclusions);

          sqlParam.Add(new SqlParameter("@Status", vehicletariff.Status));

          Logger.Debug("VehicleTariff Controller Status:" + vehicletariff.Status);

          sqlParam.Add(new SqlParameter("@UpdatedDate", vehicletariff.UpdatedDate));

          sqlParam.Add(new SqlParameter("@UpdatedBy", vehicletariff.UpdatedBy));

          return sqlParam;

      }

      public void Update(VehicleTariffInfo vehicletariff)
      {
          _sqlHelper.ExecuteNonQuery(SetValuesInVehicleTariff(vehicletariff), Storeprocedures.spUpdateVehicleTariff.ToString(), CommandType.StoredProcedure);
      }

      #endregion

      #region Search Vehicle Tariff Basic

      public DataTable SearchVehicleTariffBasicDetails(int vendorId, string packageName, ref PaginationInfo pager)
      {
          List<SqlParameter> sqlParam = new List<SqlParameter>();

          sqlParam.Add(new SqlParameter("@VendorId", vendorId));

          sqlParam.Add(new SqlParameter("@PackageName", packageName));

          DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spSearchVehicleTariff.ToString(), CommandType.StoredProcedure);

          List<DataRow> drList = new List<DataRow>();

          return CommonMethods.GetPaginatedTable(dt, ref pager);

      }

      #endregion

      #region Search Vehicle Tariff Price Detail

      public List<VehicleInfo> GetVehicleDetailsById(int vehicleId)
      {

          List<VehicleInfo> VehicleData = new List<VehicleInfo>();

          List<SqlParameter> sqlparam = new List<SqlParameter>();

          sqlparam.Add(new SqlParameter("@VehicleId", vehicleId));

          Logger.Debug("VehicleTariff Controller VendorId:" + vehicleId);

          DataTable dt = _sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.spGetVehicleTypeandSeatingCapacityOndrpVehicle.ToString(), CommandType.StoredProcedure);

          foreach (DataRow dr in dt.Rows)
          {
              VehicleData.Add(GetVehicleDetailsValues(dr));
          }

          return VehicleData;
      }

      private VehicleInfo GetVehicleDetailsValues(DataRow dr)
      {
          VehicleInfo VehicleDetails = new VehicleInfo();

          VehicleDetails.VehicleId = Convert.ToInt32(dr["VehicleId"]);

          VehicleDetails.VehicleTypeName = Convert.ToString(dr["VehicleTypeName"]);

          VehicleDetails.SeatCapacity = Convert.ToInt32(dr["SeatCapacity"]);

          return VehicleDetails;
      }

      public int InsertVehicleTariffPriceDetails(VehicleTariffPriceDetailsInfo vehicletariffprice)
      {
          return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInVehicleTariffPriceDetails(vehicletariffprice), Storeprocedures.spInsertVehicleTariffPriceDetails.ToString(), CommandType.StoredProcedure));

      }

      public List<SqlParameter> SetValuesInVehicleTariffPriceDetails(VehicleTariffPriceDetailsInfo vehicletariffprice)
      {
          List<SqlParameter> sqlParam = new List<SqlParameter>();

          if (vehicletariffprice.VehicleTariffPriceDetailsId != 0)
          {
              sqlParam.Add(new SqlParameter("VehicleTariffPriceDetalsId", vehicletariffprice.VehicleTariffPriceDetailsId));
          }
          else
          {
              sqlParam.Add(new SqlParameter("CreatedDate", vehicletariffprice.CreatedDate));

              sqlParam.Add(new SqlParameter("CreatedBy", vehicletariffprice.CreatedBy));
          }

          sqlParam.Add(new SqlParameter("@VehicleTariffId", vehicletariffprice.VehicleTariffId));

          Logger.Debug("VehicleTariff Controller VehicleTariffId:" + vehicletariffprice.VehicleTariffId);

          sqlParam.Add(new SqlParameter("@VehicleId", vehicletariffprice.VehicleId));

          Logger.Debug("VehicleTariff Controller VehicleId:" + vehicletariffprice.VehicleId);

          sqlParam.Add(new SqlParameter("@VehicleType", vehicletariffprice.VehicleTypeName));

          Logger.Debug("VehicleTariff Controller VehicleType:" + vehicletariffprice.VehicleTypeName);

          sqlParam.Add(new SqlParameter("@SeatingCapacity", vehicletariffprice.SeatingCapacity));

          Logger.Debug("VehicleTariff Controller SeatingCapacity:" + vehicletariffprice.SeatingCapacity);

          sqlParam.Add(new SqlParameter("@FreeKms", vehicletariffprice.FreeKms));

          Logger.Debug("VehicleTariff Controller FreeKms:" + vehicletariffprice.FreeKms);

          sqlParam.Add(new SqlParameter("@KmAmount", vehicletariffprice.KmAmount));

          Logger.Debug("VehicleTariff Controller KmAmount:" + vehicletariffprice.KmAmount);

          sqlParam.Add(new SqlParameter("@RupeesPerExtraKm", vehicletariffprice.RupeesPerExtraKm));

          Logger.Debug("VehicleTariff Controller RupeesPerExtraKm:" + vehicletariffprice.RupeesPerExtraKm);

          sqlParam.Add(new SqlParameter("@Duration", vehicletariffprice.Duration));

          Logger.Debug("VehicleTariff Controller Duration:" + vehicletariffprice.Duration);

          sqlParam.Add(new SqlParameter("@HoursAmount", vehicletariffprice.HoursAmount));

          Logger.Debug("VehicleTariff Controller HoursAmount:" + vehicletariffprice.HoursAmount);

          sqlParam.Add(new SqlParameter("@RupeesPerExtraHours", vehicletariffprice.RupeesPerExtraHours));

          Logger.Debug("VehicleTariff Controller RupeesPerExtraHours:" + vehicletariffprice.RupeesPerExtraHours);

          sqlParam.Add(new SqlParameter("@Source", vehicletariffprice.Source));

          Logger.Debug("VehicleTariff Controller Source:" + vehicletariffprice.Source);

          sqlParam.Add(new SqlParameter("@Destination", vehicletariffprice.Destination));

          Logger.Debug("VehicleTariff Controller Destination:" + vehicletariffprice.Destination);

          sqlParam.Add(new SqlParameter("@PackageAmount", vehicletariffprice.PackageAmount));

          Logger.Debug("VehicleTariff Controller PackageAmount:" + vehicletariffprice.PackageAmount);

          sqlParam.Add(new SqlParameter("@TransferType", vehicletariffprice.TransferType));

          Logger.Debug("VehicleTariff Controller Transfer Type:" + vehicletariffprice.TransferType);

          sqlParam.Add(new SqlParameter("@TransferSource", vehicletariffprice.TransferSource));

          Logger.Debug("VehicleTariff Controller Transfer Source:" + vehicletariffprice.TransferSource);

          sqlParam.Add(new SqlParameter("@TransferDestination", vehicletariffprice.TransferDestination));

          Logger.Debug("VehicleTariff Controller Transfer Destination:" + vehicletariffprice.TransferDestination);

          sqlParam.Add(new SqlParameter("@TransferPackageAmount", vehicletariffprice.TransferPackageAmount));

          Logger.Debug("VehicleTariff Controller Transfer PackageAmount:" + vehicletariffprice.TransferPackageAmount);

          sqlParam.Add(new SqlParameter("@UpdatedDate", vehicletariffprice.UpdatedDate));

          sqlParam.Add(new SqlParameter("@UpdatedBy", vehicletariffprice.UpdatedBy));

          return sqlParam;

      }

      public DataTable GetVehicleTariffPriceDetails(int vehicleTariffId, ref PaginationInfo pager)
      {
          List<SqlParameter> sqlParam = new List<SqlParameter>();

          sqlParam.Add(new SqlParameter("@VehicleTariffId", vehicleTariffId));

          Logger.Debug("VehicleTariff Controller VehicleTariffId:" + vehicleTariffId);

          DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetVehicleTariffPriceDetails.ToString(), CommandType.StoredProcedure);

          List<DataRow> drList = new List<DataRow>();

          return CommonMethods.GetPaginatedTable(dt, ref pager);

      }

      public void UpdateVehicleTariffPrice(VehicleTariffPriceDetailsInfo vehicletariffprice)
      {
          _sqlHelper.ExecuteNonQuery(SetValuesInVehicleTariffPriceDetails(vehicletariffprice), Storeprocedures.spUpdateVehicleTariffPriceDetails.ToString(), CommandType.StoredProcedure);
      }

      public void DeleteVehicleTariffPriceDetails(int vehicletariffpricedetailsid, int vehicletariffid)
      {
          List<SqlParameter> sqlParam = new List<SqlParameter>();

          sqlParam.Add(new SqlParameter("@VehicleTariffPriceDetalsId", vehicletariffpricedetailsid));

          Logger.Debug("VehicleTariff Controller VehicleTariffPriceDetalsId:" + vehicletariffpricedetailsid);

          sqlParam.Add(new SqlParameter("@VehicleTariffId", vehicletariffid));

          Logger.Debug("VehicleTariff Controller VehicleTariffId:" + vehicletariffid);

          _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteVehicleTariffPriceDetails.ToString(), CommandType.StoredProcedure);

      }

      #endregion

      #region Search Vehicle Tariff Customer Category Details

      public List<CustomerCategoryInfo> GetCustomerCategoryDetailsById(int customerCategoryId)
      {

          List<CustomerCategoryInfo> CustomerCategoryData = new List<CustomerCategoryInfo>();

          List<SqlParameter> sqlparam = new List<SqlParameter>();

          sqlparam.Add(new SqlParameter("@CustomerCategoryId", customerCategoryId));

          Logger.Debug("VehicleTariff Controller CustomerCategoryId: " + customerCategoryId);

          DataTable dt = _sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.spGetMarginOndrpCustomerCategory.ToString(), CommandType.StoredProcedure);

          foreach (DataRow dr in dt.Rows)
          {
              CustomerCategoryData.Add(GetCustomerCategoryDetailsValues(dr));
          }

          return CustomerCategoryData;
      }

      private CustomerCategoryInfo GetCustomerCategoryDetailsValues(DataRow dr)
      {
          CustomerCategoryInfo CustomerCategoryDetails = new CustomerCategoryInfo();

          CustomerCategoryDetails.CustomerCategoryId = Convert.ToInt32(dr["CustomerCategoryId"]);

          CustomerCategoryDetails.CustomerCategoryName = Convert.ToString(dr["CustomerCategoryName"]);

          CustomerCategoryDetails.Margin = Convert.ToDecimal(dr["Margin"]);

          return CustomerCategoryDetails;
      }

      /*public int InsertVehicleTariffCustomerCategoryDetails(VehicleTariffCustomerCategoryDetailsInfo vehicletariffcustomercategory)
      {
          return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInVehicleTariffCustomerCategoryDetails(vehicletariffcustomercategory), Storeprocedures.spInsertVehicleTariffCustomerCategoryDetails.ToString(), CommandType.StoredProcedure));

      }*/

      public void InsertVehicleTariffCustomerCategoryDetails(List<VehicleTariffCustomerCategoryDetailsInfo> VehicleTariffCustomerCategories)
      {
          foreach (var item in VehicleTariffCustomerCategories)
          {
              if (item.Margin != 0)
              {
                  item.VehicleTariffCustomerCategoryDetailsId = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInVehicleTariffCustomerCategoryDetails(item), Storeprocedures.spInsertVehicleTariffCustomerCategoryDetails.ToString(), CommandType.StoredProcedure));
              }
          }

      }

      public List<SqlParameter> SetValuesInVehicleTariffCustomerCategoryDetails(VehicleTariffCustomerCategoryDetailsInfo vehicletariffcustomercategory)
      {
          List<SqlParameter> sqlParam = new List<SqlParameter>();

          if (vehicletariffcustomercategory.VehicleTariffCustomerCategoryDetailsId != 0)
          {
              sqlParam.Add(new SqlParameter("VehicleTariffCustomerCategoryDetailsId", vehicletariffcustomercategory.VehicleTariffCustomerCategoryDetailsId));
          }
          else
          {
              sqlParam.Add(new SqlParameter("CreatedDate", vehicletariffcustomercategory.CreatedDate));

              sqlParam.Add(new SqlParameter("CreatedBy", vehicletariffcustomercategory.CreatedBy));
          }

          sqlParam.Add(new SqlParameter("@VehicleTariffId", vehicletariffcustomercategory.VehicleTariffId));

          Logger.Debug("VehicleTariff Controller VehicleTariffId:" + vehicletariffcustomercategory.VehicleTariffId);

          sqlParam.Add(new SqlParameter("@CustomerCategoryId", vehicletariffcustomercategory.CustomerCategoryId));

          Logger.Debug("VehicleTariff Controller CustomerCategoryId:" + vehicletariffcustomercategory.CustomerCategoryId);

          sqlParam.Add(new SqlParameter("@Margin", vehicletariffcustomercategory.Margin));

          Logger.Debug("VehicleTariff Controller Margin:" + vehicletariffcustomercategory.Margin);

          //sqlParam.Add(new SqlParameter("@TotalAmount", vehicletariffcustomercategory.TotalAmount));

          sqlParam.Add(new SqlParameter("@UpdatedDate", vehicletariffcustomercategory.UpdatedDate));

          sqlParam.Add(new SqlParameter("@UpdatedBy", vehicletariffcustomercategory.UpdatedBy));

          return sqlParam;

      }

      public DataTable GetVehicleTariffCustomerCategoryDetails(int vehicleTariffId, ref PaginationInfo pager)
      {
          List<SqlParameter> sqlParam = new List<SqlParameter>();

          sqlParam.Add(new SqlParameter("@VehicleTariffId", vehicleTariffId));

          Logger.Debug("VehicleTariff Controller VehicleTariffId:" + vehicleTariffId);

          DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetVehicleTariffCustomerCategoryDetails.ToString(), CommandType.StoredProcedure);

          List<DataRow> drList = new List<DataRow>();

          //return CommonMethods.GetPaginatedTable(dt, ref pager);
          return dt;
      }

      /*public void UpdateVehicleTariffCustomerCategoryDetails(VehicleTariffCustomerCategoryDetailsInfo vehicletariffcustomercategory)
      {
          _sqlHelper.ExecuteNonQuery(SetValuesInVehicleTariffCustomerCategoryDetails(vehicletariffcustomercategory), Storeprocedures.spUpdateVehicleTariffCustomerCategoryDetails.ToString(), CommandType.StoredProcedure);
      }*/

      public void UpdateVehicleTariffCustomerCategoryDetails(List<VehicleTariffCustomerCategoryDetailsInfo> vehicletariffcustomercategories)
      {
          //_sqlHelper.ExecuteNonQuery(SetValuesInVehicleTariffCustomerCategoryDetails(vehicletariffcustomercategory), Storeprocedures.spUpdateVehicleTariffCustomerCategoryDetails.ToString(), CommandType.StoredProcedure);
          foreach (var item in vehicletariffcustomercategories)
          {
              if (item.VehicleTariffCustomerCategoryDetailsId != 0)
              {
                  _sqlHelper.ExecuteNonQuery(SetValuesInVehicleTariffCustomerCategoryDetails(item), Storeprocedures.spUpdateVehicleTariffCustomerCategoryDetails.ToString(), CommandType.StoredProcedure); 
              }
              else
              {
                  if (item.Margin != 0)
                  {
                      item.VehicleTariffCustomerCategoryDetailsId = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInVehicleTariffCustomerCategoryDetails(item), Storeprocedures.spInsertVehicleTariffCustomerCategoryDetails.ToString(), CommandType.StoredProcedure));  
                  }
              }
          }
      }

      public void DeleteVehicleTariffCustomerCategoryDetails(int vehicletariffcustomercategorydetailsid, int vehicletariffid)
      {
          List<SqlParameter> sqlParam = new List<SqlParameter>();

          sqlParam.Add(new SqlParameter("@VehicleTariffCustomerCategoryDetailsId", vehicletariffcustomercategorydetailsid));

          Logger.Debug("VehicleTariff Controller VehicleTariffCustomerCategoryDetailsId:" + vehicletariffcustomercategorydetailsid);

          sqlParam.Add(new SqlParameter("@VehicleTariffId", vehicletariffid));

          Logger.Debug("VehicleTariff Controller VehicleTariffId:" + vehicletariffid);

          _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteVehicleTariffCustomerCategoryDetails.ToString(), CommandType.StoredProcedure);

      }

      #endregion

    }
}
