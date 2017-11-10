function SavePackageItineraryTrains() {

    $("#frmPackageItineraryTrains").blur();

    debugger;

    var pViewModel = {

        PackageItinerary: {

            PackageItineraryTrain: {

                //PackageItineraryTrainId: $("[name='PackageItinerary.PackageItineraryTrain.PackageItineraryTrainId']").val(),

                PackageItineraryTrainId: $("#hdnSearchPackageItineraryTrainId").val(),

                PackageItineraryId: $("[name='PackageItineraryFilter.PackageItineraryId']").val(),

                TrainName: $("[name='PackageItinerary.PackageItineraryTrain.TrainName']").val(),

                TrainFrom: $("#drpTrainFrom").val(),

                TrainTo: $("#drpTrainTo").val(),

                TrainTime: $("[name='PackageItinerary.PackageItineraryTrain.TrainTime']").val(),
            },
        }
    }

    var url = "";

    if ($("#hdnSearchPackageItineraryTrainId").val() == 0) {

        url = "/Package/InsertPackageItineraryTrain"
    }
    else {

        url = "/Package/UpdatePackageItineraryTrain"
    }
    PostAjaxJson(url, pViewModel, AfterPackageItineraryTrainSave);
}

function AfterPackageItineraryTrainSave(data) {

    FriendlyMessagePopup(data);

    $("#hdnPackageItineraryTrainId").val(data.PackageItinerary.PackageItineraryTrain.PackageItineraryTrainId);

    GetPackageItineraryTrain();

    ResetPackageItineraryTrain();

}

function ResetPackageItineraryTrain() {

    $("#txtTrain").val('');

    $("#txtTrainTime").val('');

    $("#drpTrainFrom").html("");

    $("#drpTrainTo").html("");

    $("#hdnSearchPackageItineraryTrainId").val(0);

}

function GetPackageItineraryTrain() {

    debugger;

    var pViewModel =
		{
		    PackageItinerary: {

		        PackageItineraryId: $("[name='PackageItineraryFilter.PackageItineraryId']").val()
		    },
		    Pager: {

		        CurrentPage: $('#tblPackageItineraryTrains').attr("data-current-page"),
		    }
		}

    PostAjaxJson("/Package/GetPackageItineraryTrains", pViewModel, BindPackageItineraryTrain);
}

function BindPackageItineraryTrain(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["TrainName", "TrainFromName", "TrainToName", "TrainTime"],
        primayKey: "PackageItineraryTrainId",
        hiddenFields: ["PackageItineraryTrainId", "PackageItineraryId"],
        headerNames: ["Train Name", "Train From", "Train To", "Train Time"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblPackageItineraryTrains'));

    BindPagination(list.Pager, $('#tblPackageItineraryTrains'), "ItineraryPaginationTrain");

}

function ItineraryPaginationTrain(CurrentPage) {

    $('#tblPackageItineraryTrains').attr("data-current-page", CurrentPage);

    GetPackageItineraryTrain();

}

function GetPackageItineraryTrainById(data) {

    var pViewModel =
      {

          PackageItinerary: {

              PackageItineraryTrain: {
                  PackageItineraryTrainId: $("[name='PackageItinerary.PackageItineraryTrain.PackageItineraryTrainId']").val()
              }

          },
          Pager: {

              CurrentPage: $('#hdnCurrentPage').val()
          },
      }

    PostAjaxJson("/Package/GetPackageItineraryTrainById", pViewModel, BindPackageItineraryTrainById);

}

function BindPackageItineraryTrainById(obj) {

    debugger;

    $("[name='PackageItinerary.PackageItineraryTrain.PackageItineraryTrainId']").val(obj.PackageItinerary.PackageItineraryTrain.PackageItineraryTrainId);

    $("[name='PackageItinerary.PackageItineraryTrain.TrainName']").val(obj.PackageItinerary.PackageItineraryTrain.TrainName);

    $("[name='PackageItinerary.PackageItineraryTrain.TrainFrom']").attr("data-value", obj.PackageItinerary.PackageItineraryTrain.TrainFrom);

    GetAutocompleteById("PackageItinerary.PackageItineraryTrain.TrainFrom");

    $("[name='PackageItinerary.PackageItineraryTrain.TrainTo']").attr("data-value", obj.PackageItinerary.PackageItineraryTrain.TrainTo);

    GetAutocompleteById("PackageItinerary.PackageItineraryTrain.TrainTo");

    var showdate = moment(obj.PackageItinerary.PackageItineraryTrain.TrainTime).format("MM/DD/YYYY hh:mm:ss");

    var datetimepart = showdate.split(' ');

    var timepart = datetimepart[1];

    $("[name='PackageItinerary.PackageItineraryTrain.TrainTime']").val(timepart);

}

function DeletePackageItineraryTrain() {

    debugger;

    var pViewModel =
      {

          PackageItinerary: {

              PackageItineraryTrain: {

                  PackageItineraryTrainId: $("[name='PackageItinerary.PackageItineraryTrain.PackageItineraryTrainId']").val(),

                  PackageItineraryId: $("[name='PackageItineraryFilter.PackageItineraryId']").val()
              }

          },
          Pager: {

              CurrentPage: $('#hdnCurrentPage').val()
          },
      }

    PostAjaxJson("/Package/DeletePackageItineraryTrain", pViewModel, AfterPackageItineraryTrainDelete);

    //$("[name='PackageItineraryFilter.PackageItineraryId']").val('');

}

function AfterPackageItineraryTrainDelete(data) {

    FriendlyMessagePopup(data);

    GetPackageItineraryTrain();

    ResetPackageItineraryTrain();

}