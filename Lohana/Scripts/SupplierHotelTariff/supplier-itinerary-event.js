$(document).ready(function () {

    var id = 0;

    $("#divIteneraryButtons button").click(function () {

        var SupplierHotelDayId = $("#supplierhotedaylid").val();
      

        var SupplierHotelId = $("#hdnSupplierHotelId").val();

        $(this).addClass('active').siblings().removeClass('active');

        if ($(this).val() == 1) {
         
            LoadModal("/SupplierHotelTariff/GetDayTitle", { SupplierHotelDayId: SupplierHotelDayId, SupplierHotelId: SupplierHotelId }, null, "Day Title", null);
        }
        else if ($(this).val() == 2) {

            LoadModal("/SupplierHotelTariff/GetAddHotel", null, null, "Add Hotel", null);

            GetHotelListing();
        }
        else if ($(this).val() == 3) {

            LoadModal("/SupplierHotelTariff/GetAddSightseeing", null, null, "Add Sightseeing", null);
            
            GetSightSeeingListing();
        }
        else if ($(this).val() == 4) {

            LoadModal("/SupplierHotelTariff/GetAddVehicle", null, null, "Add Vehicle", null);

            GetVehicleListing();

        }
        else if ($(this).val() == 5) {
        
            LoadModal("/SupplierHotelTariff/GetAddMeal", null, null, "Add Meal", null);

            GetMealsList();
        }
    
    });


    $(document).on('change', "[name='SupplierHotelTariffDayInfo.SupplierHotelDayId']", function (event) {
        if ($(this).prop('checked')) {

            id = $(this).attr("data-supplierhotedaylid");

            $("#supplierhotedaylid").val(id);

            $(".addBtn").attr("disabled", false);

        }
        
    });


});
