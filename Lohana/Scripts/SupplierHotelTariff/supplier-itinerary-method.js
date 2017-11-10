
function GetSupplierHotelTariffDays(id) {

    
    $("#dvItinerary").find("#divDays").load("/SupplierHotelTariff/GetSupplierHotelTariffDays", { SupplierHotelId: id }, function () {

    });

}
