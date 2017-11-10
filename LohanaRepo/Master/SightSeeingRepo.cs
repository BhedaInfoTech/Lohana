using LohanaBusinessEntities;
using LohanaBusinessEntities.City;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.SightSeeing;
using LohanaBusinessLogic.Utilities;
using LohanaHelper.Logging;
using LohanaRepo.Accessories;
using LohanaRepo.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaRepo.Master
{
    public class SightSeeingRepo
    {
         SQLHelperRepo _sqlHelper = null;

         public SightSeeingRepo()
            {
                _sqlHelper = new SQLHelperRepo();
            }

        public List<CityInfo> drpGetCountryStateCity()
        {
            List<CityInfo> cities = new List<CityInfo>();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spdrpGetCountryStateCity.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cities.Add(GetCountryStateCityValues(dr));
                }
            }
            return cities;
        }

        public CityInfo GetCountryStateCityValues(DataRow dr)
        {
            CityInfo retVal = new CityInfo();

            retVal.CityId = Convert.ToInt32(dr["CityId"]);

            retVal.CityName = Convert.ToString(dr["Name"]);

            return retVal;
        }

        public int Insert(SightSeeingInfo SightSeeing)
        {

            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInSightSeeing(SightSeeing),Storeprocedures.spInsertSightSeeing.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInSightSeeing(SightSeeingInfo SightSeeing)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (SightSeeing.SightSeeingId != 0)
            {
                sqlParam.Add(new SqlParameter("SightSeeingId", SightSeeing.SightSeeingId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", SightSeeing.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", SightSeeing.CreatedBy));
            }
           
            sqlParam.Add(new SqlParameter("@SightSeeingName", SightSeeing.SightSeeingName));

            Logger.Debug("SightSeeing Controller SightSeeingName:" + SightSeeing.SightSeeingName);

            sqlParam.Add(new SqlParameter("@CityId", SightSeeing.CityId));

            Logger.Debug("SightSeeing Controller CityId:" + SightSeeing.CityId);

            sqlParam.Add(new SqlParameter("@Description", SightSeeing.Description));

            Logger.Debug("SightSeeing Controller Description:" + SightSeeing.Description);

            sqlParam.Add(new SqlParameter("@TimeFrom", SightSeeing.TimeFrom));

            Logger.Debug("SightSeeing Controller TimeFrom:" + SightSeeing.TimeFrom);

            sqlParam.Add(new SqlParameter("@TimeTo", SightSeeing.TimeTo));

            Logger.Debug("SightSeeing Controller TimeTo:" + SightSeeing.TimeTo);

            sqlParam.Add(new SqlParameter("@VisitTime", SightSeeing.VisitTime));

            Logger.Debug("SightSeeing Controller VisitTime:" + SightSeeing.VisitTime);

            sqlParam.Add(new SqlParameter("@TotalCost", SightSeeing.TotalCost));

            Logger.Debug("SightSeeing Controller TotalCost:" + SightSeeing.TotalCost);

            sqlParam.Add(new SqlParameter("@IsActive", SightSeeing.IsActive));

            Logger.Debug("SightSeeing Controller IsActive:" + SightSeeing.IsActive);

            sqlParam.Add(new SqlParameter("@OperationalDays", SightSeeing.OperationalDays));

            Logger.Debug("SightSeeing Controller OperationalDays:" + SightSeeing.OperationalDays);

            sqlParam.Add(new SqlParameter("@UpdatedDate", SightSeeing.UpdatedDate));

            sqlParam.Add(new SqlParameter("@UpdatedBy", SightSeeing.UpdatedBy));

            //Addition by swapnali 

            sqlParam.Add(new SqlParameter("@VehicleType", SightSeeing.VehicleType));

            Logger.Debug("SightSeeing Controller VehicleType:" + SightSeeing.VehicleType);

            sqlParam.Add(new SqlParameter("@Duration", SightSeeing.Duration));

            Logger.Debug("SightSeeing Controller Duration:" + SightSeeing.Duration);

            sqlParam.Add(new SqlParameter("@DeparturePoint", SightSeeing.DeparturePoint));

            Logger.Debug("SightSeeing Controller DeparturePoint:" + SightSeeing.DeparturePoint);

            sqlParam.Add(new SqlParameter("@VendorId", SightSeeing.VendorId));

            Logger.Debug("SightSeeing Controller VendorId:" + SightSeeing.VendorId);

            sqlParam.Add(new SqlParameter("@DepartureTimeFrom", SightSeeing.DepartureTimeFrom));

            Logger.Debug("SightSeeing Controller DepartureTimeFrom:" + SightSeeing.DepartureTimeFrom);

            //sqlParam.Add(new SqlParameter("@DepartureTimeTo", SightSeeing.DepartureTimeTo));

            //Logger.Debug("SightSeeing Controller DepartureTimeTo:" + SightSeeing.DepartureTimeTo);

            sqlParam.Add(new SqlParameter("@Disclaimer", SightSeeing.Disclaimer));

            Logger.Debug("SightSeeing Controller Disclaimer:" + SightSeeing.Disclaimer);

            sqlParam.Add(new SqlParameter("@Highlights", SightSeeing.Highlights));

            Logger.Debug("SightSeeing Controller Highlights:" + SightSeeing.Highlights);

            sqlParam.Add(new SqlParameter("@AdditionalInformation", SightSeeing.AdditionalInformation));

            Logger.Debug("SightSeeing Controller AdditionalInformation:" + SightSeeing.AdditionalInformation);

            //End
         
            return sqlParam;

        }

        public DataTable GetSightSeeing(string SightSeeingname, int cityid, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();


            sqlParam.Add(new SqlParameter("@SightSeeingName", SightSeeingname));

            sqlParam.Add(new SqlParameter("@CityId", cityid));


            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetSightSeeing.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }

        public SightSeeingInfo GetSightSeeingById(int SightSeeingid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            SightSeeingInfo SightSeeing = new SightSeeingInfo();

            sqlParam.Add(new SqlParameter("@SightSeeingId", SightSeeingid));

            Logger.Debug("SightSeeing Controller SightSeeingId:" + SightSeeingid);

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetSightSeeingById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SightSeeing = GetSightSeeingValues(dr);
                }
            }
            return SightSeeing;
        }

        private SightSeeingInfo GetSightSeeingValues(DataRow dr)
        {

            SightSeeingInfo SightSeeing = new SightSeeingInfo();

            SightSeeing.SightSeeingId = Convert.ToInt32(dr["SightSeeingId"]);

            if (!dr.IsNull("SightSeeingName"))     
            SightSeeing.SightSeeingName = Convert.ToString(dr["SightSeeingName"]);

            if (!dr.IsNull("CityId")) 
            SightSeeing.CityId = Convert.ToInt32(dr["CityId"]);

            if (!dr.IsNull("Description"))
            SightSeeing.Description = Convert.ToString(dr["Description"]);

            if (!dr.IsNull("TimeFrom"))
            SightSeeing.TimeFrom = Convert.ToString(dr["TimeFrom"]);

            if (!dr.IsNull("TimeTo"))
            SightSeeing.TimeTo = Convert.ToString(dr["TimeTo"]);

            if (!dr.IsNull("VisitTime"))
            SightSeeing.VisitTime = Convert.ToString(dr["VisitTime"]);

            if (!dr.IsNull("TotalCost"))
            SightSeeing.TotalCost = Convert.ToInt32(dr["TotalCost"]);

            if (!dr.IsNull("IsActive"))
            SightSeeing.IsActive = Convert.ToBoolean(dr["IsActive"]);

            if (!dr.IsNull("OperationalDays"))
            SightSeeing.OperationalDays = Convert.ToString(dr["OperationalDays"]);

            //Additon by swapnali | Date:06/28/2017
            if (!dr.IsNull("VehicleType"))
            SightSeeing.VehicleType = Convert.ToInt32(dr["VehicleType"]);

            if (!dr.IsNull("VendorId"))
                SightSeeing.VendorId = Convert.ToString(dr["VendorId"]);

            if (!dr.IsNull("Duration"))
                SightSeeing.Duration = Convert.ToString(dr["Duration"]);

            if (!dr.IsNull("DeparturePoint"))
                SightSeeing.DeparturePoint = Convert.ToString(dr["DeparturePoint"]);

            if (!dr.IsNull("DepartureTime"))
                SightSeeing.DepartureTimeFrom = Convert.ToString(dr["DepartureTime"]);

            if (!dr.IsNull("Disclaimer"))
                SightSeeing.Disclaimer = Convert.ToString(dr["Disclaimer"]);

            if (!dr.IsNull("Highlights"))
                SightSeeing.Highlights = Convert.ToString(dr["Highlights"]);

            if (!dr.IsNull("AdditionalInformation"))
                SightSeeing.AdditionalInformation = Convert.ToString(dr["AdditionalInformation"]);

            //End

            return SightSeeing;


        }

        public void UpdateSightSeeing(SightSeeingInfo SightSeeing)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInSightSeeing(SightSeeing), Storeprocedures.spUpdateSightSeeing.ToString(), CommandType.StoredProcedure);
        }

        public bool CheckSightSeeingNameExist(string sightseeingid)
        {      

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@SightSeeingId", sightseeingid));

            Logger.Debug("SightSeeingId Controller SightSeeingId:" + sightseeingid);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckSightSeeingNameExist.ToString(), CommandType.StoredProcedure));

        }

        #region  SearchSightSeeing

        public List<SightSeeingInfo> GetSearchSightSeeingDetails(SightSeeingInfo sightSeeingInfo, bool IsExtraChild, int OccupancyType)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            List<SightSeeingInfo> SightSeeingBasicDetails = new List<SightSeeingInfo>();

           // sqlParam.Add(new SqlParameter("@SightSeeingId", sightSeeingInfo.SightSeeingId));

            sqlParam.Add(new SqlParameter("@IsExtraChild", IsExtraChild));

            sqlParam.Add(new SqlParameter("@OccupancyType", OccupancyType));

            sqlParam.Add(new SqlParameter("@CityId", sightSeeingInfo.CityId));

            sqlParam.Add(new SqlParameter("@StateId", sightSeeingInfo.StateId));

            sqlParam.Add(new SqlParameter("@CountryId", sightSeeingInfo.CountryId));
  
            if(sightSeeingInfo.FromDate != DateTime.MinValue )
            {
                  //DateTime? someDate = null;
                  sqlParam.Add(new SqlParameter("@FromDate", sightSeeingInfo.FromDate));
            }
            else
            {
                   sqlParam.Add(new SqlParameter("@FromDate", sightSeeingInfo.TravelDate));
            }        

           // sqlParam.Add(new SqlParameter("@ToDate", sightSeeingInfo.ToDate));

           // sqlParam.Add(new SqlParameter("@AdultCount", sightSeeingInfo.AdultCount));

           // sqlParam.Add(new SqlParameter("@ChildCount", sightSeeingInfo.ChildCount));

            DataSet ds = _sqlHelper.ExecuteDataSet(sqlParam, Storeprocedures.spGetSearchSightseeingDetails.ToString(), CommandType.StoredProcedure);

            DataTable dt1 = ds.Tables[0];

            if (dt1 != null && dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    SightSeeingBasicDetails.Add(GetsightSeeingBasicDetailsValues(dr));
                }
            }
            return SightSeeingBasicDetails;
        }


        public SightSeeingInfo GetsightSeeingBasicDetailsValues(DataRow dr)
        {
            AccessoriesRepo _aRepo = new AccessoriesRepo();
            SightSeeingInfo sInfo = new SightSeeingInfo();

                sInfo.SightSeeingId = Convert.ToInt32(dr["SightSeeingId"]);

            if (!dr.IsNull("SightSeeingName"))
                sInfo.SightSeeingName = Convert.ToString(dr["SightSeeingName"]);

            if (!dr.IsNull("CityId"))
                sInfo.CityId = Convert.ToInt32(dr["CityId"]);

            if (!dr.IsNull("location"))
                sInfo.location = Convert.ToString(dr["location"]);

            //if (!dr.IsNull("AdultCount"))
            //    sInfo.AdultCount = Convert.ToInt32(dr["AdultCount"]);

            //if (!dr.IsNull("ChildCount"))
            //    sInfo.ChildCount = Convert.ToInt32(dr["ChildCount"]);

            if (!dr.IsNull("Description"))
                sInfo.Description = Convert.ToString(dr["Description"]);

            if (!dr.IsNull("VisitTime"))
                sInfo.VisitTime = Convert.ToString(dr["VisitTime"]);                      

            if (!dr.IsNull("Highlights"))
                sInfo.Highlights = Convert.ToString(dr["Highlights"]);

            if (!dr.IsNull("Duration"))
                sInfo.Duration = Convert.ToString(dr["Duration"]);

            if (!dr.IsNull("OccupancyValue"))
                sInfo.OccupancyValue = Convert.ToInt32(dr["OccupancyValue"]);

            if (!dr.IsNull("OccupancyId"))
                sInfo.OccupancyId = Convert.ToInt32(dr["OccupancyId"]);

            if (!dr.IsNull("SightSeeingTariffId"))
                sInfo.SightSeeingTariffId = Convert.ToInt32(dr["SightSeeingTariffId"]);

            if (!dr.IsNull("NetRate"))
                sInfo.NetRate = Convert.ToDecimal(dr["NetRate"]);

            sInfo.Images = _aRepo.GetImagesByRefType(sInfo.SightSeeingId, (int)Attachment.SightSeeing);
            return sInfo;

        }
        #endregion

        //public List<SightSeeingInfo> GetSightSeeingByCityId(int City)
        //{
        //    List<SqlParameter> sqlParam = new List<SqlParameter>();

        //    List<SightSeeingInfo> SightSeeingDetails = new List<SightSeeingInfo>();

        //    sqlParam.Add(new SqlParameter("@CityId", City));

           
        //    DataSet ds = _sqlHelper.ExecuteDataSet(sqlParam, Storeprocedures.GetSightSeeingInfo.ToString(), CommandType.StoredProcedure);

        //    DataTable dt1 = ds.Tables[0];

        //    if (dt1 != null && dt1.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dt1.Rows)
        //        {
        //            SightSeeingInfo SightSeeingInfo = new SightSeeingInfo();
        //            if (!dr.IsNull("CityId"))
        //                SightSeeingInfo.CityId = Convert.ToInt32(dr["CityId"]);

        //            if (!dr.IsNull("SightSeeingId"))
        //                SightSeeingInfo.SightSeeingId = Convert.ToInt32(dr["SightSeeingId"]);

        //            if (!dr.IsNull("SightSeeingName"))
        //                SightSeeingInfo.SightSeeingName = Convert.ToString(dr["SightSeeingName"]);

        //             }
        //          }
        //    return SightSeeingDetails;


        //}
                
    }
}
