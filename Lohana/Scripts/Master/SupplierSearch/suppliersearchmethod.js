function GetSupplierSearchDetails() {

  
    var ssViewModel =
        {
            SupplierSearch: {
                CityId: $('#drpCity').val(),
                StateId: $('#drpState').val(),
                CountryId: $('#drpCountry').val(),
                CheckinDate: $('#txtCheckInDate').val(),
                NoOfDays:$('#txtNoOfDays').val(),
                NoOfNights:$('#txtNoOfNights').val(),
                ChildAge:$('#txtChildAge').val(),
                AdultCount: $('#txtAdultCount').val(),
                ChildCount: $('#txtChildCount').val(),
               

            }
        }

    PostAjaxJson("/SupplierSearch/GetSupplierSearch", ssViewModel, function (data) { $("#divRoomMealOccupancy").html(data); });
}