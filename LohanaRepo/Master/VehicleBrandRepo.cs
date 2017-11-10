using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.VehicleBrand;
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
    public class VehicleBrandRepo
    {
         SQLHelperRepo _sqlHelper = null;

         public VehicleBrandRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

         public int Insert(VehicleBrandInfo vehicleBrand)
         {
             return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInVehicleBrand(vehicleBrand), Storeprocedures.spInsertVehicleBrand.ToString(), CommandType.StoredProcedure));
         }

         public List<SqlParameter> SetValuesInVehicleBrand(VehicleBrandInfo vehicleBrand)
         {

             List<SqlParameter> sqlParam = new List<SqlParameter>();

             if (vehicleBrand.VehicleBrandId != 0)
             {
                 sqlParam.Add(new SqlParameter("@VehicleBrandId", vehicleBrand.VehicleBrandId));
             }
             else
             {
                 sqlParam.Add(new SqlParameter("@CreatedDate", vehicleBrand.CreatedDate));

                 sqlParam.Add(new SqlParameter("@CreatedBy", vehicleBrand.CreatedBy));
             }

             sqlParam.Add(new SqlParameter("@VehicleBrandName", vehicleBrand.VehicleBrandName));

             Logger.Debug("VehicleBrand Controller VehicleBrandName:" + vehicleBrand.VehicleBrandName);

             sqlParam.Add(new SqlParameter("@IsActive", vehicleBrand.IsActive));

             Logger.Debug("VehicleBrand Controller IsActive:" + vehicleBrand.IsActive);

             sqlParam.Add(new SqlParameter("@UpdatedBy", vehicleBrand.UpdatedBy));

             sqlParam.Add(new SqlParameter("@UpdatedDate", vehicleBrand.UpdatedDate));

             return sqlParam;
         }

         public DataTable GetVehicleBrands(string vehicleBrandName, ref PaginationInfo pager)
         {

             List<SqlParameter> sqlParam = new List<SqlParameter>();

             sqlParam.Add(new SqlParameter("@VehicleBrandName", vehicleBrandName));

             DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetVehicleBrands.ToString(), CommandType.StoredProcedure);

             return CommonMethods.GetPaginatedTable(dt, ref pager);
         }

         public void Update(VehicleBrandInfo vehicleBrand)
         {
             _sqlHelper.ExecuteNonQuery(SetValuesInVehicleBrand(vehicleBrand), Storeprocedures.spUpdateVehicleBrand.ToString(), CommandType.StoredProcedure);
         }

         public bool CheckVehicleBrandNameExist(string vehicleBrandName)
         {

             string ProcedureName = string.Empty;

             List<SqlParameter> sqlParams = new List<SqlParameter>();

             sqlParams.Add(new SqlParameter("@VehicleBrandName", vehicleBrandName));

             Logger.Debug("VehicleBrand Controller VehicleBrandName:" + vehicleBrandName);

             return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckVehicleBrandNameExist.ToString(), CommandType.StoredProcedure));

         }
    }
}
