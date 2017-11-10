using LohanaBusinessEntities.Common;
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
    public class VehicleTypeRepo
    {
         SQLHelperRepo _sqlHelper = null;

         public VehicleTypeRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

         public int Insert(VehicleTypeInfo vehicleType)
         {
             return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInVehicleType(vehicleType), Storeprocedures.spInsertVehicleType.ToString(), CommandType.StoredProcedure));
         }

         public List<SqlParameter> SetValuesInVehicleType(VehicleTypeInfo vehicleType)
         {

             List<SqlParameter> sqlParam = new List<SqlParameter>();

             if (vehicleType.VehicleTypeId != 0)
             {
                 sqlParam.Add(new SqlParameter("@VehicleTypeId", vehicleType.VehicleTypeId));
             }
             else
             {
                 sqlParam.Add(new SqlParameter("@CreatedDate", vehicleType.CreatedDate));

                 sqlParam.Add(new SqlParameter("@CreatedBy", vehicleType.CreatedBy));
             }

             sqlParam.Add(new SqlParameter("@VehicleTypeName", vehicleType.VehicleTypeName));

             Logger.Debug("VehicleType Controller VehicleTypeName:" + vehicleType.VehicleTypeName);

             sqlParam.Add(new SqlParameter("@IsActive", vehicleType.IsActive));

             Logger.Debug("VehicleType Controller IsActive:" + vehicleType.IsActive);

             sqlParam.Add(new SqlParameter("@UpdatedBy", vehicleType.UpdatedBy));

             sqlParam.Add(new SqlParameter("@UpdatedDate", vehicleType.UpdatedDate));

             return sqlParam;
         }

         public DataTable GetVehicleTypes(string vehicleTypeName, ref PaginationInfo pager)
         {

             List<SqlParameter> sqlParam = new List<SqlParameter>();

             sqlParam.Add(new SqlParameter("@VehicleTypeName", vehicleTypeName));

             Logger.Debug("Vehicle Controller VehicleTypeName:" + vehicleTypeName);

             DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetVehicleTypes.ToString(), CommandType.StoredProcedure);

             return CommonMethods.GetPaginatedTable(dt, ref pager);
         }

         public void Update(VehicleTypeInfo vehicleType)
         {
             _sqlHelper.ExecuteNonQuery(SetValuesInVehicleType(vehicleType), Storeprocedures.spUpdateVehicleType.ToString(), CommandType.StoredProcedure);
         }

         public bool CheckVehicleTypeNameExist(string vehicleTypeName)
         {

             string ProcedureName = string.Empty;

             List<SqlParameter> sqlParams = new List<SqlParameter>();

             sqlParams.Add(new SqlParameter("@VehicleTypeName", vehicleTypeName));

             Logger.Debug("VehicleType Controller VehicleTypeName:" + vehicleTypeName);

             return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckVehicleTypeNameExist.ToString(), CommandType.StoredProcedure));

         }
    }
}
