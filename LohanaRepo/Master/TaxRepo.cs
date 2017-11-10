using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Tax;
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
    public class TaxRepo
    {
        SQLHelperRepo _sqlHelper = null;

        public TaxRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        public int Insert(TaxInfo tax)
        {
          return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInTax(tax), Storeprocedures.spInsertTax.ToString(), CommandType.StoredProcedure));          
        
        }

        public List<SqlParameter> SetValuesInTax(TaxInfo tax)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (tax.TaxId != 0)
            {
                sqlParam.Add(new SqlParameter("@TaxId", tax.TaxId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedDate", tax.CreatedDate));

                sqlParam.Add(new SqlParameter("@CreatedBy", tax.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@TaxName", tax.TaxName));

            Logger.Debug("Tax Controller TaxName:" + tax.TaxName);

            sqlParam.Add(new SqlParameter("@TaxCode", tax.TaxCode));

            Logger.Debug("Tax Controller TaxCode:" + tax.TaxCode);

            sqlParam.Add(new SqlParameter("@TaxRate", tax.TaxRate));

            Logger.Debug("Tax Controller TaxName:" + tax.TaxRate);

            sqlParam.Add(new SqlParameter("@IsActive", tax.IsActive));

            Logger.Debug("Tax Controller TaxName:" + tax.IsActive);

            sqlParam.Add(new SqlParameter("@UpdatedBy", tax.UpdatedBy));

            sqlParam.Add(new SqlParameter("@UpdatedDate", tax.UpdatedDate));

            return sqlParam;
        }

        public DataTable GetTaxes(string taxName, bool isActive, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();       

            sqlParam.Add(new SqlParameter("@TaxName", taxName));

            sqlParam.Add(new SqlParameter("@IsActive", isActive));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetTaxes.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }      

        private TaxInfo GetTaxValues(DataRow dr)
        {

            TaxInfo Tax = new TaxInfo();

            Tax.TaxId = Convert.ToInt32(dr["TaxId"]);

            if (!dr.IsNull("TaxName"))
                Tax.TaxName = Convert.ToString(dr["TaxName"]);

            if (!dr.IsNull("TaxCode"))
                Tax.TaxCode = Convert.ToString(dr["TaxCode"]);

            if (!dr.IsNull("TaxRate"))
                Tax.TaxRate = Convert.ToDecimal(dr["TaxRate"]);

            if (!dr.IsNull("IsActive"))
                Tax.IsActive = Convert.ToBoolean(dr["IsActive"]);

            return Tax;

        }

        public TaxInfo GetTaxById(int taxid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            TaxInfo Tax = new TaxInfo();

            sqlParam.Add(new SqlParameter("@TaxId", taxid));

            Logger.Debug("Tax Controller TaxId:" + taxid);

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetTaxById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Tax = GetTaxValues(dr);
                }
            }
            return Tax;
        }

        public void Update(TaxInfo tax)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInTax(tax), Storeprocedures.spUpdateTax.ToString(), CommandType.StoredProcedure);
        }

        public bool CheckTaxNameExist(string taxName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@TaxName", taxName));

            Logger.Debug("Tax Controller TaxName:" + taxName);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckTaxNameExist.ToString(), CommandType.StoredProcedure));

        }

        public bool CheckTaxCodeExist(string taxCode)
        {
            bool Check = false;

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@TaxCode", taxCode));

            Logger.Debug("Tax Controller TaxCode:" + taxCode);

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spCheckTaxCodeExist.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = dt.Rows.Count;

                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    Check = Convert.ToBoolean(dr["taxCodeCount"]);
                }
            }

            return Check;
        }
    }
}
