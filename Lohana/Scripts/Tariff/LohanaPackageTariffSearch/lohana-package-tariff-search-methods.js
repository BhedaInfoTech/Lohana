function GetLohanaPackageTariffSearchDetails() {

    var lptsViewModel =
   {
       LohanaPackageTariffSearch: {

           CountryId: $("#drpCountry").val(),
           StateId: $("#drpState").val(),
           CityId: $('#drpCity').val(),
           PackageTypeId: $('#drpPackageType').val(),
           OccupancyId: $('#drpOccupancy').val(),
           //OccupancyId: $('#drpOccupancyType').val(),
           CheckinDate: $('#txtCheckInDate').val(),
           CheckOutDate: $("#txtCheckOutDate").val(),
           AdultCount: $('#drpAdultCount').val(),
           ChildCount: $('#drpChildCount').val(),
           DayDuration: $("#txtNoOfDays").val(),
           NightDuration: $("#txtNoOfNights").val(),

       }

   }

 
    PostAjaxJson("/LohanaPackageTariffSearch/GetLohanaPackageTariffSearch", lptsViewModel, function (data) { $("#divLohanaPackageTariffSearchDetails").html(data); });
  
}



function LPTFinalCostBasedOnNoOfRooms(rowId) {

    debugger;

        var hdnCost = $("#hdnCost_" + rowId).val();

        var txttxtNoOfRooms = $("#txtNoOfRooms_" + rowId).val();

        debugger;

        if (isNaN(txttxtNoOfRooms))
        {
            txttxtNoOfRooms = 0;
        }


    $("#lblLPTFinalCost_" + rowId).text(hdnCost * txttxtNoOfRooms);

}