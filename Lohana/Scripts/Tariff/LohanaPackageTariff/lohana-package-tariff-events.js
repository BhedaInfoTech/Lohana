$(document).ready(function () {

    GetBasic();

    $(document).on('change', "#tblLohanaPackageTariff [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetBasicValues($(this));

            var id = $(this).attr("data-lohanapackagetariffid");

            $("#hdnLohanaPackageTariffId").val(id);

            SetActive($("[name='LohanaPackageTariff.IsActive']"), $(this).attr("data-isactive"));

            GetRootDayWiseList(id);

        }

    });

    $("#btnAddBasic").click(function () {

        if ($("#frmLohanaPackageTariffBasic").valid()) {

            SaveBasic();
        }
    });

    $("#btnSearchBasic").click(function () {

        $("#tblLohanaPackageTariff").attr("data-current-page", "0");

        GetBasic();

    });
    $("#btnResetBasic").click(function () {

        document.getElementById("frmLohanaPackageTariffBasic").reset();

        $("#hdnLohanaPackageTariffId").val('');

        GetBasic();

    });
    $("#txtNightduration").on('change', function () {

        var days = parseInt($("#txtNightduration").val()) + 1;

        $("#txtDayduration").val(days);
    });
});