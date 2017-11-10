using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using LohanaBusinessEntities.Vendor;
using LohanaBusinessEntities.Hotel;
using LohanaBusinessEntities.Meal;
using LohanaBusinessEntities.RoomType;
using LohanaBusinessEntities.Charges;
using LohanaBusinessEntities.TaxFormula;
using LohanaBusinessEntities.HotelTariffTaxUpdation;
using LohanaBusinessEntities.HotelTariff;
using LohanaBusinessEntities.Common;
using LohanaBusinessLogic.Utilities;
using LohanaRepo.Utilities;
using LohanaHelper.Logging;


namespace LohanaRepo.HotelTariffTaxUpdation
{
    public class HotelTariffTaxUpdationRepo
    {

        SQLHelperRepo _sqlHelper = null;

        public HotelTariffTaxUpdationRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        public DataTable GetHotelTariffTaxUpdation(HotelTariffTaxUpdationInfo hotelTax, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@VendorId", hotelTax.VendorId));

            sqlParam.Add(new SqlParameter("@HotelId", hotelTax.HotelId));

            sqlParam.Add(new SqlParameter("@RoomTypeId", hotelTax.RoomTypeId));

            sqlParam.Add(new SqlParameter("@MealId", hotelTax.MealId));

            sqlParam.Add(new SqlParameter("@FormulaId", hotelTax.FormulaId));


            if (hotelTax.FromDate == DateTime.MinValue)
            {
                DateTime? someDate = null;
                sqlParam.Add(new SqlParameter("@FromDate", someDate));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@FromDate", hotelTax.FromDate));
            }

            if (hotelTax.ToDate == DateTime.MinValue)
            {
                DateTime? someDate = null;
                sqlParam.Add(new SqlParameter("@ToDate", someDate));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@ToDate", hotelTax.ToDate));
            }

            //sqlParam.Add(new SqlParameter("@FromDate", null));

            //sqlParam.Add(new SqlParameter("@ToDate", null));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetHotelTariffTax.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }

        public void UpdateHotelTariffPriceDetails(List<HotelTariffPriceDetailsInfo> hoteltariffpricedetails, HotelTariffPriceDetailsInfo hoteltariffpricedetail, HotelTariffTaxUpdationInfo hoteltax)
        {
            foreach (var item in hoteltariffpricedetails)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@HotelTariffPriceDetailsId", item.HotelTariffPriceDetailsId));

                sqlParams.Add(new SqlParameter("@HotelTariffDurationDetailsId", item.HotelTariffDurationDetailsId));
                Logger.Debug("HotelTariff Controller HotelTariffDurationDetailsId:" + item.HotelTariffDurationDetailsId);

                sqlParams.Add(new SqlParameter("@HotelTariffRoomOccupancyId", item.HotelTariffRoomOccupancyId));
                Logger.Debug("HotelTariff Controller HotelTariffRoomOccupancyId:" + item.HotelTariffRoomOccupancyId);

                sqlParams.Add(new SqlParameter("@HotelTariffId", item.HotelTariffId));
                Logger.Debug("HotelTariff Controller HotelTariffId:" + item.HotelTariffId);

                sqlParams.Add(new SqlParameter("@PublishPrice", item.PublishPrice));
                Logger.Debug("HotelTariff Controller PublishPrice:" + item.PublishPrice);

                sqlParams.Add(new SqlParameter("@SpecialPrice", item.SpecialPrice));
                Logger.Debug("HotelTariff Controller SpecialPrice:" + item.SpecialPrice);

                sqlParams.Add(new SqlParameter("@CommissionPrice", item.CommissionPrice));
                Logger.Debug("HotelTariff Controller CommissionPrice:" + item.CommissionPrice);

                sqlParams.Add(new SqlParameter("@FormulaId", hoteltax.TaxFormulaId));
                Logger.Debug("HotelTariff Controller TaxFormulaId:" + hoteltax.TaxFormulaId);

                sqlParams.Add(new SqlParameter("@TotalTaxPrice", item.TotalTaxPrice));
                Logger.Debug("HotelTariff Controller TotalTaxPrice:" + item.TotalTaxPrice);

                sqlParams.Add(new SqlParameter("@NetRate", item.NetRate));
                Logger.Debug("HotelTariff Controller NetRate:" + item.NetRate);

                sqlParams.Add(new SqlParameter("@NetRatePerNight", item.NetRatePerNight));
                Logger.Debug("HotelTariff Controller NetRatePerNight:" + item.NetRatePerNight);

                sqlParams.Add(new SqlParameter("@UpdatedDate", item.UpdatedDate));

                sqlParams.Add(new SqlParameter("@UpdatedBy", item.UpdatedBy));

                _sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.spUpdateHotelTariffPriceDetails.ToString(), CommandType.StoredProcedure);

            }

            //DeletHotelTariffCharges(hoteltariffpricedetail);

            //InsertPriceChargesDetails(hoteltariffpricedetail);

        }

        public void DeletHotelTariffCharges(HotelTariffPriceDetailsInfo hoteltariffpricedetail)
        {
            foreach (var item in hoteltariffpricedetail.HotelTariffCharges)
            {
                List<SqlParameter> sqlParam = new List<SqlParameter>();

                sqlParam.Add(new SqlParameter("HotelTariffPriceDetailsId", item.HotelTariffPriceDetailsId));

                _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeletHotelTariffCharges.ToString(), CommandType.StoredProcedure);

            }
        }

        public void InsertPriceChargesDetails(HotelTariffPriceDetailsInfo hoteltariffpricedetail)
        {
            foreach (var item in hoteltariffpricedetail.HotelTariffCharges)
            {
                List<SqlParameter> sqlParam = new List<SqlParameter>();

                if (item.HotelTariffChargesDetailsId != 0)
                {
                    sqlParam.Add(new SqlParameter("HotelTariffChargesDetailsId", item.HotelTariffChargesDetailsId));
                }

                sqlParam.Add(new SqlParameter("@HotelTariffPriceDetailsId", item.HotelTariffPriceDetailsId));

                sqlParam.Add(new SqlParameter("@ChargesId", item.ChargesId));

                sqlParam.Add(new SqlParameter("@Percentage", item.Percentage));

                sqlParam.Add(new SqlParameter("@CalculatedPrice", item.CalculatedPrice));

                _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spInsertHotelTariffCharges.ToString(), CommandType.StoredProcedure);

            }

        }

        public void InsertHotelTariffDateDetails(List<HotelTariffPriceDetailsInfo> hoteltariffpricedetails)
        {
            foreach (var item in hoteltariffpricedetails)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                if (item.HotelTariffDurationDetailsId != 0)
                {
                    sqlParams.Add(new SqlParameter("@HotelTariffPriceDetailsId", item.HotelTariffDurationDetailsId));
                }

                sqlParams.Add(new SqlParameter("@HotelTariffId", item.HotelTariffId));
                Logger.Debug("HotelTariff Controller HotelTariffId:" + item.HotelTariffId);

                sqlParams.Add(new SqlParameter("@NoOfNight", item.NoOfNight));
                Logger.Debug("HotelTariff Controller NoOfNight:" + item.NoOfNight);

                sqlParams.Add(new SqlParameter("@NetRate", item.NetRatePerNight));
                Logger.Debug("HotelTariff Controller NetRate:" + item.NetRatePerNight);

                _sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.spUpdateHotelTariffDateDetails.ToString(), CommandType.StoredProcedure);

            }

        }


    }
}
