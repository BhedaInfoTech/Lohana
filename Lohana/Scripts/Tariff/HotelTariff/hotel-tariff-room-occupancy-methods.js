function SaveHotelTariffRoomOccupancy() {

    $("#frmHotelTariffRoomOccupancy").blur();
   
    var htViewModel = {

        HotelTariffRoomOccupancy: {

            HotelTariffRoomOccupancyId: $("[name='HotelTariffRoomOccupancyFilter.HotelTariffRoomOccupancyId']").val(),

            HotelTariffRoomDetailsId: $("[name='HotelTariffRoomOccupancy.HotelTariffRoomDetailsId']").val(),

            OccupancyId: $("#drpOccupancy").val(),

            AgeFrom: $("[name='HotelTariffRoomOccupancy.AgeFrom']").val(),

            AgeTo: $("[name='HotelTariffRoomOccupancy.AgeTo']").val(),

            MealId: $("#drpMeal").val(),

            MealInclusion: $("[name='HotelTariffRoomOccupancy.MealInclusion']").val(),

            RoomInclusion: $("[name='HotelTariffRoomOccupancy.RoomInclusion']").val(),

            RoomExclusion: $("[name='HotelTariffRoomOccupancy.RoomExclusion']").val(), 
        }
    }
    var url = "";

    if ($("[name='HotelTariffRoomOccupancyFilter.HotelTariffRoomOccupancyId']").val() == 0) {

        url = "/HotelTariff/InsertRoomOccupancy"
    }
    else {

        url = "/HotelTariff/UpdateRoomOccupancy"
    }
    PostAjaxJson(url, htViewModel, AfterRoomOccupancySave);
}

function AfterRoomOccupancySave(data) {

    FriendlyMessage(data);

    ResetRoom();

    GetHotelTariffRoomOccupancy();

}

function ResetRoomOccupancy() {

    $("[name='HotelTariffRoomOccupancyFilter.HotelTariffRoomOccupancyId']").val('');

    $("#drpOccupancy").html('');

    $("#txtAgeFrom").val('');

    $("#txtAgeTo").val('');

    $("#drpMeal").html('');

    $("#txtMealInclusion").val('');

    $("#txtRoomInclusion").val('');

    $("#txtRoomExclusions").val(''); 

}

function GetHotelTariffRoomOccupancy() {

    var htViewModel =
		{
		    HotelTariffRoomOccupancy: {

		        HotelTariffRoomDetailsId: $("[name='HotelTariffRoomOccupancy.HotelTariffRoomDetailsId']").val(),

		    },
		    Pager: {

		        CurrentPage: $('#tblHotelTariffRoomOccupancy').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/HotelTariff/GetRoomOccupancy", htViewModel, BindHotelTariffRoomOccupancy);
   
}

function BindHotelTariffRoomOccupancy(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["OccupancyName", "MealName", "RoomInclusion", "RoomExclusion"],
        primayKey: ["HotelTariffRoomOccupancyId", "HotelTariffRoomDetailsId"],
        hiddenFields: ["HotelTariffRoomDetailsId", "HotelTariffRoomOccupancyId", "OccupancyId", "OccupancyName", "AgeFrom", "AgeTo", "MealId", "MealName", "MealInclusion", "RoomInclusion", "RoomExclusion"],
        headerNames: ["Occupancy", "Meal Plan", "Room Inclusion", "Room Exclusion"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblHotelTariffRoomOccupancy'));

    BindPagination(list.Pager, $('#tblHotelTariffRoomOccupancy'), "HotelTariffRoomPagination");

}

function GetSetHotelTariffRoomOccupancyValues(obj) {

    var id = $(obj).attr("data-hoteltariffroomOccupancyid");

    var hoteltariffroomdetailsid = $(obj).attr("data-hoteltariffroomdetailsid");

    var occupancyid = $(obj).attr("data-occupancyid");

    var occupancyname = $(obj).attr("data-occupancyname");

    var agefrom = $(obj).attr("data-agefrom");

    var ageto = $(obj).attr("data-ageto");

    var mealid = $(obj).attr("data-mealid");

    var mealname = $(obj).attr("data-mealname");

    var mealinclusion = $(obj).attr("data-mealinclusion");

    var roominclusion = $(obj).attr("data-roominclusion");

    var roomexclusion = $(obj).attr("data-roomexclusion"); 
 
    $("[name='HotelTariffRoomOccupancy.HotelTariffRoomDetailsId']").val(hoteltariffroomdetailsid);

    $("[name='HotelTariffRoomOccupancy.AgeFrom']").val(agefrom);

    $("[name='HotelTariffRoomOccupancy.AgeTo']").val(ageto);

    $("[name='HotelTariffRoomOccupancy.OccupancyId']").attr("data-value", occupancyid);

    $("[name='HotelTariffRoomOccupancy.MealId']").attr("data-value", mealid);

	GetAutocompleteById("HotelTariffRoomOccupancy.OccupancyId");

    GetAutocompleteById("HotelTariffRoomOccupancy.MealId");

    $("[name='HotelTariffRoomOccupancy.MealInclusion']").val(mealinclusion);

    $("[name='HotelTariffRoomOccupancy.RoomInclusion']").val(roominclusion);

    $("[name='HotelTariffRoomOccupancy.RoomExclusion']").val(roomexclusion);
     
    //View     

    $("#lblOccupancyName").text(occupancyname);

    $("#lblAgeFrom").text(agefrom);

    $("#lblAgeTo").text(ageto);

     $("#lblMealName").text(mealname);

     $("#lblMealInclusion").text(mealinclusion);

     $("#lblRoomInclusion").text(roominclusion);
  
     $("#lblRoomExclusion").text(roomexclusion);

    //For Price Occupancy 
     
    $("[name='HotelTariffPrice.HotelTariffRoomOccupancyId']").val(id);

    $("[name='HotelTariffCustomerCategory.HotelTariffRoomOccupancyId']").val(id); 

    //ResetCustomerCategory();

    //GetHotelTariffCustomerCategory(); 

    ResetPrice();

   // GetSightSeeingTariffPrice();

}

function DeleteRoomOccupancy() {

    var htViewModel =
      {

          HotelTariffRoomOccupancy: {

              HotelTariffRoomOccupancyId: $("[name='HotelTariffRoomOccupancyFilter.HotelTariffRoomOccupancyId']").val(),

              HotelTariffRoomDetailsId: $("[name='HotelTariffRoomOccupancy.HotelTariffRoomDetailsId']").val(),


          },
          Pager: {

              CurrentPage: $('#tblHotelTariffRoomOccupancy').attr("data-current-page"),
          },
      }

    PostAjaxJson("/HotelTariff/DeleteRoomOccupancy", htViewModel, AfterRoomOccupancyDelete);
    

}

function AfterRoomOccupancyDelete(data) {

    FriendlyMessage(data);

    ResetRoomOccupancy();

    GetHotelTariffRoomOccupancy();
}

function HotelTariffRoomOccupancyPagination(CurrentPage) {

    $('#tblHotelTariffRoomOccupancy').attr("data-current-page", CurrentPage);

    GetHotelTariffRoomOccupancy();
}
