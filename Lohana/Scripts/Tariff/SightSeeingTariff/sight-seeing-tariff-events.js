$(document).ready(function () {

    GetAutocompleteScript("Sight Seeing Tariff");

    

    GetSightSeeingTariffBasic();

    $(document).on('change', "#tblSightSeeingTariffBasic [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetSightSeeingTariffValues($(this));


            var id = $(this).attr("data-SightSeeingTariffId");

            $("#hdnSearchSightSeeingTariffId").val(id);

        }

    });

    $("#btnAddSightSeeingTariffBasic").click(function () {

        if ($("#frmSightSeeingTariffBasic").valid()) {

            SaveSightSeeingTariffBasic();
        }
    });

    $("#btnSearchSightSeeingTariffBasic").click(function () {

        $("#tblSightSeeingTariffBasic").attr("data-current-page", "0");

        GetSightSeeingTariffBasic();

    });

    $("#btnResetSightSeeingTariffBasic").click(function () {

        ResetBasic();

    });

    $("#btnCustomerCategories").click(function () {

        LoadParentModal("/SightSeeingTariff/GetCustomerCategoryByOccupencyIdTariffDate", { sightseeingTariffOccupancyId: $("[name='SightSeeingTariffDates.SightSeeingTariffOccupancyId']").val(), tariffDate: $("[name='SightSeeingTariffDates.TariffDate']").val() }, null, "Customer Categories", "ti-view-list-alt");
    });
})