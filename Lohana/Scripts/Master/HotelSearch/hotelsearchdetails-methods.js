//function GetHotelSearchDetails(hotelId, cityid, starcategory, roomtypeid, occupancyid, checkindate, checkoutdate,adultCount,childCount) {
function GetHotelSearchDetails() {
    var hsViewModel =
   {
       HotelSearch: {
           HotelId: $("#drpHotel").val(),
           CountryId: $('#drpCountry').val(),
           StateId: $('#drpState').val(),
           CityId: $('#drpCity').val(),
           StarCategory: $('#drpstarCategory').val(),
           RoomTypeId: $('#drproomType').val(),
           OccupancyId: $('#drpOccupancyType').val(),
           CheckinDate: $('#txtCheckInDate').val(),
           CheckOutDate: $('#txtCheckOutDate').val(),
           AdultCount: $('#drpAdultCount').val(),
           ChildCount: $('#drpChildCount').val(),
       }

   }


    //$("#divRoomMealOccupancy").load("/HotelSearch/GetHotelSearch", JSON.stringify({ HotelName: hotelname, CityId: cityid, StarCategory: starcategory, RoomTypeId: roomtypeid, OccupancyId: occupancyid, CheckInDate: checkindate, CheckOutDate: checkoutdate }), function () {
    //$("#divRoomMealOccupancy").load("/HotelSearch/GetHotelSearch", JSON.stringify(hsViewModel), function () {
    PostAjaxJson("/HotelSearch/GetHotelSearch", hsViewModel, function (data) { $("#divRoomMealOccupancy").html(data); });
    // $("#divRoomMealOccupancy").load("/HotelSearch/GetHotelSearch", JSON.stringify({ HotelId: hotelId, CityId: cityid, StarCategory: starcategory, RoomTypeId: roomtypeid, OccupancyId: occupancyid, CheckInDate: checkindate, CheckOutDate: checkoutdate, adultCount: adultCount, childCount: childCount }), function () {

}

function GetHotelRoomDetails(hotelId) {
    var hsViewModel =
  {
      HotelSearch: {
          HotelId: hotelId,
          RoomTypeId: $('#drproomType').val(),
          CheckinDate: $('#txtCheckInDate').val(),
          CheckOutDate: $('#txtCheckOutDate').val(),
          AdultCount: $('#drpAdultCount').val(),
          ChildCount: $('#drpChildCount').val(),
      }
  }
    //$("#modalParent").find('.modal-body').load("/HotelSearch/GetHotelRoomDetails", JSON.stringify({ HotelName: hotelname, CityId: cityid, StarCategory: starcategory, RoomTypeId: roomtypeid, OccupancyId: occupancyid, CheckInDate: checkindate, CheckOutDate: checkoutdate, hotelId: hotelId }), function () {
    //    $("#modalParent").modal('show');
    //});
    PostAjaxJson("/HotelSearch/GetHotelRoomDetails", hsViewModel, function (data) { $("#modalParent").find('.modal-body').html(data); });
    $("#modalParent").modal('show');
}










//function AddHotelInCart(obj) {
//    alert($(obj).parents(".m-item").find(".room-data").attr("data-hotelid"));
//    var qViewModel = 
//       {
//           Quotation: {

//               HotelId: $(obj).parents(".m-item").find(".room-data").attr("data-hotelid"),

//               HotelName: $(obj).parents(".m-item").find(".room-data").attr("data-hotelname"),

//               HotelType: $(obj).parents(".m-item").find(".room-data").attr("data-hoteltype"),

//           }
//       }
      
//    var url = "/HotelSearch/HotelAddToCart";

//   // alert(JSON.stringify(qViewModel));

//    $.cookie("Bookings", JSON.stringify(qViewModel)); 

//    PostAjaxWithProcessJson(url, $.cookie("Bookings"), AfterTransferSave, $("body"));
//}

//function AfterTransferSave()
//{

//}