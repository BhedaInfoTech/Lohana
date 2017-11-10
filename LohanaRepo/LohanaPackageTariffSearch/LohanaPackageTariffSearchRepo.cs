using LohanaBusinessEntities.LohanaPackageTariffSearch;
using LohanaRepo.Utilities;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using LohanaBusinessEntities.Common;
using System.Text;
using System.Threading.Tasks;

namespace LohanaRepo.LohanaPackageTariffSearch
{
    public class LohanaPackageTariffSearchRepo
    {
        SQLHelperRepo _sqlHelper = null;

        public LohanaPackageTariffSearchRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        //Get LohanaPackage Tariff Basic Detail

        public List<LohanaPackageTariffSearchInfo> GetLohanaPackageTariffBasicDetails(LohanaPackageTariffSearchInfo searchInfo, bool IsExtraChild, int OccupancyType)
        {
            var count = 1;

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            searchInfo.DayDuration = searchInfo.NightDuration + count;

            List<LohanaPackageTariffSearchInfo> LPTSearchDetails = new List<LohanaPackageTariffSearchInfo>();

            sqlParam.Add(new SqlParameter("@PackageTypeId", searchInfo.PackageTypeId));

            sqlParam.Add(new SqlParameter("@OccupancyId", searchInfo.OccupancyId));

            sqlParam.Add(new SqlParameter("@CountryId", searchInfo.CountryId));

            sqlParam.Add(new SqlParameter("@StateId", searchInfo.StateId));

            sqlParam.Add(new SqlParameter("@CityId", searchInfo.CityId));

            sqlParam.Add(new SqlParameter("@OccupancyType", OccupancyType));

            sqlParam.Add(new SqlParameter("@IsExtraChild", IsExtraChild));

            sqlParam.Add(new SqlParameter("@DayDuration", searchInfo.DayDuration));

            sqlParam.Add(new SqlParameter("@NightDuration", searchInfo.NightDuration));

            sqlParam.Add(new SqlParameter("@CheckInDate", searchInfo.CheckInDate));

            sqlParam.Add(new SqlParameter("@CheckOutDate", searchInfo.CheckOutDate));


            DataSet ds = _sqlHelper.ExecuteDataSet(sqlParam, Storeprocedures.spGetLohanaPackageTariffDetailsSearch.ToString(), CommandType.StoredProcedure);
           
            DataTable dt1 = ds.Tables[0];

            if (dt1 != null && dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    LPTSearchDetails.Add(GetLohanaPackageTariffBasicDetailsValues(dr));
                }
            }
            return LPTSearchDetails;
        }

