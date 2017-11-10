$(document).ready(function () {


    // On selecting "Publish Price"
    $("input.publishprice").on('change', function () {
        if ($("#frmSightSeeingTariffPrice").valid()) {
            displayCommision();
        }

        if ($("#drpFormula").val() != "") {
            CalculatePrice()
        }

    });

    // On selecting "Special Price"
    $("input.specialprice").on('change', function () {
        if ($("#frmSightSeeingTariffPrice").valid()) {
            displayCommision();
        }

        if ($("#drpFormula").val() != "") {
            CalculatePrice()
        }

    });

    // On selecting formula dropdown
    $("#drpFormula").on('change', function () {

        LoadTaxFormulaCharges($("#drpFormula").val(), $("#hdnSightSeeingTariffPriceId").val());
    });

    $(document).on("change", "[name='rdSightSeeingTariffPrice']", function () {
        $("[name='SightSeeingTariffPrice.SightSeeingTariffPriceId']").val($(this).attr("data-sightseeingtariffpriceid"));

        GetSightSeeingTariffPriceById();
        //LoadTaxFormulaCharges($("#drpFormula").val(), $("#hdnHotelTariffPriceDetailsId").val());
    });

});
