function SavePackageItineraryHotels() {

    $("#frmPackageItineraryHotels").blur();

    var pViewModel = {

        PackageItinerary: {

            PackageItineraryHotel: {

                PackageItineraryHotelId: $("[name='PackageItinerary.PackageItineraryHotel.PackageItineraryHotelId']").val(),

                PackageItineraryId: $("[name='PackageItineraryFilter.PackageItineraryId']").val(),

                HotelId: $("#drpItineraryHotel").val(),

                LocationId: $("#drpItineraryLocation").val(),

                SupplierId: $("#drpItinerarySupplier").val(),

                HotelCost: $("#drpItineraryHotelCost").val(),
            },
        }
    }

    var url = "";

    if ($("[name='PackageItinerary.PackageItineraryHotel.PackageItineraryHotelId']").val() == 0) {

        url = "/Package/InsertPackageItineraryHotel"
    }
    else {

        url = "/Package/UpdatePackageItineraryHotel"
    }
    PostAjaxJson(url, pViewModel, AfterPackageItineraryHotelSave);
}

function AfterPackageItineraryHotelSave(data) {

    FriendlyMessagePopup(data);

    $("#hdnPackageItineraryHotelId").val(data.PackageItinerary.PackageItineraryHotel.PackageItineraryHotelId);

    GetPackageItineraryHotel();

    ResetPackageItineraryHotel();

}

function ResetPackageItineraryHotel() {

    $("#drpItineraryHotel").html("");

    $("#drpItineraryLocation").html("");

    $("#drpItinerarySupplier").html("");

    $("#drpItineraryHotelCost").html("");

    $("[name='PackageItinerary.PackageItineraryHotel.PackageItineraryHotelId']").val(0);

}

function GetPackageItineraryHotel() {

    debugger;

    var pViewModel =
		{
		    PackageItinerary: {

		            PackageItineraryId: $("[name='PackageItineraryFilter.PackageItineraryId']").val()
		    },
		    Pager: {

		        CurrentPage: $('#tblPackageItineraryHotels').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/Package/GetPackageItineraryHotels", pViewModel, BindPackageItineraryHotel);
}

function BindPackageItineraryHotel(data) {

    var list = JSON.parse(data);
    //alert(list)
    var kTable = {
        dataList: ["HotelName", "Location", "supplierName", "HotelCost"],
        primayKey: "PackageItineraryHotelId",
        hiddenFields: ["PackageItineraryHotelId","PackageItineraryId"],
        headerNames: ["Hotel Name", "Location", "SupplierName", "HotelCost"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblPackageItineraryHotels'));

    BindPagination(list.Pager, $('#tblPackageItineraryHotels'), "ItineraryPaginationHotel");

}

function ItineraryPaginationHotel(CurrentPage) {

    $('#tblPackageItineraryHotels').attr("data-current-page", CurrentPage);

    GetPackageItineraryHotel();

}

function GetPackageItineraryHotelById(data) {

    //alert(data);

    var pViewModel =
      {

          PackageItinerary: {

              PackageItineraryHotel: {
                  PackageItineraryHotelId: $("[name='PackageItinerary.PackageItineraryHotel.PackageItineraryHotelId']").val()
              }

          },
          Pager: {

              CurrentPage: $('#hdnCurrentPage').val()
          },
      }

    PostAjaxJson("/Package/GetPackageItineraryHotelById", pViewModel, BindPackageItineraryHotelById);

}

function BindPackageItineraryHotelById(obj) {

   //alert(obj)

    $("[name='PackageItinerary.PackageItineraryHotel.PackageItineraryHotelId']").val(obj.PackageItinerary.PackageItineraryHotel.PackageItineraryHotelId);

    $("[name='PackageItinerary.PackageItineraryHotel.LocationId']").attr("data-value", obj.PackageItinerary.PackageItineraryHotel.LocationId);

    GetAutocompleteById("PackageItinerary.PackageItineraryHotel.LocationId");

    $("[name='PackageItinerary.PackageItineraryHotel.HotelId']").attr("data-value", obj.PackageItinerary.PackageItineraryHotel.HotelId);

    GetAutocompleteById("PackageItinerary.PackageItineraryHotel.HotelId");

    $("[name='PackageItinerary.PackageItineraryHotel.SupplierId']").attr("data-value", obj.PackageItinerary.PackageItineraryHotel.SupplierId);

    GetAutocompleteById("PackageItinerary.PackageItineraryHotel.SupplierId");

    $("[name='PackageItinerary.PackageItineraryHotel.HotelCost']").val(obj.PackageItinerary.PackageItineraryHotel.HotelCost);

    
}

function DeletePackageItineraryHotel() {

    debugger;

    var pViewModel =
      {

          PackageItinerary: {

              PackageItineraryHotel: {

                  PackageItineraryHotelId: $("[name='PackageItinerary.PackageItineraryHotel.PackageItineraryHotelId']").val(),

                  PackageItineraryId: $("[name='PackageItineraryFilter.PackageItineraryId']").val() 
              }

          },
          Pager: {

              CurrentPage: $('#hdnCurrentPage').val()
          },
      }

    PostAjaxJson("/Package/DeletePackageItineraryHotel", pViewModel, AfterPackageItineraryHotelDelete);

    //$("[name='PackageItineraryFilter.PackageItineraryId']").val('');

}

function AfterPackageItineraryHotelDelete(data) {

    FriendlyMessagePopup(data);

    GetPackageItineraryHotel();

    ResetPackageItineraryHotel();

}