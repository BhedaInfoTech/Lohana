using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LohanaBusinessEntities.Quotation;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Customer;


namespace Lohana.Models.Booking
{
    public class BookingViewModel
    {
        public QuotationInfo Quotation { get; set; }
        
        public QuotationInfo Cookies { get; set; }
        public List<CustomerInfo> Customers { get; set; }
        public BookingCartDetailsInfo BookingCartDetailsInfo { get; set; }
        public PaginationInfo Pager { get; set; }
        public List<BookingCartDetailsInfo> DocumentDetailsList { get; set; }
        public List<FriendlyMessage> FriendlyMessage { get; set; }
       
        public string cookiesdata { get; set; }
        public PaymentDetailsInfo PaymentDetailsInfo { get; set; }
        public List<PaymentDetailsInfo> PaymentHistoryList { get; set; }

        public BookingViewModel()
        {
            Quotation = new QuotationInfo();
           
            Cookies = new QuotationInfo();
            Customers = new List<CustomerInfo>();
            BookingCartDetailsInfo = new BookingCartDetailsInfo();
            Pager = new PaginationInfo();
            DocumentDetailsList = new List<BookingCartDetailsInfo>();
            FriendlyMessage = new List<FriendlyMessage>();
            PaymentDetailsInfo = new PaymentDetailsInfo();
            PaymentHistoryList= new List<PaymentDetailsInfo>();
            //cookiesdata = new HttpCookie();
        }
    }
}