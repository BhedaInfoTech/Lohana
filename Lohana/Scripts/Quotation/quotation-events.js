$(document).ready(function () {

      
    $("#frmQuotationBasic").validate();

    $(document).on('change', "[name='IsApproval']", function (event) {

        if ($(this).prop('checked')) {

            alert(2); 
            SetActive($("[name='IsApproval']"), $(this).attr("data-isactive"));
        }
    });

    if ($("[name='Quotation.QuotationId']").val() == 0)
    {
         
        $("[name='Quotation.FollowupDate']").rules('add', { required: true });
        $("[name='Quotation.AssigneeToId']").rules('add', { required: true });
        $(".DivQoutation").hide();
    }
    else
    {
        $("[name='Quotation.FollowupDate']").rules('add', { required: false });
        $("[name='Quotation.AssigneeToId']").rules('add', { required: false });
        $(".DivQoutation").show();
    }

    GetEnquiryItemDetailsView();

    $('#datepicker-autoclose').datepicker({
        autoclose: true,
        todayHighlight: true
    });

    $("#btnSave").click(function () {
        InsertOrUpdateQuotation(); 
    });
});