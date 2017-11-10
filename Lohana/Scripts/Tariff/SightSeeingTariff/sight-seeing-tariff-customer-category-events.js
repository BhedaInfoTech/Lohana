$(document).ready(function () {




    $("#btnCustomerCategories").click(function () {
        LoadParentModal("/SightSeeingTariff/GetCustomerCategoryByOccupencyIdTariffDate", { SightSeeingTariffOccupancyId: $("#hdnSightSeeingTariffOccupancyId").val(), TariffDate: $("#hdnTariffDate").val(), }, null, "Customer Categories", "ti-view-list-alt");
    });



});