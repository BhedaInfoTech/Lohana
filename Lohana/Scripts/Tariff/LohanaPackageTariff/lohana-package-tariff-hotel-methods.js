function GetHotelListing() {

    var lpViewModel =
		{
		    LohanaPackageTariffHotel: {

		    CityId:$("#drpCity").val(),

		    HotelId:$("#drpHotel").val(),

		    RoomTypeId:$("#drpRoom").val(),

		    MealId: $("#drpMeal").val(),

		    },
		    Pager: {

		        CurrentPage: $('#tblHotelTariffRoomDetails').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/LohanaPackageTariff/GetHotelListing", lpViewModel, BindHotel);
}

function BindHotel(data) {
    var list = JSON.parse(data);

    var kTable = {
        /*dataList: ["CityName","HotelName", "RoomTypeName", "MealName","NoOfNight"],
        primayKey: ["HotelTariffRoomDetailsId"],
        hiddenFields: ["CityName","HotelTariffRoomDetailsId", "HotelId", "HotelName", "RoomTypeName","MealName","NoOfNight"],
        headerNames: ["Location","Hotel Name", "Room Type", "Meal Type","No of Nights"],
        data: list.dt,*/
        //dataList: ["HotelName", "RoomTypeName", "NoOfNight", "OccupancyName", "MealName"/*, "CityName"*/],
        //primayKey: ["HotelTariffRoomOccupancyId"],
        //hiddenFields: ["OccupancyId", "HotelTariffRoomOccupancyId", "HotelName", "RoomTypeName", "HotelTariffRoomDetailsId", "MealId", "NoOfNight", "City Name"],
        //headerNames: ["Hotel Name", "Room Type", "No of Nights", "Occupancy Name", "Meal Type"/*, "City Name"*/],
        //data: list.dt,
        dataList: ["HotelName", "RoomTypeName", "NoOfNight","CityName"],
        primayKey: ["HotelTariffRoomDetailsId"],
        hiddenFields: ["HotelTariffRoomDetailsId","HotelId"],
        headerNames: ["Hotel Name", "Room Type", "No of Nights", "Location"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblHotelTariffRoomDetails'));

    BindPagination(list.Pager, $('#tblHotelTariffRoomDetails'), "HotelPagination");
}

function HotelPagination(CurrentPage) {

    $('#tblHotelTariffRoomDetails').attr("data-current-page", CurrentPage);

    GetHotelListing();
}

function GetHotelsDrp(CityId) {

    GetAjax("/LohanaPackageTariff/GetHotelsDrp", { CityId: CityId }, BindHotelDrp);
}

function BindHotelDrp(Hotels) {

    $("#drpHotel").html("");

    var htmltext = "";

    htmltext += "<option value = '0'>--Select Hotel--</option>";

    if (Hotels.length > 0) {

        for (var i = 0; i < Hotels.length ; i++) {

            htmltext += "<option value='" + Hotels[i].HotelId + "' >" + Hotels[i].HotelName + "</option>";

        }
    }

    $("#drpHotel").html(htmltext);
}

function SaveHotel() {

    //$("#frmLohanaPackageTariffHotel").blur();

    var lpViewModel = {

        LohanaPackageTariffHotel: {

            //LohanaPackageTariffHotelId: $("[name='LohanaPackageTariffHotel.LohanaPackageTariffHotelId']").val(),

            HotelTariffRoomDetailsId: $("#hdnHotelTariffRoomDetailsId").val(),

            HotelTariffType: $("#hdnHotelTariffHotelType").val(),

            //HotelTariffRoomOccupancyId: $("#hdnHotelTariffRoomOccupancyId").val(),

            //$("#hdnHotelTariffRoomDetailsId").val(hoteltariffroomdetailsid),

            //$("#hdnHotelTariffRoomOccupancyId").val(hoteltariffroomoccupancyid),

            NoOfNight: $("[name='LohanaPackageTariffHotel.NoOfNight']").val(),

            LohanaPackageTariffId: $("[name='LohanaPackageTariffHotel.LohanaPackageTariffId']").val()
         
        }
    }
    var url = "";

    if ($("[name='LohanaPackageTariffHotel.LohanaPackageTariffHotelId']").val() == 0) {

        url = "/LohanaPackageTariff/InsertLohanaPackageTariffHotel"
    }
    else {

        url = "/LohanaPackageTariff/UpdateLohanaPackageTariffHotel"
    }

    PostAjaxJson(url, lpViewModel, AfterHotelSave);
}

function AfterHotelSave(data) {

    FriendlyMessage(data);

    //$("[name='LohanaPackageTariffHotel.LohanaPackageTariffId']").val(data.LohanaPackageTariffHotel.LohanaPackageTariffId);

   // $("[name='LohanaPackageTariffHotel.HotelTariffRoomDetailsId']").val(data.LohanaPackageTariffHotel.HotelTariffRoomDetailsId);

    //$("[name='LohanaPackageTariffHotel.NoOfNight']").val(data.LohanaPackageTariffHotel.NoOfNight);

    GetHotel();

    ResetHotel();

    
}

function ResetHotel() {

    $("#hdnLohanaPackageTariffHotelId").val('');

    //$("#txtNoOfNight").val('');

    //$("#txtHotelTariffRoomDetailsId").val('');

    $("#drpCity").val(0);
    $("#drpHotel").val(0);
    $("#drpRoom").val(0);
    $("#drpMeal").val(0);
    $("#hdnHotelTariffRoomOccupancyId").val('');

    //$("#lblDetails").text('');
   
}

function GetHotel() {


    var lpViewModel =
		{
		    LohanaPackageTariffHotel: {

		        LohanaPackageTariffId: $("[name='LohanaPackageTariffHotel.LohanaPackageTariffId']").val(),

		        //HotelTariffRoomDetailsId: $("[name='LohanaPackageTariffHotel.HotelTariffRoomDetailsId']").val(),

		        NoOfNight: $("[name='LohanaPackageTariffHotel.NoOfNight']").val()

		    },
		    Pager: {

		        CurrentPage: $('#tblLohanaPackageTariffHotel').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/LohanaPackageTariff/GetLohanaPackageTariffHotel", lpViewModel, BindLohanaPackageTariffHotel);

    $("#txtNights").val('');

}

function BindLohanaPackageTariffHotel(data) {

    var list = JSON.parse(data);

    var kTable = {
        /*dataList: ["CityName", "HotelName", "RoomTypeName", "MealName", "NewNoOfNight"],
        primayKey: ["HotelTariffRoomDetailsId", "LohanaPackageTariffHotelId", "LohanaPackageTariffId"],
        hiddenFields: ["CityName", "HotelTariffRoomDetailsId", "LohanaPackageTariffId", "HotelId", "HotelName", "RoomTypeName", "MealName", "NoOfNight", "LohanaPackageTariffHotelId", "NewNoOfNight", "HotelTariffRoomOccupancyId"],
        headerNames: ["Location", "Hotel Name", "Room Type", "Meal Type", "No of Nights"],
        data: list.dt,*/
        dataList: ["CityName", "HotelName", "RoomTypeName", "MealName", "NewNoOfNight"],
        primayKey: ["HotelTariffRoomDetailsId", "LohanaPackageTariffHotelId", "LohanaPackageTariffId"],
        hiddenFields: ["CityName", "HotelTariffRoomDetailsId", "LohanaPackageTariffId", "HotelId", "HotelName", "RoomTypeName", "MealName", "NoOfNight", "LohanaPackageTariffHotelId", "NewNoOfNight"],
        headerNames: ["Location", "Hotel Name", "Room Type", "Meal Type", "No of Nights"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblLohanaPackageTariffHotel'));

    BindPagination(list.Pager, $('#tblLohanaPackageTariffHotel'), "LohanaPackageTariffHotelPagination");

}

function GetSetHotelValues(obj) {

    var id = $(obj).attr("data-lohanapackagetariffhotelid");

    $("[name='LohanaPackageTariffHotel.LohanaPackageTariffHotelId']").val(id)

    var newnoofnight = $(obj).attr("data-newnoofnight");

    var roomtypename = $(obj).attr("data-roomtypename");

    var mealname = $(obj).attr("data-mealname");

    var hoteltariffroomdetailsid = $(obj).attr("data-hoteltariffroomdetailsid");

    var hoteltariffroomoccupancyid = $(obj).attr("data-hoteltariffroomoccupancyid");

    $("[name='LohanaPackageTariffHotel.HotelTariffRoomDetailsId']").val(hoteltariffroomdetailsid),

    $("[name='LohanaPackageTariffHotel.HotelTariffRoomOccupancyId']").val(hoteltariffroomoccupancyid),

    $("[name='LohanaPackageTariffHotel.NoOfNight']").val(newnoofnight)

    var Details = roomtypename + "/" + mealname + "/" + newnoofnight;

    //$("#lblDetails").text(Details);

    //GetVehicle();

}

function DeleteHotel() {

    var lpViewModel =
      {

          LohanaPackageTariffHotel: {

              LohanaPackageTariffHotelId: $("[name='LohanaPackageTariffHotel.LohanaPackageTariffHotelId']").val(),

              LohanaPackageTariffId: $("[name='LohanaPackageTariffHotel.LohanaPackageTariffId']").val(),

              //RefId: $("#hdnHotelTariffRoomDetailsId").val(),

              //HotelTariffType: $("#hdnHotelTariffHotelType").val()

              //HotelTariffRoomOccupancyId: $("[name='LohanaPackageTariffHotel.HotelTariffRoomOccupancyId']").val()

          },
          Pager: {

              CurrentPage: $('#tblLohanaPackageTariffHotel').attr("data-current-page"),
          },
      }

    PostAjaxJson("/LohanaPackageTariff/DeleteLohanaPackageTariffHotel", lpViewModel, AfterHotelDelete);

}

function AfterHotelDelete(data) {

    FriendlyMessage(data);

    ResetHotel();

    GetHotel();
}

function LohanaPackageTariffHotelPagination(CurrentPage) {

    $('#tblLohanaPackageTariffHotel').attr("data-current-page", CurrentPage);

    GetHotel();

}
