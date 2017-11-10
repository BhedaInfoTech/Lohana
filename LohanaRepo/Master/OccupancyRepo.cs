using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using LohanaBusinessEntities.Occupancy;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities;
using LohanaRepo.Utilities;
using LohanaBusinessLogic.Utilities;
using LohanaHelper.Logging;

namespace LohanaRepo.Master
{
    public class OccupancyRepo
    {

        SQLHelperRepo _sqlHelper = null;

        public OccupancyRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        public int Insert(OccupancyInfo occupancy)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInOccupancy(occupancy), Storeprocedures.spInsertOccupancy.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInOccupancy(OccupancyInfo occupancy)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (occupancy.OccupancyId != 0)
            {
                sqlParam.Add(new SqlParameter("OccupancyId", occupancy.OccupancyId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", occupancy.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", occupancy.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("OccupancyName", occupancy.OccupancyName));

            Logger.Debug("Occupancy Controller OccupancyName:" + occupancy.OccupancyName);

            sqlParam.Add(new SqlParameter("OccupancyValue", occupancy.OccupancyValue));

            Logger.Debug("Occupancy Controller OccupancyValue:" + occupancy.OccupancyValue);

            sqlParam.Add(new SqlParameter("OccupancyType", occupancy.OccupancyType));

            Logger.Debug("Occupancy Controller Occupancytype:" + occupancy.OccupancyType);

            sqlParam.Add(new SqlParameter("IsActive", occupancy.IsActive));

            Logger.Debug("Occupancy Controller IsActive:" + occupancy.IsActive);

            sqlParam.Add(new SqlParameter("UpdatedBy", occupancy.UpdatedBy));

            sqlParam.Add(new SqlParameter("UpdatedDate", occupancy.UpdatedDate));

            return sqlParam;
        }

        public DataTable GetOccupancies(string occupancyName, int occupancyValue, int occupancytype, ref PaginationInfo pager)
        {
            
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@OccupancyName", occupancyName));

            sqlParam.Add(new SqlParameter("@OccupancyValue", occupancyValue));

            sqlParam.Add(new SqlParameter("@OccupancyType", occupancytype));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetOccupancies.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }

        private OccupancyInfo GetOccupanciesValues(DataRow dr)
        {

            OccupancyInfo Occupancy = new OccupancyInfo();

            Occupancy.OccupancyId = Convert.ToInt32(dr["OccupancyId"]);

            if (!dr.IsNull("OccupancyName"))
                Occupancy.OccupancyName = Convert.ToString(dr["OccupancyName"]);

            if (!dr.IsNull("OccupancyValue"))
                Occupancy.OccupancyValue = Convert.ToInt32(dr["OccupancyValue"]);

            if (!dr.IsNull("OccupancyType"))
                Occupancy.OccupancyType = Convert.ToInt32(dr["OccupancyType"]);

            if (!dr.IsNull("IsActive"))
                Occupancy.IsActive = Convert.ToBoolean(dr["IsActive"]);

            return Occupancy;

        }

        public void Update(OccupancyInfo occupancy)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInOccupancy(occupancy), Storeprocedures.spUpdateOccupancy.ToString(), CommandType.StoredProcedure);
        }

        public bool CheckOccupancyNameExist(string occupancyName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@OccupancyName", occupancyName));

            Logger.Debug("Occupancy Controller OccupancyName:" + occupancyName);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckOccupancyNameExist.ToString(), CommandType.StoredProcedure));

        }


    }
}
