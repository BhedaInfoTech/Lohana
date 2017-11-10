using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.TaxFormula;
using LohanaBusinessEntities.Charges;
using LohanaRepo.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LohanaBusinessLogic.Utilities;
using LohanaHelper.Logging;
using LohanaBusinessEntities.HotelTariff;

namespace LohanaRepo.Master
{
    public class TaxFormulaRepo
    {
        SQLHelperRepo _sqlHelper = null;

        public TaxFormulaRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        public List<ChargesInfo> drpGetCharges()
        {
            List<ChargesInfo> charges = new List<ChargesInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetChargeType.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    charges.Add(GetChargeTypeValues(dr));
                }
            }
            return charges;
        }

        public ChargesInfo GetChargeTypeValues(DataRow dr)
        {
            ChargesInfo retVal = new ChargesInfo();

            retVal.ChargesId = Convert.ToInt32(dr["ChargesId"]);

            retVal.ChargesName = Convert.ToString(dr["ChargesName"]);

            if (dr["IsStandardPrice"] != DBNull.Value)
            {
                retVal.IsStandardPrice = Convert.ToBoolean(dr["IsStandardPrice"]);
            }            

            return retVal;
        }

        // Fill drop-down Tax Formula
        public List<TaxFormulaInfo> drpGetTaxFormula()
        {
            List<TaxFormulaInfo> taxFormula = new List<TaxFormulaInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetTaxFormula.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    taxFormula.Add(GetTaxFormulaDDLValues(dr));
                }
            }
            return taxFormula;
        }

        public TaxFormulaInfo GetTaxFormulaDDLValues(DataRow dr)
        {
            TaxFormulaInfo retVal = new TaxFormulaInfo();

            retVal.TaxFormulaId = Convert.ToInt32(dr["TaxFormulaId"]);

            retVal.TaxFormulaName = Convert.ToString(dr["TaxFormulaName"]);

            return retVal;
        }

        #region Tax Formula

        public int InsertTaxFormula(TaxFormulaInfo taxformula)
        {
            int taxFormulaId = 0;

            taxFormulaId = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInTaxFormula(taxformula), Storeprocedures.spInsertTaxFormula.ToString(), CommandType.StoredProcedure));

            foreach (var item in taxformula.TaxFormulaCharges)
            {
                InsertTaxFormulaCharge(item, taxFormulaId);
            }

            return taxFormulaId;

        }

        public void UpdateTaxFormula(TaxFormulaInfo taxformula)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInTaxFormula(taxformula), Storeprocedures.spUpdateTaxFormula.ToString(), CommandType.StoredProcedure);

            foreach (var item in taxformula.TaxFormulaCharges)
            {
                InsertTaxFormulaCharge(item, taxformula.TaxFormulaId);
            }
        }

        private List<SqlParameter> SetValuesInTaxFormula(TaxFormulaInfo taxformula)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (taxformula.TaxFormulaId != 0)
            {

                sqlParams.Add(new SqlParameter("@TaxFormulaId", taxformula.TaxFormulaId));
            }
            else
            {
                sqlParams.Add(new SqlParameter("CreatedDate", taxformula.CreatedDate));

                sqlParams.Add(new SqlParameter("CreatedBy", taxformula.CreatedBy));
            }

            sqlParams.Add(new SqlParameter("@TaxFormulaName", taxformula.TaxFormulaName));

            Logger.Debug("TaxFormula Controller TaxFormulaName:" + taxformula.TaxFormulaName);

            sqlParams.Add(new SqlParameter("@IsActive", taxformula.IsActive));

            Logger.Debug("TaxFormula Controller IsActive:" + taxformula.IsActive);

            sqlParams.Add(new SqlParameter("@UpdatedDate", taxformula.UpdatedDate));

            sqlParams.Add(new SqlParameter("@UpdatedBy", taxformula.UpdatedBy));

            return sqlParams;
        }

        public DataTable GetTaxFormula(string taxFormulaName, ref PaginationInfo pager)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@TaxFormulaName", taxFormulaName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetTaxFormula.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public bool CheckTaxFormulaNameExist(string taxFormulaName, int taxFormulaId)
        {
            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@TaxFormulaName", taxFormulaName));

            Logger.Debug("TaxFormula Controller TaxFormulaName:" + taxFormulaName);

            sqlParams.Add(new SqlParameter("@TaxFormulaId", taxFormulaId));

            Logger.Debug("TaxFormula Controller TaxFormulaId:" + taxFormulaId);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckTaxFormulaExist.ToString(), CommandType.StoredProcedure));
        }

        public TaxFormulaInfo GetTaxFormulaById(int taxFormulaId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            TaxFormulaInfo taxFormula = new TaxFormulaInfo();

            sqlParam.Add(new SqlParameter("@TaxFormulaId", taxFormulaId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetTaxFormulaById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    taxFormula = GetTaxFormulaValues(dr);
                }
            }
            return taxFormula;
        }

        private TaxFormulaInfo GetTaxFormulaValues(DataRow dr)
        {
            TaxFormulaInfo taxFormula = new TaxFormulaInfo();

            taxFormula.TaxFormulaId = Convert.ToInt32(dr["TaxFormulaId"]);

            if (!dr.IsNull("TaxFormulaName"))
            {
                taxFormula.TaxFormulaName = Convert.ToString(dr["TaxFormulaName"]);
            }

            if (!dr.IsNull("IsActive"))
            {
                taxFormula.IsActive = Convert.ToBoolean(dr["IsActive"]);
            }

            return taxFormula;
        }

        public bool CheckTaxFormulaExist(string taxFormulaName)
        {
            bool Check = false;

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@TaxFormulaName", taxFormulaName));

            Logger.Debug("TaxFormula Controller TaxFormulaName:" + taxFormulaName);

            Check = Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckTaxFormulaExist.ToString(), CommandType.StoredProcedure));

            return Check;
        }


        #endregion

        #region Tax Formula Charge

        public int InsertTaxFormulaCharge(TaxFormulaChargesInfo taxformulacharge, int taxFormulaId)
        {
            // Insert into "Tax Formula Charges"
            int rowcount = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInTaxFormulaCharge(taxformulacharge, taxFormulaId), Storeprocedures.spInsertTaxFormulaCharges.ToString(), CommandType.StoredProcedure));

            return rowcount;
        }

        private List<SqlParameter> SetValuesInTaxFormulaCharge(TaxFormulaChargesInfo taxformulacharges, int taxFormulaId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@TaxFormulaId", taxFormulaId));

            Logger.Debug("TaxFormula Controller TaxFormulaId:" + taxFormulaId);

            sqlParams.Add(new SqlParameter("@ChargesId", taxformulacharges.ChargesId));

            Logger.Debug("TaxFormula Controller ChargesId:" + taxformulacharges.ChargesId);

            sqlParams.Add(new SqlParameter("@ChargeFormula", taxformulacharges.ChargeFormula));

            Logger.Debug("TaxFormula Controller ChargesFormula:" + taxformulacharges.ChargeFormula);
            
            sqlParams.Add(new SqlParameter("@OldChargesId", taxformulacharges.OldChargesId));

            Logger.Debug("TaxFormula Controller OldChargesId:" + taxformulacharges.OldChargesId);

            return sqlParams;
        }

        #endregion

        #region Tax Formula Calculated On

        public void InsertTaxFormulaCalculatedOn(TaxFormulaCalculatedOnInfo taxformulacalculatedon, int taxFormulaChargesId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@TaxFormulaChargesId", taxFormulaChargesId));

            Logger.Debug("TaxFormula Controller TaxFormulaChargesId:" + taxFormulaChargesId);

            sqlParams.Add(new SqlParameter("@IsFixPrice", taxformulacalculatedon.IsFixPrice));

            Logger.Debug("TaxFormula Controller IsFixPrice:" + taxformulacalculatedon.IsFixPrice);

            sqlParams.Add(new SqlParameter("@CalculatedOnId", taxformulacalculatedon.CalculatedOnId));

            Logger.Debug("TaxFormula Controller CalculatedOnId:" + taxformulacalculatedon.CalculatedOnId);

            sqlParams.Add(new SqlParameter("@Behaviour", taxformulacalculatedon.Behaviour));

            Logger.Debug("TaxFormula Controller Behaviour:" + taxformulacalculatedon.Behaviour);

            _sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.spInsertTaxFormulaCalculatedOn.ToString(), CommandType.StoredProcedure);

        }

        public List<TaxFormulaChargesInfo> GetTaxFormulaCharges(int taxFormulaId, ref PaginationInfo pager)
        {
            List<TaxFormulaChargesInfo> taxFormulaChargesInfo = new List<TaxFormulaChargesInfo>();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@TaxFormulaId", taxFormulaId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetTaxFormulaCharges.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                taxFormulaChargesInfo.Add(GetTaxFormulaCharges(dr, taxFormulaId));
            }

            return taxFormulaChargesInfo;
        }

        private TaxFormulaChargesInfo GetTaxFormulaCharges(DataRow dr, int taxFormulaId)
        {
            TaxFormulaChargesInfo taxFormulaCharges = new TaxFormulaChargesInfo();

            taxFormulaCharges.TaxFormulaId = taxFormulaId;

            if (dr["ChargesId"] != DBNull.Value)
            {
                taxFormulaCharges.ChargesId = Convert.ToInt32(dr["ChargesId"]);
            }

            if (dr["ChargesName"] != DBNull.Value)
            {
                taxFormulaCharges.ChargesName = Convert.ToString(dr["ChargesName"]);
            }

            if (dr["ChargeFormula"] != DBNull.Value)
            {
                taxFormulaCharges.ChargeFormula = Convert.ToString(dr["ChargeFormula"]);
            }

            if (dr["ChargeFormulaText"] != DBNull.Value)
            {
                taxFormulaCharges.ChargeFormulaText = Convert.ToString(dr["ChargeFormulaText"]);
            }


            return taxFormulaCharges;
        }

        private TaxFormulaCalculatedOnInfo GetTaxFormulaChargeCaculatedOnValues(DataRow dr)
        {
            TaxFormulaCalculatedOnInfo taxformulachargecalcultedon = new TaxFormulaCalculatedOnInfo();

            if (dr["TaxFormulaChargesId"] != DBNull.Value)
            {
                taxformulachargecalcultedon.TaxFormulaChargeId = Convert.ToInt32(dr["TaxFormulaChargesId"]);
            }

            if (dr["ChargesId"] != DBNull.Value)
            {
                taxformulachargecalcultedon.TaxChargesId = Convert.ToInt32(dr["ChargesId"]);
            }

            if (dr["ChargesName"] != DBNull.Value)
            {
                taxformulachargecalcultedon.TaxChargesName = Convert.ToString(dr["ChargesName"]);
            }

            if (dr["IsFixPrice"] != DBNull.Value)
            {
                taxformulachargecalcultedon.IsFixPrice = Convert.ToBoolean(dr["IsFixPrice"]);
            }

            if (dr["CalculatedOnId"] != DBNull.Value)
            {
                taxformulachargecalcultedon.CalculatedOnId = Convert.ToInt32(dr["CalculatedOnId"]);
            }

            List<KeyValueInfo> GetChargesRateTypes = LookupInfo.GetChargesRateTypes();

            if (taxformulachargecalcultedon.CalculatedOnId == 1)
            {
                taxformulachargecalcultedon.CalculatedOnName = GetChargesRateTypes[0].Value;
            }
            if (taxformulachargecalcultedon.CalculatedOnId == 2)
            {
                taxformulachargecalcultedon.CalculatedOnName = GetChargesRateTypes[1].Value;
            }
            if (taxformulachargecalcultedon.CalculatedOnId == 3)
            {
                taxformulachargecalcultedon.CalculatedOnName = GetChargesRateTypes[2].Value;
            }


            if (dr["Behaviour"] != DBNull.Value)
            {
                taxformulachargecalcultedon.Behaviour = Convert.ToString(dr["Behaviour"]);
            }

            return taxformulachargecalcultedon;
        }

        private TaxFormulaCalculatedOnInfo GetTaxFormulaChargeCaculatedOnFormula(DataRow dr)
        {
            TaxFormulaCalculatedOnInfo taxformulacalonbehaviour = new TaxFormulaCalculatedOnInfo();

            if (dr["TaxFormulaChargesId"] != DBNull.Value)
            {
                taxformulacalonbehaviour.TaxFormulaChargeId = Convert.ToInt32(dr["TaxFormulaChargesId"]);
            }

            if (dr["ChargesId"] != DBNull.Value)
            {
                taxformulacalonbehaviour.TaxChargesId = Convert.ToInt32(dr["ChargesId"]);
            }

            if (dr["ChargesName"] != DBNull.Value)
            {
                taxformulacalonbehaviour.TaxChargesName = Convert.ToString(dr["ChargesName"]);
            }

            if (dr["IsFixPrice"] != DBNull.Value)
            {
                taxformulacalonbehaviour.IsFixPrice = Convert.ToBoolean(dr["IsFixPrice"]);
            }

            if (dr["CalculatedOnId"] != DBNull.Value)
            {
                taxformulacalonbehaviour.CalculatedOnId = Convert.ToInt32(dr["CalculatedOnId"]);
            }

            List<KeyValueInfo> GetChargesRateTypes = LookupInfo.GetChargesRateTypes();

            if (taxformulacalonbehaviour.CalculatedOnId == 1)
            {
                taxformulacalonbehaviour.CalculatedOnName = GetChargesRateTypes[0].Value;
            }
            if (taxformulacalonbehaviour.CalculatedOnId == 2)
            {
                taxformulacalonbehaviour.CalculatedOnName = GetChargesRateTypes[1].Value;
            }
            if (taxformulacalonbehaviour.CalculatedOnId == 3)
            {
                taxformulacalonbehaviour.CalculatedOnName = GetChargesRateTypes[2].Value;
            }

            if (dr["Behaviour"] != DBNull.Value)
            {
                taxformulacalonbehaviour.Behaviour = Convert.ToString(dr["Behaviour"]);
            }

            return taxformulacalonbehaviour;
        }

        public TaxFormulaCalculatedOnInfo GetTaxFormulaChargeCaculatedOnFormula(TaxFormulaCalculatedOnInfo tfcoi)
        {
            //TaxFormulaCalculatedOnInfo taxformulacalonbehaviour = new TaxFormulaCalculatedOnInfo();

            tfcoi.TaxFormulaChargeId = tfcoi.TaxFormulaChargeId;

            tfcoi.TaxChargesId = tfcoi.TaxChargesId;

            tfcoi.TaxChargesName = tfcoi.TaxChargesName;

            tfcoi.CalOnBehaviour = tfcoi.CalOnBehaviour;

            return tfcoi;
        }



        #endregion

    }
}







































