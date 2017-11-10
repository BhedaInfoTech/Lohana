using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.SqlClient;
using System.Data;
using LohanaBusinessEntities;
using LohanaRepo.Utilities;
using LohanaBusinessEntities.Facility;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.FacilityType;
using LohanaBusinessLogic.Utilities;
using LohanaHelper.Logging;

namespace LohanaRepo.Master
{
    public class FacilityRepo
    {

        SQLHelperRepo _sqlHelper = null;

        public FacilityRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        public int Insert(FacilityInfo facility)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInFacility(facility), Storeprocedures.spInsertFacility.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInFacility(FacilityInfo facility)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (facility.FacilityId != 0)
            {
                sqlParam.Add(new SqlParameter("FacilityId", facility.FacilityId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", facility.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", facility.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("FacilityTypeId", facility.FacilityTypeId));

            Logger.Debug("Facility Controller FacilityTypeId:" + facility.FacilityTypeId);

            sqlParam.Add(new SqlParameter("FacilityName", facility.FacilityName));

            Logger.Debug("Facility Controller FacilityName:" + facility.FacilityName);

            sqlParam.Add(new SqlParameter("IsActive", facility.IsActive));

            Logger.Debug("Facility Controller IsActive:" + facility.IsActive);

            sqlParam.Add(new SqlParameter("UpdatedBy", facility.UpdatedBy));

            sqlParam.Add(new SqlParameter("UpdatedDate", facility.UpdatedDate));

            return sqlParam;
        }

        public DataTable GetFacilities(int facilitytypeId, string facilityName,ref PaginationInfo pager)
        {
        
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@FacilityTypeId", facilitytypeId));

            sqlParam.Add(new SqlParameter("@FacilityName", facilityName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetFacilities.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }

        private FacilityInfo GetFacilitiesValues(DataRow dr)
        {

            FacilityInfo Facility = new FacilityInfo();

            Facility.FacilityId = Convert.ToInt32(dr["FacilityId"]);

            if (!dr.IsNull("FacilityTypeId"))
                Facility.FacilityTypeId = Convert.ToInt32(dr["FacilityTypeId"]);

            if (!dr.IsNull("FacilityTypeName"))
                Facility.FacilityTypeName = Convert.ToString(dr["FacilityTypeName"]);

            if (!dr.IsNull("FacilityName"))
                Facility.FacilityName = Convert.ToString(dr["FacilityName"]);

            if (!dr.IsNull("IsActive"))
            {
                Facility.IsActive = Convert.ToBoolean(dr["IsActive"]);
            }

            return Facility;

        }

        public void Update(FacilityInfo facility)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInFacility(facility), Storeprocedures.spUpdateFacility.ToString(), CommandType.StoredProcedure);
        }

        public bool CheckFacilityNameExist(string facilityName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@FacilityName", facilityName));

            Logger.Debug("Facility Controller FacilityName:" + facilityName);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckFacilityNameExist.ToString(), CommandType.StoredProcedure));

        }

        public List<FacilityTypeInfo> drpGetFacilityTypes()
        {
            List<FacilityTypeInfo> facilitytypes = new List<FacilityTypeInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetFacilityTypes.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    facilitytypes.Add(GetFacilityTypeValues(dr));
                }
            }
            return facilitytypes;
        }

        public FacilityTypeInfo GetFacilityTypeValues(DataRow dr)
        {
            FacilityTypeInfo retVal = new FacilityTypeInfo();

            retVal.FacilityTypeId = Convert.ToInt32(dr["FacilityTypeId"]);

            retVal.FacilityTypeName = Convert.ToString(dr["FacilityTypeName"]);

            return retVal;
        }

    }
}
