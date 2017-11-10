using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.CustomerCategory;
using LohanaRepo.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LohanaBusinessEntities;
using LohanaHelper.Logging;


namespace LohanaRepo.Master
{
    public class CustomerCategoryRepo
    {

        SQLHelperRepo _sqlHelper = null;

        public CustomerCategoryRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        public int Insert(CustomerCategoryInfo CustomerCategory)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInCustomerCategory(CustomerCategory), Storeprocedures.spInsertCustomerCategory.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInCustomerCategory(CustomerCategoryInfo customerCategory)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (customerCategory.CustomerCategoryId != 0)
            {
                sqlParam.Add(new SqlParameter("@CustomerCategoryId", customerCategory.CustomerCategoryId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedDate", customerCategory.CreatedDate));

                sqlParam.Add(new SqlParameter("@CreatedBy", customerCategory.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@CustomerCategoryName", customerCategory.CustomerCategoryName));

            Logger.Debug("CustomerCategory Controller CustomerCategoryName:" + customerCategory.CustomerCategoryName);

            sqlParam.Add(new SqlParameter("@Margin", customerCategory.Margin));

            Logger.Debug("CustomerCategory Controller Margin:" + customerCategory.Margin);

            sqlParam.Add(new SqlParameter("@IsActive", customerCategory.IsActive));

            Logger.Debug("CustomerCategory Controller IsActive:" + customerCategory.IsActive);

            sqlParam.Add(new SqlParameter("@UpdatedBy", customerCategory.UpdatedBy));

            sqlParam.Add(new SqlParameter("@UpdatedDate", customerCategory.UpdatedDate));

            return sqlParam;
        }

        public List<CustomerCategoryInfo> GetCustomerCategory(string customerCategoryName, decimal margin)
        {
            List<CustomerCategoryInfo> CustomerCategory = new List<CustomerCategoryInfo>();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@CustomerCategoryName", customerCategoryName));

            sqlParam.Add(new SqlParameter("@Margin", margin));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetCustomerCategory.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                CustomerCategory.Add(GetCustomerCategoryValues(dr));
            }

            return CustomerCategory;

        }

        private CustomerCategoryInfo GetCustomerCategoryValues(DataRow dr)
        {

            CustomerCategoryInfo CustomerCategory = new CustomerCategoryInfo();

            CustomerCategory.CustomerCategoryId = Convert.ToInt32(dr["CustomerCategoryId"]);

            if (!dr.IsNull("CustomerCategoryName"))
                CustomerCategory.CustomerCategoryName = Convert.ToString(dr["CustomerCategoryName"]);

            if (!dr.IsNull("Margin"))
                CustomerCategory.Margin = Convert.ToDecimal(dr["Margin"]);

            if (!dr.IsNull("IsActive"))
                CustomerCategory.IsActive = Convert.ToBoolean(dr["IsActive"]);

            return CustomerCategory;

        }

        public void Update(CustomerCategoryInfo customerCategory)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInCustomerCategory(customerCategory), Storeprocedures.spUpdateCustomerCategory.ToString(), CommandType.StoredProcedure);
        }
                
        public bool CustomerCategoryNameExist(string customerCategoryName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@CustomerCategoryName", customerCategoryName));

            Logger.Debug("CustomerCategory Controller CustomerCategoryName:" + customerCategoryName);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckCustomerCategoryNameExist.ToString(), CommandType.StoredProcedure));

        }
                       
    }
}







