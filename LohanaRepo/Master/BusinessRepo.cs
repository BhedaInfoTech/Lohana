using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using LohanaBusinessEntities.Business;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities;
using LohanaRepo.Utilities;
using LohanaBusinessLogic.Utilities;
using LohanaHelper.Logging;

namespace LohanaRepo.Master
{
    public class BusinessRepo
    {

            SQLHelperRepo _sqlHelper = null;

        public BusinessRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        public int Insert(BusinessInfo business)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInBusiness(business), Storeprocedures.spInsertBusiness.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInBusiness(BusinessInfo business)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();
                        
            if (business.BusinessId != "")
            {
                sqlParam.Add(new SqlParameter("BusinessId", business.BusinessId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", business.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", business.CreatedBy));
            }                       
            
            sqlParam.Add(new SqlParameter("BusinessName", business.BusinessName));

            Logger.Debug("Business Controller BusinessName:" + business.BusinessName);

            sqlParam.Add(new SqlParameter("IsActive", business.IsActive));

            Logger.Debug("Business Controller IsActive:" + business.IsActive);

            sqlParam.Add(new SqlParameter("UpdatedBy", business.UpdatedBy));

            sqlParam.Add(new SqlParameter("UpdatedDate", business.UpdatedDate));
            
            return sqlParam;
        }

        public DataTable GetBusinesses(string businessName,ref PaginationInfo pager)
        {
           
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@BusinessName", businessName));           

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetBusinesses.ToString(), CommandType.StoredProcedure);          

            return CommonMethods.GetPaginatedTable(dt,ref pager);

        }

        public void Update(BusinessInfo business)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInBusiness(business), Storeprocedures.spUpdateBusiness.ToString(), CommandType.StoredProcedure);
        }
     
        public bool CheckBusinessNameExist(string businessName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@BusinessName", businessName));

            Logger.Debug("Business Controller BusinessName:" + businessName);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckBusinessNameExist.ToString(), CommandType.StoredProcedure));

        }


    }
}
