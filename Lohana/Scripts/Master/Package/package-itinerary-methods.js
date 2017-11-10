
// Package Itinerary


function SavePackageItinerary() {

    $("#frmPackageItineraryDetails").blur();

    var pViewModel = {

        PackageItinerary: {

            PackageItineraryId: $("[name='PackageItinerary.PackageItineraryId']").val(),

            PackageId: $("#hdnPackageId").val(),

            Day: $("[name='Package.PackageDay']").val(),

            DayTitle: $("[name='Package.PackageDayTitle']").val(), 

            MealId: $("#drpMeal").val(),

            SightSeeing: $("[name='Package.Sightseeing']").val(),



        }
    }

    var url = "";

    if ($("[name='PackageItinerary.PackageItineraryId']").val() == 0) {

       url = "/Package/InsertPackageItinerary"
    }
    else {

        url = "/Package/UpdatePackageItinerary"
    }
    PostAjaxJson(url, pViewModel, AfterPackageItinerarySave);
}

function AfterPackageItinerarySave(data) {

    debugger;

    FriendlyMessage(data);

    $("#hdnPackageId").val(data.PackageItinerary.PackageId);

    ResetPackageItinerary();

    GetPackageItinerary();

    

}

function ResetPackageItinerary() {

    $("[name='Package.PackageDay']").val('');

    $("[name='PackageItinerary.PackageItineraryId']").val(0);

    $("[name='Package.PackageDayTitle']").val('');

    $("#drpMeal").html("");

    $("[name='Package.Sightseeing']").val('');

    $(".note-editable").html('');

}

function GetPackageItinerary() {

    debugger;

    var pViewModel =
		{
		    PackageItinerary: {

		        PackageId: $("#hdnPackageId").val()

		    },
		    Pager: {

		        CurrentPage: $('#tblPackageItinerary').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/Package/GetPackageItinerary", pViewModel, BindPackageItinerary);
}

function BindPackageItinerary(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["PackageDay", "PackageDayTitle", "MealName", "SightSeeing"],
        primayKey: "PackageItineraryId",
        hiddenFields: ["PackageItineraryId", "PackageId"],
        headerNames: ["Day", "Day Title", "Meal Name", "Sight Seeing"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblPackageItinerary'));

    BindPagination(list.Pager, $('#tblPackageItinerary'), "ItineraryPagination");

}

function ItineraryPagination(CurrentPage) {

    $('#tblPackageItinerary').attr("data-current-page", CurrentPage);

    GetPackageItinerary();

}

function GetPackageItineraryById(data) {

    var pViewModel =
      {

          PackageItinerary: {

              PackageItineraryId: $("[name='PackageItineraryFilter.PackageItineraryId']").val()

          },
          Pager: {

              CurrentPage: $('#hdnCurrentPage').val()
          },
      }

    PostAjaxJson("/Package/GetPackageItineraryById", pViewModel, BindPackageItineraryById);

}

function BindPackageItineraryById(obj) { 
   
    debugger;

    $("[name='PackageItinerary.PackageItineraryId']").val(obj.PackageItinerary.PackageItineraryId);

    $("[name='PackageItinerary.PackageId']").val(obj.PackageItinerary.PackageId);

    $("[name='Package.PackageDay']").val(obj.PackageItinerary.Day);

    $("[name='Package.PackageDayTitle']").val(obj.PackageItinerary.DayTitle);

    $("[name='Package.MealId']").attr("data-value", obj.PackageItinerary.MealId);

    GetAutocompleteById("Package.MealId");
     
    $("textarea#txtSightSeeing").val(obj.PackageItinerary.SightSeeing); 

    $('textarea#txtSightSeeing').summernote('code', obj.PackageItinerary.SightSeeing);

}

function DeletePackageItinerary() {

    var pViewModel =
      {

          PackageItinerary: {

              PackageItineraryId: $("[name='PackageItineraryFilter.PackageItineraryId']").val(),

              PackageId: $("#hdnPackageId").val()

          },
          Pager: {

              CurrentPage: $('#hdnCurrentPage').val()
          },
      }

    PostAjaxJson("/Package/DeletePackageItinerary", pViewModel, AfterPackageItineraryDelete);

    //$("[name='PackageItineraryFilter.PackageItineraryId']").val('');

}

function AfterPackageItineraryDelete(data) {

    FriendlyMessage(data);

    GetPackageItinerary();

    ResetPackageItinerary();

}