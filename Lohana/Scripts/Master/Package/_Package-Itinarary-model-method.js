function GetHotelPackageListing() {
    //alert(1)

    var lpViewModel =
		{
		    LohanaPackageTariffHotel: {

		        CityId: $("[name='packagedaytriff.CityId']").val(),

		        HotelId: $("[name='packagedaytriff.HotelId']").val(),

		        RoomTypeId: $("[name='packagedaytriff.RoomTypeId']").val(),

		        //MealId: $("[name='SupplierHotelDayItem.MealId']").val(),

		    },
		    Pager: {

		        CurrentPage: $('#tblHotelPackageTariffRoomDetails').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/LohanaPackageTariff/GetHotelListing", lpViewModel, BindHotel);
}

function BindHotel(data) {
    var list = JSON.parse(data);

    var kTable = {

        dataList: ["HotelName", "RoomTypeName", "NoOfNight", "CityName"],
        primayKey: ["HotelTariffRoomDetailsId"],
        hiddenFields: ["HotelTariffRoomDetailsId", "HotelId", "RoomTypeId"],
        headerNames: ["Hotel Name", "Room Type", "No of Nights", "Location"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblHotelPackageTariffRoomDetails'));

    BindPagination(list.Pager, $('#tblHotelPackageTariffRoomDetails'), "HotelPagination");
}

function HotelPagination(CurrentPage) {

    $('#tblHotelPackageTariffRoomDetails').attr("data-current-page", CurrentPage);

    GetHotelPackageListing();
}


function GetPackageSightSeeingListing() {
    
    var sViewModel =
		{
		    SightSeeing: {

		        SightSeeingName: $("#select2-drpSiteSeeing-container").attr('title'),
		        CityId: $("[name='packagedaytriff.CityId']").val(),
		    },
		    Pager: {

		        CurrentPage: $('#tblPackageSightSeeing').attr("data-current-page"),
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
    buildHtmlTable(kTable, $('#tblPackageSightSeeing'));

    BindPagination(list.Pager, $('#tblPackageSightSeeing'), 'SightSeeingPagination');
}

function SightSeeingPagination(CurrentPage) {
    $('#tblPackageSightSeeing').attr("data-current-page", CurrentPage);
    GetPackageSightSeeingListing();
}



function GetPackageVehicleListing() {

    var vViewModel =
        {
            Vehicle: {


                VehicleName: $("#select2-drpVehicle-container").attr('title'),
                VehicleTypeId: $("#drpVehicleType").val(),
                VehicleBrandId: $("#drpVehicleBrand").val(),

            },
            Pager: {

                CurrentPage: $('#tblPackageVehicle').attr("data-current-page"),
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

    buildHtmlTable(kTable, $('#tblPackageVehicle'));

    BindPagination(list.Pager, $('#tblPackageVehicle'), 'VehiclePagination');


}

function VehiclePagination(CurrentPage) {
    $('#tblPackageVehicle').attr("data-current-page", CurrentPage);
    GetPackageVehicleListing();
}


function GetPackageMealsList() {

    //alert($("#select2-drpMeal-container").attr('title'));
    var mViewModel =
		{
		    Meal: {
		        MealName: $("").val(),
		        
		        
		        MealDescription: $("[name='Meal.MealDescription']").val(),

		    },
		    Pager: {
		        CurrentPage: $('#tblPackageMeal').attr("data-current-page"),
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
    buildHtmlTable(kTable, $('#tblPackageMeal'));
    BindPagination(list.Pager, $('#tblPackageMeal'), 'MealPagination');
}

function MealPagination(CurrentPage) {
    $('#tblPackageMeal').attr("data-current-page", CurrentPage);
    GetPackageMealsList();
}



function SaveGitTitleDetails() {
   
    var pViewModel =
           {
               packagedaytriff: {
                   PackageDayId: $("#packagedayId").val(),
                   PackageId: $("#hdnPackageId").val(),
                   CityId: $("[name='packagedaytriff.CityId']").val(),
                   Title: $("#txtGitTitle").val()
               },
           }
  //  alert(JSON.stringify(pViewModel));
    PostAjaxJson("/Package/UpdatePackagedays", pViewModel, AfterTitleSave);
}

function AfterTitleSave() {
   
    
    $("#itinerary").find("#divDays").load("/Package/GetPackageGitTariffDays", { PackageId: $("#hdnPackageId").val() }, function () {

    });
   

    $('#modalParent').modal('hide');

}



function SavePackageDetails() {
   
    var pViewModel =
           {

               packageDayItems: 
                   {
                       PackageId: $("#hdnPackageId").val(),
                       PackageDayId: $("#packagedayId").val(),
                       HotelId: $("#hdnHotelId").val(),
                       RoomTypeId: $("#hdnRoomTypeId").val(),
                       SighSeeingID: $("#hdnPackageSightSeeingId").val(),
                       VehicalId: $("#hdnVehicleId").val(),
                       MealId: $("#hdnMealId").val(),

                   },

           }
   // alert(JSON.stringify(pViewModel));
       PostAjaxJson("/Package/InsertPackageDayItem", pViewModel, AfterTitleSave);

}

