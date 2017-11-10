
$(document).ready(function () {

    document.getElementById("btnEditEnquiry").disabled = true;

    $(document).on('change', "[name='c1']", function (event) {

        debugger;

        if ($(this).prop('checked')) {

            var id = $(this).attr("data-enquiryid");

            $("#hdnSearchEnquiryId").val(id);

            //alert($("#hdnSearchEnquiryId").val(id));

            document.getElementById("btnEditEnquiry").disabled = false;

        }

    });

    $("#btnSearchEnquiry").click(function () {

        $("#tblEnquiry").attr("data-current-page", "0");

        GetEnquiry();
    });

    GetEnquiry();

    $("#btnEditEnquiry").click(function () {
        $("#frmSearchEnquiry").attr("action", "/Enquiry/GetEnquiryById");
        $("#frmSearchEnquiry").submit();
    });


});

