
function SavePayble() {

    var url = "";
    if ($("[name='PayableInfo.PayableId']").val() == 0) {

        $("#frmpayble").attr("action", "/Payable/Insert");
    }
    else {

        $("#frmpayble").attr("action", "/Payable/Update");
    }
    $('#frmpayble').attr("method", "POST");

    $('#frmpayble').submit();
}


function AfterSave(data) {

    FriendlyMessage(data);
}

function BindPaymentList(data) {

    var list = JSON.parse(data);
    debugger
    var kTable = {
        dataList: ["PayableDate", "AmountPaid", "ReciptNo", "PaymentMode", "PaymentStatus", "TransactionDate"],
        primayKey: "PayableId",
        hiddenFields: ["PayableId", "BookingId", "TotalAmountPaid"],
        headerNames: [" Payable Date", "  Payable Amount", " ReciptNo", "Mode Of Payment", " Payment Status", "Cheque Date"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblPaymentHistoryList'));

    BindPagination(list.Pager, $('#tblPaymentHistoryList'));

    var totalamt = list.TotalAmountPaid;

    $('#txtTotalAmtPaid').val(totalamt);


}

function Pagination1(CurrentPage) {

    $('#tblPaymentHistoryList').attr("data-current-page", CurrentPage);

    GetPaymentHistory();
}

function ResetPayableInfo() {

    $("[name='PayableInfo.PayableInfoId']").val("");

    $("[name='PayableInfo.FirstName']").val("");

    $("[name='PayableInfo.MiddleName']").val("");

    $("[name='PayableInfo.LastName']").val("");

    $("#drpGender").val("0");

    $("[name='PayableInfo.DOB']").val("");

    $("[name='PayableInfo.EmailId']").val("");

    $("[name='PayableInfo.PhoneNo']").val("");

    $("[name='PayableInfo.MobileNo']").val("");

    $("[name='PayableInfo.PanNo']").val("");

    $("[name='PayableInfo.AadharCardNo']").val("");

    $("[name='PayableInfo.PassportNo']").val("");

    $("[name='PayableInfo.Address']").val("");

    $("#drpPayableInfoCategoryId").val("0");

    if ($("[name='PayableInfo.IsActive']").val() == 0 || $("[name='PayableInfo.IsActive']").val() == "false") {
        $('.switchery').trigger('click');
    }
}


