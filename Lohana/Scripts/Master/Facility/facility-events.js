$(document).ready(function () {

    GetFacilities();

    $(document).on('change', "[name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetFacilityValues($(this));

            SetActive($("[name='Facility.IsActive']"), $(this).attr("data-isactive"));
        }

    });

    $("#btnSaveFacility").click(function () {

        if ($("#frmFacility").valid()) {

            SaveFacility();
        }

    });

    $("#btnSearchFacility").click(function () {

        $("#tblFacility").attr("data-current-page", "0");

        GetFacilities();

    });

    $("#btnResetFacility").click(function ()
    {
        document.getElementById("frmSearchFacility").reset();

        ResetFacility();
    });

});


