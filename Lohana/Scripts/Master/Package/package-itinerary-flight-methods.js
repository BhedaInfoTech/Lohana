function SavePackageItineraryFlights() {

    $("#frmPackageItineraryFlights").blur();

    debugger;

    var pViewModel = {

        PackageItinerary: {

            PackageItineraryFlight: {

                //PackageItineraryFlightId:  $("#hdnPackageItineraryFlightId").val(),

                PackageItineraryFlightId: $("#hdnSearchPackageItineraryFlightId").val(),

                PackageItineraryId: $("[name='PackageItineraryFilter.PackageItineraryId']").val(),

                FlightName: $("[name='PackageItinerary.PackageItineraryFlight.FlightName']").val(),

                FlightFrom: $("#drpflightFrom").val(),

                FlightTo: $("#drpflightTo").val(),

                FlightTime: $("[name='PackageItinerary.PackageItineraryFlight.FlightTime']").val(),
            },
        }
    }

    var url = "";

    //alert($("#hdnSearchPackageItineraryFlightId").val());

    if ($("#hdnSearchPackageItineraryFlightId").val() == 0) {

        url = "/Package/InsertPackageItineraryFlight"
    }
    else {

        url = "/Package/UpdatePackageItineraryFlight"
    }
    PostAjaxJson(url, pViewModel, AfterPackageItineraryFlightSave);
}

function AfterPackageItineraryFlightSave(data) {

    debugger;

    FriendlyMessagePopup(data);

   //$("#hdnPackageFlightItineraryId").val(data.PackageItinerary.PackageItineraryFlight.PackageItineraryId);

   // $("#hdnPackageItineraryFlightId").val(data.PackageItinerary.PackageItineraryFlight.PackageItineraryFlightId);

    ResetPackageItineraryFlight();

    GetPackageItineraryFlight();

   

}

function ResetPackageItineraryFlight() {

    $("#txtflight").val('');

    $("#txtflightTime").val('');

    $("#drpflightFrom").html("");

    $("#drpflightTo").html("");

    $("#hdnSearchPackageItineraryFlightId").val(0);

    //$("[name='PackageItinerary.PackageItineraryFlight.PackageItineraryFlightId']").val(0);

}

function GetPackageItineraryFlight() {

    debugger;

    var pViewModel =
		{
		    PackageItinerary: {

		        PackageItineraryId: $("[name='PackageItineraryFilter.PackageItineraryId']").val()
		    },
		    Pager: {

		        CurrentPage: $('#tblPackageItineraryFlights').attr("data-current-page"),
		    }
		}

    PostAjaxJson("/Package/GetPackageItineraryFlights", pViewModel, BindPackageItineraryFlight);
}

function BindPackageItineraryFlight(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["FlightName", "FlightFromName", "FlightToName", "FlightTime"],
        primayKey: "PackageItineraryFlightId",
        hiddenFields: ["PackageItineraryFlightId", "PackageItineraryId"],
        headerNames: ["Flight Name", "Flight From", "Flight To", "Flight Time"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblPackageItineraryFlights'));

    BindPagination(list.Pager, $('#tblPackageItineraryFlights'), "ItineraryPaginationFlight");

}

function ItineraryPaginationFlight(CurrentPage) {

    $('#tblPackageItineraryFlights').attr("data-current-page", CurrentPage);

    GetPackageItineraryFlight();

}

function GetPackageItineraryFlightById(data) {


    var pViewModel =
      {

          PackageItinerary: {

              PackageItineraryFlight: {
                  PackageItineraryFlightId: $("[name='PackageItinerary.PackageItineraryFlight.PackageItineraryFlightId']").val()
              }

          },
          Pager: {

              CurrentPage: $('#hdnCurrentPage').val()
          },
      }

    PostAjaxJson("/Package/GetPackageItineraryFlightById", pViewModel, BindPackageItineraryFlightById);

}

function BindPackageItineraryFlightById(obj) {

    debugger;

    $("[name='PackageItinerary.PackageItineraryFlight.PackageItineraryFlightId']").val(obj.PackageItinerary.PackageItineraryFlight.PackageItineraryFlightId);

    $("[name='PackageItinerary.PackageItineraryFlight.FlightName']").val(obj.PackageItinerary.PackageItineraryFlight.FlightName);

    $("[name='PackageItinerary.PackageItineraryFlight.FlightFrom']").attr("data-value", obj.PackageItinerary.PackageItineraryFlight.FlightFrom);

    GetAutocompleteById("PackageItinerary.PackageItineraryFlight.FlightFrom");

    $("[name='PackageItinerary.PackageItineraryFlight.FlightTo']").attr("data-value", obj.PackageItinerary.PackageItineraryFlight.FlightTo);

    GetAutocompleteById("PackageItinerary.PackageItineraryFlight.FlightTo"); 
     
    var showdate = moment(obj.PackageItinerary.PackageItineraryFlight.FlightTime).format("MM/DD/YYYY hh:mm:ss");

    var datetimepart = showdate.split(' ');

    var timepart = datetimepart[1];

    $("[name='PackageItinerary.PackageItineraryFlight.FlightTime']").val(timepart);

}

function DeletePackageItineraryFlight() {

    debugger;

    var pViewModel =
      {

          PackageItinerary: {

              PackageItineraryFlight: {

                  PackageItineraryFlightId: $("[name='PackageItinerary.PackageItineraryFlight.PackageItineraryFlightId']").val(),

                  PackageItineraryId: $("[name='PackageItineraryFilter.PackageItineraryId']").val()
              }

          },
          Pager: {

              CurrentPage: $('#hdnCurrentPage').val()
          },
      }

    PostAjaxJson("/Package/DeletePackageItineraryFlight", pViewModel, AfterPackageItineraryFlightDelete);

    //$("[name='PackageItineraryFilter.PackageItineraryId']").val('');

}

function AfterPackageItineraryFlightDelete(data) {

    FriendlyMessagePopup(data);

    GetPackageItineraryFlight();

    ResetPackageItineraryFlight();

}