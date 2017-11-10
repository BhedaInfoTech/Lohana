$(document).ready(function () {

    GetSightSeeing();

    GetAutocompleteScript("SightSeeing");
    GetAutocompleteById("SightSeeing.CityId");

    document.getElementById("btnEditSightSeeing").disabled = true;
    document.getElementById("btnViewSightSeeing").disabled = true;

    $(document).on('change', "[name='c1']", function (event) {

        if ($(this).prop('checked')) {

            var id = $(this).attr("data-sightseeingid");

            $("#hdnSearchSightSeeingId").val(id);
            //Modiifcation
            $("#hdnvendor").val($(this).attr("data-vendorid"))

            document.getElementById("btnEditSightSeeing").disabled = false;
            document.getElementById("btnViewSightSeeing").disabled = false;
        }

    });

    $("#btnSearchSightSeeing").click(function () {

        $("#tblSightSeeing").attr("data-current-page", "0");

        GetSightSeeing();
    });

    $("#btnEditSightSeeing").click(function () {

       // GetAutocompleteById("SightSeeing.VendorId");

        $("#frmSearchSightSeeing").attr("action", "/SightSeeing/GetSightSeeingById");

        $("#frmSearchSightSeeing").submit();

        

    });

    $("#btnResetSightSeeing").click(function () {

        document.getElementById("frmSearchSightSeeing").reset();

    });

    $("#btnViewSightSeeing").click(function () {

        $("#frmSearchSightSeeing").attr("target", "_blank");
        $("#frmSearchSightSeeing").attr("action", "/Sightseeing/GetSightSeeingView");
        $("#frmSearchSightSeeing")[0].submit();
        $("#frmSearchSightSeeing").attr("target", "_self");

    });
});