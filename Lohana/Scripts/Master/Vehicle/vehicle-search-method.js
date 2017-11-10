function GetVehicles() {

    var vViewModel =
		{
		    Vehicle: {

		           VehicleId: "",

		           VehicleName: $("[name='Vehicle.VehicleName']").val(),

		           VehicleTypeId: $("#drpVehicleType").val(),

		           VehicleBrandId: $("#drpVehicleBrand").val(),
                
		           IsActive: $("[name='Vehicle.IsActive']").val()

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

    BindPagination(list.Pager, $('#tblVehicle'));


}

function GetSetVehicleValues(obj) {

    var id = $(obj).attr("data-vehicleid");

    var vehicletypeid = $(obj).attr("data-vehicletypeid");

    var vehiclebrandid = $(obj).attr("data-vehiclebrandid");

    var vehiclename = $(obj).attr("data-vehiclename"); 

    $("#hdnSearchVehicleId").val(id);

    $("[name='Vehicle.VehicleTypeId']").trigger("change");

    $("[name='Vehicle.VehicleTypeId']").attr("data-value", vehicletypeid);

    GetAutocompleteById("Vehicle.VehicleTypeId");

    $("[name='Vehicle.VehicleBrandId']").attr("data-value", vehiclebrandid);

    GetAutocompleteById("Vehicle.VehicleBrandId");

    $("[name='Vehicle.VehicleBrandId']").trigger("vehiclebrandid");

    $("[name='Vehicle.VehicleName']").val(vehiclename);

}

function Pagination(CurrentPage) {

    $('#tblVehicle').attr("data-current-page", CurrentPage);

    GetVehicles();

}

function ResetVehicle() {

    $("[name='Vehicle.VehicleId']").val("");

    $("[name='Vehicle.VehicleName']").val("");

    $("#drpVehicleTypeId").val("");

    $("#drpVehicleBrandId").val("");

    if ($("[name='Vehicle.IsActive']").val() == 0 || $("[name='Vehicle.IsActive']").val() == "false") {

        $('.switchery').trigger('click');

    }
}