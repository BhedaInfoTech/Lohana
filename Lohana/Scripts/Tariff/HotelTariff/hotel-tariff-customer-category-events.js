$(document).ready(function () {


    

    $("#btnCustomerCategories").click(function () {
        LoadParentModal("/HotelTariff/GetCustomerCategoryByOccupencyIdTariffDate", { HotelTariffRoomOccupancyId: $("#hdnHotelTariffRoomOccupancyId").val(), TariffDate: $("#hdnTariffDate").val(), }, null, "Customer Categories", "ti-view-list-alt");
    });

   

});
