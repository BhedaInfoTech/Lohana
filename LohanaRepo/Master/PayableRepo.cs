using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Transaction;
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


namespace LohanaRepo.Master
{
    public class PayableRepo
    {

        SQLHelperRepo _sqlHelper = null;

        public PayableRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        public DataTable GetPayable(string VendorsName, string BookingNo, int ProductId, string PaymentStatus, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();


            sqlParam.Add(new SqlParameter("@VendorName", VendorsName));

            sqlParam.Add(new SqlParameter("@ProductId", ProductId));

            sqlParam.Add(new SqlParameter("@BookingNo", BookingNo));

            sqlParam.Add(new SqlParameter("@PaymentStatus", PaymentStatus));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.GetPayblesList.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }

        public PayableInfo GetVendorDetailsById(int BookingId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            PayableInfo Payable = new PayableInfo();

            sqlParam.Add(new SqlParameter("@BookingId", BookingId));

            Logger.Debug("Payable Controller BookingId:" + BookingId);

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPayableById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Payable = GetVendorValues(dr);
                }
            }
            return Payable;
        }

        private PayableInfo GetVendorValues(DataRow dr)
        {

            PayableInfo Payable = new PayableInfo();
            if (!dr.IsNull("VendorId"))
                Payable.VendorId = Convert.ToInt32(dr["VendorId"]);

            if (!dr.IsNull("PayableId"))
                Payable.PayableId = Convert.ToInt32(dr["PayableId"]);

            if (!dr.IsNull("VendorName"))
                Payable.VendorName = Convert.ToString(dr["VendorName"]);

            if (!dr.IsNull("BookingId"))
                Payable.BookingId = Convert.ToInt32(dr["BookingId"]);

            if (!dr.IsNull("BookingNo"))
                Payable.BookingNo = Convert.ToString(dr["BookingNo"]);

            if (!dr.IsNull("ProductTypeId"))
                Payable.ProductId = Convert.ToInt32(dr["ProductTypeId"]);

            if (!dr.IsNull("ProductName"))
                Payable.ProductName = Convert.ToString(dr["ProductName"]);

            if (!dr.IsNull("NetRate"))
                Payable.TotalAmount = Convert.ToDecimal(dr["NetRate"]);

            if (!dr.IsNull("PayableDate"))
                Payable.PayableHistoryInfo.PayableDate = Convert.ToDateTime(dr["PayableDate"]);

            if (!dr.IsNull("ReciptNo"))
                Payable.ReceiptNo = Convert.ToString(dr["ReciptNo"]);

            if (!dr.IsNull("AmountPaid"))
                Payable.PayableHistoryInfo.AmountPaid = Convert.ToDecimal(dr["AmountPaid"]);

            return Payable;

        }

        public int InsertPayable(PayableInfo PayableInfo)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInPayable(PayableInfo), Storeprocedures.spInsertPayable.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInPayable(PayableInfo PayableInfo)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (PayableInfo.PayableId != 0)
            {
                sqlParam.Add(new SqlParameter("@PayableId", PayableInfo.PayableId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedDate", PayableInfo.CreatedDate));

                sqlParam.Add(new SqlParameter("@CreatedBy", PayableInfo.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@BookingId", PayableInfo.BookingId));

            Logger.Debug("Payable Controller BookingId:" + PayableInfo.BookingId);

            sqlParam.Add(new SqlParameter("@ProductId", PayableInfo.ProductId));

            Logger.Debug("Payable Controller ProductId:" + PayableInfo.ProductId);

            sqlParam.Add(new SqlParameter("@VendorId", PayableInfo.VendorId));

            Logger.Debug("Payable Controller VendorId:" + PayableInfo.VendorId);

            sqlParam.Add(new SqlParameter("@TotalAmount", PayableInfo.TotalAmount));

            Logger.Debug("Payable Controller TotalAmount:" + PayableInfo.TotalAmount);

            sqlParam.Add(new SqlParameter("@BalanceAmount", PayableInfo.BalanceAmount));

            Logger.Debug("Payable Controller BalanceAmount:" + PayableInfo.BalanceAmount);


            if (PayableInfo.TotalAmount == PayableInfo.BalanceAmount || PayableInfo.BalanceAmount == 0)
            {
                sqlParam.Add(new SqlParameter("@PaymentStatus", "Fully Paid"));

                Logger.Debug("Payable Controller PaymentStatus:" + PayableInfo.PaymentStatus);
            }
            else if (PayableInfo.TotalAmount > PayableInfo.BalanceAmount)
            {
                sqlParam.Add(new SqlParameter("@PaymentStatus", "Partially Paid"));

                Logger.Debug("Payable Controller PaymentStatus:" + PayableInfo.PaymentStatus);
            }
            sqlParam.Add(new SqlParameter("@UpdatedDate", PayableInfo.UpdatedDate));

            sqlParam.Add(new SqlParameter("@UpdatedBy", PayableInfo.UpdatedBy));

            return sqlParam;

        }

        public int InsertPayableHistory(PayableHistoryInfo PayableHistoryInfo, int PayableId)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInPayableHistory(PayableHistoryInfo, PayableId), Storeprocedures.spInsertPayableHistory.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInPayableHistory(PayableHistoryInfo PayableHistoryInfo, int PayableId)
        {
            PayableInfo PayableInfo = new PayableInfo();
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (PayableHistoryInfo.PayableHistoryId != 0)
            {
                sqlParam.Add(new SqlParameter("PayableHistoryId", PayableHistoryInfo.PayableHistoryId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedDate", PayableHistoryInfo.CreatedDate));

                sqlParam.Add(new SqlParameter("@CreatedBy", PayableHistoryInfo.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@PayableId", PayableId));

            Logger.Debug("Payable Controller PayableId:" + PayableId);

            sqlParam.Add(new SqlParameter("@AmountPaid", PayableHistoryInfo.AmountPaid));

            Logger.Debug("Payable Controller AmountPaid:" + PayableHistoryInfo.AmountPaid);

            sqlParam.Add(new SqlParameter("@ModeOfPayment", PayableHistoryInfo.ModeOfPayment));

            Logger.Debug("Payable Controller ModeOfPayment:" + PayableHistoryInfo.ModeOfPayment);

            sqlParam.Add(new SqlParameter("@PayableDate", PayableHistoryInfo.PayableDate));

            Logger.Debug("Payable Controller PayableDate:" + PayableHistoryInfo.PayableDate);

            sqlParam.Add(new SqlParameter("@ReciptNo", PayableHistoryInfo.ReceiptNo));

            Logger.Debug("Payable Controller ReceiptNo:" + PayableHistoryInfo.ReceiptNo);

            sqlParam.Add(new SqlParameter("@TransactionModeNo", PayableHistoryInfo.TransactionModeNo));

            Logger.Debug("Payable Controller TransactionModeNo:" + PayableHistoryInfo.TransactionModeNo);

            sqlParam.Add(new SqlParameter("@BankName", PayableHistoryInfo.BankName));

            Logger.Debug("Payable Controller BankName:" + PayableHistoryInfo.BankName);
       
            if (PayableHistoryInfo.Cheque_Date != DateTime.MinValue)
            {

                sqlParam.Add(new SqlParameter("@TransactionDate", PayableHistoryInfo.Cheque_Date));

                Logger.Debug("Payable Controller TransactionDate:" + PayableHistoryInfo.Cheque_Date);
            }
            else
            {

                sqlParam.Add(new SqlParameter("@TransactionDate", null));

                Logger.Debug("Payable Controller TransactionDate:" + null);


            }       

            sqlParam.Add(new SqlParameter("@UpdatedDate", PayableHistoryInfo.UpdatedDate));

            sqlParam.Add(new SqlParameter("@UpdatedBy", PayableHistoryInfo.UpdatedBy));

            return sqlParam;

        }

        public List<PayableHistoryInfo> GetPaymentHistoryForPayment(int BookingId)       
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            List<PayableHistoryInfo> payments = new List<PayableHistoryInfo>();

            sqlParam.Add(new SqlParameter("@BookingId", BookingId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetPaymentHistoryForPaybleList.ToString(), CommandType.StoredProcedure);           
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    payments.Add(GetPaymentHistoryDetailsValues(dr));
                }
            }
            return payments;
        }

        public PayableHistoryInfo GetPaymentHistoryDetailsValues(DataRow dr)
        {
            PayableHistoryInfo Info = new PayableHistoryInfo();

            if (!dr.IsNull("ReciptNo"))
                Info.ReceiptNo = Convert.ToString(dr["ReciptNo"]);

            if (!dr.IsNull("PaymentMode"))
                Info.PaymentModeName = Convert.ToString(dr["PaymentMode"]);

            if (!dr.IsNull("PaymentStatus"))
                Info.PaymentStatus = Convert.ToString(dr["PaymentStatus"]);

            if (!dr.IsNull("AmountPaid"))
                Info.AmountPaid = Convert.ToDecimal(dr["AmountPaid"]);

            if (!dr.IsNull("PayableDate"))
                Info.PayableDate = Convert.ToDateTime(dr["PayableDate"]);

            if (!dr.IsNull("TransactionModeNo"))
                Info.Transaction_No = Convert.ToString(dr["TransactionModeNo"]);

            return Info;
        }

        public void UpdatePayable(PayableInfo PayableInfo)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInPayable(PayableInfo), Storeprocedures.UpdateVendorPayable.ToString(), CommandType.StoredProcedure);
        }


    }
}
