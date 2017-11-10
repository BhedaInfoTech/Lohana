function GetRootDayWiseList(id) {

    var lpViewModel =
		{
		    LohanaPackageTariff: {
		        LohanaPackageTariffId: id
		    },
		    //Pager: {

		    //    CurrentPage: $('#tblHotelTariffRoomDetails').attr("data-current-page"),
		    //},
		}
    PostAjaxJson("/LohanaPackageTariff/GetLohanaPackageTariffRootList", lpViewModel, BindRoot);
    
}

function BindRoot(data) {
   
    var list = JSON.parse(data);
    //var dayduration = $("[name='LohanaPackageTariff.DayDuration']").val();
    $("#divDays").empty();
    if (list.Table != null) {
        for (var i = 0; i < list.Table.length; i++) {
            //var row = '<hr/>';
            var row = '<div class="row" id="divRowId_' + i + '">';
            row += '<div class="col-md-1"><div class="form-group"><div class="input-group"><label class="custom-control custom-radio">';
            row += '<input name="LohanaPackageTariff.Day" type="radio" class="custom-control-input" id="radioDay_' + i + '" value="' + list.Table[i].LohanaPackageTariffRootId + '" data-Title="' + (list.Table[i].Title != null ? list.Table[i].Title : "") + '">';
            row += '<span class="custom-control-indicator"></span>';
            row += '<span class="custom-control-description">&nbsp;Day ' + list.Table[i].Day + '</span>';
            row += '</label></div></div></div>';
            row += '<div class="col-md-2">' + (list.Table[i].Title != null ? list.Table[i].Title: "") + '</div>';
            row += '<div class="col-md-9">';
            row += '<div class="col-md-12 col-sm-12 col-xs-12">';
            row += '<div class="box bg-white">';
            row += '<ul class="nav nav-4">';
            if (list.Table1 != null) {
                for (var j = 0; j < list.Table1.length; j++) {
                    if (list.Table[i].Day == list.Table1[j].Day && list.Table1[j].LohanaPackageTariffRootDetailId != null) {
                        if ($("#frmRoomDetails input#hdnLohanaPackageTariffTypeId").val() == list.Table1[j].LohanaPackageTariffTypeId) {
                            row += '<li class="nav-item nav-link">';
                            row += '<i class="fa fa-hotel"></i> ' + list.Table1[j].RefTypeName + ' &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class="fa fa-remove" onClick="ConfirmDeleteRoot(' + list.Table1[j].LohanaPackageTariffRootDetailId + ');" style="float: right;"></i></a>';
                            row += '</li>';
                        }
                        else if ($("#frmSearchSightSeeing input#hdnLohanaPackageTariffTypeId").val() == list.Table1[j].LohanaPackageTariffTypeId) {
                            row += '<li class="nav-item nav-link">';
                            row += '<i class="fa fa-tree"></i> ' + list.Table1[j].RefTypeName + ' &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class="fa fa-remove" onClick="ConfirmDeleteRoot(' + list.Table1[j].LohanaPackageTariffRootDetailId + ');" style="float: right;"></i></a>';
                            row += '</li>';
                        }
                        else if ($("#frmSearchVehicle input#hdnLohanaPackageTariffTypeId").val() == list.Table1[j].LohanaPackageTariffTypeId) {
                            row += '<li class="nav-item nav-link">';
                            row += '<i class="fa fa-car"></i> ' + list.Table1[j].RefTypeName + ' &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class="fa fa-remove" onClick="ConfirmDeleteRoot(' + list.Table1[j].LohanaPackageTariffRootDetailId + ');" style="float: right;"></i></a>';
                            row += '</li>';
                        }
                        else if ($("#frmSearchMeal input#hdnLohanaPackageTariffTypeId").val() == list.Table1[j].LohanaPackageTariffTypeId) {
                            row += '<li class="nav-item nav-link">';
                            row += '<i class="ti-help-alt"></i> ' + list.Table1[j].RefTypeName + ' &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class="fa fa-remove" onClick="ConfirmDeleteRoot(' + list.Table1[j].LohanaPackageTariffRootDetailId + ');" style="float: right;"></i></a>';
                            row += '</li>';
                        }
                    }
                }
            }
            row += '</ul>';
            row += '</div>';
            row += '</div>';
            row += '</div>';
            row += '</div>';
            row += '<hr/>';
            $("#divDays").append(row);
        }
    }
}

function ResetSightSeeing() {
    $("#txtSightSeeingName").val('');
    $("[name='LohanaPackageTariffSightSeeing.CityId']").val('');
    $("[name='LohanaPackageTariffSightSeeing.CityId']").trigger("change");
    $("#select2-drpSightSeeingCity-container").text('Select Location');
    document.getElementById("frmSearchSightSeeing").reset();
    $("#btnSaveSightSeeing").attr("disabled", true);
}

