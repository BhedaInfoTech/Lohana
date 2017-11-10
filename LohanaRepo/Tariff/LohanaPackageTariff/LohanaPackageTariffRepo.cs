using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Hotel;
using LohanaBusinessEntities.LohanaPackageTariff;
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

namespace LohanaRepo.Tariff.LohanaPackageTariff
{
    public class LohanaPackageTariffRepo
    {
        SQLHelperRepo _sqlHelper = null;

        public LohanaPackageTariffRepo()
		{
			_sqlHelper = new SQLHelperRepo();
		}

        #region Basic

        public int InsertLohanaPackageTariff(LohanaPackageTariffInfo lohanapackagetariff)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInLohanaPackageTariff(lohanapackagetariff), Storeprocedures.spInsertLohanaPackageTariffBasic.ToString(), CommandType.StoredProcedure));
        }

        private List<SqlParameter> SetValuesInLohanaPackageTariff(LohanaPackageTariffInfo lohanapackagetariff)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (lohanapackagetariff.LohanaPackageTariffId != 0)
            {
                sqlParams.Add(new SqlParameter("@LohanaPackageTariffId", lohanapackagetariff.LohanaPackageTariffId));
            }
            else 
            {
                sqlParams.Add(new SqlParameter("@CreatedDate", lohanapackagetariff.CreatedDate));

                sqlParams.Add(new SqlParameter("@CreatedBy", lohanapackagetariff.CreatedBy));
            }

            sqlParams.Add(new SqlParameter("@PackageTypeId", lohanapackagetariff.PackageTypeId));

            sqlParams.Add(new SqlParameter("@PackageName", lohanapackagetariff.PackageName));

            sqlParams.Add(new SqlParameter("@DayDuration", lohanapackagetariff.DayDuration));

            sqlParams.Add(new SqlParameter("@NightDuration", lohanapackagetariff.NightDuration));

            sqlParams.Add(new SqlParameter("@IsActive", lohanapackagetariff.IsActive));
          
            sqlParams.Add(new SqlParameter("@UpdatedDate", lohanapackagetariff.UpdatedDate));

            sqlParams.Add(new SqlParameter("@UpdatedBy", lohanapackagetariff.UpdatedBy));

            return sqlParams;
        }

        public DataTable GetLohanaPackageTariff(string packagename, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageName", packagename));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetLohanaPackageTariffBasic.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }

        public void UpdateLohanaPackageTariff(LohanaPackageTariffInfo lohanapackagetariff)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInLohanaPackageTariff(lohanapackagetariff), Storeprocedures.spUpdateLohanaPackageTariffBasic.ToString(), CommandType.StoredProcedure);
        }

        #endregion

        #region Hotel details

        public DataTable GetHotelListing(int cityid,int hotelid,int roomtypeid,int mealid,ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@CityId",cityid));

            sqlParam.Add(new SqlParameter("@HotelId",hotelid));

            sqlParam.Add(new SqlParameter("@RoomTypeId",roomtypeid));

            sqlParam.Add(new SqlParameter("@MealId",mealid));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetLohanaPackageTariffHotelListing.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }

        public HotelInfo GetHotelValues(DataRow dr)
        {
            HotelInfo retVal = new HotelInfo();

            retVal.HotelId = Convert.ToInt32(dr["HotelId"]);

            retVal.HotelName = Convert.ToString(dr["HotelName"]);

            return retVal;
        }

        public List<HotelInfo> GetHotelsDrp(int CityId)
        {
            List<HotelInfo> Hotels = new List<HotelInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@CityId", CityId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetHotelsByCity.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Hotels.Add(GetHotelValues(dr));
                }
            }
            return Hotels;
        }

        public int InsertLohanaPackageTariffHotel(LohanaPackageTariffHotelInfo lohanapackagetariffhotel)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInLohanaPackageTariffHotel(lohanapackagetariffhotel), Storeprocedures.spInsertLohanaPackageTariffHotel.ToString(), CommandType.StoredProcedure));
        }

        private List<SqlParameter> SetValuesInLohanaPackageTariffHotel(LohanaPackageTariffHotelInfo lohanapackagetariffhotel)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (lohanapackagetariffhotel.LohanaPackageTariffHotelId != 0)
            {
                sqlParams.Add(new SqlParameter("@LohanaPackageTariffHotelId", lohanapackagetariffhotel.LohanaPackageTariffHotelId));

            }
            else 
            {
                sqlParams.Add(new SqlParameter("@CreatedDate", lohanapackagetariffhotel.CreatedDate));

                sqlParams.Add(new SqlParameter("@CreatedBy", lohanapackagetariffhotel.CreatedBy));
            }
            sqlParams.Add(new SqlParameter("@LohanaPackageTariffId", lohanapackagetariffhotel.LohanaPackageTariffId));

            //sqlParams.Add(new SqlParameter("@HotelTariffRoomOccupancyId", lohanapackagetariffhotel.HotelTariffRoomOccupancyId));

            if (lohanapackagetariffhotel.LohanaPackageTariffTypeId != (int)LohanaBusinessEntities.Common.EnumCollection.LohanaPackageTariffType.LohanaPackageTariffHotel)
            {
                sqlParams.Add(new SqlParameter("@RefId", lohanapackagetariffhotel.HotelTariffRoomDetailsId)); 
            }
            else
            {
                sqlParams.Add(new SqlParameter("@RefId", lohanapackagetariffhotel.SupplierHotelDetailId)); 
            }

            sqlParams.Add(new SqlParameter("@NoOfNight", lohanapackagetariffhotel.NoOfNight));
       
            sqlParams.Add(new SqlParameter("@UpdatedDate", lohanapackagetariffhotel.UpdatedDate));

            sqlParams.Add(new SqlParameter("@UpdatedBy", lohanapackagetariffhotel.UpdatedBy));

            return sqlParams;
        }

        public DataTable GetLohanaPackageTariffHotel(int hoteltariffroomdetailsid,int noofnight,int lohanapackagetariffid, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@HotelTariffRoomDetailsId", hoteltariffroomdetailsid));

            //sqlParam.Add(new SqlParameter("@NoOfNight", noofnight));

            sqlParam.Add(new SqlParameter("@LohanaPackageTariffId", lohanapackagetariffid));


            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetLohanaPackageTariffHotel.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }

        public void UpdateLohanaPackageTariffHotel(LohanaPackageTariffHotelInfo lohanapackagetariffhotel)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInLohanaPackageTariffHotel(lohanapackagetariffhotel), Storeprocedures.spUpdateLohanaPackageTariffHotel.ToString(), CommandType.StoredProcedure);
        }

        public void DeleteLohanaPackageTariffHotel(int lohanapackagetariffid, int lohanapackagetariffhotelid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            LohanaPackageTariffHotelInfo lohanapackagetariffhotel = new LohanaPackageTariffHotelInfo();

            sqlParam.Add(new SqlParameter("@LohanaPackageTariffId", lohanapackagetariffid));

            Logger.Debug("LohanaPackageTariff Controller LohanaPackageTariffId:" + lohanapackagetariffid);

            sqlParam.Add(new SqlParameter("@LohanaPackageTariffHotelId", lohanapackagetariffhotelid));

            Logger.Debug("LohanaPackageTariff Controller LohanaPackageTariffHotelId:" + lohanapackagetariffhotelid);

            //sqlParam.Add(new SqlParameter("@HotelTariffRoomOccupancyId", hoteltariffroomoccupancyid));

            //Logger.Debug("LohanaPackageTariff Controller HotelTariffRoomOccupancyId:" + hoteltariffroomoccupancyid);

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteLohanaPackageTariffHotel.ToString(), CommandType.StoredProcedure);


        }

        #endregion

        #region Vehicle Details

        public DataTable GetVehicleListing(int vendorid, int vehicleid, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@VendorId", vendorid));

            sqlParam.Add(new SqlParameter("@VehicleId", vehicleid));       

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetLohanaPackageTariffVehicleListing.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }

        public int InsertLohanaPackageTariffVehicle(LohanaPackageTariffVehicleInfo lohanapackagetariffvehicle)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInLohanaPackageTariffVehicle(lohanapackagetariffvehicle), Storeprocedures.spInsertLohanaPackageTariffVehicle.ToString(), CommandType.StoredProcedure));
        }

        private List<SqlParameter> SetValuesInLohanaPackageTariffVehicle(LohanaPackageTariffVehicleInfo lohanapackagetariffvehicle)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (lohanapackagetariffvehicle.LohanaPackageTariffVehicleId != 0)
            {
                sqlParams.Add(new SqlParameter("@LohanaPackageTariffVehicleId", lohanapackagetariffvehicle.LohanaPackageTariffVehicleId));

            }
            else
            {
                sqlParams.Add(new SqlParameter("@CreatedDate", lohanapackagetariffvehicle.CreatedDate));

                sqlParams.Add(new SqlParameter("@CreatedBy", lohanapackagetariffvehicle.CreatedBy));
            }
            sqlParams.Add(new SqlParameter("@LohanaPackageTariffId", lohanapackagetariffvehicle.LohanaPackageTariffId));

            sqlParams.Add(new SqlParameter("@VehicleTariffId", lohanapackagetariffvehicle.VehicleTariffId));

            sqlParams.Add(new SqlParameter("@VehicleId", lohanapackagetariffvehicle.VehicleId));

            sqlParams.Add(new SqlParameter("@NoOfNight", lohanapackagetariffvehicle.NoOfNight));

            sqlParams.Add(new SqlParameter("@UpdatedDate", lohanapackagetariffvehicle.UpdatedDate));

            sqlParams.Add(new SqlParameter("@UpdatedBy", lohanapackagetariffvehicle.UpdatedBy));

            return sqlParams;
        }

        public DataTable GetLohanaPackageTariffVehicle(int LohanaPackageTariffId, int VehicleTariffId,int VehicleTariffPriceDetailsId, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@LohanaPackageTariffId", LohanaPackageTariffId));

            sqlParam.Add(new SqlParameter("@VehicleTariffId", VehicleTariffId));

            sqlParam.Add(new SqlParameter("@VehicleTariffPriceDetailsId", VehicleTariffPriceDetailsId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetLohanaPackageTariffVehicle.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }

        public void UpdateLohanaPackageTariffVehicle(LohanaPackageTariffVehicleInfo lohanapackagetariffvehicle)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInLohanaPackageTariffVehicle(lohanapackagetariffvehicle), Storeprocedures.spUpdateLohanaPackageTariffVehicle.ToString(), CommandType.StoredProcedure);
        }

        public void DeleteLohanaPackageTariffVehicle(int lohanapackagetariffid,int lohanapackagetariffvehicleid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            LohanaPackageTariffVehicleInfo lohanapackagetariffvehicle = new LohanaPackageTariffVehicleInfo();

            sqlParam.Add(new SqlParameter("@LohanaPackageTariffId", lohanapackagetariffid));

            Logger.Debug("LohanaPackageTariff Controller LohanaPackageTariffId:" + lohanapackagetariffid);        

            sqlParam.Add(new SqlParameter("@LohanaPackageTariffVehicleId", lohanapackagetariffvehicleid));

            Logger.Debug("LohanaPackageTariff Controller LohanaPackageTariffVehicleId:" + lohanapackagetariffvehicleid);

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteLohanaPackageTariffVehicle.ToString(), CommandType.StoredProcedure);


        }

        #endregion

        #region Root Details

        public int InsertLohanaPackageTariffRootDetail(LohanaPackageTariffRootInfo lohanapackagetariffroot)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInLohanaPackageTariffRootDetail(lohanapackagetariffroot), Storeprocedures.spInsertLohanaPackageTariffRootDetails.ToString(), CommandType.StoredProcedure));
        }

        public void UpdateLohanaPackageTariffRootTitle(LohanaPackageTariffRootInfo lohanapackagetariffroot)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInLohanaPackageTariffRoot(lohanapackagetariffroot), Storeprocedures.spUpdateLohanaPackageTariffRootTitle.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> SetValuesInLohanaPackageTariffRoot(LohanaPackageTariffRootInfo lohanapackagetariffroot)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (lohanapackagetariffroot.LohanaPackageTariffRootId != 0)
            {
                sqlParams.Add(new SqlParameter("@LohanaPackageTariffRootId", lohanapackagetariffroot.LohanaPackageTariffRootId));
                sqlParams.Add(new SqlParameter("@Title", lohanapackagetariffroot.Title));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@CreatedDate", lohanapackagetariffroot.CreatedDate));
                sqlParams.Add(new SqlParameter("@CreatedBy", lohanapackagetariffroot.CreatedBy));
            }
            sqlParams.Add(new SqlParameter("@UpdatedDate", lohanapackagetariffroot.UpdatedDate));
            sqlParams.Add(new SqlParameter("@UpdatedBy", lohanapackagetariffroot.UpdatedBy));

            return sqlParams;
        }

        private List<SqlParameter> SetValuesInLohanaPackageTariffRootDetail(LohanaPackageTariffRootInfo lohanapackagetariffroot)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@LohanaPackageTariffRootId", lohanapackagetariffroot.LohanaPackageTariffRootId));
            sqlParams.Add(new SqlParameter("@LohanaPackageTariffId", lohanapackagetariffroot.LohanaPackageTariffId));
            sqlParams.Add(new SqlParameter("@LohanaPackageTariffRefId", lohanapackagetariffroot.LohanaPackageTariffRefId));
            sqlParams.Add(new SqlParameter("@LohanaPackageTariffTypeId", lohanapackagetariffroot.LohanaPackageTariffTypeId));
            
            sqlParams.Add(new SqlParameter("@CreatedDate", lohanapackagetariffroot.CreatedDate));
            sqlParams.Add(new SqlParameter("@CreatedBy", lohanapackagetariffroot.CreatedBy));
            sqlParams.Add(new SqlParameter("@UpdatedDate", lohanapackagetariffroot.UpdatedDate));
            sqlParams.Add(new SqlParameter("@UpdatedBy", lohanapackagetariffroot.UpdatedBy));

            return sqlParams;
        }

        public DataSet GetLohanaPackageTariffRootList(int lohanaPackageTariffId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();
            sqlParam.Add(new SqlParameter("@LohanaPackageTariffId", lohanaPackageTariffId));
            //DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetLohanaPackageTariffRootListing.ToString(), CommandType.StoredProcedure);
            DataSet ds = _sqlHelper.ExecuteDataSet(sqlParam, Storeprocedures.spGetLohanaPackageTariffRootListing.ToString(), CommandType.StoredProcedure);
            
            return ds;
        }

        //public int CheckLohanaPackageTariffRootDetailExist(LohanaPackageTariffRootInfo lohanapackagetariffroot)
        public int CheckLohanaPackageTariffRootDetailExist(int LohanaPackageTariffId, int LohanaPackageTariffRootId, int LohanaPackageTariffRefId, int LohanaPackageTariffTypeId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            //sqlParams.Add(new SqlParameter("@LohanaPackageTariffRootId", lohanapackagetariffroot.LohanaPackageTariffRootId));
            //sqlParams.Add(new SqlParameter("@LohanaPackageTariffId", lohanapackagetariffroot.LohanaPackageTariffId));
            //sqlParams.Add(new SqlParameter("@LohanaPackageTariffRefId", lohanapackagetariffroot.LohanaPackageTariffRefId));
            //sqlParams.Add(new SqlParameter("@LohanaPackageTariffTypeId", lohanapackagetariffroot.LohanaPackageTariffTypeId));
            sqlParams.Add(new SqlParameter("@LohanaPackageTariffRootId", LohanaPackageTariffRootId));
            sqlParams.Add(new SqlParameter("@LohanaPackageTariffId", LohanaPackageTariffId));
            sqlParams.Add(new SqlParameter("@LohanaPackageTariffRefId", LohanaPackageTariffRefId));
            sqlParams.Add(new SqlParameter("@LohanaPackageTariffTypeId", LohanaPackageTariffTypeId));
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckLohanaPackageTariffRootDetailExist.ToString(), CommandType.StoredProcedure));
        }

        public void DeleteLohanaPackageTariffRootDetail(LohanaPackageTariffRootInfo lohanapackagetariffroot)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@LohanaPackageTariffRootDetailId", lohanapackagetariffroot.LohanaPackageTariffRootDetailId));
            _sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.spDeleteLohanaPackageTariffRootDetail.ToString(), CommandType.StoredProcedure);
        }

        #endregion


    }
}
