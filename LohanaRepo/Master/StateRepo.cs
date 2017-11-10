using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using LohanaBusinessEntities;
using LohanaRepo.Utilities;
using LohanaBusinessEntities.State;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Country;
using LohanaBusinessLogic.Utilities;
using LohanaHelper.Logging;


namespace LohanaRepo.Master
{
    public class StateRepo
    {

        SQLHelperRepo _sqlHelper = null;

        public StateRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        public int Insert(StateInfo state)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInState(state), Storeprocedures.spInsertState.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInState(StateInfo state)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (state.StateId != 0)
            {
                sqlParam.Add(new SqlParameter("StateId", state.StateId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", state.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", state.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("CountryId", state.CountryId));

            Logger.Debug("State Controller CountryId:" +state.CountryId);

            sqlParam.Add(new SqlParameter("StateCode", state.StateCode));

            Logger.Debug("State Controller StateCode:" + state.StateCode);

            sqlParam.Add(new SqlParameter("StateName", state.StateName));

            Logger.Debug("State Controller StateName:" + state.StateName);

            sqlParam.Add(new SqlParameter("IsActive", state.IsActive));

            Logger.Debug("State Controller IsActive:" + state.IsActive);

            sqlParam.Add(new SqlParameter("UpdatedBy", state.UpdatedBy));

            sqlParam.Add(new SqlParameter("UpdatedDate", state.UpdatedDate));

            return sqlParam;
        }

        public DataTable GetStates(int countryId, string stateCode,string stateName, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@CountryId", countryId));

            sqlParam.Add(new SqlParameter("@StateCode", stateCode));

            sqlParam.Add(new SqlParameter("@StateName", stateName));                    

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetStates.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void Update(StateInfo state)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInState(state), Storeprocedures.spUpdateState.ToString(), CommandType.StoredProcedure);
        }

        public bool CheckStateCodeExist(string stateCode)
        {
            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@StateCode", stateCode));

            Logger.Debug("State Controller StateCode:" + stateCode);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckStateCodeExist.ToString(), CommandType.StoredProcedure));

        }

        public bool CheckStateNameExist(string stateName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@StateName", stateName));

            Logger.Debug("State Controller StateName:" + stateName);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckStateNameExist.ToString(), CommandType.StoredProcedure));

        }

        public List<CountryInfo> drpGetCountries()
        {
            List<CountryInfo> countries = new List<CountryInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetCountries.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    countries.Add(GetCountryValues(dr));
                }
            }
            return countries;
        }

        public CountryInfo GetCountryValues(DataRow dr)
        {
            CountryInfo retVal = new CountryInfo();

            retVal.CountryId = Convert.ToInt32(dr["CountryId"]);

            retVal.CountryName = Convert.ToString(dr["CountryName"]);

            return retVal;
        }

    }
}
