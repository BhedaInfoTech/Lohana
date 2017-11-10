
using LohanaBusinessEntities.Charges;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities;
using LohanaRepo.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using LohanaBusinessLogic.Utilities;
using LohanaHelper.Logging;


namespace LohanaRepo.Master
{
    public class ChargesRepo
    {
        SQLHelperRepo _sqlHelper = null;

        public ChargesRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        public int Insert(ChargesInfo charges)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInCharges(charges), Storeprocedures.spInsertCharges.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInCharges(ChargesInfo charges)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (charges.ChargesId != 0)
            {
                sqlParam.Add(new SqlParameter("ChargesId", charges.ChargesId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", charges.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", charges.CreatedBy));
            }
            sqlParam.Add(new SqlParameter("ChargesName", charges.ChargesName));
            Logger.Debug("Charges Controller ChargesName:" +charges.ChargesName);

            sqlParam.Add(new SqlParameter("Abbreviation", charges.Abbreviation));
            Logger.Debug("Charges Controller Abbreviation:" + charges.Abbreviation);

            sqlParam.Add(new SqlParameter("ChargesBehaviour", charges.ChargesBehaviour));
            Logger.Debug("Charges Controller ChargesBehaviour:" + charges.ChargesBehaviour);
            
            sqlParam.Add(new SqlParameter("IsActive", charges.IsActive));
            Logger.Debug("Charges Controller IsActive:" + charges.IsActive);

            sqlParam.Add(new SqlParameter("UpdatedBy", charges.UpdatedBy));

            sqlParam.Add(new SqlParameter("UpdatedDate", charges.UpdatedDate));

            return sqlParam;
        }   

        public DataTable GetCharges(string chargesName, string abbreviation, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@ChargesName",chargesName));
                      
            sqlParam.Add(new SqlParameter("@Abbreviation", abbreviation));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetCharges.ToString(), CommandType.StoredProcedure);
            
            return CommonMethods.GetPaginatedTable(dt,ref pager);

        }

        public void Update(ChargesInfo charges)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInCharges(charges), Storeprocedures.spUpdateCharges.ToString(), CommandType.StoredProcedure);
        }

        public bool CheckChargesNameExist(string chargesName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@ChargesName", chargesName));

            Logger.Debug("Charges Controller ChargesName:" + chargesName);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckChargesNameExist.ToString(), CommandType.StoredProcedure));

        }

        public bool CheckChargesAbbrevationExist(string chargesabbr)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Abbreviation", chargesabbr));

            Logger.Debug("Charges Controller Abbreviation:" + chargesabbr);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckChargesAbbrevationExist.ToString(), CommandType.StoredProcedure));

        }

        public List<ChargesInfo> GetStandardCharges()
        {
            List<ChargesInfo> chargesInfo = new List<ChargesInfo>();

            DataTable dt = _sqlHelper.ExecuteDataTable(null, Storeprocedures.spGetStandardCharges.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                chargesInfo.Add(SetStandardCharges(dr));
            }

            return chargesInfo;
        }

        private ChargesInfo SetStandardCharges(DataRow dr)
        {
            ChargesInfo chargesInfo = new ChargesInfo();

            if (dr["ChargesId"] != DBNull.Value)
            {
                chargesInfo.ChargesId = Convert.ToInt32(dr["ChargesId"]);
            }

            if (dr["Abbreviation"] != DBNull.Value)
            {
                chargesInfo.Abbreviation = Convert.ToString(dr["Abbreviation"]);
            }

            return chargesInfo;
        }

        public ChargesInfo GetChargesById(int chargesId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            ChargesInfo Charges = new ChargesInfo();

            sqlParam.Add(new SqlParameter("@ChargesId", chargesId));

            Logger.Debug("Charges Controller ChargesId:" + chargesId);

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetChargesById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Charges = GetChargesValues(dr);
                }
            }

            return Charges;
        }

        private ChargesInfo GetChargesValues(DataRow dr)

        {
            ChargesInfo Charges = new ChargesInfo();

            Charges.ChargesId = Convert.ToInt32(dr["ChargesId"]);

            if (!dr.IsNull("ChargesName"))
                Charges.ChargesName = Convert.ToString(dr["ChargesName"]);

            if (!dr.IsNull("Abbreviation"))
                Charges.Abbreviation = Convert.ToString(dr["Abbreviation"]);

            if (!dr.IsNull("IsActive"))
                Charges.IsActive = Convert.ToBoolean(dr["IsActive"]);

            if (!dr.IsNull("IsStandardPrice"))
                Charges.IsStandardPrice = Convert.ToBoolean(dr["IsStandardPrice"]);

            return Charges;

        }
    }
}
