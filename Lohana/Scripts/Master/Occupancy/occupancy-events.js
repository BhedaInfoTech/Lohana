$(document).ready(function () {

    GetOccupancies();

    $(document).on('change', "[name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetOccupancyValues($(this));

            SetActive($("[name='Occupancy.IsActive']"), $(this).attr("data-isactive"));
        }

    });

    $("#btnSaveOccupancy").click(function () {

        if ($("#frmOccupancy").valid()) {
            SaveOccupancy();
        }

    });

    $("#btnSearchOccupancy").click(function () {

        $("#tblOccupancy").attr("data-current-page", "0");

        GetOccupancies();
    });
   

    $("#btnResetOccupancy").click(function () {
        document.getElementById("frmSearchOccupancy").reset();

        ResetOccupancy();
    });

   
});