using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using LohanaBusinessEntities;
using LohanaRepo.Utilities;
using LohanaBusinessEntities.Hotel;
using LohanaBusinessEntities.HotelTypeInfo;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.City;
using LohanaBusinessEntities.RoomType;
using LohanaBusinessEntities.Facility;
using LohanaBusinessEntities.FacilityType;
using LohanaBusinessEntities.Designation;
using LohanaBusinessLogic.Utilities;
using LohanaHelper.Logging;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace LohanaRepo.Master
{
    public class HotelRepo
    {
        SQLHelperRepo _sqlHelper = null;

        public HotelRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        //Insert Procedures Call

        public int Insert(HotelInfo hotel)
        {

            if (hotel.HotelId == 0)
            {

                hotel.HotelId = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInHotel(hotel), Storeprocedures.SpInsertHotel.ToString(), CommandType.StoredProcedure));

            }

            return hotel.HotelId;
        
        }

        public List<SqlParameter> SetValuesInHotel(HotelInfo hotel)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (hotel.HotelId != 0)
            {
                sqlParam.Add(new SqlParameter("@HotelId", hotel.HotelId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedDate", hotel.CreatedDate));

                sqlParam.Add(new SqlParameter("@CreatedBy", hotel.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@HotelType", hotel.HotelType));

            Logger.Debug("Hotel Controller HotelType:" + hotel.HotelType);

            sqlParam.Add(new SqlParameter("@HotelName", hotel.HotelName));

            Logger.Debug("Hotel Controller HotelName:" + hotel.HotelName);

            sqlParam.Add(new SqlParameter("@HotelGroup", hotel.HotelGroup));

            Logger.Debug("Hotel Controller HotelGroup:" + hotel.HotelGroup);

            sqlParam.Add(new SqlParameter("@StarCategory", hotel.StarCategory));

            Logger.Debug("Hotel Controller StarCategory:" + hotel.StarCategory);

            sqlParam.Add(new SqlParameter("@HotelDescription", hotel.HotelDescription));

            Logger.Debug("Hotel Controller HotelDescription:" + hotel.HotelDescription);

            sqlParam.Add(new SqlParameter("@NearestAirport", hotel.NearestAirport));

            Logger.Debug("Hotel Controller NearestAirport:" + hotel.NearestAirport);

            sqlParam.Add(new SqlParameter("@NearestRailwayStation", hotel.NearestRailwayStation));

            Logger.Debug("Hotel Controller NearestRailwayStation:" + hotel.NearestRailwayStation);

            sqlParam.Add(new SqlParameter("@NearestLandMark", hotel.NearestLandMark));

            Logger.Debug("Hotel Controller NearestLandMark:" + hotel.NearestLandMark);

            sqlParam.Add(new SqlParameter("@PreferredHotel", 1));

            sqlParam.Add(new SqlParameter("@CityId", hotel.CityId));

            Logger.Debug("Hotel Controller CityId:" + hotel.CityId);

            sqlParam.Add(new SqlParameter("@Pincode", hotel.Pincode));

            Logger.Debug("Hotel Controller Pincode:" + hotel.Pincode);

            sqlParam.Add(new SqlParameter("@Address", hotel.Address));

            Logger.Debug("Hotel Controller Address:" + hotel.Address);

            sqlParam.Add(new SqlParameter("@MobileNo", hotel.MobileNo));

            Logger.Debug("Hotel Controller MobileNo:" + hotel.MobileNo);

            sqlParam.Add(new SqlParameter("@TelephoneCode", hotel.TelephoneCode));

            Logger.Debug("Hotel Controller TelephoneCode:" + hotel.TelephoneCode);

            sqlParam.Add(new SqlParameter("@TelephoneNo", hotel.TelephoneNo));

            Logger.Debug("Hotel Controller TelephoneNo:" + hotel.TelephoneNo);

            sqlParam.Add(new SqlParameter("@EmailId", hotel.EmailId));

            Logger.Debug("Hotel Controller EmailId:" + hotel.EmailId);

            sqlParam.Add(new SqlParameter("@FaxNo", hotel.FaxNo));

            Logger.Debug("Hotel Controller FaxNo:" + hotel.FaxNo);

            sqlParam.Add(new SqlParameter("@Website", hotel.Website));

            Logger.Debug("Hotel Controller Website:" + hotel.Website);

            sqlParam.Add(new SqlParameter("@LohanaRatings", hotel.LohanaRatings));

            Logger.Debug("Hotel Controller LohanaRatings:" + hotel.LohanaRatings);

            sqlParam.Add(new SqlParameter("@TopAttractionsNearBy", hotel.TopAttractionsNearBy));

            Logger.Debug("Hotel Controller TopAttractionsNearBy:" + hotel.TopAttractionsNearBy);

            sqlParam.Add(new SqlParameter("@UsefulHotelStats", hotel.UsefulHotelStats));

            Logger.Debug("Hotel Controller UsefulHotelStats:" + hotel.UsefulHotelStats);

            sqlParam.Add(new SqlParameter("@Notes", hotel.Notes));

            Logger.Debug("Hotel Controller Notes:" + hotel.Notes);

            //sqlParam.Add(new SqlParameter("HotelType", hotel.HotelType));

            sqlParam.Add(new SqlParameter("@Comments", hotel.Comments));

            Logger.Debug("Hotel Controller Comments:" + hotel.Comments);

            sqlParam.Add(new SqlParameter("@Status", hotel.Status));

            Logger.Debug("Hotel Controller Status" + hotel.Status);

            sqlParam.Add(new SqlParameter("@UpdatedBy", hotel.UpdatedBy));

            sqlParam.Add(new SqlParameter("@UpdatedDate", hotel.UpdatedDate));

            return sqlParam;
        }

        public void InsertHotelFacilityDetails(HotelFacilityDetailsInfo hotelFacilityDetail)
        {
            
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@HotelId", hotelFacilityDetail.HotelId));
                Logger.Debug("Hotel Controller HotelId:" +hotelFacilityDetail.HotelId);
                sqlParams.Add(new SqlParameter("@FacilityId", hotelFacilityDetail.FacilityId));
                Logger.Debug("Hotel Controller FacilityId:" + hotelFacilityDetail.FacilityId);
                sqlParams.Add(new SqlParameter("@FacilityStatus", hotelFacilityDetail.FacilityStatus));
                Logger.Debug("Hotel Controller FacilityStatus:" + hotelFacilityDetail.FacilityStatus);
             

                sqlParams.Add(new SqlParameter("@CreatedBy", hotelFacilityDetail.CreatedBy));
                sqlParams.Add(new SqlParameter("@CreatedDate", hotelFacilityDetail.CreatedDate));
                sqlParams.Add(new SqlParameter("@UpdatedBy", hotelFacilityDetail.UpdatedBy));
                sqlParams.Add(new SqlParameter("@UpdatedDate", hotelFacilityDetail.UpdatedDate));

                _sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.SpInsertHotelFacilityDetails.ToString(), CommandType.StoredProcedure);
            
        }

        public int InsertHotelRoomType(HotelRoomTypeDetailsInfo roomtype)
        {

            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInHotelRoomtype(roomtype), Storeprocedures.SpInsertHotelRoomTypeDetails.ToString(), CommandType.StoredProcedure));

        }

        public List<SqlParameter> SetValuesInHotelRoomtype(HotelRoomTypeDetailsInfo roomtype)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (roomtype.RoomTypeDetailsId != 0)
            {
                sqlParam.Add(new SqlParameter("RoomTypeDetailsId", roomtype.RoomTypeDetailsId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", roomtype.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", roomtype.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@RoomTypeId", roomtype.RoomTypeId));

            Logger.Debug("Hotel Controller RoomTypeId:" + roomtype.RoomTypeId);

            sqlParam.Add(new SqlParameter("@HotelId", roomtype.HotelId));

            Logger.Debug("Hotel Controller HotelId:" + roomtype.HotelId);

            sqlParam.Add(new SqlParameter("@NoOfRooms", roomtype.NoOfRooms));

            Logger.Debug("Hotel Controller NoOfRooms:" + roomtype.NoOfRooms);

            sqlParam.Add(new SqlParameter("@OccupancyCapacity", roomtype.OccupancyCapacity));

            Logger.Debug("Hotel Controller OccupancyCapacity:" + roomtype.OccupancyCapacity);

            sqlParam.Add(new SqlParameter("@UpdatedBy", roomtype.UpdatedBy));

            sqlParam.Add(new SqlParameter("@UpdatedDate", roomtype.UpdatedDate));

            return sqlParam;
        }

        public int InsertContactPerson(HotelContactPersonInfo contactperson)
        {

            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInContactPerson(contactperson), Storeprocedures.spInsertContactPerson.ToString(), CommandType.StoredProcedure));

        }

        public List<SqlParameter> SetValuesInContactPerson(HotelContactPersonInfo contactperson)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (contactperson.ContactPersonId != 0)
            {
                sqlParam.Add(new SqlParameter("ContactPersonId", contactperson.ContactPersonId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", contactperson.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", contactperson.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@ContactPersonName", contactperson.ContactPersonName));

            Logger.Debug("Hotel Controller ContactPersonName:" + contactperson.ContactPersonName);

            sqlParam.Add(new SqlParameter("@MobileNo", contactperson.MobileNo));

            Logger.Debug("Hotel Controller MobileNo:" + contactperson.MobileNo);

            sqlParam.Add(new SqlParameter("@PhoneNo", contactperson.PhoneNo));

            Logger.Debug("Hotel Controller PhoneNo:" + contactperson.PhoneNo);

            sqlParam.Add(new SqlParameter("@EmailId", contactperson.EmailId));

            Logger.Debug("Hotel Controller EmailId:" + contactperson.EmailId);

            sqlParam.Add(new SqlParameter("@FaxNo", contactperson.FaxNo));

            Logger.Debug("Hotel Controller FaxNo:" + contactperson.FaxNo);

            sqlParam.Add(new SqlParameter("@DesignationId", contactperson.DesignationId));

            Logger.Debug("Hotel Controller DesignationId:" + contactperson.DesignationId);

            sqlParam.Add(new SqlParameter("@UpdatedBy", contactperson.UpdatedBy));

            sqlParam.Add(new SqlParameter("@UpdatedDate", contactperson.UpdatedDate));

            sqlParam.Add(new SqlParameter("@RefType", ContactType.Hotel));

            Logger.Debug("Hotel Controller RefType:" + ContactType.Hotel);
            
            sqlParam.Add(new SqlParameter("@RefId", contactperson.RefId));

            Logger.Debug("Hotel Controller RefId:" + contactperson.RefId);

            return sqlParam;
        }

        public int InsertHotelBank(HotelBankDetailsInfo hotelbank)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInHotelBank(hotelbank), Storeprocedures.spInsertHotelBankDetails.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInHotelBank(HotelBankDetailsInfo hotelbank)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            HotelInfo hotel = new HotelInfo();

            if (hotelbank.BankId != 0)
            {
                sqlParam.Add(new SqlParameter("BankId", hotelbank.BankId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", hotelbank.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", hotelbank.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@BankName", hotelbank.BankName));

            Logger.Debug("Hotel Controller BankName:" + hotelbank.BankName);

            sqlParam.Add(new SqlParameter("@HotelId", hotelbank.HotelId));

            Logger.Debug("Hotel Controller HotelId:" + hotelbank.HotelId);

            sqlParam.Add(new SqlParameter("@BranchName", hotelbank.BranchName));

            Logger.Debug("Hotel Controller BranchName:" + hotelbank.BranchName);

            sqlParam.Add(new SqlParameter("@AccountNo", hotelbank.AccountNo));

            Logger.Debug("Hotel Controller AccountNo:" + hotelbank.AccountNo);

            sqlParam.Add(new SqlParameter("@AccountHolderName", hotelbank.AccountHolderName));

            Logger.Debug("Hotel Controller AccountHolderName:" + hotelbank.AccountHolderName);

            sqlParam.Add(new SqlParameter("@IFSCCode", hotelbank.IFSCCode));

            Logger.Debug("Hotel Controller IFSCCode:" + hotelbank.IFSCCode);

            sqlParam.Add(new SqlParameter("@MICRCode", hotelbank.MICRCode));

            Logger.Debug("Hotel Controller MICRCode:" + hotelbank.MICRCode);

            sqlParam.Add(new SqlParameter("@SWIFTCode", hotelbank.SWIFTCode));

            Logger.Debug("Hotel Controller SWIFTCode:" + hotelbank.SWIFTCode);

            sqlParam.Add(new SqlParameter("@UpdatedBy", hotelbank.UpdatedBy));

            sqlParam.Add(new SqlParameter("@UpdatedDate", hotelbank.UpdatedDate));

            return sqlParam;
        }


        //Dropdown Populated and Other Values on Page Load

        public List<CityInfo> drpGetCountryStateCity()
        {
            List<CityInfo> cities = new List<CityInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetCountryStateCity.ToString(), CommandType.StoredProcedure);

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

        public List<DesignationInfo> drpGetDesignations()
        {
            List<DesignationInfo> designations = new List<DesignationInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetDesignation.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    designations.Add(GetDesignationValues(dr));
                }
            }
            return designations;
        }

        public DesignationInfo GetDesignationValues(DataRow dr)
        {
            DesignationInfo retVal = new DesignationInfo();

            retVal.DesignationId = Convert.ToInt32(dr["DesignationId"]);

            retVal.DesignationName = Convert.ToString(dr["DesignationName"]);

            return retVal;
        }

        public List<HotelFacilityDetailsInfo> GetHotelFacilities(int hotelId)
        {
            List<HotelFacilityDetailsInfo> HotelFacilities = new List<HotelFacilityDetailsInfo>();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@HotelId", hotelId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spHotelFacilities.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                HotelFacilities.Add(GetHotelFacilitiesValues(dr));
            }

            return HotelFacilities;

        }

        public HotelFacilityDetailsInfo GetHotelFacilitiesValues(DataRow dr)
        {

            HotelFacilityDetailsInfo HotelFacility = new HotelFacilityDetailsInfo();

            HotelFacility.FacilityId = Convert.ToInt32(dr["FacilityId"]);

            if (!dr.IsNull("HotelId"))
                HotelFacility.HotelId = Convert.ToInt32(dr["HotelId"]);
            

            if (!dr.IsNull("FacilityTypeId"))
                HotelFacility.FacilityTypeId = Convert.ToInt32(dr["FacilityTypeId"]);

            if (!dr.IsNull("FacilityName"))
                HotelFacility.FacilityName = Convert.ToString(dr["FacilityName"]);

            if (!dr.IsNull("FacilityTypeName"))
                HotelFacility.FacilityTypeName = Convert.ToString(dr["FacilityTypeName"]);

            if (!dr.IsNull("FacilityStatus"))
                HotelFacility.FacilityStatus = Convert.ToBoolean(dr["FacilityStatus"]);
            

            return HotelFacility;

        }


        public List<HotelTypeInfo> drpGetHotelTypes()
        {
            List<HotelTypeInfo> hoteltypes = new List<HotelTypeInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetHotelType.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    hoteltypes.Add(GetHotelTypeValues(dr));
                }
            }
            return hoteltypes;
        }

        public HotelTypeInfo GetHotelTypeValues(DataRow dr)
        {
            HotelTypeInfo retVal = new HotelTypeInfo();

            retVal.HotelTypeId = Convert.ToInt32(dr["HotelTypeId"]);

            retVal.HotelType = Convert.ToString(dr["HotelType"]);

            return retVal;
        }


        //Update Storeprocedures Call

        public void UpdateHotel(HotelInfo hotel)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInHotel(hotel), Storeprocedures.SpUpdateHotel.ToString(), CommandType.StoredProcedure);
        }

        public void UpdateHotelRoomType(HotelRoomTypeDetailsInfo roomtype)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInHotelRoomtype(roomtype), Storeprocedures.SpUpdateHotelRoomTypeDetails.ToString(), CommandType.StoredProcedure);
        }

        public void UpdateContactPerson(HotelContactPersonInfo contactperson)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInContactPerson(contactperson), Storeprocedures.spUpdateContactPerson.ToString(), CommandType.StoredProcedure);
        }

        public void UpdateHotelBank(HotelBankDetailsInfo hotelbank)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInHotelBank(hotelbank), Storeprocedures.spUpdateHotelBankDetails.ToString(), CommandType.StoredProcedure);
        }  


        //Get
        
        public DataTable GetHotel(string hotelname, int starcategory, int cityid, ref PaginationInfo pager)
        {
            
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@HotelName", hotelname));

            sqlParam.Add(new SqlParameter("@StarCategory", starcategory));

            sqlParam.Add(new SqlParameter("@CityId", cityid));
            
            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.SpGetHotel.ToString(), CommandType.StoredProcedure);
           
            return CommonMethods.GetPaginatedTable(dt,ref pager);

        }

        private HotelInfo   GetHotelValues(DataRow dr)
        {
        
            HotelInfo Hotel = new HotelInfo();

            Hotel.HotelId = Convert.ToInt32(dr["HotelId"]);

            if (!dr.IsNull("HotelName"))
                Hotel.HotelName = Convert.ToString(dr["HotelName"]);

            if (!dr.IsNull("HotelGroup"))
                Hotel.HotelGroup = Convert.ToString(dr["HotelGroup"]);

            if (!dr.IsNull("HotelType"))
                Hotel.HotelTypeId = Convert.ToInt32(dr["HotelType"]);

            if (!dr.IsNull("StarCategory"))
                Hotel.StarCategory = Convert.ToInt32(dr["StarCategory"]);

            if (!dr.IsNull("PreferredHotel"))
                Hotel.PreferredHotel = Convert.ToBoolean(dr["PreferredHotel"]);

            if (!dr.IsNull("HotelDescription"))
                Hotel.HotelDescription = Convert.ToString(dr["HotelDescription"]);

            if (!dr.IsNull("NearestAirport"))
                Hotel.NearestAirport = Convert.ToString(dr["NearestAirport"]);

            if (!dr.IsNull("NearestRailwayStation"))
                Hotel.NearestRailwayStation = Convert.ToString(dr["NearestRailwayStation"]);

            if (!dr.IsNull("NearestLandMark"))
                Hotel.NearestLandMark = Convert.ToString(dr["NearestLandMark"]); 

            if (!dr.IsNull("CityId"))
                Hotel.CityId = Convert.ToInt32(dr["CityId"]);

            if (!dr.IsNull("Pincode"))
                Hotel.Pincode = Convert.ToString(dr["Pincode"]);

            if (!dr.IsNull("Address"))
                Hotel.Address = Convert.ToString(dr["Address"]);

            if (!dr.IsNull("MobileNo"))
                Hotel.MobileNo = Convert.ToString(dr["MobileNo"]);
            

            if (!dr.IsNull("TelephoneCode"))
                Hotel.TelephoneCode = Convert.ToString(dr["TelephoneCode"]);

            if (!dr.IsNull("TelephoneNo"))
                Hotel.TelephoneNo = Convert.ToString(dr["TelephoneNo"]);

            if (!dr.IsNull("EmailId"))
                Hotel.EmailId = Convert.ToString(dr["EmailId"]);

            if (!dr.IsNull("FaxNo"))
                Hotel.FaxNo = Convert.ToString(dr["FaxNo"]);

            if (!dr.IsNull("Website"))
                Hotel.Website = Convert.ToString(dr["Website"]);

            if (!dr.IsNull("LohanaRatings"))
                Hotel.LohanaRatings = Convert.ToInt32(dr["LohanaRatings"]);

            if (!dr.IsNull("TopAttractionsNearBy"))
                Hotel.TopAttractionsNearBy = Convert.ToString(dr["TopAttractionsNearBy"]);

            if (!dr.IsNull("UsefulHotelStats"))
                Hotel.UsefulHotelStats = Convert.ToString(dr["UsefulHotelStats"]);

            if (!dr.IsNull("Notes"))
                Hotel.Notes = Convert.ToString(dr["Notes"]);

            if (!dr.IsNull("Comments"))
                Hotel.Comments = Convert.ToString(dr["Comments"]);

            if (!dr.IsNull("Status"))
                Hotel.Status = Convert.ToBoolean(dr["Status"]);

            return Hotel;

        }

        public DataTable GetHotelRoomType(int hotelId,ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@HotelId", hotelId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.SpGetHotelRoomTypeDetails.ToString(), CommandType.StoredProcedure);
          
            return CommonMethods.GetPaginatedTable(dt,ref pager);

        }

        private HotelRoomTypeDetailsInfo GetHotelRoomTypeDetailsValues(DataRow dr)
        {

            HotelRoomTypeDetailsInfo RoomType = new HotelRoomTypeDetailsInfo();

            RoomType.RoomTypeDetailsId = Convert.ToInt32(dr["RoomTypeDetailsId"]);

            if (!dr.IsNull("RoomTypeName"))
                RoomType.RoomTypeName = Convert.ToString(dr["RoomTypeName"]);

            if (!dr.IsNull("RoomTypeId"))
                RoomType.RoomTypeId = Convert.ToInt32(dr["RoomTypeId"]);

            if (!dr.IsNull("HotelId"))
                RoomType.HotelId = Convert.ToInt32(dr["HotelId"]);

            if (!dr.IsNull("NoOfRooms"))
                RoomType.NoOfRooms = Convert.ToInt32(dr["NoOfRooms"]);

            if (!dr.IsNull("OccupancyCapacity"))
                RoomType.OccupancyCapacity = Convert.ToInt32(dr["OccupancyCapacity"]);

            return RoomType;

        }

        public DataTable GetContactPerson(int refId, int refType,ref PaginationInfo pager)
        {
         
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@RefId", refId));

            sqlParam.Add(new SqlParameter("@RefType", refType));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetContactPerson.ToString(), CommandType.StoredProcedure);           

            return CommonMethods.GetPaginatedTable(dt,ref pager);

        }

        private HotelContactPersonInfo GetContactPersonValues(DataRow dr)
        {

            HotelContactPersonInfo ContactPerson = new HotelContactPersonInfo();

            ContactPerson.ContactPersonId = Convert.ToInt32(dr["ContactPersonId"]);

            if (!dr.IsNull("ContactPersonName"))
                ContactPerson.ContactPersonName = Convert.ToString(dr["ContactPersonName"]);

            if (!dr.IsNull("MobileNo"))
                ContactPerson.MobileNo = Convert.ToString(dr["MobileNo"]);

            if (!dr.IsNull("PhoneNo"))
                ContactPerson.PhoneNo = Convert.ToString(dr["PhoneNo"]);

            if (!dr.IsNull("EmailId"))
                ContactPerson.EmailId = Convert.ToString(dr["EmailId"]);

            if (!dr.IsNull("FaxNo"))
                ContactPerson.FaxNo = Convert.ToString(dr["FaxNo"]);

            if (!dr.IsNull("DesignationId"))
                ContactPerson.DesignationId = Convert.ToInt32(dr["DesignationId"]);


            if (!dr.IsNull("DesignationName"))
                ContactPerson.Designation = Convert.ToString(dr["DesignationName"]);

            if (!dr.IsNull("RefId"))
                ContactPerson.RefId = Convert.ToInt32(dr["RefId"]);

            if (!dr.IsNull("RefType"))
                ContactPerson.RefType = Convert.ToInt32(dr["RefType"]);

            return ContactPerson;

        }

        public DataTable GetHotelBank(int hotelId,ref PaginationInfo pager)
        {
            
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@HotelId", hotelId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetHotelBankDetails.ToString(), CommandType.StoredProcedure);          

            return CommonMethods.GetPaginatedTable(dt,ref pager);

        }

        private HotelBankDetailsInfo GetHotelBankValues(DataRow dr)
        {

            HotelBankDetailsInfo HotelBank = new HotelBankDetailsInfo();

            HotelBank.BankId = Convert.ToInt32(dr["BankId"]);

            HotelBank.HotelId = Convert.ToInt32(dr["HotelId"]);

            if (!dr.IsNull("BankName"))
                HotelBank.BankName = Convert.ToString(dr["BankName"]);

            if (!dr.IsNull("BranchName"))
                HotelBank.BranchName = Convert.ToString(dr["BranchName"]);

            if (!dr.IsNull("AccountNo"))
                HotelBank.AccountNo = Convert.ToString(dr["AccountNo"]);

            if (!dr.IsNull("AccountHolderName"))
                HotelBank.AccountHolderName = Convert.ToString(dr["AccountHolderName"]);

            if (!dr.IsNull("IFSCCode"))
                HotelBank.IFSCCode = Convert.ToString(dr["IFSCCode"]);

            if (!dr.IsNull("MICRCode"))
                HotelBank.MICRCode = Convert.ToString(dr["MICRCode"]);

            if (!dr.IsNull("SWIFTCode"))
                HotelBank.SWIFTCode = Convert.ToString(dr["SWIFTCode"]);

            return HotelBank;

        }


        //Get By Id

        public HotelInfo GetHotelById(int hotelId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            HotelInfo Hotel = new HotelInfo();

            sqlParam.Add(new SqlParameter("@HotelId", hotelId));

            Logger.Debug("Hotel Controller HotelId:" + hotelId);

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetHotelById.ToString(), CommandType.StoredProcedure);


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Hotel = GetHotelValues(dr);
                }
            }
            return Hotel;
        }

        public HotelRoomTypeDetailsInfo GetHotelRoomTypeById(int roomtypedetailsid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            HotelRoomTypeDetailsInfo RoomType = new HotelRoomTypeDetailsInfo();

            sqlParam.Add(new SqlParameter("@RoomTypeDetailsId", roomtypedetailsid));

            Logger.Debug("Hotel Controller RoomTypeDetailsId:" + roomtypedetailsid);

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetHotelRoomTypeById.ToString(), CommandType.StoredProcedure);


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    RoomType = GetHotelRoomTypeDetailsValues(dr);
                }
            }
            return RoomType;
        }

        public List<HotelRoomTypeDetailsInfo> GetHotelRoomTypeByHotelId(int hotelId)
        {
            List<HotelRoomTypeDetailsInfo> RoomTypes = new List<HotelRoomTypeDetailsInfo>();

            List<SqlParameter> sqlParam = new List<SqlParameter>();          

            sqlParam.Add(new SqlParameter("@HotelId", hotelId));

            //Logger.Debug("Hotel Controller HotelId:" + hotelId);

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetHotelRoomByHotelId.ToString(), CommandType.StoredProcedure);


            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                RoomTypes.Add(GetHotelRoomTypeDetailsValues(dr));
            }

            return RoomTypes;
        }

        private HotelFacilityDetailsInfo GetHotelFacilityDetailsValues(DataRow dr)
        {

            HotelFacilityDetailsInfo HotelFacility = new HotelFacilityDetailsInfo();

            HotelFacility.HotelId = Convert.ToInt32(dr["HotelId"]);

            if (!dr.IsNull("FacilityId"))
                HotelFacility.FacilityId = Convert.ToInt32(dr["FacilityId"]);

            if (!dr.IsNull("FacilityStatus"))
                HotelFacility.FacilityStatus = Convert.ToBoolean(dr["FacilityStatus"]);

            return HotelFacility;

        }

        public HotelContactPersonInfo GetContactPersonById(int contactpersonid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            HotelContactPersonInfo ContactPerson = new HotelContactPersonInfo();

            sqlParam.Add(new SqlParameter("@ContactPersonId", contactpersonid));

            Logger.Debug("Hotel Controller ContactPersonId:" + contactpersonid);

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetContactPersonById.ToString(), CommandType.StoredProcedure);


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ContactPerson = GetContactPersonValues(dr);
                }
            }
            return ContactPerson;
        }

        public HotelBankDetailsInfo GetHotelBankById(int bankid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            HotelBankDetailsInfo HotelBank = new HotelBankDetailsInfo();

            sqlParam.Add(new SqlParameter("@BankId", bankid));

            Logger.Debug("Hotel Controller BankId:" + bankid);

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetHotelBankDetailsById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    HotelBank = GetHotelBankValues(dr);
                }
            }
            return HotelBank;
        }


        //Delete 

        public void DeleteContactPerson(int contactpersonid, int refid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            HotelContactPersonInfo ContactPerson = new HotelContactPersonInfo();

            sqlParam.Add(new SqlParameter("ContactPersonId", contactpersonid));

            Logger.Debug("Hotel Controller ContactPersonId:" + contactpersonid);

            sqlParam.Add(new SqlParameter("RefId", refid));

            Logger.Debug("Hotel Controller RefId:" +refid);

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteContactPerson.ToString(), CommandType.StoredProcedure);


        }

        public void DeleteHotelRoomType(int roomtypeId , int hotelId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@RoomTypeDetailsId", roomtypeId));

            Logger.Debug("Hotel Controller RoomTypeDetailsId:" + roomtypeId);

            sqlParam.Add(new SqlParameter("@HotelId", hotelId));

            Logger.Debug("Hotel Controller HotelId:" + hotelId);

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteHotelRoomType.ToString(), CommandType.StoredProcedure);

        }

        public void DeleteHotelFacilities(int hotelId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            HotelFacilityDetailsInfo HotelFacility = new HotelFacilityDetailsInfo();

            sqlParam.Add(new SqlParameter("HotelId", hotelId));

            Logger.Debug("Hotel Controller HotelId:" + hotelId);

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteHotelFacilities.ToString(), CommandType.StoredProcedure);


        }

        public void DeleteHotelBank(int bankid, int hotelId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("BankId", bankid));

            Logger.Debug("Hotel Controller BankId:" + bankid);

            sqlParam.Add(new SqlParameter("HotelId", hotelId));

            Logger.Debug("Hotel Controller HotelId:" + hotelId);

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteHotelBankDetails.ToString(), CommandType.StoredProcedure);

        }

        //Check

        public bool CheckHotelNameExist(int cityId, string hotelName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@HotelName", hotelName));

            sqlParams.Add(new SqlParameter("@CityId", cityId));

            Logger.Debug("Hotel Controller HotelName:" + hotelName);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckHotelNameExist.ToString(), CommandType.StoredProcedure));

        }

        public bool CheckWebsiteExist(string website)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("Website", website));

            Logger.Debug("Hotel Controller Website:" + website);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckHotelWebsiteExist.ToString(), CommandType.StoredProcedure));


        }

        //public MemoryStream CreateHotel_Pdf(HotelInfo hotelInfo, string img)
        //{
        //    MemoryStream mm = new MemoryStream();

        //    StringBuilder body = new StringBuilder();

        //    body.Append("<table>");
        //    body.Append("<tbody>");

        //    body.Append("<tr>");
        //    body.Append("<td>");

        //    body.Append("<div>");
        //    body.Append("<ul>");
        //    body.Append("<li>");
        //    body.Append("<a><h3><span></span>&nbsp; Basic Details</h3></a>");
        //    body.Append("</li>");
        //    body.Append("</ul>");
        //    body.Append("</div>");

        //    body.Append("<table style='width:100%'>");
        //    body.Append("<tbody>");
        //    body.Append("<tr style='letter-spacing:2px'>");
        //    body.Append("<td>");
        //    body.Append("<table style='width:100%'>");
        //    body.Append("<tbody>");
        //    body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
        //    body.Append("<td colspan='3' width='45%;' style='background-color:dimgray;padding:4px;font-size:15px;text-align:left;text-transform:uppercase;color:white'>Primary Details:</td>");
        //    body.Append("<td>");
        //    body.Append("<div style='border-top:1px solid #ccc;margin:7px'>");
        //    body.Append("</div>");
        //    body.Append("</td>");
        //    body.Append("</tr>");
        //    body.Append("</tbody>");
        //    body.Append("</table>");
        //    body.Append("</td>");
        //    body.Append("</tr>");
        //    body.Append("<tr style='letter-spacing:2px'>");
        //    body.Append("<td>");
        //    body.Append("<table style='width:100%'>");
        //    body.Append("<tbody>");
        //    body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
        //    body.Append("<td style='text-align:left;width:25%'>Hotel Type</td>");
        //    body.Append("<td style='text-align:left;width:1%'>:</td>");
        //    body.Append("<td>" + hotelInfo.HotelType + "</td>");
        //    body.Append("</tr>");
        //    body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
        //    body.Append("<td>Hotel Name</td>");
        //    body.Append("<td>:</td>");
        //    body.Append("<td>" + hotelInfo.HotelName + "</td>");
        //    body.Append("</tr>");
        //    body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
        //    body.Append("<td>Hotel Group</td>");
        //    body.Append("<td>:</td>");
        //    body.Append("<td style='font-size:12px;letter-spacing:1px;line-height:25px'>" + hotelInfo.HotelGroup + "</td>");
        //    body.Append("</tr>");
        //    body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
        //    body.Append("<td>Star Category</td>");
        //    body.Append("<td>:</td>");
        //    body.Append("<td style='text-decoration-line:underline'><b>" + hotelInfo.StarCategory + "</b></td>");
        //    body.Append("</tr>");
        //    body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
        //    body.Append("<td>Nearest Airport (Km)</td>");
        //    body.Append("<td>:</td>");
        //    body.Append("<td style='font-size:12px;letter-spacing:1px;line-height:25px'>" + hotelInfo.NearestAirport + "</td>");
        //    body.Append("</tr>");
        //    body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
        //    body.Append("<td>Nearest Railway Station (Km)</td>");
        //    body.Append("<td>:</td>");
        //    body.Append("<td style='font-size:12px;letter-spacing:1px;line-height:25px'>" + hotelInfo.NearestRailwayStation + "</td>");
        //    body.Append("</tr>");
        //    body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
        //    body.Append("<td>Nearest LandMark</td>");
        //    body.Append("<td>:</td>");
        //    body.Append("<td style='font-size:12px;letter-spacing:1px;line-height:25px'>" + hotelInfo.NearestLandMark + "</td>");
        //    body.Append("</tr>");
        //    body.Append("</tbody>");
        //    body.Append("</table>");
        //    body.Append("</td>");
        //    body.Append("</tr>");
        //    body.Append("</tbody>");
        //    body.Append("</table>");

        //    //////////////body.Append("</td>");
        //    //////////////body.Append("</tr>");
                        
        //    //////////////body.Append("<tr>");
        //    //////////////body.Append("<td>");

        //    body.Append("<table style='width:100%'>");
        //    body.Append("<tbody>");
        //    body.Append("<tr style='letter-spacing:2px'>");
        //    body.Append("<td>");
        //    body.Append("<table style='width:100%'>");
        //    body.Append("<tbody>");
        //    body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
        //    body.Append("<td colspan='3' width='45%;' style='background-color:dimgray;padding:4px;font-size:15px;text-align:left;text-transform:uppercase;color:white'>Additional Details:</td>");
        //    body.Append("<td>");
        //    body.Append("<div style='border-top:1px solid #ccc;margin:7px'>");
        //    body.Append("</div>");
        //    body.Append("</td>");
        //    body.Append("</tr>");
        //    body.Append("</tbody>");
        //    body.Append("</table>");
        //    body.Append("</td>");
        //    body.Append("</tr>");
        //    body.Append("<tr style='letter-spacing:2px'>");
        //    body.Append("<td>");
        //    body.Append("<table style='width:100%'>");
        //    body.Append("<tbody>");
        //    body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
        //    body.Append("<td style='text-align:left;width:25%'>Lohana Ratings</td>");
        //    body.Append("<td style='text-align:left;width:1%'>:</td>");
        //    body.Append("<td>" + hotelInfo.LohanaRatings + "</td>");
        //    body.Append("</tr>");
        //    body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
        //    body.Append("<td>Hotel Description</td>");
        //    body.Append("<td>:</td>");
        //    body.Append("<td>" + hotelInfo.HotelDescription + "</td>");
        //    body.Append("</tr>");
        //    body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
        //    body.Append("<td>Top Attractions Near By</td>");
        //    body.Append("<td>:</td>");
        //    body.Append("<td style='font-size:12px;letter-spacing:1px;line-height:25px'>" + hotelInfo.TopAttractionsNearBy + "</td>");
        //    body.Append("</tr>");
        //    body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
        //    body.Append("<td>Useful Hotel Stats</td>");
        //    body.Append("<td>:</td>");
        //    body.Append("<td style='text-decoration-line:underline'><b>" + hotelInfo.UsefulHotelStats + "</b></td>");
        //    body.Append("</tr>");
        //    body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
        //    body.Append("<td>Notes</td>");
        //    body.Append("<td>:</td>");
        //    body.Append("<td style='font-size:12px;letter-spacing:1px;line-height:25px'>" + hotelInfo.Notes + "</td>");
        //    body.Append("</tr>");
        //    body.Append("</tbody>");
        //    body.Append("</table>");
        //    body.Append("</td>");
        //    body.Append("</tr>");
        //    body.Append("</tbody>");
        //    body.Append("</table>");

        //    body.Append("</td>");
        //    body.Append("</tr>");
           
        //    body.Append("<tr>");
        //    body.Append("<td>");
        //    body.Append("<table style='width:100%'>");
        //    body.Append("<tbody>");

        //    body.Append("<tr>");
        //    body.Append("<td>");
        //    body.Append("<div>");
        //    body.Append("<ul>");
        //    body.Append("<li>");
        //    body.Append("<a><h3><span></span>&nbsp; Room Types</h3></a>");
        //    body.Append("</li>");
        //    body.Append("</ul>");
        //    body.Append("</div>");
        //    body.Append("</td>");
        //    body.Append("</tr>");

        //    body.Append("<tr>");
        //    body.Append("<td>");
        //    body.Append("<table border='1' cellpadding='10' cellspacing='10' style='border-color:black' width='100%' height='70%'>");
        //    body.Append("<tr>");
        //    body.Append("<th style='background-color:darkcyan'>RoomType Name</th>");
        //    body.Append("<th style='background-color:darkcyan'>No Of Rooms</th>");
        //    body.Append("<th style='background-color:darkcyan'>Occupancy Capacity</th>");
        //    body.Append("</tr>");
        //    foreach (var item in hotelInfo.RoomTypeDetails)
        //    {
        //        body.Append("<tr>");
        //        body.Append("<td style='color:black'><a class='text-black'>" + item.RoomTypeName + "</a></td>");
        //        body.Append("<td style='color:black'><a class='text-black'>" + item.NoOfRooms + "</a></td>");
        //        body.Append("<td style='color:black'><a class='text-black'>" + item.OccupancyCapacity + "</a></td>");
        //        body.Append("</tr>");
        //    }
        //    body.Append("</table>");
        //    body.Append("</td>");
        //    body.Append("</tr>");

        //    body.Append("</tbody>");
        //    body.Append("</table>");
        //    body.Append("</td>");
        //    body.Append("</tr>");

        //    body.Append("<tr>");
        //    body.Append("<td>");
        //    body.Append("<table style='width:100%'>");
        //    body.Append("<tbody>");

        //    body.Append("<tr>");
        //    body.Append("<td>");
        //    body.Append("<div>");
        //    body.Append("<ul>");
        //    body.Append("<li>");
        //    body.Append("<a><h3><span></span>&nbsp; Images</h3></a>");
        //    body.Append("</li>");
        //    body.Append("</ul>");
        //    body.Append("</div>");
        //    body.Append("</td>");
        //    body.Append("</tr>");

        //    body.Append("<table style='width:100%'>");
        //    body.Append("<tbody>");
        //    //for (int i = 0; i < hotelInfo.Images.Count; i++)
        //    if (hotelInfo.Images.Count > 0)
        //    {
        //        int i = 0;
        //        for (int j = i; j < hotelInfo.Images.Count; j++)
        //        {
        //            if ((j + 3) % 3 == 0)
        //            {
        //                body.Append("<tr>");
        //            }
        //            body.Append("<td>");
        //           // byte[] b = File.ReadAllBytes(hotelInfo.Images[i].UniqueAttachmentId);
        //           // string Src1 = @"data:image/jpg;base64," + Convert.ToBase64String(File.ReadAllBytes(img + @"" + hotelInfo.Images[i].UniqueAttachmentId));
        //           // body.Append("<img src='~/Upload/" + Src1 + "' style='width:550px;height:200px' alt='" + hotelInfo.Images[i].AttachmentName + "' />");
        //            body.Append("<img src='~/Upload/" + hotelInfo.Images[i].UniqueAttachmentId + "' style='width:300px;height:200px' alt='" + hotelInfo.Images[i].AttachmentName + "' />");
        //            body.Append("</td>");
        //            if(j!=0)
        //            {
        //                if ((j+1) % 3 == 0)
        //                {
        //                    body.Append("</tr>");
        //                }
        //            }
        //            i = j;
        //        }                   
        //        if((i-1) % 3 != 0 )
        //        {
        //            body.Append("</tr>");
        //        }
        //    }
          
        //    body.Append("</tbody>");
        //    body.Append("</table>");

        //    body.Append("</tbody>");
        //    body.Append("</table>");
        //    body.Append("</td>");
        //    body.Append("</tr>");

        //    body.Append("</tbody>");
        //    body.Append("</table>");


        //    #region PDFData1

        //    StringReader sr = new StringReader(body.ToString());
        //    using (mm = new MemoryStream())
        //    {
        //        Document document = new Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 10f);
        //        //iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 10f);
        //        PdfWriter writer = PdfWriter.GetInstance(document, mm);              

        //        document.Open();
              
        //       // writer.CloseStream = false;

        //        XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr);

        //        //for (int i = 0; i < hotelInfo.Images.Count; i++)
        //        //{ 
        //        //    byte[] file;

        //        //    file = System.IO.File.ReadAllBytes(img + hotelInfo.Images[i].UniqueAttachmentId);//ImagePath  

        //        //    iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(file);

        //        //    jpg.ScaleToFit(550F, 200F);//Set width and height in float  

        //        //    document.Add(jpg);
        //        //    //document.NewPage();                   
        //        //}              

        //        document.Close();
        //        writer.Close();
        //    }
        //    #endregion

        //    return mm;
        //}

        

    }
}


















































