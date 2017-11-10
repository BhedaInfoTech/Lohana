$(document).ready(function () {

	
 
    $("#btnSaveHotelTariffPrice").click(function () {

        if ($("#frmSupplierHotelTariffPrice").valid()) {

        	SaveSupplierHotelTariffPrice();
        }
    });

    $("#btnHotelTariffPriceDuration").click(function () {
        LoadParentModal("/SupplierHotelTariff/GetSupplierHotelTariffDuration", { SupplierHotelPriceId: 0 }, null, "Duration Details & Customer Categories", "ti-view-list-alt");
    });

    $('#dvColorPicker').colorpicker(
		{
			format: 'hex'
		});

});
