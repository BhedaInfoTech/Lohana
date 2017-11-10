using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using LohanaBusinessEntities.Designation;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities;
using LohanaRepo.Utilities;
using LohanaBusinessLogic.Utilities;
using LohanaHelper.Logging;

namespace LohanaRepo.Master
{
    public class DesignationRepo
    {

        SQLHelperRepo _sqlHelper = null;

        public DesignationRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        public int Insert(DesignationInfo designation)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInDesignation(designation), Storeprocedures.spInsertDesignation.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInDesignation(DesignationInfo designation)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (designation.DesignationId != 0)
            {
                sqlParam.Add(new SqlParameter("DesignationId", designation.DesignationId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", designation.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", designation.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("DesignationName", designation.DesignationName));

            Logger.Debug("Designation Controller DesignationName:" + designation.DesignationName);

            sqlParam.Add(new SqlParameter("IsActive", designation.IsActive));

            Logger.Debug("Designation Controller IsActive:" + designation.IsActive);

            sqlParam.Add(new SqlParameter("UpdatedBy", designation.UpdatedBy));

            sqlParam.Add(new SqlParameter("UpdatedDate", designation.UpdatedDate));

            return sqlParam;
        }

        public DataTable GetDesignations(string designationName,ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@DesignationName", designationName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetDesignations.ToString(), CommandType.StoredProcedure);            
           
            return CommonMethods.GetPaginatedTable(dt,ref pager);

        }

        public void Update(DesignationInfo designation)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInDesignation(designation), Storeprocedures.spUpdateDesignation.ToString(), CommandType.StoredProcedure);
        }    

        public bool CheckDesignationNameExist(string designationName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@DesignationName", designationName));

            Logger.Debug("Designation Controller DesignationName:" + designationName);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckDesignationNameExist.ToString(), CommandType.StoredProcedure));

        }


    }
}
