using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.SqlClient;
using System.Data;
using LohanaBusinessEntities;
using LohanaRepo.Utilities;
using LohanaBusinessEntities.Package;
using LohanaBusinessEntities.PackageType;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.City;
using LohanaBusinessLogic.Utilities;
using LohanaBusinessEntities.Hotel;
using LohanaBusinessEntities.Meal;
using System.Globalization;
using LohanaRepo.Accessories;
using LohanaBusinessEntities.Enquiry;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;


namespace LohanaRepo.Master
{
    public class PackageRepo
    {

        SQLHelperRepo _sqlHelper = null;

        public PackageRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        //Insert Procedures Call

        public int InsertPackage(PackageInfo package)
        {
            package.PackageId = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInPackage(package), Storeprocedures.spInsertPackage.ToString(), CommandType.StoredProcedure));

            var packages = package.PackageType.Split(',');

            foreach (var item in packages)
            {
                if (item != "")
                {
                    package.PackageTypeId = Convert.ToInt32(item);

                    _sqlHelper.ExecuteScalerObj(SetValuesInPackageTypeMapping(package), Storeprocedures.spInsertPackageTypeMapping.ToString(), CommandType.StoredProcedure);
                }
            }

            foreach (var item in package.PackageDaysTriffInfo)
            {
                item.PackageId = package.PackageId;

                _sqlHelper.ExecuteNonQuery(Set_Values_In_PackageGitDays(item), Storeprocedures.sp_Insert_PackageGitTriff.ToString(), CommandType.StoredProcedure);
            }

