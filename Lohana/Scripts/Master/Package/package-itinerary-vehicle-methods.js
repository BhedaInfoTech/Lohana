function SavePackageItineraryVehicles() {

    $("#frmPackageItineraryVehicles").blur();

    debugger;

    var pViewModel = {

        PackageItinerary: {

            PackageItineraryVehicle: {

                //PackageItineraryVehicleId: $("[name='PackageItinerary.PackageItineraryVehicle.PackageItineraryVehicleId']").val(),

                PackageItineraryVehicleId: $("#hdnSearchPackageItineraryVehicleId").val(),

                PackageItineraryId: $("[name='PackageItineraryFilter.PackageItineraryId']").val(),

                VehicleName: $("[name='PackageItinerary.PackageItineraryVehicle.VehicleName']").val(),

                VehicleFrom: $("#drpVehicleFrom").val(),

                VehicleTo: $("#drpVehicleTo").val(),

                PickUp: $("#drpPickUp").val(),

                DropOff: $("#drpDropOff").val(),

                SupplierId: $("#drpItinerarySupplier").val(),

                VehicleCost: $("#drpItineraryVehicleCost").val(),

                VehicleTime: $("[name='PackageItinerary.PackageItineraryVehicle.VehicleTime']").val(),
            },
        }
    }

    var url = "";

    if ($("#hdnSearchPackageItineraryVehicleId").val() == 0) {

        url = "/Package/InsertPackageItineraryVehicle"
    }
    else {

        url = "/Package/UpdatePackageItineraryVehicle"
    }
    PostAjaxJson(url, pViewModel, AfterPackageItineraryVehicleSave);
}

function AfterPackageItineraryVehicleSave(data) {

    FriendlyMessagePopup(data);

    $("#hdnPackageItineraryVehicleId").val(data.PackageItinerary.PackageItineraryVehicle.PackageItineraryVehicleId);

    GetPackageItineraryVehicle();

    ResetPackageItineraryVehicle();

}

function ResetPackageItineraryVehicle() {

    $("#txtVehicle").val('');

    $("#hdnSearchPackageItineraryVehicleId").val(0);

    $("#txtVehicleTime").val('');

    $("#drpVehicleFrom").html("");

    $("#drpVehicleTo").html("");

    $("#drpItinerarySupplier").html("");

    $("#drpItineraryVehicleCost").val("");

    $("#drpPickUp").val('0');

    $("#drpDropOff").val('0');

}

function GetPackageItineraryVehicle() {

    debugger;

    var pViewModel =
		{
		    PackageItinerary: {

		        PackageItineraryId: $("[name='PackageItineraryFilter.PackageItineraryId']").val()
		    },
		    Pager: {

		        CurrentPage: $('#tblPackageItineraryVehicles').attr("data-current-page"),
		    }
		}

    PostAjaxJson("/Package/GetPackageItineraryVehicles", pViewModel, BindPackageItineraryVehicle);
}

function BindPackageItineraryVehicle(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["VehicleName", "VehicleFromName", "VehicleToName","PickUpName","DropOffName" ,"VehicleTime", "SupplierName", "VehicleCost"],
        primayKey: "PackageItineraryVehicleId",
        hiddenFields: ["PackageItineraryVehicleId", "PackageItineraryId"],
        headerNames: ["Vehicle Name", "Vehicle From", "Vehicle To","Pick Up","Drop Off", "Vehicle Time" , "Supplier Name", "Vehicle Cost"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblPackageItineraryVehicles'));

    BindPagination(list.Pager, $('#tblPackageItineraryVehicles'), "ItineraryPaginationVehicle");

}

function ItineraryPaginationVehicle(CurrentPage) {

    $('#tblPackageItineraryVehicles').attr("data-current-page", CurrentPage);

    GetPackageItineraryVehicle();

}

function GetPackageItineraryVehicleById(data) {

    var pViewModel =
      {

          PackageItinerary: {

              PackageItineraryVehicle: {
                  PackageItineraryVehicleId: $("[name='PackageItinerary.PackageItineraryVehicle.PackageItineraryVehicleId']").val()
              }
        },
          Pager: {

              CurrentPage: $('#hdnCurrentPage').val()
          },
      }

    PostAjaxJson("/Package/GetPackageItineraryVehicleById", pViewModel, BindPackageItineraryVehicleById);

}

function BindPackageItineraryVehicleById(obj) {

    debugger;
    alert(obj.PackageItinerary.PackageItineraryVehicle);
    $("[name='PackageItinerary.PackageItineraryVehicle.PackageItineraryVehicleId']").val(obj.PackageItinerary.PackageItineraryVehicle.PackageItineraryVehicleId);

    $("[name='PackageItinerary.PackageItineraryVehicle.VehicleName']").val(obj.PackageItinerary.PackageItineraryVehicle.VehicleName);

    $("#drpPickUp").val(obj.PackageItinerary.PackageItineraryVehicle.PickUp);

    $("#drpDropOff").val(obj.PackageItinerary.PackageItineraryVehicle.DropOff);

    $("[name='PackageItinerary.PackageItineraryVehicle.VehicleFrom']").attr("data-value", obj.PackageItinerary.PackageItineraryVehicle.VehicleFrom);

    GetAutocompleteById("PackageItinerary.PackageItineraryVehicle.VehicleFrom");

    $("[name='PackageItinerary.PackageItineraryVehicle.VehicleTo']").attr("data-value", obj.PackageItinerary.PackageItineraryVehicle.VehicleTo);

    GetAutocompleteById("PackageItinerary.PackageItineraryVehicle.VehicleTo");

    $("[name='PackageItinerary.PackageItineraryVehicle.SupplierId']").attr("data-value", obj.PackageItinerary.PackageItineraryVehicle.SupplierId);

    GetAutocompleteById("PackageItinerary.PackageItineraryVehicle.SupplierId");

    $("[name='PackageItinerary.PackageItineraryVehicle.VehicleCost']").val(obj.PackageItinerary.PackageItineraryVehicle.VehicleCost);

    var showdate = moment(obj.PackageItinerary.PackageItineraryVehicle.VehicleTime).format("MM/DD/YYYY hh:mm:ss");

    var datetimepart = showdate.split(' ');

    var timepart = datetimepart[1];

    $("[name='PackageItinerary.PackageItineraryVehicle.VehicleTime']").val(timepart);

}

function DeletePackageItineraryVehicle() {

    debugger;
    var pViewModel =
      {

          PackageItinerary: {

              PackageItineraryVehicle: {

                  PackageItineraryVehicleId: $("[name='PackageItinerary.PackageItineraryVehicle.PackageItineraryVehicleId']").val(),

                  PackageItineraryId: $("[name='PackageItineraryFilter.PackageItineraryId']").val()
              }

          },
          Pager: {

              CurrentPage: $('#hdnCurrentPage').val()
          },
      }

    PostAjaxJson("/Package/DeletePackageItineraryVehicle", pViewModel, AfterPackageItineraryVehicleDelete);

   // $("[name='PackageItineraryFilter.PackageItineraryId']").val('');

}

function AfterPackageItineraryVehicleDelete(data) {

    FriendlyMessagePopup(data);

    GetPackageItineraryVehicle();

    ResetPackageItineraryVehicle();

}