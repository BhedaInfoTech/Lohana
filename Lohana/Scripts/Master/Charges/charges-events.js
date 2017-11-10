$(document).ready(function () {

    GetCharges();
  
    $(document).on('change', "[name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetChargesValues($(this));

            SetActive($("[name='Charges.IsActive']"), $(this).attr("data-isactive"));
        }

    });

    $("#btnSaveCharges").click(function () {

        if ($("#frmCharges").valid()) {
            SaveCharges();
        }

    });

    $("#btnSearchCharges").click(function () {

        $("#tblCharges").attr("data-current-page", "0");

        if ($("#frmSearchCharges").valid()) {
            GetCharges();
        }

    });



    $("#btnResetCharges").click(function () {
        document.getElementById("frmSearchCharges").reset();

        ResetCharges();
    });
});
