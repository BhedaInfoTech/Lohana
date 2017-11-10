$(document).ready(function () {

	GetAutocompleteScript("Hotel Tariff");

	GetHotelTariffBasic();

	

    $(document).on('change', "#tblHotelTariff [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetHotelTariffValues($(this));
           

            var id = $(this).attr("data-hoteltariffid");

            $("#hdnSearchHotelTariffId").val(id);

        }

    });

    $("#btnAddHotelTariffBasic").click(function () {

        if ($("#frmHotelTariffBasic").valid()) {

            SaveHotelTariffBasic();
        }
    });

    $("#btnSearchHotelTariffBasic").click(function () {

        $("#tblHotelTariff").attr("data-current-page", "0");

            GetHotelTariffBasic();
        
    });

    $("#btnResetTariffBasicDetails").click(function () {

    	ResetBasic();

    });

    $("#btnCustomerCategories").click(function () {
        
        LoadParentModal("/HotelTariff/GetCustomerCategoryByOccupencyIdTariffDate", { hotelTariffRoomOccupancyId: $("[name='HotelTariffDates.HotelTariffRoomOccupancyId']").val(), tariffDate:$("[name='HotelTariffDates.TariffDate']").val() }, null, "Customer Categories", "ti-view-list-alt");
    });


});