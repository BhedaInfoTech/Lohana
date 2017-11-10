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
using LohanaBusinessEntities.Quotation;
using LohanaBusinessEntities.Enquiry;
using LohanaBusinessEntities;

namespace LohanaRepo.Quotation
{
    public class QuotationRepo
    {
        SQLHelperRepo _sqlHelper = null;

        public QuotationRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        #region QuotationBasic

        public int InsertQuotationBasic(QuotationInfo quotation)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInQuotationBasic(quotation), Storeprocedures.spInsertQuotation.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInQuotationBasic(QuotationInfo quotation)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (quotation.QuotationId != 0)
            {
                sqlParam.Add(new SqlParameter("@QuotationId", quotation.QuotationId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", quotation.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", quotation.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@EnquiryId", quotation.EnquiryId));

            Logger.Debug("Quotation Controller EnquiryId:" + quotation.EnquiryId);

            sqlParam.Add(new SqlParameter("@UpdatedDate", quotation.UpdatedDate));

            sqlParam.Add(new SqlParameter("@UpdatedBy", quotation.UpdatedBy));

            return sqlParam;

        }

        public void UpdateQuotationBasic(QuotationInfo quotation)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInQuotationBasic(quotation), Storeprocedures.spUpdateQuotationBasic.ToString(), CommandType.StoredProcedure);
        }

        public void UpdateQuotationItemStatus(QuotationInfo quotation)
        {
            if (quotation.QuotationStatus != 0)
            {
                _sqlHelper.ExecuteNonQuery(SetValuesInQuotationItemStatus(quotation), Storeprocedures.spUpdateQuotationItemStatus.ToString(), CommandType.StoredProcedure); 
            }
        }

        public List<SqlParameter> SetValuesInQuotationItemStatus(QuotationInfo quotation)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (quotation.QuotationItemId != 0)
            {
                sqlParam.Add(new SqlParameter("@QuotationItemId", quotation.QuotationItemId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedDate", quotation.CreatedDate));
                sqlParam.Add(new SqlParameter("@CreatedBy", quotation.CreatedBy));
            }
            sqlParam.Add(new SqlParameter("@QuotationStatus", quotation.QuotationStatus));
            sqlParam.Add(new SqlParameter("@Remark", quotation.Remark));
            sqlParam.Add(new SqlParameter("@QuotationId", quotation.QuotationId));

            //sqlParam.Add(new SqlParameter("@EnquiryId", quotation.EnquiryId));

            sqlParam.Add(new SqlParameter("@UpdatedDate", quotation.UpdatedDate));

            sqlParam.Add(new SqlParameter("@UpdatedBy", quotation.UpdatedBy));

            return sqlParam;
        }

        public List<QuotationInfo> GetApprovedQuotationItem(int quotationId)
        {
            List<QuotationInfo> QuotationList = new List<QuotationInfo>();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            sqlParamList.Add(new SqlParameter("@QuotationId", quotationId));
            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetApprovedQuotationItem.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    QuotationInfo qiItem = new QuotationInfo();
                    //TrainDetail = GetTrainDetailsValues(dr);
                    qiItem.EnquiryType = Convert.ToInt32(dr["EnquiryType"]);
                    qiItem.CustomerEmailId = Convert.ToString(dr["EmailId"]);
                    qiItem.PackageName = Convert.ToString(dr["PackageName"]);
                    qiItem.PackageDuration = Convert.ToString(dr["PackageDuration"]);
                    qiItem.Cost = Convert.ToInt32(dr["Cost"]);
                    qiItem.FromDate = Convert.ToDateTime(dr["FromDate"]);
                    QuotationList.Add(qiItem);
                }
            }
            return QuotationList;
        }

        public void InsertQuotationTask(QuotationInfo quotationInfo)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@TaskReferenceId", quotationInfo.QuotationId));
            sqlParams.Add(new SqlParameter("@TaskType", (int)TaskType.Quotation));
            sqlParams.Add(new SqlParameter("@FollowUpDate", quotationInfo.FollowUpDate));
            sqlParams.Add(new SqlParameter("@AssigneToId", quotationInfo.AssigneeToId));
            sqlParams.Add(new SqlParameter("@CreatedBy", quotationInfo.CreatedBy));
            sqlParams.Add(new SqlParameter("@CreatedDate", quotationInfo.CreatedDate));
            sqlParams.Add(new SqlParameter("@UpdatedBy", quotationInfo.UpdatedBy));
            sqlParams.Add(new SqlParameter("@UpdatedDate", quotationInfo.UpdatedDate));

