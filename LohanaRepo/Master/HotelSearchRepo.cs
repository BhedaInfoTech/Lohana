using LohanaRepo.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using LohanaBusinessEntities;
using LohanaBusinessEntities.HotelSearch;
using LohanaBusinessEntities.Common;
using LohanaRepo.Utilities;

namespace LohanaRepo.Master
{
    public class HotelSearchRepo
    {
        SQLHelperRepo _sqlHelper = null;

        public HotelSearchRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }


        // Get Hotel Basic Details


        //public List<HotelSearchInfo> GetHotelBasicDetails(string hotelname, int cityid, int starcategory, int roomtypeid, int occupancyid, DateTime checkindate, DateTime checkoutdate)
        public List<HotelSearchInfo> GetHotelBasicDetails(HotelSearchInfo searchInfo,int OccupancyType)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            List<HotelSearchInfo> HotelBasicDetails = new List<HotelSearchInfo>();
            sqlParam.Add(new SqlParameter("@HotelId", searchInfo.HotelId));
            sqlParam.Add(new SqlParameter("@CountryId", searchInfo.CountryId));
            sqlParam.Add(new SqlParameter("@StateId", searchInfo.StateId));
            sqlParam.Add(new SqlParameter("@CityId", searchInfo.CityId));
            sqlParam.Add(new SqlParameter("@StarCategory", searchInfo.StarCategory));
            sqlParam.Add(new SqlParameter("@RoomTypeId", searchInfo.RoomTypeId));
            sqlParam.Add(new SqlParameter("@OccupancyId", searchInfo.OccupancyId)); 
            sqlParam.Add(new SqlParameter("@CheckInDate", searchInfo.CheckinDate == DateTime.MinValue ? "" : searchInfo.CheckinDate.ToString()));
            sqlParam.Add(new SqlParameter("@CheckOutDate", searchInfo.CheckOutDate == DateTime.MinValue ? "" : searchInfo.CheckOutDate.ToString()));

            //sqlParam.Add(new SqlParameter("@AdultCount", searchInfo.AdultCount));
           // sqlParam.Add(new SqlParameter("@ChildCount", searchInfo.ChildCount));
            //sqlParam.Add(new SqlParameter("@OccupancyTypeRoom", (int)OccupancyType.Room)); 
            //sqlParam.Add(new SqlParameter("@OccupancyName", searchInfo.OccupancyName));  

            sqlParam.Add(new SqlParameter("@OccupancyTypeRoom", OccupancyType));  
            sqlParam.Add(new SqlParameter("@IsExtraChild", searchInfo.IsExtraChild)); 
            

           // sqlParam.Add(new SqlParameter("@OccupancyTypeExtra", (int)OccupancyType.Extra));
            //DataSet ds = _sqlHelper.ExecuteDataSet(sqlParam, Storeprocedures.GetHotelSearchLists_Sp.ToString(), CommandType.StoredProcedure);
            DataSet ds = _sqlHelper.ExecuteDataSet(sqlParam, Storeprocedures.GetHotelSearchByRoom.ToString(), CommandType.StoredProcedure);

            DataTable dt1 = ds.Tables[0];

