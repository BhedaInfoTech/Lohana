function GetPayable() {
   
    var pViewModel =
		{
		    PayableInfo: {

		        VendorName: $("[name='PayableInfo.VendorName']").val(),

		        BookingNo: $("[name='PayableInfo.BookingNo']").val(),

		        ProductId: $("[name='PayableInfo.ProductId']").val(),

		        PaymentStatus: $("[name='PayableInfo.PaymentStatus']").val(),
		    },
		    Pager: {
		        CurrentPage: $('#tblPayable').attr("data-current-page"),
		    },
		}
    PostAjaxJson("/Payable/GetPayable", pViewModel, BindPayables);
}

function BindPayables(data) {
   
    var list = JSON.parse(data);  
    var kTable = {
        dataList: ["BookingNo", "VendorName", "ProductName", "NetRate", "TotalPaidPayment", "paymentstatus"],
        primayKey: "BookingId",
        hiddenFields: ["BookingId"],
        headerNames: ["BookingNo", "VendorName", "ProductName", "TotalAmount", "PaidAmount", "PaymentStatus"],
        data: list.dt,       
    } 
    buildHtmlTable(kTable, $('#tblPayable'));

    BindPagination(list.Pager, $('#tblPayable'));
}

function Pagination(CurrentPage) {
   
    $('#tblPayable').attr("data-current-page", CurrentPage);

    GetPayable();

   document.getElementById("btnPayablrCustomer").disabled = true;

}