            _sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.spInsertQuotationTask.ToString(), CommandType.StoredProcedure);
        }

        public void GetQuotationTaskInfo(QuotationInfo quotationInfo)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            sqlParamList.Add(new SqlParameter("@TaskReferenceId", quotationInfo.QuotationId));
            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetQuotationTaskAssignee.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    quotationInfo.FollowUpDate = Convert.ToDateTime(dr["FollowUpDate"]);
                    quotationInfo.AssigneeToId = Convert.ToInt32(dr["AssigneeToId"]);
                }
            }
        }

        #endregion

        #region Common EnquiryItem

        // Common Insert

        public int InsertQuotationItem(QuotationInfo quotationitem)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInQuotationItem(quotationitem), Storeprocedures.spInsertQuotationItem.ToString(), CommandType.StoredProcedure));
        }

        private List<SqlParameter> SetValuesInQuotationItem(QuotationInfo quotationitem)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (quotationitem.QuotationItemId != 0)
            {
                sqlParams.Add(new SqlParameter("@QuotationItemId", quotationitem.QuotationItemId));
            }
            else
            {

                sqlParams.Add(new SqlParameter("@CreatedBy", quotationitem.CreatedBy));

                sqlParams.Add(new SqlParameter("@CreatedDate", quotationitem.CreatedDate));
            }


            sqlParams.Add(new SqlParameter("@QuotationId", quotationitem.QuotationId));

            Logger.Debug("Quotation Controller QuotationId:" + quotationitem.QuotationId);

            sqlParams.Add(new SqlParameter("@EnquiryItemId", quotationitem.EnquiryItemId));

            Logger.Debug("Quotation Controller EnquiryItemId:" + quotationitem.EnquiryItemId);

            sqlParams.Add(new SqlParameter("@EnquiryType", quotationitem.EnquiryType));

            Logger.Debug("Quotation Controller EnquiryType:" + quotationitem.EnquiryType);

            sqlParams.Add(new SqlParameter("@CategoryId", quotationitem.CategoryId));

            Logger.Debug("Quotation Controller CategoryId:" + quotationitem.CategoryId);

            sqlParams.Add(new SqlParameter("@PackageTypeId", quotationitem.PackageType));

            Logger.Debug("Quotation Controller PackageType:" + quotationitem.PackageType);

            sqlParams.Add(new SqlParameter("@PackageName", quotationitem.PackageName));

            Logger.Debug("Quotation Controller PackageName:" + quotationitem.PackageName);

            sqlParams.Add(new SqlParameter("@PackageDuration", quotationitem.PackageDuration));

            Logger.Debug("Quotation Controller PackageDuration:" + quotationitem.PackageDuration);

            sqlParams.Add(new SqlParameter("@Month", quotationitem.Month));

            Logger.Debug("Quotation Controller Month:" + quotationitem.Month);

            sqlParams.Add(new SqlParameter("@Year", quotationitem.Year));

            Logger.Debug("Quotation Controller Year:" + quotationitem.Year);

            sqlParams.Add(new SqlParameter("@AdultCount", quotationitem.AdultCount));

            Logger.Debug("Quotation Controller AdultCount:" + quotationitem.AdultCount);

            sqlParams.Add(new SqlParameter("@ChildCount", quotationitem.ChildCount));

            Logger.Debug("Quotation Controller ChildCount:" + quotationitem.ChildCount);

            sqlParams.Add(new SqlParameter("@RoomCount", quotationitem.RoomCount));

            Logger.Debug("Quotation Controller RoomCount:" + quotationitem.RoomCount);

            sqlParams.Add(new SqlParameter("@RoomType", quotationitem.RoomType));

            Logger.Debug("Quotation Controller RoomType:" + quotationitem.RoomType);

            sqlParams.Add(new SqlParameter("@CXBCount", quotationitem.CXBCount));

            Logger.Debug("Quotation Controller CXBCount:" + quotationitem.CXBCount);

            sqlParams.Add(new SqlParameter("@CXBAge", quotationitem.CXBAge));

            Logger.Debug("Quotation Controller CXBAge:" + quotationitem.CXBAge);

            sqlParams.Add(new SqlParameter("@CNBCount", quotationitem.CNBCount));

            Logger.Debug("Quotation Controller CNBCount:" + quotationitem.CNBCount);

            sqlParams.Add(new SqlParameter("@CNBAge", quotationitem.CNBAge));

            Logger.Debug("Quotation Controller CNBAge:" + quotationitem.CNBAge);

            sqlParams.Add(new SqlParameter("@Cost", quotationitem.Cost));

            Logger.Debug("Quotation Controller Cost:" + quotationitem.Cost);

            sqlParams.Add(new SqlParameter("@FinalCost", quotationitem.FinalCost));

            Logger.Debug("Quotation Controller FinalCost:" + quotationitem.FinalCost);

            //sqlParams.Add(new SqlParameter("@QuoteRate", quotationitem.QuoteRate));

            //Logger.Debug("Quotation Controller QuoteRate:" + quotationitem.QuoteRate);

            //sqlParams.Add(new SqlParameter("@Location", quotationitem.Location));

            //Logger.Debug("Quotation Controller Location:" + quotationitem.Location);

            //sqlParams.Add(new SqlParameter("@countryId", quotationitem.countryId));

            //Logger.Debug("Quotation Controller countryId:" + quotationitem.countryId);

            //sqlParams.Add(new SqlParameter("@stateId", quotationitem.stateId));

            //Logger.Debug("Quotation Controller Location:" + quotationitem.stateId);

            sqlParams.Add(new SqlParameter("@cityid", quotationitem.Cityid));

            Logger.Debug("Quotation Controller cityid:" + quotationitem.Cityid);

            //sqlParams.Add(new SqlParameter("@HotelType", quotationitem.HotelTypeId));

            //Logger.Debug("Quotation Controller HotelType:" + quotationitem.HotelTypeId);

            //sqlParams.Add(new SqlParameter("@StarCategory", quotationitem.StarCategory));

            //Logger.Debug("Quotation Controller StarCategory:" + quotationitem.StarCategory);


            //sqlParams.Add(new SqlParameter("@QuoteRate", quotationitem.QuoteRate));

            //Logger.Debug("Quotation Controller QuoteRate:" + quotationitem.QuoteRate);

            if (quotationitem.FromDate == DateTime.MinValue)
            {
                DateTime? someDate = null;

                sqlParams.Add(new SqlParameter("@FromDate", someDate));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@FromDate", quotationitem.FromDate));

                Logger.Debug("Quotation Controller FromDate:" + quotationitem.FromDate);
            }

            if (quotationitem.ToDate == DateTime.MinValue)
            {
                DateTime? someDate = null;

                sqlParams.Add(new SqlParameter("@ToDate", someDate));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@ToDate", quotationitem.ToDate));

                Logger.Debug("Quotation Controller ToDate:" + quotationitem.ToDate);
            }

            if (quotationitem.CheckInDate == DateTime.MinValue)
            {
                DateTime? someDate = null;

                sqlParams.Add(new SqlParameter("@CheckInDate", someDate));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@CheckInDate", quotationitem.CheckInDate));

                Logger.Debug("Quotation Controller CheckInDate:" + quotationitem.CheckInDate);
            }

            if (quotationitem.CheckOutDate == DateTime.MinValue)
            {
                DateTime? someDate = null;

                sqlParams.Add(new SqlParameter("@CheckOutDate", someDate));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@CheckOutDate", quotationitem.CheckOutDate));

                Logger.Debug("Quotation Controller CheckOutDate:" + quotationitem.CheckOutDate);
            }

            sqlParams.Add(new SqlParameter("@HotelId", quotationitem.HotelId));

            Logger.Debug("Quotation Controller HotelId:" + quotationitem.HotelId);

            sqlParams.Add(new SqlParameter("@QuotationFlightType", quotationitem.QuotationFlightType));

            Logger.Debug("Quotation Controller QuotationFlightType:" + quotationitem.QuotationFlightType);

            sqlParams.Add(new SqlParameter("@InfantCount", quotationitem.InfantCount));

            Logger.Debug("Quotation Controller InfantCount:" + quotationitem.InfantCount);

            sqlParams.Add(new SqlParameter("@QuotationTrainType", quotationitem.QuotationTrainType));

            Logger.Debug("Quotation Controller QuotationTrainType:" + quotationitem.QuotationTrainType);

            sqlParams.Add(new SqlParameter("@QuotationVehicleType", quotationitem.QuotationVehicleType));

            Logger.Debug("Quotation Controller QuotationVehicleType:" + quotationitem.QuotationVehicleType);

            sqlParams.Add(new SqlParameter("@Currency", quotationitem.Currency));

            Logger.Debug("Quotation Controller Currency:" + quotationitem.Currency);

            sqlParams.Add(new SqlParameter("@SightSeeingId", quotationitem.SightSeeingId));

            Logger.Debug("Quotation Controller SightSeeingId:" + quotationitem.SightSeeingId);

            if (quotationitem.TravelDate == DateTime.MinValue)
            {
                DateTime? someDate = null;

                sqlParams.Add(new SqlParameter("@TravelDate", someDate));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@TravelDate", quotationitem.TravelDate));

                Logger.Debug("Quotation Controller TravelDate:" + quotationitem.TravelDate);
            }

            sqlParams.Add(new SqlParameter("@VehicleType", quotationitem.VehicleType));

            Logger.Debug("Quotation Controller VehicleType:" + quotationitem.VehicleType);

            sqlParams.Add(new SqlParameter("@QuotationStatus", 1));

            Logger.Debug("Quotation Controller QuotationStatus:" + quotationitem.QuotationStatus);

            //sqlParams.Add(new SqlParameter("@CountryId", quotationitem.countryId));

            //Logger.Debug("Quotation Controller CountryId:" + quotationitem.countryId);

            //sqlParams.Add(new SqlParameter("@StateId", quotationitem.stateId));

            //Logger.Debug("Quotation Controller StateId:" + quotationitem.stateId);

            //sqlParams.Add(new SqlParameter("@Cityid", quotationitem.cityid));

            //Logger.Debug("Quotation Controller Cityid:" + quotationitem.cityid);

            sqlParams.Add(new SqlParameter("@UpdatedBy", quotationitem.UpdatedBy));

            Logger.Debug("Quotation Controller UpdatedBy:" + quotationitem.UpdatedBy);

            sqlParams.Add(new SqlParameter("@UpdatedDate", quotationitem.UpdatedDate));

            Logger.Debug("Quotation Controller UpdatedDate:" + quotationitem.UpdatedDate);

            //sqlParams.Add(new SqlParameter("@QuotationStatus", 1));

            return sqlParams;

        }


        // Common Get

        public List<QuotationInfo> GetQuotationItemDetails(int quotationId)
        {

            List<QuotationInfo> QuotationItemDetails = new List<QuotationInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@QuotationId", quotationId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetQuotationItemDetails.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                QuotationItemDetails.Add(GetQuotationItemDetails(dr));
            }

            return QuotationItemDetails;
        }

        private QuotationInfo GetQuotationItemDetails(DataRow dr)
        {
            QuotationInfo QuotationItem = new QuotationInfo();

            QuotationItem.QuotationItemId = Convert.ToInt32(dr["QuotationItemId"]);

            if (!dr.IsNull("QuotationId"))
                QuotationItem.QuotationId = Convert.ToInt32(dr["QuotationId"]);

            if (!dr.IsNull("EnquiryType"))
                QuotationItem.EnquiryType = Convert.ToInt32(dr["EnquiryType"]);

            if (!dr.IsNull("EnquiryItemId"))
                QuotationItem.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

            //if (!dr.IsNull("CategoryId"))
                //QuotationItem.CategoryId = Convert.ToInt32(dr["CategoryId"]);

            //if (!dr.IsNull("CategoryName"))
                //QuotationItem.CategoryName = Convert.ToString(dr["CategoryName"]);

            if (!dr.IsNull("PackageTypeId"))
                QuotationItem.PackageType = Convert.ToInt32(dr["PackageTypeId"]);

            if (!dr.IsNull("PackageTypeName"))
                QuotationItem.PackageTypeName = Convert.ToString(dr["PackageTypeName"]);

    

            if (!dr.IsNull("PackageName"))
                QuotationItem.PackageName = Convert.ToString(dr["PackageName"]);

            //if (!dr.IsNull("NoOfNights"))
            //    QuotationItem.NoOfnight = Convert.ToInt32(dr["NoOfNights"]);


            if (!dr.IsNull("PackageDuration"))
                QuotationItem.PackageDuration = Convert.ToString(dr["PackageDuration"]);

            if (!dr.IsNull("Month"))
                QuotationItem.Month = Convert.ToInt32(dr["Month"]);

            if (!dr.IsNull("Year"))
                QuotationItem.Year = Convert.ToInt32(dr["Year"]);

            if (!dr.IsNull("AdultCount"))
                QuotationItem.AdultCount = Convert.ToInt32(dr["AdultCount"]);

            if (!dr.IsNull("ChildCount"))
                QuotationItem.ChildCount = Convert.ToInt32(dr["ChildCount"]);

            if (!dr.IsNull("Cost"))
                QuotationItem.Cost = Convert.ToInt32(dr["Cost"]);

            //if (!dr.IsNull("Location"))
                //QuotationItem.Location = Convert.ToInt32(dr["Location"]);

            if (!dr.IsNull("CityName"))
                QuotationItem.CityName = Convert.ToString(dr["CityName"]);

            //if (!dr.IsNull("HotelType"))
                //QuotationItem.HotelTypeId = Convert.ToInt32(dr["HotelType"]);

            if (!dr.IsNull("StarCategory"))
                QuotationItem.StarCategory = Convert.ToInt32(dr["StarCategory"]);

            if (!dr.IsNull("StarCategoryStr"))
                QuotationItem.StarCategoryStr = Convert.ToString(dr["StarCategoryStr"]);

            if (!dr.IsNull("RoomType"))
                QuotationItem.RoomType = Convert.ToInt32(dr["RoomType"]);

            if (!dr.IsNull("RoomTypeName"))
                QuotationItem.RoomTypeName = Convert.ToString(dr["RoomTypeName"]);

            if (!dr.IsNull("FromDate"))
                QuotationItem.FromDate = Convert.ToDateTime(dr["FromDate"]);

            if (!dr.IsNull("ToDate"))
                QuotationItem.ToDate = Convert.ToDateTime(dr["ToDate"]);

            if (!dr.IsNull("RoomCount"))
                QuotationItem.RoomCount = Convert.ToInt32(dr["RoomCount"]);

            if (!dr.IsNull("CXBCount"))
                QuotationItem.CXBCount = Convert.ToInt32(dr["CXBCount"]);

            if (!dr.IsNull("CXBAge"))
                QuotationItem.CXBAge = Convert.ToString(dr["CXBAge"]);

            if (!dr.IsNull("CNBCount"))
                QuotationItem.CNBCount = Convert.ToInt32(dr["CNBCount"]);

            if (!dr.IsNull("CNBAge"))
                QuotationItem.CNBAge = Convert.ToString(dr["CNBAge"]);

            if (!dr.IsNull("CheckInDate"))
                QuotationItem.CheckInDate = Convert.ToDateTime(dr["CheckInDate"]);

            if (!dr.IsNull("CheckOutDate"))
                QuotationItem.CheckOutDate = Convert.ToDateTime(dr["CheckOutDate"]);

            if (!dr.IsNull("HotelType"))
                QuotationItem.HotelTypeId = Convert.ToInt32(dr["HotelType"]);

            if (!dr.IsNull("HotelTypeName"))
                QuotationItem.HotelTypeName = Convert.ToString(dr["HotelTypeName"]);

            if (!dr.IsNull("HotelName"))
                QuotationItem.HotelName = Convert.ToString(dr["HotelName"]);

            if (!dr.IsNull("SightseeingName"))
                QuotationItem.SightseeingName = Convert.ToString(dr["SightseeingName"]);

            if (!dr.IsNull("TravelDate"))
                QuotationItem.TravelDate = Convert.ToDateTime(dr["TravelDate"]);

            if (!dr.IsNull("VehicleType"))
                QuotationItem.VehicleType = Convert.ToInt32(dr["VehicleType"]);

            if (!dr.IsNull("VehicleTypeName"))
                QuotationItem.VehicleTypeName = Convert.ToString(dr["VehicleTypeName"]);

            if (!dr.IsNull("QuotationFlightType"))
                QuotationItem.QuotationFlightType = Convert.ToInt32(dr["QuotationFlightType"]);

            if (!dr.IsNull("Currency"))
                QuotationItem.Currency = Convert.ToInt32(dr["Currency"]);

            if (!dr.IsNull("CurrencyName"))
                QuotationItem.CurrencyName = Convert.ToString(dr["CurrencyName"]);

            if (!dr.IsNull("QuotationTrainType"))
                QuotationItem.QuotationTrainType = Convert.ToInt32(dr["QuotationTrainType"]);

            if (!dr.IsNull("InfantCount"))
                QuotationItem.InfantCount = Convert.ToInt32(dr["InfantCount"]);

            if (!dr.IsNull("QuotationStatus"))
                QuotationItem.QuotationStatus = Convert.ToInt32(dr["QuotationStatus"]);

            if (!dr.IsNull("Remark"))
                QuotationItem.Remark = Convert.ToString(dr["Remark"]);

            if (!dr.IsNull("CountryId"))
                QuotationItem.countryId = Convert.ToInt32(dr["CountryId"]);

            if (!dr.IsNull("StateId"))
                QuotationItem.stateId = Convert.ToInt32(dr["StateId"]);

            if (!dr.IsNull("Cityid"))
                QuotationItem.Cityid = Convert.ToInt32(dr["Cityid"]);

            //if (!dr.IsNull("UserName"))
            //    QuotationItem.UserName = Convert.ToString(dr["UserName"]);

            if (!dr.IsNull("CreatedBy"))
                QuotationItem.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            if (!dr.IsNull("CreatedDate"))
                QuotationItem.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);

            if (!dr.IsNull("UpdatedBy"))
                QuotationItem.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            if (!dr.IsNull("UpdatedDate"))
                QuotationItem.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);

           // QuotationItem.QuotationItemTypeDetails = GetQuotationItemTypeDetails(QuotationItem.QuotationId, QuotationItem.QuotationItemId);

            return QuotationItem;

        }

        public List<QuotationItemTypeDetailsInfo> GetQuotationItemTypeDetails(int quotationId, int quotationItemId)
        {
            List<QuotationItemTypeDetailsInfo> quotationitemtypedetails = new List<QuotationItemTypeDetailsInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@QuotationId", quotationId));

            sqlParamList.Add(new SqlParameter("@QuotationItemId", quotationItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetQuotationItemTypeDetails.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    QuotationItemTypeDetailsInfo quotationitemtypelist = new QuotationItemTypeDetailsInfo();

                    if (!dr.IsNull("QuotationItemTypeDetailsId"))
                        quotationitemtypelist.QuotationItemTypeDetailsId = Convert.ToInt32(dr["QuotationItemTypeDetailsId"]);

                    if (!dr.IsNull("QuotationItemId"))
                        quotationitemtypelist.QuotationItemId = Convert.ToInt32(dr["QuotationItemId"]);

                    if (!dr.IsNull("QuotationId"))
                        quotationitemtypelist.QuotationId = Convert.ToInt32(dr["QuotationId"]);

                    if (!dr.IsNull("TicketClass"))
                        quotationitemtypelist.TicketClass = Convert.ToInt32(dr["TicketClass"]);

                    if (!dr.IsNull("TicketClassName"))
                        quotationitemtypelist.TicketClassName = Convert.ToString(dr["TicketClassName"]);

                    if (!dr.IsNull("PickUpFrom"))
                        quotationitemtypelist.PickUpFrom = Convert.ToInt32(dr["PickUpFrom"]);

                    if (!dr.IsNull("PickUpFromName"))
                        quotationitemtypelist.PickUpFromName = Convert.ToString(dr["PickUpFromName"]);

                    if (!dr.IsNull("DropTo"))
                        quotationitemtypelist.DropTo = Convert.ToInt32(dr["DropTo"]);

                    if (!dr.IsNull("DropToName"))
                        quotationitemtypelist.DropToName = Convert.ToString(dr["DropToName"]);

                    if (!dr.IsNull("DepartureDate"))
                        quotationitemtypelist.DepartureDate = Convert.ToDateTime(dr["DepartureDate"]);

                    if (!dr.IsNull("ArrivalDate"))
                        quotationitemtypelist.ReturnDate = Convert.ToDateTime(dr["ArrivalDate"]);

                    if (!dr.IsNull("QuoteRate"))
                        quotationitemtypelist.QuoteRate = Convert.ToInt32(dr["QuoteRate"]);

                    quotationitemtypedetails.Add(quotationitemtypelist);
                }
            }

            return quotationitemtypedetails;
        }


        #endregion

        #region Flight Enquiry Item

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

        public int InsertFlightQuotationItem(QuotationInfo quotationitem)
        {
            quotationitem.QuotationItemId = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInQuotationItem(quotationitem), Storeprocedures.spInsertQuotationItem.ToString(), CommandType.StoredProcedure));

            InsertQuotationItemTypeDetail(quotationitem);

            return quotationitem.QuotationItemId;
        }

        public void InsertQuotationItemTypeDetail(QuotationInfo quotationitem)
        {
            foreach (var item in quotationitem.QuotationItemTypeDetails)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@QuotationItemId", quotationitem.QuotationItemId));

                sqlParams.Add(new SqlParameter("@QuotationId", 1));

                sqlParams.Add(new SqlParameter("@TicketClass", item.TicketClass));

                sqlParams.Add(new SqlParameter("@PickUpFrom", item.PickUpFrom));

                sqlParams.Add(new SqlParameter("@DropTo", item.DropTo));

                sqlParams.Add(new SqlParameter("@QuoteRate", item.QuoteRate));

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


                sqlParams.Add(new SqlParameter("@UpdatedBy", quotationitem.UpdatedBy));

                sqlParams.Add(new SqlParameter("@UpdatedDate", quotationitem.UpdatedDate));

                if (item.QuotationItemTypeDetailsId != 0)
                {
                    sqlParams.Add(new SqlParameter("@QuotationItemTypeDetailsId", item.QuotationItemTypeDetailsId));

                    _sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.spUpdateQuotationItemTypeDetails.ToString(), CommandType.StoredProcedure);
                }
                else
                {
                    sqlParams.Add(new SqlParameter("@CreatedBy", quotationitem.CreatedBy));

                    sqlParams.Add(new SqlParameter("@CreatedDate", quotationitem.CreatedDate));

                    _sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.spInsertQuotationItemTypeDetails.ToString(), CommandType.StoredProcedure);
                }

            }
        }

        public void DeleteQuotationItemType(int quotationItemId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            QuotationItemTypeDetailsInfo FlightQuotationTypeDetail = new QuotationItemTypeDetailsInfo();

            sqlParam.Add(new SqlParameter("QuotationItemId", quotationItemId));

            Logger.Debug("Quotation Controller DeleteQuotationItemType:" + quotationItemId);

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeletetQuotationItemTypeByQuotationItemId.ToString(), CommandType.StoredProcedure);

        }

        public void UpdateQuotationFlightDetails(QuotationInfo quotationitem)
        {

            List<SqlParameter> Sqlparamaters = new List<SqlParameter>();

            Sqlparamaters.Add(new SqlParameter("@QuotationItemId", quotationitem.QuotationItemId));

            _sqlHelper.ExecuteNonQuery(SetValuesInQuotationItem(quotationitem), Storeprocedures.spUpdateFlightQuotationItem.ToString(), CommandType.StoredProcedure);

            //DeleteQuotationItemType(quotationitem.QuotationItemId);

            InsertQuotationItemTypeDetail(quotationitem);

        }

        public List<QuotationInfo> GetQuotationFlightDetailsByQuotationId(int quotationId)
        {

            List<QuotationInfo> FlightDetails = new List<QuotationInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@QuotationId", quotationId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetQuotationFlightDetailsByQuotationId.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    FlightDetails.Add(GetQuotationFlightDetailsValues(dr));
                }
            }

            return FlightDetails;
        }

        public QuotationInfo GetQuotationFlightDetailsById(int quotationItemId)
        {

            QuotationInfo FlightDetail = new QuotationInfo();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@QuotationItemId", quotationItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetQuotationFlightDetailsById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    FlightDetail = GetQuotationFlightDetailsValues(dr);
                }
            }

            return FlightDetail;
        }

        private QuotationInfo GetQuotationFlightDetailsValues(DataRow dr)
        {
            QuotationInfo Flight = new QuotationInfo();

            Flight.QuotationItemId = Convert.ToInt32(dr["QuotationItemId"]);

            if (!dr.IsNull("QuotationId"))
                Flight.QuotationId = Convert.ToInt32(dr["QuotationId"]);

            if (!dr.IsNull("QuotationStatus"))
                Flight.QuotationStatus = Convert.ToInt32(dr["QuotationStatus"]);

            if (!dr.IsNull("EnquiryType"))
                Flight.EnquiryType = Convert.ToInt32(dr["EnquiryType"]);

            if (!dr.IsNull("EnquiryItemId"))
                Flight.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

            if (!dr.IsNull("QuotationFlightType"))
                Flight.QuotationFlightType = Convert.ToInt32(dr["QuotationFlightType"]);

            if (!dr.IsNull("AdultCount"))
                Flight.AdultCount = Convert.ToInt32(dr["AdultCount"]);

            if (!dr.IsNull("ChildCount"))
                Flight.ChildCount = Convert.ToInt32(dr["ChildCount"]);

            if (!dr.IsNull("InfantCount"))
                Flight.InfantCount = Convert.ToInt32(dr["InfantCount"]);

            if (!dr.IsNull("Cost"))
                Flight.Cost = Convert.ToInt32(dr["Cost"]);

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

        public List<QuotationItemTypeDetailsInfo> GetQuotationFlightTypeDetails(int quotationId)
        {
            List<QuotationItemTypeDetailsInfo> flighttypedetails = new List<QuotationItemTypeDetailsInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@QuotationId", quotationId));

            // sqlParamList.Add(new SqlParameter("@EnquiryType", enquiryType));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetQuotationFlightTypeDetails.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    QuotationItemTypeDetailsInfo flighttypelist = new QuotationItemTypeDetailsInfo();

                    if (!dr.IsNull("QuotationItemTypeDetailsId"))
                        flighttypelist.QuotationItemTypeDetailsId = Convert.ToInt32(dr["QuotationItemTypeDetailsId"]);

                    if (!dr.IsNull("QuotationItemId"))
                        flighttypelist.QuotationItemId = Convert.ToInt32(dr["QuotationItemId"]);

                    if (!dr.IsNull("QuotationId"))
                        flighttypelist.QuotationId = Convert.ToInt32(dr["QuotationId"]);

                    if (!dr.IsNull("QuotationStatus"))
                        flighttypelist.QuotationStatus = Convert.ToInt32(dr["QuotationStatus"]);

                    if (!dr.IsNull("TicketClass"))
                        flighttypelist.TicketClass = Convert.ToInt32(dr["TicketClass"]);

                    if (!dr.IsNull("TicketClassName"))
                        flighttypelist.TicketClassName = Convert.ToString(dr["TicketClassName"]);

                    if (!dr.IsNull("PickUpFrom"))
                        flighttypelist.PickUpFrom = Convert.ToInt32(dr["PickUpFrom"]);

                    if (!dr.IsNull("PickUpFromName"))
                        flighttypelist.PickUpFromName = Convert.ToString(dr["PickUpFromName"]);

                    if (!dr.IsNull("DropTo"))
                        flighttypelist.DropTo = Convert.ToInt32(dr["DropTo"]);

                    if (!dr.IsNull("DropToName"))
                        flighttypelist.DropToName = Convert.ToString(dr["DropToName"]);

                    if (!dr.IsNull("QuoteRate"))
                        flighttypelist.QuoteRate = Convert.ToInt32(dr["QuoteRate"]);

                    if (!dr.IsNull("DepartureDate"))
                        flighttypelist.DepartureDate = Convert.ToDateTime(dr["DepartureDate"]);

                    if (!dr.IsNull("ArrivalDate"))
                        flighttypelist.ReturnDate = Convert.ToDateTime(dr["ArrivalDate"]);

                    flighttypedetails.Add(flighttypelist);
                }
            }

            return flighttypedetails;
        }

        public List<QuotationItemTypeDetailsInfo> GetQuotationFlightTypeDetailsById(int quotationItemId)
        {
            List<QuotationItemTypeDetailsInfo> flighttypedetails = new List<QuotationItemTypeDetailsInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@QuotationItemId", quotationItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetQuotationFlightTypeDetailsById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    QuotationItemTypeDetailsInfo flighttypelist = new QuotationItemTypeDetailsInfo();

                    if (!dr.IsNull("QuotationItemTypeDetailsId"))
                        flighttypelist.QuotationItemTypeDetailsId = Convert.ToInt32(dr["QuotationItemTypeDetailsId"]);

                    if (!dr.IsNull("QuotationItemId"))
                        flighttypelist.QuotationItemId = Convert.ToInt32(dr["QuotationItemId"]);

                    if (!dr.IsNull("QuotationId"))
                        flighttypelist.QuotationId = Convert.ToInt32(dr["QuotationId"]);

                    if (!dr.IsNull("TicketClass"))
                        flighttypelist.TicketClass = Convert.ToInt32(dr["TicketClass"]);

                    if (!dr.IsNull("PickUpFrom"))
                        flighttypelist.PickUpFrom = Convert.ToInt32(dr["PickUpFrom"]);

                    if (!dr.IsNull("QuoteRate"))
                        flighttypelist.QuoteRate = Convert.ToInt32(dr["QuoteRate"]);

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

        #region Train Enquiry Item

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

        public int InsertTrainQuotationItem(QuotationInfo quotationitem)
        {
            quotationitem.QuotationItemId = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInQuotationItem(quotationitem), Storeprocedures.spInsertQuotationItem.ToString(), CommandType.StoredProcedure));

            InsertQuotationItemTypeDetail(quotationitem);

            InsertQuotationItemPassDetail(quotationitem);

            return quotationitem.QuotationItemId;

        }

        public int InsertTrainQuotationItemType(QuotationInfo quotationitem)
        {

            quotationitem.QuotationItemTypeDetail.QuotationItemTypeDetailsId = 0;

            quotationitem.QuotationItemTypeDetail.QuotationItemTypeDetailsId = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInQuotationItemType(quotationitem), Storeprocedures.spInsertQuotationItemTypeDetails.ToString(), CommandType.StoredProcedure));

            return quotationitem.QuotationItemTypeDetail.QuotationItemTypeDetailsId;

        }

        private List<SqlParameter> SetValuesInQuotationItemType(QuotationInfo quotationitem)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (quotationitem.QuotationItemTypeDetail.QuotationItemTypeDetailsId != 0)
            {
                sqlParams.Add(new SqlParameter("@QuotationItemTypeDetailsId", quotationitem.QuotationItemTypeDetail.QuotationItemTypeDetailsId));
            }
            else
            {

                sqlParams.Add(new SqlParameter("@CreatedBy", quotationitem.CreatedBy));

                sqlParams.Add(new SqlParameter("@CreatedDate", quotationitem.CreatedDate));
            }

            sqlParams.Add(new SqlParameter("@QuotationItemId", quotationitem.QuotationItemTypeDetail.QuotationItemId));

            sqlParams.Add(new SqlParameter("@QuotationId", 1));

            sqlParams.Add(new SqlParameter("@TicketClass", quotationitem.QuotationItemTypeDetail.TicketClass));

            sqlParams.Add(new SqlParameter("@PickUpFrom", quotationitem.QuotationItemTypeDetail.PickUpFrom));

            sqlParams.Add(new SqlParameter("@DropTo", quotationitem.QuotationItemTypeDetail.DropTo));

            sqlParams.Add(new SqlParameter("@QuoteRate", quotationitem.QuotationItemTypeDetail.QuoteRate));

            if (quotationitem.QuotationItemTypeDetail.DepartureDate == DateTime.MinValue)
            {
                DateTime? someDate = null;

                sqlParams.Add(new SqlParameter("@DepartureDate", someDate));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@DepartureDate", quotationitem.QuotationItemTypeDetail.DepartureDate));

                Logger.Debug("Enquiry Controller DepartureDate:" + quotationitem.QuotationItemTypeDetail.DepartureDate);
            }

            if (quotationitem.QuotationItemTypeDetail.ReturnDate == DateTime.MinValue)
            {
                DateTime? someDate = null;

                sqlParams.Add(new SqlParameter("@ArrivalDate", someDate));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@ArrivalDate", quotationitem.QuotationItemTypeDetail.ReturnDate));

                Logger.Debug("Enquiry Controller ArrivalDate:" + quotationitem.QuotationItemTypeDetail.ReturnDate);
            }

            sqlParams.Add(new SqlParameter("@UpdatedBy", quotationitem.UpdatedBy));

            sqlParams.Add(new SqlParameter("@UpdatedDate", quotationitem.UpdatedDate));

            return sqlParams;
        }

        public void InsertQuotationItemPassDetail(QuotationInfo quotationitem)
        {
            foreach (var item in quotationitem.QuotationItemPassDetails)
            {

                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@QuotationItemId", quotationitem.QuotationItemId));

                sqlParams.Add(new SqlParameter("@QuotationId", 1));

                sqlParams.Add(new SqlParameter("@Region", item.Region));

                sqlParams.Add(new SqlParameter("@PassType", item.PassType));

                sqlParams.Add(new SqlParameter("@RailClass", item.RailClass));

                sqlParams.Add(new SqlParameter("@RailPass", item.RailPass));

                sqlParams.Add(new SqlParameter("@NoOfDays", item.NoOfDays));

                sqlParams.Add(new SqlParameter("@QuoteRate", item.QuoteRate));

                sqlParams.Add(new SqlParameter("@UpdatedBy", quotationitem.UpdatedBy));

                sqlParams.Add(new SqlParameter("@UpdatedDate", quotationitem.UpdatedDate));

                if (item.QuotationItemPassDetailsId != 0)
                {
                    sqlParams.Add(new SqlParameter("@QuotationItemPassDetailsId", item.QuotationItemPassDetailsId));

                    _sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.spUpdateQuotationItemPassDetails.ToString(), CommandType.StoredProcedure);

                }

                else
                {
                    sqlParams.Add(new SqlParameter("@CreatedBy", quotationitem.CreatedBy));

                    sqlParams.Add(new SqlParameter("@CreatedDate", quotationitem.CreatedDate));

                    _sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.spInsertQuotationItemPassDetails.ToString(), CommandType.StoredProcedure);
                }

            }
        }

        public int InsertTrainQuotationItemPass(QuotationInfo quotationitem)
        {

            quotationitem.QuotationItemPassDetail.QuotationItemPassDetailsId = 0;

            quotationitem.QuotationItemPassDetail.QuotationItemPassDetailsId = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInQuotationItemPass(quotationitem), Storeprocedures.spInsertQuotationItemPassDetails.ToString(), CommandType.StoredProcedure));

            return quotationitem.QuotationItemPassDetail.QuotationItemPassDetailsId;
        }

        private List<SqlParameter> SetValuesInQuotationItemPass(QuotationInfo quotationitem)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (quotationitem.QuotationItemPassDetail.QuotationItemPassDetailsId != 0)
            {
                sqlParams.Add(new SqlParameter("@QuotationItemPassDetailsId", quotationitem.QuotationItemPassDetail.QuotationItemPassDetailsId));
            }
            else
            {

                sqlParams.Add(new SqlParameter("@CreatedBy", quotationitem.CreatedBy));

                sqlParams.Add(new SqlParameter("@CreatedDate", quotationitem.CreatedDate));
            }

            sqlParams.Add(new SqlParameter("@QuotationItemId", quotationitem.QuotationItemPassDetail.QuotationItemId));

            sqlParams.Add(new SqlParameter("@QuotationId", 1));

            sqlParams.Add(new SqlParameter("@Region", quotationitem.QuotationItemPassDetail.Region));

            sqlParams.Add(new SqlParameter("@PassType", quotationitem.QuotationItemPassDetail.PassType));

            sqlParams.Add(new SqlParameter("@RailPass", quotationitem.QuotationItemPassDetail.RailPass));

            sqlParams.Add(new SqlParameter("@RailClass", quotationitem.QuotationItemPassDetail.RailClass));

            sqlParams.Add(new SqlParameter("@NoOfDays", quotationitem.QuotationItemPassDetail.NoOfDays));

            sqlParams.Add(new SqlParameter("@QuoteRate", quotationitem.QuotationItemPassDetail.QuoteRate));


            sqlParams.Add(new SqlParameter("@UpdatedBy", quotationitem.UpdatedBy));

            sqlParams.Add(new SqlParameter("@UpdatedDate", quotationitem.UpdatedDate));

            return sqlParams;
        }

        public void DeleteQuotationItemTrainType(int quotationItemId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            QuotationItemTypeDetailsInfo TrainQuotationTypeDetail = new QuotationItemTypeDetailsInfo();

            sqlParam.Add(new SqlParameter("QuotationItemId", quotationItemId));

            Logger.Debug("Quotation Controller DeleteQuotationItemType:" + quotationItemId);

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeletetQuotationItemTypeByQuotationItemId.ToString(), CommandType.StoredProcedure);

        }

        public void UpdateQuotationTrainDetails(QuotationInfo quotationitem)
        {

            List<SqlParameter> Sqlparamaters = new List<SqlParameter>();

            Sqlparamaters.Add(new SqlParameter("@QuotationItemId", quotationitem.QuotationItemId));

            _sqlHelper.ExecuteNonQuery(SetValuesInQuotationItem(quotationitem), Storeprocedures.spUpdateTrainQuotationItem.ToString(), CommandType.StoredProcedure);

            InsertQuotationItemTypeDetail(quotationitem);

            InsertQuotationItemPassDetail(quotationitem);

        }



        public List<QuotationInfo> GetQuotationTrainDetailsByQuotationId(int quotationId)
        {

            List<QuotationInfo> TrainDetails = new List<QuotationInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@QuotationId", quotationId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetQuotationTrainDetailsByQuotationId.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TrainDetails.Add(GetQuotationTrainDetailsValues(dr));
                }
            }

            return TrainDetails;
        }

        public QuotationInfo GetQuotationTrainDetailsById(int quotationItemId)
        {

            QuotationInfo TrainDetail = new QuotationInfo();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@QuotationItemId", quotationItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetQuotationTrainDetailsById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TrainDetail = GetQuotationTrainDetailsValues(dr);
                }
            }

            return TrainDetail;
        }

        private QuotationInfo GetQuotationTrainDetailsValues(DataRow dr)
        {
            QuotationInfo Train = new QuotationInfo();

            Train.QuotationItemId = Convert.ToInt32(dr["QuotationItemId"]);

            if (!dr.IsNull("QuotationId"))
                Train.QuotationId = Convert.ToInt32(dr["QuotationId"]);

            if (!dr.IsNull("QuotationStatus"))
                Train.QuotationStatus = Convert.ToInt32(dr["QuotationStatus"]);

            if (!dr.IsNull("EnquiryType"))
                Train.EnquiryType = Convert.ToInt32(dr["EnquiryType"]);

            if (!dr.IsNull("EnquiryItemId"))
                Train.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

            if (!dr.IsNull("QuotationTrainType"))
                Train.QuotationTrainType = Convert.ToInt32(dr["QuotationTrainType"]);

            if (!dr.IsNull("AdultCount"))
                Train.AdultCount = Convert.ToInt32(dr["AdultCount"]);

            if (!dr.IsNull("ChildCount"))
                Train.ChildCount = Convert.ToInt32(dr["ChildCount"]);

            if (!dr.IsNull("InfantCount"))
                Train.InfantCount = Convert.ToInt32(dr["InfantCount"]);

            if (!dr.IsNull("Cost"))
                Train.Cost = Convert.ToInt32(dr["Cost"]);

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



        public List<QuotationItemTypeDetailsInfo> GetQuotationTrainTypeDetails(int quotationId)
        {
            List<QuotationItemTypeDetailsInfo> traintypedetails = new List<QuotationItemTypeDetailsInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@QuotationId", quotationId));

            // sqlParamList.Add(new SqlParameter("@EnquiryType", enquiryType));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetQuotationTrainTypeDetails.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    QuotationItemTypeDetailsInfo traintypelist = new QuotationItemTypeDetailsInfo();

                    if (!dr.IsNull("QuotationItemTypeDetailsId"))
                        traintypelist.QuotationItemTypeDetailsId = Convert.ToInt32(dr["QuotationItemTypeDetailsId"]);

                    if (!dr.IsNull("QuotationItemId"))
                        traintypelist.QuotationItemId = Convert.ToInt32(dr["QuotationItemId"]);

                    if (!dr.IsNull("QuotationId"))
                        traintypelist.QuotationId = Convert.ToInt32(dr["QuotationId"]);

                    if (!dr.IsNull("QuotationStatus"))
                        traintypelist.QuotationStatus = Convert.ToInt32(dr["QuotationStatus"]);

                    if (!dr.IsNull("TicketClass"))
                        traintypelist.TicketClass = Convert.ToInt32(dr["TicketClass"]);

                    if (!dr.IsNull("TicketClassName"))
                        traintypelist.TicketClassName = Convert.ToString(dr["TicketClassName"]);

                    if (!dr.IsNull("PickUpFrom"))
                        traintypelist.PickUpFrom = Convert.ToInt32(dr["PickUpFrom"]);

                    if (!dr.IsNull("PickUpFromName"))
                        traintypelist.PickUpFromName = Convert.ToString(dr["PickUpFromName"]);

                    if (!dr.IsNull("DropTo"))
                        traintypelist.DropTo = Convert.ToInt32(dr["DropTo"]);

                    if (!dr.IsNull("DropToName"))
                        traintypelist.DropToName = Convert.ToString(dr["DropToName"]);

                    if (!dr.IsNull("QuoteRate"))
                        traintypelist.QuoteRate = Convert.ToInt32(dr["QuoteRate"]);

                    if (!dr.IsNull("DepartureDate"))
                        traintypelist.DepartureDate = Convert.ToDateTime(dr["DepartureDate"]);

                    if (!dr.IsNull("ArrivalDate"))
                        traintypelist.ReturnDate = Convert.ToDateTime(dr["ArrivalDate"]);

                    traintypedetails.Add(traintypelist);
                }
            }

            return traintypedetails;
        }

        public QuotationItemTypeDetailsInfo GetQuotationTrainTypeDetailsById(int quotationItemId)
        {

            QuotationItemTypeDetailsInfo TrainTypeDetail = new QuotationItemTypeDetailsInfo();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@QuotationItemId", quotationItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetQuotationTrainTypeDetailsById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TrainTypeDetail = GetQuotationTrainTypeDetailsValues(dr);
                }
            }

            return TrainTypeDetail;
        }

        private QuotationItemTypeDetailsInfo GetQuotationTrainTypeDetailsValues(DataRow dr)
        {
            QuotationItemTypeDetailsInfo TrainType = new QuotationItemTypeDetailsInfo();

            if (!dr.IsNull("QuotationItemTypeDetailsId"))
                TrainType.QuotationItemTypeDetailsId = Convert.ToInt32(dr["QuotationItemTypeDetailsId"]);

            if (!dr.IsNull("QuotationItemId"))
                TrainType.QuotationItemId = Convert.ToInt32(dr["QuotationItemId"]);

            if (!dr.IsNull("QuotationId"))
                TrainType.QuotationId = Convert.ToInt32(dr["QuotationId"]);

            if (!dr.IsNull("TicketClass"))
                TrainType.TicketClass = Convert.ToInt32(dr["TicketClass"]);

            if (!dr.IsNull("PickUpFrom"))
                TrainType.PickUpFrom = Convert.ToInt32(dr["PickUpFrom"]);

            if (!dr.IsNull("QuoteRate"))
                TrainType.QuoteRate = Convert.ToInt32(dr["QuoteRate"]);

            if (!dr.IsNull("DropTo"))
                TrainType.DropTo = Convert.ToInt32(dr["DropTo"]);

            if (!dr.IsNull("DepartureDate"))
                TrainType.DepartureDate = Convert.ToDateTime(dr["DepartureDate"]);

            if (!dr.IsNull("ArrivalDate"))
                TrainType.ReturnDate = Convert.ToDateTime(dr["ArrivalDate"]);

            return TrainType;

        }

        public List<QuotationItemTypeDetailsInfo> GetQuotationTrainTypeListDetailsById(int quotationItemId)
        {
            List<QuotationItemTypeDetailsInfo> traintypedetails = new List<QuotationItemTypeDetailsInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@QuotationItemId", quotationItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetQuotationTrainTypeDetailsById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    QuotationItemTypeDetailsInfo traintypelist = new QuotationItemTypeDetailsInfo();

                    if (!dr.IsNull("QuotationItemTypeDetailsId"))
                        traintypelist.QuotationItemTypeDetailsId = Convert.ToInt32(dr["QuotationItemTypeDetailsId"]);

                    if (!dr.IsNull("QuotationItemId"))
                        traintypelist.QuotationItemId = Convert.ToInt32(dr["QuotationItemId"]);

                    if (!dr.IsNull("QuotationId"))
                        traintypelist.QuotationId = Convert.ToInt32(dr["QuotationId"]);

                    if (!dr.IsNull("TicketClass"))
                        traintypelist.TicketClass = Convert.ToInt32(dr["TicketClass"]);

                    if (!dr.IsNull("PickUpFrom"))
                        traintypelist.PickUpFrom = Convert.ToInt32(dr["PickUpFrom"]);

                    if (!dr.IsNull("QuoteRate"))
                        traintypelist.QuoteRate = Convert.ToInt32(dr["QuoteRate"]);

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




        public List<QuotationItemPassDetailsInfo> GetQuotationTrainPassDetails(int quotationId)
        {
            List<QuotationItemPassDetailsInfo> trainpassdetails = new List<QuotationItemPassDetailsInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@QuotationId", quotationId));

            // sqlParamList.Add(new SqlParameter("@EnquiryType", enquiryType));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetQuotationItemPassDetails.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    QuotationItemPassDetailsInfo trainpasslist = new QuotationItemPassDetailsInfo();

                    if (!dr.IsNull("QuotationItemPassDetailsId"))
                        trainpasslist.QuotationItemPassDetailsId = Convert.ToInt32(dr["QuotationItemPassDetailsId"]);

                    if (!dr.IsNull("QuotationItemId"))
                        trainpasslist.QuotationItemId = Convert.ToInt32(dr["QuotationItemId"]);

                    if (!dr.IsNull("QuotationId"))
                        trainpasslist.QuotationId = Convert.ToInt32(dr["QuotationId"]);

                    if (!dr.IsNull("QuotationStatus"))
                        trainpasslist.QuotationStatus = Convert.ToInt32(dr["QuotationStatus"]);

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

                    if (!dr.IsNull("QuoteRate"))
                        trainpasslist.QuoteRate = Convert.ToInt32(dr["QuoteRate"]);

                    trainpassdetails.Add(trainpasslist);
                }
            }

            return trainpassdetails;
        }

        public QuotationItemPassDetailsInfo GetQuotationTrainPassDetailsById(int quotationItemId)
        {

            QuotationItemPassDetailsInfo TrainPassDetail = new QuotationItemPassDetailsInfo();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@QuotationItemId", quotationItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetQuotationTrainPassDetailsById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TrainPassDetail = GetQuotationTrainPassDetailsValues(dr);
                }
            }

            return TrainPassDetail;
        }

        private QuotationItemPassDetailsInfo GetQuotationTrainPassDetailsValues(DataRow dr)
        {
            QuotationItemPassDetailsInfo TrainPass = new QuotationItemPassDetailsInfo();

            if (!dr.IsNull("QuotationItemPassDetailsId"))
                TrainPass.QuotationItemPassDetailsId = Convert.ToInt32(dr["QuotationItemPassDetailsId"]);

            if (!dr.IsNull("QuotationItemId"))
                TrainPass.QuotationItemId = Convert.ToInt32(dr["QuotationItemId"]);

            if (!dr.IsNull("QuotationId"))
                TrainPass.QuotationId = Convert.ToInt32(dr["QuotationId"]);

            if (!dr.IsNull("Region"))
                TrainPass.Region = Convert.ToInt32(dr["Region"]);

            if (!dr.IsNull("PassType"))
                TrainPass.PassType = Convert.ToInt32(dr["PassType"]);

            if (!dr.IsNull("RailPass"))
                TrainPass.RailPass = Convert.ToInt32(dr["RailPass"]);

            if (!dr.IsNull("RailClass"))
                TrainPass.RailClass = Convert.ToInt32(dr["RailClass"]);

            if (!dr.IsNull("NoOfDays"))
                TrainPass.NoOfDays = Convert.ToInt32(dr["NoOfDays"]);

            if (!dr.IsNull("QuoteRate"))
                TrainPass.QuoteRate = Convert.ToInt32(dr["QuoteRate"]);

            return TrainPass;

        }

        public List<QuotationItemPassDetailsInfo> GetQuotationTrainPassListDetailsById(int quotationItemId)
        {
            List<QuotationItemPassDetailsInfo> trainpassdetails = new List<QuotationItemPassDetailsInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@QuotationItemId", quotationItemId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetQuotationTrainPassDetailsById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    QuotationItemPassDetailsInfo trainpasslist = new QuotationItemPassDetailsInfo();

                    if (!dr.IsNull("QuotationItemPassDetailsId"))
                        trainpasslist.QuotationItemPassDetailsId = Convert.ToInt32(dr["QuotationItemPassDetailsId"]);

                    if (!dr.IsNull("QuotationItemId"))
                        trainpasslist.QuotationItemId = Convert.ToInt32(dr["QuotationItemId"]);

                    if (!dr.IsNull("QuotationId"))
                        trainpasslist.QuotationId = Convert.ToInt32(dr["QuotationId"]);

                    if (!dr.IsNull("Region"))
                        trainpasslist.Region = Convert.ToInt32(dr["Region"]);

                    if (!dr.IsNull("PassType"))
                        trainpasslist.PassType = Convert.ToInt32(dr["PassType"]);

                    if (!dr.IsNull("RailPass"))
                        trainpasslist.RailPass = Convert.ToInt32(dr["RailPass"]);

                    if (!dr.IsNull("RailClass"))
                        trainpasslist.RailClass = Convert.ToInt32(dr["RailClass"]);

                    if (!dr.IsNull("NoOfDays"))
                        trainpasslist.NoOfDays = Convert.ToInt32(dr["NoOfDays"]);

                    if (!dr.IsNull("QuoteRate"))
                        trainpasslist.QuoteRate = Convert.ToInt32(dr["QuoteRate"]);

                    trainpassdetails.Add(trainpasslist);
                }
            }

            return trainpassdetails;
        }




        #endregion

        #region Git
        public List<QuotationInfo> GetQuotationItemGitDetails(int quotationId)
        {

            List<QuotationInfo> QuotationItemDetails = new List<QuotationInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@QuotationId", quotationId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetQuotationGitItemDetails.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                QuotationItemDetails.Add(GetQuotationGitDetails(dr));
            }

            return QuotationItemDetails;
        }

        private QuotationInfo GetQuotationGitDetails(DataRow dr)
        {
            QuotationInfo QuotationItem = new QuotationInfo();

            QuotationItem.QuotationItemId = Convert.ToInt32(dr["QuotationItemId"]);

            if (!dr.IsNull("QuotationId"))
                QuotationItem.QuotationId = Convert.ToInt32(dr["QuotationId"]);

            if (!dr.IsNull("QuotationStatus"))
                QuotationItem.QuotationStatus = Convert.ToInt32(dr["QuotationStatus"]);

            if (!dr.IsNull("Remark"))
                QuotationItem.Remark = Convert.ToString(dr["Remark"]);

            if (!dr.IsNull("EnquiryType"))
                QuotationItem.EnquiryType = Convert.ToInt32(dr["EnquiryType"]);

            if (!dr.IsNull("EnquiryItemId"))
                QuotationItem.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

            if (!dr.IsNull("CategoryName"))
                QuotationItem.CategoryName = Convert.ToString(dr["CategoryName"]);

            if (!dr.IsNull("PackageTypeId"))
                QuotationItem.PackageType = Convert.ToInt32(dr["PackageTypeId"]);

            if (!dr.IsNull("PackageTypeName"))
                QuotationItem.PackageTypeName = Convert.ToString(dr["PackageTypeName"]);

            if (!dr.IsNull("PackageDuration"))
                QuotationItem.PackageDuration = Convert.ToString(dr["PackageDuration"]);


            if (!dr.IsNull("PackageName"))
                QuotationItem.PackageName = Convert.ToString(dr["PackageName"]);

            if (!dr.IsNull("AdultCount"))
                QuotationItem.AdultCount = Convert.ToInt32(dr["AdultCount"]);

            if (!dr.IsNull("ChildCount"))
                QuotationItem.ChildCount = Convert.ToInt32(dr["ChildCount"]);

            if (!dr.IsNull("Cost"))
                QuotationItem.Cost = Convert.ToInt32(dr["Cost"]);

            if (!dr.IsNull("FromDate"))
                QuotationItem.FromDate = Convert.ToDateTime(dr["FromDate"]);


            if (!dr.IsNull("CreatedBy"))
                QuotationItem.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            if (!dr.IsNull("CreatedDate"))
                QuotationItem.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);

            if (!dr.IsNull("UpdatedBy"))
                QuotationItem.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            if (!dr.IsNull("UpdatedDate"))
                QuotationItem.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);



            return QuotationItem;

        }

        public void DeleteGitItemById(int QuotationitemId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            QuotationInfo Quotation = new QuotationInfo();

            sqlParam.Add(new SqlParameter("@QuotationItemId", QuotationitemId));

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteGitById.ToString(), CommandType.StoredProcedure);


        }

        #endregion

        #region SightSeeing
        public List<QuotationInfo> GetQuotationItemSightSeeingDetails(int quotationId)
        {

            List<QuotationInfo> QuotationItemDetails = new List<QuotationInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@QuotationId", quotationId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.spGetQuotationSightSeeingItemDetails.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                QuotationItemDetails.Add(GetQuotationItemSightSeeingDetails(dr));
            }

            return QuotationItemDetails;
        }

        public QuotationInfo GetQuotationItemSightSeeingDetails(DataRow dr)
        {
            QuotationInfo QuotationItem = new QuotationInfo();

            QuotationItem.QuotationItemId = Convert.ToInt32(dr["QuotationItemId"]);

            if (!dr.IsNull("QuotationId"))
                QuotationItem.QuotationId = Convert.ToInt32(dr["QuotationId"]);

            if (!dr.IsNull("QuotationStatus"))
                QuotationItem.QuotationStatus = Convert.ToInt32(dr["QuotationStatus"]);

            if (!dr.IsNull("Remark"))
                QuotationItem.Remark = Convert.ToString(dr["Remark"]);

            if (!dr.IsNull("EnquiryType"))
                QuotationItem.EnquiryType = Convert.ToInt32(dr["EnquiryType"]);

            if (!dr.IsNull("EnquiryItemId"))
                QuotationItem.EnquiryItemId = Convert.ToInt32(dr["EnquiryItemId"]);

            if (!dr.IsNull("SightseeingName"))
                QuotationItem.SightseeingName = Convert.ToString(dr["SightseeingName"]);

            if (!dr.IsNull("CityName"))
                QuotationItem.CityName = Convert.ToString(dr["CityName"]);

            if (!dr.IsNull("StateName"))
                QuotationItem.StateName = Convert.ToString(dr["StateName"]);

            if (!dr.IsNull("CountryName"))
                QuotationItem.CountryName = Convert.ToString(dr["CountryName"]);

            if (!dr.IsNull("AdultCount"))
                QuotationItem.AdultCount = Convert.ToInt32(dr["AdultCount"]);

            if (!dr.IsNull("ChildCount"))
                QuotationItem.ChildCount = Convert.ToInt32(dr["ChildCount"]);

            if (!dr.IsNull("Cost"))
                QuotationItem.Cost = Convert.ToInt32(dr["Cost"]);

            if (!dr.IsNull("PackageDuration"))
                QuotationItem.PackageDuration = Convert.ToString(dr["PackageDuration"]);

            if (!dr.IsNull("FromDate"))
                QuotationItem.FromDate = Convert.ToDateTime(dr["FromDate"]);

            if (!dr.IsNull("TravelDate"))
                QuotationItem.TravelDate = Convert.ToDateTime(dr["TravelDate"]);

            return QuotationItem;

        }

        public void DeleteSightSeeingItemById(int QuotationitemId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            QuotationInfo Quotation = new QuotationInfo();

            sqlParam.Add(new SqlParameter("@QuotationItemId", QuotationitemId));

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteGitById.ToString(), CommandType.StoredProcedure);

        }
        #endregion

    }
}









