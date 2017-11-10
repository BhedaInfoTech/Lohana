$(document).ready(function () {

    $("#btnCustomerCategories").click(function () {
        LoadParentModal("/SupplierHotelTariff/GetCustomerCategoryByOccupencyIdTariffDate", { SupplierHotelPriceId: $("#hdnSupplierPriceId").val(), TariffDate: $("#hdnTariffDate").val(), }, null, "Customer Categories", "ti-view-list-alt");
    });



});
