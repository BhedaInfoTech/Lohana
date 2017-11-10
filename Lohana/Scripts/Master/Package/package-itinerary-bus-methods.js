function SavePackageItineraryBuss() {

    $("#frmPackageItineraryBuss").blur();

    debugger;

    var pViewModel = {

        PackageItinerary: {

            PackageItineraryBus: {

                //PackageItineraryBusId: $("[name='PackageItinerary.PackageItineraryBus.PackageItineraryBusId']").val(),

                PackageItineraryBusId: $("#hdnSearchPackageItineraryBusId").val(),

                PackageItineraryId: $("[name='PackageItineraryFilter.PackageItineraryId']").val(),

                BusName: $("[name='PackageItinerary.PackageItineraryBus.BusName']").val(),

                BusFrom: $("#drpBusFrom").val(),

                BusTo: $("#drpBusTo").val(),

                BusTime: $("[name='PackageItinerary.PackageItineraryBus.BusTime']").val(),

                SupplierId: $("[name='PackageItinerary.PackageItineraryBus.SupplierId']").val(),

                BusCost: $("[name='PackageItinerary.PackageItineraryBus.BusCost']").val(),
            },
        }
    }

    var url = "";

    if ($("#hdnSearchPackageItineraryBusId").val() == 0) {

        url = "/Package/InsertPackageItineraryBus"
    }
    else {

        url = "/Package/UpdatePackageItineraryBus"
    }
    PostAjaxJson(url, pViewModel, AfterPackageItineraryBusSave);
}

function AfterPackageItineraryBusSave(data) {

    FriendlyMessagePopup(data);

    $("#hdnPackageItineraryBusId").val(data.PackageItinerary.PackageItineraryBus.PackageItineraryBusId);

    GetPackageItineraryBus();

    ResetPackageItineraryBus();

}

function ResetPackageItineraryBus() {

    $("#txtBus").val('');

    $("#txtBusTime").val('');

    $("#drpBusFrom").html("");

    $("#drpBusTo").html("");

    $("#drpItinerarySupplier").html("");

    $("#drpItineraryBusCost").val("");

    $("#hdnSearchPackageItineraryBusId").val(0);

}

function GetPackageItineraryBus() {

    debugger;

    var pViewModel =
		{
		    PackageItinerary: {

		        PackageItineraryId: $("[name='PackageItineraryFilter.PackageItineraryId']").val()
		    },
		    Pager: {

		        CurrentPage: $('#tblPackageItineraryBuss').attr("data-current-page"),
		    }
		}

    PostAjaxJson("/Package/GetPackageItineraryBuss", pViewModel, BindPackageItineraryBus);
}

function BindPackageItineraryBus(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["BusName", "BusFromName", "BusToName", "BusTime", "VendorName", "BusCost"],
        primayKey: "PackageItineraryBusId", 
        hiddenFields: ["PackageItineraryBusId", "PackageItineraryId"],
        headerNames: ["Bus Name", "Bus From", "Bus To", "Bus Time", "SupplierName","BusCost" ],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblPackageItineraryBuss'));

    BindPagination(list.Pager, $('#tblPackageItineraryBuss'), "ItineraryPaginationBus");

}

function ItineraryPaginationBus(CurrentPage) {

    $('#tblPackageItineraryBuss').attr("data-current-page", CurrentPage);

    GetPackageItineraryBus();

}

function GetPackageItineraryBusById(data) {

    var pViewModel =
      {

          PackageItinerary: {

              PackageItineraryBus: {
                  PackageItineraryBusId: $("[name='PackageItinerary.PackageItineraryBus.PackageItineraryBusId']").val()
              }

          },
          Pager: {

              CurrentPage: $('#hdnCurrentPage').val()
          },
      }

    PostAjaxJson("/Package/GetPackageItineraryBusById", pViewModel, BindPackageItineraryBusById);

}

function BindPackageItineraryBusById(obj) {

    debugger;

    $("[name='PackageItinerary.PackageItineraryBus.PackageItineraryBusId']").val(obj.PackageItinerary.PackageItineraryBus.PackageItineraryBusId);

    $("[name='PackageItinerary.PackageItineraryBus.BusName']").val(obj.PackageItinerary.PackageItineraryBus.BusName);

    $("[name='PackageItinerary.PackageItineraryBus.BusFrom']").attr("data-value", obj.PackageItinerary.PackageItineraryBus.BusFrom);

    GetAutocompleteById("PackageItinerary.PackageItineraryBus.BusFrom");

    $("[name='PackageItinerary.PackageItineraryBus.BusTo']").attr("data-value", obj.PackageItinerary.PackageItineraryBus.BusTo);

    GetAutocompleteById("PackageItinerary.PackageItineraryBus.BusTo");

    $("[name='PackageItinerary.PackageItineraryBus.SupplierId']").attr("data-value", obj.PackageItinerary.PackageItineraryBus.SupplierId);

    GetAutocompleteById("PackageItinerary.PackageItineraryBus.SupplierId");

    $("[name='PackageItinerary.PackageItineraryBus.BusCost']").val(obj.PackageItinerary.PackageItineraryBus.BusCost);

    var showdate = moment(obj.PackageItinerary.PackageItineraryBus.BusTime).format("MM/DD/YYYY hh:mm:ss");

    var datetimepart = showdate.split(' ');

    var timepart = datetimepart[1];

    $("[name='PackageItinerary.PackageItineraryBus.BusTime']").val(timepart);



}

function DeletePackageItineraryBus() {

    debugger;

    var pViewModel =
      {

          PackageItinerary: {

              PackageItineraryBus: {

                  PackageItineraryBusId: $("[name='PackageItinerary.PackageItineraryBus.PackageItineraryBusId']").val(),

                  PackageItineraryId: $("[name='PackageItineraryFilter.PackageItineraryId']").val()
              }

          },
          Pager: {

              CurrentPage: $('#hdnCurrentPage').val()
          },
      }

    PostAjaxJson("/Package/DeletePackageItineraryBus", pViewModel, AfterPackageItineraryBusDelete);

    //$("[name='PackageItineraryFilter.PackageItineraryId']").val('');

}

function AfterPackageItineraryBusDelete(data) {

    FriendlyMessagePopup(data);

    GetPackageItineraryBus();

    ResetPackageItineraryBus();

}