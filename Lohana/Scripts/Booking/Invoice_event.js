$(document).ready(function () {

    GetBookingList();

//    GetPaymentHistory();
     
    $('#txtPaymentDate').datepicker('setDate', new Date());

    $('#txtChequeDate').datepicker('setDate', new Date());
        
    $(document).on('change', "[name='c1']", function (event) {

        if ($(this).prop('checked')) {

            var id = $(this).attr("data-bookingid");

            $("#hdnBookingId").val(id);

            $("#hdnBookingForAddPaymentId").val(id);

            $("#hdnBookingForPaymentHistory").val(id);

            $("#hdnbookingNo").val($(this).attr("data-bookingno"));

            $("#hdnunpaidAmount").val($(this).attr("data-unpaidamount"));

            $("#btnAddPayment").attr("disabled", false);

            $("#btnPaymentHistory").attr("disabled", false);

            $("#btnViewInvoice").attr("disabled", false);
            
            $("#BtnViewReceipt").attr("disabled", false);

            $("#hdnPaymentReceivableId").val($(this).attr("data-paymentreceivableid"));
            
        }

    });



    $("#btnSearchReceivablePaymentCustomer").click(function () {

        $("#tblCustomerBookingList").attr("data-current-page", "0");

        GetBookingList();
    });

    $("#btnViewInvoice").click(function () {

        $("#frmSearchReceivablePayment").attr("action", "/Booking/GetInvoiceDetails");

        $("#frmSearchReceivablePayment").submit();

    });
       

    $("#btnInvoicePrint").click(function () {
        $("#paymentTblPrint").printElement();
        //printDiv();
        //$("#hdnChkFlag").val(true);
       // $("#hdnBookId").val()
       //// alert($("#hdnBookId").val());
       // $("#frmGenerateInvoice").attr("target", "_blank");
       // $('#frmGenerateInvoice').attr("action", "/Booking/GenerateInvoicePrintPreview");
       // $('#frmGenerateInvoice').attr("method", "POST");
       // $('#frmGenerateInvoice').submit();

    });

    //function printDiv() {
       
    //    var divToPrint = document.getElementById('divInvoiceBasicDetails111');

    //    var newWin = window.open('', 'Print-Window');

    //    newWin.document.open();

    //    newWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');

    //    newWin.document.close();

    //    setTimeout(function () { newWin.close(); }, 10);

    //}

    $("#btnReceiptPrint").click(function () {
        $("#receipttblPrint").printElement();      
    });
      
});