        private LohanaPackageTariffSearchInfo GetLohanaPackageTariffBasicDetailsValues(DataRow dr)
        {
            LohanaPackageTariffSearchInfo LohanaPackageTariffSearchBasicDetail = new LohanaPackageTariffSearchInfo();

            if (!dr.IsNull("FinalCost"))
                LohanaPackageTariffSearchBasicDetail.Cost = Convert.ToDecimal(dr["FinalCost"]);

            if (!dr.IsNull("PackageName"))
                LohanaPackageTariffSearchBasicDetail.PackageName = Convert.ToString(dr["PackageName"]);

            if (!dr.IsNull("PackageTypeName"))
                LohanaPackageTariffSearchBasicDetail.PackageTypeName = Convert.ToString(dr["PackageTypeName"]);

            if (!dr.IsNull("RoomTypeName"))
                LohanaPackageTariffSearchBasicDetail.RoomTypeName = Convert.ToString(dr["RoomTypeName"]);

            if (!dr.IsNull("LPTDuration"))
                LohanaPackageTariffSearchBasicDetail.LPTDuration = Convert.ToString(dr["LPTDuration"]);

            if (!dr.IsNull("OccupancyValue"))
                LohanaPackageTariffSearchBasicDetail.OccupancyValue = Convert.ToInt32(dr["OccupancyValue"]);

            if (!dr.IsNull("OccupancyName"))
                LohanaPackageTariffSearchBasicDetail.OccupancyName = Convert.ToString(dr["OccupancyName"]);

            if (!dr.IsNull("RoomTypeId"))
                LohanaPackageTariffSearchBasicDetail.RoomTypeId = Convert.ToInt32(dr["RoomTypeId"]);

            if (!dr.IsNull("PackageTypeId"))
                LohanaPackageTariffSearchBasicDetail.PackageTypeId = Convert.ToInt32(dr["PackageTypeId"]);

            if (!dr.IsNull("OccupancyId"))
                LohanaPackageTariffSearchBasicDetail.OccupancyId = Convert.ToInt32(dr["OccupancyId"]);

            if (!dr.IsNull("CountryId"))
                LohanaPackageTariffSearchBasicDetail.CountryId = Convert.ToInt32(dr["CountryId"]);

            if (!dr.IsNull("CountryName"))
                LohanaPackageTariffSearchBasicDetail.CountryName = Convert.ToString(dr["CountryName"]);

            if (!dr.IsNull("StateId"))
                LohanaPackageTariffSearchBasicDetail.StateId = Convert.ToInt32(dr["StateId"]);

            if (!dr.IsNull("StateName"))
                LohanaPackageTariffSearchBasicDetail.StateName = Convert.ToString(dr["StateName"]);

            if (!dr.IsNull("CityId"))
                LohanaPackageTariffSearchBasicDetail.CityId = Convert.ToInt32(dr["CityId"]);

            if (!dr.IsNull("CityName"))
                LohanaPackageTariffSearchBasicDetail.CityName = Convert.ToString(dr["CityName"]);

            if (!dr.IsNull("LohanaPackageTariffId"))
                LohanaPackageTariffSearchBasicDetail.LohanaPackageTariffId = Convert.ToInt32(dr["LohanaPackageTariffId"]);

            return LohanaPackageTariffSearchBasicDetail;

        }

        // View Lohana Package Tariff

        public List<LohanaPackageTariffSearchInfo> GetLohanaPackageTariffItienarySearchDetails(int LohanaPackageTariffId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            List<LohanaPackageTariffSearchInfo> LohanaPackageTariffItienarySearchDetails = new List<LohanaPackageTariffSearchInfo>();

            sqlParam.Add(new SqlParameter("@LohanaPackageTariffId", LohanaPackageTariffId));

            DataSet ds = _sqlHelper.ExecuteDataSet(sqlParam, Storeprocedures.GetLohanaPackageTariffSearchItienaryDetails.ToString(), CommandType.StoredProcedure);

            DataTable dt1 = ds.Tables[0];

            if (dt1 != null && dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    LohanaPackageTariffItienarySearchDetails.Add(GetLohanaPackageTariffItienarySearchDetailsValues(dr));
                }
            }
            return LohanaPackageTariffItienarySearchDetails;
        }

        private LohanaPackageTariffSearchInfo GetLohanaPackageTariffItienarySearchDetailsValues(DataRow dr)
        {
            LohanaPackageTariffSearchInfo LohanaPackageTariffItienarySearch = new LohanaPackageTariffSearchInfo();

            if (!dr.IsNull("HotelName"))
                LohanaPackageTariffItienarySearch.HotelName = Convert.ToString(dr["HotelName"]);

            if (!dr.IsNull("VehicleName"))
                LohanaPackageTariffItienarySearch.VehicleName = Convert.ToString(dr["VehicleName"]);

            if (!dr.IsNull("MealName"))
                LohanaPackageTariffItienarySearch.MealName = Convert.ToString(dr["MealName"]);


            if (!dr.IsNull("SightSeeingName"))
                LohanaPackageTariffItienarySearch.SightSeeingName = Convert.ToString(dr["SightSeeingName"]);

            if (!dr.IsNull("LohanaPackageTariffRootId"))
                LohanaPackageTariffItienarySearch.LohanaPackageTariffRootId = Convert.ToInt32(dr["LohanaPackageTariffRootId"]);

            if (!dr.IsNull("LohanaPackageTariffId"))
                LohanaPackageTariffItienarySearch.LohanaPackageTariffId = Convert.ToInt32(dr["LohanaPackageTariffId"]);

            if (!dr.IsNull("Title"))
                LohanaPackageTariffItienarySearch.Title = Convert.ToString(dr["Title"]);

            return LohanaPackageTariffItienarySearch;

        }

    

    }
}
