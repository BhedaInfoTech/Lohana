$(document).ready(function () {

    //GetHotelTariffRoom();

    $("#divAgeFromTo").hide();

    $(document).on('change', "#tblHotelTariffRoomOccupancy [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetHotelTariffRoomOccupancyValues($(this));

            var id = $(this).attr("data-hoteltariffroomoccupancyid");
            
            $("#hdnSearchHotelTariffRoomOccupancyId").val(id);

            $("#btnDeleteHotelTariffRoomOccupancy").removeAttr("disabled");

            GetHotelTariffPrice();

            GetHotelTariffDuration($("#dvcalendar"));
        }

    });

    $("#btnAddHotelTariffRoomOccupancy").click(function () {

        if ($("#frmHotelTariffRoomOccupancy").valid()) {

            SaveHotelTariffRoomOccupancy();
        }
    });

    $("#btnDeleteHotelTariffRoomOccupancy").click(function () {

        DeleteRoomOccupancy();
    });


    $("#btnResetHotelTariffRoomOccupancy").click(function () {

        document.getElementById("frmHotelTariffRoomOccupancy").reset();

        $("#hdnSearchHotelTariffRoomOccupancyId").val('');

    });


    $(document).on('change', "#drpOccupancy", function (event) {

    	var ocuupencyType = GetAutocompleteExtraParamValue("OccupancyType", $(this));
    	 
    	if (ocuupencyType == 1)
        {
            $("#divAgeFromTo").hide();           
        }
        else
        {
            $("#divAgeFromTo").show();
        }

    });



});