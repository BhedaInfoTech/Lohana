using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Hotel;
using LohanaBusinessEntities.HotelTariff;
using LohanaBusinessEntities.Meal;
using LohanaBusinessEntities.Occupancy;
using LohanaBusinessEntities.RoomType;
using LohanaBusinessEntities.TaxFormula;
using LohanaBusinessEntities.Vendor;
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

namespace LohanaRepo.HotelTariff
{
    public class HotelTariffRepo
    {

        SQLHelperRepo _sqlHelper = null;

        public HotelTariffRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        #region DropDowns

        public List<VendorInfo> drpGetVendors()
        {
            List<VendorInfo> vendors = new List<VendorInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetVendors.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    vendors.Add(GetVendorValues(dr));
                }
            }
            return vendors;
        }

        public VendorInfo GetVendorValues(DataRow dr)
        {
            VendorInfo retVal = new VendorInfo();

            retVal.VendorId = Convert.ToInt32(dr["VendorId"]);

            retVal.VendorName = Convert.ToString(dr["VendorName"]);

            return retVal;
        }

        public List<HotelInfo> drpGetHotels()
        {
            List<HotelInfo> hotels = new List<HotelInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetHotels.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    hotels.Add(GetHotelValues(dr));
                }
            }
            return hotels;
        }

        public HotelInfo GetHotelValues(DataRow dr)
        {
            HotelInfo retVal = new HotelInfo();

            retVal.HotelId = Convert.ToInt32(dr["HotelId"]);

            retVal.HotelName = Convert.ToString(dr["HotelName"]);

            return retVal;
        }

        public List<RoomTypeInfo> drpGetRoomTypes()
        {
            List<RoomTypeInfo> roomtypes = new List<RoomTypeInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetRoomType.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    roomtypes.Add(GetRoomTypeValues(dr));
                }
            }
            return roomtypes;
        }

        public RoomTypeInfo GetRoomTypeValues(DataRow dr)
        {
            RoomTypeInfo retVal = new RoomTypeInfo();

            retVal.RoomTypeId = Convert.ToInt32(dr["RoomTypeId"]);

            retVal.RoomTypeName = Convert.ToString(dr["RoomTypeName"]);

            return retVal;
        }

        public List<MealInfo> drpGetMeals()
        {
            List<MealInfo> meals = new List<MealInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetMeals.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    meals.Add(GetMealValues(dr));
                }
            }
            return meals;
        }

        public MealInfo GetMealValues(DataRow dr)
        {
            MealInfo retVal = new MealInfo();

            retVal.MealId = Convert.ToInt32(dr["MealId"]);

            retVal.MealName = Convert.ToString(dr["MealName"]);

            return retVal;
        }

        public List<OccupancyInfo> drpGetOccupancies()
        {
            List<OccupancyInfo> occupancies = new List<OccupancyInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetOccupancies.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    occupancies.Add(GetOccupancyValues(dr));
                }
            }
            return occupancies;
        }

        public OccupancyInfo GetOccupancyValues(DataRow dr)
        {
            OccupancyInfo retVal = new OccupancyInfo();

            retVal.OccupancyId = Convert.ToInt32(dr["OccupancyId"]);

            retVal.OccupancyName = Convert.ToString(dr["OccupancyName"]);

            retVal.OccupancyType = Convert.ToInt32(dr["OccupancyType"]);

            return retVal;
        }


        #endregion

        #region Basic Details

        public int InsertHotelTariff(HotelTariffInfo hoteltariff)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInHotelTariff(hoteltariff), Storeprocedures.spInsertHotelTariff.ToString(), CommandType.StoredProcedure));
        }

        public void UpdateHotelTariff(HotelTariffInfo hoteltariff)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInHotelTariff(hoteltariff), Storeprocedures.spUpdateHotelTariff.ToString(), CommandType.StoredProcedure);
        }

        public DataTable GetHotelTariff(int vendorId, int hotelId, int cityId, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@VendorId", vendorId));

            sqlParam.Add(new SqlParameter("@HotelId", hotelId));

            sqlParam.Add(new SqlParameter("@CityId", cityId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetHotelTariff.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }

        private List<SqlParameter> SetValuesInHotelTariff(HotelTariffInfo hoteltariff)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (hoteltariff.HotelTariffId != 0)
            {
                sqlParams.Add(new SqlParameter("@HotelTariffId", hoteltariff.HotelTariffId));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@CreatedDate", hoteltariff.CreatedDate));
                sqlParams.Add(new SqlParameter("@CreatedBy", hoteltariff.CreatedBy));
            }
           
            sqlParams.Add(new SqlParameter("@VendorId", hoteltariff.VendorId));
            Logger.Debug("HotelTariff Controller VendorId:" + hoteltariff.VendorId);          

            sqlParams.Add(new SqlParameter("@HotelId", hoteltariff.HotelId));
            Logger.Debug("HotelTariff Controller HotelId:" + hoteltariff.HotelId);

            sqlParams.Add(new SqlParameter("@CityId", hoteltariff.CityId));

            sqlParams.Add(new SqlParameter("@UpdatedDate", hoteltariff.UpdatedDate));
            sqlParams.Add(new SqlParameter("@UpdatedBy", hoteltariff.UpdatedBy));
            return sqlParams;
        }

        private HotelTariffInfo GetHotelTariffValues(DataRow dr)
        {
            HotelTariffInfo hoteltariff = new HotelTariffInfo();

            hoteltariff.HotelTariffId = Convert.ToInt32(dr["HotelTariffId"]);
            hoteltariff.VendorId = Convert.ToInt32(dr["VendorId"]);
            hoteltariff.HotelId = Convert.ToInt32(dr["HotelId"]);
            hoteltariff.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
            hoteltariff.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            hoteltariff.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
            hoteltariff.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            return hoteltariff;
        }

        public bool IsSameHotelVendorExists(int vendorId, int hotelId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@VendorId", vendorId));

            sqlParam.Add(new SqlParameter("@HotelId", hotelId));

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParam, Storeprocedures.spIsSameHotelVendorExists.ToString(), CommandType.StoredProcedure));
        }

        #endregion


        #region Date

        public List<DateTime> GetFilteredDate(HotelTariffPriceDetailsInfo hoteltariffpricedetails)
        {

            HotelTariffDurationDetailsInfo duration = new HotelTariffDurationDetailsInfo();

            duration = GetDurationById(hoteltariffpricedetails.HotelTariffDurationDetailsId, hoteltariffpricedetails.HotelTariffId);


            List<DateTime> dates = new List<DateTime>();

            foreach (DateTime day in EachDay(duration.FromDate, duration.ToDate))
            {

                if (duration.OperationalDays.Split(',').Contains(day.DayOfWeek.ToString()))
                {
                    dates.Add(day.Date);
                }
            }
            return dates;

        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public HotelTariffDurationDetailsInfo GetDurationById(int hoteltariffdurationdetailsid, int hoteltariffid)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            HotelTariffDurationDetailsInfo duration = new HotelTariffDurationDetailsInfo();

            sqlParam.Add(new SqlParameter("@HotelTariffDurationDetailsId", hoteltariffdurationdetailsid));

            sqlParam.Add(new SqlParameter("@HotelTariffId", hoteltariffid));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetHotelTariffDurationById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    duration = GetDurationValues(dr);
                }
            }
            return duration;
        }

        private HotelTariffDurationDetailsInfo GetDurationValues(DataRow dr)
        {
            HotelTariffDurationDetailsInfo duration = new HotelTariffDurationDetailsInfo();


            duration.NoOfNight = Convert.ToInt32(dr["NoOfNight"]);

            duration.FromDate = Convert.ToDateTime(dr["FromDate"]);

            duration.ToDate = Convert.ToDateTime(dr["ToDate"]);

            duration.OperationalDays = Convert.ToString(dr["OperationalDays"]);

            return duration;

        }

        public void InsertHotelTariffDateDetails(List<DateTime> dates, HotelTariffPriceDetailsInfo hoteltariffpricedetails)
        {

            foreach (var item in dates)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                if (hoteltariffpricedetails.HotelTariffPriceDetailsId != 0)
                {
                    sqlParams.Add(new SqlParameter("@HotelTariffPriceDetailsId", hoteltariffpricedetails.HotelTariffPriceDetailsId));
                }

                sqlParams.Add(new SqlParameter("@HotelTariffId", hoteltariffpricedetails.HotelTariffId));
                Logger.Debug("HotelTariff Controller HotelTariffId:" + hoteltariffpricedetails.HotelTariffId);

                sqlParams.Add(new SqlParameter("@NoOfNight", hoteltariffpricedetails.NoOfNight));
                Logger.Debug("HotelTariff Controller NoOfNight:" + hoteltariffpricedetails.NoOfNight);

                sqlParams.Add(new SqlParameter("@TariffDate", item));
                Logger.Debug("HotelTariff Controller TariffDate:" + item);

                sqlParams.Add(new SqlParameter("@NetRate", hoteltariffpricedetails.NetRatePerNight));
                Logger.Debug("HotelTariff Controller NetRate:" + hoteltariffpricedetails.NetRatePerNight);

                _sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.spInsertHotelTariffDateDetails.ToString(), CommandType.StoredProcedure);

            }

        }



        #endregion

        #region Price Details

        public int InsertHotelTariffPriceDetails(HotelTariffPriceDetailsInfo hoteltariffpricedetails)
        {


            hoteltariffpricedetails.HotelTariffPriceDetailsId = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInHotelTariffPriceDetails(hoteltariffpricedetails), Storeprocedures.spInsertHotelTariffPriceDetails.ToString(), CommandType.StoredProcedure));

            InsertPriceChargesDetails(hoteltariffpricedetails);


            return hoteltariffpricedetails.HotelTariffPriceDetailsId;


        }

        public void InsertPriceChargesDetails(HotelTariffPriceDetailsInfo hoteltariffpricedetails)
        {


            foreach (var item in hoteltariffpricedetails.HotelTariffCharges)
            {

                List<SqlParameter> sqlParam = new List<SqlParameter>();

                if (item.HotelTariffChargesDetailsId != 0)
                {
                    sqlParam.Add(new SqlParameter("HotelTariffChargesDetailsId", item.HotelTariffChargesDetailsId));
                }

                sqlParam.Add(new SqlParameter("@HotelTariffPriceDetailsId", hoteltariffpricedetails.HotelTariffPriceDetailsId));

                sqlParam.Add(new SqlParameter("@ChargesId", item.ChargesId));

                sqlParam.Add(new SqlParameter("@Percentage", item.Percentage));

                sqlParam.Add(new SqlParameter("@CalculatedPrice", item.CalculatedPrice));

                _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spInsertHotelTariffCharges.ToString(), CommandType.StoredProcedure);

            }

        }

        public List<HotelTariffPriceDetailsInfo> GetHotelTariffPrice(int hoteltariffroomoccupancyid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            List<HotelTariffPriceDetailsInfo> HotelTariffPrices = new List<HotelTariffPriceDetailsInfo>();

            sqlParam.Add(new SqlParameter("@HotelTariffRoomOccupancyId", hoteltariffroomoccupancyid));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetHotelTariffPrice.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    HotelTariffPrices.Add(GetPriceValues(dr));
                }
            }
            return HotelTariffPrices;
        }

        private HotelTariffPriceDetailsInfo GetPriceValues(DataRow dr)
        {

            HotelTariffPriceDetailsInfo HotelTariffPrice = new HotelTariffPriceDetailsInfo();

            //HotelTariffPrice.HotelTariffId = Convert.ToInt32(dr["HotelTariffId"]);

            //HotelTariffPrice.HotelTariffDurationDetailsId = Convert.ToInt32(dr["HotelTariffDurationDetailsId"]);

            HotelTariffPrice.HotelTariffPriceDetailsId = Convert.ToInt32(dr["HotelTariffPriceDetailsId"]);

            HotelTariffPrice.HotelTariffRoomOccupancyId = Convert.ToInt32(dr["HotelTariffRoomOccupancyId"]);

            HotelTariffPrice.SpecialPrice = Convert.ToDecimal(dr["SpecialPrice"]);

            HotelTariffPrice.PublishPrice = Convert.ToDecimal(dr["PublishPrice"]);

            HotelTariffPrice.CommissionPrice = Convert.ToDecimal(dr["CommissionPrice"]);

            HotelTariffPrice.FormulaId = Convert.ToInt32(dr["FormulaId"]);

            HotelTariffPrice.TotalTaxPrice = Convert.ToDecimal(dr["TotalTaxPrice"]);

            HotelTariffPrice.NetRate = Convert.ToDecimal(dr["NetRate"]);

            HotelTariffPrice.NetRatePerNight = Convert.ToDecimal(dr["NetRatePerNight"]);

            HotelTariffPrice.Color = Convert.ToString(dr["Color"]);

            return HotelTariffPrice;

        }

        public void UpdateHotelTariffPriceDetails(HotelTariffPriceDetailsInfo hoteltariffpricedetails)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInHotelTariffPriceDetails(hoteltariffpricedetails), Storeprocedures.spUpdateHotelTariffPriceDetails.ToString(), CommandType.StoredProcedure);

            DeletHotelTariffCharges(hoteltariffpricedetails);

            InsertPriceChargesDetails(hoteltariffpricedetails);

        }

        public void DeletHotelTariffCharges(HotelTariffPriceDetailsInfo hoteltariffpricedetails)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("HotelTariffPriceDetailsId", hoteltariffpricedetails.HotelTariffPriceDetailsId));

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeletHotelTariffCharges.ToString(), CommandType.StoredProcedure);

        }

        public void DeleteHotelTariffDates(int hoteltariffpricedetailsid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            HotelTariffPriceDetailsInfo hoteltariffpricedetails = new HotelTariffPriceDetailsInfo();

            sqlParam.Add(new SqlParameter("HotelTariffPriceDetailsId", hoteltariffpricedetailsid));

            Logger.Debug("HotelTariff Controller HotelTariffPriceDetailsId:" + hoteltariffpricedetailsid);

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeletHotelTariffDates.ToString(), CommandType.StoredProcedure);

        }

        private List<SqlParameter> SetValuesInHotelTariffPriceDetails(HotelTariffPriceDetailsInfo hoteltariffpricedetails)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (hoteltariffpricedetails.HotelTariffPriceDetailsId != 0)
            {
                sqlParams.Add(new SqlParameter("@HotelTariffPriceDetailsId", hoteltariffpricedetails.HotelTariffPriceDetailsId));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@CreatedDate", hoteltariffpricedetails.CreatedDate));

                sqlParams.Add(new SqlParameter("@CreatedBy", hoteltariffpricedetails.CreatedBy));
            }
            sqlParams.Add(new SqlParameter("@HotelTariffRoomOccupancyId", hoteltariffpricedetails.HotelTariffRoomOccupancyId));
            Logger.Debug("HotelTariff Controller HotelTariffRoomOccupancyId:" + hoteltariffpricedetails.HotelTariffRoomOccupancyId);

            sqlParams.Add(new SqlParameter("@PublishPrice", hoteltariffpricedetails.PublishPrice));
            Logger.Debug("HotelTariff Controller PublishPrice:" + hoteltariffpricedetails.PublishPrice);

            sqlParams.Add(new SqlParameter("@SpecialPrice", hoteltariffpricedetails.SpecialPrice));
            Logger.Debug("HotelTariff Controller SpecialPrice:" + hoteltariffpricedetails.SpecialPrice);

            sqlParams.Add(new SqlParameter("@CommissionPrice", hoteltariffpricedetails.CommissionPrice));
            Logger.Debug("HotelTariff Controller CommissionPrice:" + hoteltariffpricedetails.CommissionPrice);

            sqlParams.Add(new SqlParameter("@FormulaId", hoteltariffpricedetails.FormulaId));
            Logger.Debug("HotelTariff Controller FormulaId:" + hoteltariffpricedetails.FormulaId);

            sqlParams.Add(new SqlParameter("@TotalTaxPrice", hoteltariffpricedetails.TotalTaxPrice));
            Logger.Debug("HotelTariff Controller TotalTaxPrice:" + hoteltariffpricedetails.TotalTaxPrice);

            sqlParams.Add(new SqlParameter("@NetRate", hoteltariffpricedetails.NetRate));
            Logger.Debug("HotelTariff Controller NetRate:" + hoteltariffpricedetails.NetRate);

            sqlParams.Add(new SqlParameter("@NetRatePerNight", hoteltariffpricedetails.NetRatePerNight));
            Logger.Debug("HotelTariff Controller NetRatePerNight:" + hoteltariffpricedetails.NetRatePerNight);

            sqlParams.Add(new SqlParameter("@Color", hoteltariffpricedetails.Color));
            Logger.Debug("HotelTariff Controller NetRatePerNight:" + hoteltariffpricedetails.Color);

            sqlParams.Add(new SqlParameter("@UpdatedDate", hoteltariffpricedetails.UpdatedDate));

            sqlParams.Add(new SqlParameter("@UpdatedBy", hoteltariffpricedetails.UpdatedBy));

            return sqlParams;
        }

        private HotelTariffPriceDetailsInfo GetHotelTariffPriceDetailsValues(DataRow dr)
        {
            HotelTariffPriceDetailsInfo hoteltariffpricedetails = new HotelTariffPriceDetailsInfo();

            hoteltariffpricedetails.HotelTariffPriceDetailsId = Convert.ToInt32(dr["HotelTariffPriceDetailsId"]);
            hoteltariffpricedetails.HotelTariffRoomOccupancyId = Convert.ToInt32(dr["HotelTariffRoomOccupancyId"]);
            hoteltariffpricedetails.HotelTariffDurationDetailsId = Convert.ToInt32(dr["HotelTariffDurationDetailsId"]);
            hoteltariffpricedetails.HotelTariffId = Convert.ToInt32(dr["HotelTariffId"]);
            hoteltariffpricedetails.PublishPrice = Convert.ToDecimal(dr["PublishPrice"]);
            hoteltariffpricedetails.SpecialPrice = Convert.ToDecimal(dr["SpecialPrice"]);
            hoteltariffpricedetails.CommissionPrice = Convert.ToDecimal(dr["CommissionPrice"]);
            hoteltariffpricedetails.FormulaId = Convert.ToInt32(dr["FormulaId"]);
            hoteltariffpricedetails.TotalTaxPrice = Convert.ToDecimal(dr["TotalTaxPrice"]);
            hoteltariffpricedetails.NetRate = Convert.ToDecimal(dr["NetRate"]);
            hoteltariffpricedetails.NetRatePerNight = Convert.ToDecimal(dr["NetRatePerNight"]);
            hoteltariffpricedetails.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
            hoteltariffpricedetails.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            hoteltariffpricedetails.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
            hoteltariffpricedetails.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            return hoteltariffpricedetails;
        }

        public HotelTariffPriceDetailsInfo GetHotelTariffPriceById(int hotelTariffPriceDetailsId)
        {
            HotelTariffPriceDetailsInfo hotelTariffPriceDetails = new HotelTariffPriceDetailsInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@HotelTariffPriceDetailsId", hotelTariffPriceDetailsId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spGetHotelTariffPriceById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    hotelTariffPriceDetails = GetPriceValues(dr);
                }
            }

            return hotelTariffPriceDetails;
        }

        public List<TaxFormulaChargesInfo> GetTaxFormulaChargesByPriceId(int taxFormulaId, int hoteltariffpricedetailsid, ref PaginationInfo pager)
        {
            List<TaxFormulaChargesInfo> taxFormulaChargesInfo = new List<TaxFormulaChargesInfo>();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@TaxFormulaId", taxFormulaId));

            sqlParam.Add(new SqlParameter("@HotelTariffPriceDetailsId", hoteltariffpricedetailsid));


            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetHotelTariffTaxCharges.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                taxFormulaChargesInfo.Add(GetHotelTariffTaxFormulaCharges(dr));
            }

            return taxFormulaChargesInfo;
        }

        private TaxFormulaChargesInfo GetHotelTariffTaxFormulaCharges(DataRow dr)
        {
            TaxFormulaChargesInfo taxFormulaCharges = new TaxFormulaChargesInfo();

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
            if (dr["Percentage"] != DBNull.Value)
            {
                taxFormulaCharges.HotelTariffCharge.Percentage = Convert.ToDecimal(dr["Percentage"]);
            }

            if (dr["CalculatedPrice"] != DBNull.Value)
            {
                taxFormulaCharges.HotelTariffCharge.CalculatedPrice = Convert.ToDecimal(dr["CalculatedPrice"]);
            }
            if (dr["TotalTaxPrice"] != DBNull.Value)
            {
                taxFormulaCharges.HotelTariffCharge.TotalTaxPrice = Convert.ToDecimal(dr["TotalTaxPrice"]);
            }

            //if (dr["HotelTariffChargesDetailsId"] != DBNull.Value)
            //{
            //	taxFormulaCharges.HotelTariffCharge.HotelTariffChargesDetailsId = Convert.ToInt32(dr["HotelTariffChargesDetailsId"]);
            //}
            return taxFormulaCharges;
        }

        #endregion

        #region Room Details

        public int InsertHotelTariffRoomDetails(HotelTariffRoomDetailsInfo hoteltariffroomdetails)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInHotelTariffRoomDetails(hoteltariffroomdetails), Storeprocedures.spInsertHotelTariffRoomDetails.ToString(), CommandType.StoredProcedure));

        }

        public void UpdateHotelTariffRoomDetails(HotelTariffRoomDetailsInfo hoteltariffroomdetails)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInHotelTariffRoomDetails(hoteltariffroomdetails), Storeprocedures.spUpdateHotelTariffRoomDetails.ToString(), CommandType.StoredProcedure);
        }

        public DataTable GetRoom(int hoteltariffid, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@HotelTariffId", hoteltariffid));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetHotelTariffRoom.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }

        public void DeleteRoom(int hoteltariffid, int hoteltariffroomdetailsid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            HotelTariffDurationDetailsInfo HotelTariffDuration = new HotelTariffDurationDetailsInfo();

            sqlParam.Add(new SqlParameter("@HotelTariffId", hoteltariffid));

            Logger.Debug("HotelTariff Controller HotelTariffId:" + hoteltariffid);

            sqlParam.Add(new SqlParameter("@HotelTariffRoomDetailsId", hoteltariffroomdetailsid));

            Logger.Debug("HotelTariff Controller HotelTariffRoomDetailsId:" + hoteltariffroomdetailsid);

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteHotelTariffRoom.ToString(), CommandType.StoredProcedure);


        }

        private List<SqlParameter> SetValuesInHotelTariffRoomDetails(HotelTariffRoomDetailsInfo hoteltariffroomdetails)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (hoteltariffroomdetails.HotelTariffRoomDetailsId != 0)
            {
                sqlParams.Add(new SqlParameter("@HotelTariffRoomDetailsId", hoteltariffroomdetails.HotelTariffRoomDetailsId));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@CreatedDate", hoteltariffroomdetails.CreatedDate));

                sqlParams.Add(new SqlParameter("@CreatedBy", hoteltariffroomdetails.CreatedBy));
            }


            sqlParams.Add(new SqlParameter("@HotelTariffId", hoteltariffroomdetails.HotelTariffId));
            Logger.Debug("HotelTariff Controller HotelTariffId:" + hoteltariffroomdetails.HotelTariffId);

            sqlParams.Add(new SqlParameter("@RoomRateTypeId", hoteltariffroomdetails.RoomRateTypeId));
            Logger.Debug("HotelTariff Controller RoomRateTypeId:" + hoteltariffroomdetails.RoomRateTypeId);

            sqlParams.Add(new SqlParameter("@CheckInTime", hoteltariffroomdetails.CheckInTime));
            Logger.Debug("HotelTariff Controller CheckInTime:" + hoteltariffroomdetails.CheckInTime);

            sqlParams.Add(new SqlParameter("@CheckOutTime", hoteltariffroomdetails.CheckOutTime));
            Logger.Debug("HotelTariff Controller CheckOutTime:" + hoteltariffroomdetails.CheckOutTime);

            sqlParams.Add(new SqlParameter("@RoomTypeId", hoteltariffroomdetails.RoomTypeId));
            Logger.Debug("HotelTariff Controller RoomTypeId:" + hoteltariffroomdetails.RoomTypeId);

            //sqlParams.Add(new SqlParameter("@OccupancyId", hoteltariffroomdetails.OccupancyId));
            //Logger.Debug("HotelTariff Controller OccupancyId:" + hoteltariffroomdetails.OccupancyId);

            //sqlParams.Add(new SqlParameter("@AgeFrom", hoteltariffroomdetails.AgeFrom));
            //Logger.Debug("HotelTariff Controller AgeFrom:" + hoteltariffroomdetails.AgeFrom);

            //sqlParams.Add(new SqlParameter("@AgeTo", hoteltariffroomdetails.AgeTo));
            //Logger.Debug("HotelTariff Controller AgeTo:" + hoteltariffroomdetails.AgeTo);

            //sqlParams.Add(new SqlParameter("@MealId", hoteltariffroomdetails.MealId));
            //Logger.Debug("HotelTariff Controller MealId:" + hoteltariffroomdetails.MealId);

            //sqlParams.Add(new SqlParameter("@MealInclusion", hoteltariffroomdetails.MealInclusion));
            //Logger.Debug("HotelTariff Controller MealInclusion:" + hoteltariffroomdetails.MealInclusion);

            //sqlParams.Add(new SqlParameter("@RoomInclusion", hoteltariffroomdetails.RoomInclusion));
            //Logger.Debug("HotelTariff Controller RoomInclusion:" + hoteltariffroomdetails.RoomInclusion);

            //sqlParams.Add(new SqlParameter("@RoomExclusion", hoteltariffroomdetails.RoomExclusion));			
            //Logger.Debug("HotelTariff Controller RoomExclusion:" + hoteltariffroomdetails.RoomExclusion);

            sqlParams.Add(new SqlParameter("@UpdatedDate", hoteltariffroomdetails.UpdatedDate));

            sqlParams.Add(new SqlParameter("@UpdatedBy", hoteltariffroomdetails.UpdatedBy));

            sqlParams.Add(new SqlParameter("@NoOfNight", hoteltariffroomdetails.NoOfNight));

            return sqlParams;
        }

        private HotelTariffRoomDetailsInfo GetHotelTariffRoomDetailsValues(DataRow dr)
        {
            HotelTariffRoomDetailsInfo hoteltariffroomdetails = new HotelTariffRoomDetailsInfo();

            hoteltariffroomdetails.HotelTariffRoomDetailsId = Convert.ToInt32(dr["HotelTariffRoomDetailsId"]);
            hoteltariffroomdetails.HotelTariffDurationDetailsId = Convert.ToInt32(dr["HotelTariffDurationDetailsId"]);
            hoteltariffroomdetails.HotelTariffId = Convert.ToInt32(dr["HotelTariffId"]);
            hoteltariffroomdetails.RoomRateTypeId = Convert.ToInt32(dr["RoomRateTypeId"]);
            hoteltariffroomdetails.RoomTypeId = Convert.ToInt32(dr["RoomTypeId"]);
            hoteltariffroomdetails.OccupancyId = Convert.ToInt32(dr["OccupancyId"]);
            hoteltariffroomdetails.AgeFrom = Convert.ToDecimal(dr["AgeFrom"]);
            hoteltariffroomdetails.AgeTo = Convert.ToDecimal(dr["AgeTo"]);
            hoteltariffroomdetails.MealId = Convert.ToInt32(dr["MealId"]);
            hoteltariffroomdetails.MealInclusion = Convert.ToString(dr["MealInclusion"]);
            hoteltariffroomdetails.RoomInclusion = Convert.ToString(dr["RoomInclusion"]);
            hoteltariffroomdetails.RoomExclusion = Convert.ToString(dr["RoomExclusion"]);
            hoteltariffroomdetails.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
            hoteltariffroomdetails.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            hoteltariffroomdetails.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
            hoteltariffroomdetails.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            hoteltariffroomdetails.NoOfNight = Convert.ToInt32(dr["NoOfNight"]);
            return hoteltariffroomdetails;
        }

        #endregion

        #region Room Occupancy

        public int InsertHotelTariffRoomOccupancy(HotelTariffRoomOccupancyInfo hoteltariffroomOccupancy)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInHotelTariffRoomOccupancy(hoteltariffroomOccupancy), Storeprocedures.spInsertHotelTariffRoomOccupancy.ToString(), CommandType.StoredProcedure));

        }

        public void UpdateHotelTariffRoomOccupancy(HotelTariffRoomOccupancyInfo hoteltariffroomOccupancy)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInHotelTariffRoomOccupancy(hoteltariffroomOccupancy), Storeprocedures.spUpdateHotelTariffRoomOccupancy.ToString(), CommandType.StoredProcedure);
        }

        public DataTable GetRoomOccupancy(int hoteltariffroomdetailsid, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@HotelTariffRoomDetailsId", hoteltariffroomdetailsid));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetHotelTariffRoomOccupancy.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }

        public void DeleteRoomOccupancy(int hoteltariffroomdetailsid, int hoteltariffroomoccupancyid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            HotelTariffDurationDetailsInfo HotelTariffDuration = new HotelTariffDurationDetailsInfo();

            sqlParam.Add(new SqlParameter("@HotelTariffRoomDetailsId", hoteltariffroomdetailsid));

            Logger.Debug("HotelTariff Controller HotelTariffRoomDetailsId:" + hoteltariffroomdetailsid);

            sqlParam.Add(new SqlParameter("@HotelTariffRoomOccupancyId", hoteltariffroomoccupancyid));

            Logger.Debug("HotelTariff Controller HotelTariffRoomOccupancyId:" + hoteltariffroomoccupancyid);

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteHotelTariffRoomOccupancy.ToString(), CommandType.StoredProcedure);


        }

        private List<SqlParameter> SetValuesInHotelTariffRoomOccupancy(HotelTariffRoomOccupancyInfo hoteltariffroomOccupancy)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (hoteltariffroomOccupancy.HotelTariffRoomOccupancyId != 0)
            {
                sqlParams.Add(new SqlParameter("@HotelTariffRoomOccupancyId", hoteltariffroomOccupancy.HotelTariffRoomOccupancyId));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@CreatedDate", hoteltariffroomOccupancy.CreatedDate));

                sqlParams.Add(new SqlParameter("@CreatedBy", hoteltariffroomOccupancy.CreatedBy));

                sqlParams.Add(new SqlParameter("@HotelTariffRoomDetailsId", hoteltariffroomOccupancy.HotelTariffRoomDetailsId));
                Logger.Debug("HotelTariff Controller HotelTariffRoomDetailsId:" + hoteltariffroomOccupancy.HotelTariffRoomDetailsId);
            }

            sqlParams.Add(new SqlParameter("@OccupancyId", hoteltariffroomOccupancy.OccupancyId));
            Logger.Debug("HotelTariff Controller OccupancyId:" + hoteltariffroomOccupancy.OccupancyId);

            sqlParams.Add(new SqlParameter("@AgeFrom", hoteltariffroomOccupancy.AgeFrom));
            Logger.Debug("HotelTariff Controller AgeFrom:" + hoteltariffroomOccupancy.AgeFrom);

            sqlParams.Add(new SqlParameter("@AgeTo", hoteltariffroomOccupancy.AgeTo));
            Logger.Debug("HotelTariff Controller AgeTo:" + hoteltariffroomOccupancy.AgeTo);

            sqlParams.Add(new SqlParameter("@MealId", hoteltariffroomOccupancy.MealId));
            Logger.Debug("HotelTariff Controller MealId:" + hoteltariffroomOccupancy.MealId);

            sqlParams.Add(new SqlParameter("@MealInclusion", hoteltariffroomOccupancy.MealInclusion));
            Logger.Debug("HotelTariff Controller MealInclusion:" + hoteltariffroomOccupancy.MealInclusion);

            sqlParams.Add(new SqlParameter("@RoomInclusion", hoteltariffroomOccupancy.RoomInclusion));
            Logger.Debug("HotelTariff Controller RoomInclusion:" + hoteltariffroomOccupancy.RoomInclusion);

            sqlParams.Add(new SqlParameter("@RoomExclusion", hoteltariffroomOccupancy.RoomExclusion));
            Logger.Debug("HotelTariff Controller RoomExclusion:" + hoteltariffroomOccupancy.RoomExclusion);

            sqlParams.Add(new SqlParameter("@UpdatedDate", hoteltariffroomOccupancy.UpdatedDate));

            sqlParams.Add(new SqlParameter("@UpdatedBy", hoteltariffroomOccupancy.UpdatedBy));

            return sqlParams;
        }

        private HotelTariffRoomOccupancyInfo GetHotelTariffRoomOccupancyValues(DataRow dr)
        {
            HotelTariffRoomOccupancyInfo hoteltariffroomoccupancy = new HotelTariffRoomOccupancyInfo();

            hoteltariffroomoccupancy.HotelTariffRoomOccupancyId = Convert.ToInt32(dr["HotelTariffRoomDetailsId"]);
            hoteltariffroomoccupancy.HotelTariffDurationDetailsId = Convert.ToInt32(dr["HotelTariffDurationDetailsId"]);
            hoteltariffroomoccupancy.HotelTariffId = Convert.ToInt32(dr["HotelTariffId"]);
            hoteltariffroomoccupancy.OccupancyId = Convert.ToInt32(dr["OccupancyId"]);
            hoteltariffroomoccupancy.AgeFrom = Convert.ToDecimal(dr["AgeFrom"]);
            hoteltariffroomoccupancy.AgeTo = Convert.ToDecimal(dr["AgeTo"]);
            hoteltariffroomoccupancy.MealId = Convert.ToInt32(dr["MealId"]);
            hoteltariffroomoccupancy.MealInclusion = Convert.ToString(dr["MealInclusion"]);
            hoteltariffroomoccupancy.RoomInclusion = Convert.ToString(dr["RoomInclusion"]);
            hoteltariffroomoccupancy.RoomExclusion = Convert.ToString(dr["RoomExclusion"]);
            hoteltariffroomoccupancy.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
            hoteltariffroomoccupancy.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            hoteltariffroomoccupancy.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
            hoteltariffroomoccupancy.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            return hoteltariffroomoccupancy;
        }

        #endregion

        #region HotelTariffPriceDuration And Customer Catogories

        public void SaveHotelTariffDurationWithCustomerCategories(List<DateTime> dates, HotelTariffDateDetailsInfo hotelTariffDateDetails, List<HotelTariffCustomerCategoryDetailsInfo> hotelCustomerCategories)
        {
            foreach (var item in dates)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@HotelTariffPriceDetailsId", hotelTariffDateDetails.HotelTariffPriceDetailsId));
                Logger.Debug("SaveHotelTariffDuration HotelTariffPriceDetailsId:" + hotelTariffDateDetails.HotelTariffPriceDetailsId);

                sqlParams.Add(new SqlParameter("@NoOfNight", hotelTariffDateDetails.NoOfNight));
                Logger.Debug("SaveHotelTariffDuration NoOfNight:" + hotelTariffDateDetails.NoOfNight);

                sqlParams.Add(new SqlParameter("@TariffDate", item));
                Logger.Debug("SaveHotelTariffDuration TariffDate:" + item);

                sqlParams.Add(new SqlParameter("@NetRate", hotelTariffDateDetails.NetRate));
                Logger.Debug("SaveHotelTariffDuration NetRate:" + hotelTariffDateDetails.NetRate);

                sqlParams.Add(new SqlParameter("@HotelTariffRoomOccupancyId", hotelTariffDateDetails.HotelTariffRoomOccupancyId));
                Logger.Debug("SaveHotelTariffDuration HotelTariffRoomOccupancyId:" + hotelTariffDateDetails.HotelTariffRoomOccupancyId);

                hotelTariffDateDetails.HotelTariffDatesDetailsId = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spInsertHotelTariffDateDetails.ToString(), CommandType.StoredProcedure));

                foreach (var itm in hotelCustomerCategories)
                {
                    List<SqlParameter> sqlParam = new List<SqlParameter>();

                    sqlParam.Add(new SqlParameter("@HotelTariffDateDetailsId", hotelTariffDateDetails.HotelTariffDatesDetailsId));

                    sqlParam.Add(new SqlParameter("@CustomerCategoryId", itm.CustomerCategoryId));

                    sqlParam.Add(new SqlParameter("@Margin", itm.GlobalMargin));

                    sqlParam.Add(new SqlParameter("@CreatedDate", itm.CreatedDate));

                    sqlParam.Add(new SqlParameter("@CreatedBy", itm.CreatedBy));

                    sqlParam.Add(new SqlParameter("@UpdatedDate", itm.UpdatedDate));

                    sqlParam.Add(new SqlParameter("@UpdatedBy", itm.UpdatedBy));

                    _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spInsertHotelTariffCustomerCategory.ToString(), CommandType.StoredProcedure);
                }

            }
        }

        private HotelTariffDateDetailsInfo GetHotelTariffDateDetailsValues(DataRow dr)
        {
            HotelTariffDateDetailsInfo hoteltariffdatedetails = new HotelTariffDateDetailsInfo();

            //hoteltariffdatedetails.HotelTariffDurationDetailsId = Convert.ToInt32(dr["HotelTariffDurationDetailsId"]);
            //hoteltariffdatedetails.HotelTariffId = Convert.ToInt32(dr["HotelTariffId"]);
            if (dr["NoOfNight"] != DBNull.Value)
            {
                hoteltariffdatedetails.NoOfNight = Convert.ToInt32(dr["NoOfNight"]);
            }

            if (dr["TariffDate"] != DBNull.Value)
            {
                hoteltariffdatedetails.TariffDate = Convert.ToDateTime(dr["TariffDate"]);
            }

            if (dr["NetRate"] != DBNull.Value)
            {
                hoteltariffdatedetails.NetRate = Convert.ToDecimal(dr["NetRate"]);
            }

            if (dr["HotelTariffPriceDetailsId"] != DBNull.Value)
            {
                hoteltariffdatedetails.HotelTariffPriceDetailsId = Convert.ToInt32(dr["HotelTariffPriceDetailsId"]);
            }

            if (dr["HotelTariffRoomOccupancyId"] != DBNull.Value)
            {
                hoteltariffdatedetails.HotelTariffRoomOccupancyId = Convert.ToInt32(dr["HotelTariffRoomOccupancyId"]);
            }

            if (dr["HotelTariffDateDetailsId"] != DBNull.Value)
            {
                hoteltariffdatedetails.HotelTariffDatesDetailsId = Convert.ToInt32(dr["HotelTariffDateDetailsId"]);
            }

            return hoteltariffdatedetails;
        }

        public List<HotelTariffDateDetailsInfo> GetHotelTariffDurationPrice(int hotelTariffRoomOccupancyId)
        {
            List<HotelTariffDateDetailsInfo> HotelTariffDateDetails = new List<HotelTariffDateDetailsInfo>();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            HotelTariffDurationDetailsInfo duration = new HotelTariffDurationDetailsInfo();

            sqlParam.Add(new SqlParameter("@HotelTariffRoomOccupancyId", hotelTariffRoomOccupancyId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetHotelTariffDurationPrice.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    HotelTariffDateDetails.Add(GetHotelTariffDateDetailsValues(dr));
                }
            }

            return HotelTariffDateDetails;
        }

        public List<DateTime> GetFilteredDateForDuration(HotelTariffDurationDetailsInfo hotelTariffDurationDetails)
        {
            List<DateTime> dates = new List<DateTime>();

            foreach (DateTime day in EachDay(hotelTariffDurationDetails.FromDate, hotelTariffDurationDetails.ToDate))
            {
                if (hotelTariffDurationDetails.OperationalDays.Split(',').Contains(day.DayOfWeek.ToString()))
                {
                    dates.Add(day.Date);
                }
            }
            return dates;
        }

        #endregion

        public List<HotelTariffCustomerCategoryDetailsInfo> GetHotelTariffCustomerCategory(int hotelTariffRoomOccupancyId, DateTime tariffDate)
        {
            List<HotelTariffCustomerCategoryDetailsInfo> HotelTariffCustomerCategoryDetails = new List<HotelTariffCustomerCategoryDetailsInfo>();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            HotelTariffDurationDetailsInfo duration = new HotelTariffDurationDetailsInfo();

            sqlParam.Add(new SqlParameter("@HotelTariffRoomOccupancyId", hotelTariffRoomOccupancyId));

            sqlParam.Add(new SqlParameter("@TariffDate", tariffDate));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetHotelTariffCustomerCategoriess.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    HotelTariffCustomerCategoryDetails.Add(GetHotelTariffCustomerCategoryDetailsValues(dr));
                }
            }

            return HotelTariffCustomerCategoryDetails;
        }

        private HotelTariffCustomerCategoryDetailsInfo GetHotelTariffCustomerCategoryDetailsValues(DataRow dr)
        {
            HotelTariffCustomerCategoryDetailsInfo hoteltariffcustomercategorydetails = new HotelTariffCustomerCategoryDetailsInfo();

           
            if (dr["Margin"] != DBNull.Value)
            {
                hoteltariffcustomercategorydetails.TariffMargin = Convert.ToDecimal(dr["Margin"]);
            }

            if (dr["CustomerCategoryName"] != DBNull.Value)
            {
                hoteltariffcustomercategorydetails.CustomerCategoryName = Convert.ToString(dr["CustomerCategoryName"]);
            }

            if (dr["CustomerCategoryId"] != DBNull.Value)
            {
                hoteltariffcustomercategorydetails.CustomerCategoryId = Convert.ToInt32(dr["CustomerCategoryId"]);
            }

            if (dr["HotelTariffDateDetailsId"] != DBNull.Value)
            {
                hoteltariffcustomercategorydetails.HotelTariffDateDetailsId = Convert.ToInt32(dr["HotelTariffDateDetailsId"]);
            }

            if (dr["HotelTariffRoomOccupancyId"] != DBNull.Value)
            {
                hoteltariffcustomercategorydetails.HotelTariffRoomOccupancyId = Convert.ToInt32(dr["HotelTariffRoomOccupancyId"]);
            }

            return hoteltariffcustomercategorydetails;
        }


        #region Customer Category

        public void SaveHotelTariffCustomerCategory(HotelTariffCustomerCategoryDetailsInfo customercategory)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInHotelTariffCustomerCategory(customercategory), Storeprocedures.spInsertHotelTariffCustomerCategory.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> SetValuesInHotelTariffCustomerCategory(HotelTariffCustomerCategoryDetailsInfo customercategory)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@HotelTariffDateDetailsId", customercategory.HotelTariffDateDetailsId));

            sqlParams.Add(new SqlParameter("@CreatedDate", customercategory.CreatedDate));

            sqlParams.Add(new SqlParameter("@CreatedBy", customercategory.CreatedBy));

            sqlParams.Add(new SqlParameter("@CustomerCategoryId", customercategory.CustomerCategoryId));
            Logger.Debug("HotelTariff Controller CustomerCategoryId:" + customercategory.CustomerCategoryId);

            sqlParams.Add(new SqlParameter("@Margin", customercategory.TariffMargin));
            Logger.Debug("HotelTariff Controller Margin:" + customercategory.TariffMargin);

            sqlParams.Add(new SqlParameter("@UpdatedDate", customercategory.UpdatedDate));

            sqlParams.Add(new SqlParameter("@UpdatedBy", customercategory.UpdatedBy));

            return sqlParams;
        }

        //public DataTable GetCustomerCategory(int HotelTariffDateDetailsId, ref PaginationInfo pager)
        public List<HotelTariffCustomerCategoryDetailsInfo> GetCustomerCategory()
        {
            List<HotelTariffCustomerCategoryDetailsInfo> HotelTariffCustomerCategories = new List<HotelTariffCustomerCategoryDetailsInfo>();

            DataTable dt = _sqlHelper.ExecuteDataTable(null, Storeprocedures.spGetHotelTariffCustomerCategory.ToString(), CommandType.StoredProcedure);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    HotelTariffCustomerCategories.Add(GetCustomerCategoriesValues(dr));
                }
            }

            return HotelTariffCustomerCategories;
        }

        private HotelTariffCustomerCategoryDetailsInfo GetCustomerCategoriesValues(DataRow dr)
        {
            HotelTariffCustomerCategoryDetailsInfo CustomerCategory = new HotelTariffCustomerCategoryDetailsInfo();

            if (dr["CustomerCategoryId"] != DBNull.Value)
            {
                CustomerCategory.CustomerCategoryId = Convert.ToInt32(dr["CustomerCategoryId"]);
            }

            CustomerCategory.CustomerCategoryName = Convert.ToString(dr["CustomerCategoryName"]);

            if (dr["GlobalMargin"] != DBNull.Value)
            {
                CustomerCategory.GlobalMargin = Convert.ToInt32(dr["GlobalMargin"]);
            }

            return CustomerCategory;
        }

        public void UpdateCustomerCategory(HotelTariffCustomerCategoryDetailsInfo customercategory)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInHotelTariffCustomerCategory(customercategory), Storeprocedures.spUpdateHotelTariffCustomerCategory.ToString(), CommandType.StoredProcedure);
        }

        public void DeleteCustomerCategory(int hoteltariffdurationdetailsid, int hoteltariffroomdetailsid, int customercategoryid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            HotelTariffCustomerCategoryDetailsInfo customercategory = new HotelTariffCustomerCategoryDetailsInfo();

            sqlParam.Add(new SqlParameter("HotelTariffDurationDetailsId", hoteltariffdurationdetailsid));
            Logger.Debug("HotelTariff Controller HotelTariffDurationDetailsId:" + hoteltariffdurationdetailsid);

            sqlParam.Add(new SqlParameter("HotelTariffRoomDetailsId", hoteltariffroomdetailsid));
            Logger.Debug("HotelTariff Controller HotelTariffRoomDetailsId:" + hoteltariffroomdetailsid);

            sqlParam.Add(new SqlParameter("@HotelTariffCustomerCategoryId", customercategoryid));
            Logger.Debug("HotelTariff Controller HotelTariffCustomerCategoryId:" + customercategoryid);

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteHotelTariffCustomerCategory.ToString(), CommandType.StoredProcedure);

        }


        #endregion

    }
}
