$(document).ready(function () {

	 
    $("#btnSaveHotelTariffPrice").click(function () {

        if ($("#frmHotelTariffPrice").valid()) {

            SaveHotelTariffPrice();
        }
    });

    $("#btnHotelTariffPriceDuration").click(function ()
    {
        debugger

    	LoadParentModal("/HotelTariff/GetHotelTariffDuration", { hotelTariffPriceDetailsId: 0 }, null, "Duration Details & Customer Categories", "ti-view-list-alt");
    });

    $('#dvColorPicker').colorpicker(
		{
			format: 'hex'
		}
		);

});
