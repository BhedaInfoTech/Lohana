function GetVehicleListing() {

    var lpViewModel =
		{
		    LohanaPackageTariffVehicle: {

		        VendorId: $("#drpVendorId").val(),

		        VehicleId: $("#drpVehicleId").val(),

		   

		    },
		    Pager: {

		        CurrentPage: $('#tblVehicleTariffPriceDetails').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/LohanaPackageTariff/GetVehicleListing", lpViewModel, BindVehicle);
}

function BindVehicle(data) {
    var list = JSON.parse(data);

    var kTable = {
        dataList: ["VendorName", "VehicleName","PackageName"],
        primayKey: ["VehicleTariffId"],
        hiddenFields: ["VendorId", "VehicleId", "VehicleTariffId", "VendorName", "VehicleName", "PackageName", "VehicleTariffPriceDetalsId"],
        headerNames: ["Vendor", "Vehicle","Package"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblVehicleTariffPriceDetails'));

    BindPagination(list.Pager, $('#tblVehicleTariffPriceDetails'), "VehiclePagination");
}

function VehiclePagination(CurrentPage) {

    $('#tblVehicleTariffPriceDetails').attr("data-current-page", CurrentPage);

    GetVehicleListing();
}

function SaveVehicle() {

    $("#frmLohanaPackageTariffVehicle").blur();

    var lpViewModel = {

        LohanaPackageTariffVehicle: {

            LohanaPackageTariffVehicleId: $("[name='LohanaPackageTariffVehicle.LohanaPackageTariffVehicleId']").val(),

            LohanaPackageTariffId: $("[name='LohanaPackageTariffVehicle.LohanaPackageTariffId']").val(),

            VehicleTariffId: $("[name='LohanaPackageTariffVehicle.VehicleTariffId']").val(),

            VehicleId: $("[name='LohanaPackageTariffVehicle.VehicleId']").val(),

            NoOfNight: $("[name='LohanaPackageTariffVehicle.NoOfNight']").val(),

        }
    }
    var url = "";

    if ($("[name='LohanaPackageTariffVehicle.LohanaPackageTariffVehicleId']").val() == 0) {

        url = "/LohanaPackageTariff/InsertLohanaPackageTariffVehicle"
    }
    else {

        url = "/LohanaPackageTariff/UpdateLohanaPackageTariffVehicle"
    }

    PostAjaxJson(url, lpViewModel, AfterVehicleSave);
}

function AfterVehicleSave(data) {

    FriendlyMessage(data);

    $("[name='LohanaPackageTariffVehicle.LohanaPackageTariffId']").val(data.LohanaPackageTariffVehicle.LohanaPackageTariffId);

    $("[name='LohanaPackageTariffVehicle.VehicleTariffId']").val(data.LohanaPackageTariffVehicle.VehicleTariffId);

    GetVehicle();

    ResetVehicle();

}

function ResetVehicle() {

    $("#hdnLohanaPackageTariffVehicleId").val('');

    $("[name='LohanaPackageTariffVehicle.NoOfNight']").val('');

    $("[name='LohanaPackageTariffVehicle.VehicleId']").val('');

    $("[name='LohanaPackageTariffVehicle.VehicleTariffId']").val('');

    $("[name='LohanaPackageTariffVehicle.VehicleTariffPriceDetailsId']").val('');

}

function GetVehicle() {

    var lpViewModel =
		{
		    LohanaPackageTariffVehicle: {

		        LohanaPackageTariffId: $("[name='LohanaPackageTariffVehicle.LohanaPackageTariffId']").val(),

		        VehicleTariffId: $("[name='LohanaPackageTariffVehicle.VehicleTariffId']").val(),

		        VehicleTariffPriceDetailsId:$("[name='LohanaPackageTariffVehicle.VehicleTariffPriceDetailsId']").val()
		    },
		    Pager: {

		        CurrentPage: $('#tblLohanaPackageTariffVehicle').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/LohanaPackageTariff/GetLohanaPackageTariffVehicle", lpViewModel, BindLohanaPackageTariffVehicle);

    $("#txtNights").val('');

}

function BindLohanaPackageTariffVehicle(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["VendorName","VehicleName","PackageName","NoOfNight"],
        primayKey: ["LohanaPackageTariffVehicleId"],
        hiddenFields: ["LohanaPackageTariffVehicleId", "LohanaPackageTariffId","VendorName","VehicleName","PackageName","NoOfNight","VehicleId","VehicleTariffId"],
        headerNames: ["Vendor","Vehicle","Package","No of Nights"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblLohanaPackageTariffVehicle'));

    BindPagination(list.Pager, $('#tblLohanaPackageTariffVehicle'), "LohanaPackageTariffVehiclePagination");

}


function DeleteVehicle() {

    var lpViewModel =
      {

          LohanaPackageTariffVehicle: {

              LohanaPackageTariffVehicleId: $("[name='LohanaPackageTariffVehicle.LohanaPackageTariffVehicleId']").val(),

              LohanaPackageTariffId: $("[name='LohanaPackageTariffVehicle.LohanaPackageTariffId']").val()

          },
          Pager: {

              CurrentPage: $('#tblLohanaPackageTariffVehicle').attr("data-current-page"),
          },
      }

    PostAjaxJson("/LohanaPackageTariff/DeleteLohanaPackageTariffVehicle", lpViewModel, AfterVehicleDelete);

}

function AfterVehicleDelete(data) {

    FriendlyMessage(data);

    ResetVehicle();

    GetVehicle();
}

function LohanaPackageTariffVehiclePagination(CurrentPage) {

    $('#tblLohanaPackageTariffVehicle').attr("data-current-page", CurrentPage);

    GetVehicle();

}