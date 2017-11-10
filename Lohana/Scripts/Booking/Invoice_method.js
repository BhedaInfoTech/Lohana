
function GetBookingList() {

    var bViewModel =
		{
		    BookingCartDetailsInfo: {

		        CustomerName: $("[name='BookingCartDetailsInfo.CustomerName']").val(),

		        BookingNo: $("[name='BookingCartDetailsInfo.BookingNo']").val(),

		    },
		    Pager: {

		        CurrentPage: $('#tblCustomerBookingList').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/Booking/GetBookingList", bViewModel, BindCustomers);
}

function BindCustomers(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["CustomerName", "BookingNo", "InvoiceNo", "TotalAmount", "UnpaidAmount", "PaymentStatus"],
        primayKey: "BookingId",
        hiddenFields: ["BookingId", "CustomerId", "BookingNo", "UnpaidAmount"],
        headerNames: ["Customer Name", "Booking No", "Invoice No", "Total Amount", "Unpaid Amount", "Payment Status"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblCustomerBookingList'));

    BindPagination(list.Pager, $('#tblCustomerBookingList'));
}

function Pagination(CurrentPage) {
    
    if ($("#hdnFlg").val() == "true")
    {
        $('#tblPaymentHistoryList').attr("data-current-page", CurrentPage);

        GetPaymentHistory();
    }
    else
    {
        $('#tblCustomerBookingList').attr("data-current-page", CurrentPage);

        GetBookingList();

        document.getElementById("btnViewInvoice").disabled = true;
    } 
}


function ChangeUnpaidAmount() {

    var paidAmount = $("#txtpaidAmount").val(); 

    var hdnunpaidAmount = $("#hdnUnpaidPayment").val();

    hdnunpaidAmount = hdnunpaidAmount - paidAmount;

    $("#txtunpaidAmount").text(hdnunpaidAmount);
  
}


function AddPayment() {

    LoadModal("/Booking/GetBookingById", { BookingNo: $("#hdnbookingNo").val(), UnpaidAmount: $("#hdnunpaidAmount").val(), BookingId: $("#hdnBookingId").val() }, null, "Add Payment Details", null);
    GetPaymentHistory();
}

function BtnAdd() {

    $("#hdnUnpaidPayment").val($("#txtunpaidAmount").text());

    var bViewModel =
		{
		    PaymentDetailsInfo: {

		        BookingId: $("[name='PaymentDetailsInfo.BookingId']").val(),

		        ChequeDate: $("[name='PaymentDetailsInfo.ChequeDate']").val(),

		        ReceivableDate: $("[name='PaymentDetailsInfo.ReceivableDate']").val(),

		        BookingNo: $("[name='PaymentDetailsInfo.BookingNo']").val(),

		        PaymentMode: $("[name='PaymentDetailsInfo.PaymentMode']").val(),

		        TransactionNo: $("[name='PaymentDetailsInfo.TransactionNo']").val(),

		        BankName: $("[name='PaymentDetailsInfo.BankName']").val(),

		        PaymentType: $("[name='PaymentDetailsInfo.PaymentType']").val(),

		        PaidAmount: $("[name='PaymentDetailsInfo.PaidAmount']").val(),

		        UnpaidAmount: $("[name='PaymentDetailsInfo.UnpaidAmount']").val(),

		    },
		    Pager: {

		        CurrentPage: $('#tblCustomerBookingList').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/Booking/AddCustomerPayment", bViewModel, AfterSave);
}

function AfterSave(data) {
   
    FriendlyMessage(data);

    ResetPaymentDetails();

    GetPaymentHistory();

    GetBookingList();
    
}

function ResetPaymentDetails() {

    $("#txtBankName").val("");

    $("#drpPaymentMode").val("0");

    $("#txtPaymentDate").val("");

    $("#txtInstrumentNo").val("");

    $("#txtChequeDate").val("");

    $("#txtpaidAmount").val(0);
}

function GetPaymentHistory() {

    var bViewModel =
       {
           PaymentDetailsInfo: {

               BookingId: $("#hdnBookingId").val(),
           },
           Pager: {

               CurrentPage: $('#tblPaymentHistoryList').attr("data-current-page"),
           },
       }
    PostAjaxWithProcessJson("/Booking/GetPaymentHistoryListing", bViewModel, BindPaymentList);

}

function BindPaymentList(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["BankName", "PaymentMode", "TransactionNo", "ReceivableDate", "PaidAmount"],
        primayKey: "PaymentReceivableId",
        hiddenFields: ["PaymentReceivableId", "BookingId"],
        headerNames: ["Bank Name", "Payment Mode", "Transaction No", "Receivable Date", "Paid Amount"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblPaymentHistoryList'));

    BindPagination(list.Pager, $('#tblPaymentHistoryList'));
}

function ViewPaymentReceipt() {
   
    $("#hdnPaymentReceivableId").val();
    $("#hdnBookingForAddPaymentId").val();    
    $("#frmSearchReceivablePayment").attr("target", "_blank");
    $("#frmSearchReceivablePayment").attr("action", "/Booking/ViewReceipt");
    $("#frmSearchReceivablePayment")[0].submit();
    $("#frmSearchReceivablePayment").attr("target", "_self");

}

function downloadpdf_Invoice() {

    $("#hdnBookId").val();
    
    $("#frmGenerateInvoice").attr("action", "/Booking/Invoice_DownloadPDF")

    $("#frmGenerateInvoice").submit();
}

function downloadpdf_Receipt() {

    $("#hdnBook_Id").val();
    
    $("#hdnPaymentReceivableId").val();

    $("#frmPaymentReceipt").attr("action", "/Booking/Receipt_DownloadPDF")

    $("#frmPaymentReceipt").submit();


}


