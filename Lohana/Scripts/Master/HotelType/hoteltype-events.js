/// <reference path="../../jquery.uploadify.js" />

$(document).ready(function () {

    GetHotelType();

    $(document).on('change', "[name='c1']", function (event) {

        if ($(this).prop('checked')) {
            GetSetHotelTypeValues($(this));

            SetActive($("[name='HotelTypeInfo.IsActive']"), $(this).attr("data-isactive"));
        }
    });

    $("#btnSaveHotelType").click(function () {

        if ($("#frmHotelType").valid()) {
            SaveHotelType();
        }

    });

    $("#btnSearchHotelType").click(function () {

        $("#tblHotelType").attr("data-current-page", "0");

        GetHotelType();



    });

    $("#btnResetHotelType").click(function () {
        ResetHotelType();
    });

});
