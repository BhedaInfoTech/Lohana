$(document).ready(function ()
{
 
    $('.switchery').trigger('true');

    if ($("[name='Customer.IsActive']").val() == 0 || $("[name='Customer.IsActive']").val() == "false") {
        $('.switchery').trigger('click');
    }

    else if ($("[name='Customer.IsActive']").val() == 1 || $("[name='Customer.IsActive']").val() == "true") {
        $('.switchery').trigger('click');
    }


    $("#btnSaveCustomer").click(function () {

        if ($("#frmCustomer").valid())
        {

            SaveCustomer();
        }

    });

    $("#btnResetCustomer").click(function () {

        document.getElementById("frmCustomer").reset();

        $("#hdnCustomerId").val("");
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