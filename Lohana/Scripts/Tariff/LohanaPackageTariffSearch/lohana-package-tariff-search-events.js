
$(document).ready(function () {


    $('#txtCheckInDate').datepicker('setDate', new Date());

    $('#txtCheckOutDate').datepicker('setDate', '+3d');

    GetAutocompleteScript("LohanaPackageTariffSearch");

    $("#btnSearchLohanaPackageTariff").click(function () {

       
        GetLohanaPackageTariffSearchDetails();
    });

  
    $("#btnResetLohanaPackageTariff").click(function () {
        $('#drpAdultCount').val(1),
        $('#drpChildCount').val(0)

    });



   
   

});


//function ViewRoomDetails(hotelId) {
  
//    console.log(hotelId);
//    GetHotelRoomDetails(hotelId);

//}




