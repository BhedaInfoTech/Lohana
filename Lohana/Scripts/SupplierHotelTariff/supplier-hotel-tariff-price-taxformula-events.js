

$(document).ready(function () {


    // On selecting "Publish Price"
    $("input.publishprice").on('change', function () {
        if ($("#frmSupplierHotelTariffPrice").valid()) {
            displayCommision();
        }

        if ($("#drpFormula").val() != "") {
            CalculatePrice()
        }

    });

    // On selecting "Special Price"
    $("input.specialprice").on('change', function () {
        if ($("#frmSupplierHotelTariffPrice").valid()) {
            displayCommision();
        }

        if ($("#drpFormula").val() != "") {
            CalculatePrice()
        }

    });

    // On selecting formula dropdown
    $("#drpFormula").on('change', function ()
    {
    	LoadTaxFormulaCharges($("#drpFormula").val(), $("[name='SupplierHotelPrice.SupplierHotelPriceId']").val());
    });

    $(document).on("change","[name='rdHotelTariffPrice']", function ()
    {
    	$("[name='SupplierHotelPrice.SupplierHotelPriceId']").val($(this).attr("data-supplierhoteltariffpriceid"));

    	GetHotelTariffPriceById();
    	//LoadTaxFormulaCharges($("#drpFormula").val(), $("#hdnHotelTariffPriceDetailsId").val());
    });
 
});
