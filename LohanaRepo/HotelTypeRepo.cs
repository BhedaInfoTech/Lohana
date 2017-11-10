using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Country;
using LohanaBusinessEntities.HotelTypeInfo;
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

namespace LohanaRepo
{
    public class HotelTypeRepo
    {

        SQLHelperRepo _sqlHelper = null;

        public HotelTypeRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        public int Insert(HotelTypeInfo HotelType)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInHotelType(HotelType), Storeprocedures.spInsertHotelType.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInHotelType(HotelTypeInfo HotelType)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (HotelType.HotelTypeId != 0)
            {
                sqlParam.Add(new SqlParameter("HotelTypeId", HotelType.HotelTypeId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", HotelType.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", HotelType.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("HotelType", HotelType.HotelType));

            Logger.Debug("HotelType Controller HotelType:" + HotelType.HotelType);



            sqlParam.Add(new SqlParameter("@IsActive", HotelType.IsActive));

            Logger.Debug("HotelType Controller IsActive:" + HotelType.IsActive);

            sqlParam.Add(new SqlParameter("UpdatedBy", HotelType.UpdatedBy));

            sqlParam.Add(new SqlParameter("UpdatedDate", HotelType.UpdatedDate));

            return sqlParam;
        }

        public DataTable GetHotelType(string HotelType, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@HotelType", HotelType));

           

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetHotelType.ToString(), CommandType.StoredProcedure);

			return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void Update(HotelTypeInfo HotelType)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInHotelType(HotelType), Storeprocedures.spUpdateHotelType.ToString(), CommandType.StoredProcedure);
        }

        public bool CheckHotelTypeExist(string HotelType)
        {
            bool Check = false;

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@HotelType", HotelType));

            Logger.Debug("HotelType Controller HotelType:" + HotelType);

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spCheckHotelTypeExist.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
               int count = dt.Rows.Count;

               List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                   Check = Convert.ToBoolean(dr["HotelTypeCount"]);
               }
            }

            return Check;
        }



        public DataTable dt { get; set; }
    }

    
}
