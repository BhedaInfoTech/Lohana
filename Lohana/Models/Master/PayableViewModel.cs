using LohanaBusinessEntities;
using LohanaBusinessEntities.Country;
using LohanaBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lohana.Models.Common;
using LohanaBusinessEntities.Transaction;


namespace Lohana.Models.Master
{
    public class PayableViewModel
    {
        public PayableViewModel()
        {
            Pager = new PaginationInfo();
            FriendlyMessage = new List<FriendlyMessage>();
            PayableInfo = new PayableInfo();
            PayableList = new List<PayableInfo>();
            PayableHistoryInfo = new PayableHistoryInfo();
            PayableHistoryList = new List<PayableHistoryInfo>();
            TransactionInfo = new TransactionInfo();
        }
        public List<PayableHistoryInfo> PayableHistoryList { get; set; }
        public PayableHistoryInfo PayableHistoryInfo { get; set; }
        public PayableInfo PayableInfo { get; set; }
        public List<PayableInfo> PayableList { get; set; }
        public PaginationInfo Pager { get; set; }
        public List<FriendlyMessage> FriendlyMessage { get; set; }
        public TransactionInfo TransactionInfo { get; set; }
    }
}