            if (dt1 != null && dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    HotelBasicDetails.Add(GetHotelBasicDetailsValues(dr));
                }
            }

            if(searchInfo.IsQuotationHotel)
            {
                HotelBasicDetails.All(x => x.IsQuotationHotel = searchInfo.IsQuotationHotel).ToString();
            }


            return HotelBasicDetails;
        }

        private HotelSearchInfo GetHotelBasicDetailsValues(DataRow dr)
        {
            HotelSearchInfo HotelBasicDetail = new HotelSearchInfo();

            HotelBasicDetail.HotelId = Convert.ToInt32(dr["HotelId"]);

            if (!dr.IsNull("TotalRoomPrice"))
                HotelBasicDetail.HotelRoomPrice = Convert.ToDecimal(dr["TotalRoomPrice"]);
            
            if (!dr.IsNull("HotelName"))
                HotelBasicDetail.HotelName = Convert.ToString(dr["HotelName"]);

            if (!dr.IsNull("StarCategory"))
                HotelBasicDetail.StarCategory = Convert.ToInt32(dr["StarCategory"]);

            if (!dr.IsNull("StarCategoryStr"))
                HotelBasicDetail.StarCategoryStr = Convert.ToString(dr["StarCategoryStr"]);

            if (!dr.IsNull("HotelDescription"))
                HotelBasicDetail.HotelDescription = Convert.ToString(dr["HotelDescription"]);

            if (!dr.IsNull("HotelType"))
                HotelBasicDetail.HotelType = Convert.ToInt32(dr["HotelType"]);

            if (!dr.IsNull("CityId"))
                HotelBasicDetail.CityId = Convert.ToInt32(dr["CityId"]);

            if (!dr.IsNull("CityName"))
                HotelBasicDetail.CityName = Convert.ToString(dr["CityName"]);

			if(!dr.IsNull("RoomTypeName"))
				HotelBasicDetail.RoomTypeName = Convert.ToString(dr["RoomTypeName"]);

            if (!dr.IsNull("RoomTypeId"))
                HotelBasicDetail.RoomTypeId = Convert.ToInt32(dr["RoomTypeId"]);

			if(!dr.IsNull("MealName"))
				HotelBasicDetail.MealName = Convert.ToString(dr["MealName"]);

            if (!dr.IsNull("OccupancyCapacity"))
                HotelBasicDetail.OccupancyCapacity = Convert.ToInt32(dr["OccupancyCapacity"]);

            if (!dr.IsNull("OccupancyValue"))
                HotelBasicDetail.OccupancyValue = Convert.ToInt32(dr["OccupancyValue"]);

            if (!dr.IsNull("NoOfNight"))
                HotelBasicDetail.NoOfNight = Convert.ToInt32(dr["NoOfNight"]);

            if (!dr.IsNull("VendorId"))
                HotelBasicDetail.VendorId = Convert.ToInt32(dr["VendorId"]);

            if (!dr.IsNull("NetRatePerNight"))
                HotelBasicDetail.NetRatePerNight = Convert.ToInt32(dr["NetRatePerNight"]);

            if (!dr.IsNull("NetRate"))
                HotelBasicDetail.NetRate = Convert.ToInt32(dr["NetRate"]);

            if (!dr.IsNull("NoOfRooms"))
                HotelBasicDetail.NoOfRooms = Convert.ToInt32(dr["NoOfRooms"]);

            if (!dr.IsNull("CheckInTime"))
                HotelBasicDetail.CheckInTime = DateTime.ParseExact(dr["CheckInTime"].ToString(), "HH:mm:ss", null, System.Globalization.DateTimeStyles.None);//Convert.ToDateTime(dr["CheckInTime"]);

            if (!dr.IsNull("CheckOutTime"))
                HotelBasicDetail.CheckOutTime = DateTime.ParseExact(dr["CheckOutTime"].ToString(), "HH:mm:ss", null, System.Globalization.DateTimeStyles.None);

            if (!dr.IsNull("OccupancyName"))
                HotelBasicDetail.OccupancyName = Convert.ToString(dr["OccupancyName"]);

            return HotelBasicDetail;

        }



        // Get HotelSearchRoomOccupancyPrice Details


        public List<HotelSearchRoomMealOccupancyPrice> GetHotelSearchRoomMealOccupancyPriceDetails(string hotelname, int cityid, int starcategory, int roomtypeid, int occupancyid, DateTime checkindate, DateTime checkoutdate)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            List<HotelSearchRoomMealOccupancyPrice> HotelSearchRoomMealOccupancyPriceDetails = new List<HotelSearchRoomMealOccupancyPrice>();

            sqlParam.Add(new SqlParameter("@HotelName", hotelname));

            sqlParam.Add(new SqlParameter("@CityId", cityid));

            sqlParam.Add(new SqlParameter("@StarCategory", starcategory));

            sqlParam.Add(new SqlParameter("@RoomTypeId", roomtypeid));

            sqlParam.Add(new SqlParameter("@OccupancyId", occupancyid));

            if (checkindate == DateTime.MinValue)
            {
                DateTime? someDate = null;

                sqlParam.Add(new SqlParameter("@CheckInDate", someDate));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CheckInDate", checkindate));
            }

            if (checkoutdate == DateTime.MinValue)
            {
                DateTime? someDate = null;

                sqlParam.Add(new SqlParameter("@CheckOutDate", someDate));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CheckOutDate", checkoutdate));
            }

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.SpGetHotelSearchRoomMealOccupancyPrice.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    HotelSearchRoomMealOccupancyPriceDetails.Add(GetHotelSearchRoomMealOccupancyPriceDetailsValues(dr));
                }
            }
            return HotelSearchRoomMealOccupancyPriceDetails;
        }

        private HotelSearchRoomMealOccupancyPrice GetHotelSearchRoomMealOccupancyPriceDetailsValues(DataRow dr)
        {
            HotelSearchRoomMealOccupancyPrice HotelSearchRoomMealOccupancyPriceDetail = new HotelSearchRoomMealOccupancyPrice();

            //if (!dr.IsNull("HotelTariffPriceDetailsId"))
            //    HotelSearchRoomMealOccupancyPriceDetail.HotelTariffPriceDetailsId = Convert.ToInt32(dr["HotelTariffPriceDetailsId"]);

            if (!dr.IsNull("NoOfNight"))
                HotelSearchRoomMealOccupancyPriceDetail.NoOfNight = Convert.ToInt32(dr["NoOfNight"]);

            if (!dr.IsNull("TotalRate"))
                HotelSearchRoomMealOccupancyPriceDetail.TotalRate = Convert.ToInt32(dr["TotalRate"]);

            if (!dr.IsNull("NetRatePerNight"))
                HotelSearchRoomMealOccupancyPriceDetail.NetRatePerNight = Convert.ToInt32(dr["NetRatePerNight"]);

            //if (!dr.IsNull("HotelTariffRoomDetailsId"))
            //    HotelSearchRoomMealOccupancyPriceDetail.HotelTariffRoomDetailsId = Convert.ToInt32(dr["HotelTariffRoomDetailsId"]);

            if (!dr.IsNull("RoomTypeId"))
                HotelSearchRoomMealOccupancyPriceDetail.RoomTypeId = Convert.ToInt32(dr["RoomTypeId"]);

            if (!dr.IsNull("RoomTypeName"))
                HotelSearchRoomMealOccupancyPriceDetail.RoomTypeName = Convert.ToString(dr["RoomTypeName"]);

            if (!dr.IsNull("MealId"))
                HotelSearchRoomMealOccupancyPriceDetail.MealId = Convert.ToInt32(dr["MealId"]);

            if (!dr.IsNull("MealName"))
                HotelSearchRoomMealOccupancyPriceDetail.MealName = Convert.ToString(dr["MealName"]);

            //if (!dr.IsNull("OccupancyId"))
            //    HotelSearchRoomMealOccupancyPriceDetail.OccupancyId = Convert.ToInt32(dr["OccupancyId"]);

            //if (!dr.IsNull("OccupancyName"))
            //    HotelSearchRoomMealOccupancyPriceDetail.OccupancyName = Convert.ToString(dr["OccupancyName"]);

            //if (!dr.IsNull("HotelTariffId"))
            //    HotelSearchRoomMealOccupancyPriceDetail.HotelTariffId = Convert.ToInt32(dr["HotelTariffId"]);

            if (!dr.IsNull("HotelId"))
                HotelSearchRoomMealOccupancyPriceDetail.HotelId = Convert.ToInt32(dr["HotelId"]);

            //if (!dr.IsNull("VendorId"))
            //    HotelSearchRoomMealOccupancyPriceDetail.VendorId = Convert.ToInt32(dr["VendorId"]);

            //if (!dr.IsNull("VendorName"))
            //    HotelSearchRoomMealOccupancyPriceDetail.VendorName = Convert.ToString(dr["VendorName"]);

            //if (!dr.IsNull("NetRate"))
            //    HotelSearchRoomMealOccupancyPriceDetail.NetRate = Convert.ToDecimal(dr["NetRate"]);

            return HotelSearchRoomMealOccupancyPriceDetail;

        }

        public List<HotelSearchRoomMealOccupancyPrice> GetHotelRoomDetails(HotelSearchInfo hotelSearchInfo)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            List<HotelSearchRoomMealOccupancyPrice> HotelSearchRoomMealOccupancyPriceDetails = new List<HotelSearchRoomMealOccupancyPrice>();

            sqlParam.Add(new SqlParameter("@HotelId", hotelSearchInfo.HotelId));       
            sqlParam.Add(new SqlParameter("@RoomTypeId", hotelSearchInfo.RoomTypeId));      
            DateTime? someDate = null;
            sqlParam.Add(new SqlParameter("@CheckInDate", hotelSearchInfo.CheckinDate == DateTime.MinValue ? someDate : hotelSearchInfo.CheckinDate));
            sqlParam.Add(new SqlParameter("@CheckOutDate", hotelSearchInfo.CheckOutDate == DateTime.MinValue ? someDate : hotelSearchInfo.CheckOutDate));
            sqlParam.Add(new SqlParameter("@AdultCount", hotelSearchInfo.AdultCount));
            sqlParam.Add(new SqlParameter("@ChildCount", hotelSearchInfo.ChildCount));
            sqlParam.Add(new SqlParameter("@OccupancyTypeRoom", (int)OccupancyType.Room));
            sqlParam.Add(new SqlParameter("@OccupancyTypeExtra", (int)OccupancyType.Extra));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.GetHotelRoomDetails_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    HotelSearchRoomMealOccupancyPriceDetails.Add(GetHotelSearchRoomMealOccupancyPriceDetailsValues(dr));
                }
            }
            return HotelSearchRoomMealOccupancyPriceDetails;
        }

    }
}
