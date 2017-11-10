$(function () {

    GetAutocompleteScript("PackageTitle");

    $("#btnSaveGitTitleDetails").click(function (event) {
        
        SaveGitTitleDetails();

    });

    $("#btnSaveHotelPackage").click(function (event) {

        SavePackageDetails();

    });

    $("#btnPackageSaveSiteSeeing").click(function (event) {

        SavePackageDetails();

    });

    $("#btnPackageSaveVehicle").click(function (event) {

        SavePackageDetails();

    });

    $("#btnPackageSaveMeal").click(function (event) {

        SavePackageDetails();

    });



    $(document).on('change', "[name='c1']", function (event) {
        if ($(this).prop('checked')) {

            sightseeingid = $(this).attr("data-sightseeingid");

            mealid = $(this).attr("data-mealid");

            vehicleid = $(this).attr("data-vehicleid");

            hotelid = $(this).attr("data-hotelid");

            roomtypeid = $(this).attr("data-roomtypeid");

            $("#hdnPackageSightSeeingId").val(sightseeingid);

            $("#hdnMealId").val(mealid);

            $("#hdnVehicleId").val(vehicleid);

            $("#hdnHotelId").val(hotelid);

            $("#hdnRoomTypeId").val(roomtypeid);


        }
    });


    $("#btnPackageSearchMeal").click(function () {
        $("#tblPackageMeal").attr("data-current-page", "0");
        GetPackageMealsList();
    });

    $("#btnPackageSearchVehicle").click(function () {
        $("#tblPAckageVehicle").attr("data-current-page", "0");
        GetPackageVehicleListing();
    });

    $("#btnSearchPackageHotel").click(function () {
       
        $("#tblHotelPackageTariffRoomDetails").attr("data-current-page", "0");

        GetHotelPackageListing();
    });


    $("#btnSearchPackageSightSeeing").click(function () {
        alert();
        $("#tblPackageSightSeeing").attr("data-current-page", "0");
        GetPackageSightSeeingListing();
    });


});