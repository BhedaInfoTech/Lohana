$(document).ready(function () {
    document.getElementById("btnEditPayable").disabled = true;
   
    GetPayable();

    $(document).on('change', "[name='c1']", function (event) {
      
        if ($(this).prop('checked')) {
            var id = $(this).attr("data-bookingid");
            $("#hdnSearchPayableId").val(id);
            document.getElementById("btnEditPayable").disabled = false;
        }
    });

    $("#btnSearchPayable").click(function () {
     
        $("#tblPayable").attr("data-current-page", "0");
        GetPayable();
    });

    $("#btnEditPayable").click(function () {
      
        $("#frmSearchPayable").attr("action", "/Payable/GetBookingById");
        $("#frmSearchPayable").submit();
    });

    $("#btnResetPayable").click(function () {
     
        document.getElementById("frmSearchPayable").reset();
    });
});


