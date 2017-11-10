using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using LohanaBusinessEntities;
using LohanaRepo.Utilities;
using LohanaBusinessEntities.FacilityType;
using LohanaBusinessEntities.Common;
using LohanaBusinessLogic.Utilities;
using LohanaHelper.Logging;

namespace LohanaRepo.Master
{
    public class FacilityTypeRepo
    {

        SQLHelperRepo _sqlHelper = null;

        public FacilityTypeRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        public int Insert(FacilityTypeInfo facilitytype)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInFacilityType(facilitytype), Storeprocedures.spInsertFacilityType.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInFacilityType(FacilityTypeInfo facilitytype)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (facilitytype.FacilityTypeId != 0)
            {
                sqlParam.Add(new SqlParameter("FacilityTypeId", facilitytype.FacilityTypeId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", facilitytype.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", facilitytype.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("FacilityTypeName", facilitytype.FacilityTypeName));

            Logger.Debug("FacilityType Controller FacilityTypeName:" + facilitytype.FacilityTypeName);

            sqlParam.Add(new SqlParameter("@IsActive", facilitytype.IsActive));

            Logger.Debug("FacilityType Controller IsActive:" + facilitytype.IsActive);

            sqlParam.Add(new SqlParameter("UpdatedBy", facilitytype.UpdatedBy));

            sqlParam.Add(new SqlParameter("UpdatedDate", facilitytype.UpdatedDate));

            return sqlParam;
        }

        public DataTable GetFacilityTypes(string facilitytypeName,ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@FacilityTypeName", facilitytypeName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetFacilityTypes.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void Update(FacilityTypeInfo facilitytype)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInFacilityType(facilitytype), Storeprocedures.spUpdateFacilityType.ToString(), CommandType.StoredProcedure);
        }

        public bool CheckFacilityTypeNameExist(string facilitytypeName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@FacilityTypeName", facilitytypeName));

            Logger.Debug("FacilityType Controller FacilityTypeName:" + facilitytypeName);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckFacilityTypeNameExist.ToString(), CommandType.StoredProcedure));

        }


    }
}
