function SaveHotelTariffRoom() {

    $("#frmHotelTariffRoom").blur();
   
    var htViewModel = {

        HotelTariffRoom: {

            HotelTariffRoomDetailsId:$("[name='HotelTariffRoomFilter.HotelTariffRoomDetailsId']").val(),

            HotelTariffId:$("[name='HotelTariffRoom.HotelTariffId']").val(),

            RoomRateTypeId:$("#drpRoomRateType").val(),

            CheckInTime:$("[name='HotelTariffRoom.CheckInTime']").val(),

            CheckOutTime:$("[name='HotelTariffRoom.CheckOutTime']").val(),

            RoomTypeId: $("#drpRoom").val(),

            //OccupancyId: $("#drpOccupancy").val(),

            //AgeFrom: $("[name='HotelTariffRoom.AgeFrom']").val(),

            //AgeTo: $("[name='HotelTariffRoom.AgeTo']").val(),

            //MealId: $("#drpMeal").val(),

            //MealInclusion: $("[name='HotelTariffRoom.MealInclusion']").val(),

            //RoomInclusion:$("[name='HotelTariffRoom.RoomInclusion']").val(),

            //RoomExclusion: $("[name='HotelTariffRoom.RoomExclusion']").val(),

            NoOfNight: $("#txtNoOfNight").val(),
        }
    }
    var url = "";

    if ($("[name='HotelTariffRoomFilter.HotelTariffRoomDetailsId']").val() == 0) {

        url = "/HotelTariff/InsertRoom"
    }
    else {

        url = "/HotelTariff/UpdateRoom"
    }
    PostAjaxJson(url, htViewModel, AfterRoomSave);
}

function AfterRoomSave(data) {

    FriendlyMessage(data);

    ResetRoom();

    GetHotelTariffRoom();

}

function ResetRoom() {

    $("[name='HotelTariffRoomFilter.HotelTariffRoomDetailsId']").val('');

    $("#drpRoomRateType").val('0');

    $("#txtCheckInTime").val('');

    $("#txtCheckOutTime").val('');

    $("#drpRoom").html('');

    //$("#drpOccupancy").html('');

    //$("#txtAgeFrom").val('');

    //$("#txtAgeTo").val('');

    //$("#drpMeal").html('');

    //$("#txtMealInclusion").val('');

    //$("#txtRoomInclusion").val('');

    //$("#txtRoomExclusions").val('');

    $("#txtNoOfNight").val('');

}

function GetHotelTariffRoom() {

    var htViewModel =
		{
		    HotelTariffRoom: {

		        HotelTariffId: $("[name='HotelTariffRoom.HotelTariffId']").val(),

		    },
		    Pager: {

		        CurrentPage: $('#tblHotelTariffRoomDetails').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/HotelTariff/GetRoom", htViewModel, BindHotelTariffRoom);
}

function BindHotelTariffRoom(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["RoomRateType", "RoomTypeName", "NoOfNight"],
        primayKey: ["HotelTariffRoomDetailsId", "HotelTariffId"],
        hiddenFields: ["HotelTariffId", "HotelTariffRoomDetailsId", "RoomRateTypeId","RoomRateType", "CheckInTime", "CheckOutTime", "RoomTypeId", "RoomTypeName", "NoOfNight"],
        headerNames: ["Room Rate Type", "Room Type", "No Of Night"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblHotelTariffRoomDetails'));

    BindPagination(list.Pager, $('#tblHotelTariffRoomDetails'), "HotelTariffRoomPagination");

}

function GetSetHotelTariffRoomValues(obj) {

    var id = $(obj).attr("data-hoteltariffroomdetailsid");

    var hoteltariffid = $(obj).attr("data-hoteltariffid");

    var roomratetypeid = $(obj).attr("data-roomratetypeid");

    var roomratetype = $(obj).attr("data-roomratetype");

    var checkintime = $(obj).attr("data-checkintime");

    var checkouttime = $(obj).attr("data-checkouttime");

    var roomtypeid = $(obj).attr("data-roomtypeid");

    var roomtypename = $(obj).attr("data-roomtypename");

    var noofnight = $(obj).attr("data-noofnight");

    $("[name='HotelTariffRoom.HotelTariffId']").val(hoteltariffid);

    $("#drpRoomRateType").val(roomratetypeid);

    $("[name='HotelTariffRoom.CheckInTime']").val(checkintime);

    $("[name='HotelTariffRoom.CheckOutTime']").val(checkouttime);

	$("[name='HotelTariffRoom.RoomTypeId']").attr("data-value", roomtypeid);

	GetAutocompleteById("HotelTariffRoom.RoomTypeId");

	$("[name='HotelTariffRoom.NoOfNight']").val(noofnight);

    //View

    $("#lblRoomRateType").text(roomratetype);

    $("#lblCheckInTime").text(checkintime);

    $("#lblCheckOutTime").text(checkouttime);

    $("#lblRoomTypeName").text(roomtypename);

    //For Price Details
    $("[name='HotelTariffRoomOccupancy.HotelTariffRoomDetailsId']").val(id);

    //$("[name='HotelTariffCustomerCategory.HotelTariffRoomDetailsId']").val(id);

    $("[name='HotelTariffPrice.NoOfNight']").val(noofnight);

   // ResetCustomerCategory();

    //GetHotelTariffCustomerCategory();

    ResetRoomOccupancy();

    GetHotelTariffRoomOccupancy();

}

function DeleteRoom() {

    var htViewModel =
      {

          HotelTariffRoom: {

              HotelTariffRoomDetailsId: $("[name='HotelTariffRoomFilter.HotelTariffRoomDetailsId']").val(),

              HotelTariffId: $("[name='HotelTariffRoom.HotelTariffId']").val(),


          },
          Pager: {

              CurrentPage: $('#tblHotelTariffRoomDetails').attr("data-current-page"),
          },
      }
   
    PostAjaxJson("/HotelTariff/DeleteRoom", htViewModel, AfterRoomDelete);
    

}

function AfterRoomDelete(data) {

    FriendlyMessage(data);

    ResetRoom();

    GetHotelTariffRoom();
}

function HotelTariffRoomPagination(CurrentPage) {

    $('#tblHotelTariffRoomDetails').attr("data-current-page", CurrentPage);

    GetHotelTariffRoom();
}
