using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using LohanaBusinessLogic.Utilities;
using LohanaHelper.Logging;
using LohanaRepo.Utilities;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Enquiry;
using LohanaBusinessEntities;
using LohanaBusinessEntities.City;


namespace LohanaRepo.Enquiry
{
    public class EnquiryRepo
    {
        SQLHelperRepo _sqlHelper = null;

        public EnquiryRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        #region Dropdowns

        public List<UserInfo> drpGetUsers()
        {
            List<UserInfo> users = new List<UserInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetUsers.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    users.Add(GetUserValues(dr));
                }
            }
            return users;
        }

        public UserInfo GetUserValues(DataRow dr)
        {
            UserInfo retVal = new UserInfo();

            retVal.UserId = Convert.ToInt32(dr["UserId"]);

            retVal.FirstName = Convert.ToString(dr["FirstName"]);

            return retVal;
        }


        public List<SpecializationInfo> GetSpecialization()
        {
            List<SpecializationInfo> SpecializationList = new List<SpecializationInfo>();

            DataTable dt = _sqlHelper.ExecuteDataTable(null, Storeprocedures.spdrpSpecialization.ToString(), CommandType.StoredProcedure);


            foreach (DataRow dr in dt.Rows)
            {
                SpecializationInfo specialization = new SpecializationInfo();

                if (!dr.IsNull("SpecializationId"))
                    specialization.SpecializationId = Convert.ToInt32(dr["SpecializationId"]);

                if (!dr.IsNull("Specializationname"))
                    specialization.Specializationname = Convert.ToString(dr["Specializationname"]);

                SpecializationList.Add(specialization);
            }


            return SpecializationList;
        }

        #endregion

        #region EnquiryBasic

        public int InsertEnquiryBasic(EnquiryInfo enquiry)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInEnquiry(enquiry), Storeprocedures.spInsertEnquiry.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInEnquiry(EnquiryInfo enquiry)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (enquiry.EnquiryId != 0)
            {
                sqlParam.Add(new SqlParameter("EnquiryId", enquiry.EnquiryId));

                sqlParam.Add(new SqlParameter("@EnquiryPriority", enquiry.EnquiryPriority));

                Logger.Debug("Enquiry Controller EnquiryPriority:" + enquiry.EnquiryPriority);

                sqlParam.Add(new SqlParameter("@EnquiryStatus", enquiry.EnquiryStatus));

                Logger.Debug("Enquiry Controller EnquiryStatus:" + enquiry.EnquiryStatus);

                sqlParam.Add(new SqlParameter("@EnquiryTicketDeliveryType", enquiry.EnquiryTicketDeliveryType));

                Logger.Debug("Enquiry Controller EnquiryTicketDeliveryType:" + enquiry.EnquiryTicketDeliveryType);

                sqlParam.Add(new SqlParameter("@BestTimeToReachYou", enquiry.BestTimeToReachYou));

                Logger.Debug("Enquiry Controller BestTimeToReachYou:" + enquiry.BestTimeToReachYou);

                sqlParam.Add(new SqlParameter("@AdditionalInformation", enquiry.AdditionalInformation));

                Logger.Debug("Enquiry Controller AdditionalInformation:" + enquiry.AdditionalInformation);

                if (enquiry.FollowupDate == DateTime.MinValue)
                {
                    DateTime? someDate = null;

                    sqlParam.Add(new SqlParameter("@FollowupDate", someDate));
                }
                else
                {
                    sqlParam.Add(new SqlParameter("@FollowupDate", enquiry.FollowupDate));

                    Logger.Debug("Enquiry Controller FollowupDate:" + enquiry.FollowupDate);
                }


            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", enquiry.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", enquiry.CreatedBy));
            }

            //sqlParam.Add(new SqlParameter("@EnquiryType", enquiry.EnquiryType));

            //Logger.Debug("Enquiry Controller EnquiryType:" + enquiry.EnquiryType);

            sqlParam.Add(new SqlParameter("@CustomerType", enquiry.CustomerType));

            Logger.Debug("Enquiry Controller CustomerType:" + enquiry.CustomerType);

            sqlParam.Add(new SqlParameter("@CustomerId", enquiry.CustomerId));

            Logger.Debug("Enquiry Controller CustomerId:" + enquiry.CustomerId);

            sqlParam.Add(new SqlParameter("@VendorId", enquiry.VendorId));

            Logger.Debug("Enquiry Controller VendorId:" + enquiry.VendorId);

            sqlParam.Add(new SqlParameter("@GuestName", enquiry.GuestName));

            Logger.Debug("Enquiry Controller GuestName:" + enquiry.GuestName);

            sqlParam.Add(new SqlParameter("@GuestEmail", enquiry.GuestEmail));

            Logger.Debug("Enquiry Controller GuestEmail:" + enquiry.GuestEmail);

            sqlParam.Add(new SqlParameter("@GuestMobileNo", enquiry.GuestMobileNo));

            Logger.Debug("Enquiry Controller GuestMobileNo:" + enquiry.GuestMobileNo);

            sqlParam.Add(new SqlParameter("@EnquirySource", enquiry.EnquirySource));

            Logger.Debug("Enquiry Controller EnquirySource:" + enquiry.EnquirySource);

            sqlParam.Add(new SqlParameter("@EnquiryAssignedType", enquiry.EnquiryAssignedType));

            Logger.Debug("Enquiry Controller EnquiryAssignedType:" + enquiry.EnquiryAssignedType);

            sqlParam.Add(new SqlParameter("@Specialization", enquiry.SpecializationId));

            Logger.Debug("Enquiry Controller Specialization:" + enquiry.SpecializationId);


            if (enquiry.EnquiryAssignedType == 1)
            {

                enquiry.SpecializationId = EnquiryAssignedName(enquiry);

                sqlParam.Add(new SqlParameter("@EnquiryAssigneeName", enquiry.EnquiryAssigneeName));

            }
            else
            {
                sqlParam.Add(new SqlParameter("@EnquiryAssigneeName", enquiry.EnquiryAssigneeName));

                Logger.Debug("Enquiry Controller EnquiryAssigneeName:" + enquiry.EnquiryAssigneeName);
            }



            sqlParam.Add(new SqlParameter("@EnquiryType", enquiry.EnquiryTypeID));

            Logger.Debug("Enquiry Controller EnquiryType:" + enquiry.EnquiryTypeID);



            sqlParam.Add(new SqlParameter("@UpdatedDate", enquiry.UpdatedDate));

            sqlParam.Add(new SqlParameter("@UpdatedBy", enquiry.UpdatedBy));

            return sqlParam;

        }

        public void UpdateEnquiryBasic(EnquiryInfo enquiry)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInEnquiry(enquiry), Storeprocedures.spUpdateEnquiry.ToString(), CommandType.StoredProcedure);
        }


        public DataTable GetEnquiry(int customerType, int enquiryStatus, int enquirySource, int UserID, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@UserId", UserID));

            sqlParam.Add(new SqlParameter("@CustomerType", customerType));

            sqlParam.Add(new SqlParameter("@EnquiryStatus", enquiryStatus));

            sqlParam.Add(new SqlParameter("@EnquirySource", enquirySource));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetEnquiry.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }

        public EnquiryInfo GetEnquiryById(int enquiryId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            EnquiryInfo Enquiry = new EnquiryInfo();

            sqlParam.Add(new SqlParameter("@EnquiryId", enquiryId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetEnquiryById.ToString(), CommandType.StoredProcedure);


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Enquiry = GetEnquiryValues(dr);
                }
            }
            return Enquiry;
        }



        private EnquiryInfo GetEnquiryValues(DataRow dr)
        {
            EnquiryInfo Enquiry = new EnquiryInfo();

            Enquiry.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

            if (!dr.IsNull("CustomerType"))
                Enquiry.CustomerType = Convert.ToInt32(dr["CustomerType"]);

            if (!dr.IsNull("CustomerId"))
                Enquiry.CustomerId = Convert.ToInt32(dr["CustomerId"]);

            if (!dr.IsNull("VendorId"))
                Enquiry.VendorId = Convert.ToInt32(dr["VendorId"]);

            if (!dr.IsNull("GuestName"))
                Enquiry.GuestName = Convert.ToString(dr["GuestName"]);

            if (!dr.IsNull("CustomerType"))
                Enquiry.CustomerType = Convert.ToInt32(dr["CustomerType"]);

            if (!dr.IsNull("CustomerId"))
                Enquiry.CustomerId = Convert.ToInt32(dr["CustomerId"]);

            if (!dr.IsNull("VendorId"))
                Enquiry.VendorId = Convert.ToInt32(dr["VendorId"]);

            if (!dr.IsNull("GuestName"))
                Enquiry.GuestName = Convert.ToString(dr["GuestName"]);

            if (!dr.IsNull("GuestEmail"))
                Enquiry.GuestEmail = Convert.ToString(dr["GuestEmail"]);

            if (!dr.IsNull("GuestMobileNo"))
                Enquiry.GuestMobileNo = Convert.ToString(dr["GuestMobileNo"]);

            if (!dr.IsNull("EnquirySource"))
                Enquiry.EnquirySource = Convert.ToInt32(dr["EnquirySource"]);

            if (!dr.IsNull("EnquiryPriority"))
                Enquiry.EnquiryPriority = Convert.ToInt32(dr["EnquiryPriority"]);

            if (!dr.IsNull("EnquiryStatus"))
                Enquiry.EnquiryStatus = Convert.ToInt32(dr["EnquiryStatus"]);

            if (!dr.IsNull("EnquiryTicketDeliveryType"))
                Enquiry.EnquiryTicketDeliveryType = Convert.ToInt32(dr["EnquiryTicketDeliveryType"]);

            if (!dr.IsNull("BestTimeToReachYou"))
                Enquiry.BestTimeToReachYou = Convert.ToString(dr["BestTimeToReachYou"]);

            if (!dr.IsNull("AdditionalInformation"))
                Enquiry.AdditionalInformation = Convert.ToString(dr["AdditionalInformation"]);

            if (!dr.IsNull("FollowupDate"))
                Enquiry.FollowupDate = Convert.ToDateTime(dr["FollowupDate"]);

            if (!dr.IsNull("EnquiryAssignedType"))
                Enquiry.EnquiryAssignedType = Convert.ToInt32(dr["EnquiryAssignedType"]);

            if (!dr.IsNull("EnquiryAssigneeName"))
                Enquiry.EnquiryAssigneeName = Convert.ToInt32(dr["EnquiryAssigneeName"]);

            if (!dr.IsNull("EnquiryType"))
                Enquiry.EnquiryTypeID = Convert.ToInt32(dr["EnquiryType"]);

            if (!dr.IsNull("Specialization"))
                Enquiry.SpecializationId = Convert.ToInt32(dr["Specialization"]);


            return Enquiry;

        }

        #endregion

        #region Common EnquiryItem

        // Common Insert

        public int InsertEnquiryItem(EnquiryInfo enquiryitem)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInEnquiryItem(enquiryitem), Storeprocedures.spInsertEnquiryItem.ToString(), CommandType.StoredProcedure));
        }

        private List<SqlParameter> SetValuesInEnquiryItem(EnquiryInfo enquiryitem)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (enquiryitem.EnquiryItemId != 0)
            {
                sqlParams.Add(new SqlParameter("@EnquiryItemId", enquiryitem.EnquiryItemId));
            }
            else
            {

                sqlParams.Add(new SqlParameter("@CreatedBy", enquiryitem.CreatedBy));

                sqlParams.Add(new SqlParameter("@CreatedDate", enquiryitem.CreatedDate));
            }


            sqlParams.Add(new SqlParameter("@EnquiryId", enquiryitem.EnquiryId));

            Logger.Debug("Enquiry Controller EnquiryId:" + enquiryitem.EnquiryId);

            sqlParams.Add(new SqlParameter("@EnquiryType", enquiryitem.EnquiryType));

            Logger.Debug("Enquiry Controller EnquiryType:" + enquiryitem.EnquiryType);

            sqlParams.Add(new SqlParameter("@CategoryId", enquiryitem.CategoryId));

            Logger.Debug("Enquiry Controller CategoryId:" + enquiryitem.CategoryId);

            sqlParams.Add(new SqlParameter("@PackageTypeId", enquiryitem.PackageType));

            Logger.Debug("Enquiry Controller PackageType:" + enquiryitem.PackageType);

            sqlParams.Add(new SqlParameter("@PackageName", enquiryitem.PackageName));

            Logger.Debug("Enquiry Controller PackageName:" + enquiryitem.PackageName);

            sqlParams.Add(new SqlParameter("@NoOfNights", enquiryitem.NoOfNights));

            Logger.Debug("Enquiry Controller NoOfNights:" + enquiryitem.NoOfNights);

            sqlParams.Add(new SqlParameter("@Month", enquiryitem.Month));

            Logger.Debug("Enquiry Controller Month:" + enquiryitem.Month);

            sqlParams.Add(new SqlParameter("@Year", enquiryitem.Year));

            Logger.Debug("Enquiry Controller Year:" + enquiryitem.Year);

            sqlParams.Add(new SqlParameter("@AdultCount", enquiryitem.AdultCount));

            Logger.Debug("Enquiry Controller AdultCount:" + enquiryitem.AdultCount);

            sqlParams.Add(new SqlParameter("@ChildCount", enquiryitem.ChildCount));

            Logger.Debug("Enquiry Controller ChildCount:" + enquiryitem.ChildCount);

            sqlParams.Add(new SqlParameter("@RoomCount", enquiryitem.RoomCount));

            Logger.Debug("Enquiry Controller RoomCount:" + enquiryitem.RoomCount);

            sqlParams.Add(new SqlParameter("@RoomType", enquiryitem.RoomType));

            Logger.Debug("Enquiry Controller RoomType:" + enquiryitem.RoomType);

            sqlParams.Add(new SqlParameter("@OccupancyId", enquiryitem.OccupancyId));

            Logger.Debug("Enquiry Controller OccupancyId:" + enquiryitem.OccupancyId);


            sqlParams.Add(new SqlParameter("@CXBCount", enquiryitem.CXBCount));

            Logger.Debug("Enquiry Controller CXBCount:" + enquiryitem.CXBCount);

            sqlParams.Add(new SqlParameter("@CXBAge", enquiryitem.CXBAge));

            Logger.Debug("Enquiry Controller CXBAge:" + enquiryitem.CXBAge);

            sqlParams.Add(new SqlParameter("@CNBCount", enquiryitem.CNBCount));

            Logger.Debug("Enquiry Controller CNBCount:" + enquiryitem.CNBCount);

            sqlParams.Add(new SqlParameter("@CNBAge", enquiryitem.CNBAge));

            Logger.Debug("Enquiry Controller CNBAge:" + enquiryitem.CNBAge);

            sqlParams.Add(new SqlParameter("@Budget", enquiryitem.Budget));

            Logger.Debug("Enquiry Controller Budget:" + enquiryitem.Budget);


            sqlParams.Add(new SqlParameter("@Location", enquiryitem.Location));

            Logger.Debug("Enquiry Controller Location:" + enquiryitem.Location);

            sqlParams.Add(new SqlParameter("@CountryId", enquiryitem.CountryId));

            Logger.Debug("Enquiry Controller CountryId:" + enquiryitem.CountryId);

            sqlParams.Add(new SqlParameter("@StateId", enquiryitem.StateId));

            Logger.Debug("Enquiry Controller StateId:" + enquiryitem.StateId);

            sqlParams.Add(new SqlParameter("@Cityid", enquiryitem.CityId));

            Logger.Debug("Enquiry Controller CityId:" + enquiryitem.CityId);


            //sqlParams.Add(new SqlParameter("@Location", enquiryitem.Location));

            //Logger.Debug("Enquiry Controller Location:" + enquiryitem.Location);

            sqlParams.Add(new SqlParameter("@HotelType", enquiryitem.HotelTypeId));

            Logger.Debug("Enquiry Controller HotelType:" + enquiryitem.HotelTypeId);

            sqlParams.Add(new SqlParameter("@StarCategory", enquiryitem.StarCategory));

            Logger.Debug("Enquiry Controller StarCategory:" + enquiryitem.StarCategory);

            if (enquiryitem.FromDate == DateTime.MinValue)
            {
                DateTime? someDate = null;

                sqlParams.Add(new SqlParameter("@FromDate", someDate));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@FromDate", enquiryitem.FromDate));

                Logger.Debug("Enquiry Controller FromDate:" + enquiryitem.FromDate);
            }

            if (enquiryitem.ToDate == DateTime.MinValue)
            {
                DateTime? someDate = null;

                sqlParams.Add(new SqlParameter("@ToDate", someDate));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@ToDate", enquiryitem.ToDate));

                Logger.Debug("Enquiry Controller ToDate:" + enquiryitem.ToDate);
            }

            if (enquiryitem.CheckInDate == DateTime.MinValue)
            {
                DateTime? someDate = null;

                sqlParams.Add(new SqlParameter("@CheckInDate", someDate));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@CheckInDate", enquiryitem.CheckInDate));

                Logger.Debug("Enquiry Controller CheckInDate:" + enquiryitem.CheckInDate);
            }

            if (enquiryitem.CheckOutDate == DateTime.MinValue)
            {
                DateTime? someDate = null;

                sqlParams.Add(new SqlParameter("@CheckOutDate", someDate));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@CheckOutDate", enquiryitem.CheckOutDate));

                Logger.Debug("Enquiry Controller CheckOutDate:" + enquiryitem.CheckOutDate);
            }

            sqlParams.Add(new SqlParameter("@HotelName", enquiryitem.HotelName));

            Logger.Debug("Enquiry Controller HotelName:" + enquiryitem.HotelName);

            sqlParams.Add(new SqlParameter("@EnquiryFlightType", enquiryitem.EnquiryFlightType));

            Logger.Debug("Enquiry Controller EnquiryFlightType:" + enquiryitem.EnquiryFlightType);

            sqlParams.Add(new SqlParameter("@InfantCount", enquiryitem.InfantCount));

            Logger.Debug("Enquiry Controller InfantCount:" + enquiryitem.InfantCount);

            sqlParams.Add(new SqlParameter("@EnquiryTrainType", enquiryitem.EnquiryTrainType));

            Logger.Debug("Enquiry Controller EnquiryTrainType:" + enquiryitem.EnquiryTrainType);

            sqlParams.Add(new SqlParameter("@EnquiryVehicleType", enquiryitem.EnquiryVehicleType));

            Logger.Debug("Enquiry Controller EnquiryVehicleType:" + enquiryitem.EnquiryVehicleType);

            sqlParams.Add(new SqlParameter("@Currency", enquiryitem.Currency));

            Logger.Debug("Enquiry Controller Currency:" + enquiryitem.Currency);

            sqlParams.Add(new SqlParameter("@SightseeingName", enquiryitem.SightseeingName));

            Logger.Debug("Enquiry Controller SightseeingName:" + enquiryitem.SightseeingName);

            if (enquiryitem.TravelDate == DateTime.MinValue)
            {
                DateTime? someDate = null;

                sqlParams.Add(new SqlParameter("@TravelDate", someDate));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@TravelDate", enquiryitem.TravelDate));

                Logger.Debug("Enquiry Controller TravelDate:" + enquiryitem.TravelDate);
            }

            sqlParams.Add(new SqlParameter("@VehicleType", enquiryitem.VehicleType));

            Logger.Debug("Enquiry Controller VehicleType:" + enquiryitem.VehicleType);

            sqlParams.Add(new SqlParameter("@UpdatedBy", enquiryitem.UpdatedBy));

            Logger.Debug("Enquiry Controller UpdatedBy:" + enquiryitem.UpdatedBy);

            sqlParams.Add(new SqlParameter("@UpdatedDate", enquiryitem.UpdatedDate));

            Logger.Debug("Enquiry Controller UpdatedDate:" + enquiryitem.UpdatedDate);

            return sqlParams;

        }

        public int EnquiryAssignedName(EnquiryInfo Enquiry)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@SpecializationId", Enquiry.SpecializationId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spGetAutoAssigneName.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (!dr.IsNull("EnquiryAssigneeName"))

                        Enquiry.EnquiryAssigneeName = Convert.ToInt32(dr["EnquiryAssigneeName"]);
                }
            }

            return Enquiry.EnquiryAssigneeName;

        }

        // Common Delete

        public void DeleteEnquiryItemById(int enquiryItemId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            EnquiryInfo EnquiryItem = new EnquiryInfo();

            sqlParam.Add(new SqlParameter("@EnquiryItemId", enquiryItemId));

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteEnquiryItemById.ToString(), CommandType.StoredProcedure);


        }

        public void DeleteEnquiryItemTypeById(int enquiryItemId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            EnquiryInfo EnquiryItem = new EnquiryInfo();

            sqlParam.Add(new SqlParameter("@EnquiryItemId", enquiryItemId));

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeletetEnquiryTypeByEnquiryItemId.ToString(), CommandType.StoredProcedure);


        }

        public void DeleteEnquiryItemTransferById(int enquiryItemId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            EnquiryInfo EnquiryItem = new EnquiryInfo();

            sqlParam.Add(new SqlParameter("@EnquiryItemId", enquiryItemId));

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteTransferTypeByEnquiryItemId.ToString(), CommandType.StoredProcedure);


        }

        public void DeleteEnquiryItemPassById(int enquiryItemId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            EnquiryInfo EnquiryItem = new EnquiryInfo();

            sqlParam.Add(new SqlParameter("@EnquiryItemId", enquiryItemId));

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteItemPassByEnquiryItemId.ToString(), CommandType.StoredProcedure);


        }

        // Common Get

        public List<EnquiryInfo> GetEnquiryItemDetails(int enquiryId)
        {

            List<EnquiryInfo> EnquiryItemDetails = new List<EnquiryInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@EnquiryId", enquiryId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetEnquiryItemDetails.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                EnquiryItemDetails.Add(GetEnquiryItemDetails(dr));
            }

            return EnquiryItemDetails;
        }

        private EnquiryInfo GetEnquiryItemDetails(DataRow dr)
        {
            EnquiryInfo EnquiryItem = new EnquiryInfo();

            EnquiryItem.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

            if (!dr.IsNull("EnquiryId"))
                EnquiryItem.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

            if (!dr.IsNull("EnquiryType"))
                EnquiryItem.EnquiryType = Convert.ToInt32(dr["EnquiryType"]);

            if (!dr.IsNull("CategoryId"))
                EnquiryItem.CategoryId = Convert.ToInt32(dr["CategoryId"]);

            if (!dr.IsNull("EnquiryStatus"))
                EnquiryItem.EnquiryStatus = Convert.ToInt32(dr["EnquiryStatus"]);

            //if (!dr.IsNull("CategoryName"))
                //EnquiryItem.CategoryName = Convert.ToString(dr["CategoryName"]);

            if (!dr.IsNull("PackageTypeId"))
                EnquiryItem.PackageType = Convert.ToInt32(dr["PackageTypeId"]);

            if (!dr.IsNull("PackageTypeName"))
                EnquiryItem.PackageTypeName = Convert.ToString(dr["PackageTypeName"]);

            if (!dr.IsNull("PackageName"))
                EnquiryItem.PackageName = Convert.ToString(dr["PackageName"]);

            if (!dr.IsNull("NoOfNights"))
                EnquiryItem.NoOfNights = Convert.ToInt32(dr["NoOfNights"]);

            if (!dr.IsNull("Month"))
                EnquiryItem.Month = Convert.ToInt32(dr["Month"]);

            if (!dr.IsNull("Year"))
                EnquiryItem.Year = Convert.ToInt32(dr["Year"]);

            if (!dr.IsNull("AdultCount"))
                EnquiryItem.AdultCount = Convert.ToInt32(dr["AdultCount"]);

            if (!dr.IsNull("ChildCount"))
                EnquiryItem.ChildCount = Convert.ToInt32(dr["ChildCount"]);

            if (!dr.IsNull("Budget"))
                EnquiryItem.Budget = Convert.ToInt32(dr["Budget"]);

            if (!dr.IsNull("Location"))
                EnquiryItem.Location = Convert.ToInt32(dr["Location"]);

            if (!dr.IsNull("CityName"))
                EnquiryItem.CityName = Convert.ToString(dr["CityName"]);

            if (!dr.IsNull("HotelType"))
                EnquiryItem.HotelTypeId = Convert.ToInt32(dr["HotelType"]);

            if (!dr.IsNull("StarCategory"))
                EnquiryItem.StarCategory = Convert.ToInt32(dr["StarCategory"]);

            if (!dr.IsNull("StarCategoryStr"))
                EnquiryItem.StarCategoryStr = Convert.ToString(dr["StarCategoryStr"]);

            if (!dr.IsNull("RoomType"))
                EnquiryItem.RoomType = Convert.ToInt32(dr["RoomType"]);

            if (!dr.IsNull("RoomTypeName"))
                EnquiryItem.RoomTypeName = Convert.ToString(dr["RoomTypeName"]);

            if (!dr.IsNull("OccupancyId"))
                EnquiryItem.OccupancyId = Convert.ToInt32(dr["OccupancyId"]);

            if (!dr.IsNull("OccupancyName"))
                EnquiryItem.OccupancyName = Convert.ToString(dr["OccupancyName"]);

            if (!dr.IsNull("FromDate"))
                EnquiryItem.FromDate = Convert.ToDateTime(dr["FromDate"]);

            if (!dr.IsNull("ToDate"))
                EnquiryItem.ToDate = Convert.ToDateTime(dr["ToDate"]);

            if (!dr.IsNull("RoomCount"))
                EnquiryItem.RoomCount = Convert.ToInt32(dr["RoomCount"]);

            if (!dr.IsNull("CountryName"))
                EnquiryItem.CountryName = Convert.ToString(dr["CountryName"]);

            if (!dr.IsNull("StateName"))
                EnquiryItem.StateName = Convert.ToString(dr["StateName"]);

            if (!dr.IsNull("City"))
                EnquiryItem.City = Convert.ToString(dr["City"]);

            if (!dr.IsNull("CountryId"))
                EnquiryItem.CountryId = Convert.ToInt32(dr["CountryId"]);

            if (!dr.IsNull("StateId"))
                EnquiryItem.StateId = Convert.ToInt32(dr["StateId"]);

            if (!dr.IsNull("Cityid"))
                EnquiryItem.CityId = Convert.ToInt32(dr["Cityid"]);


            if (!dr.IsNull("CXBCount"))
                EnquiryItem.CXBCount = Convert.ToInt32(dr["CXBCount"]);

            if (!dr.IsNull("CXBAge"))
                EnquiryItem.CXBAge = Convert.ToString(dr["CXBAge"]);

            if (!dr.IsNull("CNBCount"))
                EnquiryItem.CNBCount = Convert.ToInt32(dr["CNBCount"]);

            if (!dr.IsNull("CNBAge"))
                EnquiryItem.CNBAge = Convert.ToString(dr["CNBAge"]);

            if (!dr.IsNull("CheckInDate"))
                EnquiryItem.CheckInDate = Convert.ToDateTime(dr["CheckInDate"]);

            if (!dr.IsNull("CheckOutDate"))
                EnquiryItem.CheckOutDate = Convert.ToDateTime(dr["CheckOutDate"]);

            if (!dr.IsNull("HotelType"))
                EnquiryItem.HotelTypeId = Convert.ToInt32(dr["HotelType"]);

            if (!dr.IsNull("HotelTypeName"))
                EnquiryItem.HotelTypeName = Convert.ToString(dr["HotelTypeName"]);

            if (!dr.IsNull("HotelName"))
                EnquiryItem.HotelName = Convert.ToString(dr["HotelName"]);

            if (!dr.IsNull("SightseeingName"))
                EnquiryItem.SightseeingName = Convert.ToString(dr["SightseeingName"]);

            if (!dr.IsNull("TravelDate"))
                EnquiryItem.TravelDate = Convert.ToDateTime(dr["TravelDate"]);

            if (!dr.IsNull("VehicleType"))
                EnquiryItem.VehicleType = Convert.ToInt32(dr["VehicleType"]);

            if (!dr.IsNull("VehicleTypeName"))
                EnquiryItem.VehicleTypeName = Convert.ToString(dr["VehicleTypeName"]);

            if (!dr.IsNull("EnquiryFlightType"))
                EnquiryItem.EnquiryFlightType = Convert.ToInt32(dr["EnquiryFlightType"]);

            if (!dr.IsNull("Currency"))
                EnquiryItem.Currency = Convert.ToInt32(dr["Currency"]);

            if (!dr.IsNull("CurrencyName"))
                EnquiryItem.CurrencyName = Convert.ToString(dr["CurrencyName"]);

            if (!dr.IsNull("EnquiryTrainType"))
                EnquiryItem.EnquiryTrainType = Convert.ToInt32(dr["EnquiryTrainType"]);

            if (!dr.IsNull("InfantCount"))
                EnquiryItem.InfantCount = Convert.ToInt32(dr["InfantCount"]);

            if (!dr.IsNull("CustomerName"))
            {
                EnquiryItem.CustomerName = Convert.ToString(dr["CustomerName"]);
            }
            if (!dr.IsNull("VendorName"))
            {
                EnquiryItem.VendorName = Convert.ToString(dr["VendorName"]);
            }
            if (!dr.IsNull("GuestName"))
            {
                EnquiryItem.GuestName = Convert.ToString(dr["GuestName"]);
            }

            if (!dr.IsNull("UserName"))
                EnquiryItem.UserName = Convert.ToString(dr["UserName"]);

            if (!dr.IsNull("EnquirySource"))
                EnquiryItem.EnquirySourceName = Convert.ToString(dr["EnquirySource"]);

            if (!dr.IsNull("EnquiryTypeName"))
                EnquiryItem.EnquiryTypeName = Convert.ToString(dr["EnquiryTypeName"]);

            if (!dr.IsNull("Specializationname"))
                EnquiryItem.SpecializationName = Convert.ToString(dr["Specializationname"]);

            if (!dr.IsNull("CreatedBy"))
                EnquiryItem.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            if (!dr.IsNull("CreatedDate"))
                EnquiryItem.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);

            if (!dr.IsNull("UpdatedBy"))
                EnquiryItem.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            if (!dr.IsNull("UpdatedDate"))
                EnquiryItem.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);

            EnquiryItem.EnquiryItemTypeDetails = GetEnquiryItemTypeDetails(EnquiryItem.EnquiryId, EnquiryItem.EnquiryItemId);

            EnquiryItem.EnquiryItemTransferDetails = GetEnquiryItemTransferTypeDetails(EnquiryItem.EnquiryId, EnquiryItem.EnquiryItemId);

            EnquiryItem.EnquiryItemPassDetails = GetEnquiryItemPassDetails(EnquiryItem.EnquiryId, EnquiryItem.EnquiryItemId);



            return EnquiryItem;

        }

        public List<EnquiryItemTypeDetailsInfo> GetEnquiryItemTypeDetails(int enquiryId, int enquiryItemId)
        {
            List<EnquiryItemTypeDetailsInfo> enquiryitemtypedetails = new List<EnquiryItemTypeDetailsInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@EnquiryId", enquiryId));

            sqlParamList.Add(new SqlParameter("@EnquiryItemId", enquiryItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetEnquiryItemTypeDetails.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    EnquiryItemTypeDetailsInfo enquiryitemtypelist = new EnquiryItemTypeDetailsInfo();

                    if (!dr.IsNull("EnquiryItemTypeDetailsId"))
                        enquiryitemtypelist.EnquiryItemTypeDetailsId = Convert.ToInt32(dr["EnquiryItemTypeDetailsId"]);

                    if (!dr.IsNull("EnquiryItemId"))
                        enquiryitemtypelist.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

                    if (!dr.IsNull("EnquiryId"))
                        enquiryitemtypelist.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

                    if (!dr.IsNull("TicketClass"))
                        enquiryitemtypelist.TicketClass = Convert.ToInt32(dr["TicketClass"]);

                    if (!dr.IsNull("TicketClassName"))
                        enquiryitemtypelist.TicketClassName = Convert.ToString(dr["TicketClassName"]);

                    if (!dr.IsNull("PickUpFrom"))
                        enquiryitemtypelist.PickUpFrom = Convert.ToInt32(dr["PickUpFrom"]);

                    if (!dr.IsNull("PickUpFromName"))
                        enquiryitemtypelist.PickUpFromName = Convert.ToString(dr["PickUpFromName"]);

                    if (!dr.IsNull("DropTo"))
                        enquiryitemtypelist.DropTo = Convert.ToInt32(dr["DropTo"]);

                    if (!dr.IsNull("DropToName"))
                        enquiryitemtypelist.DropToName = Convert.ToString(dr["DropToName"]);

                    if (!dr.IsNull("DepartureDate"))
                        enquiryitemtypelist.DepartureDate = Convert.ToDateTime(dr["DepartureDate"]);

                    if (!dr.IsNull("ArrivalDate"))
                        enquiryitemtypelist.ReturnDate = Convert.ToDateTime(dr["ArrivalDate"]);

                    enquiryitemtypedetails.Add(enquiryitemtypelist);
                }
            }

            return enquiryitemtypedetails;
        }

        public List<EnquiryItemTransferDetailsInfo> GetEnquiryItemTransferTypeDetails(int enquiryId, int enquiryItemId)
        {
            List<EnquiryItemTransferDetailsInfo> enquiryitemtransfertypedetails = new List<EnquiryItemTransferDetailsInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@EnquiryId", enquiryId));

            sqlParamList.Add(new SqlParameter("@EnquiryItemId", enquiryItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetEnquiryItemTransferTypeDetails.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    EnquiryItemTransferDetailsInfo transfertypelist = new EnquiryItemTransferDetailsInfo();

                    if (!dr.IsNull("EnquiryItemTransferDetailsId"))
                        transfertypelist.EnquiryItemTransferDetailsId = Convert.ToInt32(dr["EnquiryItemTransferDetailsId"]);

                    if (!dr.IsNull("EnquiryItemId"))
                        transfertypelist.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

                    if (!dr.IsNull("EnquiryId"))
                        transfertypelist.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

                    if (!dr.IsNull("TransferDate"))
                        transfertypelist.TransferDate = Convert.ToDateTime(dr["TransferDate"]);

                    if (!dr.IsNull("PickUpId"))
                        transfertypelist.PickUpId = Convert.ToInt32(dr["PickUpId"]);

                    if (!dr.IsNull("PickUpTypeName"))
                        transfertypelist.PickUpTypeName = Convert.ToString(dr["PickUpTypeName"]);

                    if (!dr.IsNull("PickUpName"))
                        transfertypelist.PickUpName = Convert.ToString(dr["PickUpName"]);

                    if (!dr.IsNull("PickUpTime"))
                        transfertypelist.PickUpTime = Convert.ToString(dr["PickUpTime"]);

                    if (!dr.IsNull("DropOffId"))
                        transfertypelist.DropOffId = Convert.ToInt32(dr["DropOffId"]);

                    if (!dr.IsNull("DropOffTypeName"))
                        transfertypelist.DropOffTypeName = Convert.ToString(dr["DropOffTypeName"]);

                    if (!dr.IsNull("DropOffName"))
                        transfertypelist.DropOffName = Convert.ToString(dr["DropOffName"]);

                    if (!dr.IsNull("DropOffTime"))
                        transfertypelist.DropOffTime = Convert.ToString(dr["DropOffTime"]);

                    enquiryitemtransfertypedetails.Add(transfertypelist);
                }
            }

            return enquiryitemtransfertypedetails;
        }

        public List<EnquiryItemPassDetailsInfo> GetEnquiryItemPassDetails(int enquiryId, int enquiryItemId)
        {
            List<EnquiryItemPassDetailsInfo> enquiryitempassdetails = new List<EnquiryItemPassDetailsInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@EnquiryId", enquiryId));

            sqlParamList.Add(new SqlParameter("@EnquiryItemId", enquiryItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetTrainPassDetails.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    EnquiryItemPassDetailsInfo trainpasslist = new EnquiryItemPassDetailsInfo();

                    if (!dr.IsNull("EnquiryItemPassDetailsId"))
                        trainpasslist.EnquiryItemPassDetailsId = Convert.ToInt32(dr["EnquiryItemPassDetailsId"]);

                    if (!dr.IsNull("EnquiryItemId"))
                        trainpasslist.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

                    if (!dr.IsNull("EnquiryId"))
                        trainpasslist.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

                    if (!dr.IsNull("Region"))
                        trainpasslist.Region = Convert.ToInt32(dr["Region"]);

                    if (!dr.IsNull("RegionName"))
                        trainpasslist.RegionName = Convert.ToString(dr["RegionName"]);

                    if (!dr.IsNull("PassType"))
                        trainpasslist.PassType = Convert.ToInt32(dr["PassType"]);

                    if (!dr.IsNull("PassTypeName"))
                        trainpasslist.PassTypeName = Convert.ToString(dr["PassTypeName"]);

                    if (!dr.IsNull("RailClass"))
                        trainpasslist.RailClass = Convert.ToInt32(dr["RailClass"]);

                    if (!dr.IsNull("RailClassName"))
                        trainpasslist.RailClassName = Convert.ToString(dr["RailClassName"]);

                    if (!dr.IsNull("RailPass"))
                        trainpasslist.RailPass = Convert.ToInt32(dr["RailPass"]);

                    if (!dr.IsNull("RailPassName"))
                        trainpasslist.RailPassName = Convert.ToString(dr["RailPassName"]);

                    if (!dr.IsNull("NoOfDays"))
                        trainpasslist.NoOfDays = Convert.ToInt32(dr["NoOfDays"]);

                    enquiryitempassdetails.Add(trainpasslist);
                }
            }

            return enquiryitempassdetails;
        }

        #endregion

        #region Git Enquiry Item

        public void UpdateEnquiryGitDetails(EnquiryInfo enquiryitem)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInEnquiryItem(enquiryitem), Storeprocedures.spUpdateEnquiryGitDetails.ToString(), CommandType.StoredProcedure);
        }

        public EnquiryInfo GetGitDetailsById(int enquiryItemId)
        {

            EnquiryInfo GitDetail = new EnquiryInfo();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@EnquiryItemId", enquiryItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetGitDetailsById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    GitDetail = GetGitDetailsValues(dr);
                }
            }

            return GitDetail;
        }

        private EnquiryInfo GetGitDetailsValues(DataRow dr)
        {
            EnquiryInfo Git = new EnquiryInfo();

            Git.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

            if (!dr.IsNull("EnquiryId"))
                Git.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

            if (!dr.IsNull("EnquiryType"))
                Git.EnquiryType = Convert.ToInt32(dr["EnquiryType"]);

            if (!dr.IsNull("CategoryId"))
                Git.CategoryId = Convert.ToInt32(dr["CategoryId"]);

            if (!dr.IsNull("PackageTypeId"))
                Git.PackageType = Convert.ToInt32(dr["PackageTypeId"]);

            if (!dr.IsNull("Location"))
                Git.Location = Convert.ToInt32(dr["Location"]);

            if (!dr.IsNull("NoOfNights"))
                Git.NoOfNights = Convert.ToInt32(dr["NoOfNights"]);

            if (!dr.IsNull("AdultCount"))
                Git.AdultCount = Convert.ToInt32(dr["AdultCount"]);

            if (!dr.IsNull("ChildCount"))
                Git.ChildCount = Convert.ToInt32(dr["ChildCount"]);

            if (!dr.IsNull("Budget"))
                Git.Budget = Convert.ToInt32(dr["Budget"]);


            if (!dr.IsNull("FirstName"))
                Git.UserName = Convert.ToString(dr["FirstName"]);

            if (!dr.IsNull("Cityid"))
                Git.CityId = Convert.ToInt32(dr["Cityid"]);

            if (!dr.IsNull("StateId"))
                Git.StateId = Convert.ToInt32(dr["StateId"]);

            if (!dr.IsNull("CountryId"))
                Git.CountryId = Convert.ToInt32(dr["CountryId"]);


            if (!dr.IsNull("FromDate"))
                Git.FromDate = Convert.ToDateTime(dr["FromDate"]);

            if (!dr.IsNull("CreatedBy"))
                Git.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            if (!dr.IsNull("CreatedDate"))
                Git.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);

            if (!dr.IsNull("UpdatedBy"))
                Git.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            if (!dr.IsNull("UpdatedDate"))
                Git.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);

            return Git;

        }

        #endregion

        #region Fit Enquiry Item

        public void UpdateEnquiryFitDetails(EnquiryInfo enquiryitem)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInEnquiryItem(enquiryitem), Storeprocedures.spUpdateEnquiryFitDetails.ToString(), CommandType.StoredProcedure);
        }

        public EnquiryInfo GetFitDetailsById(int enquiryItemId)
        {

            EnquiryInfo FitDetail = new EnquiryInfo();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@EnquiryItemId", enquiryItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetFitDetailsById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    FitDetail = GetFitDetailsValues(dr);
                }
            }

            return FitDetail;
        }

        private EnquiryInfo GetFitDetailsValues(DataRow dr)
        {
            EnquiryInfo Fit = new EnquiryInfo();

            Fit.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

            if (!dr.IsNull("EnquiryId"))
                Fit.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

            if (!dr.IsNull("EnquiryType"))
                Fit.EnquiryType = Convert.ToInt32(dr["EnquiryType"]);

            if (!dr.IsNull("CategoryId"))
                Fit.CategoryId = Convert.ToInt32(dr["CategoryId"]);

            if (!dr.IsNull("PackageTypeId"))
                Fit.PackageType = Convert.ToInt32(dr["PackageTypeId"]);

            if (!dr.IsNull("PackageName"))
                Fit.PackageName = Convert.ToString(dr["PackageName"]);

            if (!dr.IsNull("Location"))
                Fit.Location = Convert.ToInt32(dr["Location"]);

            if (!dr.IsNull("NoOfNights"))
                Fit.NoOfNights = Convert.ToInt32(dr["NoOfNights"]);

            if (!dr.IsNull("HotelType"))
                Fit.HotelTypeId = Convert.ToInt32(dr["HotelType"]);

            if (!dr.IsNull("StarCategory"))
                Fit.StarCategory = Convert.ToInt32(dr["StarCategory"]);

            if (!dr.IsNull("RoomType"))
                Fit.RoomType = Convert.ToInt32(dr["RoomType"]);

            if (!dr.IsNull("OccupancyId"))
                Fit.OccupancyId = Convert.ToInt32(dr["OccupancyId"]);

            if (!dr.IsNull("Budget"))
                Fit.Budget = Convert.ToInt32(dr["Budget"]);

            if (!dr.IsNull("FromDate"))
                Fit.FromDate = Convert.ToDateTime(dr["FromDate"]);

            if (!dr.IsNull("ToDate"))
                Fit.ToDate = Convert.ToDateTime(dr["ToDate"]);

            if (!dr.IsNull("CountryId"))
                Fit.CountryId = Convert.ToInt32(dr["CountryId"]);

            if (!dr.IsNull("StateId"))
                Fit.StateId = Convert.ToInt32(dr["StateId"]);

            if (!dr.IsNull("CityId"))
                Fit.CityId = Convert.ToInt32(dr["CityId"]);

            if (!dr.IsNull("CheckInDate"))
                Fit.CheckInDate = Convert.ToDateTime(dr["CheckInDate"]);

            if (!dr.IsNull("CheckOutDate"))
                Fit.CheckOutDate = Convert.ToDateTime(dr["CheckOutDate"]);

            //if (!dr.IsNull("EnquiryAssignedType"))
            //    Fit.EnquiryAssignedType = Convert.ToInt32(dr["EnquiryAssignedType"]);

            //if (!dr.IsNull("EnquiryAssigneeName"))
            //    Fit.EnquiryAssigneeName = Convert.ToInt32(dr["EnquiryAssigneeName"]);

            if (!dr.IsNull("FirstName"))
                Fit.UserName = Convert.ToString(dr["FirstName"]);

            if (!dr.IsNull("RoomCount"))
                Fit.RoomCount = Convert.ToInt32(dr["RoomCount"]);

            if (!dr.IsNull("AdultCount"))
                Fit.AdultCount = Convert.ToInt32(dr["AdultCount"]);

            if (!dr.IsNull("CXBCount"))
                Fit.CXBCount = Convert.ToInt32(dr["CXBCount"]);

            if (!dr.IsNull("CXBAge"))
                Fit.CXBAge = Convert.ToString(dr["CXBAge"]);

            if (!dr.IsNull("CNBCount"))
                Fit.CNBCount = Convert.ToInt32(dr["CNBCount"]);

            if (!dr.IsNull("CNBAge"))
                Fit.CNBAge = Convert.ToString(dr["CNBAge"]);

            if (!dr.IsNull("CreatedBy"))
                Fit.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            if (!dr.IsNull("CreatedDate"))
                Fit.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);

            if (!dr.IsNull("UpdatedBy"))
                Fit.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            if (!dr.IsNull("UpdatedDate"))
                Fit.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);

            return Fit;

        }

        #endregion

        #region Hotel Enquiry Item

        public void UpdateEnquiryHotelDetails(EnquiryInfo enquiryitem)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInEnquiryItem(enquiryitem), Storeprocedures.spUpdateEnquiryHotelDetails.ToString(), CommandType.StoredProcedure);
        }

        public EnquiryInfo GetHotelDetailsById(int enquiryItemId)
        {

            EnquiryInfo HotelDetail = new EnquiryInfo();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@EnquiryItemId", enquiryItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetEnquiryHotelDetailsById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    HotelDetail = GetHotelDetailsValues(dr);
                }
            }

            return HotelDetail;
        }

        private EnquiryInfo GetHotelDetailsValues(DataRow dr)
        {
            EnquiryInfo Hotel = new EnquiryInfo();

            Hotel.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

            if (!dr.IsNull("EnquiryId"))
                Hotel.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

            if (!dr.IsNull("EnquiryType"))
                Hotel.EnquiryType = Convert.ToInt32(dr["EnquiryType"]);

            if (!dr.IsNull("Location"))
                Hotel.Location = Convert.ToInt32(dr["Location"]);

            if (!dr.IsNull("CheckInDate"))
                Hotel.CheckInDate = Convert.ToDateTime(dr["CheckInDate"]);

            if (!dr.IsNull("CheckOutDate"))
                Hotel.CheckOutDate = Convert.ToDateTime(dr["CheckOutDate"]);

            if (!dr.IsNull("Budget"))
                Hotel.Budget = Convert.ToInt32(dr["Budget"]);

            if (!dr.IsNull("StarCategory"))
                Hotel.StarCategory = Convert.ToInt32(dr["StarCategory"]);

            if (!dr.IsNull("HotelType"))
                Hotel.HotelTypeId = Convert.ToInt32(dr["HotelType"]);

            if (!dr.IsNull("HotelName"))
                Hotel.HotelName = Convert.ToString(dr["HotelName"]);

            if (!dr.IsNull("RoomType"))
                Hotel.RoomType = Convert.ToInt32(dr["RoomType"]);

            if (!dr.IsNull("EnquiryAssignedType"))
                Hotel.EnquiryAssignedType = Convert.ToInt32(dr["EnquiryAssignedType"]);

            if (!dr.IsNull("EnquiryAssigneeName"))
                Hotel.EnquiryAssigneeName = Convert.ToInt32(dr["EnquiryAssigneeName"]);

            if (!dr.IsNull("RoomCount"))
                Hotel.RoomCount = Convert.ToInt32(dr["RoomCount"]);

            if (!dr.IsNull("CountryId"))
                Hotel.CountryId = Convert.ToInt32(dr["CountryId"]);

            if (!dr.IsNull("StateId"))
                Hotel.StateId = Convert.ToInt32(dr["StateId"]);

            if (!dr.IsNull("CityId"))
                Hotel.CityId = Convert.ToInt32(dr["CityId"]);

            if (!dr.IsNull("AdultCount"))
                Hotel.AdultCount = Convert.ToInt32(dr["AdultCount"]);

            if (!dr.IsNull("CXBCount"))
                Hotel.CXBCount = Convert.ToInt32(dr["CXBCount"]);

            if (!dr.IsNull("CXBAge"))
                Hotel.CXBAge = Convert.ToString(dr["CXBAge"]);

            if (!dr.IsNull("CNBCount"))
                Hotel.CNBCount = Convert.ToInt32(dr["CNBCount"]);

            if (!dr.IsNull("CNBAge"))
                Hotel.CNBAge = Convert.ToString(dr["CNBAge"]);

            if (!dr.IsNull("CreatedBy"))
                Hotel.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            if (!dr.IsNull("CreatedDate"))
                Hotel.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);

            if (!dr.IsNull("UpdatedBy"))
                Hotel.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            if (!dr.IsNull("UpdatedDate"))
                Hotel.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);

            return Hotel;

        }

        #endregion

        #region Sightseeing Enquiry Item

        public void UpdateEnquirySightseeingDetails(EnquiryInfo enquiryitem)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInEnquiryItem(enquiryitem), Storeprocedures.spUpdateEnquirySightseeingDetails.ToString(), CommandType.StoredProcedure);
        }

        public EnquiryInfo GetSightseeingDetailsById(int enquiryItemId)
        {

            EnquiryInfo SightseeingDetail = new EnquiryInfo();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@EnquiryItemId", enquiryItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetEnquirySightseeingDetailsById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SightseeingDetail = GetSightseeingDetailsValues(dr);
                }
            }

            return SightseeingDetail;
        }

        private EnquiryInfo GetSightseeingDetailsValues(DataRow dr)
        {
            EnquiryInfo Sightseeing = new EnquiryInfo();

            Sightseeing.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

            if (!dr.IsNull("EnquiryId"))
                Sightseeing.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

            if (!dr.IsNull("EnquiryType"))
                Sightseeing.EnquiryType = Convert.ToInt32(dr["EnquiryType"]);

            //if (!dr.IsNull("Location"))
            //    Sightseeing.Location = Convert.ToInt32(dr["Location"]);

            if (!dr.IsNull("CityId"))
                Sightseeing.CityId = Convert.ToInt32(dr["CityId"]);                     

            if (!dr.IsNull("StateId"))
                Sightseeing.StateId = Convert.ToInt32(dr["StateId"]);

            if (!dr.IsNull("CountryId"))
                Sightseeing.CountryId = Convert.ToInt32(dr["CountryId"]);

            if (!dr.IsNull("SightseeingName"))
                Sightseeing.SightseeingName = Convert.ToString(dr["SightseeingName"]);

            if (!dr.IsNull("TravelDate"))
                Sightseeing.TravelDate = Convert.ToDateTime(dr["TravelDate"]);

            if (!dr.IsNull("VehicleType"))
                Sightseeing.VehicleType = Convert.ToInt32(dr["VehicleType"]);

            if (!dr.IsNull("Budget"))
                Sightseeing.Budget = Convert.ToInt32(dr["Budget"]);


            if (!dr.IsNull("CreatedBy"))
                Sightseeing.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            if (!dr.IsNull("CreatedDate"))
                Sightseeing.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);

            if (!dr.IsNull("UpdatedBy"))
                Sightseeing.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            if (!dr.IsNull("UpdatedDate"))
                Sightseeing.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);

            return Sightseeing;

        }

        #endregion

        #region Flight Enquiry Item

        public int InsertFlightEnquiryItem(EnquiryInfo enquiryitem)
        {
            enquiryitem.EnquiryItemId = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInEnquiryItem(enquiryitem), Storeprocedures.spInsertEnquiryItem.ToString(), CommandType.StoredProcedure));

            InsertEnquiryItemTypeDetail(enquiryitem);

            return enquiryitem.EnquiryItemId;
        }

        public void InsertEnquiryItemTypeDetail(EnquiryInfo enquiryitem)
        {
            foreach (var item in enquiryitem.EnquiryItemTypeDetails)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@EnquiryItemId", enquiryitem.EnquiryItemId));

                sqlParams.Add(new SqlParameter("@EnquiryId", enquiryitem.EnquiryId));

                sqlParams.Add(new SqlParameter("@TicketClass", item.TicketClass));

                sqlParams.Add(new SqlParameter("@PickUpFrom", item.PickUpFrom));

                sqlParams.Add(new SqlParameter("@DropTo", item.DropTo));

                if (item.DepartureDate == DateTime.MinValue)
                {
                    DateTime? someDate = null;

                    sqlParams.Add(new SqlParameter("@DepartureDate", someDate));
                }
                else
                {
                    sqlParams.Add(new SqlParameter("@DepartureDate", item.DepartureDate));

                    Logger.Debug("Enquiry Controller DepartureDate:" + item.DepartureDate);
                }

                if (item.ReturnDate == DateTime.MinValue)
                {
                    DateTime? someDate = null;

                    sqlParams.Add(new SqlParameter("@ArrivalDate", someDate));
                }
                else
                {
                    sqlParams.Add(new SqlParameter("@ArrivalDate", item.ReturnDate));

                    Logger.Debug("Enquiry Controller ArrivalDate:" + item.ReturnDate);
                }

                sqlParams.Add(new SqlParameter("@CreatedBy", enquiryitem.CreatedBy));

                sqlParams.Add(new SqlParameter("@CreatedDate", enquiryitem.CreatedDate));

                sqlParams.Add(new SqlParameter("@UpdatedBy", enquiryitem.UpdatedBy));

                sqlParams.Add(new SqlParameter("@UpdatedDate", enquiryitem.UpdatedDate));

                _sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.spInsertEnquiryItemTypeDetails.ToString(), CommandType.StoredProcedure);
            }
        }

        public void DeleteEnquiryItemType(int enquiryItemId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            EnquiryItemTransferDetailsInfo TransferDetail = new EnquiryItemTransferDetailsInfo();

            sqlParam.Add(new SqlParameter("EnquiryItemId", enquiryItemId));

            Logger.Debug("Enquiry Controller DeleteItemType:" + enquiryItemId);

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteItemTypeByEnquiryItemId.ToString(), CommandType.StoredProcedure);

        }

        public void UpdateEnquiryFlightDetails(EnquiryInfo enquiryitem)
        {

            List<SqlParameter> Sqlparamaters = new List<SqlParameter>();

            Sqlparamaters.Add(new SqlParameter("@EnquiryItemId", enquiryitem.EnquiryItemId));

            _sqlHelper.ExecuteNonQuery(SetValuesInEnquiryItem(enquiryitem), Storeprocedures.spUpdateEnquiryFlightDetails.ToString(), CommandType.StoredProcedure);

            DeleteEnquiryItemType(enquiryitem.EnquiryItemId);

            InsertEnquiryItemTypeDetail(enquiryitem);

        }

        public EnquiryInfo GetFlightDetailsById(int enquiryItemId)
        {

            EnquiryInfo FlightDetail = new EnquiryInfo();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@EnquiryItemId", enquiryItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetEnquiryFlightDetailsById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    FlightDetail = GetFlightDetailsValues(dr);
                }
            }

            return FlightDetail;
        }

        private EnquiryInfo GetFlightDetailsValues(DataRow dr)
        {
            EnquiryInfo Flight = new EnquiryInfo();

            Flight.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

            if (!dr.IsNull("EnquiryId"))
                Flight.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

            if (!dr.IsNull("EnquiryType"))
                Flight.EnquiryType = Convert.ToInt32(dr["EnquiryType"]);

            if (!dr.IsNull("EnquiryFlightType"))
                Flight.EnquiryFlightType = Convert.ToInt32(dr["EnquiryFlightType"]);

            if (!dr.IsNull("AdultCount"))
                Flight.AdultCount = Convert.ToInt32(dr["AdultCount"]);

            if (!dr.IsNull("ChildCount"))
                Flight.ChildCount = Convert.ToInt32(dr["ChildCount"]);

            if (!dr.IsNull("InfantCount"))
                Flight.InfantCount = Convert.ToInt32(dr["InfantCount"]);

            if (!dr.IsNull("Budget"))
                Flight.Budget = Convert.ToInt32(dr["Budget"]);


            if (!dr.IsNull("CreatedBy"))
                Flight.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            if (!dr.IsNull("CreatedDate"))
                Flight.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);

            if (!dr.IsNull("UpdatedBy"))
                Flight.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            if (!dr.IsNull("UpdatedDate"))
                Flight.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);

            return Flight;

        }

        public List<EnquiryItemTypeDetailsInfo> GetFlightTypeDetails(int enquiryId)
        {
            List<EnquiryItemTypeDetailsInfo> flighttypedetails = new List<EnquiryItemTypeDetailsInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@EnquiryId", enquiryId));

            // sqlParamList.Add(new SqlParameter("@EnquiryType", enquiryType));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetFlightTypeDetails.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    EnquiryItemTypeDetailsInfo flighttypelist = new EnquiryItemTypeDetailsInfo();

                    if (!dr.IsNull("EnquiryItemTypeDetailsId"))
                        flighttypelist.EnquiryItemTypeDetailsId = Convert.ToInt32(dr["EnquiryItemTypeDetailsId"]);

                    if (!dr.IsNull("EnquiryItemId"))
                        flighttypelist.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

                    if (!dr.IsNull("EnquiryId"))
                        flighttypelist.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

                    if (!dr.IsNull("TicketClass"))
                        flighttypelist.TicketClass = Convert.ToInt32(dr["TicketClass"]);

                    if (!dr.IsNull("PickUpFrom"))
                        flighttypelist.PickUpFrom = Convert.ToInt32(dr["PickUpFrom"]);

                    if (!dr.IsNull("DropTo"))
                        flighttypelist.DropTo = Convert.ToInt32(dr["DropTo"]);

                    if (!dr.IsNull("DepartureDate"))
                        flighttypelist.DepartureDate = Convert.ToDateTime(dr["DepartureDate"]);

                    if (!dr.IsNull("ArrivalDate"))
                        flighttypelist.ReturnDate = Convert.ToDateTime(dr["ArrivalDate"]);

                    flighttypedetails.Add(flighttypelist);
                }
            }

            return flighttypedetails;
        }

        public List<EnquiryItemTypeDetailsInfo> GetFlightTypeDetailsById(int enquiryItemId)
        {
            List<EnquiryItemTypeDetailsInfo> flighttypedetails = new List<EnquiryItemTypeDetailsInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@EnquiryItemId", enquiryItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetFlightTypeDetailsById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    EnquiryItemTypeDetailsInfo flighttypelist = new EnquiryItemTypeDetailsInfo();

                    if (!dr.IsNull("EnquiryItemTypeDetailsId"))
                        flighttypelist.EnquiryItemTypeDetailsId = Convert.ToInt32(dr["EnquiryItemTypeDetailsId"]);

                    if (!dr.IsNull("EnquiryItemId"))
                        flighttypelist.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

                    if (!dr.IsNull("EnquiryId"))
                        flighttypelist.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

                    if (!dr.IsNull("TicketClass"))
                        flighttypelist.TicketClass = Convert.ToInt32(dr["TicketClass"]);

                    if (!dr.IsNull("PickUpFrom"))
                        flighttypelist.PickUpFrom = Convert.ToInt32(dr["PickUpFrom"]);

                    if (!dr.IsNull("DropTo"))
                        flighttypelist.DropTo = Convert.ToInt32(dr["DropTo"]);

                    if (!dr.IsNull("DepartureDate"))
                        flighttypelist.DepartureDate = Convert.ToDateTime(dr["DepartureDate"]);

                    if (!dr.IsNull("ArrivalDate"))
                        flighttypelist.ReturnDate = Convert.ToDateTime(dr["ArrivalDate"]);

                    flighttypedetails.Add(flighttypelist);
                }
            }

            return flighttypedetails;
        }

        #endregion

        #region Transfer Enqury Item

        public int InsertTransferEnquiryItem(EnquiryInfo enquiryitem)
        {
            enquiryitem.EnquiryItemId = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInEnquiryItem(enquiryitem), Storeprocedures.spInsertEnquiryItem.ToString(), CommandType.StoredProcedure));

            InsertEnquiryItemTransferDetail(enquiryitem);

            return enquiryitem.EnquiryItemId;
        }

        public void InsertEnquiryItemTransferDetail(EnquiryInfo enquiryitem)
        {
            foreach (var item in enquiryitem.EnquiryItemTransferDetails)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@EnquiryItemId", enquiryitem.EnquiryItemId));

                sqlParams.Add(new SqlParameter("@EnquiryId", enquiryitem.EnquiryId));

                if (item.TransferDate == DateTime.MinValue)
                {
                    DateTime? someDate = null;

                    sqlParams.Add(new SqlParameter("@TransferDate", someDate));
                }
                else
                {
                    sqlParams.Add(new SqlParameter("@TransferDate", item.TransferDate));

                    Logger.Debug("Enquiry Controller TransferDate:" + item.TransferDate);
                }

                sqlParams.Add(new SqlParameter("@PickUpId", item.PickUpId));

                sqlParams.Add(new SqlParameter("@PickUpName", item.PickUpName));

                sqlParams.Add(new SqlParameter("@PickUpTime", item.PickUpTime));

                sqlParams.Add(new SqlParameter("@DropOffId", item.DropOffId));

                sqlParams.Add(new SqlParameter("@DropOffName", item.DropOffName));

                sqlParams.Add(new SqlParameter("@DropOffTime", item.DropOffTime));

                sqlParams.Add(new SqlParameter("@CreatedBy", enquiryitem.CreatedBy));

                sqlParams.Add(new SqlParameter("@CreatedDate", enquiryitem.CreatedDate));

                sqlParams.Add(new SqlParameter("@UpdatedBy", enquiryitem.UpdatedBy));

                sqlParams.Add(new SqlParameter("@UpdatedDate", enquiryitem.UpdatedDate));

                _sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.spInsertEnquiryItemTransferDetails.ToString(), CommandType.StoredProcedure);
            }
        }

        public void DeleteTransferType(int enquiryItemId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            EnquiryItemTransferDetailsInfo TransferDetail = new EnquiryItemTransferDetailsInfo();

            sqlParam.Add(new SqlParameter("EnquiryItemId", enquiryItemId));

            Logger.Debug("Hotel Controller ContactPersonId:" + enquiryItemId);

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteTransferTypeByEnquiryItemId.ToString(), CommandType.StoredProcedure);

        }

        public void UpdateEnquiryTransferDetails(EnquiryInfo enquiryitem)
        {

            List<SqlParameter> Sqlparamaters = new List<SqlParameter>();

            Sqlparamaters.Add(new SqlParameter("@EnquiryItemId", enquiryitem.EnquiryItemId));

            _sqlHelper.ExecuteNonQuery(SetValuesInEnquiryItem(enquiryitem), Storeprocedures.spUpdateEnquiryTransferDetails.ToString(), CommandType.StoredProcedure);

            DeleteTransferType(enquiryitem.EnquiryItemId);

            InsertEnquiryItemTransferDetail(enquiryitem);

        }

        public EnquiryInfo GetTransferDetailsById(int enquiryItemId)
        {

            EnquiryInfo TransferDetail = new EnquiryInfo();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@EnquiryItemId", enquiryItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetEnquiryTransferDetailsById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TransferDetail = GetTransferDetailsValues(dr);
                }
            }

            return TransferDetail;
        }

        private EnquiryInfo GetTransferDetailsValues(DataRow dr)
        {
            EnquiryInfo Transfer = new EnquiryInfo();

            Transfer.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

            if (!dr.IsNull("EnquiryId"))
                Transfer.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

            if (!dr.IsNull("EnquiryType"))
                Transfer.EnquiryType = Convert.ToInt32(dr["EnquiryType"]);

            if (!dr.IsNull("Location"))
                Transfer.Location = Convert.ToInt32(dr["Location"]);

            if (!dr.IsNull("Currency"))
                Transfer.Currency = Convert.ToInt32(dr["Currency"]);

            if (!dr.IsNull("VehicleType"))
                Transfer.VehicleType = Convert.ToInt32(dr["VehicleType"]);

            if (!dr.IsNull("AdultCount"))
                Transfer.AdultCount = Convert.ToInt32(dr["AdultCount"]);

            if (!dr.IsNull("ChildCount"))
                Transfer.ChildCount = Convert.ToInt32(dr["ChildCount"]);

            if (!dr.IsNull("Budget"))
                Transfer.Budget = Convert.ToInt32(dr["Budget"]);


            if (!dr.IsNull("CreatedBy"))
                Transfer.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            if (!dr.IsNull("CreatedDate"))
                Transfer.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);

            if (!dr.IsNull("UpdatedBy"))
                Transfer.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            if (!dr.IsNull("UpdatedDate"))
                Transfer.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);

            return Transfer;

        }

        public List<EnquiryItemTransferDetailsInfo> GetTransferTypeDetails(int enquiryId)
        {
            List<EnquiryItemTransferDetailsInfo> transfertypedetails = new List<EnquiryItemTransferDetailsInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@EnquiryId", enquiryId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetTransferTypeDetails.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    EnquiryItemTransferDetailsInfo transfertypelist = new EnquiryItemTransferDetailsInfo();

                    if (!dr.IsNull("EnquiryItemTransferDetailsId"))
                        transfertypelist.EnquiryItemTransferDetailsId = Convert.ToInt32(dr["EnquiryItemTransferDetailsId"]);

                    if (!dr.IsNull("EnquiryItemId"))
                        transfertypelist.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

                    if (!dr.IsNull("EnquiryId"))
                        transfertypelist.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

                    if (!dr.IsNull("TransferDate"))
                        transfertypelist.TransferDate = Convert.ToDateTime(dr["TransferDate"]);

                    if (!dr.IsNull("PickUpId"))
                        transfertypelist.PickUpId = Convert.ToInt32(dr["PickUpId"]);

                    if (!dr.IsNull("PickUpName"))
                        transfertypelist.PickUpName = Convert.ToString(dr["PickUpName"]);

                    if (!dr.IsNull("PickUpTime"))
                        transfertypelist.PickUpTime = Convert.ToString(dr["PickUpTime"]);

                    if (!dr.IsNull("DropOffId"))
                        transfertypelist.DropOffId = Convert.ToInt32(dr["DropOffId"]);

                    if (!dr.IsNull("DropOffName"))
                        transfertypelist.DropOffName = Convert.ToString(dr["DropOffName"]);

                    if (!dr.IsNull("DropOffTime"))
                        transfertypelist.DropOffTime = Convert.ToString(dr["DropOffTime"]);

                    transfertypedetails.Add(transfertypelist);
                }
            }

            return transfertypedetails;
        }

        public List<EnquiryItemTransferDetailsInfo> GetTransferTypeDetailsById(int enquiryItemId)
        {
            List<EnquiryItemTransferDetailsInfo> transfertypedetails = new List<EnquiryItemTransferDetailsInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@EnquiryItemId", enquiryItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetTransferTypeDetailsById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    EnquiryItemTransferDetailsInfo transfertypelist = new EnquiryItemTransferDetailsInfo();

                    if (!dr.IsNull("EnquiryItemTransferDetailsId"))
                        transfertypelist.EnquiryItemTransferDetailsId = Convert.ToInt32(dr["EnquiryItemTransferDetailsId"]);

                    if (!dr.IsNull("EnquiryItemId"))
                        transfertypelist.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

                    if (!dr.IsNull("EnquiryId"))
                        transfertypelist.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

                    if (!dr.IsNull("TransferDate"))
                        transfertypelist.TransferDate = Convert.ToDateTime(dr["TransferDate"]);

                    if (!dr.IsNull("PickUpId"))
                        transfertypelist.PickUpId = Convert.ToInt32(dr["PickUpId"]);

                    if (!dr.IsNull("PickUpName"))
                        transfertypelist.PickUpName = Convert.ToString(dr["PickUpName"]);

                    if (!dr.IsNull("PickUpTime"))
                        transfertypelist.PickUpTime = Convert.ToString(dr["PickUpTime"]);

                    if (!dr.IsNull("DropOffId"))
                        transfertypelist.DropOffId = Convert.ToInt32(dr["DropOffId"]);

                    if (!dr.IsNull("DropOffName"))
                        transfertypelist.DropOffName = Convert.ToString(dr["DropOffName"]);

                    if (!dr.IsNull("DropOffTime"))
                        transfertypelist.DropOffTime = Convert.ToString(dr["DropOffTime"]);

                    transfertypedetails.Add(transfertypelist);
                }
            }

            return transfertypedetails;
        }

        #endregion

        #region  Train Enquiry Item

        public int InsertTrainEnquiryItem(EnquiryInfo enquiryitem)
        {
            enquiryitem.EnquiryItemId = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInEnquiryItem(enquiryitem), Storeprocedures.spInsertEnquiryItem.ToString(), CommandType.StoredProcedure));

            InsertEnquiryItemTrainTypeDetail(enquiryitem);

            InsertEnquiryItemTrainPassDetail(enquiryitem);

            return enquiryitem.EnquiryItemId;
        }

        public void InsertEnquiryItemTrainTypeDetail(EnquiryInfo enquiryitem)
        {
            foreach (var item in enquiryitem.EnquiryItemTypeDetails)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@EnquiryItemId", enquiryitem.EnquiryItemId));

                sqlParams.Add(new SqlParameter("@EnquiryId", enquiryitem.EnquiryId));

                sqlParams.Add(new SqlParameter("@TicketClass", item.TicketClass));

                sqlParams.Add(new SqlParameter("@PickUpFrom", item.PickUpFrom));

                sqlParams.Add(new SqlParameter("@DropTo", item.DropTo));

                if (item.DepartureDate == DateTime.MinValue)
                {
                    DateTime? someDate = null;

                    sqlParams.Add(new SqlParameter("@DepartureDate", someDate));
                }
                else
                {
                    sqlParams.Add(new SqlParameter("@DepartureDate", item.DepartureDate));

                    Logger.Debug("Enquiry Controller DepartureDate:" + item.DepartureDate);
                }

                if (item.ReturnDate == DateTime.MinValue)
                {
                    DateTime? someDate = null;

                    sqlParams.Add(new SqlParameter("@ArrivalDate", someDate));
                }
                else
                {
                    sqlParams.Add(new SqlParameter("@ArrivalDate", item.ReturnDate));

                    Logger.Debug("Enquiry Controller ArrivalDate:" + item.ReturnDate);
                }

                sqlParams.Add(new SqlParameter("@CreatedBy", enquiryitem.CreatedBy));

                sqlParams.Add(new SqlParameter("@CreatedDate", enquiryitem.CreatedDate));

                sqlParams.Add(new SqlParameter("@UpdatedBy", enquiryitem.UpdatedBy));

                sqlParams.Add(new SqlParameter("@UpdatedDate", enquiryitem.UpdatedDate));

                _sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.spInsertEnquiryItemTypeDetails.ToString(), CommandType.StoredProcedure);
            }
        }

        public void InsertEnquiryItemTrainPassDetail(EnquiryInfo enquiryitem)
        {
            foreach (var item in enquiryitem.EnquiryItemPassDetails)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@EnquiryItemId", enquiryitem.EnquiryItemId));

                sqlParams.Add(new SqlParameter("@EnquiryId", enquiryitem.EnquiryId));

                sqlParams.Add(new SqlParameter("@Region", item.Region));

                sqlParams.Add(new SqlParameter("@PassType", item.PassType));

                sqlParams.Add(new SqlParameter("@RailPass", item.RailPass));

                sqlParams.Add(new SqlParameter("@RailClass", item.RailClass));

                sqlParams.Add(new SqlParameter("@NoOfDays", item.NoOfDays));

                sqlParams.Add(new SqlParameter("@CreatedBy", enquiryitem.CreatedBy));

                sqlParams.Add(new SqlParameter("@CreatedDate", enquiryitem.CreatedDate));

                sqlParams.Add(new SqlParameter("@UpdatedBy", enquiryitem.UpdatedBy));

                sqlParams.Add(new SqlParameter("@UpdatedDate", enquiryitem.UpdatedDate));

                _sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.spInsertEnquiryItemPassDetails.ToString(), CommandType.StoredProcedure);
            }
        }

        public void DeleteEnquiryItemPass(int enquiryItemId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            EnquiryItemPassDetailsInfo PassDetail = new EnquiryItemPassDetailsInfo();

            sqlParam.Add(new SqlParameter("EnquiryItemId", enquiryItemId));

            Logger.Debug("Enquiry Controller DeleteEnquiryItemPass:" + enquiryItemId);

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteItemPassByEnquiryItemId.ToString(), CommandType.StoredProcedure);

        }

        public void UpdateEnquiryTrainDetails(EnquiryInfo enquiryitem)
        {

            List<SqlParameter> Sqlparamaters = new List<SqlParameter>();

            Sqlparamaters.Add(new SqlParameter("@EnquiryItemId", enquiryitem.EnquiryItemId));

            _sqlHelper.ExecuteNonQuery(SetValuesInEnquiryItem(enquiryitem), Storeprocedures.spUpdateEnquiryTrainDetails.ToString(), CommandType.StoredProcedure);

            DeleteEnquiryItemType(enquiryitem.EnquiryItemId);

            DeleteEnquiryItemPass(enquiryitem.EnquiryItemId);

            InsertEnquiryItemTrainTypeDetail(enquiryitem);

            InsertEnquiryItemTrainPassDetail(enquiryitem);
        }

        public EnquiryInfo GetTrainDetailsById(int enquiryItemId)
        {

            EnquiryInfo TrainDetail = new EnquiryInfo();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@EnquiryItemId", enquiryItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetEnquiryTrainDetailsById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TrainDetail = GetTrainDetailsValues(dr);
                }
            }

            return TrainDetail;
        }

        private EnquiryInfo GetTrainDetailsValues(DataRow dr)
        {
            EnquiryInfo Train = new EnquiryInfo();

            Train.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

            if (!dr.IsNull("EnquiryId"))
                Train.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

            if (!dr.IsNull("EnquiryType"))
                Train.EnquiryType = Convert.ToInt32(dr["EnquiryType"]);

            if (!dr.IsNull("EnquiryTrainType"))
                Train.EnquiryTrainType = Convert.ToInt32(dr["EnquiryTrainType"]);

            if (!dr.IsNull("AdultCount"))
                Train.AdultCount = Convert.ToInt32(dr["AdultCount"]);

            if (!dr.IsNull("ChildCount"))
                Train.ChildCount = Convert.ToInt32(dr["ChildCount"]);

            if (!dr.IsNull("InfantCount"))
                Train.InfantCount = Convert.ToInt32(dr["InfantCount"]);

            if (!dr.IsNull("Budget"))
                Train.Budget = Convert.ToInt32(dr["Budget"]);



            if (!dr.IsNull("CreatedBy"))
                Train.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            if (!dr.IsNull("CreatedDate"))
                Train.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);

            if (!dr.IsNull("UpdatedBy"))
                Train.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            if (!dr.IsNull("UpdatedDate"))
                Train.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);

            return Train;

        }

        public List<EnquiryItemTypeDetailsInfo> GetTrainTypeDetails(int enquiryId, int enquiryType)
        {
            List<EnquiryItemTypeDetailsInfo> traintypedetails = new List<EnquiryItemTypeDetailsInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@EnquiryId", enquiryId));

            sqlParamList.Add(new SqlParameter("@EnquiryType", enquiryType));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetTrainTypeDetails.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    EnquiryItemTypeDetailsInfo traintypelist = new EnquiryItemTypeDetailsInfo();

                    if (!dr.IsNull("EnquiryItemTypeDetailsId"))
                        traintypelist.EnquiryItemTypeDetailsId = Convert.ToInt32(dr["EnquiryItemTypeDetailsId"]);

                    if (!dr.IsNull("EnquiryItemId"))
                        traintypelist.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

                    if (!dr.IsNull("EnquiryId"))
                        traintypelist.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

                    if (!dr.IsNull("TicketClass"))
                        traintypelist.TicketClass = Convert.ToInt32(dr["TicketClass"]);

                    if (!dr.IsNull("PickUpFrom"))
                        traintypelist.PickUpFrom = Convert.ToInt32(dr["PickUpFrom"]);

                    if (!dr.IsNull("DropTo"))
                        traintypelist.DropTo = Convert.ToInt32(dr["DropTo"]);

                    if (!dr.IsNull("DepartureDate"))
                        traintypelist.DepartureDate = Convert.ToDateTime(dr["DepartureDate"]);

                    if (!dr.IsNull("ArrivalDate"))
                        traintypelist.ReturnDate = Convert.ToDateTime(dr["ArrivalDate"]);

                    traintypedetails.Add(traintypelist);
                }
            }

            return traintypedetails;
        }

        public List<EnquiryItemTypeDetailsInfo> GetTrainTypeDetailsById(int enquiryItemId)
        {
            List<EnquiryItemTypeDetailsInfo> traintypedetails = new List<EnquiryItemTypeDetailsInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@EnquiryItemId", enquiryItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetTrainTypeDetailsById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    EnquiryItemTypeDetailsInfo traintypelist = new EnquiryItemTypeDetailsInfo();

                    if (!dr.IsNull("EnquiryItemTypeDetailsId"))
                        traintypelist.EnquiryItemTypeDetailsId = Convert.ToInt32(dr["EnquiryItemTypeDetailsId"]);

                    if (!dr.IsNull("EnquiryItemId"))
                        traintypelist.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

                    if (!dr.IsNull("EnquiryId"))
                        traintypelist.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

                    if (!dr.IsNull("TicketClass"))
                        traintypelist.TicketClass = Convert.ToInt32(dr["TicketClass"]);

                    if (!dr.IsNull("PickUpFrom"))
                        traintypelist.PickUpFrom = Convert.ToInt32(dr["PickUpFrom"]);

                    if (!dr.IsNull("DropTo"))
                        traintypelist.DropTo = Convert.ToInt32(dr["DropTo"]);

                    if (!dr.IsNull("DepartureDate"))
                        traintypelist.DepartureDate = Convert.ToDateTime(dr["DepartureDate"]);

                    if (!dr.IsNull("ArrivalDate"))
                        traintypelist.ReturnDate = Convert.ToDateTime(dr["ArrivalDate"]);

                    traintypedetails.Add(traintypelist);
                }
            }

            return traintypedetails;
        }

        public List<EnquiryItemPassDetailsInfo> GetTrainPassDetails(int enquiryId)
        {
            List<EnquiryItemPassDetailsInfo> trainpassdetails = new List<EnquiryItemPassDetailsInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@EnquiryId", enquiryId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetTrainPassDetails.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    EnquiryItemPassDetailsInfo trainpasslist = new EnquiryItemPassDetailsInfo();

                    if (!dr.IsNull("EnquiryItemPassDetailsId"))
                        trainpasslist.EnquiryItemPassDetailsId = Convert.ToInt32(dr["EnquiryItemPassDetailsId"]);

                    if (!dr.IsNull("EnquiryItemId"))
                        trainpasslist.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

                    if (!dr.IsNull("EnquiryId"))
                        trainpasslist.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

                    if (!dr.IsNull("Region"))
                        trainpasslist.Region = Convert.ToInt32(dr["Region"]);

                    if (!dr.IsNull("PassType"))
                        trainpasslist.PassType = Convert.ToInt32(dr["PassType"]);

                    if (!dr.IsNull("RailClass"))
                        trainpasslist.RailClass = Convert.ToInt32(dr["RailClass"]);

                    if (!dr.IsNull("RailPass"))
                        trainpasslist.RailPass = Convert.ToInt32(dr["RailPass"]);

                    if (!dr.IsNull("NoOfDays"))
                        trainpasslist.NoOfDays = Convert.ToInt32(dr["NoOfDays"]);

                    trainpassdetails.Add(trainpasslist);
                }
            }

            return trainpassdetails;
        }

        public List<EnquiryItemPassDetailsInfo> GetTrainPassDetailsById(int enquiryItemId)
        {
            List<EnquiryItemPassDetailsInfo> trainpassdetails = new List<EnquiryItemPassDetailsInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@EnquiryItemId", enquiryItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetTrainPassDetailsById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    EnquiryItemPassDetailsInfo trainpasslist = new EnquiryItemPassDetailsInfo();

                    if (!dr.IsNull("EnquiryItemPassDetailsId"))
                        trainpasslist.EnquiryItemPassDetailsId = Convert.ToInt32(dr["EnquiryItemPassDetailsId"]);

                    if (!dr.IsNull("EnquiryItemId"))
                        trainpasslist.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

                    if (!dr.IsNull("EnquiryId"))
                        trainpasslist.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

                    if (!dr.IsNull("Region"))
                        trainpasslist.Region = Convert.ToInt32(dr["Region"]);

                    if (!dr.IsNull("PassType"))
                        trainpasslist.PassType = Convert.ToInt32(dr["PassType"]);

                    if (!dr.IsNull("RailClass"))
                        trainpasslist.RailClass = Convert.ToInt32(dr["RailClass"]);

                    if (!dr.IsNull("RailPass"))
                        trainpasslist.RailPass = Convert.ToInt32(dr["RailPass"]);

                    if (!dr.IsNull("NoOfDays"))
                        trainpasslist.NoOfDays = Convert.ToInt32(dr["NoOfDays"]);

                    trainpassdetails.Add(trainpasslist);
                }
            }

            return trainpassdetails;
        }

        #endregion


        public void InsertTask(EnquiryInfo enquiryitem)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@EnquaryId", enquiryitem.EnquiryId));

            sqlParams.Add(new SqlParameter("@TaskType", (int)TaskType.Enquiry));

            sqlParams.Add(new SqlParameter("@CreatedBy", enquiryitem.CreatedBy));

            sqlParams.Add(new SqlParameter("@CreatedDate", enquiryitem.CreatedDate));

            sqlParams.Add(new SqlParameter("@UpdatedBy", enquiryitem.UpdatedBy));

            sqlParams.Add(new SqlParameter("@UpdatedDate", enquiryitem.UpdatedDate));

            _sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.spInsertEnquiryTask.ToString(), CommandType.StoredProcedure);
        }


        public List<CityInfo> drpGetcity()
        {
            List<CityInfo> city = new List<CityInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetGitCity.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    city.Add(GetcityValues(dr));
                }
            }
            return city;
        }


        public CityInfo GetcityValues(DataRow dr)
        {
            CityInfo retVal = new CityInfo();

            retVal.CityId = Convert.ToInt32(dr["CityId"]);

            retVal.CityName = Convert.ToString(dr["CityName"]);

            return retVal;
        }

    }
}
