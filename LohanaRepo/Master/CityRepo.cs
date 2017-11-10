using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using LohanaBusinessEntities;
using LohanaRepo.Utilities;
using LohanaBusinessEntities.City;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Country;
using LohanaBusinessEntities.State;
using LohanaBusinessLogic.Utilities;
using LohanaHelper.Logging;



namespace LohanaRepo.Master
{
    public class CityRepo
    {

        SQLHelperRepo _sqlHelper = null;

        public CityRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        public int Insert(CityInfo city)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInCity(city), Storeprocedures.spInsertCity.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInCity(CityInfo city)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (city.CityId != 0)
            {
                sqlParam.Add(new SqlParameter("CityId", city.CityId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", city.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", city.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("CountryId", city.CountryId));

            Logger.Debug("City Controller setCountryId:" + city.CountryId);

            sqlParam.Add(new SqlParameter("StateId", city.StateId));

            Logger.Debug("City Controller SetStateId:" + city.StateId);

            sqlParam.Add(new SqlParameter("CityCode", city.CityCode));

            Logger.Debug("City Controller CityCode:" + city.CityCode);

            sqlParam.Add(new SqlParameter("CityName", city.CityName));

            Logger.Debug("City Controller CityName:" + city.CityName);

            sqlParam.Add(new SqlParameter("IsActive", city.IsActive));

            Logger.Debug("City Controller IsActive:" + city.IsActive);

            sqlParam.Add(new SqlParameter("UpdatedBy", city.UpdatedBy));

            sqlParam.Add(new SqlParameter("UpdatedDate", city.UpdatedDate));

            return sqlParam;
        }

        public DataTable GetCities(int countryId, int stateId, string cityCode, string cityName, ref PaginationInfo pager)
      
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@CountryId", countryId));            

            sqlParam.Add(new SqlParameter("@StateId", stateId));

            sqlParam.Add(new SqlParameter("@CityCode", cityCode));

            sqlParam.Add(new SqlParameter("@CityName", cityName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetCities.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);         

        }

        private CityInfo GetCitiesValues(DataRow dr)
        {

            CityInfo City = new CityInfo();

            City.CityId = Convert.ToInt32(dr["CityId"]);

            if (!dr.IsNull("CountryId"))
                City.CountryId = Convert.ToInt32(dr["CountryId"]);

            if (!dr.IsNull("CountryName"))
                City.CountryName = Convert.ToString(dr["CountryName"]);

            if (!dr.IsNull("StateId"))
                City.StateId = Convert.ToInt32(dr["StateId"]);

            if (!dr.IsNull("StateName"))
                City.StateName = Convert.ToString(dr["StateName"]);
            
            if (!dr.IsNull("CityCode"))
                City.CityCode = Convert.ToString(dr["CityCode"]);

            if (!dr.IsNull("CityName"))
                City.CityName = Convert.ToString(dr["CityName"]);
            
            if (!dr.IsNull("IsActive"))
                City.IsActive = Convert.ToBoolean(dr["IsActive"]);


            return City;

        }

        public void Update(CityInfo city)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInCity(city), Storeprocedures.spUpdateCity.ToString(), CommandType.StoredProcedure);
        }

        public bool CheckCityCodeExist(string cityCode)
        {
            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@CityCode", cityCode));

            Logger.Debug("City Controller Check CityCode:" + cityCode);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckCityCodeExist.ToString(), CommandType.StoredProcedure));

        }

        public bool CheckCityNameExist(string cityName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@CityName", cityName));

            Logger.Debug("City Controller Check CityName:" + cityName);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckCityNameExist.ToString(), CommandType.StoredProcedure));

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

        public List<StateInfo> drpGetstates()
        {
            List<StateInfo> states = new List<StateInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetStates.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    states.Add(GetStateValues(dr));
                }
            }
            return states;
        }

        public StateInfo GetStateValues(DataRow dr)
        {
            StateInfo retVal = new StateInfo();

            retVal.StateId = Convert.ToInt32(dr["StateId"]);           

            retVal.StateName = Convert.ToString(dr["StateName"]);

            return retVal;
        }

        public List<StateInfo> GetStatesByCountryId(int countryId)
        {
            List<StateInfo> states = new List<StateInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@CountryId", countryId));

            Logger.Debug("City Controller GetStateByCountryId:" +countryId);

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spGetStatesByCountryId.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    states.Add(GetStateValues(dr));
                }
            }
            return states;
        }
       

    }
}
