function GetEnquiryItemDetailsView() {

   // alert("safsg");

    debugger;

    $("#dvQuotationEnquiryItem").load("/Quotation/GetEnquiryItemDetailsView", { EnquiryId: $("#hdnEnquiryId").val(), QuotationId: $("#hdnQuotationId").val(), IsApproval: $("#hdnIsApproval").val() }, null);


}

function ViewPackageData(rowId) {

    $("#hdnSearchPckgId").val(rowId);

    $("#frmQuotationBasic").attr("target", "_blank");
    $("#frmQuotationBasic").attr("action", "/Package/PackageView");
    $("#frmQuotationBasic")[0].submit();
    $("#frmQuotationBasic").attr("target", "_self");

} 

function InsertOrUpdateQuotation() {    
    
    var QuotationItem = [];       

    if ($("[name='IsApproval']").val() == true || $("[name='IsApproval']").val() == 'True') {
        debugger;
        $('#tblGitDetails > tbody  > tr').each(function () {
            if ($(this).find(".QuotationStatus").val() != undefined && $(this).find(".QuotationStatus").val() != 0 && $(this).find(".QuotationStatus").val() != '') {
                QuotationItem.push({
                    //QuotationItemId: $(this)[0].find("td:eq(0)").find("[id^='hdnQuotationGItId_']").val(),
                    QuotationItemId: $(this).find("td:eq(0)").find("[id^='hdnQuotationGItId_']").val(),
                    QuotationStatus: $(this).find(".QuotationStatus").val(),//.find("[id^='drpQuotationGItStatus_']").val(),
                    QuotationId: $("[name='Quotation.QuotationId']").val(),
                    Remark: $(this).find(".remark").val(),
                    //id: $(this).data('id-traduction')
                });
            }
        });
        $('#tblFitDetails > tbody  > tr').each(function () {
            if ($(this).find(".QuotationStatus").val() != undefined && $(this).find(".QuotationStatus").val() != 0 && $(this).find(".QuotationStatus").val() != '') {
                QuotationItem.push({
                    //QuotationItemId: $(this)[0].find("td:eq(0)").find("[id^='hdnQuotationGItId_']").val(),
                    QuotationItemId: $(this).find("td:eq(0)").find("[id^='hdnQuotationFitId_']").val(),
                    QuotationStatus: $(this).find(".QuotationStatus").val(),//.find("[id^='drpQuotationGItStatus_']").val(),
                    QuotationId: $("[name='Quotation.QuotationId']").val(),
                    Remark: $(this).find(".remark").val(),
                    //id: $(this).data('id-traduction')
                });
            }
        });
        $('#tblSptDetails > tbody  > tr').each(function () {
            if ($(this).find(".QuotationStatus").val() != undefined && $(this).find(".QuotationStatus").val() != 0 && $(this).find(".QuotationStatus").val() != '') {
                QuotationItem.push({
                    //QuotationItemId: $(this)[0].find("td:eq(0)").find("[id^='hdnQuotationGItId_']").val(),
                    QuotationItemId: $(this).find("td:eq(0)").find("[id^='hdnQuotationSptId_']").val(),
                    QuotationStatus: $(this).find(".QuotationStatus").val(),//.find("[id^='drpQuotationGItStatus_']").val(),
                    QuotationId: $("[name='Quotation.QuotationId']").val(),
                    Remark: $(this).find(".remark").val(),
                    //id: $(this).data('id-traduction')
                });
            }
        });
        $('#tblSightSeeingDetails > tbody  > tr').each(function () {
            if ($(this).find(".QuotationStatus").val() != undefined && $(this).find(".QuotationStatus").val() != 0 && $(this).find(".QuotationStatus").val() != '') {
                QuotationItem.push({
                    //QuotationItemId: $(this)[0].find("td:eq(0)").find("[id^='hdnQuotationGItId_']").val(),
                    QuotationItemId: $(this).find("td:eq(0)").find("[id^='hdnQuotationSightSeeingId_']").val(),
                    QuotationStatus: $(this).find(".QuotationStatus").val(),//.find("[id^='drpQuotationGItStatus_']").val(),
                    QuotationId: $("[name='Quotation.QuotationId']").val(),
                    Remark: $(this).find(".remark").val(),
                    //id: $(this).data('id-traduction')
                });
            }
        });
    }


    var qViewModel =
       {
           Quotation: {
               EnquiryId: $("[name='Enquiry.EnquiryId']").val(),
               QuotationId: $("[name='Quotation.QuotationId']").val(),
               FollowupDate: $("[name='Quotation.FollowupDate']").val(),
               AssigneeToId: $("[name='Quotation.AssigneeToId']").val(),
           },
           IsApproval: $("[name='IsApproval']").val(),
           QuotaionItems: QuotationItem,
       }
    debugger;
    if ($("[name='Quotation.QuotationId']").val() != 0) {
        //$("#frmQuotationBasic").attr("action", "/Quotation/Update");
        PostAjaxJson("/Quotation/Update", qViewModel, AfterSave);
    }
    else {
        //$("#frmQuotationBasic").attr("action", "/Quotation/Insert");
        PostAjaxJson("/Quotation/Insert", qViewModel, AfterSave);
    }
}

function AfterSave(data) {
    FriendlyMessage(data);
    $("#hdnQuotationId").val(data.Quotation.QuotationId);
    GetEnquiryItemDetailsView();
}