//public List<FacilityInfo> GetHotelFacilities(int hotelId)
//{
//    List<FacilityInfo> Facilities = new List<FacilityInfo>();

//    List<SqlParameter> sqlParam = new List<SqlParameter>();

//    sqlParam.Add(new SqlParameter("@HotelId", hotelId));

//    DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spHotelFacilities.ToString(), CommandType.StoredProcedure);

//    List<DataRow> drList = new List<DataRow>();

//    drList = dt.AsEnumerable().ToList();

//    foreach (DataRow dr in drList)
//    {
//        Facilities.Add(GetHotelFacilitiesValues(dr));
//    }

//    return Facilities;

//}

//public FacilityInfo GetHotelFacilitiesValues(DataRow dr)
//{

//    FacilityInfo Facility = new FacilityInfo();

//    Facility.FacilityId = Convert.ToInt32(dr["FacilityId"]);

//    if (!dr.IsNull("FacilityTypeId"))
//        Facility.FacilityTypeId = Convert.ToInt32(dr["FacilityTypeId"]);

//    if (!dr.IsNull("FacilityName"))
//        Facility.FacilityName = Convert.ToString(dr["FacilityName"]);

//    if (!dr.IsNull("FacilityTypeName"))
//        Facility.FacilityTypeName = Convert.ToString(dr["FacilityTypeName"]);

//    //if (!dr.IsNull("FacilityStatus"))
//    //    Facility.FacilityStatus = Convert.ToBoolean(dr["FacilityStatus"]);

//    return Facility;

//}
