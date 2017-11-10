using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LohanaBusinessEntities.Transaction;

namespace LohanaBusinessEntities
{
    public class PayableInfo
    {
        public PayableInfo()
        {
            PayableHistoryInfo = new PayableHistoryInfo();
            PayableHistoryList = new List<PayableHistoryInfo>();
            TransactionInfo = new TransactionInfo();
        }

        public int PayableId { get; set; }
        public int BookingId { get; set; }
        public string BookingNo { get; set; }
        public int ProductId { get; set; }
        public int VendorId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public string VendorName { get; set; }
        public string ProductName { get; set; }
        public PayableHistoryInfo PayableHistoryInfo { get; set; }
        public List<PayableHistoryInfo> PayableHistoryList { get; set; }
        public string ReceiptNo { get; set; }
        public decimal TotalAmountPaid { get; set; }

      
        public TransactionInfo TransactionInfo { get; set; }
    }

    public class PayableHistoryInfo
    {
        public string PaymentModeName;
        public string PaymentStatus { get; set; }
        public string ReceiptNo { get; set; }
        public int PayableHistoryId { get; set; }
        public int PayableId { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal TotalAmountPaid { get; set; }

        public int ModeOfPayment { get; set; }
        public DateTime PayableDate { get; set; }
        public decimal BalanceAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }

        public DateTime Cheque_Date
        {
            get;
            set;
        }

        public string Cheque_No
        {
            get;
            set;
        }

        public string BankName
        {
            get;
            set;
        }

        public string Credit_Card_No
        {
            get;
            set;
        }

        public string Transaction_No
        {
            get;
            set;
        }

        public string Debit_Card_No
        {
            get;
            set;
        }

        public string TransactionModeNo { get; set; }
    }
}

