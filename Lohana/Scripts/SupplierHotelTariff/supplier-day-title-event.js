$(function () {

    GetAutocompleteScript("SupplierHotelTariff");

    $("#btnSaveTitleDetails").click(function (event) {
       
        SaveTitleDetails();
       
    });   

    $("#btnSaveHotel").click(function (event) {
 
        SaveHotelDetails();

    });

    $("#btnSaveSiteSeeing").click(function (event) {

        SaveHotelDetails();

    });

    $("#btnSaveVehicle").click(function (event) {

        SaveHotelDetails();

    });

    $("#btnSaveMeal").click(function (event) {

        SaveHotelDetails();

    });
  
    $("#btnSearchSightSeeing").click(function () {
        $("#tblSightSeeing").attr("data-current-page", "0");
        GetSightSeeingListing();
    });

    $(document).on('change', "[name='c1']", function (event)
    {
        if ($(this).prop('checked')) {

            sightseeingid = $(this).attr("data-sightseeingid");

            mealid = $(this).attr("data-mealid");

            vehicleid = $(this).attr("data-vehicleid");

            hotelid = $(this).attr("data-hotelid");

            roomtypeid = $(this).attr("data-roomtypeid");

            $("#hdnSightSeeingId").val(sightseeingid);

            $("#hdnMealId").val(mealid);

            $("#hdnVehicleId").val(vehicleid);

            $("#hdnHotelId").val(hotelid);
            
            $("#hdnRoomTypeId").val(roomtypeid);


        }
    });

    $("#btnSearchMeal").click(function () {
        $("#tblMeal").attr("data-current-page", "0");
        GetMealsList();
    });

    $("#btnSearchVehicle").click(function () {
        $("#tblVehicle").attr("data-current-page", "0");
        GetVehicleListing();
    });

    $("#btnSearchHotel").click(function () {

        $("#tblHotelTariffRoomDetails").attr("data-current-page", "0");
        GetHotelListing();
    });

    $('.ResetBtn').click(function () {


        $("#drpcity").html("");

        $("#drpHotel").html("");

        $("#drpRoom").html("");

        $("#drpSiteSeeing").html("");

        $("#drpMeal").html("");

        $("#txtMealDescription").val("");

        $("#drpVehicle").html("");

        $("#drpVehicleBrand").html("");

        $("#drpVehicleType").html("");

    });

});