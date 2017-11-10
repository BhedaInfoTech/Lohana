using LohanaBusinessEntities.SupplierSearch;
using LohanaRepo.Utilities;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using LohanaBusinessEntities.Common;
using System.Text;
using System.Threading.Tasks;

namespace LohanaRepo.Master
{
  public class SupplierSearchRepo
    {
      SQLHelperRepo _sqlHelper = null;

      public SupplierSearchRepo()
      {
          _sqlHelper = new SQLHelperRepo();
      }

      //Get Supplier Hotel Basic Detail
      public List<SupplierSearchInfo> GetHotelBasicDetails(SupplierSearchInfo searchInfo,bool IsExtraChild,int OccupancyType)
      {
          List<SqlParameter> sqlParam = new List<SqlParameter>();

          List<SupplierSearchInfo> SupplierSearchDetails = new List<SupplierSearchInfo>();

          sqlParam.Add(new SqlParameter("@CountryId", searchInfo.CountryId));

          sqlParam.Add(new SqlParameter("@StateId", searchInfo.StateId));

          sqlParam.Add(new SqlParameter("@CityId", searchInfo.CityId));

          sqlParam.Add(new SqlParameter("@OccupancyType", OccupancyType));

          sqlParam.Add(new SqlParameter("@IsExtraChild",IsExtraChild));

          sqlParam.Add(new SqlParameter("@DayDuration",searchInfo.NoOfDays));

          sqlParam.Add(new SqlParameter("@NightDuration", searchInfo.NoOfNights));

          sqlParam.Add(new SqlParameter("@CheckInDate",searchInfo.CheckInDate));

          sqlParam.Add(new SqlParameter("@CheckOutDate", searchInfo.CheckOutDate));

  
          DataSet ds = _sqlHelper.ExecuteDataSet(sqlParam, Storeprocedures.GetSupplierSearchLists_Sp.ToString(), CommandType.StoredProcedure);
          DataTable dt1 = ds.Tables[0];

          if (dt1 != null && dt1.Rows.Count > 0)
          {
              foreach (DataRow dr in dt1.Rows)
              {
                  SupplierSearchDetails.Add(GetHotelBasicDetailsValues(dr));
              }
          }
          return SupplierSearchDetails;
      }


      private SupplierSearchInfo GetHotelBasicDetailsValues(DataRow dr)
      {
          SupplierSearchInfo SupplierBasicDetail = new SupplierSearchInfo();

          //SupplierBasicDetail.CityId = Convert.ToInt32(dr["CityId"]);

          if (!dr.IsNull("PackageCost"))
              SupplierBasicDetail.PackageCost = Convert.ToDecimal(dr["PackageCost"]);

          if (!dr.IsNull("SupplierName"))
              SupplierBasicDetail.SupplierName = Convert.ToString(dr["SupplierName"]);

          if (!dr.IsNull("PackageName"))
              SupplierBasicDetail.PackageName = Convert.ToString(dr["PackageName"]);

          //if (!dr.IsNull("MonthName"))
          //    SupplierBasicDetail.MonthName = Convert.ToString(dr["MonthName"]);

          if (!dr.IsNull("SupplierHotelId"))
              SupplierBasicDetail.SupplierHotelId = Convert.ToInt32(dr["SupplierHotelId"]);

          if (!dr.IsNull("OccupancyValue"))
           SupplierBasicDetail.OccupancyValue = Convert.ToInt32(dr["OccupancyValue"]);

          if (!dr.IsNull("DayDuration"))
              SupplierBasicDetail.NoOfDays = Convert.ToInt32(dr["DayDuration"]);

          if (!dr.IsNull("NightDuration"))
              SupplierBasicDetail.NoOfNights = Convert.ToInt32(dr["NightDuration"]);

          //if (!dr.IsNull("OccupancyCapacity"))
          //    SupplierBasicDetail.OccupancyCapacity = Convert.ToInt32(dr["OccupancyCapacity"]);


          return SupplierBasicDetail;

      }

      public List<SupplierSearchInfo> GetSupplierHotelDetails(int SupplierHotelId)
      {
          List<SqlParameter> sqlParam = new List<SqlParameter>();

          List<SupplierSearchInfo> SupplierHotelDetails = new List<SupplierSearchInfo>();

          sqlParam.Add(new SqlParameter("@SupplierHotelId", SupplierHotelId));

          DataSet ds = _sqlHelper.ExecuteDataSet(sqlParam, Storeprocedures.GetSupplierHotelSearchDetails.ToString(), CommandType.StoredProcedure);
          DataTable dt1 = ds.Tables[0];

          if (dt1 != null && dt1.Rows.Count > 0)
          {
              foreach (DataRow dr in dt1.Rows)
              {
                  SupplierHotelDetails.Add(GetSupplierHotelValues(dr));
              }
          }
          return SupplierHotelDetails;
      }

      private SupplierSearchInfo GetSupplierHotelValues(DataRow dr)
      {
          SupplierSearchInfo SupplierHotel = new SupplierSearchInfo();


          //if (!dr.IsNull("PackageCost"))
          //    SupplierHotel.PackageCost = Convert.ToDecimal(dr["PackageCost"]);
 

          //if (!dr.IsNull("OccupancyName"))
          //    SupplierHotel.OccupancyName = Convert.ToString(dr["OccupancyName"]);


          if (!dr.IsNull("HotelName"))
              SupplierHotel.HotelName = Convert.ToString(dr["HotelName"]);

          if (!dr.IsNull("VehicleName"))
              SupplierHotel.VehicleName = Convert.ToString(dr["VehicleName"]);

          if (!dr.IsNull("MealName"))
              SupplierHotel.MealName = Convert.ToString(dr["MealName"]);


          if (!dr.IsNull("SightSeeingName"))
              SupplierHotel.SightSeeingName = Convert.ToString(dr["SightSeeingName"]);

          if (!dr.IsNull("SupplierHotelDayId"))
              SupplierHotel.SupplierHotelDayId = Convert.ToInt32(dr["SupplierHotelDayId"]);

          if (!dr.IsNull("SupplierHotelId"))
              SupplierHotel.SupplierHotelId = Convert.ToInt32(dr["SupplierHotelId"]);

          if (!dr.IsNull("Title"))
              SupplierHotel.Title = Convert.ToString(dr["Title"]);


          return SupplierHotel;

      }


  


        
      }
    }