            return package.PackageId;
        }

        private List<SqlParameter> Set_Values_In_PackageGitDays(PackageDaysTriffInfo packageTariffDayInfo)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (packageTariffDayInfo.PackageDayId != 0)
            {
                sqlParams.Add(new SqlParameter("@PackageDayId", packageTariffDayInfo.PackageDayId));
            }

            sqlParams.Add(new SqlParameter("@PackageId", packageTariffDayInfo.PackageId));
            sqlParams.Add(new SqlParameter("@CityId", packageTariffDayInfo.CityId));
            sqlParams.Add(new SqlParameter("@Title", packageTariffDayInfo.Title));


            if (packageTariffDayInfo.PackageDayId == 0)
            {

                sqlParams.Add(new SqlParameter("@CreatedDate", packageTariffDayInfo.CreatedDate));
                sqlParams.Add(new SqlParameter("@CreatedBy", packageTariffDayInfo.CreatedBy));
            }

            sqlParams.Add(new SqlParameter("@UpdatedDate", packageTariffDayInfo.UpdatedDate));
            sqlParams.Add(new SqlParameter("@UpdatedBy", packageTariffDayInfo.UpdatedBy));

            return sqlParams;
        }

        public void Update_GitDayTitles(PackageDaysTriffInfo packageTariffDayInfo)
        {
            _sqlHelper.ExecuteNonQuery(Set_Values_In_PackageGitDays(packageTariffDayInfo), Storeprocedures.sp_Update_GitItinararyDays.ToString(), CommandType.StoredProcedure);
        }

        public List<SqlParameter> SetValuesInPackageTypeMapping(PackageInfo package)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("PackageId", package.PackageId));

            sqlParam.Add(new SqlParameter("PackageTypeId", package.PackageTypeId));

            sqlParam.Add(new SqlParameter("CreatedDate", package.CreatedDate));

            sqlParam.Add(new SqlParameter("CreatedBy", package.CreatedBy));

            sqlParam.Add(new SqlParameter("UpdatedBy", package.UpdatedBy));

            sqlParam.Add(new SqlParameter("UpdatedDate", package.UpdatedDate));

            return sqlParam;
        }

        public List<SqlParameter> SetValuesInPackage(PackageInfo package)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (package.PackageId != 0)
            {
                sqlParam.Add(new SqlParameter("PackageId", package.PackageId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", package.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", package.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("PackageCode", package.PackageCode));

            sqlParam.Add(new SqlParameter("PackageCategoryId", package.PackageCategoryId));

            //sqlParam.Add(new SqlParameter("PackageTypeId", package.PackageTypeId));

            sqlParam.Add(new SqlParameter("PackageName", package.PackageName));
                        
            sqlParam.Add(new SqlParameter("DepartureCityId", package.DepartureCityId));

            sqlParam.Add(new SqlParameter("TourReportingPoint", package.TourReportingPoint));

            sqlParam.Add(new SqlParameter("TourDroppingPoint", package.TourDroppingPoint));

            sqlParam.Add(new SqlParameter("PackageCost", package.PackageCost));

            sqlParam.Add(new SqlParameter("Adventure", package.Adventure));

            sqlParam.Add(new SqlParameter("Speciality", package.Speciality));

            sqlParam.Add(new SqlParameter("PlaceToVisit", package.PlaceToVisit));

            sqlParam.Add(new SqlParameter("PackageStatus", package.Status));

            sqlParam.Add(new SqlParameter("UpdatedBy", package.UpdatedBy));

            sqlParam.Add(new SqlParameter("UpdatedDate", package.UpdatedDate));

            sqlParam.Add(new SqlParameter("DayDuration", package.DayDuration));

            sqlParam.Add(new SqlParameter("NightDuration", package.NightDuration));

          //  sqlParam.Add(new SqlParameter("Color", package.Color));


            return sqlParam;
        }

        public List<SqlParameter> SetValuesInPackageDetails(PackageInfo package)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (package.PackageId != 0)
            {
                sqlParam.Add(new SqlParameter("PackageId", package.PackageId));
            }

            sqlParam.Add(new SqlParameter("Inclusions", package.Inclusions));

            sqlParam.Add(new SqlParameter("Exclusions", package.Exclusions));

            sqlParam.Add(new SqlParameter("PaymentTems", package.PaymentTems));

            sqlParam.Add(new SqlParameter("TourRequirements", package.TourRequirements));

            sqlParam.Add(new SqlParameter("ThingsToCarryAlong", package.ThingsToCarryAlong));

            sqlParam.Add(new SqlParameter("Weather", package.Weather));

            sqlParam.Add(new SqlParameter("Shopping", package.Shopping));

            sqlParam.Add(new SqlParameter("TermsCondition", package.TermsCondition));

            sqlParam.Add(new SqlParameter("CancellationDetails", package.CancellationDetails));

            sqlParam.Add(new SqlParameter("RouteChanges", package.RouteChanges));

            sqlParam.Add(new SqlParameter("DosAndDonts", package.DosAndDonts));

            sqlParam.Add(new SqlParameter("UpdatedBy", package.UpdatedBy));

            sqlParam.Add(new SqlParameter("UpdatedDate", package.UpdatedDate));

            return sqlParam;
        }

        public int InsertPackageDate(PackageDatesInfo packagedate)
        {

            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInPackageDate(packagedate), Storeprocedures.spInsertPackageDates.ToString(), CommandType.StoredProcedure));

        }

        public List<SqlParameter> SetValuesInPackageDate(PackageDatesInfo packagedate)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (packagedate.PackageDateId != 0)
            {
                sqlParam.Add(new SqlParameter("PackageDateId", packagedate.PackageDateId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", packagedate.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", packagedate.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@PackageId", packagedate.PackageId));

            sqlParam.Add(new SqlParameter("@PackageStartDate", packagedate.PackageStartDate));

            sqlParam.Add(new SqlParameter("@PackageEndDate", packagedate.PackageEndDate));

            sqlParam.Add(new SqlParameter("@PackageCost", packagedate.PackageCost));

            sqlParam.Add(new SqlParameter("@UpdatedBy", packagedate.UpdatedBy));

            sqlParam.Add(new SqlParameter("@UpdatedDate", packagedate.UpdatedDate));

            return sqlParam;
        }

        public int InsertPackageItinerary(PackageItineraryInfo packageitinerary)
        {

            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInPackageItinerary(packageitinerary), Storeprocedures.spInsertPackageItinerary.ToString(), CommandType.StoredProcedure));

        }

        public List<SqlParameter> SetValuesInPackageItinerary(PackageItineraryInfo packageitinerary)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (packageitinerary.PackageItineraryId != 0)
            {
                sqlParam.Add(new SqlParameter("@PackageItineraryId", packageitinerary.PackageItineraryId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", packageitinerary.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", packageitinerary.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@PackageId", packageitinerary.PackageId));

            sqlParam.Add(new SqlParameter("@PackageDay", packageitinerary.Day));

            sqlParam.Add(new SqlParameter("@PackageDayTitle", packageitinerary.DayTitle));

            sqlParam.Add(new SqlParameter("@MealId", packageitinerary.MealId));

            sqlParam.Add(new SqlParameter("@SightSeeing", packageitinerary.SightSeeing));

            sqlParam.Add(new SqlParameter("@UpdatedBy", packageitinerary.UpdatedBy));

            sqlParam.Add(new SqlParameter("@UpdatedDate", packageitinerary.UpdatedDate));

            return sqlParam;
        }



        //Update Storeprocedures Call

        public void UpdatePackage(PackageInfo package)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInPackage(package), Storeprocedures.spUpdatePackage.ToString(), CommandType.StoredProcedure);

            var PackageType = package.PackageType.Split(',');

            if (PackageType.Length != 0)
            {
                List<SqlParameter> sqlParam = new List<SqlParameter>();

                sqlParam.Add(new SqlParameter("@PackageId", package.PackageId));

                _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeletePackageTypeMapping.ToString(), CommandType.StoredProcedure);

                foreach (var item in PackageType)
                {
                    if (item != "")
                    {
                        package.PackageTypeId = Convert.ToInt32(item);

                        _sqlHelper.ExecuteScalerObj(SetValuesInPackageTypeMapping(package), Storeprocedures.spInsertPackageTypeMapping.ToString(), CommandType.StoredProcedure);
                    }
                }
            }

        }

        public void UpdatePackageOtherDetails(PackageInfo package)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInPackageDetails(package), Storeprocedures.spUpdatePackageDetails.ToString(), CommandType.StoredProcedure);
        }

        public void UpdatePackageDate(PackageDatesInfo packagedate)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInPackageDate(packagedate), Storeprocedures.spUpdatePackageDates.ToString(), CommandType.StoredProcedure);
        }

        public void UpdatePackageItinerary(PackageItineraryInfo packageitinerary)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInPackageItinerary(packageitinerary), Storeprocedures.spUpdatePackageItinerary.ToString(), CommandType.StoredProcedure);
        }


        //Location Dropdown

        public List<CityInfo> drpGetCountryStateCity()
        {
            List<CityInfo> locations = new List<CityInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetCountryStateCity.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    locations.Add(GetCountryStateCityValues(dr));
                }
            }
            return locations;
        }

        public CityInfo GetCountryStateCityValues(DataRow dr)
        {
            CityInfo retVal = new CityInfo();

            retVal.CityId = Convert.ToInt32(dr["CityId"]);

            retVal.CityName = Convert.ToString(dr["Name"]);

            return retVal;
        }

        //City Dropdown

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

        //PackageType Dropdown

        public List<PackageTypeInfo> drpGetPackageTypes()
        {
            List<PackageTypeInfo> packagetypes = new List<PackageTypeInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetPackageTypes.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    packagetypes.Add(GetPackageTypeValues(dr));
                }
            }
            return packagetypes;
        }

        public PackageTypeInfo GetPackageTypeValues(DataRow dr)
        {
            PackageTypeInfo retVal = new PackageTypeInfo();

            retVal.PackageTypeId = Convert.ToInt32(dr["PackageTypeId"]);

            retVal.PackageTypeName = Convert.ToString(dr["PackageTypeName"]);

            return retVal;
        }

        // Hotel Dropdown

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

        // Meal Dropdown

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




        // Get Store Procs

        public DataTable GetPackage(string packageName, int packageCategoryId, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageName", packageName));

            sqlParam.Add(new SqlParameter("@PackageCategoryId", packageCategoryId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackage.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }

        public DataTable GetPackageDate(int packageId, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageId", packageId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageDateDetails.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }

        public DataTable GetPackageItinerary(int packageId, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageId", packageId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageItinerary.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }


        // Get By Id Store Procs

        public PackageInfo GetPackageById(int packageId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            PackageInfo Package = new PackageInfo();

            sqlParam.Add(new SqlParameter("@PackageId", packageId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageById.ToString(), CommandType.StoredProcedure);


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Package = GetPackageValues(dr);
                }
            }
            return Package;
        }

        public PackageDatesInfo GetPackageDateById(int packagedateId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            PackageDatesInfo PackageDate = new PackageDatesInfo();

            sqlParam.Add(new SqlParameter("@PackageDateId", packagedateId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageDateById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PackageDate = GetPackageDateValues(dr);
                }
            }
            return PackageDate;
        }

        public PackageItineraryInfo GetPackageItineraryById(int packageitineraryId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            PackageItineraryInfo PackageItinerary = new PackageItineraryInfo();

            sqlParam.Add(new SqlParameter("@PackageItineraryId", packageitineraryId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageItineraryById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PackageItinerary = GetPackageItineraryValues(dr);
                }
            }
            return PackageItinerary;
        }


        // Package Type Multiple List

        public List<PackageTypeMappingInfo> GetPackageTypeListById(int packageId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            List<PackageTypeMappingInfo> List = new List<PackageTypeMappingInfo>();

            sqlParam.Add(new SqlParameter("@PackageId", packageId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.GetPackageTypeListById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PackageTypeMappingInfo Info = new PackageTypeMappingInfo();

                    Info.PackageTypeId = Convert.ToInt32(dr["PackageTypeId"]);

                    List.Add(Info);
                }
            }
            return List;
        }


        // Get Values


        private PackageDatesInfo GetPackageDateValues(DataRow dr)
        {

            PackageDatesInfo PackageDate = new PackageDatesInfo();

            PackageDate.PackageDateId = Convert.ToInt32(dr["PackageDateId"]);

            if (!dr.IsNull("PackageStartDate"))
                PackageDate.PackageStartDate = Convert.ToString(dr["PackageStartDate"]);

            if (!dr.IsNull("PackageEndDate"))
                PackageDate.PackageEndDate = Convert.ToString(dr["PackageEndDate"]);

            if (!dr.IsNull("PackageCost"))
                PackageDate.PackageCost = Convert.ToInt32(dr["PackageCost"]);

            if (!dr.IsNull("PackageId"))
                PackageDate.PackageId = Convert.ToInt32(dr["PackageId"]);

            return PackageDate;

        }

        private PackageInfo GetPackageValues(DataRow dr)
        {
            PackageInfo Package = new PackageInfo();

            Package.PackageId = Convert.ToInt32(dr["PackageId"]);

            // Package Type Multiple List Start 

            Package.PackageTypeMappings = GetPackageTypeListById(Package.PackageId);

            // End

            if (!dr.IsNull("PackageName"))
                Package.PackageName = Convert.ToString(dr["PackageName"]);

            if (!dr.IsNull("PackageCode"))
                Package.PackageCode = Convert.ToString(dr["PackageCode"]);

            if (!dr.IsNull("PackageTypeId"))
                Package.PackageTypeId = Convert.ToInt32(dr["PackageTypeId"]);

            if (!dr.IsNull("PackageCategoryId"))
                Package.PackageCategoryId = Convert.ToInt32(dr["PackageCategoryId"]);

            //if (!dr.IsNull("PackageDuration"))
            //    Package.PackageDuration = Convert.ToString(dr["PackageDuration"]);

            if (!dr.IsNull("DepartureCityId"))
                Package.DepartureCityId = Convert.ToInt32(dr["DepartureCityId"]);

            if (!dr.IsNull("TourDroppingPoint"))
                Package.TourDroppingPoint = Convert.ToString(dr["TourDroppingPoint"]);

            if (!dr.IsNull("TourReportingPoint"))
                Package.TourReportingPoint = Convert.ToString(dr["TourReportingPoint"]);

            if (!dr.IsNull("PackageCost"))
                Package.PackageCost = Convert.ToInt32(dr["PackageCost"]);

            if (!dr.IsNull("Adventure"))
                Package.Adventure = Convert.ToString(dr["Adventure"]);

            if (!dr.IsNull("Speciality"))
                Package.Speciality = Convert.ToString(dr["Speciality"]);

            if (!dr.IsNull("PlaceToVisit"))
                Package.PlaceToVisit = Convert.ToString(dr["PlaceToVisit"]);

            if (!dr.IsNull("PackageStatus"))
                Package.Status = Convert.ToBoolean(dr["PackageStatus"]);

            if (!dr.IsNull("Inclusions"))
                Package.Inclusions = Convert.ToString(dr["Inclusions"]);

            if (!dr.IsNull("Exclusions"))
                Package.Exclusions = Convert.ToString(dr["Exclusions"]);

            if (!dr.IsNull("PaymentTems"))
                Package.PaymentTems = Convert.ToString(dr["PaymentTems"]);

            if (!dr.IsNull("TourRequirements"))
                Package.TourRequirements = Convert.ToString(dr["TourRequirements"]);

            if (!dr.IsNull("ThingsToCarryAlong"))
                Package.ThingsToCarryAlong = Convert.ToString(dr["ThingsToCarryAlong"]);

            if (!dr.IsNull("Weather"))
                Package.Weather = Convert.ToString(dr["Weather"]);

            if (!dr.IsNull("Shopping"))
                Package.Shopping = Convert.ToString(dr["Shopping"]);

            if (!dr.IsNull("TermsCondition"))
                Package.TermsCondition = Convert.ToString(dr["TermsCondition"]);

            if (!dr.IsNull("CancellationDetails"))
                Package.CancellationDetails = Convert.ToString(dr["CancellationDetails"]);

            if (!dr.IsNull("RouteChanges"))
                Package.RouteChanges = Convert.ToString(dr["RouteChanges"]);

            if (!dr.IsNull("DosAndDonts"))
                Package.DosAndDonts = Convert.ToString(dr["DosAndDonts"]);

            if (!dr.IsNull("DayDuration"))
                Package.DayDuration = Convert.ToInt32(dr["DayDuration"]);

            if (!dr.IsNull("NightDuration"))
                Package.NightDuration = Convert.ToInt32(dr["NightDuration"]);


            //if (!dr.IsNull("Color"))
            //    Package.Color = Convert.ToString(dr["Color"]);

            return Package;

        }

        private PackageItineraryInfo GetPackageItineraryValues(DataRow dr)
        {
            PackageItineraryInfo PackageItinerary = new PackageItineraryInfo();

            PackageItinerary.PackageItineraryId = Convert.ToInt32(dr["PackageItineraryId"]);

            if (!dr.IsNull("PackageId"))
                PackageItinerary.PackageId = Convert.ToInt32(dr["PackageId"]);

            if (!dr.IsNull("PackageDay"))
                PackageItinerary.Day = Convert.ToInt32(dr["PackageDay"]);

            if (!dr.IsNull("PackageDayTitle"))
                PackageItinerary.DayTitle = Convert.ToString(dr["PackageDayTitle"]);

            if (!dr.IsNull("MealId"))
                PackageItinerary.MealId = Convert.ToInt32(dr["MealId"]);

            if (!dr.IsNull("SightSeeing"))
                PackageItinerary.SightSeeing = Convert.ToString(dr["SightSeeing"]);

            return PackageItinerary;

        }

        // Delete

        public void DeletePackageDate(int packagedateId, int packageId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageDateId", packagedateId));

            sqlParam.Add(new SqlParameter("@PackageId", packageId));

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeletePackageDate.ToString(), CommandType.StoredProcedure);

        }

        public void DeletePackageItinerary(int packageItineraryId, int packageId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageItineraryId", packageItineraryId));

            sqlParam.Add(new SqlParameter("@PackageId", packageId));

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeletePackageItinerary.ToString(), CommandType.StoredProcedure);

        }


        // Check Exist


        public bool CheckPackageCodeExist(string PackageCode)
        {
            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@PackageCode", PackageCode));

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckPackageCodeExist.ToString(), CommandType.StoredProcedure));

        }

        public bool CheckPackageNameExist(string PackageName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@PackageName", PackageName));

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckPackageNameExist.ToString(), CommandType.StoredProcedure));

        }


        #region Package Itinerary Hotel

        public int InsertPackageItineraryHotel(PackageItineraryHotelsInfo packageItineraryHotelsInfo)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInPackageItineraryHotel(packageItineraryHotelsInfo), Storeprocedures.spInsertPackageItineraryHotel.ToString(), CommandType.StoredProcedure));
        }

        private List<SqlParameter> SetValuesInPackageItineraryHotel(PackageItineraryHotelsInfo packageItineraryHotelsInfo)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (packageItineraryHotelsInfo.PackageItineraryHotelId != 0)
            {
                sqlParam.Add(new SqlParameter("@PackageItineraryHotelId", packageItineraryHotelsInfo.PackageItineraryHotelId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedDate", packageItineraryHotelsInfo.CreatedDate));

                sqlParam.Add(new SqlParameter("@CreatedBy", packageItineraryHotelsInfo.CreatedBy));

                sqlParam.Add(new SqlParameter("@PackageItineraryId", packageItineraryHotelsInfo.PackageItineraryId));
            }

            sqlParam.Add(new SqlParameter("@HotelId", packageItineraryHotelsInfo.HotelId));

            sqlParam.Add(new SqlParameter("@Location", packageItineraryHotelsInfo.LocationId));

            sqlParam.Add(new SqlParameter("@SupplierId", packageItineraryHotelsInfo.SupplierId));

            sqlParam.Add(new SqlParameter("@HotelCost", packageItineraryHotelsInfo.HotelCost));

            sqlParam.Add(new SqlParameter("@UpdatedBy", packageItineraryHotelsInfo.UpdatedBy));

            sqlParam.Add(new SqlParameter("@UpdatedDate", packageItineraryHotelsInfo.UpdatedDate));

            return sqlParam;
        }

        public PackageItineraryHotelsInfo GetPackageItineraryHotelById(int packageitineraryhotelId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            PackageItineraryHotelsInfo PackageItineraryHotel = new PackageItineraryHotelsInfo();

            sqlParam.Add(new SqlParameter("@PackageItineraryHotelId", packageitineraryhotelId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageItineraryHotelById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PackageItineraryHotel = GetPackageItineraryHotelValues(dr);
                }
            }
            return PackageItineraryHotel;
        }

        private PackageItineraryHotelsInfo GetPackageItineraryHotelValues(DataRow dr)
        {
            PackageItineraryHotelsInfo PackageItineraryHotel = new PackageItineraryHotelsInfo();

            PackageItineraryHotel.PackageItineraryHotelId = Convert.ToInt32(dr["PackageItineraryHotelId"]);

            PackageItineraryHotel.PackageItineraryId = Convert.ToInt32(dr["PackageItineraryId"]);

            if (!dr.IsNull("HotelId"))
                PackageItineraryHotel.HotelId = Convert.ToInt32(dr["HotelId"]);

            PackageItineraryHotel.HotelName = Convert.ToString(dr["HotelName"]);

            if (!dr.IsNull("LocationId"))
                PackageItineraryHotel.LocationId = Convert.ToInt32(dr["LocationId"]);

            PackageItineraryHotel.Location = Convert.ToString(dr["Location"]);

            if (!dr.IsNull("SupplierId"))
                PackageItineraryHotel.SupplierId = Convert.ToInt32(dr["SupplierId"]);

            PackageItineraryHotel.SupplierName = Convert.ToString(dr["SupplierName"]);

            if (!dr.IsNull("HotelCost"))
                PackageItineraryHotel.HotelCost = Convert.ToDecimal(dr["HotelCost"]);

            return PackageItineraryHotel;
        }

        public void UpdatePackageItineraryHotel(PackageItineraryHotelsInfo packageItineraryHotelsInfo)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInPackageItineraryHotel(packageItineraryHotelsInfo), Storeprocedures.spUpdatePackageItineraryHotel.ToString(), CommandType.StoredProcedure);
        }

        public DataTable GetPackageItineraryHotels(int PackageItineraryId, ref PaginationInfo pager)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageItineraryId", PackageItineraryId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageItineraryHotels.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void DeletePackageItineraryHotel(int packageItineraryHotelId, int packageItineraryId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageItineraryId", packageItineraryId));

            sqlParam.Add(new SqlParameter("@PackageItineraryHotelId", packageItineraryHotelId));

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeletePackageItineraryHotel.ToString(), CommandType.StoredProcedure);
        }

        #endregion

        #region Package Itinerary Flight

        public int InsertPackageItineraryFlight(PackageItineraryFlightsInfo packageItineraryFlightsInfo)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInPackageItineraryFlight(packageItineraryFlightsInfo), Storeprocedures.spInsertPackageItineraryFlight.ToString(), CommandType.StoredProcedure));
        }

        private List<SqlParameter> SetValuesInPackageItineraryFlight(PackageItineraryFlightsInfo packageItineraryFlightsInfo)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (packageItineraryFlightsInfo.PackageItineraryFlightId != 0)
            {
                sqlParam.Add(new SqlParameter("@PackageItineraryFlightId", packageItineraryFlightsInfo.PackageItineraryFlightId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedDate", packageItineraryFlightsInfo.CreatedDate));

                sqlParam.Add(new SqlParameter("@CreatedBy", packageItineraryFlightsInfo.CreatedBy));

                sqlParam.Add(new SqlParameter("@PackageItineraryId", packageItineraryFlightsInfo.PackageItineraryId));
            }

            sqlParam.Add(new SqlParameter("@FlightName", packageItineraryFlightsInfo.FlightName));

            sqlParam.Add(new SqlParameter("@FlightFrom", packageItineraryFlightsInfo.FlightFrom));

            sqlParam.Add(new SqlParameter("@FlightTo", packageItineraryFlightsInfo.FlightTo));

            sqlParam.Add(new SqlParameter("@FlightTime", packageItineraryFlightsInfo.FlightTime));

            sqlParam.Add(new SqlParameter("@UpdatedBy", packageItineraryFlightsInfo.UpdatedBy));

            sqlParam.Add(new SqlParameter("@UpdatedDate", packageItineraryFlightsInfo.UpdatedDate));

            return sqlParam;
        }

        public PackageItineraryFlightsInfo GetPackageItineraryFlightById(int packageitineraryFlightId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            PackageItineraryFlightsInfo PackageItineraryFlight = new PackageItineraryFlightsInfo();

            sqlParam.Add(new SqlParameter("@PackageItineraryFlightId", packageitineraryFlightId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageItineraryFlightById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PackageItineraryFlight = GetPackageItineraryFlightValues(dr);
                }
            }
            return PackageItineraryFlight;
        }

        private PackageItineraryFlightsInfo GetPackageItineraryFlightValues(DataRow dr)
        {
            PackageItineraryFlightsInfo PackageItineraryFlight = new PackageItineraryFlightsInfo();

            PackageItineraryFlight.PackageItineraryFlightId = Convert.ToInt32(dr["PackageItineraryFlightId"]);

            PackageItineraryFlight.PackageItineraryId = Convert.ToInt32(dr["PackageItineraryId"]);

            PackageItineraryFlight.FlightFromName = Convert.ToString(dr["FlightFromName"]);

            PackageItineraryFlight.FlightToName = Convert.ToString(dr["FlightToName"]);

            PackageItineraryFlight.FlightFrom = Convert.ToInt32(dr["FlightFrom"]);

            PackageItineraryFlight.FlightTo = Convert.ToInt32(dr["FlightTo"]);

            PackageItineraryFlight.FlightName = Convert.ToString(dr["FlightName"]);

            PackageItineraryFlight.FlightTime = DateTime.ParseExact(dr["FlightTime"].ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);//Convert.ToDateTime(dr["FlightTime"]);

            return PackageItineraryFlight;
        }

        public void UpdatePackageItineraryFlight(PackageItineraryFlightsInfo packageItineraryFlightsInfo)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInPackageItineraryFlight(packageItineraryFlightsInfo), Storeprocedures.spUpdatePackageItineraryFlight.ToString(), CommandType.StoredProcedure);
        }

        public DataTable GetPackageItineraryFlights(int PackageItineraryId, ref PaginationInfo pager)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageItineraryId", PackageItineraryId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageItineraryFlights.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void DeletePackageItineraryFlight(int packageItineraryFlightId, int packageItineraryId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageItineraryId", packageItineraryId));

            sqlParam.Add(new SqlParameter("@PackageItineraryFlightId", packageItineraryFlightId));

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeletePackageItineraryFlight.ToString(), CommandType.StoredProcedure);
        }

        #endregion

        #region Package Itinerary Train

        public int InsertPackageItineraryTrain(PackageItineraryTrainsInfo packageItineraryTrainsInfo)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInPackageItineraryTrain(packageItineraryTrainsInfo), Storeprocedures.spInsertPackageItineraryTrain.ToString(), CommandType.StoredProcedure));
        }

        private List<SqlParameter> SetValuesInPackageItineraryTrain(PackageItineraryTrainsInfo packageItineraryTrainsInfo)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (packageItineraryTrainsInfo.PackageItineraryTrainId != 0)
            {
                sqlParam.Add(new SqlParameter("@PackageItineraryTrainId", packageItineraryTrainsInfo.PackageItineraryTrainId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedDate", packageItineraryTrainsInfo.CreatedDate));

                sqlParam.Add(new SqlParameter("@CreatedBy", packageItineraryTrainsInfo.CreatedBy));

                sqlParam.Add(new SqlParameter("@PackageItineraryId", packageItineraryTrainsInfo.PackageItineraryId));
            }

            sqlParam.Add(new SqlParameter("@TrainName", packageItineraryTrainsInfo.TrainName));

            sqlParam.Add(new SqlParameter("@TrainFrom", packageItineraryTrainsInfo.TrainFrom));

            sqlParam.Add(new SqlParameter("@TrainTo", packageItineraryTrainsInfo.TrainTo));

            sqlParam.Add(new SqlParameter("@TrainTime", packageItineraryTrainsInfo.TrainTime));

            sqlParam.Add(new SqlParameter("@UpdatedBy", packageItineraryTrainsInfo.UpdatedBy));

            sqlParam.Add(new SqlParameter("@UpdatedDate", packageItineraryTrainsInfo.UpdatedDate));

            return sqlParam;
        }

        public PackageItineraryTrainsInfo GetPackageItineraryTrainById(int packageitineraryTrainId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            PackageItineraryTrainsInfo PackageItineraryTrain = new PackageItineraryTrainsInfo();

            sqlParam.Add(new SqlParameter("@PackageItineraryTrainId", packageitineraryTrainId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageItineraryTrainById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PackageItineraryTrain = GetPackageItineraryTrainValues(dr);
                }
            }
            return PackageItineraryTrain;
        }

        private PackageItineraryTrainsInfo GetPackageItineraryTrainValues(DataRow dr)
        {
            PackageItineraryTrainsInfo PackageItineraryTrain = new PackageItineraryTrainsInfo();

            PackageItineraryTrain.PackageItineraryTrainId = Convert.ToInt32(dr["PackageItineraryTrainId"]);

            PackageItineraryTrain.PackageItineraryId = Convert.ToInt32(dr["PackageItineraryId"]);

            PackageItineraryTrain.TrainFromName = Convert.ToString(dr["TrainFromName"]);

            PackageItineraryTrain.TrainToName = Convert.ToString(dr["TrainToName"]);

            PackageItineraryTrain.TrainFrom = Convert.ToInt32(dr["TrainFrom"]);

            PackageItineraryTrain.TrainTo = Convert.ToInt32(dr["TrainTo"]);

            PackageItineraryTrain.TrainName = Convert.ToString(dr["TrainName"]);

            PackageItineraryTrain.TrainTime = DateTime.ParseExact(dr["TrainTime"].ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);//Convert.ToDateTime(dr["TrainTime"]);

            return PackageItineraryTrain;
        }

        public void UpdatePackageItineraryTrain(PackageItineraryTrainsInfo packageItineraryTrainsInfo)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInPackageItineraryTrain(packageItineraryTrainsInfo), Storeprocedures.spUpdatePackageItineraryTrain.ToString(), CommandType.StoredProcedure);
        }

        public DataTable GetPackageItineraryTrains(int PackageItineraryId, ref PaginationInfo pager)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageItineraryId", PackageItineraryId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageItineraryTrains.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void DeletePackageItineraryTrain(int packageItineraryTrainId, int packageItineraryId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageItineraryId", packageItineraryId));

            sqlParam.Add(new SqlParameter("@PackageItineraryTrainId", packageItineraryTrainId));

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeletePackageItineraryTrain.ToString(), CommandType.StoredProcedure);
        }

        #endregion

        #region Package Itinerary Bus

        public int InsertPackageItineraryBus(PackageItineraryBusesInfo packageItineraryBussInfo)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInPackageItineraryBus(packageItineraryBussInfo), Storeprocedures.spInsertPackageItineraryBus.ToString(), CommandType.StoredProcedure));
        }

        private List<SqlParameter> SetValuesInPackageItineraryBus(PackageItineraryBusesInfo packageItineraryBussInfo)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (packageItineraryBussInfo.PackageItineraryBusId != 0)
            {
                sqlParam.Add(new SqlParameter("@PackageItineraryBusId", packageItineraryBussInfo.PackageItineraryBusId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedDate", packageItineraryBussInfo.CreatedDate));

                sqlParam.Add(new SqlParameter("@CreatedBy", packageItineraryBussInfo.CreatedBy));

                sqlParam.Add(new SqlParameter("@PackageItineraryId", packageItineraryBussInfo.PackageItineraryId));
            }

            sqlParam.Add(new SqlParameter("@BusName", packageItineraryBussInfo.BusName));

            sqlParam.Add(new SqlParameter("@BusFrom", packageItineraryBussInfo.BusFrom));

            sqlParam.Add(new SqlParameter("@BusTo", packageItineraryBussInfo.BusTo));

            sqlParam.Add(new SqlParameter("@BusTime", packageItineraryBussInfo.BusTime));

            sqlParam.Add(new SqlParameter("@SupplierId", packageItineraryBussInfo.SupplierId));

            sqlParam.Add(new SqlParameter("@BusCost", packageItineraryBussInfo.BusCost));

            sqlParam.Add(new SqlParameter("@UpdatedBy", packageItineraryBussInfo.UpdatedBy));

            sqlParam.Add(new SqlParameter("@UpdatedDate", packageItineraryBussInfo.UpdatedDate));

            return sqlParam;
        }

        public PackageItineraryBusesInfo GetPackageItineraryBusById(int packageitineraryBusId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            PackageItineraryBusesInfo PackageItineraryBus = new PackageItineraryBusesInfo();

            sqlParam.Add(new SqlParameter("@PackageItineraryBusId", packageitineraryBusId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageItineraryBusById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PackageItineraryBus = GetPackageItineraryBusValues(dr);
                }
            }
            return PackageItineraryBus;
        }

        private PackageItineraryBusesInfo GetPackageItineraryBusValues(DataRow dr)
        {
            PackageItineraryBusesInfo PackageItineraryBus = new PackageItineraryBusesInfo();

            PackageItineraryBus.PackageItineraryBusId = Convert.ToInt32(dr["PackageItineraryBusId"]);

            PackageItineraryBus.PackageItineraryId = Convert.ToInt32(dr["PackageItineraryId"]);

            PackageItineraryBus.BusFromName = Convert.ToString(dr["BusFromName"]);

            PackageItineraryBus.BusToName = Convert.ToString(dr["BusToName"]);

            PackageItineraryBus.BusFrom = Convert.ToInt32(dr["BusFrom"]);

            PackageItineraryBus.BusTo = Convert.ToInt32(dr["BusTo"]);

            PackageItineraryBus.BusName = Convert.ToString(dr["BusName"]);

            PackageItineraryBus.SupplierId = Convert.ToInt32(dr["SupplierId"]);

            PackageItineraryBus.BusCost = Convert.ToDecimal(dr["BusCost"]);

            // = DateTime.ParseExact(dr["VehicleTime"].ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);//Convert.ToDateTime(dr["VehicleTime"]);


            DateTime bustime = DateTime.ParseExact(dr["BusTime"].ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);

            PackageItineraryBus.BusTime = Convert.ToDateTime(bustime.ToString("HH:mm:ss"));
            //PackageItineraryBus.BusTime = Convert.ToDateTime(dr["BusTime"]); // Converts only the time

            //(BusTime.ToString("HH:mm:ss"));

            return PackageItineraryBus;
        }

        public void UpdatePackageItineraryBus(PackageItineraryBusesInfo packageItineraryBussInfo)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInPackageItineraryBus(packageItineraryBussInfo), Storeprocedures.spUpdatePackageItineraryBus.ToString(), CommandType.StoredProcedure);
        }

        public DataTable GetPackageItineraryBuss(int PackageItineraryId, ref PaginationInfo pager)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageItineraryId", PackageItineraryId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageItineraryBuss.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void DeletePackageItineraryBus(int packageItineraryBusId, int packageItineraryId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageItineraryId", packageItineraryId));

            sqlParam.Add(new SqlParameter("@PackageItineraryBusId", packageItineraryBusId));

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeletePackageItineraryBus.ToString(), CommandType.StoredProcedure);
        }

        #endregion

        #region Package Itinerary Vehicle

        public int InsertPackageItineraryVehicle(PackageItineraryVehiclesInfo packageItineraryVehiclesInfo)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInPackageItineraryVehicle(packageItineraryVehiclesInfo), Storeprocedures.spInsertPackageItineraryVehicle.ToString(), CommandType.StoredProcedure));
        }

        private List<SqlParameter> SetValuesInPackageItineraryVehicle(PackageItineraryVehiclesInfo packageItineraryVehiclesInfo)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (packageItineraryVehiclesInfo.PackageItineraryVehicleId != 0)
            {
                sqlParam.Add(new SqlParameter("@PackageItineraryVehicleId", packageItineraryVehiclesInfo.PackageItineraryVehicleId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedDate", packageItineraryVehiclesInfo.CreatedDate));

                sqlParam.Add(new SqlParameter("@CreatedBy", packageItineraryVehiclesInfo.CreatedBy));

                sqlParam.Add(new SqlParameter("@PackageItineraryId", packageItineraryVehiclesInfo.PackageItineraryId));
            }

            sqlParam.Add(new SqlParameter("@VehicleName", packageItineraryVehiclesInfo.VehicleName));

            sqlParam.Add(new SqlParameter("@VehicleFrom", packageItineraryVehiclesInfo.VehicleFrom));

            sqlParam.Add(new SqlParameter("@VehicleTo", packageItineraryVehiclesInfo.VehicleTo));

            sqlParam.Add(new SqlParameter("@PickUp", packageItineraryVehiclesInfo.PickUp));

            sqlParam.Add(new SqlParameter("@DropOff", packageItineraryVehiclesInfo.DropOff));

            sqlParam.Add(new SqlParameter("@VehicleTime", packageItineraryVehiclesInfo.VehicleTime));

            sqlParam.Add(new SqlParameter("@SupplierId", packageItineraryVehiclesInfo.SupplierId));

            sqlParam.Add(new SqlParameter("@VehicleCost", packageItineraryVehiclesInfo.VehicleCost));

            sqlParam.Add(new SqlParameter("@UpdatedBy", packageItineraryVehiclesInfo.UpdatedBy));

            sqlParam.Add(new SqlParameter("@UpdatedDate", packageItineraryVehiclesInfo.UpdatedDate));

            return sqlParam;
        }

        public PackageItineraryVehiclesInfo GetPackageItineraryVehicleById(int packageitineraryVehicleId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            PackageItineraryVehiclesInfo PackageItineraryVehicle = new PackageItineraryVehiclesInfo();

            sqlParam.Add(new SqlParameter("@PackageItineraryVehicleId", packageitineraryVehicleId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageItineraryVehicleById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PackageItineraryVehicle = GetPackageItineraryVehicleValues(dr);
                }
            }
            return PackageItineraryVehicle;
        }

        private PackageItineraryVehiclesInfo GetPackageItineraryVehicleValues(DataRow dr)
        {
            PackageItineraryVehiclesInfo PackageItineraryVehicle = new PackageItineraryVehiclesInfo();

            PackageItineraryVehicle.PackageItineraryVehicleId = Convert.ToInt32(dr["PackageItineraryVehicleId"]);

            PackageItineraryVehicle.PackageItineraryId = Convert.ToInt32(dr["PackageItineraryId"]);

            PackageItineraryVehicle.VehicleFromName = Convert.ToString(dr["VehicleFromName"]);

            PackageItineraryVehicle.VehicleName = Convert.ToString(dr["VehicleName"]);

            PackageItineraryVehicle.VehicleToName = Convert.ToString(dr["VehicleToName"]);

            PackageItineraryVehicle.VehicleFrom = Convert.ToInt32(dr["VehicleFrom"]);

            PackageItineraryVehicle.VehicleTo = Convert.ToInt32(dr["VehicleTo"]);

            PackageItineraryVehicle.PickUp = Convert.ToInt32(dr["PickUp"]);

            PackageItineraryVehicle.DropOff = Convert.ToInt32(dr["DropOff"]);

            PackageItineraryVehicle.SupplierId = Convert.ToInt32(dr["SupplierId"]);

            PackageItineraryVehicle.supplierName = Convert.ToString(dr["supplierName"]);

            PackageItineraryVehicle.VehicleCost = Convert.ToDecimal(dr["VehicleCost"]);

            PackageItineraryVehicle.VehicleTime = DateTime.ParseExact(dr["VehicleTime"].ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);//Convert.ToDateTime(dr["VehicleTime"]);

            return PackageItineraryVehicle;
        }

        public void UpdatePackageItineraryVehicle(PackageItineraryVehiclesInfo packageItineraryVehiclesInfo)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInPackageItineraryVehicle(packageItineraryVehiclesInfo), Storeprocedures.spUpdatePackageItineraryVehicle.ToString(), CommandType.StoredProcedure);
        }

        public DataTable GetPackageItineraryVehicles(int PackageItineraryId, ref PaginationInfo pager)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageItineraryId", PackageItineraryId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageItineraryVehicles.ToString(), CommandType.StoredProcedure);

            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add("PickUpName", typeof(System.String));
                dt.Columns.Add("DropOffName", typeof(System.String));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    foreach (var item in LookupInfo.GetPickUpAndDropOff())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["PickUp"]) == item.Key)
                        {
                            dt.Rows[i]["PickUpName"] = item.Value;
                        }

                        if (Convert.ToInt32(dt.Rows[i]["DropOff"]) == item.Key)
                        {
                            dt.Rows[i]["DropOffName"] = item.Value;
                        }
                    }
                }
            }

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void DeletePackageItineraryVehicle(int packageItineraryVehicleId, int packageItineraryId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageItineraryId", packageItineraryId));

            sqlParam.Add(new SqlParameter("@PackageItineraryVehicleId", packageItineraryVehicleId));

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeletePackageItineraryVehicle.ToString(), CommandType.StoredProcedure);
        }

        #endregion

        public List<PackageItineraryInfo> GetPackageItineraryDtailsById(int packageId)
        {
            PackageInfo package = new PackageInfo();
            List<PackageItineraryInfo> PackageItineraryInfo_list = new List<PackageItineraryInfo>();

            package = GetPackageById(packageId);

            //package = GetPackageById(packageId);

            package.PackageItinerarys = GetPackageItinerary(packageId);

            foreach (var item in package.PackageItinerarys)
            {

                item.PackageItineraryHotels = GetPackgeItinerayHotelsByPackageItineraryId(item.PackageItineraryId);
                item.PackageItineraryFlights = GetPackgeItinerayFlightsByPackageItineraryId(item.PackageItineraryId);
                item.PackageItineraryTrains = GetPackgeItinerayTrainsByPackageItineraryId(item.PackageItineraryId);
                item.PackageItineraryBuses = GetPackgeItinerayBusesByPackageItineraryId(item.PackageItineraryId);
                item.PackageItineraryVehicles = GetPackgeItinerayVehiclesByPackageItineraryId(item.PackageItineraryId);

            }




            return package.PackageItinerarys;
        }


        public List<PackageDatesInfo> GetPackagedatesById(int packageId)
        {
            PackageInfo package = new PackageInfo();
            List<PackageDatesInfo> PackageDatesInfo_list = new List<PackageDatesInfo>();


            package = GetPackageById(packageId);

            // package.PackageDates = GetPackageDate(packageId);

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageId", packageId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageDateDetails.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                PackageDatesInfo PackageDatesInfo = new PackageDatesInfo();
                PackageDatesInfo.PackageStartDate = Convert.ToDateTime(dr["PackageStartDate"]).ToString("dd/MM/yyyy");
                PackageDatesInfo.PackageEndDate = Convert.ToDateTime(dr["PackageEndDate"]).ToString("dd/MM/yyyy");

                package.PackageDates.Add(PackageDatesInfo);

            }


            return package.PackageDates;
        }


        public List<PackageInfo> GetPackagesById(int packageId)
        {
            PackageInfo package = new PackageInfo();
            List<PackageInfo> PackageInfo_list = new List<PackageInfo>();


            package = GetPackageById(packageId);

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageId", packageId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageById.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                PackageInfo PackageInfo = new PackageInfo();

                if (!dr.IsNull("Inclusions"))
                    PackageInfo.Inclusions = Convert.ToString(dr["Inclusions"]);

                if (!dr.IsNull("Exclusions"))
                    PackageInfo.Exclusions = Convert.ToString(dr["Exclusions"]);

                if (!dr.IsNull("PaymentTems"))
                    PackageInfo.PaymentTems = Convert.ToString(dr["PaymentTems"]);

                if (!dr.IsNull("TourRequirements"))
                    PackageInfo.TourRequirements = Convert.ToString(dr["TourRequirements"]);

                if (!dr.IsNull("ThingsToCarryAlong"))
                    PackageInfo.ThingsToCarryAlong = Convert.ToString(dr["ThingsToCarryAlong"]);

                if (!dr.IsNull("Weather"))
                    PackageInfo.Weather = Convert.ToString(dr["Weather"]);

                if (!dr.IsNull("Shopping"))
                    PackageInfo.Shopping = Convert.ToString(dr["Shopping"]);

                if (!dr.IsNull("TermsCondition"))
                    PackageInfo.TermsCondition = Convert.ToString(dr["TermsCondition"]);

                if (!dr.IsNull("CancellationDetails"))
                    PackageInfo.CancellationDetails = Convert.ToString(dr["CancellationDetails"]);

                if (!dr.IsNull("RouteChanges"))
                    PackageInfo.RouteChanges = Convert.ToString(dr["RouteChanges"]);

                if (!dr.IsNull("DosAndDonts"))
                    PackageInfo.DosAndDonts = Convert.ToString(dr["DosAndDonts"]);

                //if (!dr.IsNull("MealName"))
                //    PackageInfo.MealName = Convert.ToString(dr["MealName"]);




                PackageInfo_list.Add(PackageInfo);

            }


            return PackageInfo_list;
        }





        public PackageInfo GetPackagesInfoById(int packageId)
        {
            PackageInfo package = new PackageInfo();
            // List<PackageInfo> PackageInfo_list = new List<PackageInfo>();


            package = GetPackageById(packageId);

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageId", packageId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageById.ToString(), CommandType.StoredProcedure);
            PackageInfo PackageInfo = new PackageInfo();
            foreach (DataRow dr in dt.Rows)
            {


                if (!dr.IsNull("Inclusions"))
                    PackageInfo.Inclusions = Convert.ToString(dr["Inclusions"]);

                if (!dr.IsNull("Exclusions"))
                    PackageInfo.Exclusions = Convert.ToString(dr["Exclusions"]);

                if (!dr.IsNull("PaymentTems"))
                    PackageInfo.PaymentTems = Convert.ToString(dr["PaymentTems"]);

                if (!dr.IsNull("TourRequirements"))
                    PackageInfo.TourRequirements = Convert.ToString(dr["TourRequirements"]);

                if (!dr.IsNull("ThingsToCarryAlong"))
                    PackageInfo.ThingsToCarryAlong = Convert.ToString(dr["ThingsToCarryAlong"]);

                if (!dr.IsNull("Weather"))
                    PackageInfo.Weather = Convert.ToString(dr["Weather"]);

                if (!dr.IsNull("Shopping"))
                    PackageInfo.Shopping = Convert.ToString(dr["Shopping"]);

                if (!dr.IsNull("TermsCondition"))
                    PackageInfo.TermsCondition = Convert.ToString(dr["TermsCondition"]);

                if (!dr.IsNull("CancellationDetails"))
                    PackageInfo.CancellationDetails = Convert.ToString(dr["CancellationDetails"]);

                if (!dr.IsNull("RouteChanges"))
                    PackageInfo.RouteChanges = Convert.ToString(dr["RouteChanges"]);

                if (!dr.IsNull("DosAndDonts"))
                    PackageInfo.DosAndDonts = Convert.ToString(dr["DosAndDonts"]);

                //if (!dr.IsNull("MealName"))
                //    PackageInfo.MealName = Convert.ToString(dr["MealName"]);

                if (!dr.IsNull("PackageName"))
                    PackageInfo.PackageName = Convert.ToString(dr["PackageName"]);

                if (!dr.IsNull("PackageCost"))
                    PackageInfo.PackageCost = Convert.ToInt32(dr["PackageCost"]);

                //if (!dr.IsNull("PackageDuration"))
                //    PackageInfo.PackageDuration = Convert.ToString(dr["PackageDuration"]);

                if (!dr.IsNull("PackageTypeName"))
                    PackageInfo.PackageType = Convert.ToString(dr["PackageTypeName"]);

                if (!dr.IsNull("PackageCategoryStr"))
                    PackageInfo.PackageCategoryName = Convert.ToString(dr["PackageCategoryStr"]);
                
                //  PackageInfo_list.Add(PackageInfo);

            }


            return PackageInfo;
        }

        public List<PackageDaysTriffInfo> Get_PackageGitTariffDays(int PackageId)
        {
            List<PackageDaysTriffInfo> packagedays = new List<PackageDaysTriffInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@PackageId", PackageId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_PackageGitDays.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    packagedays.Add(Get_PackageGitDays_Values(dr));
                }
            }

            return packagedays;
        }

        private PackageDaysTriffInfo Get_PackageGitDays_Values(DataRow dr)
        {
            PackageDaysTriffInfo packagedays = new PackageDaysTriffInfo();

            packagedays.PackageDayId = Convert.ToInt32(dr["PackageDayId"]);
            packagedays.PackageId = Convert.ToInt32(dr["PackageId"]);
            packagedays.CityId = Convert.ToInt32(dr["CityId"]);
            packagedays.Title = Convert.ToString(dr["Title"]);
            packagedays.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
            packagedays.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            packagedays.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
            packagedays.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            packagedays.PackageDayitem = Get_PackageGitTariffDayItems(packagedays.PackageDayId);

            return packagedays;
        }

        public List<PackageDayitemTriffinfo> Get_PackageGitTariffDayItems(int PackageDayId)
        {
            List<PackageDayitemTriffinfo> packagetriff = new List<PackageDayitemTriffinfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@PackageDayId", PackageDayId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_GitDayItems.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    packagetriff.Add(Get_PackageGitDayItems_Values(dr));
                }
            }

            return packagetriff;
        }


        private PackageDayitemTriffinfo Get_PackageGitDayItems_Values(DataRow dr)
        {
            PackageDayitemTriffinfo PackageDayitemTrif = new PackageDayitemTriffinfo();

            PackageDayitemTrif.PackageItemDayID = Convert.ToInt32(dr["PackageItemDayID"]);
            PackageDayitemTrif.PackageDayId = Convert.ToInt32(dr["PackageDayId"]);
            PackageDayitemTrif.RefID = Convert.ToInt32(dr["RefID"]);
            PackageDayitemTrif.HotelId = Convert.ToInt32(dr["HotelId"]);
            PackageDayitemTrif.RoomTypeId = Convert.ToInt32(dr["RoomTypeId"]);
            PackageDayitemTrif.SighSeeingID = Convert.ToInt32(dr["SighSeeingID"]);
            PackageDayitemTrif.VehicalId = Convert.ToInt32(dr["VehicalId"]);
            PackageDayitemTrif.MealId = Convert.ToInt32(dr["MealId"]);
            PackageDayitemTrif.HotelName = Convert.ToString(dr["HotelName"]);
            PackageDayitemTrif.SightSeeingName = Convert.ToString(dr["SightSeeingName"]);
            PackageDayitemTrif.VehicleName = Convert.ToString(dr["VehicleName"]);
            PackageDayitemTrif.MealName = Convert.ToString(dr["MealName"]);
            PackageDayitemTrif.RoomTypeName = Convert.ToString(dr["RoomTypeName"]);
            PackageDayitemTrif.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
            PackageDayitemTrif.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            PackageDayitemTrif.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
            PackageDayitemTrif.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            return PackageDayitemTrif;
        }


        public void Insert_PackageDayItem(PackageDayitemTriffinfo PackageDayitemTrif)
        {
            _sqlHelper.ExecuteNonQuery(Set_Values_In_GitDayItem(PackageDayitemTrif), Storeprocedures.sp_Insert_GitItinararyDayItem.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_GitDayItem(PackageDayitemTriffinfo PackageDayitemTrif)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            if (PackageDayitemTrif.PackageItemDayID != 0)
            {
                sqlParams.Add(new SqlParameter("@PackageItemDayID", PackageDayitemTrif.PackageItemDayID));
            }

            sqlParams.Add(new SqlParameter("@PackageDayId", PackageDayitemTrif.PackageDayId));

            if (PackageDayitemTrif.HotelId != 0)
            {
                sqlParams.Add(new SqlParameter("@RefType", (int)SupplierTariffItem.Hotel));
            }
            else if (PackageDayitemTrif.SighSeeingID != 0)
            {
                sqlParams.Add(new SqlParameter("@RefType", (int)SupplierTariffItem.SightSeeing));
            }
            else if (PackageDayitemTrif.VehicalId != 0)
            {
                sqlParams.Add(new SqlParameter("@RefType", (int)SupplierTariffItem.Vehicle));
            }
            else if (PackageDayitemTrif.MealId != 0)
            {
                sqlParams.Add(new SqlParameter("@RefType", (int)SupplierTariffItem.Meal));
            }
            else
            {

            }

            sqlParams.Add(new SqlParameter("@HotelId", PackageDayitemTrif.HotelId));
            sqlParams.Add(new SqlParameter("@RoomTypeId", PackageDayitemTrif.RoomTypeId));
            sqlParams.Add(new SqlParameter("@SightSeeingId", PackageDayitemTrif.SighSeeingID));
            sqlParams.Add(new SqlParameter("@VehicleId", PackageDayitemTrif.VehicalId));
            sqlParams.Add(new SqlParameter("@MealId", PackageDayitemTrif.MealId));
            sqlParams.Add(new SqlParameter("@CreatedDate", PackageDayitemTrif.CreatedDate));
            sqlParams.Add(new SqlParameter("@CreatedBy", PackageDayitemTrif.CreatedBy));
            sqlParams.Add(new SqlParameter("@UpdatedDate", PackageDayitemTrif.UpdatedDate));
            sqlParams.Add(new SqlParameter("@UpdatedBy", PackageDayitemTrif.UpdatedBy));
            return sqlParams;
        }



        public void DeleteDayItem(int PackageItemDayID)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@PackageItemDayID", PackageItemDayID));

            _sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.spDeleteGitDayItems.ToString(), CommandType.StoredProcedure);
        }









        private PackageItineraryInfo GetPackageItineraryDtailsValues(DataRow dr)
        {


            PackageItineraryInfo PackageItineraryInfo = new LohanaBusinessEntities.Package.PackageItineraryInfo();

            if (!dr.IsNull("PackageDay"))
                PackageItineraryInfo.Day = Convert.ToInt32(dr["PackageDay"]);

            if (!dr.IsNull("PackageDayTitle"))
                PackageItineraryInfo.DayTitle = Convert.ToString(dr["PackageDayTitle"]);

            if (!dr.IsNull("SightSeeing"))
                PackageItineraryInfo.SightSeeing = Convert.ToString(dr["SightSeeing"]);

            if (!dr.IsNull("MealId"))
                PackageItineraryInfo.MealId = Convert.ToInt32(dr["MealId"]);

            if (!dr.IsNull("MealName"))
                PackageItineraryInfo.MealName = Convert.ToString(dr["MealName"]);

            if (!dr.IsNull("PackageItineraryId"))
                PackageItineraryInfo.PackageItineraryId = Convert.ToInt32(dr["PackageItineraryId"]);


            //if (!dr.IsNull("CityName"))
            //    PackageItineraryInfo.PackageItineraryHotel.Location = Convert.ToString(dr["CityName"]);

            //if (!dr.IsNull("HotelName"))
            //    PackageItineraryInfo.PackageItineraryHotel.HotelName = Convert.ToString(dr["HotelName"]);

            //if (!dr.IsNull("FlightName"))
            //    PackageItineraryInfo.PackageItineraryFlight.FlightName = Convert.ToString(dr["FlightName"]);

            //if (!dr.IsNull("FlightFrom"))
            //    PackageItineraryInfo.PackageItineraryFlight.FlightFrom = Convert.ToInt32(dr["FlightFrom"]);

            //if (!dr.IsNull("FlightTo"))
            //    PackageItineraryInfo.PackageItineraryFlight.FlightTo = Convert.ToInt32(dr["FlightTo"]);

            //if (!dr.IsNull("FlightTime"))
            //    PackageItineraryInfo.PackageItineraryFlight.FlightTime = DateTime.ParseExact(dr["FlightTime"].ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);

            //if (!dr.IsNull("TrainName"))
            //    PackageItineraryInfo.PackageItineraryTrain.TrainName = Convert.ToString(dr["TrainName"]);

            //if (!dr.IsNull("TrainFrom"))
            //    PackageItineraryInfo.PackageItineraryTrain.TrainFrom = Convert.ToInt32(dr["TrainFrom"]);

            //if (!dr.IsNull("TrainTo"))
            //    PackageItineraryInfo.PackageItineraryTrain.TrainTo = Convert.ToInt32(dr["TrainTo"]);

            //if (!dr.IsNull("TrainTime"))
            //    PackageItineraryInfo.PackageItineraryTrain.TrainTime = DateTime.ParseExact(dr["TrainTime"].ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);

            //if (!dr.IsNull("BusName"))
            //    PackageItineraryInfo.PackageItineraryBus.BusName = Convert.ToString(dr["BusName"]);

            //if (!dr.IsNull("BusFrom"))
            //    PackageItineraryInfo.PackageItineraryBus.BusFrom = Convert.ToInt32(dr["BusFrom"]);

            //if (!dr.IsNull("BusTo"))
            //    PackageItineraryInfo.PackageItineraryBus.BusTo = Convert.ToInt32(dr["BusTo"]);

            //if (!dr.IsNull("BusTime"))
            //    PackageItineraryInfo.PackageItineraryBus.BusTime = DateTime.ParseExact(dr["BusTime"].ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);

            //if (!dr.IsNull("VehicleName"))
            //    PackageItineraryInfo.PackageItineraryVehicle.VehicleName = Convert.ToString(dr["VehicleName"]);

            //if (!dr.IsNull("VehicleFrom"))
            //    PackageItineraryInfo.PackageItineraryVehicle.VehicleFrom = Convert.ToInt32(dr["VehicleFrom"]);

            //if (!dr.IsNull("VehicleTo"))
            //    PackageItineraryInfo.PackageItineraryVehicle.VehicleTo = Convert.ToInt32(dr["VehicleTo"]);

            //if (!dr.IsNull("PickUp"))
            //    PackageItineraryInfo.PackageItineraryVehicle.PickUp = Convert.ToInt32(dr["PickUp"]);

            //if (!dr.IsNull("DropOff"))
            //    PackageItineraryInfo.PackageItineraryVehicle.DropOff = Convert.ToInt32(dr["DropOff"]);

            //if (!dr.IsNull("VehicleTime"))
            //    PackageItineraryInfo.PackageItineraryVehicle.VehicleTime = DateTime.ParseExact(dr["VehicleTime"].ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);


            return PackageItineraryInfo;

        }

        public List<PackageItineraryInfo> GetPackageItinerary(int packageId)
        {

            List<PackageItineraryInfo> it = new List<PackageItineraryInfo>();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageId", packageId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageItinerary.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                PackageItineraryInfo PackageItineraryInfo = new LohanaBusinessEntities.Package.PackageItineraryInfo();
                PackageItineraryInfo = GetPackageItineraryDtailsValues(dr);


                it.Add(PackageItineraryInfo);
            }


            return it;

        }

        public List<PackageItineraryHotelsInfo> GetPackgeItinerayHotelsByPackageItineraryId(int PackageItineraryId)
        {
            List<PackageItineraryHotelsInfo> packageItinerayHotels = new List<PackageItineraryHotelsInfo>();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageItineraryId", PackageItineraryId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageItineraryHotels.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    packageItinerayHotels.Add(GetPackageItineraryHotelValues(dr));
                }
            }

            return packageItinerayHotels;
        }

        public List<PackageItineraryFlightsInfo> GetPackgeItinerayFlightsByPackageItineraryId(int PackageItineraryId)
        {
            List<PackageItineraryFlightsInfo> packageItinerayFlights = new List<PackageItineraryFlightsInfo>();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageItineraryId", PackageItineraryId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageItineraryFlights.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    packageItinerayFlights.Add(GetPackageItineraryFlightValues(dr));
                }
            }

            return packageItinerayFlights;
        }


        public List<PackageItineraryTrainsInfo> GetPackgeItinerayTrainsByPackageItineraryId(int PackageItineraryId)
        {
            List<PackageItineraryTrainsInfo> packageItinerayTrains = new List<PackageItineraryTrainsInfo>();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageItineraryId", PackageItineraryId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageItineraryTrains.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    packageItinerayTrains.Add(GetPackageItineraryTrainValues(dr));
                }
            }

            return packageItinerayTrains;
        }


        public List<PackageItineraryBusesInfo> GetPackgeItinerayBusesByPackageItineraryId(int PackageItineraryId)
        {
            List<PackageItineraryBusesInfo> packageItinerayBuses = new List<PackageItineraryBusesInfo>();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageItineraryId", PackageItineraryId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageItineraryBuss.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    packageItinerayBuses.Add(GetPackageItineraryBusValues(dr));
                }
            }

            return packageItinerayBuses;
        }

        public List<PackageItineraryVehiclesInfo> GetPackgeItinerayVehiclesByPackageItineraryId(int PackageItineraryId)
        {
            List<PackageItineraryVehiclesInfo> packageItinerayVehicles = new List<PackageItineraryVehiclesInfo>();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@PackageItineraryId", PackageItineraryId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPackageItineraryVehicles.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    packageItinerayVehicles.Add(GetPackageItineraryVehicleValues(dr));
                }
            }

            return packageItinerayVehicles;
        }

        public List<PackageInfo> GetSearchPackageDetails(PackageInfo packageInfo)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            List<PackageInfo> PackageBasicDetails = new List<PackageInfo>();

            sqlParam.Add(new SqlParameter("@PackageName", packageInfo.PackageName));

            DataSet ds = _sqlHelper.ExecuteDataSet(sqlParam, Storeprocedures.spGetSearchPackageDetails.ToString(), CommandType.StoredProcedure);

            DataTable dt1 = ds.Tables[0];

            if (dt1 != null && dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    PackageBasicDetails.Add(GetPackageBasicDetailsValues(dr));
                }
            }
            return PackageBasicDetails;
        }

        public PackageInfo GetPackageBasicDetailsValues(DataRow dr)
        {
            AccessoriesRepo _aRepo = new AccessoriesRepo();
            PackageInfo pInfo = new PackageInfo();

          
            pInfo.PackageId = Convert.ToInt32(dr["PackageId"]);

            if (!dr.IsNull("PackageName"))
                pInfo.PackageName = Convert.ToString(dr["PackageName"]);

            if (!dr.IsNull("PackageCategoryId"))
                pInfo.PackageCategoryId = Convert.ToInt32(dr["PackageCategoryId"]);

            if (!dr.IsNull("PackageCategoryStr"))
                pInfo.PackageCategoryName = Convert.ToString(dr["PackageCategoryStr"]);

            if (!dr.IsNull("PackageDuration"))
                pInfo.PackageDuration = Convert.ToString(dr["PackageDuration"]);

            if (!dr.IsNull("PackageCost"))
                pInfo.PackageCost = Convert.ToInt32(dr["PackageCost"]);

            if (!dr.IsNull("PackageTypeName"))
                pInfo.PackageTypeName = Convert.ToString(dr["PackageTypeName"]);

            if (!dr.IsNull("cityname"))
                pInfo.CityName = Convert.ToString(dr["cityname"]);

            if (!dr.IsNull("StateName"))
                pInfo.Country = Convert.ToString(dr["StateName"]);

            if (!dr.IsNull("CountryName"))
                pInfo.State = Convert.ToString(dr["CountryName"]);

            if (!dr.IsNull("CountryId"))
                pInfo.CountryId = Convert.ToInt32(dr["CountryId"]);

            if (!dr.IsNull("StateId"))
                pInfo.StateId = Convert.ToInt32(dr["StateId"]);


            if (!dr.IsNull("DepartureCityId"))
                pInfo.CityId = Convert.ToInt32(dr["DepartureCityId"]);


            if (!dr.IsNull("packageTypeId"))
                pInfo.PackageTypeIds = Convert.ToString(dr["packageTypeId"]);



            pInfo.Images = _aRepo.GetImagesByRefType(pInfo.PackageId, (int)Attachment.Package);
            return pInfo;

        }
            

        public List<PackageInfo> GetSearchgitDetails(PackageInfo packageInfo)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            List<PackageInfo> PackageBasicDetails = new List<PackageInfo>();

           // sqlParam.Add(new SqlParameter("@PackageName", packageInfo.PackageName));

            sqlParam.Add(new SqlParameter("@PackageCost", packageInfo.PackageCost));

            sqlParam.Add(new SqlParameter("@CityId", packageInfo.CityId));

            sqlParam.Add(new SqlParameter("@StateId", packageInfo.StateId));

            sqlParam.Add(new SqlParameter("@CountryId", packageInfo.CountryId));

            sqlParam.Add(new SqlParameter("@FromDate", packageInfo.FromDate));

             //sqlParam.Add(new SqlParameter("@CountryId", packageInfo.CountryId));

             //sqlParam.Add(new SqlParameter("@StateId", packageInfo.StateId));
            DataSet ds = _sqlHelper.ExecuteDataSet(sqlParam, Storeprocedures.spGetSearchGitDetails.ToString(), CommandType.StoredProcedure);

            DataTable dt1 = ds.Tables[0];

            if (dt1 != null && dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    PackageBasicDetails.Add(GetPackageBasicDetailsValues(dr));
                }
            }
            return PackageBasicDetails;
        }


        public List<DateTime> GetFilteredDateForDuration(PackageDuration PackageDuration)
        {
            List<DateTime> dates = new List<DateTime>();

            foreach (DateTime day in EachDay(PackageDuration.FormDate, PackageDuration.EndDate))
            {
                if (PackageDuration.OperationalDays.Split(',').Contains(day.DayOfWeek.ToString()))
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

        public void SavePackageDurationWithCustomerCategories(List<DateTime> dates, PackageDuration PackageDurationNet, List<PackageCustomerCategoryInfo> PackageCustomer)
        {
            foreach (var item in dates)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@PackageDurationId", PackageDurationNet.PackageDurationId));
              

                sqlParams.Add(new SqlParameter("@TariffDate", item));
            

                sqlParams.Add(new SqlParameter("@NetRate", PackageDurationNet.price));
               

                sqlParams.Add(new SqlParameter("@PackageId", PackageDurationNet.PackageId));

                int PackageDuration = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spInsertPackageTariffDuration.ToString(), CommandType.StoredProcedure));

                foreach (var itm in PackageCustomer)
                {
                    List<SqlParameter> sqlParam = new List<SqlParameter>();

                 //   sqlParam.Add(new SqlParameter("@PackagePriceCategoryId", itm.PackagePriceCategoryId));

                    sqlParam.Add(new SqlParameter("@CustomerCategoryId", itm.CustomerCategoryId));

                    sqlParam.Add(new SqlParameter("@PackageId", itm.PackageId));

                    sqlParam.Add(new SqlParameter("@PackageDurationId", PackageDuration));

                    sqlParam.Add(new SqlParameter("@Margin", itm.Margin));

                    sqlParam.Add(new SqlParameter("@CreatedDate", itm.CreatedDate));

                    sqlParam.Add(new SqlParameter("@CreatedBy", itm.CreatedBy));

                    sqlParam.Add(new SqlParameter("@UpdatedDate", itm.UpdatedDate));

                    sqlParam.Add(new SqlParameter("@UpdatedBy", itm.UpdatedBy));

                    _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spInsertPackageTariffCustomerCategory.ToString(), CommandType.StoredProcedure);
                }

            }
        }




        public List<PackageDuration> GetpackagePrice(int PackageId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            List<PackageDuration> PackagePrices = new List<PackageDuration>();

            sqlParam.Add(new SqlParameter("@PackageId", PackageId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetpackagePrice.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PackagePrices.Add(GetPriceValues(dr));
                }
            }
            return PackagePrices;
        }

        private PackageDuration GetPriceValues(DataRow dr)
        {
            PackageDuration packageTariff = new PackageDuration();

             if (dr["TariffDate"] != DBNull.Value)
            {
                packageTariff.TariffDate = Convert.ToDateTime(dr["TariffDate"]);
            }

             if (dr["NetRate"] != DBNull.Value)
            {
                packageTariff.price = Convert.ToDecimal(dr["NetRate"]);
            }


            if (dr["PackageId"] != DBNull.Value)
            {
                packageTariff.PackageId = Convert.ToInt32(dr["PackageId"]);
            }

            return packageTariff;
        }
    }
}
