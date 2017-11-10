function GetTask()
{
    var tViewModel =
        {
            Filter:
            {
                Object: $("#hdnFilter_Object").val(), 
            }, 
        }

}

/*function UpdateQuotaionStatus(taskId,quotationId, quotationStatus) {
    $("[name='TaskId']").val(taskId);
    $("[name='QuotationId']").val(quotationId);
    $("[name='QuotationStatus']").val(quotationStatus);

    $("#frmDashboard").removeAttr("target", "_blank");
    $("#frmDashboard").attr("action", "/Dashboard/UpdateQuotationStatus");
    $("#frmDashboard").submit();
}*/

function GetQuotaionDetail(enquiryId,quotationId) {
    
    $("[name='Enquiry.EnquiryId']").val(enquiryId);
    $("[name='Quotation.QuotationId']").val(quotationId);
    //$("[name='IsApproval']").val(true);
    $("#frmDashboard").removeAttr("target", "_blank");
    $("#frmDashboard").attr("action", "/Quotation/Index");
    $("#frmDashboard").submit();
    
}