// 1 feb 2017

//foreach (DataRow dr in dt.Rows)
//{

//    if (Convert.ToString(dr["Behaviour"]) != "0")
//    {
//        taxformulacalonbehaviour.Add(GetTaxFormulaChargeCaculatedOnFormula(dr));
//    }
//    else
//    {
//        taxformulachargecalcultedons.Add(GetTaxFormulaChargeCaculatedOnValues(dr));
//    }
//}

//int count = 0;

//foreach (var item in taxformulacalonbehaviour.Select(a => new {a.TaxFormulaChargeId, a.Behaviour, a.CalculatedOnId, a.CalculatedOnName, a.CalOnBehaviour}).Distinct())
//{
//    string calOnFormula = "";

//    calOnFormula = ITE.CalculatedOnName + " ";

//    TaxFormulaCalculatedOnInfo tfcoi = new TaxFormulaCalculatedOnInfo();

//    tfcoi.TaxChargesId = item.TaxFormulaChargeId;

//    tfcoi.Behaviour = item.Behaviour;

//    tfcoi.CalculatedOnId = item.CalculatedOnId;

//    tfcoi.CalculatedOnName = item.CalculatedOnName;

//    tfcoi.CalOnBehaviour = item.CalOnBehaviour;

//    foreach (var itm in taxformulacalonbehaviour.Where(a => a.TaxFormulaChargeId == item.TaxFormulaChargeId))
//    {                                     
//            calOnFormula += itm.Behaviour + " "  + itm.CalculatedOnName + " ";
//    }

//    tfcoi.CalOnBehaviour = calOnFormula;

//    taxformulachargecalcultedons[count].CalOnBehaviour = tfcoi.CalOnBehaviour;

//    count ++;

//}