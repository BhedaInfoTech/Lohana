function SaveVehicle() {

    debugger;
    
    if ($("[name='Vehicle.IsActive']").val() == 1 || $("[name='Vehicle.IsActive']").val() == "true" || $("[name='Vehicle.IsActive']").val() == "True")  {

        activeFlg = true;
    }
    else {
        activeFlg = false;
    }


    $("#frmVehicle").blur();

    var vViewModel = {

        Vehicle: {

            VehicleId: $("[name='Vehicle.VehicleId']").val(),

            VehicleName: $("[name='Vehicle.VehicleName']").val(),

            SeatCapacity: $("[name='Vehicle.SeatCapacity']").val(),

            VehicleTypeId: $("#drpVehicleTypeId").val(),

            VehicleBrandId: $("#drpVehicleBrandId").val(),

            IsActive: activeFlg,

        }
    }

    var url = "";

    if ($("[name='Vehicle.VehicleId']").val() == 0) {

        url = "/Vehicle/Insert"
    }
    else {

        url = "/Vehicle/Update"
    }

    PostAjaxWithProcessJson(url, vViewModel, AfterSave, $("body"));
}

function AfterSave(data) {

    FriendlyMessage(data);

}

function ResetVehicle() {

    $("[name='Vehicle.VehicleId']").val("");

    $("[name='Vehicle.VehicleName']").val("");

    $("[name='Vehicle.SeatCapacity']").val("");

    $("#drpVehicleTypeId").val("");

    $("#drpVehicleBrandId").val("");

    if ($("[name='Vehicle.IsActive']").val() == 0 || $("[name='Vehicle.IsActive']").val() == "false") {
        $('.switchery').trigger('click');
    }
}
