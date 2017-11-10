
using LohanaBusinessEntities;
using LohanaBusinessEntities.Charges;
using LohanaBusinessEntities.City;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Hotel;
using LohanaBusinessEntities.Meal;
using LohanaBusinessEntities.RoomType;
using LohanaBusinessEntities.SupplierHotelTariff;
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

namespace LohanaRepo.Tariff.SupplierHotelTariff
{
    public class SupplierHotelTariffRepo
    {
        SQLHelperRepo _sqlHelper = null;

        public SupplierHotelTariffRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        #region Get DropDown Item

        // Get Vendor Dropdown
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

        // Get Location (cities) Dropdown
        public List<CityInfo> drpGetCities()
        {
            List<CityInfo> cities = new List<CityInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetCities.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cities.Add(GetCityValues(dr));
                }
            }
            return cities;
        }

        public CityInfo GetCityValues(DataRow dr)
        {
            CityInfo retVal = new CityInfo();

            retVal.CityId = Convert.ToInt32(dr["CityId"]);

            retVal.CityName = Convert.ToString(dr["CityName"]);

            return retVal;
        }

        // Get Meal Dropdown

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

        // Get RoomType Dropdown
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

        // Get Hotel Dropdown
        public List<HotelInfo> drpGetHotelsByCity(int LocationId)
        {
            List<HotelInfo> hotel = new List<HotelInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@CityId", LocationId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetHotelsByCity.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    hotel.Add(GetHotelValues(dr));
                }
            }
            return hotel;
        }

        public HotelInfo GetHotelValues(DataRow dr)
        {
            HotelInfo retVal = new HotelInfo();

            retVal.HotelId = Convert.ToInt32(dr["HotelId"]);

            retVal.HotelName = Convert.ToString(dr["HotelName"]);

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

        
        #endregion

        #region Get List
        

        // Get Supplier Hotel Duration
        public DataTable GetSupplierHotelDuration(int supplierHotelId,ref PaginationInfo pager)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@SupplierHotelId", supplierHotelId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spGetSupplierHotelDuration.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        //Get Customer category
        public DataTable GetCustomerCategory(int SupplierHotelDetailId, int SupplierHotelDurationId, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@SupplierHotelDetailId", SupplierHotelDetailId));

            sqlParam.Add(new SqlParameter("@SupplierHotelDurationId", SupplierHotelDurationId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetSupplierHotelCustomerCategory.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }


        #endregion



        #region  Supplier's hotel tariff detail

        public void InsertSupplierHotel(SupplierHotelTariffInfo supplierHotelTariffInfo)
        {
            //_sqlHelper.ExecuteNonQuery(SetValuesInSupplierHotelTariffInfo(supplierHotelTariffInfo), Storeprocedures.spInsertSupplierHotel.ToString(), CommandType.StoredProcedure);

            int id = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInSupplierHotelTariffInfo(supplierHotelTariffInfo), Storeprocedures.spInsertSupplierHotel.ToString(), CommandType.StoredProcedure));

            foreach(var item in supplierHotelTariffInfo.supplierHotelTariffDays)
            {
                item.SupplierHotelId = id;

                _sqlHelper.ExecuteNonQuery(Set_Values_In_SupplierHotelDays(item), Storeprocedures.sp_Insert_SupplierHotelDays.ToString(), CommandType.StoredProcedure);
        }
        }

		public void UpdateSupplierHotel(SupplierHotelTariffInfo supplierHotelTariffInfo)
		{
			_sqlHelper.ExecuteNonQuery(SetValuesInSupplierHotelTariffInfo(supplierHotelTariffInfo), Storeprocedures.spUpdateSupplierHotel.ToString(), CommandType.StoredProcedure);
		}

        public List<SqlParameter> SetValuesInSupplierHotelTariffInfo(SupplierHotelTariffInfo supplierHotelTariff)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (supplierHotelTariff.SupplierHotelId != 0)
            {
                sqlParam.Add(new SqlParameter("@SupplierHotelId", supplierHotelTariff.SupplierHotelId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedDate", supplierHotelTariff.CreatedDate));

                sqlParam.Add(new SqlParameter("@CreatedBy", supplierHotelTariff.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@SupplierId", supplierHotelTariff.SupplierId));

            sqlParam.Add(new SqlParameter("@PackageName", supplierHotelTariff.PackageName));

            sqlParam.Add(new SqlParameter("@IsActive", supplierHotelTariff.IsActive));       

            sqlParam.Add(new SqlParameter("@UpdatedDate", supplierHotelTariff.UpdatedDate));

            sqlParam.Add(new SqlParameter("@UpdatedBy", supplierHotelTariff.UpdatedBy));

            sqlParam.Add(new SqlParameter("@DayDuration", supplierHotelTariff.DayDuration));

            sqlParam.Add(new SqlParameter("@NightDuration", supplierHotelTariff.NightDuration));

            return sqlParam;
        }

		public DataTable GetSupplierHotel(ref PaginationInfo pager)
		{
			List<SupplierHotelTariffInfo> LstSupplierHotelTariff = new List<SupplierHotelTariffInfo>();

			List<SqlParameter> sqlParams = new List<SqlParameter>();

			DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spGetSupplierHotel.ToString(), CommandType.StoredProcedure);

			return CommonMethods.GetPaginatedTable(dt, ref pager);
		}

		#endregion

		#region  Supplier's hotel details

		public void InsertSupplierHotelDetail(SupplierHotelDetailInfo supplierHotelDetailInfo)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInSupplierHotelDetailInfo(supplierHotelDetailInfo), Storeprocedures.spInsertSupplierHotelDetail.ToString(), CommandType.StoredProcedure);
        }

        public void UpdateSupplierHotelDetail(SupplierHotelDetailInfo supplierHotelDetailInfo)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInSupplierHotelDetailInfo(supplierHotelDetailInfo), Storeprocedures.spUpdateSupplierHotelDetail.ToString(), CommandType.StoredProcedure);
        }

		public void DeleteSupplierHotelDetail(int supplierHoteDetaillId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@SupplierHotelDetailId", supplierHoteDetaillId));

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteSupplierHotelDetail.ToString(), CommandType.StoredProcedure);
        }

        public List<SqlParameter> SetValuesInSupplierHotelDetailInfo(SupplierHotelDetailInfo supplierHotelDetailInfo)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (supplierHotelDetailInfo.SupplierHoteDetaillId != 0)
            {
                sqlParam.Add(new SqlParameter("@SupplierHotelDetailId", supplierHotelDetailInfo.SupplierHoteDetaillId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedDate", supplierHotelDetailInfo.CreatedDate));

                sqlParam.Add(new SqlParameter("@CreatedBy", supplierHotelDetailInfo.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@SupplierHotelId", supplierHotelDetailInfo.SupplierHotelId));

            sqlParam.Add(new SqlParameter("@CityId", supplierHotelDetailInfo.CityId));

            sqlParam.Add(new SqlParameter("@HotelId", supplierHotelDetailInfo.HotelId));

            sqlParam.Add(new SqlParameter("@RoomTypeId", supplierHotelDetailInfo.RoomTypeId));

            sqlParam.Add(new SqlParameter("@MealId", supplierHotelDetailInfo.MealId));

            sqlParam.Add(new SqlParameter("@TotalNights", supplierHotelDetailInfo.TotalNights));

            sqlParam.Add(new SqlParameter("@MealInclusions", supplierHotelDetailInfo.MealInclusions));

            sqlParam.Add(new SqlParameter("@UpdatedDate", supplierHotelDetailInfo.UpdatedDate));

            sqlParam.Add(new SqlParameter("@UpdatedBy", supplierHotelDetailInfo.UpdatedBy));

            return sqlParam;
        }

		public DataTable GetSupplierHotelDetail(int SupplierHotelId, ref PaginationInfo pager)
		{
			List<SqlParameter> sqlParams = new List<SqlParameter>();

			sqlParams.Add(new SqlParameter("@SupplierHotelId", SupplierHotelId));

			DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spGetSupplierHotelDetail.ToString(), CommandType.StoredProcedure);

			return CommonMethods.GetPaginatedTable(dt, ref pager);
		}
        
		#endregion

        #region Supplier's hotel Occupancy

        public void InsertSupplierOccupancyDetail(SupplierOccupancyDetailInfo SupplierOccupancyDetail)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInSupplierOccupancyDetailInfo(SupplierOccupancyDetail), Storeprocedures.spInsertSupplierOccupancy.ToString(), CommandType.StoredProcedure);
        }

        public void UpdateSupplierOccupancyDetail(SupplierOccupancyDetailInfo SupplierOccupancyDetail)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInSupplierOccupancyDetailInfo(SupplierOccupancyDetail), Storeprocedures.spUpdateSupplierOccupancy.ToString(), CommandType.StoredProcedure);
        }

        public List<SqlParameter> SetValuesInSupplierOccupancyDetailInfo(SupplierOccupancyDetailInfo SupplierOccupancyDetail)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (SupplierOccupancyDetail.OccupancyDetailId != 0)
            {
                sqlParam.Add(new SqlParameter("@OccupancyDetailId", SupplierOccupancyDetail.OccupancyDetailId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedDate", SupplierOccupancyDetail.CreatedDate));

                sqlParam.Add(new SqlParameter("@CreatedBy", SupplierOccupancyDetail.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@SupplierHotelId", SupplierOccupancyDetail.SupplierHotelId));

            sqlParam.Add(new SqlParameter("@OccupancyId", SupplierOccupancyDetail.OccupancyId));

            sqlParam.Add(new SqlParameter("@AgeFrom", SupplierOccupancyDetail.AgeFrom));

            sqlParam.Add(new SqlParameter("@AgeTo", SupplierOccupancyDetail.AgeTo));

            sqlParam.Add(new SqlParameter("@UpdatedDate", SupplierOccupancyDetail.UpdatedDate));

            sqlParam.Add(new SqlParameter("@UpdatedBy", SupplierOccupancyDetail.UpdatedBy));

            return sqlParam;
        }

        public DataTable GetSupplierOccupancyDetail(int SupplierHotelId, ref PaginationInfo pager)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@SupplierHotelId", SupplierHotelId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spGetSupplierOccupancy.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

       
        








    #endregion

        #region Supplier Hotel Price

        public void InsertSupplierHotelPrice(SupplierHotelPriceInfo supplierHotelPrice)
		{
			supplierHotelPrice.SupplierHotelPriceId = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInSupplierHotelPriceInfo(supplierHotelPrice), Storeprocedures.spInsertSupplierHotelPrice.ToString(), CommandType.StoredProcedure));

			InsertSupplierHotelPriceCharges(supplierHotelPrice);
		}
		
		public void UpdateSupplierHotelPrice(SupplierHotelPriceInfo supplierHotelPrice)
		{
			_sqlHelper.ExecuteNonQuery(SetValuesInSupplierHotelPriceInfo(supplierHotelPrice), Storeprocedures.spUpdateSupplierHotelPrice.ToString(), CommandType.StoredProcedure);

			DeleteSupplierHotelPriceCharges(supplierHotelPrice.SupplierHotelPriceId);

			InsertSupplierHotelPriceCharges(supplierHotelPrice);
		}

        public List<SqlParameter> SetValuesInSupplierHotelPriceInfo(SupplierHotelPriceInfo supplierHotelPriceInfo)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (supplierHotelPriceInfo.SupplierHotelPriceId != 0)
            {
                sqlParam.Add(new SqlParameter("@SupplierHotelPriceId", supplierHotelPriceInfo.SupplierHotelPriceId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedDate", DateTime.Now));

                sqlParam.Add(new SqlParameter("@CreatedBy", 1));
            }

            sqlParam.Add(new SqlParameter("@OccupancyDetailId", supplierHotelPriceInfo.OccupancyDetailId));

            sqlParam.Add(new SqlParameter("@PublishPrice", supplierHotelPriceInfo.PublishPrice));

            sqlParam.Add(new SqlParameter("@SpecialPrice", supplierHotelPriceInfo.SpecialPrice));

            sqlParam.Add(new SqlParameter("@CommissionPrice", supplierHotelPriceInfo.CommissionPrice));

            sqlParam.Add(new SqlParameter("@FormulaId", supplierHotelPriceInfo.FormulaId));

            sqlParam.Add(new SqlParameter("@TotalTaxPrice", supplierHotelPriceInfo.TotalTaxPrice));

            sqlParam.Add(new SqlParameter("@NetRate", supplierHotelPriceInfo.NetRate));

			sqlParam.Add(new SqlParameter("@IsChildPrice", supplierHotelPriceInfo.IsChildPrice));

            sqlParam.Add(new SqlParameter("@AgeFrom", supplierHotelPriceInfo.AgeFrom));

            sqlParam.Add(new SqlParameter("@AgeTo", supplierHotelPriceInfo.AgeTo));

			sqlParam.Add(new SqlParameter("@Color", supplierHotelPriceInfo.Color));

            sqlParam.Add(new SqlParameter("@UpdatedDate", DateTime.Now));

            sqlParam.Add(new SqlParameter("@UpdatedBy", 1));

            return sqlParam;
        }

		public void InsertSupplierHotelPriceCharges(SupplierHotelPriceInfo supplierHotelPrices)
		{
			foreach(var item in supplierHotelPrices.SupplierHotelPriceDetails)
			{
				List<SqlParameter> sqlParam = new List<SqlParameter>();


				sqlParam.Add(new SqlParameter("@SupplierHotelPriceId", supplierHotelPrices.SupplierHotelPriceId));

				sqlParam.Add(new SqlParameter("@ChargesId", item.ChargesId));

				sqlParam.Add(new SqlParameter("@Percentage", item.Percentage));

				sqlParam.Add(new SqlParameter("@CalculatedPrice", item.CalculatedPrice));

				_sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spInsertSupplierHotelChargeDetail.ToString(), CommandType.StoredProcedure);
			}
		}

		public void DeleteSupplierHotelPriceCharges(int supplierHotelPriceId)
		{
			List<SqlParameter> sqlParam = new List<SqlParameter>();

			sqlParam.Add(new SqlParameter("@SupplierHotelPriceId", supplierHotelPriceId));

			_sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteSupplierHotelChargeDetail.ToString(), CommandType.StoredProcedure);

		}

		public List<SupplierHotelPriceInfo> GetSupplierHotelPrice(int OccupancyDetailId)
		{
			List<SqlParameter> sqlParam = new List<SqlParameter>();

			List<SupplierHotelPriceInfo> supplierHotelPrices = new List<SupplierHotelPriceInfo>();

            sqlParam.Add(new SqlParameter("@OccupancyDetailId", OccupancyDetailId));

			DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetSupplierHotelPrice.ToString(), CommandType.StoredProcedure);

			if(dt != null && dt.Rows.Count > 0)
			{
				foreach(DataRow dr in dt.Rows)
				{
					supplierHotelPrices.Add(GetPriceValues(dr));
				}
			}
			return supplierHotelPrices;
		}

		private SupplierHotelPriceInfo GetPriceValues(DataRow dr)
		{
			SupplierHotelPriceInfo supplierhotelprice = new SupplierHotelPriceInfo();

			if(DBNull.Value != dr["SupplierHotelPriceId"])
			{
				supplierhotelprice.SupplierHotelPriceId = Convert.ToInt32(dr["SupplierHotelPriceId"]);
			}

            if (DBNull.Value != dr["OccupancyDetailId"])
			{
                supplierhotelprice.OccupancyDetailId = Convert.ToInt32(dr["OccupancyDetailId"]);
			}

			if(DBNull.Value != dr["PublishPrice"])
			{
				supplierhotelprice.PublishPrice = Convert.ToDecimal(dr["PublishPrice"]);
			}

			if(DBNull.Value != dr["SpecialPrice"])
			{
				supplierhotelprice.SpecialPrice = Convert.ToDecimal(dr["SpecialPrice"]);
			}

			if(DBNull.Value != dr["CommissionPrice"])
			{
				supplierhotelprice.CommissionPrice = Convert.ToDecimal(dr["CommissionPrice"]);
			}

			if(DBNull.Value != dr["FormulaId"])
			{
				supplierhotelprice.FormulaId = Convert.ToInt32(dr["FormulaId"]);
			}

			if(DBNull.Value != dr["TotalTaxPrice"])
			{
				supplierhotelprice.TotalTaxPrice = Convert.ToDecimal(dr["TotalTaxPrice"]);
			}

			if(DBNull.Value != dr["NetRate"])
			{
				supplierhotelprice.NetRate = Convert.ToDecimal(dr["NetRate"]);
			}

			if(DBNull.Value != dr["IsChildPrice"])
			{
				supplierhotelprice.IsChildPrice = Convert.ToBoolean(dr["IsChildPrice"]);
			}

			if(DBNull.Value != dr["AgeFrom"])
			{
				supplierhotelprice.AgeFrom = Convert.ToInt32(dr["AgeFrom"]);
			}

			if(DBNull.Value != dr["AgeTo"])
			{
				supplierhotelprice.AgeTo = Convert.ToInt32(dr["AgeTo"]);
			}

			supplierhotelprice.Color = Convert.ToString(dr["Color"]);

			supplierhotelprice.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);

			supplierhotelprice.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

			supplierhotelprice.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);

			supplierhotelprice.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

			return supplierhotelprice;
		}

		public SupplierHotelPriceInfo GetSupplierHotelPriceById(int supplierHotelPriceId)
		{
			List<SqlParameter> sqlParam = new List<SqlParameter>();

			SupplierHotelPriceInfo supplierHotelPrice = new SupplierHotelPriceInfo();

			sqlParam.Add(new SqlParameter("@SupplierHotelPriceId", supplierHotelPriceId));

			DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetSupplierHotelPriceById.ToString(), CommandType.StoredProcedure);

			if(dt != null && dt.Rows.Count > 0)
			{
				foreach(DataRow dr in dt.Rows)
				{
					supplierHotelPrice = GetPriceValues(dr);
				}
			}
			return supplierHotelPrice;
		}

		public List<TaxFormulaChargesInfo> GetSupplierHotelTaxFormulaChargesByPriceId(int taxFormulaId, int supplierHotelPriceId, ref PaginationInfo pager)
		{
			List<TaxFormulaChargesInfo> taxFormulaChargesInfo = new List<TaxFormulaChargesInfo>();

			List<SqlParameter> sqlParam = new List<SqlParameter>();

			sqlParam.Add(new SqlParameter("@TaxFormulaId", taxFormulaId));

			sqlParam.Add(new SqlParameter("@SupplierHotelPriceId", supplierHotelPriceId));


			DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetSupplierHotelTaxFormulaChargesByPriceId.ToString(), CommandType.StoredProcedure);

			foreach(DataRow dr in dt.Rows)
			{
				taxFormulaChargesInfo.Add(GetHotelTariffTaxFormulaCharges(dr));
			}

			return taxFormulaChargesInfo;
		}

		private TaxFormulaChargesInfo GetHotelTariffTaxFormulaCharges(DataRow dr)
		{
			TaxFormulaChargesInfo taxFormulaCharges = new TaxFormulaChargesInfo();

			if(dr["ChargesId"] != DBNull.Value)
			{
				taxFormulaCharges.ChargesId = Convert.ToInt32(dr["ChargesId"]);
			}

			if(dr["ChargesName"] != DBNull.Value)
			{
				taxFormulaCharges.ChargesName = Convert.ToString(dr["ChargesName"]);
			}

			if(dr["ChargeFormula"] != DBNull.Value)
			{
				taxFormulaCharges.ChargeFormula = Convert.ToString(dr["ChargeFormula"]);
			}

			if(dr["ChargeFormulaText"] != DBNull.Value)
			{
				taxFormulaCharges.ChargeFormulaText = Convert.ToString(dr["ChargeFormulaText"]);
			}
			if(dr["Percentage"] != DBNull.Value)
			{
				taxFormulaCharges.HotelTariffCharge.Percentage = Convert.ToDecimal(dr["Percentage"]);
			}

			if(dr["CalculatedPrice"] != DBNull.Value)
			{
				taxFormulaCharges.HotelTariffCharge.CalculatedPrice = Convert.ToDecimal(dr["CalculatedPrice"]);
			}
			if(dr["TotalTaxPrice"] != DBNull.Value)
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

        #region SupplierHotelTariffPriceDuration And Customer Catogories

        public void SaveSupplierHotelTariffDurationWithCustomerCategories(List<DateTime> dates, SupplierHotelTariffDurationInfo SupplierHotelTariffDuration, List<SupplierHotelCustomerCategoryInfo> SupplierHotelCustomerCategories)
        {
            foreach (var item in dates)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@SupplierHotelPriceId", SupplierHotelTariffDuration.SupplierHotelPriceId));
                Logger.Debug("SaveSupplierHotelTariffDuration SupplierHotelPriceId:" + SupplierHotelTariffDuration.SupplierHotelPriceId);

                //sqlParams.Add(new SqlParameter("@NoOfNight", hotelTariffDateDetails.NoOfNight));
                //Logger.Debug("SaveHotelTariffDuration NoOfNight:" + hotelTariffDateDetails.NoOfNight);

                sqlParams.Add(new SqlParameter("@TariffDate", item));
                Logger.Debug("SaveHotelTariffDuration TariffDate:" + item);

                sqlParams.Add(new SqlParameter("@NetRate", SupplierHotelTariffDuration.NetRate));
                Logger.Debug("SaveSupplierHotelTariffDuration NetRate:" + SupplierHotelTariffDuration.NetRate);

                sqlParams.Add(new SqlParameter("@OccupancyDetailId", SupplierHotelTariffDuration.OccupancyDetailId));
                Logger.Debug("SaveSupplierHotelTariffDuration OccupancyDetailId:" + SupplierHotelTariffDuration.OccupancyDetailId);

                SupplierHotelTariffDuration.SupplierHotelDurationId = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spInsertSupplierHotelTariffDuration.ToString(), CommandType.StoredProcedure));

                foreach (var itm in SupplierHotelCustomerCategories)
                {
                    List<SqlParameter> sqlParam = new List<SqlParameter>();

                    sqlParam.Add(new SqlParameter("@SupplierHotelDurationId", SupplierHotelTariffDuration.SupplierHotelDurationId));

                    sqlParam.Add(new SqlParameter("@CustomerCategoryId", itm.CustomerCategoryId));

                    sqlParam.Add(new SqlParameter("@Margin", itm.Margin));

                    sqlParam.Add(new SqlParameter("@CreatedDate", itm.CreatedDate));

                    sqlParam.Add(new SqlParameter("@CreatedBy", itm.CreatedBy));

                    sqlParam.Add(new SqlParameter("@UpdatedDate", itm.UpdatedDate));

                    sqlParam.Add(new SqlParameter("@UpdatedBy", itm.UpdatedBy));

                    _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spInsertSupplierHotelTariffCustomerCategory.ToString(), CommandType.StoredProcedure);
                }

            }
        }

        private SupplierHotelTariffDurationInfo GetSupplierHotelTariffDurationValues(DataRow dr)
        {
            SupplierHotelTariffDurationInfo SupplierHotelTariff = new SupplierHotelTariffDurationInfo();

            //hoteltariffdatedetails.HotelTariffDurationDetailsId = Convert.ToInt32(dr["HotelTariffDurationDetailsId"]);
            //hoteltariffdatedetails.HotelTariffId = Convert.ToInt32(dr["HotelTariffId"]);
            //if (dr["NoOfNight"] != DBNull.Value)
            //{
            //    hoteltariffdatedetails.NoOfNight = Convert.ToInt32(dr["NoOfNight"]);
            //}

            if (dr["TariffDate"] != DBNull.Value)
            {
                SupplierHotelTariff.TariffDate = Convert.ToDateTime(dr["TariffDate"]);
            }

            if (dr["NetRate"] != DBNull.Value)
            {
                SupplierHotelTariff.NetRate = Convert.ToDecimal(dr["NetRate"]);
            }

            if (dr["SupplierHotelPriceId"] != DBNull.Value)
            {
                SupplierHotelTariff.SupplierHotelPriceId = Convert.ToInt32(dr["SupplierHotelPriceId"]);
            }

            if (dr["OccupancyDetailId"] != DBNull.Value)
            {
                SupplierHotelTariff.OccupancyDetailId = Convert.ToInt32(dr["OccupancyDetailId"]);
            }

            return SupplierHotelTariff;
        }

        public List<SupplierHotelTariffDurationInfo> GetSupplierHotelTariffDurationPrice(int OccupancyDetailId)
        {
            List<SupplierHotelTariffDurationInfo> SupplierHotelTariff = new List<SupplierHotelTariffDurationInfo>();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            SupplierHotelDurationInfo duration = new SupplierHotelDurationInfo();

            sqlParam.Add(new SqlParameter("@OccupancyDetailId", OccupancyDetailId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetSupplierHotelTariffDurationPrice.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SupplierHotelTariff.Add(GetSupplierHotelTariffDurationValues(dr));
                }
            }

            return SupplierHotelTariff;
        }

        public List<DateTime> GetFilteredDateForDuration(SupplierHotelDurationInfo supplierhotelTariffDurationDetails)
        {
            List<DateTime> dates = new List<DateTime>();

            foreach (DateTime day in EachDay(supplierhotelTariffDurationDetails.FromDate, supplierhotelTariffDurationDetails.ToDate))
            {
                if (supplierhotelTariffDurationDetails.OperationalDays.Split(',').Contains(day.DayOfWeek.ToString()))
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


        #endregion

        #region CustomerCategory View

        public List<SupplierHotelCustomerCategoryInfo> GetSupplierHotelTariffCustomerCategory(int SupplierHotelPriceId, DateTime TariffDate)
         
        {

        List<SupplierHotelCustomerCategoryInfo> SupplierHotelCustomers = new List<SupplierHotelCustomerCategoryInfo>();

         List<SqlParameter> sqlParam = new List<SqlParameter>();

        SupplierHotelDurationInfo duration = new SupplierHotelDurationInfo();

        sqlParam.Add(new SqlParameter("@SupplierHotelPriceId", SupplierHotelPriceId));

         sqlParam.Add (new SqlParameter("@TariffDate", TariffDate));

         DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetSupplierHotelTariffCustomerCategoriess.ToString(), CommandType.StoredProcedure);

         if (dt != null && dt.Rows.Count > 0)

        foreach (DataRow dr in dt.Rows)
                {
                   SupplierHotelCustomers.Add(GetSupplierHotelCustomersValues(dr));
                }

    return SupplierHotelCustomers;
}

        private SupplierHotelCustomerCategoryInfo GetSupplierHotelCustomersValues(DataRow dr)
        {
            SupplierHotelCustomerCategoryInfo supplierhotelcustomer = new SupplierHotelCustomerCategoryInfo();

            if (dr["Margin"] != DBNull.Value)
            {
                supplierhotelcustomer.Margin = Convert.ToDecimal(dr["Margin"]);
            }

            if (dr["CustomerCategoryName"] != DBNull.Value)
            {
                supplierhotelcustomer.CustomerCategoryName = Convert.ToString(dr["CustomerCategoryName"]);
            }

            if (dr["CustomerCategoryId"] != DBNull.Value)
            {
                supplierhotelcustomer.CustomerCategoryId = Convert.ToInt32(dr["CustomerCategoryId"]);
            }

            if (dr["SupplierHotelDurationId"] != DBNull.Value)
            {
                supplierhotelcustomer.SupplierHotelDurationId = Convert.ToInt32(dr["SupplierHotelDurationId"]);
            }

            //if (dr["SupplierHotelPriceId"] != DBNull.Value)
            //{
            //    supplierhotelcustomer.SupplierHotelPriceId = Convert.ToInt32(dr["SupplierHotelPriceId"]);
            //}

            return supplierhotelcustomer;
        }


        #endregion

        #region Supplier Hotel Days

        public void Update_SupplierHotelDay(SupplierHotelTariffDayInfo SupplierHotelTariffDayInfo)
        {
            _sqlHelper.ExecuteNonQuery(Set_Values_In_SupplierHotelDays(SupplierHotelTariffDayInfo), Storeprocedures.sp_Update_SupplierHotelDays.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_SupplierHotelDays(SupplierHotelTariffDayInfo SupplierHotelTariffDayInfo)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (SupplierHotelTariffDayInfo.SupplierHotelDayId != 0)
            {
                sqlParams.Add(new SqlParameter("@SupplierHotelDayId", SupplierHotelTariffDayInfo.SupplierHotelDayId));
            }

            sqlParams.Add(new SqlParameter("@SupplierHotelId", SupplierHotelTariffDayInfo.SupplierHotelId));
            sqlParams.Add(new SqlParameter("@CityId", SupplierHotelTariffDayInfo.CityId));
            sqlParams.Add(new SqlParameter("@Title", SupplierHotelTariffDayInfo.Title));


            if (SupplierHotelTariffDayInfo.SupplierHotelDayId == 0)
            {
                sqlParams.Add(new SqlParameter("@IsActive", SupplierHotelTariffDayInfo.IsActive));
                sqlParams.Add(new SqlParameter("@CreatedDate", SupplierHotelTariffDayInfo.CreatedDate));
                sqlParams.Add(new SqlParameter("@CreatedBy", SupplierHotelTariffDayInfo.CreatedBy));
            }

            sqlParams.Add(new SqlParameter("@UpdatedDate", SupplierHotelTariffDayInfo.UpdatedDate));
            sqlParams.Add(new SqlParameter("@UpdatedBy", SupplierHotelTariffDayInfo.UpdatedBy));

            return sqlParams;
        }


        public List<SupplierHotelTariffDayInfo> Get_SupplierHotelTariffDays(int supplierHotelId)
        {
            List<SupplierHotelTariffDayInfo> supplierhoteldayss = new List<SupplierHotelTariffDayInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@SupplierHotelId", supplierHotelId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_SupplierHotelDays.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    supplierhoteldayss.Add(Get_SupplierHotelDays_Values(dr));
                }
            }

            return supplierhoteldayss;
        }

        private SupplierHotelTariffDayInfo Get_SupplierHotelDays_Values(DataRow dr)
        {
            SupplierHotelTariffDayInfo supplierhoteldays = new SupplierHotelTariffDayInfo();

            //List<SupplierHotelDayItemInfo> ItemInfoList = new List<SupplierHotelDayItemInfo>();

            supplierhoteldays.SupplierHotelDayId = Convert.ToInt32(dr["SupplierHotelDayId"]);
            supplierhoteldays.SupplierHotelId = Convert.ToInt32(dr["SupplierHotelId"]);
            supplierhoteldays.CityId = Convert.ToInt32(dr["CityId"]);
            supplierhoteldays.Title = Convert.ToString(dr["Title"]);
            supplierhoteldays.IsActive = Convert.ToBoolean(dr["IsActive"]);
            supplierhoteldays.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
            supplierhoteldays.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            supplierhoteldays.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
            supplierhoteldays.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            supplierhoteldays.supplierHotelDayItems = Get_SupplierHotelTariffDayItems(supplierhoteldays.SupplierHotelDayId);

            return supplierhoteldays;
        }


        public List<SupplierHotelDayItemInfo> Get_SupplierHotelTariffDayItems(int SupplierHotelDayId)
        {
            List<SupplierHotelDayItemInfo> supplierhoteldayitems = new List<SupplierHotelDayItemInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@SupplierHotelDayId", SupplierHotelDayId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_SupplierHotelDayItems.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    supplierhoteldayitems.Add(Get_SupplierHotelTariffDayItems_Values(dr));
                }
            }

            return supplierhoteldayitems;
        }

        private SupplierHotelDayItemInfo Get_SupplierHotelTariffDayItems_Values(DataRow dr)
        {
            SupplierHotelDayItemInfo supplierhoteldayitem = new SupplierHotelDayItemInfo();

            supplierhoteldayitem.SupplierHotelDayItemId = Convert.ToInt32(dr["SupplierHotelDayItemId"]);
            supplierhoteldayitem.SupplierHotelDayId = Convert.ToInt32(dr["SupplierHotelDayId"]);
            supplierhoteldayitem.RefType = Convert.ToInt32(dr["RefType"]);
            supplierhoteldayitem.HotelId = Convert.ToInt32(dr["HotelId"]);
            supplierhoteldayitem.RoomTypeId = Convert.ToInt32(dr["RoomTypeId"]);
            supplierhoteldayitem.SightSeeingId = Convert.ToInt32(dr["SightSeeingId"]);
            supplierhoteldayitem.VehicleId = Convert.ToInt32(dr["VehicleId"]);
            supplierhoteldayitem.MealId = Convert.ToInt32(dr["MealId"]);
            supplierhoteldayitem.HotelName = Convert.ToString(dr["HotelName"]);
            supplierhoteldayitem.SightSeeingName = Convert.ToString(dr["SightSeeingName"]);
            supplierhoteldayitem.VehicleName = Convert.ToString(dr["VehicleName"]);
            supplierhoteldayitem.MealName = Convert.ToString(dr["MealName"]);
            supplierhoteldayitem.RoomTypeName = Convert.ToString(dr["RoomTypeName"]);
            supplierhoteldayitem.IsActive = Convert.ToBoolean(dr["IsActive"]);
            supplierhoteldayitem.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
            supplierhoteldayitem.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            supplierhoteldayitem.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
            supplierhoteldayitem.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            return supplierhoteldayitem;
        }


        public void Insert_SupplierHotelDayItem(SupplierHotelDayItemInfo supplierhoteldayitem)
        {
            _sqlHelper.ExecuteNonQuery(Set_Values_In_SupplierHotelDayItem(supplierhoteldayitem), Storeprocedures.sp_Insert_SupplierHotelDayItem.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_SupplierHotelDayItem(SupplierHotelDayItemInfo supplierhoteldayitem)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            if (supplierhoteldayitem.SupplierHotelDayItemId != 0)
            {
                sqlParams.Add(new SqlParameter("@SupplierHotelDayItemId", supplierhoteldayitem.SupplierHotelDayItemId));
            }
         
            sqlParams.Add(new SqlParameter("@SupplierHotelDayId", supplierhoteldayitem.SupplierHotelDayId));

            if (supplierhoteldayitem.HotelId != 0)
            {
                sqlParams.Add(new SqlParameter("@RefType", (int)SupplierTariffItem.Hotel));
            }
            else if (supplierhoteldayitem.SightSeeingId != 0)
            {
                sqlParams.Add(new SqlParameter("@RefType", (int)SupplierTariffItem.SightSeeing));
            }
            else if (supplierhoteldayitem.VehicleId != 0)
            {
                sqlParams.Add(new SqlParameter("@RefType", (int)SupplierTariffItem.Vehicle));
            }
            else if (supplierhoteldayitem.MealId != 0)
            {
                sqlParams.Add(new SqlParameter("@RefType", (int)SupplierTariffItem.Meal));
            }
            else { 
            
            }
  
            sqlParams.Add(new SqlParameter("@HotelId", supplierhoteldayitem.HotelId));
            sqlParams.Add(new SqlParameter("@RoomTypeId", supplierhoteldayitem.RoomTypeId));
            sqlParams.Add(new SqlParameter("@SightSeeingId", supplierhoteldayitem.SightSeeingId));
            sqlParams.Add(new SqlParameter("@VehicleId", supplierhoteldayitem.VehicleId));
            sqlParams.Add(new SqlParameter("@MealId", supplierhoteldayitem.MealId));
            sqlParams.Add(new SqlParameter("@IsActive", supplierhoteldayitem.IsActive));
            sqlParams.Add(new SqlParameter("@CreatedDate", supplierhoteldayitem.CreatedDate));
            sqlParams.Add(new SqlParameter("@CreatedBy", supplierhoteldayitem.CreatedBy));
            sqlParams.Add(new SqlParameter("@UpdatedDate", supplierhoteldayitem.UpdatedDate));
            sqlParams.Add(new SqlParameter("@UpdatedBy", supplierhoteldayitem.UpdatedBy));
            return sqlParams;
        }



        public void DeleteDayItem(int SupplierHotelDayItemId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@SupplierHotelDayItemId", SupplierHotelDayItemId));

            _sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.spDeleteSupplierDayItems.ToString(), CommandType.StoredProcedure);
        }
        #endregion



    }
}
