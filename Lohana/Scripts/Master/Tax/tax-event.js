$(document).ready(function () {
    
    if ($("[name='Tax.IsActive']").val() == 0 || $("[name='Tax.IsActive']").val() == "false") {
        $('.switchery').trigger('click');
    }

    else if ($("[name='Tax.IsActive']").val() == 1 || $("[name='Tax.IsActive']").val() == "true") {
        $('.switchery').trigger('click');
    }

    $("#btnSaveTax").click(function () {
        
        if ($("#frmTax").valid()) {

            SaveTax();
        }

    });

    $("#btnResetTax").click(function () {

        document.getElementById("frmTax").reset();

        $("#hdnTaxId").val("");
    });


    $(document).on("change", "input[type='checkbox']", function () {
        if ($(this).prop("checked")) {

            $(this).val(true);
        }
        else {

            $(this).val(false);
        }
    });


});



