
$(document).ready(function () {


    $('#txtCheckInDate').datepicker('setDate', new Date());      
       
    $('#txtCheckOutDate').datepicker('setDate', '+3d');

    GetAutocompleteScript("HotelSearch");   
   
    $("#btnSearchHotel").click(function () {

       // GetHotelSearchDetails($("#drpHotel").val(), $('#drpCity').val(), $('#drpstarCategory').val(), $('#drproomType').val(), $('#drpOccupancyType').val(), $('#txtCheckInDate').val(), $('#txtCheckOutDate').val(), $('#drpAdultCount').val(), $('#drpChildCount').val());
        GetHotelSearchDetails();
    });

    //GetHotelSearchDetails($("[name='Hotel.hotelName']").val(), $('#drpcity').val(), $('#drpstarCategory').val(), $('#drproomType').val(), $('#drpOccupancyType').val(), $('#txtCheckInDate').val(), $('#txtCheckOutDate').val());
    //GetHotelSearchDetails();
    //GetHotelSearchDetails($("#drpHotel").val(), $('#drpCity').val(), $('#drpstarCategory').val(), $('#drproomType').val(), $('#drpOccupancyType').val(), $('#txtCheckInDate').val(), $('#txtCheckOutDate').val(), $('#drpAdultCount').val(), $('#drpChildCount').val());   


    $("#btnResetHotel").click(function () {

        document.getElementById("frmHotelSearch").reset();

        
    });

   // $(".AddToCart").click(function () {
    //$('.AddToCart').on('click', function () {
    //$(".add-to-cart").click(function () {
    //    alert();
    //    AddHotelInCart($(this));
        
    //});




});


function ViewRoomDetails(hotelId) {
    // $("#roomdetails").show();
    //var hotelId = $(this).closest('.pli-content').find('.clsHotelId').val();
    console.log(hotelId);
    GetHotelRoomDetails(hotelId);
}




