$(document).ready(function () {


    $("#btnSaveSightSeeingTariffPrice").click(function () {

        if ($("#frmSightSeeingTariffPrice").valid()) {

            SaveSightSeeingTariffPrice();
        }
    });

    $("#btnSightSeeingTariffPriceDuration").click(function () {
        LoadParentModal("/SightSeeingTariff/GetSightSeeingTariffDuration", { sightseeingTariffPriceId: 0 }, null, "Duration Details & Customer Categories", "ti-view-list-alt");
    });

    $('#dvColorPicker').colorpicker(
		{
		    format: 'hex'
		}
		);

});