function GetSightSeeingListing() {

    var sViewModel =
		{
		    SightSeeing: {

		        SightSeeingName: $("[name='LohanaPackageTariffSightSeeing.SightSeeingName']").val(),
		        CityId: $("#drpSightSeeingCity").val(),
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

function ResetVehicle() {
    //$("[name='Vehicle.VehicleId']").val("");
    document.getElementById("frmSearchVehicle").reset();
    $("[name='LohanaPackageTariffVehicle.VehicleName']").val("");
    $("#drpVehicleType").val("");
    $("#drpVehicleBrand").val("");
    $("[name='LohanaPackageTariffVehicle.VehicleBrandId']").trigger("change");
    $("[name='LohanaPackageTariffVehicle.VehicleTypeId']").trigger("change");
    $("#select2-drpVehicleType-container").text('Select vehicle type');
    $("#select2-drpVehicleBrand-container").text('Select vehicle brand');
    $("#btnSaveVehicle").attr("disabled", true);
}

function GetVehicleListing() {
    var vViewModel =
		{
		    Vehicle: {

		        VehicleId: "",
		        VehicleName: $("[name='LohanaPackageTariffVehicle.VehicleName']").val(),
		        VehicleTypeId: $("#drpVehicleType").val(),
		        VehicleBrandId: $("#drpVehicleBrand").val(),
		        //IsActive: $("[name='Vehicle.IsActive']").val()
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

//function ResetMeal() {
//    document.getElementById("frmSearchMal").reset();
//}

function GetMealsList() {

    var mViewModel =
		{
		    Meal: {
		        MealId: "",
		        MealName: $("[name='Meal.MealName']").val(),
		        MealDescription: $("[name='Meal.MealDescription']").val(),
		        //IsActive: $("[name='Meal.IsActive']").val()
		    },
		    Pager: {
		        CurrentPage: $('#tblMeal').attr("data-current-page"),
		    },
		}
    PostAjaxWithProcessJson("/Meal/GetMeals", mViewModel, BindMeals, $("#frmSearchMeal"));
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

function SetRootValue() {
    $("#hdnLohanaPackageTariffRootId").val();
}

function SaveRootDetail() {
    var lpViewModel =
       {
           LohanaPackageTariffRoot: {
               LohanaPackageTariffId: $("#txtLohanaPackageTariffId").val(),
               LohanaPackageTariffRootId: $("#hdnLohanaPackageTariffRootId").val(),
               LohanaPackageTariffRefId: $("#hdnLohanaPackageTariffRefId").val(),
               LohanaPackageTariffTypeId: $("#hdnLohanaPackageTariffTypeId").val(),
           },
           //Pager: {

           //    CurrentPage: $('#tblHotelTariffRoomDetails').attr("data-current-page"),
           //},
       }
    PostAjaxJson("/LohanaPackageTariff/InsertLohanaPackageTariffRootDetail", lpViewModel, AfterRootSave);
}

function AfterRootSave(data) {
    FriendlyMessage(data);
    GetRootDayWiseList(data.LohanaPackageTariffRoot.LohanaPackageTariffId);
    document.getElementById("frmLohanaPackageTariffRootDetails").reset();
    $("#frmLohanaPackageTariffRootDetails input#hdnLohanaPackageTariffRootId").val('');
    $("#frmLohanaPackageTariffRootDetails input#hdnLohanaPackageTariffRefId").val('');
    $("#frmLohanaPackageTariffRootDetails input#hdnLohanaPackageTariffTypeId").val('')
    $("#btnAddTitle").attr("disabled", true);
    $("#btnAddHotel").attr("disabled", true);
    $("#btnAddSightSeeing").attr("disabled", true);
    $("#btnAddVehicle").attr("disabled", true);
    $("#btnAddMeal").attr("disabled", true);
}

function SaveRootTitle() {
    var lpViewModel =
       {
           LohanaPackageTariffRoot: {
               LohanaPackageTariffId: $("#txtLohanaPackageTariffId").val(),
               LohanaPackageTariffRootId: $("#hdnLohanaPackageTariffRootId").val(),
               Title: $("#txtTitle").val(),
           },
       }
    PostAjaxJson("/LohanaPackageTariff/UpdateLohanaPackageTariffRootTitle", lpViewModel, AfterRootSave);
}

function DeleteRoot() {
    var lpViewModel =
       {
           LohanaPackageTariffRoot: {
               LohanaPackageTariffId: $("#txtLohanaPackageTariffId").val(),
               LohanaPackageTariffRootDetailId: $("#hdnLohanaPackageTariffRootDetailsId").val(),
               LohanaPackageTariffRefId: $("#hdnLohanaPackageTariffRefId").val(),
               LohanaPackageTariffTypeId: $("#hdnLohanaPackageTariffTypeId").val(),
           },
       }
    PostAjaxJson("/LohanaPackageTariff/DeleteLohanaPackageTariffRootDetail", lpViewModel, AfterRootSave);
}

function ConfirmDeleteRoot(id) {
    $("#modalConfirmDelete").modal("show");
    $("#hdnLohanaPackageTariffRootDetailsId").val(id);
}