function SaveTitleDetails() {

    
    var sViewModel =
           {
               SupplierHotelTariffDayInfo: {
                   SupplierHotelDayId: $("#hdnSupplierHotelDayId").val(),
                   SupplierHotelId: $("#hdnSupplierHotelId").val(),
                   CityId: $("[name='SupplierHotelTariffDayInfo.CityId']").val(),
                   Title: $("#txtTitle").val()
               },
           }
    PostAjaxJson("/SupplierHotelTariff/UpdateSupplierHotelDays", sViewModel, AfterTitleSave);
}

function AfterTitleSave()
{

    GetSupplierHotelTariffDays($("#hdnSupplierHotelId").val());

    $('#modalParent').modal('hide');

    $(".addBtn").attr("disabled", true);

}   

function SaveHotelDetails() {

 
    var sViewModel =
           {

               SupplierHotelDayItem:
                   {
                       SupplierHotelDayId: $("[name='SupplierHotelTariffDayInfo.SupplierHotelDayId']").val(),
                       
                       HotelId: $("#hdnHotelId").val(),
                       RoomTypeId:$("#hdnRoomTypeId").val(),
                       SightSeeingId: $("#hdnSightSeeingId").val(),
                       VehicleId: $("#hdnVehicleId").val(),
                       MealId: $("#hdnMealId").val(),

                   },

           }
    PostAjaxJson("/SupplierHotelTariff/InsertSupplierHotelDayItem", sViewModel, AfterTitleSave);

}

function GetHotelListing() {

    var lpViewModel =
		{
		    LohanaPackageTariffHotel: {

		        CityId: $("[name='SupplierHotelTariffDayInfo.CityId']").val(),

		        HotelId: $("[name='SupplierHotelDayItem.HotelId']").val(),

		        RoomTypeId: $("[name='SupplierHotelDayItem.RoomTypeId']").val(),

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
      
        dataList: ["HotelName", "RoomTypeName", "NoOfNight", "CityName"],
        primayKey: ["HotelTariffRoomDetailsId"],
        hiddenFields: ["HotelTariffRoomDetailsId", "HotelId","RoomTypeId"],
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

function GetSightSeeingListing() {


    var SightSeeingName = "";

    if ($("#select2-drpSiteSeeing-container").attr('title') == undefined)
    {
        SightSeeingName = "";
    }
    else
    {
        SightSeeingName = $("#select2-drpSiteSeeing-container").attr('title');
    }
    

    var sViewModel =
		{
		    SightSeeing: {
		       
                SightSeeingName:SightSeeingName,
		        CityId: $("[name='SupplierHotelTariffDayInfo.CityId']").val(),
		    },
		    Pager: {

		        CurrentPage: $('#tblSightSeeing').attr("data-current-page"),
		    },
		}
    PostAjaxJson("/SightSeeing/GetSightSeeing", sViewModel, BindSightSeeing);
}

function BindSightSeeing(data) {
   
    var list = JSON.parse(data);

    var kTable = {
        dataList: ["SightSeeingName", "CityName", "OperationalTime", "OperationalDays"],
        primayKey: "SightSeeingId",
        hiddenFields: ["SightSeeingId", "SightSeeingName", "CityId", "VendorId"],
        headerNames: ["Sight Seeing Name", "Location", "Operational Time", "Operational Days"],
        data: list.dt,
    }
    buildHtmlTable(kTable, $('#tblSightSeeing'));

    BindPagination(list.Pager, $('#tblSightSeeing'), 'SightSeeingPagination');
}

function SightSeeingPagination(CurrentPage) {
    $('#tblSightSeeing').attr("data-current-page", CurrentPage);
    GetSightSeeingListing();
}


function GetMealsList() {

    var MealName = "";
    
    if ($("#select2-drpMeal-container").attr('title') == undefined) 
    {
        MealName = "";
    }
    else 
    {
        MealName = $("#select2-drpMeal-container").attr('title');
    }
    
    var mViewModel =
		{
		    Meal: {		      
		        MealName:MealName,     		      
		       MealDescription:$("[name='Meal.MealDescription']").val(),
		      
		    },
		    Pager: {
		        CurrentPage: $('#tblMeal').attr("data-current-page"),
		    },
		}
    PostAjaxWithProcessJson("/Meal/GetMeals", mViewModel, BindMeals);
}

function BindMeals(data) {

    var list = JSON.parse(data);
    var kTable = {
        dataList: ["MealName", "MealDescription", "IsActiveStr"],
        primayKey: "MealId",
        hiddenFields: ["MealId", "MealName", "MealDescription", "IsActive"],
        headerNames: ["Meal Name", "Meal Description", "Is Active"],
        data: list.dt,
    }
    buildHtmlTable(kTable, $('#tblMeal'));
    BindPagination(list.Pager, $('#tblMeal'), 'MealPagination');
}

function MealPagination(CurrentPage) {
    $('#tblMeal').attr("data-current-page", CurrentPage);
    GetMealsList();
}

function GetVehicleListing() {
  
    var VehicleName = "";

    if ($("#select2-drpVehicle-container") == undefined) {
        VehicleName = "";
    }
    else {
        VehicleName = $("#select2-drpVehicle-container").attr('title');
    }
  
    var vViewModel =
        {
            Vehicle: {
                VehicleName: VehicleName,
                VehicleTypeId: $("#drpVehicleType").val(),
                VehicleBrandId: $("#drpVehicleBrand").val(),

            },
            Pager: {

                CurrentPage: $('#tblVehicle').attr("data-current-page"),
            },
        }

    PostAjaxJson("/Vehicle/GetVehicles", vViewModel, BindVehicles);
}

function BindVehicles(data) {


    var list = JSON.parse(data);

    var kTable = {
        dataList: ["VehicleName", "VehicleTypeName", "VehicleBrandName", "SeatCapacity", "IsActive"],
        primayKey: "VehicleId",
        hiddenFields: ["VehicleId", "VehicleTypeId", "VehicleBrandId", "VehicleName", "IsActive"],
        headerNames: ["Vehicle Name", "Vehicle Type Name", "Vehicle Brand Name", "Seat Capacity", "IsActive"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblVehicle'));

    BindPagination(list.Pager, $('#tblVehicle'), 'VehiclePagination');


}

function VehiclePagination(CurrentPage) {
    $('#tblVehicle').attr("data-current-page", CurrentPage);
    GetVehicleListing();
}

function GetSupplierHotelTariffDays(id) {


    $("#dvItinerary").find("#divDays").load("/SupplierHotelTariff/GetSupplierHotelTariffDays", { SupplierHotelId: id }, function () {

    });

}
