function SaveSupplierOccupancyDetail()
{
    var sViewModel =
        {
            SupplierOccupancyDetail: {

                SupplierHotelId: $("[name='SupplierOccupancyDetail.SupplierHotelId']").val(),

                OccupancyDetailId: $("[name='SupplierOccupancyDetail.OccupancyDetailId']").val(),

                OccupancyId: $("[name='SupplierOccupancyDetail.OccupancyId']").val(),

                AgeFrom: $("[name='SupplierOccupancyDetail.AgeFrom']").val(),

                AgeTo: $("[name='SupplierOccupancyDetail.AgeTo']").val(),
         
            }
        }

    var url = "";

    if ($("[name='SupplierOccupancyDetail.OccupancyDetailId']").val() == 0) {

        url = "/SupplierHotelTariff/InsertSupplierOccupancyDetail"
    }
    else {
        url = "/SupplierHotelTariff/UpdateSupplierOccupancyDetail"
    }

    PostAjaxWithProcessJson(url, sViewModel, AfterSupplerOccupancyDetailSave, $("body"));
}

function AfterSupplerOccupancyDetailSave(data) {
    FriendlyMessage(data);

    ResetSupplierOccupancyDetail();

    GetSupplierOccupancyDetail();
}

function GetSupplierOccupancyDetail() {
    var sViewModel =
		{
		    SupplierOccupancyDetail: {

		        SupplierHotelId: $("[name='SupplierOccupancyDetail.SupplierHotelId']").val(),
		    },
		    Pager: {

		        CurrentPage: $('#tblSupplierOccupancyDetails').attr("data-current-page"),
		    },
		}

    //alert($('#tblSupplierOccupancyDetails').attr("data-current-page"));
    //alert($("[name='SupplierOccupancyDetail.SupplierHotelId']").val());

    //alert(JSON.stringify(sViewModel));

    PostAjaxWithProcessJson("/SupplierHotelTariff/GetSupplierOccupancyDetail", sViewModel, BindSupplierOccupancyDetail, $('#tblSupplierOccupancyDetails'));
}

function BindSupplierOccupancyDetail(data) {
    var list = JSON.parse(data);

    var kTable = {
        dataList: ["OccupancyName"],
        primayKey: "OccupancyDetailId",
        hiddenFields: ["OccupancyDetailId", "OccupancyId", "AgeFrom", "AgeTo"],
        headerNames: ["Occupancy"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblSupplierOccupancyDetails'));

    BindPagination(list.Pager, $('#tblSupplierOccupancyDetails'), "SupplierOccupancyPagination");

}

function SupplierOccupancyPagination(CurrentPage) {

    $('#tblSupplierOccupancyDetails').attr("data-current-page", CurrentPage);

    GetSupplierOccupancyDetail();
}

function ResetSupplierOccupancyDetail() {

    $("[name='SupplierOccupancyDetail.OccupancyId']").html("");

    $("[name='SupplierOccupancyDetail.OccupancyDetailId']").val("");

    $("#txtAgeFrom").val('');

    $("#txtAgeTo").val('');

}

//function FillOccupancyDDL(LocationId) {
//    var sViewModel =
//		{
//		    SupplierHotelDetail: {

//		        CityId: LocationId,
//		    },
//		}

//    PostAjaxWithProcessJson("/SupplierHotelTariff/GetHotelByLocation", sViewModel, BindHotelDropdown, $("body"));
//}


function SetOccupancyDetail(obj) {
    var OccupancyId = obj.attr("data-occupancyid");

    var OccupancyDetailId = obj.attr("data-occupancydetailid");

    var agefrom = $(obj).attr("data-agefrom");

    var ageto = $(obj).attr("data-ageto");

    $("[name='SupplierOccupancyDetail.OccupancyDetailId']").val(OccupancyDetailId);

    $("[name='SupplierOccupancyDetail.AgeFrom']").val(agefrom);

    $("[name='SupplierOccupancyDetail.AgeTo']").val(ageto);

    $("[name='SupplierOccupancyDetail.OccupancyId']").attr("data-value", OccupancyId);

    GetAutocompleteById("SupplierOccupancyDetail.OccupancyId");

  
}



