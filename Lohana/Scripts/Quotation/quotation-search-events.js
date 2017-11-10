$(document).ready(function () {

    $("#btnEditQuotation").click(function () {
        $("#frmSearchQuotation").attr("action", "/Quotation/GetEnquiryById");
        $("#frmSearchQuotation").submit();
    });

});
