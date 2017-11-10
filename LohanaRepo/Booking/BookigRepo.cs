using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LohanaBusinessEntities.Quotation;
using LohanaRepo.Utilities;
using LohanaBusinessEntities.Common;
using System.Data;
using System.Data.SqlClient;

using LohanaBusinessLogic.Utilities;
using LohanaHelper.Logging;
using LohanaBusinessEntities;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace LohanaRepo.Booking
{
    public class BookigRepo
    {

        SQLHelperRepo _sqlHelper = null;

        public BookigRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        public int InsertTravellerInformation(BookingCartDetailsInfo bookingCartDetailsInfo)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInTravellerInformation(bookingCartDetailsInfo), Storeprocedures.spInsertTravellersInformation.ToString(), CommandType.StoredProcedure));
        }

        public int UpdateTravellerInformation(BookingCartDetailsInfo bookingCartDetailsInfo)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInTravellerInformation(bookingCartDetailsInfo), Storeprocedures.spUpdateTravellersInformation.ToString(), CommandType.StoredProcedure));
        }

        public int InsertBooking(BookingCartDetailsInfo bookingCartDetailsInfo)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@QuotationId", bookingCartDetailsInfo.QuatationId));

            Logger.Debug("Booking Controller QuotationId:" + bookingCartDetailsInfo.QuatationId);

            sqlParams.Add(new SqlParameter("@CustomerId", bookingCartDetailsInfo.CustomerId));

            Logger.Debug("Booking Controller CustomerId:" + bookingCartDetailsInfo.CustomerId);

            sqlParams.Add(new SqlParameter("CreatedDate", bookingCartDetailsInfo.CreatedDate));

            sqlParams.Add(new SqlParameter("CreatedBy", bookingCartDetailsInfo.CreatedBy));

            sqlParams.Add(new SqlParameter("UpdatedBy", bookingCartDetailsInfo.UpdatedBy));

            sqlParams.Add(new SqlParameter("UpdatedDate", bookingCartDetailsInfo.UpdatedDate));

            //sqlParams.Add(new SqlParameter("ID", ParameterDirection.Output));

            //            SELECT 
            //   SUM(Val1) as 'Val1',
            //   SUM(Val2) as 'Val2',
            //   SUM(Val3) as 'Val3',
            //   (SUM(Val1) + SUM(Val2) + SUM(Val3)) as 'Total'
            //FROM Emp
            int ID = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.sp_Insert_Booking.ToString(), CommandType.StoredProcedure));

            return ID;
        }

        public List<SqlParameter> SetValuesInTravellerInformation(BookingCartDetailsInfo bookingCartDetailsInfo)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (bookingCartDetailsInfo.TravellerId != 0)
            {
                sqlParam.Add(new SqlParameter("TravellerInformationId", bookingCartDetailsInfo.TravellerId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", DateTime.Now));

                sqlParam.Add(new SqlParameter("CreatedBy", bookingCartDetailsInfo.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("TravellerName", bookingCartDetailsInfo.TravellerName));

            Logger.Debug("Booking Controller TravellerName:" + bookingCartDetailsInfo.TravellerName);

            sqlParam.Add(new SqlParameter("Age", bookingCartDetailsInfo.Age));

            Logger.Debug("Booking Controller Age:" + bookingCartDetailsInfo.Age);

            sqlParam.Add(new SqlParameter("MobileNo", bookingCartDetailsInfo.MobileNo));

            Logger.Debug("Booking Controller MobileNo:" + bookingCartDetailsInfo.MobileNo);

            sqlParam.Add(new SqlParameter("BookingId", bookingCartDetailsInfo.BookingId));

            // sqlParam.Add(new SqlParameter("@QuotationId", bookingCartDetailsInfo.QuatationId));

            sqlParam.Add(new SqlParameter("UpdatedBy", bookingCartDetailsInfo.UpdatedBy));

            sqlParam.Add(new SqlParameter("UpdatedDate", bookingCartDetailsInfo.UpdatedDate));

            return sqlParam;
        }

        public DataTable GetTravellersDetails(BookingCartDetailsInfo bookingCartDetailsInfo, ref PaginationInfo pager)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@BookingId", bookingCartDetailsInfo.BookingId));

            sqlParam.Add(new SqlParameter("@TravellersInformationId", bookingCartDetailsInfo.TravellerId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetTravellersInformation.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void DeleteTravellerDetails(int TravellerId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@TravellersInformationId", TravellerId));
            _sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spDeleteTravellersInformation.ToString(), CommandType.StoredProcedure);
        }

        public int InsertTravellerDocumentDetails(BookingCartDetailsInfo bookingCartDetailsInfo)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@TravellerInformationId", bookingCartDetailsInfo.TravellerId));
            sqlParams.Add(new SqlParameter("@DocumentTypeId", bookingCartDetailsInfo.DocumentTypeId));
            sqlParams.Add(new SqlParameter("@DocumentNo", bookingCartDetailsInfo.DocumentNo));
            sqlParams.Add(new SqlParameter("@FileName", bookingCartDetailsInfo.AttachmentName));
            sqlParams.Add(new SqlParameter("CreatedDate", bookingCartDetailsInfo.CreatedDate));

            sqlParams.Add(new SqlParameter("CreatedBy", bookingCartDetailsInfo.CreatedBy));

            sqlParams.Add(new SqlParameter("UpdatedBy", bookingCartDetailsInfo.UpdatedBy));

            sqlParams.Add(new SqlParameter("UpdatedDate", bookingCartDetailsInfo.UpdatedDate));

            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spInsertTravellersDocumentDetails.ToString(), CommandType.StoredProcedure));
        }

        public List<BookingCartDetailsInfo> GetTravellerDocumentDetails(int BookingId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            List<BookingCartDetailsInfo> DetailsList = new List<BookingCartDetailsInfo>();
            sqlParams.Add(new SqlParameter("@BookingId", BookingId));
            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spGetTravellersDocumentDetails.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BookingCartDetailsInfo bookingCartDetails = new BookingCartDetailsInfo();

                    bookingCartDetails.TravellerId = Convert.ToInt32(dr["TravellersInformationId"]);
                    bookingCartDetails.DocumentTypeId = Convert.ToInt32(dr["DocumentType"]);
                    bookingCartDetails.DocumentType = Enum.GetName(typeof(DocumentType), bookingCartDetails.DocumentTypeId).ToString();

                    //ProjectDetails.ProjectStatusName = Enum.GetName(typeof(ProjectStatus), projectDetail.Status).ToString();


                    bookingCartDetails.DocumentNo = Convert.ToString(dr["DocumentNo"]);

                    bookingCartDetails.AttachmentName = Convert.ToString(dr["FileName"]);

                    bookingCartDetails.TravellerDocumentId = Convert.ToInt32(dr["TravellersDocumentId"]);

                    bookingCartDetails.TravellerName = Convert.ToString(dr["TravellerName"]);

                    DetailsList.Add(bookingCartDetails);
                }
            }
            return DetailsList;
        }

        public void DeleteTravellerDocument(int TravellerDocumentId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@TravellerDocumentId", TravellerDocumentId));
            _sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spDeleteTravellersDocument.ToString(), CommandType.StoredProcedure);
        }

        public List<BookingCartDetailsInfo> GetTrainFlightDetails(int BookingId)
        {
            List<BookingCartDetailsInfo> FlightDetails = new List<BookingCartDetailsInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@BookingId", BookingId));
            sqlParams.Add(new SqlParameter("@BookingType", "Flight"));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.GetTrainFlightDetails.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BookingCartDetailsInfo bookingCartDetails = new BookingCartDetailsInfo();
                    bookingCartDetails.QuatationId = Convert.ToInt32(dr["QuotationId"]);
                    bookingCartDetails.VendorId = Convert.ToString(dr["VendorId"]);
                    bookingCartDetails.VendorName = Convert.ToString(dr["VendorName"]);

                    bookingCartDetails.FlightName = Convert.ToString(dr["Train/FlightName"]);
                    bookingCartDetails.TicketTypeId = Convert.ToInt32(dr["TicketType"]);
                    bookingCartDetails.TicketTypeName = Enum.GetName(typeof(AirplaneTicketClass), bookingCartDetails.TicketTypeId).ToString();

                    bookingCartDetails.JourneyDate = Convert.ToDateTime(dr["JourneyDate"]);
                    bookingCartDetails.JourneyTime = Convert.ToString(dr["JourneyTime"]);
                    bookingCartDetails.Source = Convert.ToString(dr["Source"]);
                    bookingCartDetails.Destination = Convert.ToString(dr["Destination"]);
                    bookingCartDetails.VisitorPass = Convert.ToString(dr["PassType"]);
                    bookingCartDetails.Duration = Convert.ToString(dr["Duration"]);
                    bookingCartDetails.Train_FlightMainId = Convert.ToInt32(dr["TrainFlightMainId"]);
                    FlightDetails.Add(bookingCartDetails);
                }

            }
            return FlightDetails;
        }

        public int InsertTrainOrFlightDetails(BookingCartDetailsInfo bookingCartDetailsInfo)
        {
            int ID = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInFlightDetails(bookingCartDetailsInfo), Storeprocedures.InsertTrainOrFlightDetails.ToString(), CommandType.StoredProcedure));

            return ID;
        }

        public void UpdateTrainOrFlightDetails(BookingCartDetailsInfo bookingCartDetailsInfo)
        {
            _sqlHelper.ExecuteScalerObj(SetValuesInFlightDetails(bookingCartDetailsInfo), Storeprocedures.UpdateTrainOrFlightDetails.ToString(), CommandType.StoredProcedure);
        }

        public List<SqlParameter> SetValuesInFlightDetails(BookingCartDetailsInfo bookingCartDetailsInfo)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (bookingCartDetailsInfo.Train_FlightMainId != 0)
            {
                sqlParams.Add(new SqlParameter("@Train_FlightMainId", bookingCartDetailsInfo.Train_FlightMainId));
            }

            sqlParams.Add(new SqlParameter("@BookingId", bookingCartDetailsInfo.BookingId));

            Logger.Debug("Booking Controller BookingId:" + bookingCartDetailsInfo.BookingId);

            sqlParams.Add(new SqlParameter("@QuatationId", bookingCartDetailsInfo.QuatationId));

            Logger.Debug("Booking Controller QuatationId:" + bookingCartDetailsInfo.QuatationId);

            sqlParams.Add(new SqlParameter("@Vendorid", bookingCartDetailsInfo.VendorId));

            Logger.Debug("Booking Controller Vendorid:" + bookingCartDetailsInfo.VendorId);

            sqlParams.Add(new SqlParameter("@TrainName", bookingCartDetailsInfo.FlightName));

            Logger.Debug("Booking Controller FlightName:" + bookingCartDetailsInfo.FlightName);

            sqlParams.Add(new SqlParameter("@TicketType", bookingCartDetailsInfo.TicketTypeId));

            Logger.Debug("Booking Controller TicketType:" + bookingCartDetailsInfo.TicketTypeId);

            sqlParams.Add(new SqlParameter("@JourneyDate", bookingCartDetailsInfo.JourneyDate));

            Logger.Debug("Booking Controller JourneyDate:" + bookingCartDetailsInfo.JourneyDate);

            sqlParams.Add(new SqlParameter("@JourneyTime", bookingCartDetailsInfo.JourneyTime));

            Logger.Debug("Booking Controller JourneyTime:" + bookingCartDetailsInfo.JourneyTime);

            sqlParams.Add(new SqlParameter("@Source", bookingCartDetailsInfo.Source));

            Logger.Debug("Booking Controller Source:" + bookingCartDetailsInfo.Source);

            sqlParams.Add(new SqlParameter("@Destination", bookingCartDetailsInfo.Destination));

            Logger.Debug("Booking Controller Destination:" + bookingCartDetailsInfo.Destination);

            sqlParams.Add(new SqlParameter("@PassType", bookingCartDetailsInfo.VisitorPass));

            Logger.Debug("Booking Controller VisitorPass:" + bookingCartDetailsInfo.VisitorPass);

            sqlParams.Add(new SqlParameter("@Duration", bookingCartDetailsInfo.Duration));

            Logger.Debug("Booking Controller Duration:" + bookingCartDetailsInfo.Duration);

            if (bookingCartDetailsInfo.Train_FlightMainId == 0)
            {
                sqlParams.Add(new SqlParameter("CreatedDate", bookingCartDetailsInfo.CreatedDate));

                sqlParams.Add(new SqlParameter("CreatedBy", bookingCartDetailsInfo.CreatedBy));
            }
            sqlParams.Add(new SqlParameter("UpdatedBy", bookingCartDetailsInfo.UpdatedBy));

            sqlParams.Add(new SqlParameter("UpdatedDate", bookingCartDetailsInfo.UpdatedDate));

            sqlParams.Add(new SqlParameter("BookingType", "Flight"));

            return sqlParams;
        }



        public int InsertTrainOrFlightPassangerDetails(BookingCartDetailsInfo bookingCartDetailsInfo)
        {
            int ID = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValueInPassangertBooking(bookingCartDetailsInfo), Storeprocedures.InsertTrainOrFlightPassangerDetails.ToString(), CommandType.StoredProcedure));
            return ID;
        }

        public List<SqlParameter> SetValueInPassangertBooking(BookingCartDetailsInfo bookingCartDetailsInfo)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@TrainFlightMainId", bookingCartDetailsInfo.Train_FlightMainId));

            Logger.Debug("Booking Controller TrainFlightMainId:" + bookingCartDetailsInfo.Train_FlightMainId);

            sqlParams.Add(new SqlParameter("@TravellerId", bookingCartDetailsInfo.TravellerId));

            Logger.Debug("Booking Controller TravellerId:" + bookingCartDetailsInfo.TravellerId);

            sqlParams.Add(new SqlParameter("@SeatNo", bookingCartDetailsInfo.SeatNo));

            Logger.Debug("Booking Controller SeatNo:" + bookingCartDetailsInfo.SeatNo);

            sqlParams.Add(new SqlParameter("@Amount", bookingCartDetailsInfo.Price));

            Logger.Debug("Booking Controller Amount:" + bookingCartDetailsInfo.Price);
            return sqlParams;
        }

        public void SaveFlightpassangerDetails(BookingCartDetailsInfo bookingCartDetailsInfo)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@TrainFlightMainId", bookingCartDetailsInfo.Train_FlightMainId));
            sqlParams.Add(new SqlParameter("@TravellerId", bookingCartDetailsInfo.PassangerId));
            sqlParams.Add(new SqlParameter("@SeatNo", bookingCartDetailsInfo.SeatNo));
            sqlParams.Add(new SqlParameter("@Amount", bookingCartDetailsInfo.Price));
            _sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.InsertTrainOrFlightPassangerDetails.ToString(), CommandType.StoredProcedure);
        }

        public List<BookingCartDetailsInfo> GetPassangerDetails(int TrainOrFlightMainId)
        {
            List<BookingCartDetailsInfo> PassangerList = new List<BookingCartDetailsInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@TrainOrFlightMainId", TrainOrFlightMainId));
            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.GetTrainFlightPassangerDetails.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BookingCartDetailsInfo bookingCartDetails = new BookingCartDetailsInfo();
                    bookingCartDetails.Train_FlightMainId = Convert.ToInt32(dr["Train/FlightMainId"]);
                    bookingCartDetails.Train_FlightdetailId = Convert.ToInt32(dr["Train/FlightDetailId"]);
                    bookingCartDetails.TravellerId = Convert.ToInt32(dr["TravellerId"]);
                    bookingCartDetails.SeatNo = Convert.ToString(dr["SeatNumber"]);
                    bookingCartDetails.Price = Convert.ToDecimal(dr["Amount"]);
                    bookingCartDetails.TravellerName = Convert.ToString(dr["TravellerName"]);
                    bookingCartDetails.Age = Convert.ToInt32(dr["Age"]);
                    PassangerList.Add(bookingCartDetails);
                }
            }


            return PassangerList;
        }

        public void DeletePassangerDetails(int Train_FlightdetailId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Train_FlightdetailId", Train_FlightdetailId));
            _sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.DeletePassangerDetails.ToString(), CommandType.StoredProcedure);
        }

        public void DeleteFlightDetails(int Train_FlightMainId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Train_FlightMainId", Train_FlightMainId));
            _sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.DeleteTrainOrFlightDetails.ToString(), CommandType.StoredProcedure);
        }


        //Train

        public int InsertTrainDetails(BookingCartDetailsInfo bookingCartDetailsInfo)
        {
            int ID = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInTrainDetails(bookingCartDetailsInfo), Storeprocedures.InsertTrainOrFlightDetails.ToString(), CommandType.StoredProcedure));

            return ID;
        }

        public int UpdateTrainDetails(BookingCartDetailsInfo bookingCartDetailsInfo)
        {
            int ID = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInTrainDetails(bookingCartDetailsInfo), Storeprocedures.UpdateTrainOrFlightDetails.ToString(), CommandType.StoredProcedure));

            return ID;
        }

        public List<SqlParameter> SetValuesInTrainDetails(BookingCartDetailsInfo bookingCartDetailsInfo)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (bookingCartDetailsInfo.Train_FlightMainId != 0)
            {
                sqlParams.Add(new SqlParameter("@Train_FlightMainId", bookingCartDetailsInfo.Train_FlightMainId));
            }

            sqlParams.Add(new SqlParameter("@BookingId", bookingCartDetailsInfo.BookingId));

            Logger.Debug("Booking Controller BookingId:" + bookingCartDetailsInfo.BookingId);

            sqlParams.Add(new SqlParameter("@QuatationId", bookingCartDetailsInfo.QuatationId));

            Logger.Debug("Booking Controller QuatationId:" + bookingCartDetailsInfo.QuatationId);

            sqlParams.Add(new SqlParameter("@Vendorid", bookingCartDetailsInfo.TrainVendorId));

            Logger.Debug("Booking Controller Vendorid:" + bookingCartDetailsInfo.TrainVendorId);

            sqlParams.Add(new SqlParameter("@TrainName", bookingCartDetailsInfo.TrainName));

            Logger.Debug("Booking Controller FlightName:" + bookingCartDetailsInfo.TrainName);

            sqlParams.Add(new SqlParameter("@TicketType", bookingCartDetailsInfo.TicketClassId));

            Logger.Debug("Booking Controller TicketType:" + bookingCartDetailsInfo.TicketClassId);

            sqlParams.Add(new SqlParameter("@JourneyDate", bookingCartDetailsInfo.TrainJourneyDate));

            Logger.Debug("Booking Controller JourneyDate:" + bookingCartDetailsInfo.TrainJourneyDate);

            sqlParams.Add(new SqlParameter("@JourneyTime", bookingCartDetailsInfo.TrainJourneyTime));

            Logger.Debug("Booking Controller JourneyTime:" + bookingCartDetailsInfo.TrainJourneyTime);

            sqlParams.Add(new SqlParameter("@Source", bookingCartDetailsInfo.TrainSource));

            Logger.Debug("Booking Controller Source:" + bookingCartDetailsInfo.TrainSource);

            sqlParams.Add(new SqlParameter("@Destination", bookingCartDetailsInfo.TrainDestination));

            Logger.Debug("Booking Controller Destination:" + bookingCartDetailsInfo.TrainDestination);

            sqlParams.Add(new SqlParameter("@PassType", bookingCartDetailsInfo.VisitorPass));

            Logger.Debug("Booking Controller VisitorPass:" + bookingCartDetailsInfo.VisitorPass);

            sqlParams.Add(new SqlParameter("@Duration", bookingCartDetailsInfo.TrainDuration));

            Logger.Debug("Booking Controller Duration:" + bookingCartDetailsInfo.TrainDuration);

            if (bookingCartDetailsInfo.Train_FlightMainId == 0)
            {
                sqlParams.Add(new SqlParameter("CreatedDate", bookingCartDetailsInfo.CreatedDate));

                sqlParams.Add(new SqlParameter("CreatedBy", bookingCartDetailsInfo.CreatedBy));
            }
            sqlParams.Add(new SqlParameter("UpdatedBy", bookingCartDetailsInfo.UpdatedBy));

            sqlParams.Add(new SqlParameter("UpdatedDate", bookingCartDetailsInfo.UpdatedDate));

            sqlParams.Add(new SqlParameter("BookingType", "Train"));

            return sqlParams;
        }

        public List<BookingCartDetailsInfo> GetTrainDetails(int BookingId)
        {
            List<BookingCartDetailsInfo> TrainDetails = new List<BookingCartDetailsInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@BookingId", BookingId));
            sqlParams.Add(new SqlParameter("@BookingType", "Train"));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.GetTrainFlightDetails.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BookingCartDetailsInfo bookingCartDetails = new BookingCartDetailsInfo();
                    bookingCartDetails.QuatationId = Convert.ToInt32(dr["QuotationId"]);
                    bookingCartDetails.TrainVendorId = Convert.ToString(dr["VendorId"]);
                    bookingCartDetails.VendorName = Convert.ToString(dr["VendorName"]);

                    bookingCartDetails.TrainName = Convert.ToString(dr["Train/FlightName"]);
                    bookingCartDetails.TicketClassId = Convert.ToInt32(dr["TicketType"]);
                    bookingCartDetails.TicketClassName = Enum.GetName(typeof(TrainTicketClass), bookingCartDetails.TicketClassId).ToString();
                    bookingCartDetails.TrainJourneyDate = Convert.ToDateTime(dr["JourneyDate"]);
                    bookingCartDetails.TrainJourneyTime = Convert.ToString(dr["JourneyTime"]);
                    bookingCartDetails.TrainSource = Convert.ToString(dr["Source"]);
                    bookingCartDetails.TrainDestination = Convert.ToString(dr["Destination"]);
                    bookingCartDetails.VisitorPass = Convert.ToString(dr["PassType"]);
                    bookingCartDetails.TrainDuration = Convert.ToString(dr["Duration"]);
                    bookingCartDetails.Train_FlightMainId = Convert.ToInt32(dr["TrainFlightMainId"]);
                    TrainDetails.Add(bookingCartDetails);
                }

            }
            return TrainDetails;
        }




        #region GenerateQuotation

        public List<BookingCartDetailsInfo> GetInvoiceDetails(BookingCartDetailsInfo bookingCartDetailsInfo)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            List<BookingCartDetailsInfo> BookingCartBasicInfo = new List<BookingCartDetailsInfo>();

            sqlParam.Add(new SqlParameter("@BookingId", bookingCartDetailsInfo.BookingId));

            DataSet ds = _sqlHelper.ExecuteDataSet(sqlParam, Storeprocedures.spGetInvoiceDetails.ToString(), CommandType.StoredProcedure);

            DataTable dt1 = ds.Tables[0];

            if (dt1 != null && dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    BookingCartBasicInfo.Add(GetInvoiceBasicDetailsValues(dr));
                }
            }
            return BookingCartBasicInfo;

        }

        public BookingCartDetailsInfo GetInvoiceBasicDetailsValues(DataRow dr)
        {
            BookingCartDetailsInfo Info = new BookingCartDetailsInfo();

            Info.BookingId = Convert.ToInt32(dr["BookingId"]);

            if (!dr.IsNull("PackageDetailsId"))
                Info.PackageDetailsId = Convert.ToInt32(dr["PackageDetailsId"]);

            if (!dr.IsNull("PackageName"))
                Info.PackageName = Convert.ToString(dr["PackageName"]);

            if (!dr.IsNull("BookingNo"))
                Info.BookingNo = Convert.ToString(dr["BookingNo"]);

            if (!dr.IsNull("CustomerName"))
                Info.CustomerName = Convert.ToString(dr["CustomerName"]);

            if (!dr.IsNull("Address"))
                Info.Address = Convert.ToString(dr["Address"]);

            if (!dr.IsNull("MobileNo"))
                Info.MobileNo = Convert.ToString(dr["MobileNo"]);

            if (!dr.IsNull("EmailId"))
                Info.EmailId = Convert.ToString(dr["EmailId"]);

            if (!dr.IsNull("InvoiceId"))
                Info.InvoiceId = Convert.ToInt32(dr["InvoiceId"]);

            if (!dr.IsNull("InvoiceNo"))
                Info.InvoiceNo = Convert.ToString(dr["InvoiceNo"]);

            if (!dr.IsNull("TotalAmount"))
                Info.TotalAmount = Convert.ToDecimal(dr["TotalAmount"]);

            if (!dr.IsNull("UnpaidAmount"))
                Info.UnpaidAmount = Convert.ToDecimal(dr["UnpaidAmount"]);

            Info.CreatedDate = DateTime.Now;

            Info.ProductDetails = GetProductItemsDetails(Info.BookingId);

            return Info;
        }

        public List<BookingCartDetailsInfo> GetProductItemsDetails(int BookingId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            List<BookingCartDetailsInfo> BookingBasicInfo = new List<BookingCartDetailsInfo>();

            sqlParam.Add(new SqlParameter("@BookingId", BookingId));

            DataSet ds = _sqlHelper.ExecuteDataSet(sqlParam, Storeprocedures.spGetProductItemsDetails.ToString(), CommandType.StoredProcedure);

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                DataTable dt1 = ds.Tables[i];

                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt1.Rows)
                    {
                        BookingBasicInfo.Add(GetProductItemsDetailsValues(dr));
                    }
                }
            }


            return BookingBasicInfo;
        }

        public List<BookingCartDetailsInfo> TravellerId(int BookingId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            List<BookingCartDetailsInfo> BookingBasicInfo = new List<BookingCartDetailsInfo>();

            sqlParam.Add(new SqlParameter("@BookingId", BookingId));

            DataSet ds = _sqlHelper.ExecuteDataSet(sqlParam, Storeprocedures.spGetProductItemsDetails.ToString(), CommandType.StoredProcedure);

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                DataTable dt1 = ds.Tables[i];

                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt1.Rows)
                    {
                        BookingBasicInfo.Add(GetProductItemsDetailsValues(dr));
                    }
                }
            }


            return BookingBasicInfo;
        }

        public BookingCartDetailsInfo GetProductItemsDetailsValues(DataRow dr)
        {
            BookingCartDetailsInfo info = new BookingCartDetailsInfo();

            if (!dr.IsNull("ItemName"))
                info.ItemName = Convert.ToString(dr["ItemName"]);

            if (!dr.IsNull("Cost"))
                info.Cost = Convert.ToDecimal(dr["Cost"]);

            if (!dr.IsNull("Quantity"))
                info.Quantity = Convert.ToInt32(dr["Quantity"]);

            //if (!dr.IsNull("HotelName"))
            //    info.HotelName = Convert.ToString(dr["HotelName"]);

            //if (!dr.IsNull("HotelRate"))
            //    info.HotelRate = Convert.ToDecimal(dr["HotelRate"]);

            ////if (!dr.IsNull("SightseeingName"))
            ////    info.SightseeingName = Convert.ToString(dr["SightseeingName"]);

            //if (!dr.IsNull("SightSeeingId"))
            //    info.SightSeeingId = Convert.ToInt32(dr["SightSeeingId"]);

            //if (!dr.IsNull("SightSeeingRate"))
            //    info.SightSeeingRate = Convert.ToDecimal(dr["SightSeeingRate"]);

            //if (!dr.IsNull("PackageName"))
            //    info.PackageName = Convert.ToString(dr["PackageName"]);

            //if (!dr.IsNull("PackageRate"))
            //    info.PackageRate = Convert.ToDecimal(dr["PackageRate"]);

            //if (!dr.IsNull("Train/FlightName"))
            //    info.TravellerName = Convert.ToString(dr["Train/FlightName"]);

            //if (!dr.IsNull("TravellerRate"))
            //    info.TravellerRate = Convert.ToDecimal(dr["TravellerRate"]);

            //if (!dr.IsNull("PackageDetailsId"))
            //    info.PackageDetailsId = Convert.ToInt32(dr["PackageDetailsId"]);


            return info;
        }

        public DataTable GetBookingList(BookingCartDetailsInfo bookingCartDetailsInfo, ref PaginationInfo pager)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@BookingId", bookingCartDetailsInfo.BookingId));

            sqlParam.Add(new SqlParameter("@CustomerName", bookingCartDetailsInfo.CustomerName));

            sqlParam.Add(new SqlParameter("@BookingNo", bookingCartDetailsInfo.BookingNo));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetBookingListInformation.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public int AddCustomerPayment(PaymentDetailsInfo paymentDetailsInfo)
        {
            var id = 0;
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@BookingId", paymentDetailsInfo.BookingId));

            sqlParams.Add(new SqlParameter("@PaymentMode", paymentDetailsInfo.PaymentMode));

            sqlParams.Add(new SqlParameter("@ReceivableDate", paymentDetailsInfo.ReceivableDate));

            if (paymentDetailsInfo.ChequeDate != DateTime.MinValue)
            {
                sqlParams.Add(new SqlParameter("@ChequeDate", paymentDetailsInfo.ChequeDate));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@ChequeDate", DBNull.Value));
            }
            if (paymentDetailsInfo.TransactionNo != null)
            {
                sqlParams.Add(new SqlParameter("@TransactionNo", paymentDetailsInfo.TransactionNo));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@TransactionNo", 0));
            }
            if (paymentDetailsInfo.BankName != null)
            {
                sqlParams.Add(new SqlParameter("@BankName", paymentDetailsInfo.BankName));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@BankName", null));
            }

            sqlParams.Add(new SqlParameter("@PaidAmount", paymentDetailsInfo.PaidAmount));

            sqlParams.Add(new SqlParameter("@CreatedOn", paymentDetailsInfo.CreatedDate));

            sqlParams.Add(new SqlParameter("@CreatedBy", paymentDetailsInfo.CreatedBy));

            sqlParams.Add(new SqlParameter("@UpdatedBy", paymentDetailsInfo.UpdatedBy));

            sqlParams.Add(new SqlParameter("@ID", id));

            sqlParams.Add(new SqlParameter("@UpdatedOn", paymentDetailsInfo.UpdatedDate));

            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.sp_Insert_Payment.ToString(), CommandType.StoredProcedure));

        }

        public DataTable GetPaymentHistory(int bookingId, ref PaginationInfo pager)
        {
            List<PaymentDetailsInfo> payments = new List<PaymentDetailsInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@BookingId", bookingId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spGetPaymentHistoryList.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void InserPackageDetails(List<BookingCartDetailsInfo> GitDetailList, BookingCartDetailsInfo bookingCartDetailsInfo)
        {
            foreach (var item in GitDetailList)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("@BookingId", item.BookingId));
                sqlParams.Add(new SqlParameter("@QuotationId", item.QuatationId));
                sqlParams.Add(new SqlParameter("@PackageTypeId", item.PackageTypeId));
                sqlParams.Add(new SqlParameter("@ProductType", item.ProductType));
                sqlParams.Add(new SqlParameter("@VendorId", item.VendorId));
                sqlParams.Add(new SqlParameter("@PackageName", item.PackageName));
                sqlParams.Add(new SqlParameter("@PackageDuration", item.Duration));
                sqlParams.Add(new SqlParameter("@Location", item.Destination));
                sqlParams.Add(new SqlParameter("@CategoryId", item.CategoryId));

                sqlParams.Add(new SqlParameter("@FromDate", item.FromDate == DateTime.MinValue ? null : item.FromDate.ToString()));

                sqlParams.Add(new SqlParameter("@ToDate", item.ToDate == DateTime.MinValue ? null : item.ToDate.ToString()));

                sqlParams.Add(new SqlParameter("@NetRate", item.NetRate));
                sqlParams.Add(new SqlParameter("@QuoteRate", item.QuoteRate));
                sqlParams.Add(new SqlParameter("@CreatedDate", bookingCartDetailsInfo.CreatedDate));
                sqlParams.Add(new SqlParameter("@CreatedBy", bookingCartDetailsInfo.CreatedBy));
                sqlParams.Add(new SqlParameter("@UpdatedBy", bookingCartDetailsInfo.UpdatedBy));
                sqlParams.Add(new SqlParameter("@UpdatedDate", bookingCartDetailsInfo.UpdatedDate));
                _sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spInsertPackageDetails.ToString(), CommandType.StoredProcedure);
            }

        }

        public void UpdateBookingAmount(int BookingId)
        {
            //GetPackagesAmount
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@bookingId", BookingId));
            _sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spGetProductTotalAmount.ToString(), CommandType.StoredProcedure);

        }



        public List<PaymentDetailsInfo> GetReceiptDetails(int PaymentReceivableId, int BookingId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            List<PaymentDetailsInfo> PaymentInfo = new List<PaymentDetailsInfo>();

            sqlParam.Add(new SqlParameter("@PaymentReceivableId", PaymentReceivableId));

            sqlParam.Add(new SqlParameter("@BookingId", BookingId));

            DataSet ds = _sqlHelper.ExecuteDataSet(sqlParam, Storeprocedures.spGetReceiptDetails.ToString(), CommandType.StoredProcedure);

            DataTable dt1 = ds.Tables[0];

            if (dt1 != null && dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    PaymentInfo.Add(GetPaymentReceiptDetailsValues(dr));
                }
            }
            return PaymentInfo;
        }

        public PaymentDetailsInfo GetPaymentReceiptDetailsValues(DataRow dr)
        {
            PaymentDetailsInfo Info = new PaymentDetailsInfo();

            Info.BookingId = Convert.ToInt32(dr["BookingId"]);

            Info.PaymentReceivableId = Convert.ToInt32(dr["PaymentReceivableId"]);

            if (!dr.IsNull("BookingNo"))
                Info.BookingNo = Convert.ToString(dr["BookingNo"]);

            if (!dr.IsNull("InvoiceNo"))
                Info.InvoiceNo = Convert.ToString(dr["InvoiceNo"]);

            if (!dr.IsNull("ReceiptNo"))
                Info.ReceiptNo = Convert.ToString(dr["ReceiptNo"]);

            if (!dr.IsNull("CustomerName"))
                Info.CustomerName = Convert.ToString(dr["CustomerName"]);

            if (!dr.IsNull("Address"))
                Info.Address = Convert.ToString(dr["Address"]);

            if (!dr.IsNull("MobileNo"))
                Info.MobileNo = Convert.ToString(dr["MobileNo"]);

            if (!dr.IsNull("EmailId"))
                Info.EmailId = Convert.ToString(dr["EmailId"]);

            if (!dr.IsNull("CreatedOn"))
                Info.CreatedDate = Convert.ToDateTime(dr["CreatedOn"]);

            if (!dr.IsNull("BankName"))
                Info.BankName = Convert.ToString(dr["BankName"]);

            if (!dr.IsNull("PaidAmount"))
                Info.PaidAmount = Convert.ToDecimal(dr["PaidAmount"]);

            if (!dr.IsNull("ChequeDate"))
                Info.ChequeDate = Convert.ToDateTime(dr["ChequeDate"]);

            if (!dr.IsNull("ReceivableDate"))
                Info.ReceivableDate = Convert.ToDateTime(dr["ReceivableDate"]);

            if (!dr.IsNull("TransactionNo"))
                Info.TransactionNo = Convert.ToString(dr["TransactionNo"]);

            if (!dr.IsNull("PaymentMode"))
                Info.PaymentModeName = Convert.ToString(dr["PaymentMode"]);

            return Info;
        }

        //public List<PaymentDetailsInfo> GetPaymentHistory(int BookingId)
        //{
        //    List<SqlParameter> sqlParam = new List<SqlParameter>();

        //    List<PaymentDetailsInfo> payments= new List<PaymentDetailsInfo> ();

        //    sqlParam.Add(new SqlParameter("@BookingId", BookingId));

        //    DataSet ds = _sqlHelper.ExecuteDataSet(sqlParam, Storeprocedures.spGetPaymentHistoryList.ToString(), CommandType.StoredProcedure);

        //    DataTable dt1 = ds.Tables[0];

        //    if (dt1 != null && dt1.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dt1.Rows)
        //        {
        //            payments.Add(GetPaymentDetailsValues(dr));
        //        }
        //    }
        //    return payments;

        //}

        //public PaymentDetailsInfo GetPaymentDetailsValues(DataRow dr)
        //{
        //    PaymentDetailsInfo Info= new PaymentDetailsInfo();

        //    Info.BookingId = Convert.ToInt32(dr["BookingId"]);

        //    Info.PaymentDetailId = Convert.ToInt32(dr["PaymentDetailsId"]);

        //    if (!dr.IsNull("BookingNo"))
        //        Info.BookingNo = Convert.ToString(dr["BookingNo"]);

        //    if (!dr.IsNull("BankName"))
        //        Info.BankName = Convert.ToString(dr["BankName"]);

        //    if (!dr.IsNull("PaymentMode"))
        //        Info.PaymentModeName = Convert.ToString(dr["PaymentMode"]);

        //    if (!dr.IsNull("InstrumentDate"))
        //        Info.InstrumentDate = Convert.ToDateTime(dr["InstrumentDate"]);

        //    if (!dr.IsNull("InstrumentNo"))
        //        Info.InstrumentNo = Convert.ToString(dr["InstrumentNo"]);

        //    //if (!dr.IsNull("PaymentType"))
        //    //    Info.PaymentTypeName = Convert.ToString(dr["PaymentType"]);

        //    if (!dr.IsNull("PaidAmount"))
        //        Info.PaidAmount = Convert.ToDecimal(dr["PaidAmount"]);

        //    return Info;
        //}      

        public MemoryStream CreateInvoice_DownloadPDF(List<BookingCartDetailsInfo> DocumentDetailsList)
        {
            MemoryStream ms = new MemoryStream();
            StringBuilder html = new StringBuilder();

            html.Append("<html><head></head><body> ");

            html.Append("<table cellpadding='5' style='border-collapse: collapse; width: 100%;background-color:white' border='1'>");
            if (DocumentDetailsList.Count > 0)
            {
                html.Append("<thead style='background: #eee;'>");
                html.Append("<tr>");
                html.Append("<th colspan='5' style='text-align: left;'>Invoice No:" + DocumentDetailsList[0].InvoiceNo + "<span style='float: right;'>Date- " + DocumentDetailsList[0].CreatedDate + "</span></th>");
                html.Append("</tr>");
                html.Append("</thead>");
                html.Append("<tbody>");
                html.Append("<tr>");
                html.Append("<td colspan='4' style='text-align: right; width: 70%; border-right: none;'>");
                html.Append("<p><b>Travellers Details:</b></p>");
                html.Append("</td>");
                html.Append("<td style='width: 30%; border-left: none;'></td>");
                html.Append("</tr>");
                html.Append("<tr>");
                html.Append("<td colspan='4' style='text-align: right; width: 70%; border-right: none;'>");
                html.Append("<p>Customer Name: </p>");
                html.Append("<p>Address: </p>");
                html.Append("<p>Mobile No: </p>");
                html.Append("<p>Email Id:</p>");
                //html.Append("<p>Destination: </p>");
                //html.Append("<p>Travel Dates: </p>");
                //html.Append("<p>No. of Travelers:</p>");
                //html.Append("<p>Payment Mode:</p>");
                html.Append("</td>");
                html.Append("<td style='text-align: left; width: 30%; border-left: none;'>");
                html.Append("<p>" + DocumentDetailsList[0].CustomerName + "</p>");
                html.Append("<p>" + DocumentDetailsList[0].Address + "</p>");
                html.Append("<p>" + DocumentDetailsList[0].MobileNo + "</p>");
                html.Append("<p>" + DocumentDetailsList[0].EmailId + "</p>");
                //html.Append("<p>"+DocumentDetailsList[0].Destination+"</p>");
                //html.Append("<p>"+DocumentDetailsList[0].TravelDate+"</p>");
                //html.Append("<p>5</p>");
                //html.Append("<p>Cash, Check</p>");
                html.Append("</td>");
                html.Append("</tr>");
                html.Append("</tbody>");
                html.Append("<tbody>");
                html.Append("<tr>");
                html.Append("<td style='width: 10%; text-align: center;'><b>#</b></td>");
                html.Append("<td style='width: 30%; text-align: center;'><b>Product Items</b></td>");
                html.Append("<td style='width: 10%; text-align: center;'><b>Quantity</b></td>");
                html.Append("<td style='width: 20%; text-align: center;'><b>Unit Price</b></td>");
                html.Append("<td style='width: 30%; text-align: center;'><b>Total Price</b></td>");
                html.Append("</tr>");
                if (DocumentDetailsList[0].ProductDetails.Count > 0)
                {
                    int j = 1;
                    foreach (var item in DocumentDetailsList[0].ProductDetails)
                    {
                        html.Append("<tr>");
                        html.Append("<td style='text-align: center;'>" + j + "</td>");
                        html.Append("<td style='text-align: center;'>" + item.ItemName + "</td>");
                        if (item.Quantity == 0)
                        {
                            html.Append("<td style='text-align: center; '></td>");
                        }
                        else
                        {
                            html.Append("<td style='text-align: center; '>" + item.Quantity + "</td>");
                        }
                        html.Append("<td style='text-align: right;'>" + item.Cost + "</td>");
                        html.Append("<td style='text-align: right;'>" + item.Cost + "</td>");
                        html.Append("</tr>");
                        j++;
                    }
                }
                html.Append("</tbody>");
                html.Append("<tbody>");
                html.Append("<tr>");
                html.Append("<td colspan='3' style='width: 50%; border-right: none;'>");
                html.Append("<p><b>Terms and Conditions</b></p>");
                html.Append("<p>Thank you for your business. We do expect payment within 21 days, so please process this invoice within that time. There will be a 1.5% interest charge per month on late invoices.html.Append</p>");
                html.Append("</td>");
                html.Append("<td style='width: 30%; text-align: right; border-right: none; border-left: none; '>");
                html.Append("<p>Sub - Total amount:</p>");
                html.Append("<p>GST:</p>");
                html.Append("<p>Grand Total:</p>");
                html.Append("</td>");
                html.Append("<td style='width: 20%; border-left: none;'>");
                html.Append("<p><b>" + DocumentDetailsList[0].TotalAmount + "/-</b></p>");
                html.Append("<p><b>15%</b></p>");
                html.Append("<p><b>" + DocumentDetailsList[0].TotalAmount + "/-</b></p>");
                html.Append("</td>");
                html.Append("</tr>");
                html.Append("</tbody>");

            }

            html.Append("</table>");


            html.Append("</body></html>");



            Byte[] bytes;
            StringReader sr = new StringReader(html.ToString());
            using (ms = new MemoryStream())
            {
                using (var doc = new Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 10f))
                {
                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {
                        doc.Open();

                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, sr);

                        doc.Close();
                    }
                }
                bytes = ms.ToArray();
            }
            // string FilePath = path + "//test1.pdf";
            // System.IO.File.WriteAllBytes(FilePath, bytes);
            return ms;
        }

        public MemoryStream CreateReceipt_DownloadPDF(List<PaymentDetailsInfo> PaymentHistoryList)
        {
            MemoryStream ms = new MemoryStream();
            StringBuilder html = new StringBuilder();

            html.Append("<html><head></head><body> ");

            html.Append("<table cellpadding='5' style='border-collapse: collapse; width: 100%;background-color:white' border='1' id='receipttblPrint'>");
            if (PaymentHistoryList.Count > 0)
            {
                html.Append("<thead style='background: #eee;'>");
                html.Append("<tr>");
                html.Append("<th colspan='6' style='text-align: left;'>Payment Receipt</th>");
                html.Append("</tr>");
                html.Append("</thead>");
                html.Append("<tbody>");
                html.Append("<tr>");
                html.Append("<td colspan='4' style='text-align: right; width: 70%; border-right: none;'>");
                html.Append("<p><b>Receipt No:</b></p>");
                html.Append("</td>");
                html.Append("<td colspan='2' style='width: 30%; border-left: none;'>");
                html.Append("<p><b>" + PaymentHistoryList[0].ReceiptNo + "</b></p>");
                html.Append("</td>");
                html.Append("</tr>");
                html.Append("<tr>");
                html.Append("<td colspan='4' style='text-align: right; width: 70%; border-right: none;'>");
                html.Append("<p><b>Receipt Date:</b></p>");
                html.Append("</td>");
                html.Append("<td colspan='2' style='width: 30%; border-left: none;'>");
                html.Append("<p><b>" + PaymentHistoryList[0].CreatedDate + "</b></p>");
                html.Append("</td>");
                html.Append("</tr>");
                html.Append("<tr>");
                html.Append("<td colspan='6' style='text-align: left;'>");
                html.Append("<p><b>Invoice No: " + PaymentHistoryList[0].InvoiceNo + "</b></p>");
                html.Append("</td>");
                html.Append("</tr>");
                html.Append("<tr>");
                html.Append("<td colspan='3' style='width: 50%;'>");
                html.Append("<p><b>Name Mr./Mrs.:" + PaymentHistoryList[0].CustomerName + "</b></p>");
                html.Append("</td>");
                html.Append("<td colspan='3' style='width: 50%;'>");
                html.Append("<p><b>Address:" + PaymentHistoryList[0].Address + "</b></p>");
                html.Append("</td>");
                html.Append("</tr>");
                html.Append("<tr>");
                html.Append("<td colspan='3' style='width: 50%;'>");
                html.Append("<p><b>Email Id:" + PaymentHistoryList[0].EmailId + "</b></p>");
                html.Append("</td>");
                html.Append("<td colspan='3' style='width: 50%;'>");
                html.Append("<p><b> Mobile No: " + PaymentHistoryList[0].MobileNo + "</b></p>");
                html.Append("</td>");
                html.Append("</tr>");
                html.Append("</tbody>");
                html.Append("<tbody>");
                html.Append("<tr>");
                html.Append("<td style='width: 5%; text-align: center;'><b>#</b></td>");
                html.Append("<td style='width: 35%; text-align: center;'><b>Bank Name</b></td>");
                html.Append("<td style='width: 20%; text-align: center;'><b>Payment Mode</b></td>");
                html.Append("<td style='width: 10%; text-align: center;'><b>Transaction No</b></td>");
                html.Append("<td style='width: 10%; text-align: center;'><b>Transaction Date</b></td>");
                html.Append("<td style='width: 20%; text-align: center;'><b>Paid Amount</b></td>");
                html.Append("</tr>");
                if (PaymentHistoryList.Count > 0)
                {
                    int i = 1;
                    foreach (var item in PaymentHistoryList)
                    {
                        html.Append("<tr>");
                        html.Append("<td style='text-align: center; '>" + i + "</td>");
                        html.Append("<td style='text-align: center; '>" + item.BankName + "</td>");
                        html.Append("<td style='text-align: center; '>" + item.PaymentModeName + "</td>");
                        html.Append("<td style='text-align: center; '>" + item.TransactionNo + "</td>");
                        html.Append("<td style='text-align: center; '>" + item.ReceivableDate + "</td>");
                        html.Append("<td style='text-align: right; '>" + item.PaidAmount + "</td>");
                        html.Append("</tr>");
                        i++;
                    }
                }

                html.Append("</tbody>");
                html.Append("<tbody>");
                html.Append("<tr>");
                html.Append("<td colspan='4' style='width: 40%; border-right: none;'>");
                html.Append("<p><b>Terms and Conditions</b></p>");
                html.Append("<p>Thank you for your business. We do expect payment within 21 days, so please process this invoice within that time. There will be a 1.5% interest charge per month on late invoices.html.Append</p>");
                html.Append("</td>");
                html.Append("<td style='width: 30%; text-align: right; border-right: none; border-left: none; '>");
                html.Append("<p>Sub - Total amount:</p>");
                html.Append("<p>GST:</p>");
                html.Append("<p>Grand Total:</p>");
                html.Append("</td>");
                html.Append("<td style='width: 30%; border-left: none;'>");
                html.Append("<p style='text-align: right;'><b>" + PaymentHistoryList[0].PaidAmount + "/-</b></p>");
                html.Append("<p style='text-align: right;'><b>15%</b></p>");
                html.Append("<p style='text-align: right;'><b>" + PaymentHistoryList[0].PaidAmount + "/-</b></p>");
                html.Append("</td>");
                html.Append("</tr>");
                html.Append("</tbody>");
            }
            html.Append("</table>");

            html.Append("</body></html>");


            Byte[] bytes;
            StringReader sr = new StringReader(html.ToString());
            using (ms = new MemoryStream())
            {
                using (var doc = new Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 10f))
                {
                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {
                        doc.Open();

                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, sr);

                        doc.Close();
                    }
                }
                bytes = ms.ToArray();
            }
            // string FilePath = path + "//test1.pdf";
            // System.IO.File.WriteAllBytes(FilePath, bytes);
            return ms;
        }

        #endregion



        //public void InsertFitDetails(List<BookingCartDetailsInfo> fitDetailList, BookingCartDetailsInfo bookingCartDetailsInfo)
        //{
        //    foreach (var item in fitDetailList)
        //    {
        //        List<SqlParameter> sqlParams = new List<SqlParameter>();
        //        sqlParams.Add(new SqlParameter("@BookingId", item.BookingId));
        //        sqlParams.Add(new SqlParameter("@QuotationId", item.QuatationId));
        //        sqlParams.Add(new SqlParameter("@PackageTypeId", item.PackageTypeId));
        //        sqlParams.Add(new SqlParameter("@ProductType", item.ProductType));
        //        sqlParams.Add(new SqlParameter("@PackageName", item.PackageName));
        //        sqlParams.Add(new SqlParameter("@PackageDuration", item.Duration));
        //        sqlParams.Add(new SqlParameter("@Location", item.Destination));
        //        sqlParams.Add(new SqlParameter("@CategoryId", item.CategoryId));

        //        sqlParams.Add(new SqlParameter("@FromDate", item.FromDate == DateTime.MinValue ? null : item.FromDate.ToString()));

        //        sqlParams.Add(new SqlParameter("@ToDate", item.ToDate == DateTime.MinValue ? null : item.ToDate.ToString()));

        //        sqlParams.Add(new SqlParameter("@NetRate", item.NetRate));
        //        sqlParams.Add(new SqlParameter("@QuoteRate", item.QuoteRate));
        //        sqlParams.Add(new SqlParameter("@CreatedDate", bookingCartDetailsInfo.CreatedDate));
        //        sqlParams.Add(new SqlParameter("@CreatedBy", bookingCartDetailsInfo.CreatedBy));
        //        sqlParams.Add(new SqlParameter("@UpdatedBy", bookingCartDetailsInfo.UpdatedBy));
        //        sqlParams.Add(new SqlParameter("@UpdatedDate", bookingCartDetailsInfo.UpdatedDate));
        //        _sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spInsertPackageDetails.ToString(), CommandType.StoredProcedure);
        //    }

        //}


    }
}
