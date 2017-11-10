

$(document).ready(function () {


    // On selecting "Publish Price"
    $("input.publishprice").on('change', function () {
        if ($("#frmHotelTariffPrice").valid()) {
            displayCommision();
        }

        if ($("#drpFormula").val() != "") {
            CalculatePrice()
        }

    });

    // On selecting "Special Price"
    $("input.specialprice").on('change', function () {
        if ($("#frmHotelTariffPrice").valid()) {
            displayCommision();
        }

        if ($("#drpFormula").val() != "") {
            CalculatePrice()
        }

    });

    // On selecting formula dropdown
    $("#drpFormula").on('change', function ()
    {

        LoadTaxFormulaCharges($("#drpFormula").val(),$("#hdnHotelTariffPriceDetailsId").val());
    });

    $(document).on("change","[name='rdHotelTariffPrice']", function ()
    {
    	$("[name='HotelTariffPrice.HotelTariffPriceDetailsId']").val($(this).attr("data-hoteltariffpriceid"));

    	GetHotelTariffPriceById();
    	//LoadTaxFormulaCharges($("#drpFormula").val(), $("#hdnHotelTariffPriceDetailsId").val());
    });
 
});
