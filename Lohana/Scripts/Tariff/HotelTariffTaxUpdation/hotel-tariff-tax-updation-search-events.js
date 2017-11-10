var HotelTariffUpdateChargesList = [];

$(document).ready(function () {

    GetHotelTariffTax();

    $("#btnSearchHotelTariffTax").click(function () {

        $("#tblSearchHotelTariffTaxDetails").attr("data-current-page", "0");

        GetHotelTariffTax();
    });

    $(document).on('click', "#tblHotelTariffTaxDetails  [name='ViewTax']", function (event) {

        var hoteltariffid = $(this).attr("data-hoteltariffid");

        var hoteltariffpricedetailsid = $(this).attr("data-hoteltariffpricedetailsid");

        var hoteltariffroomdetailsid = $(this).attr("data-hoteltariffroomdetailsid");

        var hoteltariffdurationdetailsid = $(this).attr("data-hoteltariffdurationdetailsid");

        var formulaid = $(this).attr("data-formulaid");

        $("[name='HotelTariffPrice.HotelTariffId']").val(hoteltariffid);

        $("[name='HotelTariffPrice.HotelTariffPriceDetailsId']").val(hoteltariffpricedetailsid);

        $("[name='HotelTariffPrice.HotelTariffRoomDetailsId']").val(hoteltariffroomdetailsid);

        $("[name='HotelTariffPrice.HotelTariffDurationDetailsId']").val(hoteltariffdurationdetailsid);

        $("[name='HotelTariffPrice.FormulaId']").val(formulaid);

        $("#TaxChargesModal").modal('show');

        GetHotelTariffPrice();

    });

    // Update Tax

    $("#btnUpdateTaxFormula").click(function () {

        debugger;

        SaveTaxFormulaChargesCheckboxList();
        
    });

    $("#drpFormula").on('change', function () {

        LoadTaxFormulaCharges($("#drpFormula").val(), $("#hdnHotelTariffPriceDetailsId").val());
    });

    $("#drpFormulaUpdate").on('change', function () {
         
        LoadTaxFormulaChargesUpdate($("#drpFormulaUpdate").val());
    });

});


