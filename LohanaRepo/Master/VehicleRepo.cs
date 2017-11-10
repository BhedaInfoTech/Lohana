using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Vehicle;
using LohanaBusinessEntities.VehicleBrand;
using LohanaBusinessEntities.VehicleType;
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

namespace LohanaRepo.Master
{
    public class VehicleRepo
    {
          SQLHelperRepo _sqlHelper = null;

          public VehicleRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

          public int Insert(VehicleInfo vehicle)
          {
              return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInVehicle(vehicle), Storeprocedures.spInsertVehicle.ToString(), CommandType.StoredProcedure));
          }

          public List<SqlParameter> SetValuesInVehicle(VehicleInfo vehicle)
          {

              List<SqlParameter> sqlParam = new List<SqlParameter>();

              if (vehicle.VehicleId != 0)
              {
                  sqlParam.Add(new SqlParameter("@VehicleId", vehicle.VehicleId));
              }
              else
              {
                  sqlParam.Add(new SqlParameter("@CreatedDate", vehicle.CreatedDate));

                  sqlParam.Add(new SqlParameter("@CreatedBy", vehicle.CreatedBy));
              }

              sqlParam.Add(new SqlParameter("@VehicleName", vehicle.VehicleName));

              Logger.Debug("Vehicle Controller VehicleName:" + vehicle.VehicleName);

              sqlParam.Add(new SqlParameter("@SeatCapacity", vehicle.SeatCapacity));

              Logger.Debug("Vehicle Controller SeatCapacity:" + vehicle.SeatCapacity);

              sqlParam.Add(new SqlParameter("@VehicleBrandId", vehicle.VehicleBrandId));

              Logger.Debug("Vehicle Controller VehicleBrandId:" + vehicle.VehicleBrandId);

              sqlParam.Add(new SqlParameter("@VehicleTypeId", vehicle.VehicleTypeId));

              Logger.Debug("Vehicle Controller VehicleTypeId:" + vehicle.VehicleTypeId);

              sqlParam.Add(new SqlParameter("@IsActive", vehicle.IsActive));

              Logger.Debug("Vehicle Controller IsActive:" + vehicle.IsActive);

              sqlParam.Add(new SqlParameter("@UpdatedBy", vehicle.UpdatedBy));

              sqlParam.Add(new SqlParameter("@UpdatedDate", vehicle.UpdatedDate));

              return sqlParam;
          }

          public DataTable GetVehicles(string vehicleName, int vehicleTypeId, int vehicleBrandId, ref PaginationInfo pager)
          {

              List<SqlParameter> sqlParam = new List<SqlParameter>();

              sqlParam.Add(new SqlParameter("@VehicleName", vehicleName));

              sqlParam.Add(new SqlParameter("@VehicleTypeId", vehicleTypeId));

              sqlParam.Add(new SqlParameter("@VehicleBrandId", vehicleBrandId));
                        
              DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetVehicles.ToString(), CommandType.StoredProcedure);

              return CommonMethods.GetPaginatedTable(dt, ref pager);
          }

          private VehicleInfo GetVehicleValues(DataRow dr)
          {

              VehicleInfo Vehicle = new VehicleInfo();

              Vehicle.VehicleId = Convert.ToInt32(dr["VehicleId"]);

              if (!dr.IsNull("VehicleName"))
                  Vehicle.VehicleName = Convert.ToString(dr["VehicleName"]);

              if (!dr.IsNull("SeatCapacity"))
                  Vehicle.SeatCapacity = Convert.ToInt32(dr["SeatCapacity"]);

              if (!dr.IsNull("VehicleTypeId"))
                  Vehicle.VehicleTypeId = Convert.ToInt32(dr["VehicleTypeId"]);

              if (!dr.IsNull("VehicleBrandId"))
                  Vehicle.VehicleBrandId = Convert.ToInt32(dr["VehicleBrandId"]);

              if (!dr.IsNull("IsActive"))
                  Vehicle.IsActive = Convert.ToBoolean(dr["IsActive"]);

              return Vehicle;

          }

          public VehicleInfo GetVehicleById(int vehicleid)
          {
              List<SqlParameter> sqlParam = new List<SqlParameter>();

              VehicleInfo Vehicle = new VehicleInfo();

              sqlParam.Add(new SqlParameter("@VehicleId", vehicleid));

              Logger.Debug("Vehicle Controller VehicleId:" + vehicleid);

              DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetVehicleById.ToString(), CommandType.StoredProcedure);

              if (dt != null && dt.Rows.Count > 0)
              {
                  foreach (DataRow dr in dt.Rows)
                  {
                      Vehicle = GetVehicleValues(dr);
                  }
              }
              return Vehicle;
          }

          public void UpdateVehicle(VehicleInfo vehicle)
          {
              _sqlHelper.ExecuteNonQuery(SetValuesInVehicle(vehicle), Storeprocedures.spUpdateVehicle.ToString(), CommandType.StoredProcedure);
          }

          public bool CheckVehicleNameExist(string vehicleName)
          {

              string ProcedureName = string.Empty;

              List<SqlParameter> sqlParams = new List<SqlParameter>();

              sqlParams.Add(new SqlParameter("@VehicleName", vehicleName));

              Logger.Debug("Vehicle Controller VehicleName:" + vehicleName);

              return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckVehicleNameExist.ToString(), CommandType.StoredProcedure));

          }
        
          public List<VehicleTypeInfo> drpGetVehicleType()
          {
              List<VehicleTypeInfo> vehicletypeid = new List<VehicleTypeInfo>();

              List<SqlParameter> sqlParam = new List<SqlParameter>();

              DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spdrpGetVehicleType.ToString(), CommandType.StoredProcedure);

              if (dt != null && dt.Rows.Count > 0)
              {
                  foreach (DataRow dr in dt.Rows)
                  {
                      vehicletypeid.Add(GetVehicleTypeIdValues(dr));
                  }
              }

              return vehicletypeid;

          }

          public VehicleTypeInfo GetVehicleTypeIdValues(DataRow dr)
          {
              VehicleTypeInfo Val = new VehicleTypeInfo();

              Val.VehicleTypeId = Convert.ToInt32(dr["VehicleTypeId"]);

              Val.VehicleTypeName = Convert.ToString(dr["VehicleTypeName"]);

              return Val;
          }

          public List<VehicleBrandInfo> drpGetVehicleBrand()
          {
              List<VehicleBrandInfo> vehiclebrandid = new List<VehicleBrandInfo>();

              List<SqlParameter> sqlParam = new List<SqlParameter>();

              DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spdrpGetVehicleBrand.ToString(), CommandType.StoredProcedure);

              if (dt != null && dt.Rows.Count > 0)
              {
                  foreach (DataRow dr in dt.Rows)
                  {
                      vehiclebrandid.Add(GetVehicleBrandIdValues(dr));
                  }
              }

              return vehiclebrandid;

          }

          public VehicleBrandInfo GetVehicleBrandIdValues(DataRow dr)
          {
              VehicleBrandInfo Val = new VehicleBrandInfo();

              Val.VehicleBrandId = Convert.ToInt32(dr["VehicleBrandId"]);

              Val.VehicleBrandName = Convert.ToString(dr["VehicleBrandName"]);

              return Val;
          }

    }
}
