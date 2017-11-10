$(document).ready(function () {


    $("#btnSavePackageOtherDetails").click(function () {

        if ($("#frmPackageOtherDetails").valid()) {

            SavePackageOtherDetails();

            $(".nav-link").show();
        }

    });

    $("#btnResetPackageOtherDetails").click(function () {

        document.getElementById("frmPackageOtherDetails").reset();

        reset
    });




});