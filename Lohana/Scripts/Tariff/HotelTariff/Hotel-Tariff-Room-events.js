$(document).ready(function () {

    //GetHotelTariffRoom();

    $("#divAgeFromTo").hide();

    $(document).on('change', "#tblHotelTariffRoomDetails [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetHotelTariffRoomValues($(this));

            var id = $(this).attr("data-hoteltariffroomdetailsid");
            
            $("#hdnSearchHotelTariffRoomDetailsId").val(id);

            $("#btnDeleteHotelTariffRoom").removeAttr("disabled");

           // GetHotelTariffDuration($("#dvcalendar"));
        }

    });

    $("#btnAddHotelTariffRoom").click(function () {

        if ($("#frmHotelTariffRoom").valid()) {

            SaveHotelTariffRoom();
        }
    });

    $("#btnDeleteHotelTariffRoom").click(function () {

        DeleteRoom();
    });


    $("#btnResetHotelTariffRoom").click(function () {

        document.getElementById("frmHotelTariffRoom").reset();

        $("#hdnSearchHotelTariffRoomDetailsId").val('');

    });


    //$(document).on('change', "#drpOccupancy", function (event) {

    //	var ocuupencyType = GetAutocompleteExtraParamValue("OccupancyType", $(this));

    //	if (ocuupencyType == 1)
    //    {
    //        $("#divAgeFromTo").hide();           
    //    }
    //    else
    //    {
    //        $("#divAgeFromTo").show();
    //    }

    //});



});